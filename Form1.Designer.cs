namespace artistArtGui
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.artistName = new System.Windows.Forms.TextBox();
            this.number = new System.Windows.Forms.NumericUpDown();
            this.path = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.nextPagebutton = new System.Windows.Forms.Button();
            this.artistLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.prePagebutton = new System.Windows.Forms.Button();
            this.downThemAllbutton = new System.Windows.Forms.Button();
            this.pageNumber = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.number)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(391, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Get List";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // artistName
            // 
            this.artistName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.artistName.Location = new System.Drawing.Point(232, 10);
            this.artistName.Name = "artistName";
            this.artistName.Size = new System.Drawing.Size(100, 20);
            this.artistName.TabIndex = 0;
            // 
            // number
            // 
            this.number.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.number.Location = new System.Drawing.Point(338, 10);
            this.number.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.number.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.number.Name = "number";
            this.number.Size = new System.Drawing.Size(47, 20);
            this.number.TabIndex = 1;
            this.number.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // path
            // 
            this.path.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.path.Location = new System.Drawing.Point(12, 63);
            this.path.Name = "path";
            this.path.ReadOnly = true;
            this.path.Size = new System.Drawing.Size(454, 20);
            this.path.TabIndex = 3;
            this.path.Text = "Click me to Browse ";
            this.path.TextChanged += new System.EventHandler(this.path_TextChanged);
            this.path.Click += new System.EventHandler(this.path_Click);
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
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pageNumber);
            this.splitContainer1.Panel2.Controls.Add(this.artistLabel);
            this.splitContainer1.Panel2.Controls.Add(this.nextPagebutton);
            this.splitContainer1.Panel2.Controls.Add(this.number);
            this.splitContainer1.Panel2.Controls.Add(this.downThemAllbutton);
            this.splitContainer1.Panel2.Controls.Add(this.artistName);
            this.splitContainer1.Panel2.Controls.Add(this.prePagebutton);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Controls.Add(this.statusLabel);
            this.splitContainer1.Panel2.Controls.Add(this.progressBar1);
            this.splitContainer1.Panel2.Controls.Add(this.path);
            this.splitContainer1.Panel2MinSize = 60;
            this.splitContainer1.Size = new System.Drawing.Size(469, 644);
            this.splitContainer1.SplitterDistance = 554;
            this.splitContainer1.TabIndex = 0;
            // 
            // nextPagebutton
            // 
            this.nextPagebutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nextPagebutton.Location = new System.Drawing.Point(419, 34);
            this.nextPagebutton.Name = "nextPagebutton";
            this.nextPagebutton.Size = new System.Drawing.Size(47, 23);
            this.nextPagebutton.TabIndex = 7;
            this.nextPagebutton.Text = "Next";
            this.nextPagebutton.UseVisualStyleBackColor = true;
            this.nextPagebutton.Click += new System.EventHandler(this.nextPagebutton_Click);
            // 
            // artistLabel
            // 
            this.artistLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.artistLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.artistLabel.Location = new System.Drawing.Point(12, 7);
            this.artistLabel.Name = "artistLabel";
            this.artistLabel.Size = new System.Drawing.Size(198, 21);
            this.artistLabel.TabIndex = 6;
            this.artistLabel.Text = "Aritst";
            this.artistLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.statusLabel.Location = new System.Drawing.Point(12, 27);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(198, 17);
            this.statusLabel.TabIndex = 5;
            this.statusLabel.Text = "Idle";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 47);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(198, 10);
            this.progressBar1.TabIndex = 4;
            // 
            // prePagebutton
            // 
            this.prePagebutton.Location = new System.Drawing.Point(324, 34);
            this.prePagebutton.Name = "prePagebutton";
            this.prePagebutton.Size = new System.Drawing.Size(48, 23);
            this.prePagebutton.TabIndex = 9;
            this.prePagebutton.Text = "Pre";
            this.prePagebutton.UseVisualStyleBackColor = true;
            this.prePagebutton.Click += new System.EventHandler(this.prePagebutton_Click);
            // 
            // downThemAllbutton
            // 
            this.downThemAllbutton.Location = new System.Drawing.Point(231, 34);
            this.downThemAllbutton.Name = "downThemAllbutton";
            this.downThemAllbutton.Size = new System.Drawing.Size(87, 23);
            this.downThemAllbutton.TabIndex = 10;
            this.downThemAllbutton.Text = "Download All";
            this.downThemAllbutton.UseVisualStyleBackColor = true;
            this.downThemAllbutton.Click += new System.EventHandler(this.downThemAllbutton_Click);
            // 
            // pageNumber
            // 
            this.pageNumber.Location = new System.Drawing.Point(378, 34);
            this.pageNumber.Name = "pageNumber";
            this.pageNumber.Size = new System.Drawing.Size(35, 23);
            this.pageNumber.TabIndex = 11;
            this.pageNumber.Text = "1";
            this.pageNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 644);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "artistArtDownload(GUI)";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.number)).EndInit();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox artistName;
        private System.Windows.Forms.NumericUpDown number;
        private System.Windows.Forms.TextBox path;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label artistLabel;
        private System.Windows.Forms.Button nextPagebutton;
        private System.Windows.Forms.Button downThemAllbutton;
        private System.Windows.Forms.Button prePagebutton;
        private System.Windows.Forms.Label pageNumber;
    }
}

