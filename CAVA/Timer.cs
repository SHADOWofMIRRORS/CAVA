using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace CAVA
{
    public partial class Timer : MetroForm
    {
        public int tim;
        int s = 59;
        int a = 0;
        int b = 0;
        int pr;
        int c = 0;
        int d = 0;
        public string patht;
        double bar = 0;
        double barP = 100;
        int barPint;
        int barconst;
        public Timer()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void Timer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.ifo = 0;
            Properties.Settings.Default.Save();
            if (pr == 0)
            {
                if (e.CloseReason == CloseReason.UserClosing ||
                    e.CloseReason == CloseReason.TaskManagerClosing)

                {
                    e.Cancel = true;
                    panel1.Visible = true;
                    this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - 20, Screen.PrimaryScreen.WorkingArea.Height / 2 - 130);
                    this.TopMost = true;
                }



                else
                {

                }
            }

            
        }


        private void Timer_Load(object sender, EventArgs e)
        {
            try
            {
              
            }
            catch(Exception ex)
            {

            }
            try
            {
                
            }
            catch (Exception ex)
            {

            }
            if (Properties.Settings.Default.LANG == "BE")
            {
                label1.Text = "Заданне:";
                label2.Text = "Час выдадзена(хвіліны) :";
                label3.Text = "Часу засталося:";
                metroLabel1.Text = "Па-над ўсіх вокнаў";
                metroButton3.Text = @"З а в е р ш ы ц ь
п р а ц у";
                metroButton1.Text = "Паказаць анатацыі";
                metroButton2.Text = @"Запусціць файл
з заданнем
яшчэ раз";
            }
            else if (Properties.Settings.Default.LANG == "EN")
            {
                label1.Text = "Assignment:";
                label2.Text = "Time granted (minutes):";
                label3.Text = "Time left until:";
                metroLabel1.Text = "Always on top";
                metroButton3.Text = @"Exits";
                metroButton1.Text = "Show summaries";
                metroButton2.Text = @"Run the file with the job again";
            }
            else
            {
                label1.Text = "Задание:";
                label2.Text = "Отведённое время (минуты) :";
                label3.Text = "Осталось времени:";
                metroLabel1.Text = "Поверх всех окон";
                metroButton3.Text = @"З а к о н ч и т ь
р а б о т у";
                metroButton1.Text = "Показаць аннотации";
                metroButton2.Text = @"Запустить файл
с заданием
ещё раз";
            }
            try
            {

                try
                {
                    try
                    {
                        teacherDataGridView.CurrentCell = teacherDataGridView[0, Properties.Settings.Default.RT];
                        subDataGridView.CurrentCell = subDataGridView[0, Properties.Settings.Default.RS];
                        clasDataGridView.CurrentCell = clasDataGridView[0, Properties.Settings.Default.RC];
                        pupilDataGridView.CurrentCell = pupilDataGridView[0, Properties.Settings.Default.RP];
                        accDataGridView.CurrentCell = accDataGridView[0, Properties.Settings.Default.AccRow];
                    }
                    catch (Exception ex)
                    {

                    }
                    accDataGridView.Rows[Properties.Settings.Default.AccRow].Cells[7].Value = 1;
                    accBindingSource.EndEdit();
                   

                    Process.Start(@"" + Properties.Settings.Default.path + "");
                    if (accDataGridView.Rows[Properties.Settings.Default.AccRow].Cells[8].Value.ToString() == "")
                    {
                        accDataGridView.Rows[Properties.Settings.Default.AccRow].Cells[8].Value = 1;
                    }
                    else
                    {
                        accDataGridView.Rows[Properties.Settings.Default.AccRow].Cells[8].Value = Convert.ToInt32(accDataGridView.Rows[Properties.Settings.Default.AccRow].Cells[8].Value.ToString()) + 1;
                    }
                    accBindingSource.EndEdit();
                    
                    labelTimeV.Text = tim.ToString();
                    labelTask.Text = Properties.Settings.Default.name;
                    tim--;
                    if (Properties.Settings.Default.LANG == "RU")
                    {
                        labelTimeO.Text = tim.ToString() + " Мин";
                        labelTimeO2.Text = s.ToString() + " Сек";
                    }
                    else if (Properties.Settings.Default.LANG == "BE")
                    {
                        labelTimeO.Text = tim.ToString() + " Мін";
                        labelTimeO2.Text = s.ToString() + " Сек";
                    }
                    else
                    {
                        labelTimeO.Text = tim.ToString() + " Min";
                        labelTimeO2.Text = s.ToString() + " Sec";
                    }
                    bar = tim * 60 + 1;
                    barconst = tim * 60 + 1;
                    timer2.Start();
                }
                catch (Exception ex)
                {
                    if (Properties.Settings.Default.LANG == "BE")
                    {
                        MessageBox.Show("Запуск заданні адменены, Памылка: " + ex.Message, "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if  (Properties.Settings.Default.LANG == "RU")
                    {
                        MessageBox.Show("Запуск задания отменён, Ошибка: " + ex.Message, "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Run the task is canceled, error: " + ex.Message, "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    accDataGridView.Rows[Properties.Settings.Default.AccRow].Cells[7].Value = 0;
                    accBindingSource.EndEdit();
               
                    pr = 1;
                    Application.Exit();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                accDataGridView.Rows[Properties.Settings.Default.AccRow].Cells[2].Value = tim;
                accBindingSource.EndEdit();

                teacherDataGridView.CurrentCell = teacherDataGridView[0, Properties.Settings.Default.RT];
                subDataGridView.CurrentCell = subDataGridView[0, Properties.Settings.Default.RS];
                clasDataGridView.CurrentCell = clasDataGridView[0, Properties.Settings.Default.RC];
                pupilDataGridView.CurrentCell = pupilDataGridView[0, Properties.Settings.Default.RP];
                accDataGridView.CurrentCell = accDataGridView[0, Properties.Settings.Default.AccRow];

                if (tim < 0)
                {
                    try
                    {
                        accDataGridView.Rows[Properties.Settings.Default.AccRow].Cells[7].Value = 0;
                        accBindingSource.EndEdit();
                
                        accDataGridView.Rows[Properties.Settings.Default.AccRow].Cells[2].Value = tim;
                        accBindingSource.EndEdit();
              
                        reboot r1 = new reboot();
                        r1.halt(true, true);
                        timer2.Stop();
                    }
                    catch (Exception ex)
                    {
                        if (Properties.Settings.Default.LANG == "BE")
                        {
                            MessageBox.Show("Інфармацыя пра заданне не захавана, выхад адменены. Error: " + ex.Message, "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else if (Properties.Settings.Default.LANG == "RU")
                            MessageBox.Show("Информация о задании не сохранена, выход отменён. Error: " + ex.Message, "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        else
                            MessageBox.Show("The job information was not saved, the output was canceled. Error: " + ex.Message, "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                if (tim == 0 && s == 0)
                {
                    try
                    {
                        accDataGridView.Rows[Properties.Settings.Default.AccRow].Cells[7].Value = 0;
                        accBindingSource.EndEdit();
                        
                        accDataGridView.Rows[Properties.Settings.Default.AccRow].Cells[2].Value = tim;
                        accBindingSource.EndEdit();
                       
                        reboot r1 = new reboot();
                        r1.halt(true, true);
                        timer2.Stop();
                    }
                    catch (Exception ex)
                    {
                        if (Properties.Settings.Default.LANG == "BE")
                        {
                            MessageBox.Show("Інфармацыя пра заданне не захавана, выхад адменены. Error: " + ex.Message, "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else if (Properties.Settings.Default.LANG == "RU")
                            MessageBox.Show("Информация о задании не сохранена, выход отменён. Error: " + ex.Message, "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        else
                            MessageBox.Show("The job information was not saved, the output was canceled. Error: " + ex.Message, "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    }


                }
                else
                {
                    bar--;
                    barP = ((bar - 1) * 100) / barconst;
                    barPint = Convert.ToInt32(Math.Round(barP));
                    //Prog.Size = new Size(20, Convert.ToInt32(Math.Round(Convert.ToDouble((340 * barPint) / 100))));
                    Prog.Location = new Point(0, 350 - Convert.ToInt32(Math.Round(Convert.ToDouble((340 * barPint) / 100))));

                    Properties.Settings.Default.tim = tim;
                    Properties.Settings.Default.s = s;
                    Properties.Settings.Default.ifo = 1;
                    Properties.Settings.Default.Save();
                    if (s == 0)
                    {

                        s = s + 59;
                        if (Properties.Settings.Default.LANG == "RU")
                        {
                            labelTimeO2.Text = s.ToString() + " Сек";
                            tim--;
                            labelTimeO.Text = tim.ToString() + " Мин";
                        }
                        else if (Properties.Settings.Default.LANG == "BE")
                        {
                            labelTimeO2.Text = s.ToString() + " Сек";
                            tim--;
                            labelTimeO.Text = tim.ToString() + " Мін";
                        }
                        else
                        {
                            labelTimeO2.Text = s.ToString() + " Sec";
                            tim--;
                            labelTimeO.Text = tim.ToString() + " Min";
                        }
                    }
                    else
                    {
                        s--;
                        if ((Properties.Settings.Default.LANG == "RU") || (Properties.Settings.Default.LANG == "BE"))
                            labelTimeO2.Text = s.ToString() + " Сек";
                        else
                            labelTimeO2.Text = s.ToString() + " Sec";
                    }
                    if (tim == 15 && a == 0 && s == 0)
                    {
                        SoundPlayer sp = new SoundPlayer(Application.StartupPath + @"\15.wav");
                        sp.Play();
                        if (Properties.Settings.Default.LANG == "BE")
                        {
                            notifyIcon1.BalloonTipText = "Да завяршэння працы засталося хвілін: 15";
                        }
                        else if (Properties.Settings.Default.LANG == "RU")
                            notifyIcon1.BalloonTipText = "До завершения работы осталось минут: 15";
                        else
                            notifyIcon1.BalloonTipText = "Minutes left before the end: 15";
                        notifyIcon1.ShowBalloonTip(15);
                        a++;
                    }
                    if (tim == 10 && b == 0 && s == 0)
                    {
                        SoundPlayer sp = new SoundPlayer(Application.StartupPath + @"\10.wav");
                        sp.Play();
                        if (Properties.Settings.Default.LANG == "BE")
                        {
                            notifyIcon1.BalloonTipText = "Да завяршэння працы засталося хвілін: 10";
                        }
                        else if (Properties.Settings.Default.LANG == "RU")
                            notifyIcon1.BalloonTipText = "До завершения работы осталось минут: 10";
                        
                        else
                            notifyIcon1.BalloonTipText = "Minutes left before the end: 10";
                        notifyIcon1.ShowBalloonTip(10);
                        b++;
                    }
                    if (tim == 5 && c == 0 && s == 0)
                    {
                        SoundPlayer sp = new SoundPlayer(Application.StartupPath + @"\5.wav");
                        sp.Play();
                        if (Properties.Settings.Default.LANG == "BE")
                        {
                            notifyIcon1.BalloonTipText = "Да завяршэння працы засталося хвілін: 5";
                        }
                        else if (Properties.Settings.Default.LANG == "RU")
                            notifyIcon1.BalloonTipText = "До завершения работы осталось минут: 5";
                        else
                            notifyIcon1.BalloonTipText = "Minutes left before the end: 5";
                        notifyIcon1.ShowBalloonTip(5);
                        c++;
                    }
                    if (tim == 1 && d == 0 && s == 0)
                    {
                        SoundPlayer sp = new SoundPlayer(Application.StartupPath + @"\1.wav");
                        sp.Play();
                        if (Properties.Settings.Default.LANG == "BE")
                        {
                            notifyIcon1.BalloonTipText = "Да завяршэння працы засталося хвілін: 1";
                        }
                        else if (Properties.Settings.Default.LANG == "RU")
                            notifyIcon1.BalloonTipText = "До завершения работы осталось минут: 1";
                        else
                            notifyIcon1.BalloonTipText = "Minutes left before the end: 1";
                        notifyIcon1.ShowBalloonTip(5);
                        d++;
                    }
                }
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Properties.Settings.Default.LANG == "BE")
            {
                MessageBox.Show("Засталося: \nХвілін: " + tim + "\nСекунд: " + s + "", "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (Properties.Settings.Default.LANG == "RU")
            {
                MessageBox.Show("Осталось: \nМинут: " + tim + "\nСекунд: " + s + "", "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
                MessageBox.Show("Left: \nMinutes: " + tim + "\nSeconds: " + s + "", "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (Properties.Settings.Default.LANG == "BE")
            {
                MessageBox.Show("Засталося: \nХвілін: " + tim + "\nСекунд: " + s + "", "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (Properties.Settings.Default.LANG == "RU")
                {
                    MessageBox.Show("Осталось: \nМинут: " + tim + "\nСекунд: " + s + "", "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            else
                MessageBox.Show("Left: \nMinutes: " + tim + "\nSeconds: " + s + "", "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        
        }

        private void notifyIcon1_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            if (Properties.Settings.Default.LANG == "BE")
            {
                notifyIcon1.BalloonTipText = "Засталося Хвілін: " + tim + " Секунд: " + s + "";
                notifyIcon1.ShowBalloonTip(9);
            }
            else if (Properties.Settings.Default.LANG == "RU")
            {
                notifyIcon1.BalloonTipText = "Осталось Минут: " + tim + " Секунд: " + s + "";
                notifyIcon1.ShowBalloonTip(9);
            }
            else
            {
                notifyIcon1.BalloonTipText = "Left Minutes: " + tim + " Seconds: " + s + "";
                notifyIcon1.ShowBalloonTip(9);
            }

        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.LANG == "BE")
            {
                notifyIcon1.BalloonTipText = "Засталося Хвілін: " + tim + " Секунд: " + s + "";
            }
            else if (Properties.Settings.Default.LANG == "RU")
                notifyIcon1.BalloonTipText = "Осталось Минут: " + tim + " Секунд: " + s + "";
            else
                notifyIcon1.BalloonTipText = "Left Minutes: " + tim + " Seconds: " + s + "";
            notifyIcon1.ShowBalloonTip(9);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Properties.Settings.Default.Desc,"CAVA",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Properties.Settings.Default.Desc, "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Properties.Settings.Default.path);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"CAVA",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            DialogResult r = DialogResult.Cancel;
            if (Properties.Settings.Default.LANG == "BE")
            {
                r = MessageBox.Show("Вы сапраўды хочаце датэрмінова завяршыць працу ? Час будзе захаваны. Не забудзьцеся захаваць файл з заданнем! Камбінацыя клавіш на клавіятуры: (CTRL+S)", "CAVA", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            }
            else if (Properties.Settings.Default.LANG == "RU")
                r = MessageBox.Show("Вы действительно хотите досрочно завершить работу ? Время будет сохранено. Не забудьте сохранить файл с заданием! Комбинация клавиш на клавиатуре: (CTRL+S)", "CAVA", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            else
                r = MessageBox.Show("Do you really want to finish the job ahead of schedule? The time will be saved. Do not forget to save the file with the task! The key combination on the keyboard: (CTRL + S) ", " CAVA ", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (r == DialogResult.Yes)
            {
                try
                {
                    accDataGridView.Rows[Properties.Settings.Default.AccRow].Cells[7].Value = 0;
                    accBindingSource.EndEdit();
                 
                    accDataGridView.Rows[Properties.Settings.Default.AccRow].Cells[2].Value = tim;
                    accBindingSource.EndEdit();
             
                    Application.Exit();
                    reboot r1 = new reboot();
                    r1.halt(true, true);
                    timer2.Stop();
                }
                catch (Exception ex)
                {
                    if (Properties.Settings.Default.LANG == "BE")
                    {
                        MessageBox.Show("Інфармацыя пра заданне не захавана, выхад адменены. Error: " + ex.Message, "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.LANG == "RU")
                        MessageBox.Show("Информация о задании не сохранена, выход отменён. Error: " + ex.Message, "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    else
                        MessageBox.Show("The job information was not saved, the output was canceled. Error: " + ex.Message, "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void metroToggle1_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle1.Checked == true)
            {
                this.TopMost = true;
            }
            else
            {
                this.TopMost = false;
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (this.TopMost == true)
                metroToggle1.Checked = true;
            if (this.TopMost == false)
                metroToggle1.Checked = false;
        }

        private void Timer_Shown(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            //if (count == 20 && ScrR.Enabled != true)
            //{
            //    ScrOn.Start();
            //}
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            //if (ScrOn.Enabled != true && count1 == 70)
            //    ScrR.Start();
        }

        private void ScrR_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - count1, Screen.PrimaryScreen.WorkingArea.Height / 2 - 130);
            //panel1.Size = new Size(count1, 352);
            //count1 = count1 - 10;
            //if (count1 == 20)
            //{
            //    ScrR.Stop();
            //    count1 = 70;
            //}
        }

        private void ScrOn_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - count, Screen.PrimaryScreen.WorkingArea.Height / 2 - 130);
            //panel1.Size = new Size(count, 352);
            //count = count + 10;
            //if (count == 70)
            //{
            //    ScrOn.Stop();
            //    count = 20;
            //}
        }

        private void panel2_MouseEnter(object sender, EventArgs e)
        {
            //if (count == 20 && ScrR.Enabled != true)
            //{
            //    ScrOn.Start();
            //}
        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {

        }

        private void panel1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - 320, Screen.PrimaryScreen.WorkingArea.Height / 2 - 130);
        }

        private void Prog_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Prog_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - 320, Screen.PrimaryScreen.WorkingArea.Height / 2 - 130);
        }
    }
}
