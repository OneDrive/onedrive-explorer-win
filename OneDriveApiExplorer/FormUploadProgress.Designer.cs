namespace NewApiBrowser
{
    partial class FormUploadProgress
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
            this.labelFilename = new System.Windows.Forms.Label();
            this.progressBarPercentComplete = new System.Windows.Forms.ProgressBar();
            this.labelProgressString = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelFilename
            // 
            this.labelFilename.AutoSize = true;
            this.labelFilename.Location = new System.Drawing.Point(13, 13);
            this.labelFilename.Name = "labelFilename";
            this.labelFilename.Size = new System.Drawing.Size(121, 13);
            this.labelFilename.TabIndex = 0;
            this.labelFilename.Text = "Uploading \"foobar.txt\"...";
            // 
            // progressBarPercentComplete
            // 
            this.progressBarPercentComplete.Location = new System.Drawing.Point(16, 39);
            this.progressBarPercentComplete.Name = "progressBarPercentComplete";
            this.progressBarPercentComplete.Size = new System.Drawing.Size(404, 23);
            this.progressBarPercentComplete.TabIndex = 1;
            // 
            // labelProgressString
            // 
            this.labelProgressString.AutoSize = true;
            this.labelProgressString.Location = new System.Drawing.Point(13, 74);
            this.labelProgressString.Name = "labelProgressString";
            this.labelProgressString.Size = new System.Drawing.Size(128, 13);
            this.labelProgressString.TabIndex = 2;
            this.labelProgressString.Text = "{0} of {1} bytes transfered";
            // 
            // FormUploadProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 115);
            this.Controls.Add(this.labelProgressString);
            this.Controls.Add(this.progressBarPercentComplete);
            this.Controls.Add(this.labelFilename);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormUploadProgress";
            this.Text = "Upload Progress";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelFilename;
        private System.Windows.Forms.ProgressBar progressBarPercentComplete;
        private System.Windows.Forms.Label labelProgressString;
    }
}