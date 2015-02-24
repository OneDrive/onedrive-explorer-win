namespace NewApiBrowser
{
    partial class FormSyncResults
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
            this.oneDriveObjectBrowser1 = new NewApiBrowser.OneDriveObjectBrowser();
            this.buttonGetNext = new System.Windows.Forms.Button();
            this.labelRefreshing = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // oneDriveObjectBrowser1
            // 
            this.oneDriveObjectBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.oneDriveObjectBrowser1.DisplayFormat = NewApiBrowser.PropertyDisplayFormat.RawJson;
            this.oneDriveObjectBrowser1.Location = new System.Drawing.Point(11, 11);
            this.oneDriveObjectBrowser1.Margin = new System.Windows.Forms.Padding(2);
            this.oneDriveObjectBrowser1.Name = "oneDriveObjectBrowser1";
            this.oneDriveObjectBrowser1.SelectedItem = null;
            this.oneDriveObjectBrowser1.Size = new System.Drawing.Size(760, 475);
            this.oneDriveObjectBrowser1.TabIndex = 0;
            // 
            // buttonGetNext
            // 
            this.buttonGetNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonGetNext.Location = new System.Drawing.Point(12, 491);
            this.buttonGetNext.Name = "buttonGetNext";
            this.buttonGetNext.Size = new System.Drawing.Size(75, 23);
            this.buttonGetNext.TabIndex = 1;
            this.buttonGetNext.Text = "&Get Next";
            this.buttonGetNext.UseVisualStyleBackColor = true;
            this.buttonGetNext.Click += new System.EventHandler(this.buttonGetNext_Click);
            // 
            // labelRefreshing
            // 
            this.labelRefreshing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelRefreshing.AutoSize = true;
            this.labelRefreshing.Location = new System.Drawing.Point(93, 496);
            this.labelRefreshing.Name = "labelRefreshing";
            this.labelRefreshing.Size = new System.Drawing.Size(67, 13);
            this.labelRefreshing.TabIndex = 2;
            this.labelRefreshing.Text = "Refreshing...";
            // 
            // FormSyncResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 526);
            this.Controls.Add(this.labelRefreshing);
            this.Controls.Add(this.buttonGetNext);
            this.Controls.Add(this.oneDriveObjectBrowser1);
            this.Name = "FormSyncResults";
            this.Text = "Item Results";
            this.Load += new System.EventHandler(this.FormSyncResults_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OneDriveObjectBrowser oneDriveObjectBrowser1;
        private System.Windows.Forms.Button buttonGetNext;
        private System.Windows.Forms.Label labelRefreshing;
    }
}