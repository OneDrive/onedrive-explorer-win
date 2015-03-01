using System;
using System.Windows.Forms;
using OneDrive;

namespace NewApiBrowser
{
    public partial class FormSyncResults : Form
    {
        public ODConnection Connection { get; set; }
        public ODDataModel Results { get; set; }

        public FormSyncResults(ODConnection connection, ODDataModel result)
        {
            InitializeComponent();

            Connection = connection;
            Results = result;
        }

        private void FormSyncResults_Load(object sender, EventArgs e)
        {
            LoadResults(Results);
            labelRefreshing.Visible = false;
        }

        private void LoadResults(ODDataModel results)
        {
            Results = results;
            oneDriveObjectBrowser1.SelectedItem = results;

            var resultCollection = results as ODItemCollection;
            if (null != resultCollection)
            {
                buttonGetNext.Enabled = resultCollection.MoreItemsAvailable();
            }
            else
            {
                buttonGetNext.Visible = false;
            }
        }

        private async void buttonGetNext_Click(object sender, EventArgs e)
        {
            var resultCollection = Results as ODItemCollection;
            if (null != resultCollection)
            {
                labelRefreshing.Visible = true;
                var response = await resultCollection.GetNextPage(Connection);
                LoadResults(response);
                labelRefreshing.Visible = false;
            }
        }
    }
}
