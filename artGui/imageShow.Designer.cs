namespace WindowsFormsApplication1
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
            this.imageId = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imageContainer)).BeginInit();
            this.SuspendLayout();
            // 
            // imageContainer
            // 
            this.imageContainer.Location = new System.Drawing.Point(3, 3);
            this.imageContainer.Name = "imageContainer";
            this.imageContainer.Size = new System.Drawing.Size(144, 128);
            this.imageContainer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageContainer.TabIndex = 0;
            this.imageContainer.TabStop = false;
            // 
            // indicator
            // 
            this.indicator.AutoSize = true;
            this.indicator.Location = new System.Drawing.Point(92, 134);
            this.indicator.Name = "indicator";
            this.indicator.Size = new System.Drawing.Size(55, 13);
            this.indicator.TabIndex = 1;
            this.indicator.TabStop = true;
            this.indicator.Text = "linkLabel1";
            this.indicator.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.indicator_LinkClicked);
            // 
            // imageId
            // 
            this.imageId.AutoSize = true;
            this.imageId.Location = new System.Drawing.Point(4, 136);
            this.imageId.Name = "imageId";
            this.imageId.Size = new System.Drawing.Size(0, 13);
            this.imageId.TabIndex = 2;
            // 
            // imageShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.imageId);
            this.Controls.Add(this.indicator);
            this.Controls.Add(this.imageContainer);
            this.Name = "imageShow";
            ((System.ComponentModel.ISupportInitialize)(this.imageContainer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imageContainer;
        private System.Windows.Forms.LinkLabel indicator;
        private System.Windows.Forms.Label imageId;
    }
}
