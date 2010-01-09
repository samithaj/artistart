using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;


namespace artistArtGui
{
    public partial class imageShow : UserControl
    {
        //Constructors
        public imageShow()
        {
        }
        public imageShow(int id, string small, string original, string artist)
        {
            InitializeComponent();
            thumbUrl = small;
            originalUrl = original;
            artistName = artist;
            updateStatus();
        }

        //Properties
        public bool localShow = false;
        public bool isDownloaded = false;//Image downloaded?
        public bool isDownloading = false;//Image downloading?
        private string thumbUrl;//Preview Url
        private string originalUrl;//Image Url
        private string artistName;//Artist Name
        private BackgroundWorker background1 = new BackgroundWorker();//Enable multiThreading
        private ProgressBar progressBar1;//Progress Bar.Announced Here for dynamic display.

        //Methods

        //Update image status, is it downloaded?
        public void updateStatus()
        {
            string filename = getPath();
            //If downloaded, use local file for displaying
            if (File.Exists(filename))
            {
                this.isDownloaded = true;
                this.imageContainer.ImageLocation = filename;
                this.imageContainer.Click += new EventHandler(imageContainer_Click);
                this.isDownloaded = true;
                this.indicator.Text = "Delete";
                this.indicator.Enabled = true;
            }
            else if (thumbUrl == originalUrl)
            {
                this.imageContainer.Click -= new EventHandler(imageContainer_Click);
                this.indicator.Text = "Deleted";
                this.indicator.Enabled = false;
                return;
            }
            else
            //Not downloaded
            {
                //Add progress bar
                this.SuspendLayout();
                progressBar1 = new ProgressBar();
                progressBar1.Location = new System.Drawing.Point(5, 138);
                progressBar1.Name = "progressBar1";
                progressBar1.Size = new System.Drawing.Size(68, 10);
                progressBar1.TabIndex = 3;
                progressBar1.Maximum = 100;
                Controls.Add(progressBar1);
                this.ResumeLayout();

                this.indicator.Text = "Download";
                this.indicator.Enabled = true;
                this.imageContainer.Click -= new EventHandler(imageContainer_Click);
                //Download previews
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

        //Get path from static class DownloadFromHttp
        //and create the full file path
        public string getPath()
        {
            if (thumbUrl == originalUrl) return originalUrl;
            string filename;
            filename = originalUrl.ToString().Remove(originalUrl.ToString().LastIndexOf("/"));
            filename = filename.Remove(0, filename.LastIndexOf("/") + 1);
            filename = downloadFromHttp.savePath + artistName + "_" + filename + Path.GetExtension(originalUrl);
            return filename;
        }

        //Download button clicked
        public void indicator_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if (!isDownloaded && !isDownloading)
            {
                background1.WorkerReportsProgress = true;
                background1.ProgressChanged += new ProgressChangedEventHandler(background1_ProgressChanged);
                background1.DoWork += new DoWorkEventHandler(background1_DoWork);
                background1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(background1_RunWorkerCompleted);
                this.indicator.Text = "Downloading";
                this.indicator.Enabled = false;
                background1.RunWorkerAsync();
            }
            else
            {
                this.indicator.Enabled = false;
                this.indicator.Text = "Padding";
                confirmDelete confirmDialog = new confirmDelete(this);
                confirmDialog.Show();

            }
        }

        //Progress bar update.
        void background1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ////Test returned value
            //if (e.ProgressPercentage > 100)
            //{
            //    MessageBox.Show("Over");
            //    return;
            //}
            this.progressBar1.Value = e.ProgressPercentage;
        }

        //Downloading completes and update the preview.
        void background1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
                return;
            }
            this.imageContainer.ImageLocation = getPath();

            this.indicator.Text = "Delete";
            this.indicator.Enabled = true;
            this.imageContainer.Click += new EventHandler(imageContainer_Click);
            this.isDownloading = false;
            this.isDownloaded = true;
            ((BackgroundWorker)sender).Dispose();
        }

        //Open downloaded file when clicked
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

        //Download image in another thread.
        void background1_DoWork(object sender, DoWorkEventArgs e)
        {
            //downloadImageFromHttp(originalUrl, artistName, background1);

            isDownloading = true;
            string path;
            WebRequest req = WebRequest.Create(originalUrl);

            //this is for my testing..I have a very poor Internet connection.
            req.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.CacheIfAvailable);
            //cache end.

            WebResponse result = null;

            //Get identical number frome server and build filename 
            string identifier = originalUrl;
            identifier = identifier.ToString().Remove(identifier.ToString().LastIndexOf("/"));
            identifier = identifier.Remove(0, identifier.LastIndexOf("/") + 1);
            string filenamePrefix = artistName;

            foreach (char invalidChar in Path.GetInvalidFileNameChars())
            {
                filenamePrefix = filenamePrefix.Replace(invalidChar, '-');
            }
            path = downloadFromHttp.savePath + filenamePrefix + "_" + identifier + Path.GetExtension(originalUrl);
            //MessageBox.Show(path);
            long size = 0;

            try
            {
                result = req.GetResponse();
                size = result.ContentLength;
            }
            catch
            {
                return;
            }

            //Test if file exists again.
            if (File.Exists(downloadFromHttp.savePath) || size == 0) return;

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
                    background1.ReportProgress(callback);

                } while (l > 0);

                value = true;

            }
            catch (Exception err)
            {
                isDownloading = false;
                MessageBox.Show(err.Message);

            }
            finally
            {
                if (outStream != null) outStream.Close();
                if (inStream != null) inStream.Close();
                if (result != null) result.Close();
                isDownloading = false;
            }

            isDownloading = false;
            //if (value) returnValue = 1;
            return;

        }

        public Image returnImage()
        {
            return this.imageContainer.Image;
        }

        public void makeDeleteEnabled()
        {
            this.indicator.Text = "Delete";
            this.indicator.Enabled = true;
        }

    }
}
