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
            pathIn = pathIn.Remove(pathIn.LastIndexOf(@"\") + 1);



            if (System.IO.Directory.Exists(pathIn))
                path.Text = pathIn;
            if (int.Parse(numberIn) > 50)
            {
                MessageBox.Show("Reach limit");
                this.number.Value = 5;
            }
            else
            {
                number.Value = int.Parse(numberIn);
            }
            button1_Click(null, null);

        }
        private int page = 1;
        public XmlDocument Artlist;
        private int maxPage = 1;
        public ArrayList imageListCollection;
        private BackgroundWorker backgroundWorker1 = new BackgroundWorker();
        private bool isDownloading;
        //! Cache resoult!
        private ArrayList artistOutputArray = new ArrayList();

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

        void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

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
                    return;
                }

                Artlist.LoadXml(xml);
            }
            catch
            {
                this.statusLabel.Text = "Download list eror, check your network connection!";
                MessageBox.Show("Download list eror");
                e.Cancel = true;
                return;
            }
            XmlNodeList nodeList = Artlist.GetElementsByTagName("image");

            imageShow[] imageListControl = new imageShow[nodeList.Count];
            //this.SuspendLayout();
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

                //this.splitContainer1.Panel1.Controls.Add(imageListControl[i]);

                imageListControl[i].Show();
            }
            //this.ResumeLayout();
            e.Result = imageListControl;
            worker.ReportProgress(1);

        }

        void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);

                nextPagebutton.Enabled = true;
                button1.Enabled = true;
                return;
            }
            else if (e.Cancelled == true)
            {

                nextPagebutton.Enabled = true;
                button1.Enabled = true;
                MessageBox.Show("Canceled!");
                return;
            }
            else
            {
                artistOutputArray.Add((imageShow[])e.Result);

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

        private void path_TextChanged(object sender, EventArgs e)
        {
            downloadFromHttp.savePath = this.path.Text;
        }

        public static void getProgress(string stuts, int percentage)
        {

        }

        private void path_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = this.path.Text;
            dialog.ShowDialog();
            this.path.Text = dialog.SelectedPath;
        }

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


    }
}
