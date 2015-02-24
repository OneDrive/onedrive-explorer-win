namespace NewApiBrowser
{
    partial class FormAsyncJobViewer
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
            this.components = new System.ComponentModel.Container();
            this.listViewPendingJobs = new System.Windows.Forms.ListView();
            this.columnOperation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnPercentComplete = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSourceUrl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonClose = new System.Windows.Forms.Button();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // listViewPendingJobs
            // 
            this.listViewPendingJobs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewPendingJobs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnOperation,
            this.columnPercentComplete,
            this.columnStatus,
            this.columnSourceUrl});
            this.listViewPendingJobs.Location = new System.Drawing.Point(12, 12);
            this.listViewPendingJobs.Name = "listViewPendingJobs";
            this.listViewPendingJobs.Size = new System.Drawing.Size(620, 263);
            this.listViewPendingJobs.TabIndex = 0;
            this.listViewPendingJobs.UseCompatibleStateImageBehavior = false;
            this.listViewPendingJobs.View = System.Windows.Forms.View.Details;
            // 
            // columnOperation
            // 
            this.columnOperation.Text = "Operation";
            this.columnOperation.Width = 136;
            // 
            // columnPercentComplete
            // 
            this.columnPercentComplete.Text = "% Complete";
            this.columnPercentComplete.Width = 146;
            // 
            // columnStatus
            // 
            this.columnStatus.Text = "Status";
            this.columnStatus.Width = 97;
            // 
            // columnSourceUrl
            // 
            this.columnSourceUrl.Text = "Source URL";
            this.columnSourceUrl.Width = 231;
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.Location = new System.Drawing.Point(557, 282);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "&Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // timerRefresh
            // 
            this.timerRefresh.Enabled = true;
            this.timerRefresh.Interval = 5000;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // FormAsyncJobViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 317);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.listViewPendingJobs);
            this.MaximizeBox = false;
            this.Name = "FormAsyncJobViewer";
            this.Text = "Pending Async Actions";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAsyncJobViewer_FormClosing);
            this.Load += new System.EventHandler(this.FormAsyncJobViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewPendingJobs;
        private System.Windows.Forms.ColumnHeader columnOperation;
        private System.Windows.Forms.ColumnHeader columnPercentComplete;
        private System.Windows.Forms.ColumnHeader columnStatus;
        private System.Windows.Forms.ColumnHeader columnSourceUrl;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Timer timerRefresh;
    }
}