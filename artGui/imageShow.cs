using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class imageShow : UserControl
    {
        public int idNumber;

        private string thumbUrl;
        private string originalUrl;
        private string artistName;

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
        private void updateStatus()
        {
            string filename;
            filename = originalUrl.ToString().Remove(originalUrl.ToString().LastIndexOf("/"));
            filename = filename.Remove(0, filename.LastIndexOf("/") + 1);
            filename = downloadFromHttp.savePath + artistName + "_" + filename + ".jpg";

            if (File.Exists(filename))
            {
                this.indicator.Enabled = false;
                this.imageContainer.ImageLocation = filename;
            }
            else
            {
                this.imageContainer.Image = Image.FromStream(downloadFromHttp.downloadThumb(thumbUrl));
            }
        }

        private void indicator_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            downloadFromHttp.downloadImageFromHttp(originalUrl, artistName);
        }

    }
}
