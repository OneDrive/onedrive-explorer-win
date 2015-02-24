using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using OneDrive;

namespace NewApiBrowser
{
    public partial class FormAsyncJobViewer : Form
    {
        public BindingList<ODAsyncTask> PendingJobs { get; set; }
        public ODConnection Connection { get; set; }

        private bool _refreshing = false;

        public FormAsyncJobViewer()
        {
            InitializeComponent();

            PendingJobs = new BindingList<ODAsyncTask>();
            PendingJobs.ListChanged += PendingJobs_ListChanged;
        }

        void PopulateListView()
        {
            listViewPendingJobs.BeginUpdate();
            listViewPendingJobs.Items.Clear();
            foreach (var job in PendingJobs)
            {
                listViewPendingJobs.Items.Add(ListViewItemForTask(job));
            }
            listViewPendingJobs.EndUpdate();
        }

        void PendingJobs_ListChanged(object sender, ListChangedEventArgs e)
        {
            PopulateListView();
        }

        ListViewItem ListViewItemForTask(ODAsyncTask task)
        {
            var item = new ListViewItem();
            UpdateListViewItem(item, task, true);
            return item;
        }

        void UpdateListViewItem(ListViewItem item, ODAsyncTask task, bool forceUpdate = false)
        {
            if (!forceUpdate && !this.IsHandleCreated)
                return;

            var updateAction = new Action<ListViewItem, ODAsyncTask>((lvitem, lvtask) =>
                {
                    lvitem.SubItems.Clear();
                    lvitem.Text = lvtask.Status.Operation.ToString();
                    lvitem.SubItems.Add(lvtask.Status.PercentComplete.ToString());
                    lvitem.SubItems.Add(lvtask.Status.Status.ToString());
                    lvitem.SubItems.Add(lvtask.RequestUri.ToString());
                    lvitem.Tag = lvtask;
                });

            if (this.InvokeRequired)
            {
                Invoke(new MethodInvoker(() => updateAction(item, task)));
            }
            else
            {
                updateAction(item, task);
            }
        }
    


        internal async void RefreshStatus()
        {
            if (_refreshing) return;

            _refreshing = true;
            foreach (ListViewItem item in listViewPendingJobs.Items)
            {
                var task = item.Tag as ODAsyncTask;
                if (task.Status.Status != AsyncJobStatus.Complete)
                {
                    await task.Refresh(Connection).ContinueWith(new Action<Task>(t => UpdateListViewItem(item, task)));
                }
            }
            _refreshing = false;
        }

        private void FormAsyncJobViewer_Load(object sender, EventArgs e)
        {
            PopulateListView();
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            RefreshStatus();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FormAsyncJobViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
