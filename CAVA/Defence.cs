using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Windows.Forms;

namespace CAVA
{
    public partial class Defence : MetroForm
    {

        public Defence()
        {
            InitializeComponent();
        }

        bool def = false;
        string s1 = "";
        string s2 = "";
        int i = 0;
        bool i1 = false;
        private void Defence_Load(object sender, EventArgs e)
        {
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
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.DarkGray;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Empty;
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            def = true;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            def = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Defence = s1;
            Properties.Settings.Default.Save();
            Application.Exit();
        }

        private void Defence_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'A' && i1 == true)
            {
                i++;
            }
            else
            {
                if (e.KeyChar == 'V' && i1 == true)
                {
                    i++;
                }
                else
                {
                    if (e.KeyChar == 'C' && i1 == true)
                    {
                        i++;
                    }
                }
            }
            if (i == 4)
            {
                button2.Enabled = true;
            }
        }

        private void Defence_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Delete && e.Shift) && def == true)
            {
                i1 = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
