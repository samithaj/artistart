using System.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace lastFmArtist
{
    public partial class confirmDelete : Form
    {
        private imageShow TodeleteImage;

        public confirmDelete(imageShow inShow)
        {
            TodeleteImage = inShow;
            this.TopMost = true;
            InitializeComponent();
            this.pictureBox1.Image = inShow.returnImage();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                File.Delete(TodeleteImage.path);
                TodeleteImage.updateStatus();
                //TodeleteImage.isDownloaded = false;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                TodeleteImage.makeDeleteEnabled();
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TodeleteImage.makeDeleteEnabled();
            this.Close();
        }

        private void confirmDelete_Leave(object sender, EventArgs e)
        {
            this.Focus();
        }






    }
}
