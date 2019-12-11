using CAVA.MESSAGEBOXFOLDER;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Media;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace CAVA
{

    public partial class mini : MetroForm
    {
        public mini()
        {
            InitializeComponent();
        }

        public int ex = 0;
        int tim;
        int s;
        private Int32 tmpX;
        private Int32 tmpY;
        private bool flMove = false;
        public int load;
        bool FastCloing = false;

        AL.AL AL = new AL.AL();

        private void mini_Load(object sender, EventArgs e)
        {
            comboBox1.Text = Properties.Settings.Default.LANG;
            if (System.IO.File.Exists(Application.StartupPath + @"\ConnectString.TTOR") == true)
            {
                string s1 = AL.Decoding(System.IO.File.ReadAllText(Application.StartupPath + @"\ConnectString.TTOR"));
                EditConnect(s1);
            }
            else
            {
                EditConnect("Server=ALEXALL;Database=AA7;User Id=ALEXALL;Password=ALEXALL;");
                System.IO.File.WriteAllText(Application.StartupPath + @"\ConnectString.TTOR", "Server=ALEXALL;Database=AA7;User Id=ALEXALL;Password=ALEXALL;", Encoding.UTF8);
            }
            try
            {
                if (Properties.Settings.Default.LANG == "")
                {
                    Properties.Settings.Default.LANG = "RU";
                    Properties.Settings.Default.Save();
                }
                try
                {
                    if (Properties.Settings.Default.LANG == "BE")
                    {
                        btnStart.Text = "Пачаць";
                        btnCreate.Text = "Стварыць";
                        NI.BalloonTipText = "Пачакайце, CAVA запускаецца";
                    }
                    else if (Properties.Settings.Default.LANG == "EN")
                    {
                        btnStart.Text = "Start";
                        btnCreate.Text = "Create";
                        NI.BalloonTipText = "Please wait, CAVA is loaded.";
                    }
                        NI.ShowBalloonTip(10);
                    // TODO: данная строка кода позволяет загрузить данные в таблицу "cAVA_DATADataSet.Update". При необходимости она может быть перемещена или удалена.
                    this.updateTableAdapter.Fill(this.cAVADataSet.Update);
                    // TODO: данная строка кода позволяет загрузить данные в таблицу "cAVADataSet.Computers". При необходимости она может быть перемещена или удалена.
                    this.computersTableAdapter.Fill(this.cAVADataSet.Computers);
                    if (updateDataGridView.RowCount == 1)
                    {
                        updateTableAdapter.Insert(0, "", true);
                        CAVATableAdapter.Update(ref updateTableAdapter, ref cAVADataSet, "Update");
                    }

                    Properties.Settings.Default.Close = 0;
                    Properties.Settings.Default.Save();

                    if (Properties.Settings.Default.DelUpdate.Length > 0)
                    {
                        try
                        {
                            System.IO.File.Delete(Properties.Settings.Default.DelUpdate);
                            Properties.Settings.Default.DelUpdate = "";
                            Properties.Settings.Default.Save();
                            MessageBox.Show("Подождите, идёт удаление файлов установки...", "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка удаления файлов UPDATER" + ex.Message, "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    if (Properties.Settings.Default.Id < 1)
                    {
                        SetId();
                    }
                    else
                    {
                        if (computersDataGridView.RowCount == 0)
                        {
                            InsertComputer();
                        }
                        bool Is = false;
                        for (int i = 0; i < computersDataGridView.RowCount; i++)
                        {
                            if (G(computersId, i) == Properties.Settings.Default.Id.ToString())
                            {
                                computersTableAdapter.Fill(cAVADataSet.Computers);
                                computersDataGridView.CurrentCell = computersDataGridView[0, i];
                                Is = true;
                                R(computersConnected, true);
                                R(computersStop, false);
                                computersTableAdapter.Update(cAVADataSet.Computers);
                                break;
                            }
                        }
                        if (Is == false)
                        {
                            SetId();
                        }
                    }
                    timer1.Start();
                    timer2.Start();
                    timer3.Start();
                    Properties.Settings.Default.instrucint = 0;
                    Properties.Settings.Default.Save();
                    ex = Properties.Settings.Default.ex;

                    MethodLoad2();

                    NI.Visible = true;
                }
                catch (Exception ex)
                {
                    timerIsReg.Enabled = false;
                    timer1.Enabled = false;
                    timer2.Enabled = false;
                    timer3.Enabled = false;
                    MessageBox.Show("Нажмите Ок чтобы продолжить." + ex.Message, "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    FastCloing = true;
                    EnterSettings es = new EnterSettings();
                    es.i = 1;
                    es.Show();
                }
                NI.Visible = false;    //Убрать Tip
                NI.Visible = true;

            }
            catch (Exception ex)
            {

            }
        }

        void SetId()
        {
            if (G(computersConnected, computersDataGridView.RowCount - 1) != "True")
                Properties.Settings.Default.Id = Convert.ToInt32(G(computersId, computersDataGridView.RowCount - 1));
            else
                InsertComputer();
            Properties.Settings.Default.Save();
            Application.Restart();
        }

        void InsertComputer()
        {
            computersDataGridView.EndEdit();
            computersBindingSource.EndEdit();
            computersTableAdapter.Update(cAVADataSet.Computers);
            computersTableAdapter.Fill(cAVADataSet.Computers);
            computersTableAdapter.Insert("Имя", "", "", -1, false, false, 0, null, false);
            computersTableAdapter.Fill(cAVADataSet.Computers);
            SetId();
        }

        private void MethodLoad1()
        {
            if (System.Diagnostics.Process.GetProcessesByName(Application.ProductName).Length > 1)
            {
                Process p = new Process();
                foreach (var process in Process.GetProcessesByName("CAVA"))
                {
                    process.Kill();
                }
                foreach (var process in Process.GetProcessesByName("CAVA"))
                {
                    process.Kill();
                }
                MessageBox.Show("Приложение уже запущено. Закройте все процессы связанные с CAVA.",
                    "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else
            {
                CE ce = new CE();
                ce.Show();

            }
        }

        private void MethodLoad2()
        {
            CE ce = new CE();
            ce.Show();

        }

        private void mini_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FastCloing == false)
            {
                if (ex >= 1)
                {
                    Properties.Settings.Default.Reload();
                    Properties.Settings.Default.ex = 1;
                    tim = Properties.Settings.Default.tim;
                    Properties.Settings.Default.timpr = tim;
                    s = Properties.Settings.Default.s;
                    Properties.Settings.Default.instrucint = 0;
                    Properties.Settings.Default.Save();

                }
                else
                {
                    Properties.Settings.Default.Reload();
                    Properties.Settings.Default.ex = 0;
                    tim = Properties.Settings.Default.tim;
                    Properties.Settings.Default.timpr = tim;
                    s = Properties.Settings.Default.s;
                    Properties.Settings.Default.Save();
                }
                Properties.Settings.Default.proverka = 0;
                Properties.Settings.Default.Save();
                computersTableAdapter.Fill(cAVADataSet.Computers);
                R(computersConnected, false);
                R(computersStop, false);
                R(computersStart, false);
                R(computersTime, 0);
                computersTableAdapter.Update(cAVADataSet.Computers);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();
            tim = Properties.Settings.Default.tim;
            s = Properties.Settings.Default.s;
            ex = Properties.Settings.Default.ex;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            flMove = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (flMove)
            {
                this.Left = this.Left + (Cursor.Position.X - tmpX);
                this.Top = this.Top + (Cursor.Position.Y - tmpY);

                tmpX = Cursor.Position.X;
                tmpY = Cursor.Position.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            tmpX = Cursor.Position.X;
            tmpY = Cursor.Position.Y;
            flMove = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            const string message = "Служба поддержки: ALEXALL-mail@yandex.ru";
            const string caption = "ALEX ALL";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void label5_MouseUp(object sender, MouseEventArgs e)
        {
            flMove = false;
        }

        private void label5_MouseDown(object sender, MouseEventArgs e)
        {
            tmpX = Cursor.Position.X;
            tmpY = Cursor.Position.Y;
            flMove = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ifo = 0;
            Properties.Settings.Default.Save();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 15; i++)
            {
                System.Threading.Thread.Sleep(55);
                this.Opacity = this.Opacity - 0.1;

            }
            this.Hide();
            Enter l = new Enter();
            l.Show();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            Form CE = Application.OpenForms["CE"];
            for (int i = 0; i < 20; i++)
            {
                System.Threading.Thread.Sleep(35);
                CE.Opacity = CE.Opacity - 0.1;

            }
            Form a = Application.OpenForms[0];
            a.Show();
            a.Opacity = 100;
            CE.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            timer2.Enabled = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.SettingsNI == 1)
            {
                NI.Visible = false;
                Properties.Settings.Default.SettingsNI = 0;
                Properties.Settings.Default.Save();
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            try
            {
                // TODO: данная строка кода позволяет загрузить данные в таблицу "cAVA_DATADataSet.Update". При необходимости она может быть перемещена или удалена.
                CAVATableAdapter.Update(ref this.updateTableAdapter, ref this.cAVADataSet, "Fill");
                if (updateDataGridView.Rows[0].Cells[1].Value.ToString() == "1")
                {
                    timer3.Stop();
                    string name = System.IO.Path.GetFileName(updateDataGridView.Rows[0].Cells[2].Value.ToString());
                    System.IO.File.Copy(updateDataGridView.Rows[0].Cells[2].Value.ToString(), Application.StartupPath + @"\" + name);
                    Properties.Settings.Default.DelUpdate = Application.StartupPath + @"\" + name;
                    Properties.Settings.Default.Save();
                    Process.Start(Application.StartupPath + @"\" + name);
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                timer3.Stop();
            }

            try
            {
                int c = computersDataGridView.CurrentRow.Index;
                // TODO: данная строка кода позволяет загрузить данные в таблицу "cAVADataSet.Computers". При необходимости она может быть перемещена или удалена.
                this.computersTableAdapter.Fill(this.cAVADataSet.Computers);
                if (computersDataGridView.RowCount == 0)
                {
                    FastCloing = true;
                    this.Close();
                }
                computersDataGridView.CurrentCell = computersDataGridView[0, c];
                if (G(computersStart) == "True" && Convert.ToInt32(G(computersTime)) == 0 && Convert.ToInt32(G(computersTest_Id)) != -1)
                {
                    Test.Test T = new Test.Test();
                    T.ComputerId = Convert.ToInt32(G(computersId));
                    T.TestRow = Convert.ToInt32(G(computersTest_Id));
                    T.Show();
                    R(computersStart, false);
                    computersTableAdapter.Update(cAVADataSet.Computers);
                    this.Hide();
                }
                if (Convert.ToBoolean(G(computersConnected)) == false)
                {
                    timer3.Stop();
                    this.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("" + Properties.Settings.Default.Enter, "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void label11_Click(object sender, EventArgs e)
        {
            NI.BalloonTipTitle = "ALEX ALL";
            NI.BalloonTipText = "Нажмите, чтобы перейти на сайт";
            NI.ShowBalloonTip(9);
        }

        private void начатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PupilEnter pue = new PupilEnter();
            for (int i = 0; i < 15; i++)
            {
                System.Threading.Thread.Sleep(55);
                this.Opacity = this.Opacity - 0.1;

            }
            pue.Opacity = 15;
            pue.Show();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Enter ent = new Enter();
            ent.Show();
            this.Hide();
        }

        private void NI_BalloonTipClicked(object sender, EventArgs e)
        {
            Process.Start("http://alex-all.ru/");
        }
        public string GetID()
        {
            string s1 = "";
            string s2 = "";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(
            "SELECT Manufacturer,Product FROM Win32_BaseBoard");
            ManagementObjectCollection information = searcher.Get();
            foreach (ManagementObject obj in information)
                foreach (PropertyData data in obj.Properties)
                {
                    if (s2.Length == 0)
                        s2 = data.Value.ToString();
                    else s1 = data.Value.ToString();

                }
            return s1;
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.LANG == "RU")
            {
                MessageBox.Show("Поддержка: ALEXALL-mail@yandex.ru", "ALEX ALL", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                if (Properties.Settings.Default.LANG == "BE")
                {
                    MessageBox.Show("Падтрымка: ALEXALL-mail@yandex.ru", "ALEX ALL", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void mini_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                NI.Visible = true;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            PupilEnter pue = new PupilEnter();
            for (int i = 0; i < 15; i++)
            {
                System.Threading.Thread.Sleep(25);
                this.Opacity = this.Opacity - 0.1;

            }
            this.Hide();
            this.Opacity = 15;
            pue.Opacity = 15;
            pue.Show();
            NI.Visible = false;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (updateDataGridView.Rows[0].Cells[3].Value.ToString() == "True")
            {
                for (int i = 0; i < 15; i++)
                {
                    System.Threading.Thread.Sleep(25);
                    this.Opacity = this.Opacity - 0.1;

                }
                PupilReg pr = new PupilReg();
                pr.Show();
                this.Hide();
                this.Opacity = 15;
                NI.Visible = false;
            }
            else
            {
                if (Properties.Settings.Default.LANG == "BE")
                {
                    MessageBox.Show("Настаўнік адключыў магчымасць рэгістрацыі.", "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (Properties.Settings.Default.LANG == "RU")
                    {
                        MessageBox.Show("Учитель отключил возможность регистрации", "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void timerIsReg_Tick(object sender, EventArgs e)
        {
            try
            {
                // TODO: данная строка кода позволяет загрузить данные в таблицу "cAVA_DATADataSet.Update". При необходимости она может быть перемещена или удалена.
                CAVATableAdapter.Update(ref this.updateTableAdapter, ref this.cAVADataSet, "Fill");
                if (updateDataGridView.Rows[0].Cells[3].Value.ToString() == "True")
                {
                    btnCreate.Enabled = true;
                    btnCreate.Style = MetroFramework.MetroColorStyle.Brown;
                }
                else
                {
                    btnCreate.Enabled = false;
                    btnCreate.Style = MetroFramework.MetroColorStyle.Silver;
                }
            }
            catch (Exception ex)
            {
                timerIsReg.Enabled = false;
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
                MessageBox.Show("Нажмите Ок чтобы продолжить." + ex.Message, "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        void EditConnect(string ConnectString)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            foreach (XmlElement element in xmlDoc.DocumentElement)
            {
                if (element.Name.Equals("connectionStrings"))
                {
                    foreach (XmlNode node in element.ChildNodes)
                    {
                        if (node.Attributes[0].Value.Equals("CAVA.Properties.Settings.CAVAConnectionString"))
                        {
                            node.Attributes[1].Value = ConnectString;
                        }
                    }
                }
            }

            xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            ConfigurationManager.RefreshSection("connectionStrings");

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CAVA.Properties.Settings.CAVAConnectionString"].ConnectionString;

        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "BE")
            {
                Properties.Settings.Default.LANG = "BE";
            }
            else if (comboBox1.Text == "EN")
                Properties.Settings.Default.LANG = "EN";
            else
            {
                if (comboBox1.Text == "RU")
                {
                    Properties.Settings.Default.LANG = "RU";
                }
            }
            Properties.Settings.Default.Save();
        }
        void R(DataGridViewColumn Column, object Text = null, int Row = -1)
        {
            if (Row == -1)
            {
                if (Column.DataGridView.RowCount >= Column.DataGridView.CurrentRow.Index &&
                Column.DataGridView.CurrentRow.Index >= 0)
                    Column.DataGridView.Rows[Column.DataGridView.CurrentRow.Index].Cells[Column.Name].Value = Text;
            }
            else
            {
                if (Column.DataGridView.RowCount >= Row && Row >= 0)
                    Column.DataGridView.Rows[Row].Cells[Column.Name].Value = Text;
            }
            Column.DataGridView.EndEdit();
            ((BindingSource)Column.DataGridView.DataSource).EndEdit();
        }

        string G(DataGridViewColumn Column, int Row = -1)
        {
            if (Row == -1)
            {
                if (Column.DataGridView.RowCount >= Column.DataGridView.CurrentRow.Index &&
                Column.DataGridView.CurrentRow.Index >= 0)
                    return Column.DataGridView.Rows[Column.DataGridView.CurrentRow.Index].Cells[Column.Name].Value.ToString();
                else
                    return "";
            }
            else
            {
                if (Column.DataGridView.RowCount >= Row && Row >= 0)
                    return Column.DataGridView.Rows[Row].Cells[Column.Name].Value.ToString();
                else
                    return "";
            }
        }
    }
}
