﻿using System.Threading;
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
            number.Value = int.Parse(numberIn);

            button1_Click(null, null);

        }


        public XmlDocument Artlist;
        public ArrayList imageListCollection;
        private BackgroundWorker backgroundWorker1 = new BackgroundWorker();


        private void button1_Click(object sender, EventArgs e)
        {
            this.artistLabel.Text = this.artistName.Text;
            this.splitContainer1.Panel1.Controls.Clear();
            statusLabel.Text = "Fetching Artistart list...";
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
                string xml = downloadFromHttp.downloadTextFromHttp("http://ws.audioscrobbler.com/2.0/?method=artist.getimages&artist=" + artistName.Text + "&api_key=aa55f6dc630a531d0a093c1ca77df129&limit=" + number.Value.ToString());
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

                return;
            }
            else if (e.Cancelled == true)
            {
                return;
            }
            else
            {
                this.SuspendLayout();
                foreach (imageShow im in (imageShow[])e.Result)
                {
                    this.splitContainer1.Panel1.Controls.Add(im);
                }
                this.ResumeLayout();
                this.statusLabel.Text = "Fetching Artistart list complete";
                this.progressBar1.Value = 100;
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
            dialog.ShowDialog();
            this.path.Text = dialog.SelectedPath;
        }
    }
}