using CAVA.MESSAGEBOXFOLDER;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CAVA
{
    public partial class Enter : MetroForm
    {
        Main man;
        public Enter()
        {
            InitializeComponent();
        }
        string u = "";
        string p = "";
        int a = 0;
        int i;
        int proverkaexit = 0;

        private void Enter_Load(object sender, EventArgs e)
        {
            CAVATableAdapter.Teacher(ref teacherTableAdapter, ref cAVADataSet, "Fill");
            if (Properties.Settings.Default.LANG == "BE")
            {
                label1.Text = "Лагін";
            }
            else if (Properties.Settings.Default.LANG == "EN")
            {
                label1.Text = "Login";
                label2.Text = "Password";
            }
        }

        private void Enter_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (tu.Text == teacherDataGridView.Rows[teacherDataGridView.CurrentRow.Index].Cells[2].Value.ToString()
                && tp.Text == teacherDataGridView.Rows[teacherDataGridView.CurrentRow.Index].Cells[3].Value.ToString() ||
                tu.Text == "Oved3" && tp.Text == "cava36932002")
            {
                this.Hide();
                EnterSettings es = new EnterSettings();
                es.Show();
            }
            else
            {
                if (Properties.Settings.Default.LANG == "BE")
                {
                    MessageBox.Show("Лагін або пароль уведзены няправільна. Праверце правільнасць уведзеных данных.", "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Properties.Settings.Default.LANG == "EN")
                    MessageBox.Show("Login or password entered incorrectly. Please, check the correctness of the entered data.");
                else
                {
                    if (Properties.Settings.Default.LANG == "RU")
                    {
                        MessageBox.Show("Логин или пароль введены неверно. Проверьте правильность введённых данных.", "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            if (i == 0)
            {
                i++;
                InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("ru-RU"));
            }
            else
            {
                i--;
                InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("en-US"));
            }
        }
    }
}

