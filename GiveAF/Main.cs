// -----------------------------------------------------------
// This program is private software, based on C# source code.
// To sell or change credits of this software is forbidden,
// except if someone approves it from GiveAF INC. team.
// -----------------------------------------------------------
// Copyrights (c) 2016 GiveAF INC. All rights reserved.
// -----------------------------------------------------------

#region

using System;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

#endregion

// ReSharper disable InvertIf

namespace GiveAF
{
    internal sealed partial class Main : Form
    {
        private readonly Timer _timer = new Timer();

        public Main()
        {
            InitializeComponent();
            _timer.Tick += timer_Tick;
        }

        private void AnimateProgBar(int milliSeconds)
        {
            if (!_timer.Enabled)
            {
                progressBar1.Value = 0;
                _timer.Interval = milliSeconds/100;
                _timer.Enabled = true;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value == 100)
            {
                _timer.Stop();
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
                    _timer.Enabled = false;
                }
            }
        }

        private void FinishTimer()
        {
            Thread.Sleep(1000);
            MessageBox.Show(@"ERROR: Unable to give a fuck.");
            MethodInvoker inv = delegate
            {
                progressBar1.Value = 0;
                progressBar1.Refresh();
                label1.Text = @"No fucks given.";
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