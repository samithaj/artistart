namespace lastFmArtist
{
    partial class mainForm
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
            if (mainForm.downloadingNum != 0)
            {
                if (System.Windows.Forms.MessageBox.Show("Downloading is not completed, are you sure to quit?(May cause image file corruption!", "Quiting", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.OK) return;
            }
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.artistTabPage = new System.Windows.Forms.TabControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.downloadingNumLabel = new System.Windows.Forms.Label();
            this.artistWikiPanel = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.libraryBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.withWikiCheckBox = new System.Windows.Forms.CheckBox();
            this.modChangeGroupBox = new System.Windows.Forms.GroupBox();
            this.localRadioButton = new System.Windows.Forms.RadioButton();
            this.allImageradioButton = new System.Windows.Forms.RadioButton();
            this.pageHaveImagesNumber = new System.Windows.Forms.NumericUpDown();
            this.artistNameTXB = new System.Windows.Forms.TextBox();
            this.searchBTN = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.artistWikiPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.modChangeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pageHaveImagesNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.artistTabPage);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.artistWikiPanel);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.splitContainer1.Panel2MinSize = 0;
            this.splitContainer1.Size = new System.Drawing.Size(662, 373);
            this.splitContainer1.SplitterDistance = 499;
            this.splitContainer1.TabIndex = 0;
            // 
            // artistTabPage
            // 
            this.artistTabPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.artistTabPage.Location = new System.Drawing.Point(0, 0);
            this.artistTabPage.Name = "artistTabPage";
            this.artistTabPage.SelectedIndex = 0;
            this.artistTabPage.Size = new System.Drawing.Size(499, 373);
            this.artistTabPage.TabIndex = 0;
            this.artistTabPage.DoubleClick += new System.EventHandler(this.artistTabPage_DoubleClick);
            this.artistTabPage.SelectedIndexChanged += new System.EventHandler(this.artistTabPage_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.downloadingNumLabel);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 325);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(156, 45);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Download Status";
            // 
            // downloadingNumLabel
            // 
            this.downloadingNumLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.downloadingNumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downloadingNumLabel.Location = new System.Drawing.Point(3, 16);
            this.downloadingNumLabel.Name = "downloadingNumLabel";
            this.downloadingNumLabel.Size = new System.Drawing.Size(150, 26);
            this.downloadingNumLabel.TabIndex = 0;
            this.downloadingNumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // artistWikiPanel
            // 
            this.artistWikiPanel.Controls.Add(this.textBox1);
            this.artistWikiPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.artistWikiPanel.Location = new System.Drawing.Point(0, 233);
            this.artistWikiPanel.Name = "artistWikiPanel";
            this.artistWikiPanel.Padding = new System.Windows.Forms.Padding(5);
            this.artistWikiPanel.Size = new System.Drawing.Size(156, 137);
            this.artistWikiPanel.TabIndex = 1;
            this.artistWikiPanel.TabStop = false;
            this.artistWikiPanel.Text = "Artist Summary";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(5, 18);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(146, 114);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Double Clicks to Change Font";
            this.textBox1.DoubleClick += new System.EventHandler(this.textBox1_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.withWikiCheckBox);
            this.groupBox1.Controls.Add(this.modChangeGroupBox);
            this.groupBox1.Controls.Add(this.pageHaveImagesNumber);
            this.groupBox1.Controls.Add(this.artistNameTXB);
            this.groupBox1.Controls.Add(this.searchBTN);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(156, 233);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Go!";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.libraryBtn);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(3, 150);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(150, 80);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Library";
            // 
            // libraryBtn
            // 
            this.libraryBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.libraryBtn.Location = new System.Drawing.Point(7, 51);
            this.libraryBtn.Name = "libraryBtn";
            this.libraryBtn.Size = new System.Drawing.Size(137, 23);
            this.libraryBtn.TabIndex = 2;
            this.libraryBtn.Text = "Load Library Directory";
            this.libraryBtn.UseVisualStyleBackColor = true;
            this.libraryBtn.Click += new System.EventHandler(this.libraryBtn_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(7, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Display All Artists";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // withWikiCheckBox
            // 
            this.withWikiCheckBox.Location = new System.Drawing.Point(6, 51);
            this.withWikiCheckBox.Name = "withWikiCheckBox";
            this.withWikiCheckBox.Size = new System.Drawing.Size(69, 19);
            this.withWikiCheckBox.TabIndex = 2;
            this.withWikiCheckBox.Text = "Summary";
            this.withWikiCheckBox.UseVisualStyleBackColor = true;
            this.withWikiCheckBox.CheckedChanged += new System.EventHandler(this.withWikiCheckBox_CheckedChanged);
            // 
            // modChangeGroupBox
            // 
            this.modChangeGroupBox.Controls.Add(this.button2);
            this.modChangeGroupBox.Controls.Add(this.localRadioButton);
            this.modChangeGroupBox.Controls.Add(this.allImageradioButton);
            this.modChangeGroupBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.modChangeGroupBox.Location = new System.Drawing.Point(3, 79);
            this.modChangeGroupBox.Name = "modChangeGroupBox";
            this.modChangeGroupBox.Size = new System.Drawing.Size(150, 71);
            this.modChangeGroupBox.TabIndex = 5;
            this.modChangeGroupBox.TabStop = false;
            this.modChangeGroupBox.Text = "Display";
            // 
            // localRadioButton
            // 
            this.localRadioButton.AutoSize = true;
            this.localRadioButton.Location = new System.Drawing.Point(85, 19);
            this.localRadioButton.Name = "localRadioButton";
            this.localRadioButton.Size = new System.Drawing.Size(51, 17);
            this.localRadioButton.TabIndex = 1;
            this.localRadioButton.Text = "Local";
            this.localRadioButton.UseVisualStyleBackColor = true;
            this.localRadioButton.CheckedChanged += new System.EventHandler(this.localRadioButton_CheckedChanged);
            // 
            // allImageradioButton
            // 
            this.allImageradioButton.AutoSize = true;
            this.allImageradioButton.Checked = true;
            this.allImageradioButton.Location = new System.Drawing.Point(6, 19);
            this.allImageradioButton.Name = "allImageradioButton";
            this.allImageradioButton.Size = new System.Drawing.Size(73, 17);
            this.allImageradioButton.TabIndex = 0;
            this.allImageradioButton.TabStop = true;
            this.allImageradioButton.Text = "All Images";
            this.allImageradioButton.UseVisualStyleBackColor = true;
            // 
            // pageHaveImagesNumber
            // 
            this.pageHaveImagesNumber.Location = new System.Drawing.Point(115, 22);
            this.pageHaveImagesNumber.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.pageHaveImagesNumber.Name = "pageHaveImagesNumber";
            this.pageHaveImagesNumber.Size = new System.Drawing.Size(38, 20);
            this.pageHaveImagesNumber.TabIndex = 1;
            this.pageHaveImagesNumber.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // artistNameTXB
            // 
            this.artistNameTXB.Location = new System.Drawing.Point(6, 22);
            this.artistNameTXB.Name = "artistNameTXB";
            this.artistNameTXB.Size = new System.Drawing.Size(103, 20);
            this.artistNameTXB.TabIndex = 0;
            // 
            // searchBTN
            // 
            this.searchBTN.Location = new System.Drawing.Point(84, 48);
            this.searchBTN.Name = "searchBTN";
            this.searchBTN.Size = new System.Drawing.Size(69, 23);
            this.searchBTN.TabIndex = 3;
            this.searchBTN.Text = "Search";
            this.searchBTN.UseVisualStyleBackColor = true;
            this.searchBTN.Click += new System.EventHandler(this.searchBTN_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(69, 42);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Refresh";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 373);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(670, 400);
            this.Name = "mainForm";
            this.Text = "lasfFmArtist";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.artistWikiPanel.ResumeLayout(false);
            this.artistWikiPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.modChangeGroupBox.ResumeLayout(false);
            this.modChangeGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pageHaveImagesNumber)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox artistWikiPanel;
        private System.Windows.Forms.NumericUpDown pageHaveImagesNumber;
        private System.Windows.Forms.TextBox artistNameTXB;
        private System.Windows.Forms.Button searchBTN;
        private System.Windows.Forms.TabControl artistTabPage;
        private System.Windows.Forms.GroupBox modChangeGroupBox;
        private System.Windows.Forms.RadioButton localRadioButton;
        private System.Windows.Forms.RadioButton allImageradioButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox withWikiCheckBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label downloadingNumLabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button libraryBtn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button2;
    }
}

