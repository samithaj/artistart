using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Xml;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public XmlDocument Artlist;
        public ArrayList urlList;

        private void button1_Click(object sender, EventArgs e)
        {
            int x = 0, y = 0;

            Artlist = new XmlDocument();
            string xml = downloadFromHttp.downloadTextFromHttp("http://ws.audioscrobbler.com/2.0/?method=artist.getimages&artist=" + artistName.Text + "&api_key=aa55f6dc630a531d0a093c1ca77df129&limit=" + number.Value.ToString());
            if (xml == null)
            {
                return;
            }
            Artlist.LoadXml(xml);
            XmlNodeList nodeList = Artlist.GetElementsByTagName("image");

            imageShow[] imageListControl = new imageShow[nodeList.Count];
            this.SuspendLayout();
            for (int i = 0; i < nodeList.Count; i++)
            {
                imageListControl[i] = new imageShow(i, 
                    nodeList.Item(i).SelectSingleNode("sizes").SelectSingleNode("size[@name=\"medium\"]").InnerText,
                    nodeList.Item(i).SelectSingleNode("sizes").SelectSingleNode("size[@name=\"original\"]").InnerText,
                    artistName.Text);
                if (x + 150 > this.splitContainer1.Panel1.Width)
                {
                    y += 150;
                    x = 0;
                }
                imageListControl[i].Location = new Point(x, y);
                x += 150;

                imageListControl[i].Name = "imageList" + i.ToString();
                imageListControl[i].Size = new Size(150, 150);
                this.splitContainer1.Panel1.Controls.Add(imageListControl[i]);
                imageListControl[i].Show();
            }
            this.ResumeLayout();
        }

        private void path_TextChanged(object sender, EventArgs e)
        {
            downloadFromHttp.savePath = this.path.Text;
        }

    }
}
