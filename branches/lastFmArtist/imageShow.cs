using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;


namespace lastFmArtist
{
    public partial class imageShow : UserControl
    {
        //Constructors
        public imageShow()
        {
            InitializeComponent();
            this.path = mainForm.savePath;
        }

        public imageShow(int id, string small, string original, string artist, string pathTmp)
        {
            InitializeComponent();
            thumbUrl = small;
            originalUrl = original;
            artistName = artist;
            dir = pathTmp;
            updateStatus();
        }

        //Properties
        public bool localShow = false;
        public bool isDownloaded = false;//Image downloaded?
        public bool isDownloading//Image downloading?
        {
            get
            {
                return this.background1 == null ? false : this.background1.IsBusy;
            }
        }
        public string path;
        public string imagePath
        {
            get
            {
                return this.path;
            }
            set
            {
                getPath();
            }
        }

        private string dir;
        private string thumbUrl;//Preview Url
        private string originalUrl;//Image Url
        private string artistName;//Artist Name
        private BackgroundWorker background1;//Enable multiThreading
        private ProgressBar progressBar1;//Progress Bar.Announced Here for dynamic display.
        private ToolTip tooltip = new ToolTip();

        //Methods

        //Update image status, is it downloaded?
        public void updateStatus()
        {
            getPath();
            //If downloaded, use local file for displaying
            if (File.Exists(this.path))
            {
                this.isDownloaded = true;
                this.imageContainer.ImageLocation = this.path;

                //Image tmpImage = Image.FromFile(this.path);

                //this.imageContainer.Image = tmpImage.GetThumbnailImage(150, 150, null, IntPtr.Zero);

                this.imageContainer.MouseClick += new MouseEventHandler(imageContainer_MouseClick);
                this.isDownloaded = true;
                this.indicator.Text = "Delete";
                this.indicator.Enabled = true;
                tooltip.SetToolTip(this.imageContainer, this.path);

            }
            else if (thumbUrl == originalUrl)
            {
                this.imageContainer.MouseClick -= new MouseEventHandler(imageContainer_MouseClick);
                this.indicator.Text = "Deleted";
                this.indicator.Enabled = false;

                isDownloaded = true;
                return;
            }
            else
            //Not downloaded
            {
                this.isDownloaded = false;
                //Add progress bar
                tooltip.RemoveAll();


                this.Controls.Remove(this.progressBar1);
                this.SuspendLayout();
                progressBar1 = new ProgressBar();
                progressBar1.Location = new System.Drawing.Point(5, 138);
                progressBar1.Name = "progressBar1";
                progressBar1.Size = new System.Drawing.Size(68, 10);
                progressBar1.TabIndex = 3;
                progressBar1.Maximum = 100;

                this.Controls.Add(progressBar1);
                this.ResumeLayout();

                this.indicator.Text = "Download";
                this.indicator.Enabled = true;
                progressBar1.Value = 0;

                this.imageContainer.MouseClick -= new MouseEventHandler(imageContainer_MouseClick);

                //Download previews
                try
                {
                    this.imageContainer.Image = Image.FromStream(mainForm.downloadThumb(thumbUrl));
                }
                catch
                {
                    MessageBox.Show("Download Error");
                }

            }
        }

        //Open downloaded file when clicked
        void imageContainer_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                try
                {
                    System.Diagnostics.Process.Start(this.path);
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
            else
            {
                try
                {
                    //Environment.GetEnvironmentVariable("windir") + @
                    System.Diagnostics.Process.Start(@"Explorer.exe", "/Select,\"" + this.path + "\"");
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
        }

        //Get path from static class DownloadFromHttp
        //and create the full file path
        public string getPath()
        {
            if (thumbUrl == originalUrl)
            {
                this.path = originalUrl;
                return this.path;
            }

            if (dir != null)
            {
                this.path =
                   Path.Combine(dir, fileNameBuilder());
            }
            else
            {
                this.path = Path.Combine(mainForm.savePath, fileNameBuilder());
            }
            return this.path;
        }

        private string fileNameBuilder()
        {
            //Get identical number frome server and build filename 
            string identifier = originalUrl;
            identifier = identifier.ToString().Remove(identifier.ToString().LastIndexOf("/"));
            identifier = identifier.Remove(0, identifier.LastIndexOf("/") + 1);

            string filenamePrefix = this.artistName;

            foreach (char invalidChar in Path.GetInvalidFileNameChars())
            {
                filenamePrefix = filenamePrefix.Replace(invalidChar, '-');
            }
            return filenamePrefix + "_" + identifier + Path.GetExtension(originalUrl);


        }

        //Download button clicked
        public void indicator_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {


            if (!isDownloaded && !isDownloading)
            {
                this.background1 = new BackgroundWorker();
                this.background1.WorkerReportsProgress = true;
                this.background1.ProgressChanged += new ProgressChangedEventHandler(background1_ProgressChanged);
                this.background1.DoWork += new DoWorkEventHandler(background1_DoWork);
                this.background1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(background1_RunWorkerCompleted);
                this.indicator.Text = "Downloading";
                this.indicator.Enabled = false;
                this.background1.RunWorkerAsync();
            }
            else if (isDownloaded)
            {
                this.indicator.Enabled = false;
                this.indicator.Text = "Padding";
                confirmDelete confirmDialog = new confirmDelete(this);
                confirmDialog.Show();
            }

        }

        //Progress bar update.
        private void background1_ProgressChanged(object sender, ProgressChangedEventArgs e)
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
        private void background1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
                mainForm.downloadThread--;
                return;
            }

            this.updateStatus();
            //this.imageContainer.ImageLocation = path;

            //this.indicator.Text = "Delete";
            //this.indicator.Enabled = true;
            //this.imageContainer.Click += new EventHandler(imageContainer_Click);

            //this.isDownloaded = true;

            mainForm.downloadThread--;

            ((BackgroundWorker)sender).Dispose();
        }




        //Download image in another thread.
        private void background1_DoWork(object sender, DoWorkEventArgs e)
        {
            //downloadImageFromHttp(originalUrl, artistName, background1);
            mainForm.downloadThread++;

            WebRequest req = WebRequest.Create(originalUrl);

            //this is for my testing..I have a very poor Internet connection.
            req.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.CacheIfAvailable);
            //cache end.

            WebResponse result = null;
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
            if (File.Exists(mainForm.savePath) || size == 0) return;

            //bool value = false;
            byte[] buffer = new byte[1024];
            Stream outStream = null;
            Stream inStream = null;
            try
            {
                outStream = System.IO.File.Create(this.path);
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

                //value = true;

            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);

            }
            finally
            {
                if (outStream != null) outStream.Close();
                if (inStream != null) inStream.Close();
                if (result != null) result.Close();

            }


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
