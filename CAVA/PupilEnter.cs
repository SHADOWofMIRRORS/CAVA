using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using MetroFramework.Forms;
using System.Runtime.InteropServices;

namespace CAVA
{
    public partial class PupilEnter : MetroForm
    {
        public PupilEnter()
        {
            InitializeComponent();
        }
        int l,z;
        int i;
        int lang;

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

        private void PupilEnter_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (i == 0)
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

        }

        private void PupilEnter_Load(object sender, EventArgs e)
        {
            try
            {
                CAVATableAdapter.Teacher(ref teacherTableAdapter, ref cAVADataSet, "Fill");
                CAVATableAdapter.Sub(ref subTableAdapter, ref cAVADataSet, "Fill");
                CAVATableAdapter.Clas(ref clasTableAdapter, ref cAVADataSet, "Fill");
                CAVATableAdapter.Pupil(ref pupilTableAdapter, ref cAVADataSet, "Fill");
            }
            catch (Exception ex)
            {

            }
            try
            {
                CAVATableAdapter.Teacher(ref teacherTableAdapter, ref cAVADataSet, "Fill");
                CAVATableAdapter.Sub(ref subTableAdapter, ref cAVADataSet, "Fill");
                CAVATableAdapter.Clas(ref clasTableAdapter, ref cAVADataSet, "Fill");
                CAVATableAdapter.Pupil(ref pupilTableAdapter, ref cAVADataSet, "Fill");
            }
            catch (Exception ex)
            {

            }
            if (Properties.Settings.Default.LANG == "BE")
            {
                label1.Text = "Група, Клас";
                label2.Text = "Навучэнец";
                label9.Text = "Выкладчык";
                label10.Text = "Вучэбная дысцыпліна, прадмет";
                metroButton1.Text = "Уваход";
            }
            if (teacherDataGridView.Rows[teacherDataGridView.CurrentRow.Index].Cells[4].Value.ToString() == 1.ToString())
            {
                z = 1;
                pictureBox1.Visible = true;
            }
            else
            {
                z = 0;
                pictureBox1.Visible = false;
            }

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

        private void timer2_Tick(object sender, EventArgs e)
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

        private void teacherDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (teacherDataGridView.Rows[teacherDataGridView.CurrentRow.Index].Cells[4].Value.ToString() == 1.ToString())
                {
                    z = 1;
                    pictureBox1.Visible = true;
                }
                else
                {
                    z = 0;
                    pictureBox1.Visible = false;
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                // Получение имени компьютера.
                if (z == 1)
                {
                    string host = System.Net.Dns.GetHostName();
                    // Получение ip-адреса.
                    System.Net.IPAddress ip = System.Net.Dns.GetHostByName(host).AddressList[0];
                    // IP
                    string IP = ip.ToString();
                    if (TextBoxPass.Text == pupilDataGridView.CurrentRow.Cells[4].Value.ToString()
                        && pupilDataGridView.CurrentRow.Cells[2].Value.ToString() == IP)
                    {
                        Main man = new Main();
                        int rowclas = clasDataGridView.CurrentRow.Index;
                        int row = pupilDataGridView.CurrentRow.Index;
                        string s = pupilDataGridView.Rows[row].Cells[1].Value.ToString();
                        Properties.Settings.Default.RT = teacherDataGridView.CurrentRow.Index;
                        Properties.Settings.Default.RS = subDataGridView.CurrentRow.Index;
                        Properties.Settings.Default.RC = rowclas;
                        Properties.Settings.Default.RP = pupilDataGridView.CurrentRow.Index;
                        Properties.Settings.Default.Save();
                        man.s = s;
                        man.Show();
                        i = 1;
                        this.Close();
                    }
                    else
                    {
                        if (Properties.Settings.Default.LANG == "BE")
                        {
                            MessageBox.Show("Праверце правільнасць уведзеных дадзеных. Пры уключанай IP прывязцы, уваход магчым толькі з кампутара, на якім ваш акаўнт быў зарэгістраваны.", "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (Properties.Settings.Default.LANG == "RU")
                            {
                                MessageBox.Show("Проверьте правильность введённых данных. При включённой IP привязке, вход возможен только с компьютера, на котором ваш аккаунт был зарегистрирован.", "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        int row = pupilDataGridView.CurrentRow.Index;
                        try
                        {
                            CAVATableAdapter.Pupil(ref this.pupilTableAdapter, ref this.cAVADataSet, "Fill");
                            // TODO: данная строка кода позволяет загрузить данные в таблицу "cAVADataSet.Clas". При необходимости она может быть перемещена или удалена.
                        }
                        catch (Exception ex)
                        {

                        }
                        TextBoxPass.Text = "";
                        pupilDataGridView.CurrentCell = pupilDataGridView.Rows[row].Cells[4];
                    }
                }
                else
                {
                    if (TextBoxPass.Text == pupilDataGridView.CurrentRow.Cells[2].Value.ToString())
                    {
                        Main man = new Main();
                        int rowclas = clasDataGridView.CurrentRow.Index;
                        int row = pupilDataGridView.CurrentRow.Index;
                        string s = pupilDataGridView.Rows[row].Cells[1].Value.ToString();
                        man.s = s;
                        Properties.Settings.Default.RT = teacherDataGridView.CurrentRow.Index;
                        Properties.Settings.Default.RS = subDataGridView.CurrentRow.Index;
                        Properties.Settings.Default.RC = rowclas;
                        Properties.Settings.Default.RP = pupilDataGridView.CurrentRow.Index;
                        Properties.Settings.Default.Save();
                        man.Show();
                        i = 1;
                        this.Close();
                    }
                    else
                    {
                        if (Properties.Settings.Default.LANG == "BE")
                        {
                            MessageBox.Show("Праверце правільнасць уведзеных дадзеных.", "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (Properties.Settings.Default.LANG == "RU")
                            {
                                MessageBox.Show("Проверьте правильность введённых данных.", "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        int row = pupilDataGridView.CurrentRow.Index;
                        try
                        {
                            CAVATableAdapter.Pupil(ref this.pupilTableAdapter, ref this.cAVADataSet, "Fill");
                            // TODO: данная строка кода позволяет загрузить данные в таблицу "cAVADataSet.Clas". При необходимости она может быть перемещена или удалена.
                        }
                        catch (Exception ex)
                        {

                        }
                        TextBoxPass.Text = "";
                        pupilDataGridView.CurrentCell = pupilDataGridView.Rows[row].Cells[4];
                    }
                }
            }
            catch (Exception)
            {
                if (Properties.Settings.Default.LANG == "BE")
                {
                    MessageBox.Show("Праверце правільнасць уведзеных дадзеных.", "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (Properties.Settings.Default.LANG == "RU")
                    {
                        MessageBox.Show("Проверьте правильность введённых данных.", "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
