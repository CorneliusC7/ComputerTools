using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace ComputerTools
{
    public partial class Form1 : Form
    {
        public bool autoClean = false;
        public PerformanceCounter cpuCounter;
        public PerformanceCounter ramCounter;
        public Form1()
        {
            InitializeComponent();
            PCCLEANING.Visible = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            ramCounter = new PerformanceCounter("Memory", "Available MBytes");
        }


        private void button1_Click(object sender, EventArgs e)
        {
            PCCLEANING.Visible = !PCCLEANING.Visible;
        }

        private void PCCLEANING_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PCCLEANING.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PCCLEANING.Visible = false;
        
        }

        private void button7_Click(object sender, EventArgs e)
        {
            autoClean = checkBox1.Checked;
            if(autoClean == true)
            {
                timer1.Start();
            }
            else
            {
                timer1.Stop();
            }

            MessageBox.Show("Automatic Cleaning : " + autoClean.ToString());
            button7.Enabled = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            button7.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("CMD.exe", "/c shutdown -r");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = @"/c del /q C:\Windows\Temp\*";
            process.StartInfo = startInfo;
            process.Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = @"/c del /q C:\Windows\Prefetch\*";
            process.StartInfo = startInfo;
            process.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = @"/C del /f /q C:\Windows\Temp\*";
            process.StartInfo = startInfo;
            process.Start();
        }
        public float getCurrentCpuUsage()
        {
            return cpuCounter.NextValue();
        }

        public float getAvailableRAM()
        {
            return ramCounter.NextValue();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.WindowState = FormWindowState.Minimized;
            this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            this.ShowInTaskbar = false;
            timer3.Start();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            timer3.Stop();
        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
