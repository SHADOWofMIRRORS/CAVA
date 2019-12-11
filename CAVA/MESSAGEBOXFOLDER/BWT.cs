using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CAVA.MESSAGEBOXFOLDER
{
    public partial class BWT : MetroForm
    {
        public BWT()
        {
            InitializeComponent();
        }
        int pr;
        public string SavePath;
        public string sx;
        public int ro;
        public string accd;
        public string accdesc;
        public string s;
        public string name;
        int x,ex;
        int pcb;
        public int zagruzkasteacher;
        int ErrorLoading;

        private void BWT_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                File.Copy(@"" + accd, SavePath, true);
                //_________________
                Properties.Settings.Default.Desc = accdesc;
                Properties.Settings.Default.path = SavePath;
                Properties.Settings.Default.r3 = ro;
                Properties.Settings.Default.name = name;
                int i = Convert.ToInt32(s);
                Properties.Settings.Default.tim = i;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Desc = accdesc;
                Properties.Settings.Default.Save();
                notifyIcon1.Visible = true;
                if (Properties.Settings.Default.LANG == "BE")
                {
                    notifyIcon1.BalloonTipText = "Пачакайце, ідзе загрузка задання.";
                }
                else
                {
                    if (Properties.Settings.Default.LANG == "RU")
                    {
                        notifyIcon1.BalloonTipText = "Подождите, идёт загрузка задания.";
                    }
                }
                notifyIcon1.ShowBalloonTip(100);
            }
            catch(Exception ex)
            {
                ErrorLoading = 1;
                backgroundWorker1.CancelAsync();
                Properties.Settings.Default.al = 0;
                Properties.Settings.Default.y = 0;
                Properties.Settings.Default.Save();
                MessageBox.Show(ex.Message, "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Form il = Application.OpenForms["Task"];
                il.Enabled = true;
                this.Close();

            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

                if (ex == 0)
                {
                    if (e.Error != null)
                    {
                        try
                        {
                            backgroundWorker1.CancelAsync();
                            Form il = Application.OpenForms["Task"];
                            timer2.Stop();
                            timer1.Stop();
                            metroProgressBar1.Visible = false;
                            if (Properties.Settings.Default.LANG == "BE")
                            {
                                MessageBox.Show("Памылка пры загрузцы задання: " + e.Error.Message, "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                if (Properties.Settings.Default.LANG == "RU")
                                {
                                    MessageBox.Show("Ошибка при загрузке задания: " + e.Error.Message, "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            timer3.Enabled = false;
                            il.Enabled = true;
                            Properties.Settings.Default.al = 0;
                            Properties.Settings.Default.y = 0;
                            Properties.Settings.Default.Save();
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                        }

                    }
                    else
                    {
                        if (ErrorLoading == 0)
                        {
                            timer2.Enabled = false;
                            timer1.Enabled = false;
                            metroProgressBar1.Visible = false;
                            if (Properties.Settings.Default.LANG == "BE")
                            {
                                MessageBox.Show("Заданне ўстаноўлена. Можна прыступаць да працы.\nвыніковы час чакання: " + pr + " сек.", "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                            else
                            {
                                if (Properties.Settings.Default.LANG == "RU")
                                {
                                    MessageBox.Show("Задание установлено. Можно приступать к работе.\nВремя ожидания составило: " + pr + " сек.", "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                }
                            }
                            backgroundWorker1.CancelAsync();
                            timer3.Enabled = false;
                            Properties.Settings.Default.Desc = accdesc;
                            Properties.Settings.Default.path = SavePath;
                            Properties.Settings.Default.r3 = ro;
                            Properties.Settings.Default.name = name;
                            int i = Convert.ToInt32(s);
                            Properties.Settings.Default.tim = i;
                            Properties.Settings.Default.Save();
                            Properties.Settings.Default.Desc = accdesc;
                            Properties.Settings.Default.Save();




                            Properties.Settings.Default.al = 1;
                            Properties.Settings.Default.y = 1;
                            Properties.Settings.Default.Save();
                            if (zagruzkasteacher == 0)
                            {
                                Form il = Application.OpenForms["Task"];
                                il.Enabled = true;
                                il.Close();
                            }
                            this.Close();
                        }
                    }
                }
                else
                {

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"CAVA",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult r = MessageBox.Show("Остановить загрузку задания ?", "CAVA", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (r == DialogResult.Yes)
                {
                    ex = 1;
                    backgroundWorker1.CancelAsync();
                    this.Close();
                }
            }
            catch(Exception ex)
            {

            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (x == 0)
            {
                label1.Text = "Processing.";
                x++;
            }
            else
            {
                if (x == 1)
                {
                    label1.Text = "Processing..";
                    x++;
                }
                else
                {
                    if (x == 2)
                    {
                        label1.Text = "Processing...";
                        x++;
                    }
                    else
                    {
                        if (x == 3)
                        {
                            label1.Text = "Processing";
                            x = 0;
                        }
                    }
                }
            }
            
            
            

            
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void BWT_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (pcb == 0)
                {
                pcb++;
                pictureBox1.Image = Properties.Resources.A1;
                }
            else
            {
                if (pcb == 1)
                {
                    pcb++;
                    pictureBox1.Image = Properties.Resources.A2;
                }
                else
                {
                    if (pcb == 2)
                    {
                        pcb++;
                        pictureBox1.Image = Properties.Resources.A3;
                    }
                    else
                    {
                        if (pcb == 3)
                        {
                            pcb++;
                            pictureBox1.Image = Properties.Resources.A4;
                        }
                        else
                        {
                            if (pcb == 4)
                            {
                                pcb++;
                                pictureBox1.Image = Properties.Resources.A5;
                            }
                            else
                            {
                                if (pcb == 5)
                                {
                                    pcb = 0;
                                    pictureBox1.Image = Properties.Resources.CavaPNG;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            pr++;
            label3.Text = pr.ToString() + " сек.";
        }
    }
}
