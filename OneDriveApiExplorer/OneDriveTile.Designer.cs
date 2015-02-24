namespace NewApiBrowser
{
    partial class OneDriveTile
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelName = new System.Windows.Forms.Label();
            this.pictureBoxThumbnail = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxThumbnail)).BeginInit();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoEllipsis = true;
            this.labelName.BackColor = System.Drawing.Color.Transparent;
            this.labelName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.ForeColor = System.Drawing.Color.White;
            this.labelName.Location = new System.Drawing.Point(0, 91);
            this.labelName.Margin = new System.Windows.Forms.Padding(0);
            this.labelName.Name = "labelName";
            this.labelName.Padding = new System.Windows.Forms.Padding(0, 0, 7, 6);
            this.labelName.Size = new System.Drawing.Size(179, 27);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Documents (Microsoft)";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.labelName.Click += new System.EventHandler(this.Control_Click);
            this.labelName.DoubleClick += new System.EventHandler(this.Control_DoubleClick);
            // 
            // pictureBoxThumbnail
            // 
            this.pictureBoxThumbnail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxThumbnail.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxThumbnail.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBoxThumbnail.Name = "pictureBoxThumbnail";
            this.pictureBoxThumbnail.Padding = new System.Windows.Forms.Padding(2);
            this.pictureBoxThumbnail.Size = new System.Drawing.Size(179, 91);
            this.pictureBoxThumbnail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxThumbnail.TabIndex = 1;
            this.pictureBoxThumbnail.TabStop = false;
            this.pictureBoxThumbnail.Click += new System.EventHandler(this.Control_Click);
            this.pictureBoxThumbnail.DoubleClick += new System.EventHandler(this.Control_DoubleClick);
            // 
            // OneDriveTile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumBlue;
            this.Controls.Add(this.pictureBoxThumbnail);
            this.Controls.Add(this.labelName);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "OneDriveTile";
            this.Size = new System.Drawing.Size(179, 118);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxThumbnail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.PictureBox pictureBoxThumbnail;
    }
}
