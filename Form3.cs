using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.WindowsMobile.Forms;
using Microsoft.WindowsMobile.PocketOutlook;

namespace DeviceApplication11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            SplashScreenForm frm = new SplashScreenForm();
            frm.Show();
            InitializeComponent();
            cmbxOm.Enabled = false;
            cmbxEkh.Enabled = false;
            lblVer.Text = "Version " + Version;
            this.pictureBox5.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox5_Paint);
            cmboxrshow.SelectedIndex = 0;
            
            try
            {
            string imageaddress = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase.ToString()) ; 
            pictureBox7.Image = new Bitmap(imageaddress + @"\resources\images\background.jpg");
            pictureBox1.Image = new Bitmap(imageaddress + @"\resources\images\panelom.jpg");
            pictureBox2.Image = new Bitmap(imageaddress + @"\resources\images\panelekh.jpg");
            closepressed.Image = new Bitmap(imageaddress + @"\resources\images\exitpressed.png");
            close.Image = new Bitmap(imageaddress + @"\resources\images\exit.png");
            pictureBox6.Image = new Bitmap(imageaddress + @"\resources\images\titlebar.jpg");
            pictureBox8.Image = new Bitmap(imageaddress + @"\resources\images\ScribbleArt.jpg");
            pictureBox4.Image = new Bitmap(imageaddress + @"\resources\images\accept.jpg");
            pictureBox3.Image = new Bitmap(imageaddress + @"\resources\images\sendtoafriend.jpg");
            }
            catch (Exception)
            {
                if (MessageBox.Show("Error loading resources,please reinstall the program!", "Resource error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    Application.Exit();
                } 
            }
        }
        public string Version = "8.0";//Software Version.
        public string title = "SilverCorrector";
        public string[] comboBoxItemsOm = { "ادبیات پیش", "ادبیات", "عربی 2", "عربی 3", "دین و زندگی پیش", "دین و زندگی", "زبان پیش", "زبان", };
        public string[] comboBoxItemsEkhRz = { "دیفرانسیل", "حسابان", "ریاضی", "هندسه 1", "هندسه 2", "هندسه تحلیلی", "گسسته", "آمار", "جبر و احتمال", "فیزیک پیش", "فیزیک", "شیمی پیش", "شیمی" };
        public string[] comboBoxItemsEkhTj = { "زمین شناسی", "ریاضی پیش", "ریاضی پایه", "هندسه 1", "زیست پیش", "زیست", "آمار", "فیزیک پیش", "فیزیک", "شیمی پیش", "شیمی" };
        public string[] Om = { "ادبیات پیش", "ادبیات", "عربی 2", "عربی 3", "دین و زندگی پیش", "دین و زندگی", "زبان پیش", "زبان", };
        public string[] EkhRz = { "دیفرانسیل", "حسابان", "ریاضی","هندسه 1", "هندسه 2", "هندسه تحلیلی", "گسسته", "آمار", "جبر و احتمال", "فیزیک پیش", "فیزیک", "شیمی پیش", "شیمی" };
        public string[] EkhTj = { "زمین شناسی", "ریاضی پیش", "ریاضی پایه", "هندسه 1", "زیست پیش", "زیست", "آمار", "فیزیک پیش", "فیزیک", "شیمی پیش", "شیمی" };
        public string[] omfren = {"adabiat pish","adabiat","arabi2","arabi3","dini pish","dini","zaban pish","zaban" };
        public string[] ekhrzfren = {"dif","hesaban","riazi paye","hendese1","hendese2","tahlili","gosaste","amar","jabr","fizik pish","fizik","shimi pish","shimi" };
        public string[] ekhtjfren = {"zamin shenasi","riazi pish","riazi","hendese1","zist pish","zist","amar","fizik pish","fizik","shimi pish","shimi" };
        public string[] smsom = new string[8];
        public string[] smsekhrz = new string[13];
        public string[] smsekhtj = new string[11];
        public float[] OmZ = {4,4,2,2,3,3,2,2 };//OmZ-->zarib
        public float[] EkhRzZ = {4,4,4,4,4,4,4,4,4,3,3,2,2 };//EkhRzZ-->zarib
        public float[] EkhTjZ ={0,2,2,2,4,4,2,2,2,3,3 };//EkhTjZ-->zarib
        public float[] percentOm = {-1,-1,-1,-1,-1,-1,-1,-1};
        public float[] percentEkh = {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1};
        public float sumMakhraj;
        public float sumSoorat;
        public int averageD;
        public float average;
        public string[] data;
        public string[] savefilestr = new string[25];
        public int charcount = 0;
        public int msgcount = 0;

        public void resume()
        {
            string line;
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase.ToString());
            try
            {
                if (!File.Exists(path + @"\resources\data.txt"))
                {
                    File.Create(path + @"\resources\data.txt");
                }
            }
            catch
            {
                MessageBox.Show("Can't create data.txt","Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation,MessageBoxDefaultButton.Button1);
                
            }
            try
            {
                StreamReader sr = new StreamReader(path + @"\resources\data.txt");
                //Pass the file path and file name to the StreamReader constructor

                //Read the first line of text
                line = sr.ReadLine();
                if (line != null)
                {
                    //Continue to read until you reach end of file
                    string reshte = "";
                    if (line == "riazi" || line == "tajrobi")
                    {
                        if (line == "riazi")
                        {
                            cmboxReshte.SelectedIndex = 0;
                        }
                        else if (line == "tajrobi")
                        {
                            cmboxReshte.SelectedIndex = 1;
                        }
                        reshte = line;
                        line = sr.ReadLine();
                        //fill om
                        int i = 0;
                        foreach (float pr in percentOm)
                        {
                            percentOm[i] = float.Parse(line);
                            line = sr.ReadLine();
                            i++;
                        }
                        //fill ekh
                        int j = 0;
                        foreach (float prc in percentEkh)
                        {
                            percentEkh[j] = float.Parse(line);
                            line = sr.ReadLine();
                            j++;
                        }
                    }
                    //close the file
                    sr.Close();

                    //filling textboxes and drawing chart...
                    int c = 0;
                    txtResultsTotal.Text = string.Empty;
                    foreach (float ompercent in percentOm)
                    {
                        if (ompercent.ToString() != "-1")
                        {
                            txtResultsTotal.Text += " " + Om[c] + ": %" + ompercent.ToString() + "\r\n";
                        }
                        c++;
                    }
                    c = 0;
                    if (reshte == "riazi")
                    {
                        title = "SilverCorrector";
                        titlebar.Refresh();
                        foreach (float percent in percentEkh)
                        {
                            if (percent.ToString() != "-1")
                            {
                                txtResultsTotal.Text += " " + EkhRz[c] + " %" + percent.ToString() + "\r\n";
                            }
                            c++;
                        }
                    }
                    else if (reshte == "tajrobi")
                    {
                        title = "SilverCorrector";
                        titlebar.Refresh();
                        foreach (float percent in percentEkh)
                        {
                            if (c < 11)
                            {
                                if (percent.ToString() != "-1")
                                {
                                    txtResultsTotal.Text += " " + EkhTj[c] + " %" + percent.ToString() + "\r\n";
                                }
                            }
                            c++;
                        } 
                        pictureBox5.Refresh();
                        totalResult();
                        pictureBox5.Refresh();
                    }
                }

            }
            catch
            {
                MessageBox.Show("Error reading/writing from/into text-file!\nRunning the program again may fix it!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                
            }
        }

        public void saveFile()
        {
            string savepath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase.ToString());
            try
            {
                if (!File.Exists(savepath + @"\resources\data.txt"))
                {
                    File.Create(savepath + @"\resources\data.txt");
                }
            }
            catch
            {
                MessageBox.Show("Can't create data.txt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                
            }
            try
            {
                StreamWriter srw = new StreamWriter(savepath + @"\resources\data.txt");
                //Pass the file path and file name to the StreamReader constructor

                //saves into the text file
                foreach (string str in savefilestr)
                {
                    srw.WriteLine(str);
                }
                //close the file
                srw.Close();
            }
            catch
            {
                MessageBox.Show("Error accessing data.txt!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                
            }
        }

        private void pictureBox5_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Brush bb = new System.Drawing.SolidBrush(System.Drawing.Color.Blue);//100 %
            Brush b = new System.Drawing.SolidBrush(System.Drawing.Color.Black);//good ones
            Brush r = new System.Drawing.SolidBrush(System.Drawing.Color.Red);//bad ones
            Font f = new System.Drawing.Font("Tahoma", 10, 0);
            Pen p = new Pen(System.Drawing.Color.Red, 2);
            Pen pBlack = new Pen(System.Drawing.Color.Black, 2);
            Rectangle borderRect = new Rectangle(17,5,450,350);
            e.Graphics.DrawRectangle(pBlack, borderRect);
            if (averageD > 0)
            {
                if (average != 100)
                {
                    e.Graphics.DrawLine(p, 461 - averageD, 0, 461 - averageD,450);
                    try
                    {
                        label6.Text = "درصد کل " + (average.ToString()).Substring(0, 4) + " %";
                    }
                    catch (Exception)
                    {
                        label6.Text = "درصد کل " + average.ToString() + " %";
                    }
                }
                else if (average == 100)
                {
                    e.Graphics.DrawLine(p, 455 - averageD, 0, 455 - averageD, 450);
                    label6.Text = "درصد کل " + average.ToString() + " %";  
                }
            }
            else if (averageD <= 0)
            {
                e.Graphics.DrawLine(p, 461, 0, 461, 450);
                label6.Text = "درصد کل " + "0" + " %";
            }
            int i = 0;
            int x = 0;
            int y = 0;
            int percent;
            if (cmboxrshow.SelectedIndex == 0)//omoomi
            {
                foreach (float flt in percentOm)
                {
                    if (percentOm[i] >= 0 && percentOm[i] != 100)
                    {
                        if (percentOm[i] >= 50)
                        {
                            if (percentOm[i] >= average && percentOm[i] !=100)
                            {
                                percent = (int)(percentOm[i] * 4.3);
                                x = 451 - percent;
                                y = (int)(i * 40);
                                Rectangle rect = new Rectangle(x, y + 30, 10, 10);
                                Rectangle recttxt = new Rectangle(x + 10, y + 22, 150, 100);
                                e.Graphics.DrawString(comboBoxItemsOm[i] + " ", new Font("tahoma", 7, 0), b, recttxt);
                                e.Graphics.FillRectangle(b, rect);
                            }
                            else 
                            {
                                percent = (int)(percentOm[i] * 4.3);
                                x = 451 - percent;
                                y = (int)(i * 40);
                                Rectangle rect = new Rectangle(x, y + 30, 10, 10);
                                Rectangle recttxt = new Rectangle(x + 10, y + 22, 150, 100);
                                e.Graphics.DrawString(comboBoxItemsOm[i] + " ", new Font("tahoma", 7, 0), r, recttxt);
                                e.Graphics.FillRectangle(b, rect);
                            }
                        }
                        else if (percentOm[i] < 50)
                        {
                            if (percentOm[i] >= average)
                            {
                                percent = (int)(percentOm[i] * 4.3);
                                x = 451 - percent;
                                y = (int)(i * 40);
                                Rectangle rect = new Rectangle(x, y + 30, 10, 10);
                                Rectangle recttxt = new Rectangle(x - 160, y + 22, 150, 100);
                                StringFormat strFormat = new StringFormat();
                                strFormat.Alignment = StringAlignment.Far;
                                e.Graphics.DrawString(comboBoxItemsOm[i] + " ", new Font("tahoma", 7, 0), b, recttxt, strFormat);
                                e.Graphics.FillRectangle(b, rect);
                            }
                            else 
                            {
                                percent = (int)(percentOm[i] * 4.3);
                                x = 451 - percent;
                                y = (int)(i * 40);
                                Rectangle rect = new Rectangle(x, y + 30, 10, 10);
                                Rectangle recttxt = new Rectangle(x - 160, y + 22, 150, 100);
                                StringFormat strFormat = new StringFormat();
                                strFormat.Alignment = StringAlignment.Far;
                                e.Graphics.DrawString(comboBoxItemsOm[i] + " ", new Font("tahoma", 7, 0), r, recttxt, strFormat);
                                e.Graphics.FillRectangle(b, rect);
                            }
                        }
                    }
                    else if (percentOm[i] == 100)
                    {
                        percent = (int)(percentOm[i] * 4.3);
                        x = 451 - percent;
                        y = (int)(i * 40);
                        Rectangle rect = new Rectangle(x, y + 30, 10, 10);
                        Rectangle recttxt = new Rectangle(x + 10, y + 22, 150, 100);
                        e.Graphics.DrawString(comboBoxItemsOm[i] + " ", new Font("tahoma", 7, 0), bb, recttxt);
                        e.Graphics.FillRectangle(b, rect);
                    }
                    else if (percentOm[i] < 0 && percentOm[i] != -1)
                    {
                        percent = (int)(percentOm[i] * 4.3);
                        x = 461;
                        y = (int)(i * 40);
                        Rectangle rect = new Rectangle(x, y + 30, 10, 10);
                        Rectangle recttxt = new Rectangle(x - 160, y + 22, 150, 100);
                        StringFormat strFormat = new StringFormat();
                        strFormat.Alignment = StringAlignment.Far;
                        e.Graphics.DrawString(comboBoxItemsOm[i], new Font("tahoma", 7, 0), r, recttxt, strFormat);
                        e.Graphics.FillRectangle(b, rect);
                    }
                    i++;
                }
            }
            else if (cmboxrshow.SelectedIndex == 1)//ekhtesasi
            {
                if (cmboxReshte.SelectedIndex == 0)
                {
                    int j = 0;
                    foreach (float flt in percentEkh)
                    {
                        if (percentEkh[j] > 0 && percentEkh[j] != 100)
                        {
                            if (percentEkh[j] < 50)
                            {
                                if (percentEkh[j] >= average && percentEkh[j] !=100)
                                {
                                    percent = (int)(percentEkh[j] * 4.3);
                                    x = 451 - percent;
                                    y = (int)(j * 24.6);
                                    Rectangle rect = new Rectangle(x, y + 30, 10, 10);
                                    Rectangle recttxt = new Rectangle(x - 160, y + 22, 150, 100);
                                    StringFormat strFormat = new StringFormat();
                                    strFormat.Alignment = StringAlignment.Far;
                                    e.Graphics.DrawString(comboBoxItemsEkhRz[j] + " ", new Font("tahoma", 7, 0), b, recttxt, strFormat);
                                    e.Graphics.FillRectangle(b, rect);
                                }
                                else if (percentEkh[j] == 100)
                                {
                                    percent = (int)(percentEkh[j] * 4.3);
                                    x = 451 - percent;
                                    y = (int)(j * 24.6);
                                    Rectangle rect = new Rectangle(x, y + 30, 10, 10);
                                    Rectangle recttxt = new Rectangle(x - 160, y + 22, 150, 100);
                                    StringFormat strFormat = new StringFormat();
                                    strFormat.Alignment = StringAlignment.Far;
                                    e.Graphics.DrawString(comboBoxItemsEkhRz[j] + " ", new Font("tahoma", 7, 0), bb, recttxt, strFormat);
                                    e.Graphics.FillRectangle(b, rect); 
                                }
                                else
                                {
                                    percent = (int)(percentEkh[j] * 4.3);
                                    x = 451 - percent;
                                    y = (int)(j * 24.6);
                                    Rectangle rect = new Rectangle(x, y + 30, 10, 10);
                                    Rectangle recttxt = new Rectangle(x - 160, y + 22, 150, 100);
                                    StringFormat strFormat = new StringFormat();
                                    strFormat.Alignment = StringAlignment.Far;
                                    e.Graphics.DrawString(comboBoxItemsEkhRz[j] + " ", new Font("tahoma", 7, 0), r, recttxt, strFormat);
                                    e.Graphics.FillRectangle(b, rect);
                                }
                            }
                            else if (percentEkh[j] >= 50)
                            {
                                if (percentEkh[j] >= average)
                                {
                                    percent = (int)(percentEkh[j] * 4.3);
                                    x = 451 - percent;
                                    y = (int)(j * 24.6);
                                    Rectangle rect = new Rectangle(x, y + 30, 10, 10);
                                    Rectangle recttxt = new Rectangle(x + 10, y + 22, 150, 100);
                                    e.Graphics.DrawString(comboBoxItemsEkhRz[j] + " ", new Font("tahoma", 7, 0), b, recttxt);
                                    e.Graphics.FillRectangle(b, rect);
                                }
                                else
                                {
                                    percent = (int)(percentEkh[j] * 4.3);
                                    x = 451 - percent;
                                    y = (int)(j * 24.6);
                                    Rectangle rect = new Rectangle(x, y + 30, 10, 10);
                                    Rectangle recttxt = new Rectangle(x + 10, y + 22, 150, 100);
                                    e.Graphics.DrawString(comboBoxItemsEkhRz[j] + " ", new Font("tahoma", 7, 0), r, recttxt);
                                    e.Graphics.FillRectangle(b, rect);
                                }
                            }
                        }
                        else if (percentEkh[j] == 100)
                        {
                            percent = (int)(percentEkh[j] * 4.3);
                            x = 451 - percent;
                            y = (int)(j * 24.6);
                            Rectangle rect = new Rectangle(x, y + 30, 10, 10);
                            Rectangle recttxt = new Rectangle(x + 10, y + 22, 150, 100);
                            e.Graphics.DrawString(comboBoxItemsEkhRz[j] + " ", new Font("tahoma", 7, 0), bb, recttxt);
                            e.Graphics.FillRectangle(b, rect);
                        }
                        else if (percentEkh[j] <= 0 && percentEkh[j] != -1)
                        {
                            percent = (int)(percentEkh[j] * 4.3);
                            x = 461;
                            y = (int)(j * 24.6);
                            Rectangle rect = new Rectangle(x, y + 30, 10, 10);
                            Rectangle recttxt = new Rectangle(x - 160, y + 22, 150, 100);
                            StringFormat strFormat = new StringFormat();
                            strFormat.Alignment = StringAlignment.Far;
                            e.Graphics.DrawString(comboBoxItemsEkhRz[j] + " ", new Font("tahoma", 7, 0), r, recttxt, strFormat);
                            e.Graphics.FillRectangle(b, rect);
                        }
                        j++;
                    }
                }
                else if (cmboxReshte.SelectedIndex == 1)
                {
                    int j = 0;
                    foreach (float flt in percentEkh)
                    {
                        if (percentEkh[j] > 0 && percentEkh[j] != 100)
                        {
                            if (percentEkh[j] < 50)
                            {
                                if (percentEkh[j] >= average)
                                {
                                    percent = (int)(percentEkh[j] * 4.3);
                                    x = 451 - percent;
                                    y = (int)(j * 29);
                                    Rectangle rect = new Rectangle(x, y + 30, 10, 10);
                                    Rectangle recttxt = new Rectangle(x - 160, y + 22, 150, 100);
                                    StringFormat strFormat = new StringFormat();
                                    strFormat.Alignment = StringAlignment.Far;
                                    e.Graphics.DrawString(comboBoxItemsEkhTj[j] + " ", new Font("tahoma", 7, 0), b, recttxt, strFormat);
                                    e.Graphics.FillRectangle(b, rect);
                                }
                                else
                                {
                                    percent = (int)(percentEkh[j] * 4.3);
                                    x = 451 - percent;
                                    y = (int)(j * 29);
                                    Rectangle rect = new Rectangle(x, y + 30, 10, 10);
                                    Rectangle recttxt = new Rectangle(x - 160, y + 22, 150, 100);
                                    StringFormat strFormat = new StringFormat();
                                    strFormat.Alignment = StringAlignment.Far;
                                    e.Graphics.DrawString(comboBoxItemsEkhTj[j] + " ", new Font("tahoma", 7, 0), r, recttxt, strFormat);
                                    e.Graphics.FillRectangle(b, rect);
                                }
                            }
                            else if (percentEkh[j] >= 50)
                            {
                                if (percentEkh[j] >= average)
                                {
                                    percent = (int)(percentEkh[j] * 4.3);
                                    x = 451 - percent;
                                    y = (int)(j * 29);
                                    Rectangle rect = new Rectangle(x, y + 30, 10, 10);
                                    Rectangle recttxt = new Rectangle(x + 10, y + 22, 150, 100);
                                    e.Graphics.DrawString(comboBoxItemsEkhTj[j] + " ", new Font("tahoma", 7, 0), b, recttxt);
                                    e.Graphics.FillRectangle(b, rect);
                                }
                                else
                                {
                                    percent = (int)(percentEkh[j] * 4.3);
                                    x = 451 - percent;
                                    y = (int)(j * 29);
                                    Rectangle rect = new Rectangle(x, y + 30, 10, 10);
                                    Rectangle recttxt = new Rectangle(x + 10, y + 22, 150, 100);
                                    e.Graphics.DrawString(comboBoxItemsEkhTj[j] + " ", new Font("tahoma", 7, 0), r, recttxt);
                                    e.Graphics.FillRectangle(b, rect);
                                }
                            }
                        }
                        else if (percentEkh[j] == 100)
                        {
                            percent = (int)(percentEkh[j] * 4.3);
                            x = 451 - percent;
                            y = (int)(j * 29);
                            Rectangle rect = new Rectangle(x, y + 30, 10, 10);
                            Rectangle recttxt = new Rectangle(x + 10, y + 22, 150, 100);
                            e.Graphics.DrawString(comboBoxItemsEkhTj[j] + " ", new Font("tahoma", 7, 0), bb, recttxt);
                            e.Graphics.FillRectangle(b, rect);
                        }
                        else if (percentEkh[j] <= 0 && percentEkh[j] != -1)
                        {
                        percent = (int)(percentEkh[j] * 4.3);
                        x = 461;
                        y = (int)(j * 29);
                        Rectangle rect = new Rectangle(x, y + 30, 10, 10);
                        Rectangle recttxt = new Rectangle(x - 160, y + 22, 150, 100);
                        StringFormat strFormat = new StringFormat();
                        strFormat.Alignment = StringAlignment.Far;
                        e.Graphics.DrawString(comboBoxItemsEkhTj[j], new Font("tahoma", 7, 0), r, recttxt, strFormat);
                        e.Graphics.FillRectangle(b, rect);
                        }
                        j++;
                    }
                }
            }
        }

        private void btnCalc_Click_1(object sender, EventArgs e)
        {
            inputPanel1.Enabled = false;
            if (tabControl1.SelectedIndex == 4)
            {
                try
                {
                    string percentstobesent = string.Empty;
                    foreach (string str in smsom)
                    {
                        if (str != "empty")
                        {
                            percentstobesent += str + ",";
                        }                       
                    }
                    if (cmboxReshte.SelectedIndex == 0)
                    {
                       foreach (string str in smsekhrz)
                        {
                            if (str != "empty")
                            {
                                percentstobesent += str + ",";
                            }                       
                        } 
                    }
                    else if (cmboxReshte.SelectedIndex == 1)
                    {
                        foreach (string str in smsekhtj)
                        {
                            if (str != "empty")
                            {
                                percentstobesent += str + ",";
                            }                       
                        } 
                    }
                    percentstobesent = percentstobesent.Substring(0, percentstobesent.Length - 1);
                    SmsMessage msg = new SmsMessage();
                    string strno = textBox1.Text;
                    string strtext;
                    if (textBox2.Text != "Text to be sent to your friend...")
                    {
                        strtext = textBox2.Text + "(" + percentstobesent + ")";
                    }
                    else { strtext = "(" + percentstobesent + ")"; }
                    Cursor.Current = Cursors.WaitCursor;
                    if (textBox1.Text != null)
                    {
                        strno = textBox1.Text;
                    }
                    msg.To.Add(new Recipient(strno));
                    msg.RequestDeliveryReport = true; //requests as default
                    msg.Body = strtext.Trim();
                    msg.Send();
                }
                catch (InvalidSmsRecipientException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    
                }
                catch (ServiceCenterException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    
                }
                catch (SmsException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    
                }
                finally { Cursor.Current = Cursors.Default; }
            }
            else if (tabControl1.SelectedIndex == 0)
            {
                float grade;
                try
                {
                    if (cmboxReshte.SelectedItem == null)
                    {
                        if (txtTrue.Text == "0" && txtFalse.Text == "0" && txtNA.Text == "0")
                        {
                            results frm = new results();
                            frm.Controls[0].Text = "درصد شما" + " :" + "0" + " %";//label
                            frm.ShowDialog();
                        }
                        else 
                        {
                            int _true = Int32.Parse(txtTrue.Text);
                            int _false = Int32.Parse(txtFalse.Text);
                            int _na = Int32.Parse(txtNA.Text);
                            float soorat = (_true * 3) - _false;
                            float makhraj = (_true + _false + _na) * 3;
                            grade = (soorat / makhraj) * 100;
                            results frm = new results();
                            frm.Controls[0].Text = "درصد شما" + " :" + grade.ToString() + " %";//label
                            frm.ShowDialog();
                        }
                    }
                    if (txtTrue.Text == "0" && txtFalse.Text == "0" && txtNA.Text == "0")
                    {
                        if (radOm.Checked == true || radEkh.Checked == true)
                        {
                            results frm = new results();
                            if (radOm.Checked == true)
                            {
                                frm.Controls[0].Text = cmbxOm.SelectedValue + " :0 %";//label
                                frm.ShowDialog();
                            }
                            else if (radEkh.Checked == true)
                            {
                                frm.Controls[0].Text = cmbxEkh.SelectedValue + " :0 %";//label
                                frm.ShowDialog();
                            }
                        }
                        if (cmbxOm.Enabled == true)
                        {
                            if (Om[cmbxOm.SelectedIndex].Substring(0, 1) != " ")
                            {
                                Om[cmbxOm.SelectedIndex] = " " + Om[cmbxOm.SelectedIndex] + ": %0";
                                percentOm[cmbxOm.SelectedIndex] = 0;
                            }
                            else
                            {
                                Om[cmbxOm.SelectedIndex] = " " + comboBoxItemsOm[cmbxOm.SelectedIndex] + ": %0";
                                percentOm[cmbxOm.SelectedIndex] = 0;
                            }
                        }
                        else if (cmbxEkh.Enabled == true && cmboxReshte.SelectedIndex == 0)
                        {
                            if (EkhRz[cmbxEkh.SelectedIndex].Substring(0, 1) != " ")
                            {
                                EkhRz[cmbxEkh.SelectedIndex] = " " + EkhRz[cmbxEkh.SelectedIndex] + ": %0";
                                percentEkh[cmbxEkh.SelectedIndex] = 0;
                            }
                            else
                            {
                                EkhRz[cmbxEkh.SelectedIndex] = " " + comboBoxItemsEkhRz[cmbxEkh.SelectedIndex] + ": %0";
                                percentEkh[cmbxEkh.SelectedIndex] = 0;
                            }
                        }
                        else if (cmbxEkh.Enabled == true && cmboxReshte.SelectedIndex == 1)
                        {
                            if (EkhTj[cmbxEkh.SelectedIndex].Substring(0, 1) != " ")
                            {
                                EkhTj[cmbxEkh.SelectedIndex] = " " + EkhTj[cmbxEkh.SelectedIndex] + ": %0";
                                percentEkh[cmbxEkh.SelectedIndex] = 0;
                            }
                            else
                            {
                                EkhTj[cmbxEkh.SelectedIndex] = " " + comboBoxItemsEkhTj[cmbxEkh.SelectedIndex] + ": %0";
                                percentEkh[cmbxEkh.SelectedIndex] = 0;
                            }
                        }
                    }
                    else
                    {
                        int _true = Int32.Parse(txtTrue.Text);
                        int _false = Int32.Parse(txtFalse.Text);
                        int _na = Int32.Parse(txtNA.Text);
                        float soorat = (_true * 3) - _false;
                        float makhraj = (_true + _false + _na) * 3;
                        grade = (soorat / makhraj) * 100;
                        if (radOm.Checked == true || radEkh.Checked == true)
                        {
                            results frm = new results();
                            if (radOm.Checked == true)
                            {
                                frm.Controls[0].Text = cmbxOm.SelectedValue + " :" + grade.ToString() + " %";//label
                                frm.ShowDialog();
                            }
                            if (cmboxReshte.SelectedItem != null)
                            {
                                if (radEkh.Checked == true)
                                {
                                    frm.Controls[0].Text = cmbxEkh.SelectedValue + " :" + grade.ToString() + " %";//label
                                    frm.ShowDialog();
                                }
                            }
                        }
                        if (cmbxOm.Enabled == true)
                        {
                            if (Om[cmbxOm.SelectedIndex].Substring(0, 1) != " ")
                            {
                                Om[cmbxOm.SelectedIndex] = " " + Om[cmbxOm.SelectedIndex] + ": %" + grade.ToString();
                                percentOm[cmbxOm.SelectedIndex] = grade;
                            }
                            else
                            {
                                Om[cmbxOm.SelectedIndex] = " " + comboBoxItemsOm[cmbxOm.SelectedIndex] + ": %" + grade.ToString();
                                percentOm[cmbxOm.SelectedIndex] = grade;
                            }
                        }
                        else if (cmbxEkh.Enabled == true && cmboxReshte.SelectedIndex == 0)
                        {
                            if (EkhRz[cmbxEkh.SelectedIndex].Substring(0, 1) != " ")
                            {
                                EkhRz[cmbxEkh.SelectedIndex] = " " + EkhRz[cmbxEkh.SelectedIndex] + ": %" + grade.ToString();
                                percentEkh[cmbxEkh.SelectedIndex] = grade;
                            }
                            else
                            {
                                EkhRz[cmbxEkh.SelectedIndex] = " " + comboBoxItemsEkhRz[cmbxEkh.SelectedIndex] + ": %" + grade.ToString();
                                percentEkh[cmbxEkh.SelectedIndex] = grade;
                            }
                        }
                        else if (cmbxEkh.Enabled == true && cmboxReshte.SelectedIndex == 1)
                        {
                            if (EkhTj[cmbxEkh.SelectedIndex].Substring(0, 1) != " ")
                            {
                                EkhTj[cmbxEkh.SelectedIndex] = " " + EkhTj[cmbxEkh.SelectedIndex] + ": %" + grade.ToString();
                                percentEkh[cmbxEkh.SelectedIndex] = grade;
                            }
                            else
                            {
                                EkhTj[cmbxEkh.SelectedIndex] = " " + comboBoxItemsEkhTj[cmbxEkh.SelectedIndex] + ": %" + grade.ToString();
                                percentEkh[cmbxEkh.SelectedIndex] = grade;
                            }
                        }
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Invalid input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    
                }
                    txtResultsTotal.Text = "";
                    int counterom = 0;
                    foreach (string strOm in Om)
                    {
                        if (strOm != comboBoxItemsOm[counterom])
                        {
                            txtResultsTotal.Text += strOm + "\r\n";
                        }
                        counterom++;
                    }
                    //txtResultsEkh.Text = "";
                    if (cmboxReshte.SelectedIndex == 0)
                    {
                        int counterekh = 0;
                        foreach (string strEkh in EkhRz)
                        {
                            if (strEkh != comboBoxItemsEkhRz[counterekh])
                            {
                                txtResultsTotal.Text += strEkh + "\r\n";
                            }
                            counterekh++;
                        }
                    }
                    else if (cmboxReshte.SelectedIndex == 1)
                    {
                        int counterekh = 0;
                        foreach (string strEkh in EkhTj)
                        {
                            if (strEkh != comboBoxItemsEkhTj[counterekh])
                            {
                                txtResultsTotal.Text += strEkh + "\r\n";
                            }
                            counterekh++;
                        }
                    }
                totalResult();
                pictureBox5.Refresh();
                if (cmboxReshte.SelectedValue != null)
                {
                    int counter = 0;
                    foreach (float om in percentOm)
                    {
                        data[counter] = om.ToString();
                        counter++;
                    }
                    if (cmboxReshte.SelectedIndex == 0)
                    {
                        data[counter] = "Rz";
                        counter++;
                        foreach (float ekh in percentEkh)
                        {
                            data[counter] = ekh.ToString();
                            counter++;
                        }
                    }
                    else if (cmboxReshte.SelectedIndex == 1)
                    {
                        data[counter] = "Tj";
                        counter++;
                        foreach (float ekh in percentEkh)
                        {
                            data[counter] = ekh.ToString();
                            counter++;
                        }
                    }
                }
                try //sending percents(float) to saveFile()
                {
                    if (cmboxReshte.SelectedIndex == 0)
                    {
                        savefilestr[0] = "riazi";
                    }
                    else if (cmboxReshte.SelectedIndex == 1)
                    {
                        savefilestr[0] = "tajrobi";
                    }
                    int i = 1;
                    foreach (float omflt in percentOm)
                    {
                        savefilestr[i] = omflt.ToString();
                        i++;
                    }
                    if (cmboxReshte.SelectedIndex == 0 || cmboxReshte.SelectedIndex == 1)
                    {
                        foreach (float ekhflt in percentEkh)
                        {
                            savefilestr[i] = ekhflt.ToString();
                            i++;
                        }
                    }
                    saveFile();
                }
                catch
                {
                    MessageBox.Show("Error saving the file!", "error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    
                }
            }
            else if (tabControl1.SelectedIndex != 0 && tabControl1.SelectedIndex != 5)
            {
                tabControl1.SelectedIndex = 0;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                // Up
                if (txtTrue.Focused == true || txtFalse.Focused == true || txtNA.Focused == true)
                {
                    if (radOm.Checked == true && tabControl1.SelectedIndex == 0)
                    {
                        if (cmboxReshte.SelectedItem != null && cmbxOm.SelectedIndex != 0)
                        {
                            cmbxOm.SelectedIndex--;
                        }
                    }
                    if (radEkh.Checked == true && tabControl1.SelectedIndex == 0)
                    {
                        if (cmboxReshte.SelectedItem != null && cmbxEkh.SelectedIndex != 0)
                        {
                            cmbxEkh.SelectedIndex--;
                        }
                        else if (cmboxReshte.SelectedItem != null && cmbxEkh.SelectedIndex == 0)
                        {
                            radOm.Checked = true;
                            cmbxOm.SelectedIndex = cmbxOm.Items.Count - 1;
                        }
                    }
                }
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // Down
                if (txtTrue.Focused == true || txtFalse.Focused == true || txtNA.Focused == true)
                {
                    if (radEkh.Checked == true && tabControl1.SelectedIndex == 0)
                    {
                        if (cmboxReshte.SelectedItem != null && cmbxEkh.SelectedIndex != cmbxEkh.Items.Count - 1)
                        {
                            cmbxEkh.SelectedIndex++;
                        }
                    }
                    if (radOm.Checked == true && tabControl1.SelectedIndex == 0)
                    {
                        if (cmboxReshte.SelectedItem != null && cmbxOm.SelectedIndex != cmbxOm.Items.Count - 1)
                        {
                            cmbxOm.SelectedIndex++;
                        }
                        else if (cmboxReshte.SelectedItem != null && cmbxOm.SelectedIndex == cmbxOm.Items.Count - 1)
                        {
                            radEkh.Checked = true;
                            cmbxEkh.SelectedIndex = 0;
                        }
                    }
                }
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                // Left
                if (txtTrue.Focused == true && txtTrue.SelectionStart == 0)
                {
                    txtNA.Focus();
                    txtNA.SelectionStart = txtNA.Text.Length;
                }
                else if (txtFalse.Focused == true && txtFalse.SelectionStart == 0)
                {
                    txtTrue.Focus();
                    txtTrue.SelectionStart = txtTrue.Text.Length;
                }
                else if (txtNA.Focused == true && txtNA.SelectionStart == 0)
                {
                    txtFalse.Focus();
                    txtFalse.SelectionStart = txtFalse.Text.Length;
                }
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                // Right
                if (txtTrue.Focused == true && txtTrue.SelectionStart == txtTrue.Text.Length)
                {
                    txtFalse.Focus();
                    txtFalse.SelectionStart = 0;
                }
                else if (txtFalse.Focused == true && txtFalse.SelectionStart == txtFalse.Text.Length)
                {
                    txtNA.Focus();
                    txtNA.SelectionStart = 0;
                }
                else if (txtNA.Focused == true && txtNA.SelectionStart == txtNA.Text.Length)
                {
                    txtTrue.Focus();
                    txtTrue.SelectionStart = 0;
                }
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                // Enter
            }

        }
        
        private void radOm_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radOm.Checked == true)
            {
                cmbxOm.DataSource = comboBoxItemsOm;
                radEkh.Checked = false;
                cmbxOm.Enabled = true;
                cmbxEkh.Enabled = false;
                if (title != "SilverCorrector")
                {
                    title = comboBoxItemsOm[cmbxOm.SelectedIndex];
                    titlebar.Refresh();
                }
            }
            txtTrue.Text = "0";
            txtFalse.Text = "0";
            txtNA.Text = "0";    
        }

        private void radEkh_CheckedChanged_1(object sender, EventArgs e)
        {

            if (radEkh.Checked == true)
            {
                if (cmboxReshte.SelectedIndex == 0)
                {
                    cmbxEkh.DataSource = comboBoxItemsEkhRz;
                    if (title != "SilverCorrector")
                    {
                        title = comboBoxItemsEkhRz[cmbxEkh.SelectedIndex];
                        titlebar.Refresh();
                    }
                }
                else if (cmboxReshte.SelectedIndex == 1)
                {
                    cmbxEkh.DataSource = comboBoxItemsEkhTj;
                    if (title != "SilverCorrector")
                    {
                        title = comboBoxItemsEkhTj[cmbxEkh.SelectedIndex];
                        titlebar.Refresh();
                    }
                }
                radOm.Checked = false;
                cmbxOm.Enabled = false;
                cmbxEkh.Enabled = true;
            }
            txtTrue.Text = "0";
            txtFalse.Text = "0";
            txtNA.Text = "0";  
        }

        private void menuItem3_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
        }

        private void menuItem4_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cmboxReshte_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmboxReshte.SelectedIndex == 0)
            {
                cmbxEkh.DataSource = comboBoxItemsEkhRz;
            }
            else if (cmboxReshte.SelectedIndex == 1)
            {
                cmbxEkh.DataSource = comboBoxItemsEkhTj;
            }
            if (radOm.Checked == true)
            {
                title = comboBoxItemsOm[cmbxOm.SelectedIndex];
                titlebar.Refresh();
            }
            else if (radEkh.Capture == true && cmbxEkh.SelectedIndex == 0)
            {
                title = comboBoxItemsEkhRz[cmbxEkh.SelectedIndex];
                titlebar.Refresh();
            }
            else if (radEkh.Capture == true && cmbxEkh.SelectedIndex == 1)
            {
                title = comboBoxItemsEkhTj[cmbxEkh.SelectedIndex];
                titlebar.Refresh();
            }
            //reseting percents when "reshte" is changed
            int i = 0;
            foreach (float flt in percentEkh)
            {
                percentEkh[i] = -1;
                i++;
            }
            txtResultsTotal.Text = string.Empty;
            txtResultsTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            txtTrue.Text = "0";
            txtFalse.Text = "0";
            txtNA.Text = "0";
        }
        public void totalResult() 
        {
            if (cmboxReshte.SelectedIndex == 0 || cmboxReshte.SelectedIndex == 1)
            {
                sumSoorat = 0;
                sumMakhraj = 0;
                int i = 0;//for Om makhraj
                int j = 0;//for EkhRz makhraj
                int k = 0;//for EkhTj makhraj
                int l = 0;//for soorat...got tired a bit u know!(Om)
                int m = 0;//for soorat...got tired a bit u know!(EkhRz)
                int n = 0;//for soorat...got tired a bit u know!(EkhTj)
                //makhraj
                foreach (float fltOm in percentOm)
                {
                    //-1 means null here :D
                    if (percentOm[i] != -1)
                    {
                        sumMakhraj += OmZ[i];
                    }
                    i++;
                }
                if (cmboxReshte.SelectedIndex == 0)
                {
                    foreach (float fltEkh in percentEkh)
                    {
                        //-1 means null here too :o
                        if (percentEkh[j] != -1)
                        {
                            sumMakhraj += EkhRzZ[j] * 3;
                        }
                        j++;
                    }
                }
                else if (cmboxReshte.SelectedIndex == 1)
                {
                    foreach (float fltEkh in percentEkh)
                    {
                        //-1 means null here too :o
                        if (percentEkh[k] != -1)
                        {
                            sumMakhraj += EkhTjZ[k] * 3;
                        }
                        k++;
                    }
                }
                //soorat
                foreach (float flt in percentOm)
                {
                    if (percentOm[l] != -1)
                    {
                        sumSoorat += percentOm[l] * OmZ[l];
                    }
                    l++;
                }
                if (cmboxReshte.SelectedIndex == 0)
                {
                    foreach (float flt in percentEkh)
                    {
                        if (percentEkh[m] != -1)
                        {
                            sumSoorat += percentEkh[m] * EkhRzZ[m] * 3;
                        }
                        m++;
                    }
                }
                else if (cmboxReshte.SelectedIndex == 1)
                {
                    foreach (float flt in percentEkh)
                    {
                        if (percentEkh[n] != -1)
                        {
                            sumSoorat += percentEkh[n] * EkhTjZ[n] * 3;
                        }
                        n++;
                    }
                }
                if (sumMakhraj != 0)
                {
                    average = (sumSoorat / sumMakhraj);
                    //average degree for average line drawing...!
                    averageD = (int)((average)*4.3);//        <------------------averageD
                }
                else
                {
                    //average degree for average line drawing...!
                    average = 0;
                    averageD = 0;
                }
            }
        }
        private void menuItem1_Click(object sender, EventArgs e)
        {
            totalResult();
            inputPanel1.Enabled = false;
            if (cmboxReshte.SelectedItem != null)
            {
                results frm = new results();
                frm.Controls[0].Text = "درصد کل" + " :" + average.ToString() + " %";
                frm.ShowDialog();  
            }
            pictureBox5.Refresh();
        }

        private void cmbxOm_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            title = comboBoxItemsOm[cmbxOm.SelectedIndex];
            titlebar.Refresh();
            txtTrue.Text = "0";
            txtFalse.Text = "0";
            txtNA.Text = "0";            
        }

        private void cmbxEkh_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmboxReshte.SelectedIndex == 0)
            {
                title = comboBoxItemsEkhRz[cmbxEkh.SelectedIndex];
                titlebar.Refresh();
            }
            else if (cmboxReshte.SelectedIndex == 1)
            {
                title = comboBoxItemsEkhTj[cmbxEkh.SelectedIndex];
                titlebar.Refresh();
            }
            txtTrue.Text = "0";
            txtFalse.Text = "0";
            txtNA.Text = "0";
        }

        private void cmboxrshow_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox5.Refresh();
            if (tabControl1.SelectedIndex != 0)
            {
                totalResult();
            }
        }

        private void menuItem5_Click(object sender, EventArgs e)
        {
            resume(); 
        }

        private void menuItem6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;//send to a friend
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int txtcharcount = 0;
            if (textBox2.ForeColor != System.Drawing.Color.Black && textBox2.Text != "Text to be sent to your friend...")
            {
                textBox2.ForeColor = System.Drawing.Color.Black;
            }
            if (textBox2.Text != "Text to be sent to your friend...")
            {
                txtcharcount = textBox2.Text.Length;
                msgcount = ((charcount + txtcharcount) / 160) + 1;
                lblchar.Text = "char: " + (charcount + txtcharcount).ToString() + "\n" + "msg: " + msgcount.ToString();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            charcount = 0;
            try
            {
                if (tabControl1.SelectedIndex == 4)
                {
                    btnCalc.Text = "Send";
                    title = "SendToAFriend";
                    titlebar.Refresh();
                    int i = 0;
                    foreach (float flt in percentOm)
                    {
                        if (flt.ToString() != "-1")
                        {
                            if (flt.ToString().Length >= 5)
                            {
                                smsom[i] = omfren[i] + ":" + flt.ToString().Substring(0, 5);
                            }
                            else { smsom[i] = omfren[i] + ":" + flt.ToString(); } 
                        }
                        else { smsom[i] = "empty"; }
                        i++;
                    }
                    i = 0;
                    if (cmboxReshte.SelectedIndex == 0)
                    {
                        foreach (float flt in percentEkh)
                        {
                            if (flt.ToString() != "-1")
                            {
                                if (flt.ToString().Length >= 5)
                                {
                                    smsekhrz[i] = ekhrzfren[i] + ":" + flt.ToString().Substring(0, 5);
                                }
                                else { smsekhrz[i] = ekhrzfren[i] + ":" + flt.ToString(); }
                            }
                            else { smsekhrz[i] = "empty"; }
                            i++;
                        }
                    }
                    else if (cmboxReshte.SelectedIndex == 1)
                    {
                        foreach (float flt in percentEkh)
                        {
                            if(i < 11)//array length!
                            {
                            if (flt.ToString() != "-1")
                            {
                                if (flt.ToString().Length >= 5)
                                {
                                    smsekhtj[i] = ekhtjfren[i] + ":" + flt.ToString().Substring(0, 5);
                                }
                                else { smsekhtj[i] = ekhtjfren[i] + ":" + flt.ToString(); }
                            }
                            else { smsekhtj[i] = "empty"; }
                            }
                            i++;
                        }
                    }
                    foreach (string str in smsom)
                    {
                        if (str != "empty")
                        {
                            charcount += str.Length;
                        }
                    }
                    if (cmboxReshte.SelectedIndex == 0)
                    {
                        foreach (string str in smsekhrz)
                        {
                            if (str != "empty")
                            {
                                charcount += str.Length; 
                            }
                        }
                    }
                    else if (cmboxReshte.SelectedIndex == 1)
                    {
                        foreach (string str in smsekhtj)
                        {
                            if (str != "empty")
                            {
                                charcount += str.Length;
                            }
                        }
                    }
                    charcount += 2;//parentheses
                    msgcount = (charcount / 160) + 1;
                    lblchar.Text = "char: " + charcount.ToString() + "\n" + "msg: " + msgcount.ToString();
                }
                else if(tabControl1.SelectedIndex == 0)
                {
                    btnCalc.Text = "Calculate!";
                    title = "SilverCorrector";
                    titlebar.Refresh();
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    btnCalc.Text = "back";
                    title = "درصد ها";
                    titlebar.Refresh();
                }
                else if (tabControl1.SelectedIndex == 2)
                {
                    btnCalc.Text = "back";
                    title= "کل";
                    titlebar.Refresh();
                }
                else if (tabControl1.SelectedIndex == 3)
                {
                    btnCalc.Text = "back";
                    title = "About";
                    titlebar.Refresh();
                }
            }
            catch
            {
                tabControl1.SelectedIndex = 0;
                MessageBox.Show("Enter your percents first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                
            }
        }

        private void textBox2_GotFocus(object sender, EventArgs e)
        {
            if (textBox2.Text == "Text to be sent to your friend...")
            {
                textBox2.Text = string.Empty;
            }
            TextBox tb = sender as TextBox;
            Timer timer = new Timer();

            timer.Interval = 100;
            timer.Enabled = true;
            timer.Tick += (EventHandler)delegate(object obj, EventArgs args)
            {
                tb.SelectAll();
                timer.Dispose();
            };
            inputPanel1.Enabled = true;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.ForeColor != System.Drawing.Color.Black && textBox1.Text != "09.........")
            {
                textBox1.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void textBox1_GotFocus(object sender, EventArgs e)
        {
            if (textBox1.Text == "09.........")
            {
                textBox1.Text = string.Empty;
            }
            TextBox tb = sender as TextBox;
            Timer timer = new Timer();

            timer.Interval = 100;
            timer.Enabled = true;
            timer.Tick += (EventHandler)delegate(object obj, EventArgs args)
            {
                tb.SelectAll();
                timer.Dispose();
            };
            inputPanel1.Enabled = true;
        }

        private void txtTrue_GotFocus(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            Timer timer = new Timer();

            timer.Interval = 100;
            timer.Enabled = true;
            timer.Tick += (EventHandler)delegate(object obj, EventArgs args)
            {
                tb.SelectAll();
                timer.Dispose();
            };
            inputPanel1.Enabled = true;
        }

        private void txtFalse_GotFocus(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            Timer timer = new Timer();

            timer.Interval = 100;
            timer.Enabled = true;
            timer.Tick += (EventHandler)delegate(object obj, EventArgs args)
            {
                tb.SelectAll();
                timer.Dispose();
            };
            inputPanel1.Enabled = true;
        }

        private void txtNA_GotFocus(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            Timer timer = new Timer();

            timer.Interval = 100;
            timer.Enabled = true;
            timer.Tick += (EventHandler)delegate(object obj, EventArgs args)
            {
                tb.SelectAll();
                timer.Dispose();
            };
            inputPanel1.Enabled = true;
        }
        private void panelekh_Click(object sender, EventArgs e)
        {
            if (cmboxReshte.SelectedItem != null)
            {
                radEkh.Checked = true; 
            }  
        }

        private void panelomoomi_Click(object sender, EventArgs e)
        {
            radOm.Checked = true;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void titlebar_Paint(object sender, PaintEventArgs e)
        {
            Brush b = new System.Drawing.SolidBrush(Color.White);
            Font f = new System.Drawing.Font("Tahoma",9,FontStyle.Regular);
            Rectangle rec = new Rectangle(100, 15, 400, 40);
            if (title == "SilverCorrector")
            {
                e.Graphics.DrawString(title + " " + Version, f, b, rec);
            }
            else
            {
                e.Graphics.DrawString(title, f, b, rec);
            } 
        }

        private void close_MouseDown(object sender, MouseEventArgs e)
        {
            close.Visible = false;
            closepressed.Visible = true;
        }

        private void close_MouseUp(object sender, MouseEventArgs e)
        {
            close.Visible = true;
            closepressed.Visible = false;
        }

        private void pictureBox7_Paint(object sender, PaintEventArgs e)
        {
            string s = "رشته";
            Font f = new System.Drawing.Font("tahoma",9,FontStyle.Regular);
            Brush b = new System.Drawing.SolidBrush(Color.Black);
            Rectangle reshte = new Rectangle(320, 395, 69, 40);
            e.Graphics.DrawString(s, f, b, reshte);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            radOm.Checked = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (cmboxReshte.SelectedIndex == 0 || cmboxReshte.SelectedIndex == 1)
            {
                radEkh.Checked = true;  
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            string s = "عمومی";
            Font f = new System.Drawing.Font("tahoma", 9, FontStyle.Regular);
            Brush b = new System.Drawing.SolidBrush(Color.Black);
            Rectangle reshte = new Rectangle(30, 0, 138, 43);
            e.Graphics.DrawString(s, f, b, reshte);
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            string s = "اختصاصی";
            Font f = new System.Drawing.Font("tahoma", 9, FontStyle.Regular);
            Brush b = new System.Drawing.SolidBrush(Color.Black);
            Rectangle reshte = new Rectangle(10, 0, 138, 43);
            e.Graphics.DrawString(s, f, b, reshte);
        }

        private void textBox2_LostFocus(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.ForeColor = Color.DarkGray;
                textBox2.Text = "Text to be sent to your friend...";
            }
        }

        private void textBox1_LostFocus(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.ForeColor = Color.DarkGray;
                textBox1.Text = "09.........";
            }
        }

        private void txtResultsOm_TextChanged(object sender, EventArgs e)
        {
            txtResultsTotal.Visible = true;
            pictureBox8.Visible = false;
        }
    }

}