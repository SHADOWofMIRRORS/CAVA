using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Xml;
using System.IO;
using System.DirectoryServices;
using CAVA.MESSAGEBOXFOLDER;

namespace CAVA
{
    public partial class EnterSettings : Form
    {
        public EnterSettings()
        {
            InitializeComponent();
        }
        Configuration c;
        OpenFileDialog ofd = new OpenFileDialog();
        string filepath;
        int px = 0;
        public int i = 0;

        AL.AL AL = new AL.AL();
        private void EnterSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.load = 1;
            Properties.Settings.Default.Save();
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (tbServer.Text.Length > 0 &&
    tbDb.Text.Length > 0 &&
    tbUser.Text.Length > 0 &&
    tbPass.Text.Length > 0)
            {
                try
                {
                    string s = AL.Encoding(@"Server=" + tbServer.Text + ";Database=" + tbDb.Text + ";User Id=" + tbUser.Text + ";Password=" + tbPass.Text + ";");
                    System.IO.File.WriteAllText(Application.StartupPath + @"\ConnectString.TTOR", s, Encoding.UTF8);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "AA7", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены", "AA7", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void tbUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
