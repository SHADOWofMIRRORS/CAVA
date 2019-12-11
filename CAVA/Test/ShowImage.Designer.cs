namespace CAVA.Test
{
    partial class ShowImage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.MetroStyle = new MetroFramework.Components.MetroStyleManager(this.components);
            this.ImageBox = new System.Windows.Forms.PictureBox();
            this.timerShow = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.MetroStyle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // MetroStyle
            // 
            this.MetroStyle.Owner = this;
            this.MetroStyle.Style = MetroFramework.MetroColorStyle.Brown;
            this.MetroStyle.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // ImageBox
            // 
            this.ImageBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ImageBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImageBox.Location = new System.Drawing.Point(20, 60);
            this.ImageBox.Name = "ImageBox";
            this.ImageBox.Size = new System.Drawing.Size(760, 420);
            this.ImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImageBox.TabIndex = 91;
            this.ImageBox.TabStop = false;
            // 
            // timerShow
            // 
            this.timerShow.Tick += new System.EventHandler(this.timerShow_Tick);
            // 
            // ShowImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.ImageBox);
            this.MinimumSize = new System.Drawing.Size(400, 250);
            this.Name = "ShowImage";
            this.Style = MetroFramework.MetroColorStyle.Brown;
            this.Text = "ShowImage";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.ShowImage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MetroStyle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager MetroStyle;
        private System.Windows.Forms.PictureBox ImageBox;
        private System.Windows.Forms.Timer timerShow;
    }
}