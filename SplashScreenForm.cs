using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DeviceApplication11
{
    public partial class SplashScreenForm : Form
    {
        public SplashScreenForm()
        {
            InitializeComponent();
            timer1.Enabled = true;
            this.Location = new Point(
Screen.PrimaryScreen.WorkingArea.Width / 2 - this.Width / 2,
Screen.PrimaryScreen.WorkingArea.Height / 2 - this.Height / 2);  
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}