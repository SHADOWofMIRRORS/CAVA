using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CAVA.Test
{
    public partial class ShowImage : MetroForm
    {
        public ShowImage()
        {
            InitializeComponent();
        }

        public System.Drawing.Image Image;

        public string Header;

        private void ShowImage_Load(object sender, EventArgs e)
        {
            timerShow.Enabled = true;
        }

        private void timerShow_Tick(object sender, EventArgs e)
        {
            timerShow.Stop();
            this.Text = Header;
            ImageBox.Image = Image;
        }
    }
}
