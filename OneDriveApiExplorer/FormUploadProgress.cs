using System;
using System.Windows.Forms;

namespace NewApiBrowser
{
    public partial class FormUploadProgress : Form
    {
        public FormUploadProgress(string filename)
        {
            InitializeComponent();

            labelFilename.Text = string.Format("Uploading \"{0}\"...", filename);
            labelProgressString.Text = "Starting upload...";
            progressBarPercentComplete.Value = 0;
        }

        public void UpdateProgress(int percentComplete, long bytesUploaded, long totalBytes)
        {
            const double mbconst = 1024.0 * 1024.0;

            Action updateAction = new Action(() =>
                {
                    labelProgressString.Text = string.Format("{0:0.00} of {1:0.00} MB transfered", bytesUploaded / mbconst, totalBytes / mbconst);
                    progressBarPercentComplete.Value = percentComplete;
                });

            if (InvokeRequired)
                BeginInvoke(updateAction);
            else
                updateAction();
        }
    }
}
