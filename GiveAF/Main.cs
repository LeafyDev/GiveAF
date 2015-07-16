using System;
using System.Threading;
using System.Windows.Forms;

using Timer = System.Windows.Forms.Timer;

// ReSharper disable InvertIf

namespace GiveAF
{
    public partial class Main : Form
    {
        private readonly Timer timer = new Timer();

        public Main()
        {
            InitializeComponent();
            timer.Tick += timer_Tick;
        }

        public void AnimateProgBar(int milliSeconds)
        {
            if(!timer.Enabled)
            {
                progressBar1.Value = 0;
                timer.Interval = milliSeconds / 100;
                timer.Enabled = true;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if(progressBar1.Value == 100)
            {
                timer.Stop();
                progressBar1.Refresh();
                var t = new Thread(FinishTimer);
                t.Start();
            }
            else
            {
                if (progressBar1.Value < 100)
                {
                    progressBar1.Value += 1;
                    progressBar1.Refresh();
                }
                else
                {
                    timer.Enabled = false;
                }
            }
        }

        public void FinishTimer()
        {
            Thread.Sleep(1000);
            MessageBox.Show(@"ERROR: Unable to give a fuck.");
            MethodInvoker inv = delegate
            {
                this.progressBar1.Value = 0;
                this.progressBar1.Refresh();
                this.label1.Text = @"No fucks given.";
            };
            Invoke(inv);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = @"Attempting to give a fuck...";
            AnimateProgBar(3500);
        }
    }
}