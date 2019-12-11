using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAVA.Test;

namespace CAVA
{
    public partial class TestOpen : MetroForm
    {
        public TestOpen()
        {
            InitializeComponent();
        }
        public int t = 0;
        public int s = 0;
        public int c = 0;
        public int p = 0;
        public int a = 0;
        public int TestRow = 0;

        bool a1 = true;
        private void Test_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: данная строка кода позволяет загрузить данные в таблицу "cAVADataSet.Test". При необходимости она может быть перемещена или удалена.
                CAVATableAdapter.Test(ref this.testTableAdapter, ref this.cAVADataSet, "Fill");
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
                // TODO: данная строка кода позволяет загрузить данные в таблицу "cAVADataSet.Test". При необходимости она может быть перемещена или удалена.
                CAVATableAdapter.Test(ref this.testTableAdapter, ref this.cAVADataSet, "Fill");
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
                // TODO: данная строка кода позволяет загрузить данные в таблицу "cAVADataSet.Test". При необходимости она может быть перемещена или удалена.
                CAVATableAdapter.Test(ref this.testTableAdapter, ref this.cAVADataSet, "Fill");

                this.Text = testDataGridView.Rows[TestRow].Cells[1].Value.ToString();
                tbTime.Text = Minute(Convert.ToInt32(testDataGridView.Rows[TestRow].Cells[2].Value.ToString()));
                if (testDataGridView.Rows[TestRow].Cells[3].Value.ToString() == "Описание к тесту отсутствует (Нажмите, чтобы изменить)")
                    tbDesc.Text = "TestCreaTOR ALEXALL";
                else
                    tbDesc.Text = testDataGridView.Rows[TestRow].Cells[3].Value.ToString();
            }
            catch (Exception)
            {

            }
            try
            {
                teacherDataGridView.CurrentCell = teacherDataGridView[0, t];
                subDataGridView.CurrentCell = subDataGridView[0, s];
                clasDataGridView.CurrentCell = clasDataGridView[0, c];
                pupilDataGridView.CurrentCell = pupilDataGridView[0, p];
                accDataGridView.CurrentCell = accDataGridView[0, a];
                testDataGridView.CurrentCell = testDataGridView[0, TestRow];
            }
            catch (Exception ex)
            {

            }
            if (Properties.Settings.Default.LANG == "BE")
            {
                btnStart.Text = "Пачаць";

            }
            else if (Properties.Settings.Default.LANG == "EN")
            {
                btnStart.Text = "Begin";

            }
            else
            {
                btnStart.Text = "Начать";
            }
            tbTime.Focus();
        }

        public string Minute(int Number)
        {
            string str;
            if ((Properties.Settings.Default.LANG == "BE") || (Properties.Settings.Default.LANG == "RU"))
            {
                if ((Number % 10 == 0) || (Number % 10 >= 5) || ((Number / 10) % 10 == 1))
                    str = Number.ToString() + " секунд";
                else if (Number % 10 == 1)
                    str = Number.ToString() + " секунда";
                else
                    str = Number.ToString() + " секунды";
                return str;
            }
            else
            {
                if (Number == 1)
                    str = Number.ToString() + " second";
                else
                    str = Number.ToString() + " seconds";
                return str;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form Task = Application.OpenForms["Task"];
            Task.Enabled = true;
            Task.Show();
            this.Close();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (accDataGridView.Rows[a].Cells[6].Value.ToString() == "")
            {
                accDataGridView.Rows[a].Cells[6].Value = 1;
            }
            else
            {
                accDataGridView.Rows[a].Cells[6].Value = Convert.ToInt32(accDataGridView.Rows[a].Cells[6].Value.ToString()) + 1;
            }
            try
            {

                teacherDataGridView.EndEdit();
                subBindingSource.EndEdit();
                clasBindingSource.EndEdit();
                pupilBindingSource.EndEdit();
                accBindingSource.EndEdit();

                CAVATableAdapter.Acc(ref accTableAdapter, ref cAVADataSet, "Update");
                CAVATableAdapter.Pupil(ref pupilTableAdapter, ref cAVADataSet, "Update");
                CAVATableAdapter.Clas(ref clasTableAdapter, ref cAVADataSet, "Update");
                CAVATableAdapter.Sub(ref subTableAdapter, ref cAVADataSet, "Update");
                CAVATableAdapter.Teacher(ref teacherTableAdapter, ref cAVADataSet, "Update");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CAVA.Test.Test T = new Test.Test();
            T.t = t;
            T.s = s;
            T.c = c;
            T.p = p;
            T.a = a;
            T.TestRow = TestRow;
            T.Show();
            a1 = false;
            this.Close();
        }

        private void TestOpen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (a1 == true)
            {
                Form Task = Application.OpenForms["Task"];
                Task.Enabled = true;
                Task.Show();
            }
        }
    }
}
