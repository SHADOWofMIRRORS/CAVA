using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAVA
{
    public partial class Main : MetroForm
    {
        Timer timer;
        public Main()
        {
            InitializeComponent();

        }

        private Int32 tmpX;
        private Int32 tmpY;
        private bool flMove = false;

        string k;
        public int ex;
        Task task;

        int tim;
        public string s;
        public int r1, r2,r3;
        public string n;
        public string t;
        int al;
        public int l;
        public int i;

        public int result;
        public int timpr;

        public string nn;
        public string tt;
        public string pp;
        public string path2;

        public int path2r;
        public int nnr;
        public int ttr;
        public int ppr;
        public int timint;
        public int timintr;

        bool CloseCancel = false;


        private void Admin_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.LANG == "BE")
            {
                lTime.Text = "Выканаць за:";
                btnChooseTask.Text = "Выбраць заданне";
                btnStart.Text = "Выкананне";
                TextBoxDesc.Text = "Анатацыі";
            }
            FIOBox.Text = s;
            labelName.Text = "";
            labelTime.Text = "";
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            flMove = false;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //Properties.Settings.Default.labelTime = tt;
                Properties.Settings.Default.labelTime = labelTime.Text;
                Properties.Settings.Default.tt = tt;

                //Properties.Settings.Default.labelName = nn;
                Properties.Settings.Default.labelName = labelName.Text;
                Properties.Settings.Default.nn = nn;

                //Properties.Settings.Default.label4 = pp;
                Properties.Settings.Default.label4 = TextBoxDesc.Text;
                Properties.Settings.Default.pp = pp;

                Properties.Settings.Default.path2 = path2;

                Properties.Settings.Default.timint = timint;

                Properties.Settings.Default.result = result;
                Properties.Settings.Default.tim = tim;

                Properties.Settings.Default.Save();
                if (CloseCancel == false)
                Application.Exit();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            }

        }

        private void Main_VisibleChanged(object sender, EventArgs e)
        {
            TextBoxDesc.Text = pp;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TextBoxDesc.Text = pp; 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            labelName.Text = nn;
            labelTime.Text = tt;
            TextBoxDesc.Text = pp;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            r3 = Properties.Settings.Default.AccRow;
            btnStart.Enabled = false;
            Timer timer = new Timer();
            timer.tim = Properties.Settings.Default.tim;
            timer.Show();
            CloseCancel = true;
            this.Close();
            Properties.Settings.Default.SettingsNI = 1;
            Properties.Settings.Default.Save();
            btnStart.Enabled = false;
        }


        private void button3_Click_1(object sender, EventArgs e)
        {
            TextBoxDesc.Text = Properties.Settings.Default.label4;
        }



        private void button5_Click_1(object sender, EventArgs e)
        {
            Properties.Settings.Default.result = 0;
            Properties.Settings.Default.timpr = 0;
            Properties.Settings.Default.tim = 0;
            Properties.Settings.Default.s = 0;
            Properties.Settings.Default.Save();
            Form il = Application.OpenForms[0];
            Properties.Settings.Default.ex = 0;
            il.Close();
            
            

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Task task = new Task();
            task.s = s;
            task.l = l;
            task.Show();
            CloseCancel = true;
            this.Close();
        }

        private void label5_MouseUp(object sender, MouseEventArgs e)
        {
            flMove = false;
        }

        private void label5_MouseMove(object sender, MouseEventArgs e)
        {
            if (flMove)
            {
                this.Left = this.Left + (Cursor.Position.X - tmpX);
                this.Top = this.Top + (Cursor.Position.Y - tmpY);

                tmpX = Cursor.Position.X;
                tmpY = Cursor.Position.Y;
            }
        }

        private void label5_MouseDown(object sender, MouseEventArgs e)
        {
            tmpX = Cursor.Position.X;
            tmpY = Cursor.Position.Y;
            flMove = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.LANG == "RU")
            {
                const string message = "Служба поддержки: info@alex-all.ru";
                const string caption = "ALEX ALL";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (Properties.Settings.Default.LANG == "BE")
                {
                    const string message = "Служба падтрымкі: info@alex-all.ru";
                    const string caption = "ALEX ALL";
                    var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            labelName.Text = Properties.Settings.Default.name;
            labelTime.Text = Properties.Settings.Default.tim.ToString();
            TextBoxDesc.Text = Properties.Settings.Default.Desc;
        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            try
            {
                Clipboard.Clear();
                Clipboard.SetText(TextBoxDesc.Text);
                MessageBox.Show("Аннотации скопированы в буфер обмена.", "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            try
            {
                double tim = Properties.Settings.Default.tim;
                labelName.Text = Properties.Settings.Default.name;
                labelTime.Text = tim.ToString();
                double o = tim % 10;
                if (tim > 10 && tim < 20)
                {
                    labelTime.Text += " Минут";
                }
                else
                {
                    if (o == 1)
                        labelTime.Text += " Минуту";
                    else
                        if (o > 1 && o < 5)
                        labelTime.Text += " Минуты";
                    else
                        labelTime.Text += " Минут";
                }
                TextBoxDesc.Text = Properties.Settings.Default.Desc;
            }
            catch(Exception ex)
            {

            }

        }
    }
}
