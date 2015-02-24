using System;
using System.Windows.Forms;
using OneDrive;

namespace NewApiBrowser
{
    public partial class FormSyncResults : Form
    {
        public ODConnection Connection { get; set; }
        public ODItemCollection Results { get; set; }

        public FormSyncResults(ODConnection connection, ODItemCollection result)
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

        private void LoadResults(ODItemCollection results)
        {
            Results = results;
            oneDriveObjectBrowser1.SelectedItem = results;

            buttonGetNext.Enabled = results.MoreItemsAvailable();
        }

        private async void buttonGetNext_Click(object sender, EventArgs e)
        {
            if (null != Results)
            {
                labelRefreshing.Visible = true;
                var response = await Results.GetNextPage(Connection);
                LoadResults(response);
                labelRefreshing.Visible = false;
            }
        }
    }
}
