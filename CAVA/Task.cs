using CAVA.MESSAGEBOXFOLDER;
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
using CAVA.Test;

namespace CAVA
{
    public partial class Task : MetroForm
    {
        public string z;
        public int t;
        public string p;
        public string s;
        int al;
        public int l = 0;
        int y,c;
        public int r1, r2,r3;
        string m;
        public string SavePath;
        public string sx;
        public int ro;
        bool firstshowing = true;
        private bool Drag;
        private int MouseX;
        private int MouseY;

        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        private bool m_aeroEnabled;

        private const int CS_DROPSHADOW = 0x00020000;
        private const int WM_NCPAINT = 0x0085;
        private const int WM_ACTIVATEAPP = 0x001C;

        [System.Runtime.InteropServices.DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);
        [System.Runtime.InteropServices.DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
        [System.Runtime.InteropServices.DllImport("dwmapi.dll")]

        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
            );

        public struct MARGINS
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }
        protected override CreateParams CreateParams
        {
            get
            {
                m_aeroEnabled = CheckAeroEnabled();
                CreateParams cp = base.CreateParams;
                if (!m_aeroEnabled)
                    cp.ClassStyle |= CS_DROPSHADOW; return cp;
            }
        }
        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0; DwmIsCompositionEnabled(ref enabled);
                return (enabled == 1) ? true : false;
            }
            return false;
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCPAINT:
                    if (m_aeroEnabled)
                    {
                        var v = 2;
                        DwmSetWindowAttribute(this.Handle, 2, ref v, 4);
                        MARGINS margins = new MARGINS()
                        {
                            bottomHeight = 1,
                            leftWidth = 0,
                            rightWidth = 0,
                            topHeight = 0
                        }; DwmExtendFrameIntoClientArea(this.Handle, ref margins);
                    }
                    break;
                default: break;
            }
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT) m.Result = (IntPtr)HTCAPTION;
        }
        private void PanelMove_MouseDown(object sender, MouseEventArgs e)
        {
            Drag = true;
            MouseX = Cursor.Position.X - this.Left;
            MouseY = Cursor.Position.Y - this.Top;
        }
        private void PanelMove_MouseMove(object sender, MouseEventArgs e)
        {
            if (Drag)
            {
                this.Top = Cursor.Position.Y - MouseY;
                this.Left = Cursor.Position.X - MouseX;
            }
        }
        private void PanelMove_MouseUp(object sender, MouseEventArgs e) { Drag = false; }
        public Task()
        {
            InitializeComponent();
            m_aeroEnabled = false;
        }

        private void Task_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Properties.Settings.Default.RT = teacherDataGridView.CurrentRow.Index;
                Properties.Settings.Default.RS = subDataGridView.CurrentRow.Index;
                Properties.Settings.Default.RC = clasDataGridView.CurrentRow.Index;
                Properties.Settings.Default.RP = pupilDataGridView.CurrentRow.Index;
                Properties.Settings.Default.AccRow = accDataGridView.CurrentRow.Index;
                Properties.Settings.Default.Save();
            }
            catch(Exception ex)
            {

            }
            Main man = new Main();
            try
            {
                al = Properties.Settings.Default.al;
                y = Properties.Settings.Default.y;
                if (l == 0)
                {
                    if (al == 1)
                    {
                        Properties.Settings.Default.Save();
                        man.s = s;
                        man.l = l;
                        if (y == 1)
                        {
                            man.i = 1;
                            man.btnStart.Enabled = true;
                            man.timer2.Start();
                        }
                        man.Show();
                    }
                    else
                    {
                        man.s = s;
                        man.Show();
                    }
                }
                else
                {
                    Form i = Application.OpenForms["CAVA"];
                    i.Enabled = true;
                }
            }
            catch(Exception ex)
            {
                man.s = s;
                man.Show();
            }
            
        }

        private void Task_Load(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    // TODO: данная строка кода позволяет загрузить данные в таблицу "cAVADataSet.Acc". При необходимости она может быть перемещена или удалена.
                    CAVATableAdapter.Acc(ref this.accTableAdapter, ref this.cAVADataSet, "Fill");
                    // TODO: данная строка кода позволяет загрузить данные в таблицу "cAVADataSet.Pupil". При необходимости она может быть перемещена или удалена.
                    CAVATableAdapter.Pupil(ref this.pupilTableAdapter, ref this.cAVADataSet, "Fill");
                    // TODO: данная строка кода позволяет загрузить данные в таблицу "cAVADataSet.Clas". При необходимости она может быть перемещена или удалена.
                    CAVATableAdapter.Clas(ref this.clasTableAdapter, ref this.cAVADataSet, "Fill");
                    // TODO: данная строка кода позволяет загрузить данные в таблицу "cAVADataSet.Sub". При необходимости она может быть перемещена или удалена.
                    CAVATableAdapter.Sub(ref this.subTableAdapter, ref this.cAVADataSet, "Fill");
                    // TODO: данная строка кода позволяет загрузить данные в таблицу "cAVADataSet.Teacher". При необходимости она может быть перемещена или удалена.
                    CAVATableAdapter.Teacher(ref this.teacherTableAdapter, ref this.cAVADataSet, "Fill");
                }
                catch (Exception ex)
                {

                }
                try
                {
                    // TODO: данная строка кода позволяет загрузить данные в таблицу "cAVADataSet.Acc". При необходимости она может быть перемещена или удалена.
                    CAVATableAdapter.Acc(ref this.accTableAdapter, ref this.cAVADataSet, "Fill");
                    // TODO: данная строка кода позволяет загрузить данные в таблицу "cAVADataSet.Pupil". При необходимости она может быть перемещена или удалена.
                    CAVATableAdapter.Pupil(ref this.pupilTableAdapter, ref this.cAVADataSet, "Fill");
                    // TODO: данная строка кода позволяет загрузить данные в таблицу "cAVADataSet.Clas". При необходимости она может быть перемещена или удалена.
                    CAVATableAdapter.Clas(ref this.clasTableAdapter, ref this.cAVADataSet, "Fill");
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
                    this.Text = "CAVA V. 4.0 ";
                    ZH.Text = @"Тут будуць
адлюстроўвацца вашы заданні";
                    metroButton1.Text = "Устанавіць заданне";
                    label1.Text = @"• Максімальная колькасць
запускау 
кожнага задання:";
                    timeDataGridViewTextBoxColumn.HeaderText = "Час";
                    nameDataGridViewTextBoxColumn1.HeaderText = "Названне";
                    descDataGridViewTextBoxColumn.HeaderText = "Апісанне";
                    markDataGridViewTextBoxColumn.HeaderText = "Адзнака";
                    tCDataGridViewTextBoxColumn.HeaderText = "Коль-ць запускаў";
                }
                else if (Properties.Settings.Default.LANG == "EN")
                {
                    this.Text = "CAVA V. 4.0 ";
                    ZH.Text = @"There will be
show your ratings";
                    metroButton1.Text = "Set Task";
                    label1.Text = @"• Maximum amount
launches 
of each tasks:";

                    timeDataGridViewTextBoxColumn.HeaderText = "Время";
                    nameDataGridViewTextBoxColumn1.HeaderText = "Название";
                    descDataGridViewTextBoxColumn.HeaderText = "Описание";
                    markDataGridViewTextBoxColumn.HeaderText = "Оценка";
                    tCDataGridViewTextBoxColumn.HeaderText = "Кол-во запусков";
                }
                try
                {

                    Properties.Settings.Default.al = 0;
                    Properties.Settings.Default.y = 0;
                    Properties.Settings.Default.Save();
                    timer1.Start();
                    if (firstshowing == true)
                    {
                        this.Text = this.Text + s;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                try
                {
                    teacherDataGridView.CurrentCell = teacherDataGridView[0, Properties.Settings.Default.RT];
                    subDataGridView.CurrentCell = subDataGridView[0, Properties.Settings.Default.RS];
                    clasDataGridView.CurrentCell = clasDataGridView[0, Properties.Settings.Default.RC];
                    pupilDataGridView.CurrentCell = pupilDataGridView[0, Properties.Settings.Default.RP];
                }
                catch (Exception ex)
                {

                }
                try
                {
                    accDataGridView.Rows[4].DefaultCellStyle.BackColor = Color.Red;
                    foreach (DataGridViewRow row in accDataGridView.Rows)
                    {
                        if (row.Cells[8].Value.ToString() == 1.ToString())
                        {
                            row.DefaultCellStyle.BackColor = Color.Red;
                        }
                        else
                        {
                            row.DefaultCellStyle.BackColor = Color.White;
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }
            catch(Exception ex)
            {

            }
        }
        private void accDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int o = accDataGridView.CurrentRow.Index;
            accDataGridView.Rows[o].Selected = true;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            y = 1;
            al = 1;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Form il = Application.OpenForms["BWT"];
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            label2.Text = pupilDataGridView.Rows[Properties.Settings.Default.RP].Cells[5].Value.ToString();
            if (l == 1)
            {
                metroButton1.Visible = false;
            }

            if (accDataGridView.Rows.Count == 0)
            {
                panelCenter.Visible = false;
                ZH.Visible = true;
            }
        }

        private void Task_VisibleChanged(object sender, EventArgs e)
        {
            firstshowing = false;
            Task_Load(e, e);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ZH_Click(object sender, EventArgs e)
        {

        }

        private void accDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(accDataGridView.Rows[accDataGridView.CurrentRow.Index].Cells[1].Value.ToString()) == false)
                {
                    try
                    {
                        ro = accDataGridView.CurrentRow.Index;
                        if (accDataGridView.Rows[ro].Cells[6].Value.ToString() == "")
                        {
                            accDataGridView.Rows[ro].Cells[6].Value = "0";
                            accBindingSource.EndEdit();
                            CAVATableAdapter.Acc(ref accTableAdapter, ref cAVADataSet, "Update");
                            CAVATableAdapter.Acc(ref this.accTableAdapter, ref this.cAVADataSet, "Fill");
                        }
                        int a1 = Convert.ToInt32(accDataGridView.Rows[ro].Cells[6].Value.ToString());
                        int a2 = Convert.ToInt32(pupilDataGridView.Rows[Properties.Settings.Default.RP].Cells[5].Value.ToString());
                        if (a1 >= a2)
                        {
                            if (Properties.Settings.Default.LANG == "BE")
                            {
                                MessageBox.Show("Дасягнута максімальная колькасць запускаў гэтага задання.", "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                if (Properties.Settings.Default.LANG == "RU")
                                {
                                    MessageBox.Show("Достигнуто максимальное количество запусков этого задания.", "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            if (accDataGridView.Rows[ro].Cells[8].Value.ToString() == 1.ToString())
                            {
                                if (Properties.Settings.Default.LANG == "BE")
                                {
                                    MessageBox.Show("Заданне заблакавана", "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    if (Properties.Settings.Default.LANG == "RU")
                                    {
                                        MessageBox.Show("Задание заблокировано.", "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            else
                            {

                                TestOpen T = new TestOpen();
                                T.t = teacherDataGridView.CurrentRow.Index;
                                T.s = subDataGridView.CurrentRow.Index;
                                T.c = clasDataGridView.CurrentRow.Index;
                                T.p = pupilDataGridView.CurrentRow.Index;
                                T.a = accDataGridView.CurrentRow.Index;

                                string t = accDataGridView.Rows[accDataGridView.CurrentRow.Index].Cells[1].Value.ToString();
                                string[] t1 = t.Split(new char[] { ':' });
                                T.TestRow = Convert.ToInt32(t1[t1.Length - 1]);
                                T.Show();
                                this.Enabled = false;
                                this.Hide();
                                firstshowing = false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        if (Properties.Settings.Default.LANG == "BE")
                        {
                            MessageBox.Show("Заданне не абрана або: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            if (Properties.Settings.Default.LANG == "RU")
                            {
                                MessageBox.Show("Задание не выбрано или: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                        }
                    }
                }
                else
                {
                    c = 0;
                    try
                    {
                        ro = accDataGridView.CurrentRow.Index;
                        if (accDataGridView.Rows[ro].Cells[6].Value.ToString() == "")
                        {
                            accDataGridView.Rows[ro].Cells[6].Value = "0";
                            accBindingSource.EndEdit();
                            CAVATableAdapter.Acc(ref this.accTableAdapter, ref this.cAVADataSet, "Update");
                            CAVATableAdapter.Acc(ref this.accTableAdapter, ref this.cAVADataSet, "Fill");
                        }
                        int a1 = Convert.ToInt32(accDataGridView.Rows[ro].Cells[6].Value.ToString());
                        int a2 = Convert.ToInt32(pupilDataGridView.Rows[Properties.Settings.Default.RP].Cells[5].Value.ToString());
                        if (a1 >= a2)
                        {
                            if (Properties.Settings.Default.LANG == "BE")
                            {
                                MessageBox.Show("Дасягнута максімальная колькасць запускаў гэтага задання.", "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                if (Properties.Settings.Default.LANG == "RU")
                                {
                                    MessageBox.Show("Достигнуто максимальное количество запусков этого задания.", "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            if (accDataGridView.Rows[ro].Cells[8].Value.ToString() == 1.ToString())
                            {
                                if (Properties.Settings.Default.LANG == "BE")
                                {
                                    MessageBox.Show("Заданне заблакавана", "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    if (Properties.Settings.Default.LANG == "RU")
                                    {
                                        MessageBox.Show("Задание заблокировано.", "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            else
                            {
                                if (Convert.ToInt32(accDataGridView.Rows[ro].Cells[2].Value.ToString()) <= 0)
                                {
                                    if (Properties.Settings.Default.LANG == "BE")
                                    {
                                        MessageBox.Show("Параметр Час не адпавядае патрэбнаму значэнню.", "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                    {
                                        if (Properties.Settings.Default.LANG == "RU")
                                        {
                                            MessageBox.Show("Параметр Время не соответствует требуемому значению.", "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                                else
                                {
                                    if (subDataGridView.Rows[subDataGridView.CurrentRow.Index].Cells[3].Value.ToString() == "")
                                    {
                                        if (Properties.Settings.Default.LANG == "BE")
                                        {
                                            MessageBox.Show("На гэтай вучэбнай дысцыпліне не ўстаноўлена тэчка вываду. Звярніцеся да адміністратара.", "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        else
                                        {
                                            if (Properties.Settings.Default.LANG == "RU")
                                            {
                                                MessageBox.Show("У этой учебной дисциплины отсутствует папка вывода. Обратитесь к администратору.", "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                        }
                                    }
                                    else
                                    {

                                        sx = System.IO.Path.GetExtension(accDataGridView.Rows[ro].Cells[1].Value.ToString());
                                        SavePath = @"" + subDataGridView.Rows[subDataGridView.CurrentRow.Index].Cells[3].Value.ToString() + @"\"
                                        + pupilDataGridView.Rows[pupilDataGridView.CurrentRow.Index].Cells[1].Value.ToString() + @"\";
                                        if (Directory.Exists(SavePath) == true)
                                        {
                                            SavePath += accDataGridView.Rows[ro].Cells[3].Value.ToString()
                                                + sx;
                                        }
                                        else
                                        {
                                            Directory.CreateDirectory(SavePath);
                                            SavePath += accDataGridView.Rows[ro].Cells[3].Value.ToString()
                                                + sx;
                                        }
                                        // Проверка на каталог
                                        try
                                        {
                                            if (System.IO.Path.HasExtension(SavePath) == false)
                                            {
                                                if (Properties.Settings.Default.LANG == "BE")
                                                {
                                                    MessageBox.Show("Шлях да задання не з'яўляецца файлам.", "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                }
                                                else
                                                {
                                                    if (Properties.Settings.Default.LANG == "RU")
                                                    {
                                                        MessageBox.Show("Путь к заданию не является файлом.", "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    }
                                                }

                                            }
                                            else
                                            {
                                                if (c == 0)
                                                {
                                                    //Проверка наличия файла в директории вывода
                                                    try
                                                    {
                                                        if (File.Exists(SavePath) == false)
                                                        {
                                                            try
                                                            {
                                                                //Копирование
                                                                //__________________________
                                                                this.Enabled = false;
                                                                BWT bwt = new BWT();
                                                                bwt.SavePath = SavePath;
                                                                bwt.ro = ro;
                                                                bwt.sx = sx;
                                                                bwt.accd = accDataGridView.Rows[ro].Cells[1].Value.ToString();
                                                                bwt.accdesc = accDataGridView.Rows[ro].Cells[4].Value.ToString();
                                                                bwt.s = accDataGridView.Rows[ro].Cells[2].Value.ToString();
                                                                bwt.name = accDataGridView.Rows[ro].Cells[3].Value.ToString();
                                                                bwt.Show();







                                                            }
                                                            catch (Exception ex)
                                                            {

                                                            }

                                                        }
                                                        else
                                                        {
                                                            Properties.Settings.Default.Desc = accDataGridView.Rows[ro].Cells[4].Value.ToString();
                                                            Properties.Settings.Default.path = SavePath;
                                                            Properties.Settings.Default.r3 = ro;
                                                            Properties.Settings.Default.name = accDataGridView.Rows[ro].Cells[3].Value.ToString();
                                                            string s = accDataGridView.Rows[ro].Cells[2].Value.ToString();
                                                            int i = Convert.ToInt32(s);
                                                            Properties.Settings.Default.tim = i;
                                                            Properties.Settings.Default.Save();
                                                            Properties.Settings.Default.Desc = accDataGridView.Rows[ro].Cells[4].Value.ToString();
                                                            Properties.Settings.Default.Save();
                                                            Properties.Settings.Default.al = 1;
                                                            Properties.Settings.Default.y = 1;
                                                            Properties.Settings.Default.Save();
                                                            if (Convert.ToInt32(accDataGridView.Rows[ro].Cells[8].Value.ToString()) > 0)
                                                            {
                                                                if (Properties.Settings.Default.LANG == "BE")
                                                                {
                                                                    MessageBox.Show("Заданне ўстаноўлена, можаце працягнуць працу.", "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                                                }
                                                                else
                                                                {
                                                                    if (Properties.Settings.Default.LANG == "RU")
                                                                    {
                                                                        MessageBox.Show("Задание установлено, можете продолжить работу.", "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (Properties.Settings.Default.LANG == "BE")
                                                                {
                                                                    MessageBox.Show("Загрузка завершана, можна прыступіць да працы", "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                                                }
                                                                else
                                                                {
                                                                    if (Properties.Settings.Default.LANG == "RU")
                                                                    {
                                                                        MessageBox.Show("Загрузка завершена, можно приступить к работе.", "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                                                    }
                                                                }
                                                            }
                                                            this.Close();
                                                        }
                                                    }
                                                    catch (Exception ex)
                                                    {

                                                    }


                                                }
                                            }

                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message, "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        if (Properties.Settings.Default.LANG == "BE")
                        {
                            MessageBox.Show("Заданне не абрана або: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            if (Properties.Settings.Default.LANG == "RU")
                            {
                                MessageBox.Show("Задание не выбрано или: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (Properties.Settings.Default.LANG == "BE")
                {
                    MessageBox.Show("Заданне не абрана.", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    if (Properties.Settings.Default.LANG == "RU")
                    {
                        MessageBox.Show("Задание не выбрано.", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            
        }

        private void accBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {


        }
    }
}
