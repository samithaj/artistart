namespace lastFmArtist
{
    partial class artistPagesControl
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.artistImagePathtextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.downloadAllbtn = new System.Windows.Forms.Button();
            this.pageStatus = new System.Windows.Forms.Label();
            this.nextBtn = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.preBtn = new System.Windows.Forms.Button();
            this.pageNumberLabel = new System.Windows.Forms.Label();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(749, 467);
            this.splitContainer1.SplitterDistance = 429;
            this.splitContainer1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(749, 429);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.Click += new System.EventHandler(this.flowLayoutPanel1_Click);
            this.flowLayoutPanel1.MouseEnter += new System.EventHandler(this.flowLayoutPanel1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.artistImagePathtextBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5, 10, 5, 0);
            this.panel2.Size = new System.Drawing.Size(385, 34);
            this.panel2.TabIndex = 8;
            // 
            // artistImagePathtextBox
            // 
            this.artistImagePathtextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.artistImagePathtextBox.Location = new System.Drawing.Point(5, 10);
            this.artistImagePathtextBox.Name = "artistImagePathtextBox";
            this.artistImagePathtextBox.ReadOnly = true;
            this.artistImagePathtextBox.Size = new System.Drawing.Size(375, 21);
            this.artistImagePathtextBox.TabIndex = 7;
            this.artistImagePathtextBox.Text = "Specify Path..! Will Not Save To Library!";
            this.artistImagePathtextBox.Click += new System.EventHandler(this.artistImagePathtextBox_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.downloadAllbtn);
            this.panel1.Controls.Add(this.pageStatus);
            this.panel1.Controls.Add(this.nextBtn);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.preBtn);
            this.panel1.Controls.Add(this.pageNumberLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(385, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(364, 34);
            this.panel1.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(346, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(15, 21);
            this.button1.TabIndex = 6;
            this.button1.Text = ">";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // downloadAllbtn
            // 
            this.downloadAllbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadAllbtn.Location = new System.Drawing.Point(128, 11);
            this.downloadAllbtn.Name = "downloadAllbtn";
            this.downloadAllbtn.Size = new System.Drawing.Size(90, 21);
            this.downloadAllbtn.TabIndex = 3;
            this.downloadAllbtn.Text = "Download All";
            this.downloadAllbtn.UseVisualStyleBackColor = true;
            this.downloadAllbtn.Click += new System.EventHandler(this.downloadAllbtn_Click);
            // 
            // pageStatus
            // 
            this.pageStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pageStatus.Location = new System.Drawing.Point(13, 9);
            this.pageStatus.Name = "pageStatus";
            this.pageStatus.Size = new System.Drawing.Size(109, 12);
            this.pageStatus.TabIndex = 5;
            this.pageStatus.Text = "Idle";
            this.pageStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nextBtn
            // 
            this.nextBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nextBtn.Location = new System.Drawing.Point(300, 11);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(40, 21);
            this.nextBtn.TabIndex = 0;
            this.nextBtn.Text = "Next";
            this.nextBtn.UseVisualStyleBackColor = true;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(13, 23);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(109, 10);
            this.progressBar1.TabIndex = 4;
            // 
            // preBtn
            // 
            this.preBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.preBtn.Location = new System.Drawing.Point(224, 11);
            this.preBtn.Name = "preBtn";
            this.preBtn.Size = new System.Drawing.Size(40, 21);
            this.preBtn.TabIndex = 1;
            this.preBtn.Text = "Pre";
            this.preBtn.UseVisualStyleBackColor = true;
            this.preBtn.Click += new System.EventHandler(this.preBtn_Click);
            // 
            // pageNumberLabel
            // 
            this.pageNumberLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pageNumberLabel.Location = new System.Drawing.Point(270, 11);
            this.pageNumberLabel.Name = "pageNumberLabel";
            this.pageNumberLabel.Size = new System.Drawing.Size(24, 21);
            this.pageNumberLabel.TabIndex = 2;
            this.pageNumberLabel.Text = "1";
            this.pageNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // artistPagesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(150, 185);
            this.Name = "artistPagesControl";
            this.Size = new System.Drawing.Size(749, 467);
            this.Load += new System.EventHandler(this.artistPagesControl_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button preBtn;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.Label pageNumberLabel;
        private System.Windows.Forms.Button downloadAllbtn;
        private System.Windows.Forms.Label pageStatus;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox artistImagePathtextBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button1;
    }
}
