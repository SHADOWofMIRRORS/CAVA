using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Data.SqlClient;
using MetroFramework.Forms;
using System.Runtime.InteropServices;

namespace CAVA
{
    public partial class PupilReg : MetroForm
    {
        public PupilReg()
        {
            InitializeComponent();
        }
        int i = 0;
        string IP,HOST;
        string im, fam, kl, pas;
        int l,ci,m;
        int re = 30;
        int lang;

        bool Animation = false;

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowThreadProcessId(
            [In] IntPtr hWnd,
            [Out, Optional] IntPtr lpdwProcessId
            );

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        static extern ushort GetKeyboardLayout(
            [In] int idThread
            );

        /// <summary>
        /// Вернёт Id раскладки.
        /// </summary>
        ushort GetKeyboardLayout()
        {
            return GetKeyboardLayout(GetWindowThreadProcessId(GetForegroundWindow(), IntPtr.Zero));
        }

        private void PupilReg_Load_2(object sender, EventArgs e)
        {
            try
            {
                // TODO: данная строка кода позволяет загрузить данные в таблицу "cAVADataSet.Update". При необходимости она может быть перемещена или удалена.
                CAVATableAdapter.Update(ref this.updateTableAdapter, ref this.cAVADataSet, "Fill");
                // TODO: данная строка кода позволяет загрузить данные в таблицу "cAVADataSet.Pupil". При необходимости она может быть перемещена или удалена.
                CAVATableAdapter.Pupil(ref this.pupilTableAdapter, ref this.cAVADataSet, "Fill");
                // TODO: данная строка кода позволяет загрузить данные в таблицу "cAVADataSet.Clas". При необходимости она может быть перемещена или удалена.
                CAVATableAdapter.Clas(ref this.clasTableAdapter1, ref this.cAVADataSet, "Fill");
                // TODO: данная строка кода позволяет загрузить данные в таблицу "cAVADataSet.Sub". При необходимости она может быть перемещена или удалена.
                CAVATableAdapter.Sub(ref this.subTableAdapter, ref this.cAVADataSet, "Fill");
                // TODO: данная строка кода позволяет загрузить данные в таблицу "cAVADataSet.Teacher". При необходимости она может быть перемещена или удалена.
                CAVATableAdapter.Teacher(ref this.teacherTableAdapter, ref this.cAVADataSet, "Fill");
            }
            catch(Exception ex)
            {

            }
            try
            {
                // TODO: данная строка кода позволяет загрузить данные в таблицу "cAVADataSet.Update". При необходимости она может быть перемещена или удалена.
                CAVATableAdapter.Update(ref this.updateTableAdapter, ref this.cAVADataSet, "Fill");
                // TODO: данная строка кода позволяет загрузить данные в таблицу "cAVADataSet.Pupil". При необходимости она может быть перемещена или удалена.
                CAVATableAdapter.Pupil(ref this.pupilTableAdapter, ref this.cAVADataSet, "Fill");
                // TODO: данная строка кода позволяет загрузить данные в таблицу "cAVADataSet.Clas". При необходимости она может быть перемещена или удалена.
                CAVATableAdapter.Clas(ref this.clasTableAdapter1, ref this.cAVADataSet, "Fill");
                // TODO: данная строка кода позволяет загрузить данные в таблицу "cAVADataSet.Sub". При необходимости она может быть перемещена или удалена.
                CAVATableAdapter.Sub(ref this.subTableAdapter, ref this.cAVADataSet, "Fill");
                // TODO: данная строка кода позволяет загрузить данные в таблицу "cAVADataSet.Teacher". При необходимости она может быть перемещена или удалена.
                CAVATableAdapter.Teacher(ref this.teacherTableAdapter, ref this.cAVADataSet, "Fill");
            }
            catch (Exception ex)
            {

            }
            if (Properties.Settings.Default.LANG == "BE")
            {
                Text = "1. Ваш выкладчык";
                Sub.Text = "2. Вучэбная дысцыпліна";
                Clas.Text = "3. Ваша група, Клас";
                NameFamily.Text = "4. Імя";
                Pass.Text = "6. Калі ласка, увядзіце пароль:";
                SecondPass.Text = "7. Паўтарыце пароль:";
                btnRegister.Text = "Рэгістрацыя";
            }
            Animation = true;
        }

        private void btnLanguage_Click(object sender, EventArgs e)
        {
            if (l == 0)
            {
                l++;
                InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("ru-RU"));
            }
            else
            {
                l--;
                InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("en-US"));
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                CAVATableAdapter.Teacher(ref this.teacherTableAdapter, ref this.cAVADataSet, "Fill");
                if (updateDataGridView.Rows[0].Cells[3].Value.ToString() == "True")
                {
                    if (tbPassword.Text == tbSecPassword.Text &&
    comboBoxClas.Text.Length > 0 &&
    comboBoxTeacher.Text.Length > 0 &&
    comboBoxSub.Text.Length > 0 &&
    tbName.Text.Length > 0 &&
    tbPassword.Text.Length > 5)
                    {
                        // Получение имени компьютера.
                        string host = System.Net.Dns.GetHostName();
                        // Получение ip-адреса.
                        System.Net.IPAddress ip = System.Net.Dns.GetHostByName(host).AddressList[0];
                        // IP
                        string IP = ip.ToString();
                        string cm = clasDataGridView.CurrentCell.Value.ToString();
                        int c = Convert.ToInt32(cm);
                        string name = "" + tbName.Text;
                        int ro = clasDataGridView.CurrentRow.Index;
                        int rowc = clasDataGridView.RowCount;
                        if (clasDataGridView.RowCount == rowc)
                        {

                            clasDataGridView.CurrentCell = clasDataGridView[0, ro];
                            string pv = subDataGridView.Rows[subDataGridView.CurrentRow.Index].Cells[3].Value.ToString() + @"\" + name;
                            pupilTableAdapter.Insert(name, tbPassword.Text, IP, c, 1, pv);
                            pupilDataGridView.EndEdit();
                            CAVATableAdapter.Pupil(ref pupilTableAdapter, ref cAVADataSet, "Update");
                            CAVATableAdapter.Pupil(ref pupilTableAdapter, ref cAVADataSet, "Fill");

                            if (Properties.Settings.Default.LANG == "BE")
                            {
                                MessageBox.Show("Паспяховая рэгістрацыя", "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                            else
                            {
                                if (Properties.Settings.Default.LANG == "RU")
                                {
                                    MessageBox.Show("Успешная регистрация", "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                }
                            }
                            if (Properties.Settings.Default.LANG == "BE")
                            {
                                MessageBox.Show("Рэгістрацыйныя дадзеныя:" +
                                    " \nВыкладчык: " + comboBoxTeacher.Text +
                                    " \nВучэбная дысцыпліна, прадмет: " + comboBoxSub.Text +
                                    "\nГрупа, Клас: " + clasDataGridView.Rows[clasDataGridView.CurrentRow.Index].Cells[1].Value.ToString() +
                                    " \nІмя: " + tbName.Text +
                                    "\nПароль: " + tbPassword.Text +
                                    "", "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                            else
                            {
                                if (Properties.Settings.Default.LANG == "RU")
                                {
                                    MessageBox.Show("Регистрационные данные:" +
                                        " \nПреподаватель: " + comboBoxTeacher.Text +
                                        " \nУчебная дисциплина, предмет: " + comboBoxSub.Text +
                                        "\nГруппа, Класс: " + clasDataGridView.Rows[clasDataGridView.CurrentRow.Index].Cells[1].Value.ToString() +
                                        " \nИмя: " + tbName.Text +
                                        "\nПароль: " + tbPassword.Text +
                                        "", "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                }
                            }

                            this.Close();
                        }
                        else
                        {
                            if (Properties.Settings.Default.LANG == "BE")
                            {
                                MessageBox.Show("Абранага класа не існуе", "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                            else
                            {
                                if (Properties.Settings.Default.LANG == "RU")
                                {
                                    MessageBox.Show("Выбранного класса не существует", "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                }
                            }
                        }
                    }
                    else
                    {
                        tbPassword.Text = tbSecPassword.Text = "";
                        if (Properties.Settings.Default.LANG == "BE")
                        {
                            MessageBox.Show(
                           "Усе палі павінны быць запоўненыя дакладна. Даўжыня пароля павінна быць больш за 5-ць сімвалаў.",
                           "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (Properties.Settings.Default.LANG == "RU")
                            {
                                MessageBox.Show(
                               "Все поля должны быть заполнены верно. Длина пароля должна быть больше 5-ти символов",
                               "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                    }
                }
                else
                {
                    if (Properties.Settings.Default.LANG == "BE")
                    {
                        MessageBox.Show("Магчымасць рэгістрацыі адключана", "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (Properties.Settings.Default.LANG == "RU")
                        {
                            MessageBox.Show("Возможность регистрации выключена", "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void tbSecPassword_TextChanged(object sender, EventArgs e)
        {
            if (tbPassword.Text == tbSecPassword.Text)
                btnRegister.Enabled = true;
        }

        private void comboBoxTeacher_Click(object sender, EventArgs e)
        {
            Animate(Sub);
        }

        private void comboBoxSub_Click(object sender, EventArgs e)
        {
            Animate(Clas);
        }

        private void comboBoxClas_Click(object sender, EventArgs e)
        {
            Animate(NameFamily);
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            Animate(Pass);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            uint L = GetKeyboardLayout();
            if (L == 1033)
                btnLanguage.Text = "EN";
            else if (L == 1049)
                btnLanguage.Text = "RU";
            else if (L == 1033)
                btnLanguage.Text = "EN";
            else if (L == 3079)
                btnLanguage.Text = "DE";
            else if (L == 1031)
                btnLanguage.Text = "DE";
            else if (L == 5127)
                btnLanguage.Text = "DE";
            else if (L == 4103)
                btnLanguage.Text = "DE";
            else if (L == 2055)
                btnLanguage.Text = "DE";
            else if (L == 1031)
                btnLanguage.Text = "DE";
            else if (L == 1059)
                btnLanguage.Text = "BE";
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                PassReliability.Value = tbPassword.Text.Length;
            }
            catch(Exception ex)
            {

            }
            if (tbPassword.Text.Length <4)
            {
                PassReliability.Style = MetroFramework.MetroColorStyle.Red;
            }
            else
            {
                if (tbPassword.Text.Length < 7)
                {
                    PassReliability.Style = MetroFramework.MetroColorStyle.Orange;
                }
                else
                {
                    if (tbPassword.Text.Length >= 9)
                    {
                        PassReliability.Style = MetroFramework.MetroColorStyle.Green;
                    }
                    else
                    {
                        PassReliability.Style = MetroFramework.MetroColorStyle.Orange;
                    }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ci = comboBoxClas.SelectedIndex;
            // TODO: данная строка кода позволяет загрузить данные в таблицу "cAVADataSet.Clas". При необходимости она может быть перемещена или удалена.
            CAVATableAdapter.Clas(ref this.clasTableAdapter1, ref this.cAVADataSet, "Fill");
            void r2()
            {
                try
                {
                    this.Update();
                }
                catch
                {
                    r2();
                }
            }
            comboBoxClas.SelectedIndex = ci;
            l = 1000;
        }

        private void PupilReg_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form il = Application.OpenForms[0];
            for (int i = 0; i < 15; i++)
            {
                System.Threading.Thread.Sleep(25);
                this.Opacity = this.Opacity - 0.1;

            }
            il.Opacity = 15;
            il.Show();
        }

        private void label4_Click(object sender, EventArgs e)
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

        void Animate(Label LabelName)
        {
            if (Animation == true)
            {
                if (LabelName == Sub)
                {
                    Sub.Visible = true;
                    comboBoxSub.Visible = true;
                }
                if (LabelName == Clas)
                {
                    Clas.Visible = true;
                    comboBoxClas.Visible = true;
                }
                if (LabelName == NameFamily)
                {
                    NameFamily.Visible = true;
                    tbName.Visible = true;
                }
                if (LabelName == Pass)
                {
                    btnLanguage.Visible = true;
                    Pass.Visible = true;
                    tbPassword.Visible = true;
                    SecondPass.Visible = true;
                    tbSecPassword.Visible = true;
                    PassReliability.Visible = true;
                }
            }
        }
    }
}
