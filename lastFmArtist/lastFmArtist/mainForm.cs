using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace lastFmArtist
{
    public delegate void numberChangedHandler();

    public partial class mainForm : Form
    {

        void dd(object sender, EventArgs e)
        {
            aboutForm aboutForm = new aboutForm();

            aboutForm.Show();
        }

        private int oldImagesOnePageHas;

        public mainForm()
        {
            mainForm.savePath = Directory.CreateDirectory(Path.Combine(System.Windows.Forms.Application.StartupPath, "DefaultLib")).FullName;
            InitializeComponent();
            mainForm.numberChanged += new numberChangedHandler(downloadFromHttp_numberChanged);
            this.groupBox2.ContextMenu = new ContextMenu(new MenuItem[] { new MenuItem("About", new EventHandler(dd)) });
        }
        public mainForm(string[] artistListTmp, string pathTmp, int pageHaveImagesNumTmp)
        {
            InitializeComponent();
            mainForm.numberChanged += new numberChangedHandler(downloadFromHttp_numberChanged);


            if (!Directory.Exists(pathTmp))
            {
                foreach (char invalidChar in Path.GetInvalidPathChars())
                {
                    pathTmp = pathTmp.Replace(invalidChar, '-');
                }
                Directory.CreateDirectory(pathTmp);
            }

            mainForm.savePath = pathTmp;

            this.pageHaveImagesNumber.Value = pageHaveImagesNumTmp;

            foreach (string artistNameTmp in artistListTmp)
            {
                addOrSwitchNewArtistTab(artistNameTmp, true);
            }
        }

        //Methods
        private void searchBTN_Click(object sender, EventArgs e)
        {
            if (this.artistNameTXB.Text != string.Empty)
            {
                addOrSwitchNewArtistTab(this.artistNameTXB.Text, true);
                if (this.withWikiCheckBox.Checked)
                {
                    fetchWiki(this.artistNameTXB.Text);
                }
                this.artistTabPage.SelectTab(this.artistNameTXB.Text);
            }
        }

        //Delete Resize method...Using flowPanel
        //private void artistTabPage_Resize(object sender, EventArgs e)
        //{
        //    ((artistPagesControl)(this.artistTabPage.SelectedTab.Controls["page"])).redrawPage();
        //}

        private void localRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (artistTabPage.TabCount == 0)
            {
                return;
            }
            else
            {
                ((artistPagesControl)(artistTabPage.SelectedTab.Controls["page"])).redrawPage((int)(this.pageHaveImagesNumber.Value));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will cost a lot of your memory if you have a large collection, continue?", "Confirm Display All", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.artistTabPage.TabPages.Clear();
                this.localRadioButton.CheckedChanged -= new EventHandler(localRadioButton_CheckedChanged);
                this.localRadioButton.Select();
                this.localRadioButton.CheckedChanged += new EventHandler(localRadioButton_CheckedChanged);
                string[] fileNames = System.IO.Directory.GetFiles(mainForm.savePath, "*_*.jpg");
                foreach (string artistNameTmp in fileNames)
                {
                    addOrSwitchNewArtistTab(System.IO.Path.GetFileNameWithoutExtension(artistNameTmp.Remove(artistNameTmp.LastIndexOf('_'))), false);
                }
                fileNames = System.IO.Directory.GetFiles(mainForm.savePath, "*_*.png");
                foreach (string artistNameTmp in fileNames)
                {
                    addOrSwitchNewArtistTab(System.IO.Path.GetFileNameWithoutExtension(artistNameTmp.Remove(artistNameTmp.LastIndexOf('_'))), false);
                }
                fileNames = System.IO.Directory.GetFiles(mainForm.savePath, "*_*.gif");
                foreach (string artistNameTmp in fileNames)
                {
                    addOrSwitchNewArtistTab(System.IO.Path.GetFileNameWithoutExtension(artistNameTmp.Remove(artistNameTmp.LastIndexOf('_'))), false);
                }
            }

        }

        private void addOrSwitchNewArtistTab(string artistNameTmp, bool isToGotoFoundTab)
        {
            bool found = false;
            foreach (TabPage artistTabPageTmp in this.artistTabPage.TabPages)
            {
                if (artistTabPageTmp.Text.Equals(artistNameTmp, StringComparison.CurrentCultureIgnoreCase))
                {
                    if (isToGotoFoundTab)
                    {
                        artistTabPage.SelectTab(artistTabPageTmp.Name);

                        if ((int)(this.pageHaveImagesNumber.Value) != this.oldImagesOnePageHas)
                        {
                            this.oldImagesOnePageHas = (int)(this.pageHaveImagesNumber.Value);
                            ((artistPagesControl)(artistTabPage.SelectedTab.Controls["page"])).redrawPage(this.oldImagesOnePageHas);
                        }
                        else
                        {
                            //       ((artistPagesControl)(artistTabPage.SelectedTab.Controls["page"])).redrawPage();
                        }
                    }
                    found = true;
                    return;
                }
            }
            if (!found || artistTabPage.TabPages.Count == 0)
            {
                this.oldImagesOnePageHas = (int)(this.pageHaveImagesNumber.Value);

                TabPage anewTabPage = new TabPage(artistNameTmp);
                anewTabPage.Name = artistNameTmp;

                artistPagesControl anewArtistTabPage = new artistPagesControl(artistNameTmp, (int)(this.pageHaveImagesNumber.Value), localRadioButton);
                anewArtistTabPage.Dock = DockStyle.Fill;
                anewArtistTabPage.Name = "page";
                anewTabPage.Controls.Add(anewArtistTabPage);
                this.SuspendLayout();
                this.artistTabPage.TabPages.Add(anewTabPage);
                this.ResumeLayout();
            }
        }

        private void downloadFromHttp_numberChanged()
        {
            if (this.downloadingNumLabel.InvokeRequired)
            {
                numberChangedHandler newHandler = new numberChangedHandler(changeLabelNumber);
                this.Invoke(newHandler);
                //this.downloadingNumLabel.Text = mainForm.downloadThread.ToString();
            }
            else
            {
                this.downloadingNumLabel.Text = mainForm.downloadingNum.ToString();
            }
        }

        private void changeLabelNumber()
        {
            this.downloadingNumLabel.Text = mainForm.downloadingNum.ToString();
        }

        private void fetchWiki(string artistTarget)
        {
            BackgroundWorker wikiWorker = new BackgroundWorker();
            wikiWorker.DoWork += new DoWorkEventHandler(wikiWorker_DoWork);
            wikiWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(wikiWorker_RunWorkerCompleted);
            wikiWorker.RunWorkerAsync(artistTarget);
        }

        private void wikiWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.textBox1.Text = (string)(e.Result);
        }

        private void wikiWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            System.Xml.XmlDocument Artlist = new System.Xml.XmlDocument();

            string xml = mainForm.downloadTextFromHttp("http://ws.audioscrobbler.com/2.0/?method=artist.getinfo&artist=" + (string)e.Argument + "&api_key=aa55f6dc630a531d0a093c1ca77df129");
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

            System.Xml.XmlNodeList nodeList = Artlist.GetElementsByTagName("summary");


            e.Result = System.Web.HttpUtility.HtmlDecode(System.Text.RegularExpressions.Regex.Replace(nodeList[0].InnerText, @"<(.|\n)*?>", string.Empty));

            //e.Result = nodeList[0].InnerText;
        }

        private void artistTabPage_DoubleClick(object sender, EventArgs e)
        {
            ((TabControl)sender).SelectedTab.Dispose();
        }



        private void libraryBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog aNewDialog = new FolderBrowserDialog();
            aNewDialog.SelectedPath = mainForm.savePath;
            aNewDialog.ShowDialog();
            if (aNewDialog.SelectedPath != mainForm.savePath)
            {
                mainForm.savePath = aNewDialog.SelectedPath;
            }
        }

        private void artistTabPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.withWikiCheckBox.Checked && this.artistTabPage.TabCount > 0)
                fetchWiki(this.artistTabPage.SelectedTab.Text);
        }

        private void withWikiCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.withWikiCheckBox.Checked)
            {
                this.textBox1.Text = "";
            }
            else if (this.artistTabPage.TabCount != 0)
            {
                fetchWiki(this.artistTabPage.SelectedTab.Text);
            }
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            ToolTip aNewToolTip = new ToolTip();
            aNewToolTip.SetToolTip(withWikiCheckBox, "Display Artist's Summary?");
            aNewToolTip.SetToolTip(artistNameTXB, "Artist Name");
            aNewToolTip.SetToolTip(allImageradioButton, "Display local and remote images");
            aNewToolTip.SetToolTip(localRadioButton, "Only display local images based on each tab's path");
            aNewToolTip.SetToolTip(button1, "Display images of all aritsts' in library !LARGE MEMORY USAGE");
            aNewToolTip.SetToolTip(pageHaveImagesNumber, "Number of images one page has");
        }

        /*Static Properties and methods*/
        static event numberChangedHandler numberChanged;

        static private int downloadingNum = 0;

        static public string savePath = @"K:\artistart\by_artistName\";

        static public string downloadTextFromHttp(string url)
        {
            WebRequest req = WebRequest.Create(url);
            WebResponse result = null;
            Stream ReceiveStream = null;
            StreamReader readerOfStream = null;

            //this is for my testing..I have a very poor Internet connection.
            req.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.CacheIfAvailable);
            //cache end.
            try
            {
                result = req.GetResponse();
                ReceiveStream = result.GetResponseStream();
                readerOfStream = new StreamReader(ReceiveStream);
                return readerOfStream.ReadToEnd();
            }
            catch (Exception err)
            {
                System.Windows.Forms.MessageBox.Show(err.Message);
                return null;
            }
            finally
            {
                if (readerOfStream != null) readerOfStream.Close();
                if (ReceiveStream != null) ReceiveStream.Close();
            }

        }

        static public Stream downloadThumb(string url)
        {
            WebRequest req = WebRequest.Create(url);
            WebResponse result = null;
            req.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.CacheIfAvailable);
            try
            {
                result = req.GetResponse();
                return result.GetResponseStream();
            }
            catch
            {
                return null;
            }
        }

        static public int downloadThread
        {
            get
            {
                return downloadingNum;
            }
            set
            {
                downloadingNum = value;
                numberChanged();
            }
        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {

            FontDialog aNewDialog = new FontDialog();
            aNewDialog.Font = this.textBox1.Font;
            aNewDialog.ShowDialog();
            this.textBox1.Font = aNewDialog.Font;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.artistTabPage.SelectedTab != null)
                ((artistPagesControl)(this.artistTabPage.SelectedTab.Controls["page"])).redrawPage((int)(this.pageHaveImagesNumber.Value));
        }


    }
}
