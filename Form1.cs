using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace AntivirusForFilesHaritTalwar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string GetMD5FromFile(string filenPath)
        {
            using(var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filenPath))
                {
                    return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty.ToLower());
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var md5signatures = File.ReadAllLines("MD5Base.txt");
            if (md5signatures.Contains(tbMD5.Text))
            {
                lblStatus.Text = "This file is INFECTED!";
            }
            else
            {
                lblStatus.Text = "This file is CLEAN!";
            }
        }

        private void browseFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Textfiles | *.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tbMD5.Text = GetMD5FromFile(ofd.FileName);
            }
        }

        private void tbFilePath_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
