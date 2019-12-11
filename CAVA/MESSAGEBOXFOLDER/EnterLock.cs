using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CAVA.MESSAGEBOXFOLDER
{
    public partial class EnterLock : Form
    {
        public EnterLock()
        {
            InitializeComponent();
        }
        int i = 0;
        int lang;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
                pictureBox2.Visible = true;
            else
                pictureBox2.Visible = false;
            InputLanguage myCurrentLanguage = InputLanguage.CurrentInputLanguage;
            label6.Text = myCurrentLanguage.LayoutName;
            if (i == 0)
            {
                if (textBox1.Text == Properties.Settings.Default.lps)
                {
                    Properties.Settings.Default.loc = 0;
                    Properties.Settings.Default.Save();
                    this.Close();
                }
            }
            else
            {
                if (i == 1)
                {
                    if (textBox1.Text == Properties.Settings.Default.lps)
                    {
                        label1.Text = "Введите НОВЫЙ пароль";

                        button1.Text = "Подтвердить";
                        button1.Visible = true;
                        i = 2;
                    }
                }
            }
        }

        private void EnterLock_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form il = Application.OpenForms["EnterSettings"];
            il.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (i==0)
            {
                i = 1;
                label1.Text = "Введите текущий пароль";
                button1.Visible = false;
            }
            if (i == 2)
            {
                if (textBox1.Text.Length == 0)
                {
                    DialogResult r1 = MessageBox.Show("Строка пароля пустая. Установить пароль по-умолчанию?", "CAVA", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                    if (r1 == DialogResult.Yes)
                    {
                        Properties.Settings.Default.lps = "CAVA";
                        Properties.Settings.Default.Save();
                        this.Close();
                    }
                }
                else
                {
                    DialogResult r = MessageBox.Show("Сохранить изменения ?", "CAVA", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                    if (r == DialogResult.Yes)
                    {
                        Properties.Settings.Default.lps = textBox1.Text;
                        Properties.Settings.Default.Save();
                        this.Close();
                    }
                }                
            }
        }

        private void EnterLock_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.lps=="")
            {
                Properties.Settings.Default.lps = "CAVA";
                Properties.Settings.Default.Save();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            if (lang == 0)
            {
                lang++;
                InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("ru-RU"));
            }
            else
            {
                lang--;
                InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("en-US"));
            }
        }
    }
}
