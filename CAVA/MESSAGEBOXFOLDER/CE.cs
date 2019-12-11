using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AnimatorNS;
using System.Diagnostics;

namespace CAVA
{
    public partial class CE : Form
    {
        public CE()
        {
            InitializeComponent();
        }
        private Int32 tmpX;
        private Int32 tmpY;
        private bool flMove = false;
        int prov = 0;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            prov++;
            if (prov >= 2)
            {
                for (int i = 0; i < 20; i++)
                {
                    System.Threading.Thread.Sleep(35);
                    this.Opacity = this.Opacity - 0.1;

                }
                Form a = Application.OpenForms[0];
                a.Show();
                a.Opacity = 100;
                this.Close();
            }
        }

        private void CE_Load(object sender, EventArgs e)
        {
            this.Activate();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Form il = Application.OpenForms[0];
            il.Opacity = 100;
            il.ShowInTaskbar = true;
            this.Close();
        }

        private void CE_MouseUp(object sender, MouseEventArgs e)
        {
            flMove = false;
        }

        private void CE_MouseDown(object sender, MouseEventArgs e)
        {
            tmpX = Cursor.Position.X;
            tmpY = Cursor.Position.Y;
            flMove = true;
        }

        private void CE_MouseMove(object sender, MouseEventArgs e)
        {
            if (flMove)
            {
                this.Left = this.Left + (Cursor.Position.X - tmpX);
                this.Top = this.Top + (Cursor.Position.Y - tmpY);

                tmpX = Cursor.Position.X;
                tmpY = Cursor.Position.Y;
            }
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            tmpX = Cursor.Position.X;
            tmpY = Cursor.Position.Y;
            flMove = true;
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            flMove = false;
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (flMove)
            {
                this.Left = this.Left + (Cursor.Position.X - tmpX);
                this.Top = this.Top + (Cursor.Position.Y - tmpY);

                tmpX = Cursor.Position.X;
                tmpY = Cursor.Position.Y;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < 20; i++)
            {
                System.Threading.Thread.Sleep(35);
                this.Opacity = this.Opacity - 0.1;

            }
            Form a = Application.OpenForms[0];
            a.Show();
            a.Opacity = 100;
            this.Close();
        }

        private void CE_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            flMove = false;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            tmpX = Cursor.Position.X;
            tmpY = Cursor.Position.Y;
            flMove = true;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (flMove)
            {
                this.Left = this.Left + (Cursor.Position.X - tmpX);
                this.Top = this.Top + (Cursor.Position.Y - tmpY);

                tmpX = Cursor.Position.X;
                tmpY = Cursor.Position.Y;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void timer2_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //Random r = new Random();
            //string s1 = "Подготовка параметров.";
            //string s2 = "Инициализация сборки.";
            //string s3 = "Проверка подключения к серверу";
            //string s4 = "Загрузка информации";
            //string s5 = "Установка независимых параметров";
            //int i = r.Next(0,6);
            //if (i==1)
            //{
            //    label1.Text = s1;
            //}
            //if (i == 2)
            //{
            //    label1.Text = s2;
            //}
            //if (i == 3)
            //{
            //    label1.Text = s3;
            //}
            //if (i == 4)
            //{
            //    label1.Text = s4;
            //}
            //if (i == 5)
            //{
            //    label1.Text = s5;
            //}
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
