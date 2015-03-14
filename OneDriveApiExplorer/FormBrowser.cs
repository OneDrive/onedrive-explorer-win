using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using OneDrive;

namespace NewApiBrowser
{
    
    public partial class FormBrowser : Form
    {
        private ODConnection Connection { get; set; }
        private ODItem CurrentFolder { get; set; }
        private ODItem SelectedItem { get; set; }

        private OneDriveTile _selectedTile;

        private FormAsyncJobViewer JobStatusForm { get; set; }

        public FormBrowser()
        {
            InitializeComponent();

            JobStatusForm = new FormAsyncJobViewer();
        }

        private void ShowWork(bool working)
        {
            this.UseWaitCursor = working;
            this.progressBar1.Visible = working;

        }

        private async Task LoadFolderFromId(string id)
        {
            if (null == Connection) return;

            // Update the UI for loading something new
            ShowWork(true);
            LoadChildren(null);  // Clear the current folder view

            try
            {
                ODItemReference item = new ODItemReference { Id = id };
                var selectedItem = await Connection.GetItemAsync(item, ItemRetrievalOptions.DefaultWithChildrenThumbnails);
                ProcessFolder(selectedItem);
            }
            catch (ODException exception)
            {
                PresentOneDriveException(exception);
            }

            ShowWork(false);
        }

        private async void ProcessFolder(ODItem folder)
        {
            if (null != folder)
            {
                this.CurrentFolder = folder;

                LoadProperties(folder);

                ODItemCollection pagedItemCollection = await folder.PagedChildrenCollectionAsync(Connection, ChildrenRetrievalOptions.DefaultWithThumbnails);
                LoadChildren(pagedItemCollection, false);

                while (pagedItemCollection.MoreItemsAvailable())
                {
                    pagedItemCollection = await pagedItemCollection.GetNextPage(Connection);
                    LoadChildren(pagedItemCollection, false);
                }
            }
        }

        private void LoadProperties(ODItem item)
        {
            SelectedItem = item;
            oneDriveObjectBrowser1.SelectedItem = item;
        }

        private void LoadChildren(ODItemCollection items, bool clearExistingItems = true)
        {
            flowLayoutContents.SuspendLayout();
            
            if (clearExistingItems)
                flowLayoutContents.Controls.Clear();

            // Load the children
            if (null != items)
            {
                List<Control> newControls = new List<Control>();
                foreach (var obj in items.Collection)
                {
                    newControls.Add(CreateControlForChildObject(obj));
                }
                flowLayoutContents.Controls.AddRange(newControls.ToArray());
            }

            flowLayoutContents.ResumeLayout();
        }

        private void AddItemToFolderContents(ODItem obj)
        {
            flowLayoutContents.Controls.Add(CreateControlForChildObject(obj));
        }

        private void UpdateItemInFolderContents(ODItem originalItem, ODItem latestItem)
        {
            foreach (OneDriveTile tile in flowLayoutContents.Controls)
            {
                if (tile.SourceItem == originalItem)
                {
                    tile.SourceItem = latestItem;
                    tile.Name = latestItem.Id;
                }
            }
        }

        private void RemoveItemFromFolderContents(ODItem itemToDelete)
        {
            flowLayoutContents.Controls.RemoveByKey(itemToDelete.Id);
        }

        private Control CreateControlForChildObject(ODItem item)
        {
            OneDriveTile tile = new OneDriveTile { SourceItem = item, Connection = this.Connection };
            tile.Click += ChildObject_Click;
            tile.DoubleClick += ChildObject_DoubleClick;
            tile.Name = item.Id;
            return tile;
        }

        async void ChildObject_DoubleClick(object sender, EventArgs e)
        {
            var item = ((OneDriveTile)sender).SourceItem;

            // Look up the object by ID
            if (item.CanHaveChildren())
            {
                NavigateToItemWithChildren(item);
            }
            else
            {
                await DownloadAndSaveItem(item);
            }
        }

        void ChildObject_Click(object sender, EventArgs e)
        {
            if (null != _selectedTile)
            {
                _selectedTile.Selected = false;
            }
            
            var item = ((OneDriveTile)sender).SourceItem;
            LoadProperties(item);
            _selectedTile = (OneDriveTile)sender;
            _selectedTile.Selected = true;
        }

        private async void FormBrowser_Load(object sender, EventArgs e)
        {
            await SignIn();   
        }

        private async void NavigateToItemWithChildren(ODItem folder)
        {
            FixBreadCrumbForCurrentFolder(folder);
            await LoadFolderFromId(folder.Id);
        }

        private void FixBreadCrumbForCurrentFolder(ODItem folder)
        {
            var breadcrumbs = flowLayoutPanelBreadcrumb.Controls;
            bool existingCrumb = false;
            foreach (LinkLabel crumb in breadcrumbs)
            {
                if (crumb.Tag == folder)
                {
                    RemoveDeeperBreadcrumbs(crumb);
                    existingCrumb = true;
                    break;
                }
            }

            if (!existingCrumb)
            {
                LinkLabel label = new LinkLabel();
                label.Text = "> " + folder.Name;
                label.LinkArea = new LinkArea(2, folder.Name.Length);
                label.LinkClicked += linkLabelBreadcrumb_LinkClicked;
                label.AutoSize = true;
                label.Tag = folder;
                flowLayoutPanelBreadcrumb.Controls.Add(label);
            }
        }

        private void linkLabelBreadcrumb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel link = (LinkLabel)sender;

            RemoveDeeperBreadcrumbs(link);

            ODItem item = link.Tag as ODItem;
            if (null == item)
            {

                Task t = LoadFolderFromId("root");
            }
            else
            {
                Task t = LoadFolderFromId(item.Id);
            }
        }

        private void RemoveDeeperBreadcrumbs(LinkLabel link)
        {
            // Remove the breadcrumbs deeper than this item
            var breadcrumbs = flowLayoutPanelBreadcrumb.Controls;
            int indexOfControl = breadcrumbs.IndexOf(link);
            for (int i = breadcrumbs.Count - 1; i > indexOfControl; i--)
            {
                breadcrumbs.RemoveAt(i);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateConnectedStateUx()
        {
            bool connected = (null != this.Connection);
            signInToolStripMenuItem.Visible = !connected;
            signOutToolStripMenuItem.Visible = connected;
            flowLayoutPanelBreadcrumb.Visible = connected;
            flowLayoutContents.Visible = connected;
        }

        private async void signInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await SignIn();
        }
        private async Task SignIn()
        {
            Connection = await OAuthAuthenticator.SignInToMicrosoftAccount(this);
            if (null != Connection)
            {
                await LoadFolderFromId("root");
            }
            UpdateConnectedStateUx();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Connection = null;
            Properties.Settings.Default.RefreshToken = null;
            Properties.Settings.Default.Save();

            UpdateConnectedStateUx();
        }

        private bool IsConnected()
        {
            if (null == this.Connection)
                return false;

            return true;
        }

        //private async void chunkedUploadToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    await DoBitsUpload(false);
        //}

        //private async Task DoBitsUpload(bool useParallelAlgo)
        //{
        //    // Do a sequential bits upload
        //    if (!IsConnected())
        //    {
        //        MessageBox.Show("Not connected to a supported service.");
        //        return;
        //    }

        //    var targetFolder = this.CurrentFolder;
        //    string filename;
        //    using (var fileStream = GetFileStreamForUpload(targetFolder.Name, out filename))
        //    {
        //        if (null == fileStream)
        //        {
        //            return;
        //        }

        //        ShowWork(true);
        //        string path = targetFolder.Path() + "/" + filename;
        //        if (path.StartsWith("/root/"))
        //            path = path.Replace("/root/", "/LiveFolders/");
        //        var itemReference = ODConnection.ItemReferenceForDrivePath(path);
        //        var item = await Connection.UploadLargeFileAsync(itemReference, fileStream, new ItemUploadOptions
        //        {
        //            ProgressReporter = (int complete, long bytes, long total) =>
        //                {
        //                    System.Diagnostics.Debug.WriteLine("{3} - Transfer {0}%, {1}/{2}", complete, bytes, total, DateTime.Now);
        //                },
        //            AllowParallelUpload = useParallelAlgo
        //        });

        //        if (null != item)
        //        {
        //            AddItemToFolderContents(item);
        //        }
        //        else
        //        {
        //            MessageBox.Show("Something went wrong.");
        //        }

        //        ShowWork(false);
        //    }
        //}

        private System.IO.Stream GetFileStreamForUpload(string targetFolderName, out string originalFilename)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Upload to " + targetFolderName;
            dialog.Filter = "All Files (*.*)|*.*";
            dialog.CheckFileExists = true;
            var response = dialog.ShowDialog();
            if (response != DialogResult.OK)
            {
                originalFilename = null;
                return null;
            }

            try
            {
                originalFilename = System.IO.Path.GetFileName(dialog.FileName);
                return new System.IO.FileStream(dialog.FileName, System.IO.FileMode.Open);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error uploading file: " + ex.Message);
                originalFilename = null;
                return null;
            }
        }


        private async void createFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInputDialog dialog = new FormInputDialog("Create Folder", "New folder name:");
            var result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrEmpty(dialog.InputText))
            {
                string folderName = dialog.InputText;
                await CreateChildFolderInCurrentFolder(folderName);
            }
        }

        private async Task CreateChildFolderInCurrentFolder(string folderName)
        {
            try
            {
                var newFolder = await Connection.CreateFolderAsync(this.CurrentFolder.ItemReference(), folderName);
                if (newFolder != null)
                {
                    AddItemToFolderContents(newFolder);
                }
            }
            catch (ODException exception)
            {
                PresentOneDriveException(exception);
            }
        }

        private static void PresentOneDriveException(ODException exception)
        {
            string message = exception.Message;
            string code = "no-server-error-code";
            string json = null;

            var serverException = exception as ODServerException;
            if (null != serverException)
            {
                code = serverException.ServiceError.Code;
                json = serverException.ServiceError.JsonString();
            }
            
            MessageBox.Show(string.Format("OneDrive reported the following error:\r\ncode: {0}\r\nmessage: {1}\r\n{2}", code, message, json));
        }

        private async void deleteSelectedItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var itemToDelete = this.SelectedItem;
            var result = MessageBox.Show("Are you sure you want to delete " + itemToDelete.Name + "?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    bool wasDeleted = await Connection.DeleteItemAsync(itemToDelete.ItemReference(), ItemDeleteOptions.Default);
                    if (wasDeleted)
                    {
                        RemoveItemFromFolderContents(itemToDelete);
                        MessageBox.Show("Item was deleted successfully");
                    }
                }
                catch (ODException exception)
                {
                    PresentOneDriveException(exception);
                }
            }
        }

        private async void getChangesHereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var result = await Connection.ViewChangesAsync(this.CurrentFolder.ItemReference(), ViewChangesOptions.Default);
                FormSyncResults results = new FormSyncResults(Connection, result);
                results.Show();
            }
            catch (ODException ex)
            {
                PresentOneDriveException(ex);
            }
        }

        //private async void bitsParallelToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    await DoBitsUpload(true);
        //}

        private async void openFromOneDriveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cleanAppId = "0000000040131ABA";
            var result = await OneDriveSamples.Picker.FormOneDrivePicker.OpenFileAsync(cleanAppId, true, this);

            if (result == null)
            {
                return;
            }

            try
            {
                var pickedFilesContainer = await result.GetItemsFromSelectionAsync(this.Connection);
                ProcessFolder(pickedFilesContainer);
            }
            catch (ODException ex)
            {
                PresentOneDriveException(ex);
            }
        }

        private async void saveSelectedFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var item = this.SelectedItem;
            if (null == item)
            {
                MessageBox.Show("Nothing selected.");
                return;
            }

            await DownloadAndSaveItem(item);
        }

        private async Task DownloadAndSaveItem(ODItem item)
        {
            var dialog = new SaveFileDialog();
            dialog.FileName = item.Name;
            dialog.Filter = "All Files (*.*)|*.*";
            var result = dialog.ShowDialog();
            if (result != System.Windows.Forms.DialogResult.OK) return;

            var stream = await item.GetContentStreamAsync(Connection, StreamDownloadOptions.Default);
            using (var outputStream = new System.IO.FileStream(dialog.FileName, System.IO.FileMode.Create))
            {
                await stream.CopyToAsync(outputStream);
            }
        }

        private void ShowJobStatus()
        {
            JobStatusForm.Connection = Connection;
            JobStatusForm.RefreshStatus();
            JobStatusForm.Show();
        }

        private async void fromURLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInputDialog dialog = new FormInputDialog("Upload from URL", "Type the URL to save to this folder in OneDrive:");
            var result = dialog.ShowDialog();
            if (result != System.Windows.Forms.DialogResult.OK || String.IsNullOrEmpty(dialog.InputText))
                return;

            Uri remoteUrl = new Uri(dialog.InputText);
            var filename = System.IO.Path.GetFileName(remoteUrl.AbsolutePath);
            var job = await Connection.UploadFromUrlAsync(CurrentFolder.ItemReference(), dialog.InputText, filename);
            JobStatusForm.PendingJobs.Add(job);
            ShowJobStatus();
        }

        private async void newFileInCurrentFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var targetFolder = this.CurrentFolder;
            string filename;

            var stream = GetFileStreamForUpload(targetFolder.Name, out filename);
            if (null == stream)
                return;

            try
            {
                var uploadedItem = await Connection.PutNewFileToParentItemAsync(targetFolder.ItemReference(), filename, stream, ItemUploadOptions.Default);
                AddItemToFolderContents(uploadedItem);
            }
            catch (ODException exception)
            {
                PresentOneDriveException(exception);
            }
        }

        private async void replaceSelectedItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.SelectedItem == null)
            {
                MessageBox.Show("Nothing is selected.");
                return;
            }

            if (this.SelectedItem.CanHaveChildren())
            {
                MessageBox.Show("Cannot replace a folder with a file. Select a file item and try again.");
                return;
            }


            var targetItem = this.SelectedItem;
            string filename;
            var stream = GetFileStreamForUpload(targetItem.Name, out filename);
            if (null == stream)
                return;

            try
            {
                var uploadedItem = await Connection.PutContentsAsync(targetItem.ItemReference(), stream, ItemUploadOptions.Default);
                UpdateItemInFolderContents(targetItem, uploadedItem);
                LoadProperties(uploadedItem);
            }
            catch (ODException exception)
            {
                PresentOneDriveException(exception);
            }


        }

        private async void toPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename;
            var stream = GetFileStreamForUpload("Path", out filename);
            if (null == stream)
                return;

            FormInputDialog dialog = new FormInputDialog("Type Path", "Path to store file:");
            dialog.InputText = this.CurrentFolder.Path() + "/" + filename;

            var result = dialog.ShowDialog();
            if (result != System.Windows.Forms.DialogResult.OK && !string.IsNullOrEmpty(dialog.InputText))
            {
                return;
            }

            string path = dialog.InputText;
            try
            {
                var newItemReference = ODConnection.ItemReferenceForDrivePath(path);
                var newItem = await Connection.PutContentsAsync(newItemReference, stream, ItemUploadOptions.Default);
                AddItemToFolderContents(newItem);
            }
            catch (ODException exception)
            {
                PresentOneDriveException(exception);
            }
        }

        private async void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInputDialog dialog = new FormInputDialog("Search", "Search for:");

            var result = dialog.ShowDialog();
            if (result != System.Windows.Forms.DialogResult.OK && !string.IsNullOrEmpty(dialog.InputText))
            {
                return;
            }

            try
            {
                ShowWork(true);
                var results = await Connection.SearchForItemsAsync(ODConnection.ItemReferenceForItemId("root"), dialog.InputText, ItemRetrievalOptions.Default);
                var form = new FormSyncResults(Connection, results);
                form.Show();
            }
            catch (ODException exception)
            {
                PresentOneDriveException(exception);
            }
            ShowWork(false);
        }

        private async void largeFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename;
            var stream = GetFileStreamForUpload("Path", out filename);
            if (null == stream)
                return;

            FormInputDialog dialog = new FormInputDialog("Type Path", "Path to store file:");
            dialog.InputText = this.CurrentFolder.Path() + "/" + filename;

            var result = dialog.ShowDialog();
            if (result != System.Windows.Forms.DialogResult.OK && !string.IsNullOrEmpty(dialog.InputText))
            {
                return;
            }

            string path = dialog.InputText;
            try
            {
                var newItemReference = ODConnection.ItemReferenceForDrivePath(path);
                
                FormUploadProgress uploadForm = new FormUploadProgress(filename);
                var uploadOptions = ItemUploadOptions.Default;
                uploadOptions.ProgressReporter = uploadForm.UpdateProgress;

                uploadForm.Show();
                var newItem = await Connection.UploadLargeFileAsync(newItemReference, stream, uploadOptions);
                if (null != newItem)
                {
                    AddItemToFolderContents(newItem);
                }
                uploadForm.Close();
            }
            catch (ODException exception)
            {
                PresentOneDriveException(exception);
            }
        }

        private async void renameSelectedItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var itemToRename = this.SelectedItem;

            FormInputDialog dialog = new FormInputDialog("Rename selected item", "New item name");
            dialog.InputText = itemToRename.Name;

            var result = dialog.ShowDialog();
            if (result != System.Windows.Forms.DialogResult.OK)
                return;

            ODItem changes = new ODItem { Name = dialog.InputText };
            try
            {
                var renamedItem = await Connection.PatchItemAsync(itemToRename.ItemReference(), changes);
                UpdateItemInFolderContents(itemToRename, renamedItem);
            }
            catch (ODException ex)
            {
                PresentOneDriveException(ex);
            }
        }

        private async void getDriveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var defaultDrive = await Connection.GetDrive();

            FormSyncResults display = new FormSyncResults(Connection, defaultDrive);
            display.Show();

        }
    }

}
