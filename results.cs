using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DeviceApplication11
{
    public partial class results : Form
    {
        public results()
        {
            InitializeComponent();
            this.Location = new Point(
            Screen.PrimaryScreen.WorkingArea.Width / 2 - this.Width / 2,
            Screen.PrimaryScreen.WorkingArea.Height / 3 - this.Height / 2);
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Dispose();
            this.Close();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rec = new Rectangle(3, 3, pictureBox1.Width - 6, pictureBox1.Height - 6);
            e.Graphics.DrawRectangle(new Pen(System.Drawing.Color.Black,2),rec);
        }
    }
}