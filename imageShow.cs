using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;


namespace artistArtGui
{
    public partial class imageShow : UserControl
    {
        public bool isDownloaded = false;
        public int idNumber;
        private string thumbUrl;
        private string originalUrl;
        private string artistName;
        private BackgroundWorker background1 = new BackgroundWorker();
        private ProgressBar progressBar1;
        public imageShow()
        {
        }

        public imageShow(int id, string small, string original, string artist)
        {
            InitializeComponent();
            idNumber = id;

            thumbUrl = small;
            originalUrl = original;
            artistName = artist;
            updateStatus();
        }

        public void updateStatus()
        {
            string filename = getPath();

            if (File.Exists(filename))
            {

                this.indicator.Text = "Downloaded";
                this.indicator.Enabled = false;
                this.imageContainer.ImageLocation = filename;
                this.imageContainer.Click += new EventHandler(imageContainer_Click);
                this.isDownloaded = true;
            }
            else
            {
                this.SuspendLayout();

                progressBar1 = new ProgressBar();
                progressBar1.Location = new System.Drawing.Point(5, 138);
                progressBar1.Name = "progressBar1";
                progressBar1.Size = new System.Drawing.Size(68, 10);
                progressBar1.TabIndex = 3;
                progressBar1.Maximum = 100;
                Controls.Add(progressBar1);

                this.ResumeLayout();
                try
                {
                    this.imageContainer.Image = Image.FromStream(downloadFromHttp.downloadThumb(thumbUrl));
                }
                catch
                {
                    MessageBox.Show("Download Error");
                }

            }
        }

        private string getPath()
        {
            string filename;
            filename = originalUrl.ToString().Remove(originalUrl.ToString().LastIndexOf("/"));
            filename = filename.Remove(0, filename.LastIndexOf("/") + 1);
            filename = downloadFromHttp.savePath + artistName + "_" + filename + ".jpg";
            return filename;
        }

        public void indicator_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            background1.WorkerReportsProgress = true;
            background1.ProgressChanged += new ProgressChangedEventHandler(background1_ProgressChanged);
            background1.DoWork += new DoWorkEventHandler(background1_DoWork);
            background1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(background1_RunWorkerCompleted);
            this.indicator.Enabled = false;
            this.indicator.Text = "Downloading";
            background1.RunWorkerAsync();
        }

        void background1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //if (e.ProgressPercentage > 100)
            //{
            //    MessageBox.Show("Over");
            //    return;
            //}
            this.progressBar1.Value = e.ProgressPercentage;
        }

        void background1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
                return;
            }
            this.imageContainer.ImageLocation = getPath();
            this.indicator.Enabled = false;
            this.indicator.Text = "Downloaded";
            this.imageContainer.Click += new EventHandler(imageContainer_Click);
            this.isDownloaded = true;
            ((BackgroundWorker)sender).Dispose();
        }

        void imageContainer_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(getPath());
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        void background1_DoWork(object sender, DoWorkEventArgs e)
        {
            downloadImageFromHttp(originalUrl, artistName, background1);
        }

        private int downloadImageFromHttp(string url, string prefix, BackgroundWorker worker)
        {

            string path;
            int returnValue = 0;
            WebRequest req = WebRequest.Create(url);
            req.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.CacheIfAvailable);
            WebResponse result = null;

            string filename = url;
            filename = filename.ToString().Remove(filename.ToString().LastIndexOf("/"));
            filename = filename.Remove(0, filename.LastIndexOf("/") + 1);
            path = downloadFromHttp.savePath + prefix + "_" + filename + ".jpg";
            try
            {
                result = req.GetResponse();
                long size = result.ContentLength;
                if (File.Exists(downloadFromHttp.savePath)) return 0;

                bool value = false;
                byte[] buffer = new byte[1024];
                Stream outStream = null;
                Stream inStream = null;
                try
                {
                    outStream = System.IO.File.Create(path);
                    inStream = result.GetResponseStream();
                    int l;
                    long j = 0;
                    int callback = 0;
                    do
                    {

                        l = inStream.Read(buffer, 0, buffer.Length);
                        if (l > 0) outStream.Write(buffer, 0, l);
                        j += l;
                        callback = (int)((float)(j) / (float)size * 100);
                        worker.ReportProgress(callback);

                    } while (l > 0);

                    value = true;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                finally
                {
                    if (outStream != null) outStream.Close();
                    if (inStream != null) inStream.Close();
                }

                if (value) return 1;
            }
            catch
            {
                returnValue = -1;
            }
            finally
            {
                if (result != null) result.Close();
            }
            return returnValue;


        }



    }
}
