using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;


namespace lastFmArtist
{
    public partial class artistPagesControl : UserControl
    {
        private string artistName;
        public int pageNum = 1;
        //how many in one page.
        public int imagesHaveCount;
        private BackgroundWorker pageFetchThread = new BackgroundWorker();
        //This is pages' collection,each CONTAINING ARRAY OF ONE PAGE'S IMAGES
        private ArrayList artistPagesArraylist;
        private int downloadingPage = -1;
        private RadioButton mode;
        public string artistPath = mainForm.savePath;

        /*Contructors         
         */
        public artistPagesControl()
        {
            InitializeComponent();
        }
        public artistPagesControl(string inArtist, int imagesHaveCountIn, RadioButton modeIn)
        {
            InitializeComponent();
            this.artistName = inArtist;
            this.imagesHaveCount = imagesHaveCountIn;
            this.mode = modeIn;

            this.artistPath = mainForm.savePath;
            this.artistImagePathtextBox.Text = this.artistPath;

            artistPagesArraylist = new ArrayList();
            drawPage(pageNum);
        }

        /*Private Methods
         */
        private void progressReport(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
        }

        private void fetchCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                MessageBox.Show("Canceled");
            }
            else if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else
            {
                artistPagesArraylist.Add(e.Result);
                if (this.downloadingPage == pageNum)
                {
                    drawPage(pageNum);
                    this.downloadingPage = -1;
                }
                this.pageStatus.Text = "Idle";
            }
        }

        private void fetchPageFromServer(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            System.Xml.XmlDocument Artlist = new System.Xml.XmlDocument();

            string xml = mainForm.downloadTextFromHttp("http://ws.audioscrobbler.com/2.0/?method=artist.getimages&artist=" + artistName + "&api_key=aa55f6dc630a531d0a093c1ca77df129&limit=" + imagesHaveCount + "&page=" + ((int)(e.Argument)).ToString());
            if (xml == null)
            {
                e.Cancel = true;
                e.Result = null;
                worker.Dispose();
                return;
            }

            try
            {
                Artlist.LoadXml(xml);
            }
            catch (Exception err)
            {
                //Cancel thread and throw a window;
                MessageBox.Show(err.Message);
                e.Cancel = true;
                worker.Dispose();
                return;
            }

            System.Xml.XmlNodeList nodeList = Artlist.GetElementsByTagName("image");
            imageShow[] imageListControl = new imageShow[nodeList.Count];

            for (int i = 0; i < nodeList.Count; i++)
            {
                imageListControl[i] = new imageShow(i,
                    nodeList.Item(i).SelectSingleNode("sizes").SelectSingleNode("size[@name=\"medium\"]").InnerText,
                    nodeList.Item(i).SelectSingleNode("sizes").SelectSingleNode("size[@name=\"original\"]").InnerText,
                    artistName, this.artistPath);
                worker.ReportProgress((int)((float)i / (float)nodeList.Count * 100));
            }

            e.Result = imageListControl;
            worker.ReportProgress(1);
        }

        private void getPage(int targetPage)
        {
            this.pageFetchThread = new BackgroundWorker();
            this.pageFetchThread.WorkerReportsProgress = true;
            this.pageFetchThread.WorkerSupportsCancellation = true;
            this.pageFetchThread.DoWork += new DoWorkEventHandler(fetchPageFromServer);
            this.pageFetchThread.RunWorkerCompleted += new RunWorkerCompletedEventHandler(fetchCompleted);
            this.pageFetchThread.ProgressChanged += new ProgressChangedEventHandler(progressReport);
            this.pageFetchThread.RunWorkerAsync(targetPage);
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            pageNum++;
            drawPage(pageNum);
        }

        private void preBtn_Click(object sender, EventArgs e)
        {
            if (--pageNum <= 0)
            {
                pageNum = 1;
            }
            drawPage(pageNum);

        }

        private void drawPage(int targetPage)
        {
            if (mode.Checked)
            {
                this.nextBtn.Enabled = false;
                this.preBtn.Enabled = false;
                this.downloadAllbtn.Enabled = false;
                //Close All
                this.flowLayoutPanel1.Controls.Clear();

                string[] fileNames = System.IO.Directory.GetFiles(this.artistPath, "*" + artistName + "*");



                for (int i = 0; i < fileNames.Length; i++)
                {
                    imageShow aShow = new imageShow(i, fileNames[i], fileNames[i], this.artistName, artistPath);

                    this.flowLayoutPanel1.Controls.Add(aShow);
                }


            }
            else
            {
                this.preBtn.Enabled = true;
                if (targetPage > this.artistPagesArraylist.Count)
                {
                    if (!this.pageFetchThread.IsBusy)
                    {
                        downloadingPage = targetPage;
                        getPage(targetPage);
                        this.pageNumberLabel.Text = targetPage.ToString();
                        this.flowLayoutPanel1.Controls.Clear();
                        this.nextBtn.Enabled = false;
                        this.downloadAllbtn.Enabled = false;
                    }
                    else
                    {
                        this.pageNumberLabel.Text = targetPage.ToString();
                        this.flowLayoutPanel1.Controls.Clear();
                        this.nextBtn.Enabled = false;
                        this.downloadAllbtn.Enabled = false;
                    }
                    this.pageStatus.Text = "Fetching Page" + targetPage.ToString();
                }
                else
                {
                    /*Discoved that I can use flowLayoutPanel.. What a loser I am...
                    int x = 0, y = 0;
                    this.SuspendLayout();
                     */
                    this.flowLayoutPanel1.Controls.Clear();

                    foreach (imageShow showBlock in (imageShow[])artistPagesArraylist[targetPage - 1])
                    {
                        //    if (x + 150 > this.Width)
                        //    {
                        //        y += 150;
                        //        x = 0;
                        //    }
                        //    showBlock.Location = new Point(x, y);
                        //    showBlock.Size = new Size(150, 150);
                        this.flowLayoutPanel1.Controls.Add(showBlock);
                        //    x += 150;
                    }

                    //this.ResumeLayout();


                    this.pageNumberLabel.Text = targetPage.ToString() + "/" + this.artistPagesArraylist.Count.ToString();
                    this.nextBtn.Enabled = true;
                    this.downloadAllbtn.Enabled = true;

                }
            }
        }

        private void downloadAllbtn_Click(object sender, EventArgs e)
        {
            if (artistPagesArraylist.Count != 0)
            {
                foreach (imageShow showBlock in (imageShow[])artistPagesArraylist[pageNum - 1])
                {
                    if (!showBlock.isDownloading && !showBlock.isDownloaded)
                    {
                        showBlock.indicator_LinkClicked(null, null);
                    }
                }
            }
        }

        private void flowLayoutPanel1_Click(object sender, EventArgs e)
        {
            this.flowLayoutPanel1.Focus();
        }

        private void artistImagePathtextBox_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            dialog.SelectedPath = this.artistPath;
            dialog.ShowDialog();

            if (dialog.SelectedPath != this.artistPath)
            {
                this.artistImagePathtextBox.Text = dialog.SelectedPath;
                this.artistPath = dialog.SelectedPath;
                this.pageNum = 1;
                this.pageNumberLabel.Text = "1";
                this.redrawPage();


            }
        }



        /*Public Methods
         */
        public void redrawPage()
        {
            this.artistPagesArraylist.Clear();
            drawPage(pageNum);
        }

        public void redrawPage(int imageOnePageHas)
        {
            this.imagesHaveCount = imageOnePageHas;
            this.artistPagesArraylist.Clear();
            this.pageNum = 1;

            drawPage(pageNum);
        }

        //public void softRedrawPage(int imageOnePageHas)
        //{
        //    this.imagesHaveCount = imageOnePageHas;

        //    drawPage(pageNum);
        //}

        private void artistPagesControl_Load(object sender, EventArgs e)
        {
            ToolTip aNewToolTip = new ToolTip();
            aNewToolTip.SetToolTip(this.artistImagePathtextBox, "Specify artist path, ignoring Library Setting");
            aNewToolTip.SetToolTip(this.panel2, "Specify artist path, ignoring Library Setting");
            aNewToolTip.SetToolTip(this.flowLayoutPanel1, "Left click downloaded image to open, right to browse in its folder");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.Parent.Parent.Parent.Parent.Parent is mainForm)
                ((SplitContainer)(this.Parent.Parent.Parent.Parent.Parent.Controls["splitContainer1"])).Panel2Collapsed = ((SplitContainer)(this.Parent.Parent.Parent.Parent.Parent.Controls["splitContainer1"])).Panel2Collapsed ? false : true;
        }




    }
}
