using System.Threading;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Xml;

namespace artistArtGui
{
    public partial class Form1 : Form
    {
        //Contructors
        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
        }
        public Form1(string artistIn, string pathIn, string numberIn)
        {
            InitializeComponent();

            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;

            artistName.Text = artistIn;
            pathIn += "\\";

            //<path> parameter is changed here to use STANDARD DIRECTORY PATH
            //pathIn = pathIn.Remove(pathIn.LastIndexOf(@"\") + 1);

            //Judge path or create path
            #region
            if (System.IO.Directory.Exists(pathIn))
            {
                path.Text = pathIn;
            }
            else
            {
                try
                {
                    path.Text = pathIn;
                    System.IO.Directory.CreateDirectory(path.Text);

                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
            #endregion

            if (int.Parse(numberIn) > 50)
            {
                MessageBox.Show("50 limit reached.!");
                this.number.Value = 5;
            }
            else
            {
                number.Value = int.Parse(numberIn);
            }

            //Perform simulating click action
            button1_Click(null, null);

        }

        //Properties
        private int page = 1;
        public XmlDocument Artlist;
        private int maxPage = 1;//The max page you have fetched from server.
        public ArrayList imageListCollection;//One page's imageShow controls.
        private BackgroundWorker backgroundWorker1 = new BackgroundWorker();//multithreading
        private bool isDownloading;//Is a page fetching?

        //! Cache resoult!
        private ArrayList artistOutputArray = new ArrayList();//Fetched Pages.


        //Methods
        private void button1_Click(object sender, EventArgs e)
        {
            nextPagebutton.Enabled = false;
            button1.Enabled = false;

            this.artistLabel.Text = this.artistName.Text;
            this.splitContainer1.Panel1.Controls.Clear();
            statusLabel.Text = "Fetching Artistart list...";
            backgroundWorker1 = new BackgroundWorker();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
            backgroundWorker1.RunWorkerAsync();
        }

        //Progress Report
        void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        //Fetch page in another thread.
        void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            int x = 0, y = 0;
            Artlist = new XmlDocument();
            try
            {
                string xml = downloadFromHttp.downloadTextFromHttp("http://ws.audioscrobbler.com/2.0/?method=artist.getimages&artist=" + artistName.Text + "&api_key=aa55f6dc630a531d0a093c1ca77df129&limit=" + number.Value.ToString() + "&page=" + page.ToString());
                if (xml == null)
                {
                    e.Cancel = true;
                    e.Result = null;
                    worker.Dispose();
                    return;
                }

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
            XmlNodeList nodeList = Artlist.GetElementsByTagName("image");

            imageShow[] imageListControl = new imageShow[nodeList.Count];

            for (int i = 0; i < nodeList.Count; i++)
            {
                imageListControl[i] = new imageShow(i,
                    nodeList.Item(i).SelectSingleNode("sizes").SelectSingleNode("size[@name=\"medium\"]").InnerText,
                    nodeList.Item(i).SelectSingleNode("sizes").SelectSingleNode("size[@name=\"original\"]").InnerText,
                    artistName.Text);
                worker.ReportProgress((int)((float)i / (float)nodeList.Count * 100));
                if (x + 150 > this.splitContainer1.Panel1.Width)
                {
                    y += 150;
                    x = 0;
                }
                imageListControl[i].Location = new Point(x, y);
                x += 150;
                imageListControl[i].Name = "imageList" + i.ToString();
                imageListControl[i].Size = new Size(150, 150);

                imageListControl[i].Show();
            }

            e.Result = imageListControl;
            worker.ReportProgress(1);

        }

        //When page is fetched from server
        void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Is there a error or is process canceled?
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
                nextPagebutton.Enabled = true;
                button1.Enabled = true;
                return;
            }
            else if (e.Cancelled == true)
            {
                if (page == maxPage)
                    nextPagebutton.Enabled = false;
                button1.Enabled = true;

                //MessageBox.Show("Canceled!");
                return;
            }
            //Everythins is solid, then 
            else
            {
                //Add fetched page to artistOutputArray

                artistOutputArray.Add((imageShow[])e.Result);

                //If current page is the new downloaded page,then show it
                if (page == maxPage)
                {
                    this.SuspendLayout();
                    foreach (imageShow im in (imageShow[])e.Result)
                    {
                        this.splitContainer1.Panel1.Controls.Add(im);
                    }
                    nextPagebutton.Enabled = true;
                    button1.Enabled = true;
                    this.ResumeLayout();
                }
                this.statusLabel.Text = "Fetching Artistart list complete";
                this.progressBar1.Value = 100;
                this.button1.Enabled = false;

                isDownloading = false;
            }
        }

        //Change save path when path textBox changed.
        private void path_TextChanged(object sender, EventArgs e)
        {
            downloadFromHttp.savePath = this.path.Text + "\\";
        }

        //Display a folder browser dialog.
        private void path_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = this.path.Text;
            dialog.ShowDialog();
            this.path.Text = dialog.SelectedPath;
        }

        //Download them all.
        private void downThemAllbutton_Click(object sender, EventArgs e)
        {
            foreach (imageShow showBlock in (imageShow[])artistOutputArray[page - 1])
            {
                if (!showBlock.isDownloaded)
                {
                    showBlock.indicator_LinkClicked(null, null);

                }
            }
        }

        //Next page button
        private void nextPagebutton_Click(object sender, EventArgs e)
        {
            page++;
            if (maxPage < page)
            {
                maxPage = page;
            }
            if (isDownloading && page == maxPage)
            {
                button1.Enabled = false;
                nextPagebutton.Enabled = false;
                this.pageNumber.Text = page.ToString();
                this.SuspendLayout();
                this.splitContainer1.Panel1.Controls.Clear();
                this.ResumeLayout();
                return;
            }
            this.pageNumber.Text = page.ToString();

            if (!isDownloading && artistOutputArray.Count < maxPage)
            {
                isDownloading = true;
                button1_Click(null, null);
            }
            else
            {
                this.SuspendLayout();
                this.nextPagebutton.Enabled = true;
                this.button1.Enabled = false;
                this.splitContainer1.Panel1.Controls.Clear();
                foreach (imageShow showBlock in (imageShow[])artistOutputArray[page - 1])
                {
                    this.splitContainer1.Panel1.Controls.Add(showBlock);
                }
                this.ResumeLayout();
            }
        }

        //Previous page button
        private void prePagebutton_Click(object sender, EventArgs e)
        {
            nextPagebutton.Enabled = true;
            button1.Enabled = false;
            page--;
            if (page < 1)
            {
                page = 1;
            }
            this.pageNumber.Text = page.ToString();

            this.SuspendLayout();
            this.splitContainer1.Panel1.Controls.Clear();
            foreach (imageShow showBlock in (imageShow[])artistOutputArray[page - 1])
            {
                this.splitContainer1.Panel1.Controls.Add(showBlock);
            }
            this.ResumeLayout();
        }

        //Enable mouse scrolling.
        private void splitContainer1_Panel1_MouseEnter(object sender, EventArgs e)
        {
            splitContainer1.Panel1.Focus();
        }




    }
}
