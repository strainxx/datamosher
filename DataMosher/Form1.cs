using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataMosher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog origDialog = new OpenFileDialog();
            origDialog.Filter = "Images|*.jpg;*.jpeg;*.png;...";
            if (origDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Loaded image", "Datamosher", MessageBoxButtons.OK, MessageBoxIcon.Information);
                origFileLabel.Text = origDialog.FileName;
            }
        }

        void datamoshImg(string imgpath, string output, int maxByte, int maxArray)
        {
            byte[] byteData = File.ReadAllBytes(imgpath);
            Random r = new Random();
            for (int i = 0; i < 2000000; i++)
            {
                byteData[r.Next(1000, maxArray)] = (byte)r.Next(maxByte);
            }
            File.WriteAllBytes(output, byteData);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ext = Path.GetExtension(origFileLabel.Text);
            //MessageBox.Show(ext);
            datamoshImg(origFileLabel.Text, Environment.GetEnvironmentVariable("USERPROFILE") + @"\" + "Downloads\\datamoshed" + ext, (int)maxbyte.Value, (int)maxarr.Value);
        }
    }
}
