namespace NewApiBrowser
{
    partial class FormBrowser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutContents = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelBreadcrumb = new System.Windows.Forms.FlowLayoutPanel();
            this.linkLabelOneDriveRoot = new System.Windows.Forms.LinkLabel();
            this.oneDriveObjectBrowser1 = new NewApiBrowser.OneDriveObjectBrowser();
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.createFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSelectedFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.renameSelectedItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSelectedItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFileInCurrentFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceSelectedItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.fromURLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.largeFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pickerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFromOneDriveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadToOneDriveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.advancedScenariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getChangesHereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getDriveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanelBreadcrumb.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutContents);
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanelBreadcrumb);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.oneDriveObjectBrowser1);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.splitContainer1.Size = new System.Drawing.Size(800, 542);
            this.splitContainer1.SplitterDistance = 537;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 5;
            // 
            // flowLayoutContents
            // 
            this.flowLayoutContents.AutoScroll = true;
            this.flowLayoutContents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutContents.Location = new System.Drawing.Point(3, 42);
            this.flowLayoutContents.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutContents.Name = "flowLayoutContents";
            this.flowLayoutContents.Size = new System.Drawing.Size(534, 497);
            this.flowLayoutContents.TabIndex = 1;
            // 
            // flowLayoutPanelBreadcrumb
            // 
            this.flowLayoutPanelBreadcrumb.Controls.Add(this.linkLabelOneDriveRoot);
            this.flowLayoutPanelBreadcrumb.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanelBreadcrumb.Location = new System.Drawing.Point(3, 0);
            this.flowLayoutPanelBreadcrumb.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanelBreadcrumb.Name = "flowLayoutPanelBreadcrumb";
            this.flowLayoutPanelBreadcrumb.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.flowLayoutPanelBreadcrumb.Size = new System.Drawing.Size(534, 42);
            this.flowLayoutPanelBreadcrumb.TabIndex = 2;
            this.flowLayoutPanelBreadcrumb.Visible = false;
            // 
            // linkLabelOneDriveRoot
            // 
            this.linkLabelOneDriveRoot.AutoSize = true;
            this.linkLabelOneDriveRoot.Location = new System.Drawing.Point(2, 2);
            this.linkLabelOneDriveRoot.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabelOneDriveRoot.Name = "linkLabelOneDriveRoot";
            this.linkLabelOneDriveRoot.Size = new System.Drawing.Size(52, 13);
            this.linkLabelOneDriveRoot.TabIndex = 0;
            this.linkLabelOneDriveRoot.TabStop = true;
            this.linkLabelOneDriveRoot.Text = "OneDrive";
            this.linkLabelOneDriveRoot.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelBreadcrumb_LinkClicked);
            // 
            // oneDriveObjectBrowser1
            // 
            this.oneDriveObjectBrowser1.DisplayFormat = NewApiBrowser.PropertyDisplayFormat.RawJson;
            this.oneDriveObjectBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.oneDriveObjectBrowser1.Location = new System.Drawing.Point(0, 0);
            this.oneDriveObjectBrowser1.Margin = new System.Windows.Forms.Padding(2);
            this.oneDriveObjectBrowser1.Name = "oneDriveObjectBrowser1";
            this.oneDriveObjectBrowser1.SelectedItem = null;
            this.oneDriveObjectBrowser1.Size = new System.Drawing.Size(257, 464);
            this.oneDriveObjectBrowser1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 464);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(257, 75);
            this.panel1.TabIndex = 1;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(705, 6);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(92, 15);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 4;
            this.progressBar1.Value = 100;
            this.progressBar1.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.uploadFileToolStripMenuItem,
            this.pickerToolStripMenuItem,
            this.advancedScenariosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 6);
            this.menuStrip1.Size = new System.Drawing.Size(800, 27);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.signInToolStripMenuItem,
            this.signOutToolStripMenuItem,
            this.toolStripMenuItem3,
            this.createFolderToolStripMenuItem,
            this.saveSelectedFileToolStripMenuItem,
            this.toolStripMenuItem4,
            this.renameSelectedItemToolStripMenuItem,
            this.deleteSelectedItemToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 19);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // signInToolStripMenuItem
            // 
            this.signInToolStripMenuItem.Name = "signInToolStripMenuItem";
            this.signInToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.signInToolStripMenuItem.Text = "Sign In to OneDrive...";
            this.signInToolStripMenuItem.Click += new System.EventHandler(this.signInToolStripMenuItem_Click);
            // 
            // signOutToolStripMenuItem
            // 
            this.signOutToolStripMenuItem.Name = "signOutToolStripMenuItem";
            this.signOutToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.signOutToolStripMenuItem.Text = "Sign Out";
            this.signOutToolStripMenuItem.Visible = false;
            this.signOutToolStripMenuItem.Click += new System.EventHandler(this.signOutToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(211, 6);
            // 
            // createFolderToolStripMenuItem
            // 
            this.createFolderToolStripMenuItem.Name = "createFolderToolStripMenuItem";
            this.createFolderToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.createFolderToolStripMenuItem.Text = "Create Folder...";
            this.createFolderToolStripMenuItem.Click += new System.EventHandler(this.createFolderToolStripMenuItem_Click);
            // 
            // saveSelectedFileToolStripMenuItem
            // 
            this.saveSelectedFileToolStripMenuItem.Name = "saveSelectedFileToolStripMenuItem";
            this.saveSelectedFileToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.saveSelectedFileToolStripMenuItem.Text = "Download Selected File...";
            this.saveSelectedFileToolStripMenuItem.Click += new System.EventHandler(this.saveSelectedFileToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(211, 6);
            // 
            // renameSelectedItemToolStripMenuItem
            // 
            this.renameSelectedItemToolStripMenuItem.Name = "renameSelectedItemToolStripMenuItem";
            this.renameSelectedItemToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.renameSelectedItemToolStripMenuItem.Text = "Rename Selected Item...";
            this.renameSelectedItemToolStripMenuItem.Click += new System.EventHandler(this.renameSelectedItemToolStripMenuItem_Click);
            // 
            // deleteSelectedItemToolStripMenuItem
            // 
            this.deleteSelectedItemToolStripMenuItem.Name = "deleteSelectedItemToolStripMenuItem";
            this.deleteSelectedItemToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteSelectedItemToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.deleteSelectedItemToolStripMenuItem.Text = "Delete Selected Item...";
            this.deleteSelectedItemToolStripMenuItem.Click += new System.EventHandler(this.deleteSelectedItemToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(211, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // uploadFileToolStripMenuItem
            // 
            this.uploadFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFileInCurrentFolderToolStripMenuItem,
            this.replaceSelectedItemToolStripMenuItem,
            this.toPathToolStripMenuItem,
            this.toolStripMenuItem2,
            this.fromURLToolStripMenuItem,
            this.largeFileToolStripMenuItem});
            this.uploadFileToolStripMenuItem.Name = "uploadFileToolStripMenuItem";
            this.uploadFileToolStripMenuItem.Size = new System.Drawing.Size(57, 19);
            this.uploadFileToolStripMenuItem.Text = "Upload";
            // 
            // newFileInCurrentFolderToolStripMenuItem
            // 
            this.newFileInCurrentFolderToolStripMenuItem.Name = "newFileInCurrentFolderToolStripMenuItem";
            this.newFileInCurrentFolderToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.newFileInCurrentFolderToolStripMenuItem.Text = "New File In Current Folder...";
            this.newFileInCurrentFolderToolStripMenuItem.Click += new System.EventHandler(this.newFileInCurrentFolderToolStripMenuItem_Click);
            // 
            // replaceSelectedItemToolStripMenuItem
            // 
            this.replaceSelectedItemToolStripMenuItem.Name = "replaceSelectedItemToolStripMenuItem";
            this.replaceSelectedItemToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.replaceSelectedItemToolStripMenuItem.Text = "Replace Selected Item...";
            this.replaceSelectedItemToolStripMenuItem.Click += new System.EventHandler(this.replaceSelectedItemToolStripMenuItem_Click);
            // 
            // toPathToolStripMenuItem
            // 
            this.toPathToolStripMenuItem.Name = "toPathToolStripMenuItem";
            this.toPathToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.toPathToolStripMenuItem.Text = "To Path...";
            this.toPathToolStripMenuItem.Click += new System.EventHandler(this.toPathToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(217, 6);
            // 
            // fromURLToolStripMenuItem
            // 
            this.fromURLToolStripMenuItem.Name = "fromURLToolStripMenuItem";
            this.fromURLToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.fromURLToolStripMenuItem.Text = "From URL...";
            this.fromURLToolStripMenuItem.Click += new System.EventHandler(this.fromURLToolStripMenuItem_Click);
            // 
            // largeFileToolStripMenuItem
            // 
            this.largeFileToolStripMenuItem.Name = "largeFileToolStripMenuItem";
            this.largeFileToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.largeFileToolStripMenuItem.Text = "Large File...";
            this.largeFileToolStripMenuItem.Click += new System.EventHandler(this.largeFileToolStripMenuItem_Click);
            // 
            // pickerToolStripMenuItem
            // 
            this.pickerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFromOneDriveToolStripMenuItem,
            this.uploadToOneDriveToolStripMenuItem});
            this.pickerToolStripMenuItem.Name = "pickerToolStripMenuItem";
            this.pickerToolStripMenuItem.Size = new System.Drawing.Size(51, 19);
            this.pickerToolStripMenuItem.Text = "Picker";
            // 
            // openFromOneDriveToolStripMenuItem
            // 
            this.openFromOneDriveToolStripMenuItem.Name = "openFromOneDriveToolStripMenuItem";
            this.openFromOneDriveToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.openFromOneDriveToolStripMenuItem.Text = "Open from OneDrive...";
            this.openFromOneDriveToolStripMenuItem.Click += new System.EventHandler(this.openFromOneDriveToolStripMenuItem_Click);
            // 
            // uploadToOneDriveToolStripMenuItem
            // 
            this.uploadToOneDriveToolStripMenuItem.Name = "uploadToOneDriveToolStripMenuItem";
            this.uploadToOneDriveToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.uploadToOneDriveToolStripMenuItem.Text = "Upload to OneDrive...";
            // 
            // advancedScenariosToolStripMenuItem
            // 
            this.advancedScenariosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getChangesHereToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.getDriveToolStripMenuItem});
            this.advancedScenariosToolStripMenuItem.Name = "advancedScenariosToolStripMenuItem";
            this.advancedScenariosToolStripMenuItem.Size = new System.Drawing.Size(125, 19);
            this.advancedScenariosToolStripMenuItem.Text = "Advanced Scenarios";
            // 
            // getChangesHereToolStripMenuItem
            // 
            this.getChangesHereToolStripMenuItem.Name = "getChangesHereToolStripMenuItem";
            this.getChangesHereToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.getChangesHereToolStripMenuItem.Text = "Get Changes...";
            this.getChangesHereToolStripMenuItem.Click += new System.EventHandler(this.getChangesHereToolStripMenuItem_Click);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.searchToolStripMenuItem.Text = "Search...";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.searchToolStripMenuItem_Click);
            // 
            // getDriveToolStripMenuItem
            // 
            this.getDriveToolStripMenuItem.Name = "getDriveToolStripMenuItem";
            this.getDriveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.getDriveToolStripMenuItem.Text = "Get Drive...";
            this.getDriveToolStripMenuItem.Click += new System.EventHandler(this.getDriveToolStripMenuItem_Click);
            // 
            // FormBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 569);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormBrowser";
            this.Text = "OneDrive API Browser";
            this.Load += new System.EventHandler(this.FormBrowser_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanelBreadcrumb.ResumeLayout(false);
            this.flowLayoutPanelBreadcrumb.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelBreadcrumb;
        private System.Windows.Forms.LinkLabel linkLabelOneDriveRoot;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uploadFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectedItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pickerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFromOneDriveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uploadToOneDriveToolStripMenuItem;
        private OneDriveObjectBrowser oneDriveObjectBrowser1;
        private System.Windows.Forms.ToolStripMenuItem createFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSelectedFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem advancedScenariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getChangesHereToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem fromURLToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutContents;
        private System.Windows.Forms.ToolStripMenuItem newFileInCurrentFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replaceSelectedItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toPathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem largeFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameSelectedItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getDriveToolStripMenuItem;
    }
}

