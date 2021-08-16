using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace ComputerTools
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            if(saveFileDialog1.FileName != "")
            {
                string pathsa = Path.GetFullPath(saveFileDialog1.FileName);
                WebClient webClient = new WebClient();
                webClient.DownloadFile(textBox1.Text, pathsa);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
