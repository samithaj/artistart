namespace lastFmArtist
{
    partial class imageShow
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
            this.imageContainer = new System.Windows.Forms.PictureBox();
            this.indicator = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.imageContainer)).BeginInit();
            this.SuspendLayout();
            // 
            // imageContainer
            // 
            this.imageContainer.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.imageContainer.Location = new System.Drawing.Point(3, 3);
            this.imageContainer.MaximumSize = new System.Drawing.Size(144, 128);
            this.imageContainer.MinimumSize = new System.Drawing.Size(144, 128);
            this.imageContainer.Name = "imageContainer";
            this.imageContainer.Size = new System.Drawing.Size(144, 128);
            this.imageContainer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageContainer.TabIndex = 0;
            this.imageContainer.TabStop = false;
            // 
            // indicator
            // 
            this.indicator.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.indicator.Location = new System.Drawing.Point(78, 134);
            this.indicator.Name = "indicator";
            this.indicator.Size = new System.Drawing.Size(69, 16);
            this.indicator.TabIndex = 1;
            this.indicator.TabStop = true;
            this.indicator.Text = "Download";
            this.indicator.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.indicator.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.indicator_LinkClicked);
            // 
            // imageShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.indicator);
            this.Controls.Add(this.imageContainer);
            this.Name = "imageShow";
            ((System.ComponentModel.ISupportInitialize)(this.imageContainer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imageContainer;
        private System.Windows.Forms.LinkLabel indicator;
    }
}
