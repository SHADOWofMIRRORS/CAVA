namespace CAVA
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btnStart = new System.Windows.Forms.Button();
            this.lWork = new System.Windows.Forms.Label();
            this.lTime = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.btnChooseTask = new System.Windows.Forms.Button();
            this.TextBoxDesc = new System.Windows.Forms.RichTextBox();
            this.metroToolTip1 = new MetroFramework.Components.MetroToolTip();
            this.FIOBox = new System.Windows.Forms.Label();
            this.panelCenter = new System.Windows.Forms.TableLayoutPanel();
            this.panelDesc = new System.Windows.Forms.TableLayoutPanel();
            this.panelTime = new System.Windows.Forms.TableLayoutPanel();
            this.panelWork = new System.Windows.Forms.TableLayoutPanel();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.panelCenter.SuspendLayout();
            this.panelDesc.SuspendLayout();
            this.panelTime.SuspendLayout();
            this.panelWork.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnStart.Enabled = false;
            this.btnStart.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btnStart.FlatAppearance.BorderSize = 3;
            this.btnStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Gulim", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(555, 56);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(123, 76);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Вперёд";
            this.metroToolTip1.SetToolTip(this.btnStart, "Нажмите чтобы начать работу");
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.button1_Click);
            // 
            // lWork
            // 
            this.lWork.AutoSize = true;
            this.lWork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lWork.Font = new System.Drawing.Font("Gulim", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lWork.ForeColor = System.Drawing.Color.White;
            this.lWork.Location = new System.Drawing.Point(3, 0);
            this.lWork.Name = "lWork";
            this.lWork.Size = new System.Drawing.Size(94, 46);
            this.lWork.TabIndex = 3;
            this.lWork.Text = "Работа: ";
            this.lWork.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lTime
            // 
            this.lTime.AutoSize = true;
            this.lTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lTime.Font = new System.Drawing.Font("Gulim", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lTime.ForeColor = System.Drawing.Color.White;
            this.lTime.Location = new System.Drawing.Point(3, 0);
            this.lTime.Name = "lTime";
            this.lTime.Size = new System.Drawing.Size(94, 66);
            this.lTime.TabIndex = 4;
            this.lTime.Text = "Время:";
            this.lTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelName.Font = new System.Drawing.Font("Gulim", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelName.ForeColor = System.Drawing.Color.White;
            this.labelName.Location = new System.Drawing.Point(103, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(575, 46);
            this.labelName.TabIndex = 7;
            this.labelName.Text = "WorkName";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTime.Font = new System.Drawing.Font("Gulim", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTime.ForeColor = System.Drawing.Color.White;
            this.labelTime.Location = new System.Drawing.Point(103, 0);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(575, 66);
            this.labelTime.TabIndex = 8;
            this.labelTime.Text = "Time";
            this.labelTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // btnChooseTask
            // 
            this.btnChooseTask.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnChooseTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnChooseTask.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnChooseTask.FlatAppearance.BorderSize = 3;
            this.btnChooseTask.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnChooseTask.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnChooseTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChooseTask.Font = new System.Drawing.Font("Gulim", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseTask.Location = new System.Drawing.Point(238, 51);
            this.btnChooseTask.Name = "btnChooseTask";
            this.btnChooseTask.Size = new System.Drawing.Size(211, 45);
            this.btnChooseTask.TabIndex = 19;
            this.btnChooseTask.Text = "Выбрать задание";
            this.metroToolTip1.SetToolTip(this.btnChooseTask, "Нажмите чтобы выбрать задание");
            this.btnChooseTask.UseVisualStyleBackColor = false;
            this.btnChooseTask.Click += new System.EventHandler(this.button6_Click);
            // 
            // TextBoxDesc
            // 
            this.TextBoxDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.TextBoxDesc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBoxDesc.Font = new System.Drawing.Font("Gulim", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextBoxDesc.ForeColor = System.Drawing.Color.White;
            this.TextBoxDesc.Location = new System.Drawing.Point(3, 3);
            this.TextBoxDesc.Name = "TextBoxDesc";
            this.TextBoxDesc.ReadOnly = true;
            this.TextBoxDesc.Size = new System.Drawing.Size(537, 129);
            this.TextBoxDesc.TabIndex = 21;
            this.TextBoxDesc.Text = "Description";
            // 
            // FIOBox
            // 
            this.FIOBox.AutoSize = true;
            this.FIOBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FIOBox.Font = new System.Drawing.Font("Gulim", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FIOBox.ForeColor = System.Drawing.Color.White;
            this.FIOBox.Location = new System.Drawing.Point(3, 0);
            this.FIOBox.MinimumSize = new System.Drawing.Size(600, 0);
            this.FIOBox.Name = "FIOBox";
            this.FIOBox.Size = new System.Drawing.Size(681, 37);
            this.FIOBox.TabIndex = 35;
            this.FIOBox.Text = "Pupil FirstName Lastname";
            this.FIOBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelCenter
            // 
            this.panelCenter.ColumnCount = 1;
            this.panelCenter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelCenter.Controls.Add(this.panelDesc, 0, 4);
            this.panelCenter.Controls.Add(this.panelTime, 0, 3);
            this.panelCenter.Controls.Add(this.btnChooseTask, 0, 1);
            this.panelCenter.Controls.Add(this.FIOBox, 0, 0);
            this.panelCenter.Controls.Add(this.panelWork, 0, 2);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(20, 60);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.RowCount = 5;
            this.panelCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.panelCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.68085F));
            this.panelCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.82979F));
            this.panelCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.14894F));
            this.panelCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.96809F));
            this.panelCenter.Size = new System.Drawing.Size(687, 376);
            this.panelCenter.TabIndex = 36;
            // 
            // panelDesc
            // 
            this.panelDesc.ColumnCount = 2;
            this.panelDesc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 543F));
            this.panelDesc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelDesc.Controls.Add(this.TextBoxDesc, 0, 0);
            this.panelDesc.Controls.Add(this.btnStart, 1, 0);
            this.panelDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesc.Location = new System.Drawing.Point(3, 238);
            this.panelDesc.Name = "panelDesc";
            this.panelDesc.RowCount = 1;
            this.panelDesc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelDesc.Size = new System.Drawing.Size(681, 135);
            this.panelDesc.TabIndex = 38;
            // 
            // panelTime
            // 
            this.panelTime.ColumnCount = 2;
            this.panelTime.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.panelTime.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelTime.Controls.Add(this.lTime, 0, 0);
            this.panelTime.Controls.Add(this.labelTime, 1, 0);
            this.panelTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTime.Location = new System.Drawing.Point(3, 166);
            this.panelTime.Name = "panelTime";
            this.panelTime.RowCount = 1;
            this.panelTime.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelTime.Size = new System.Drawing.Size(681, 66);
            this.panelTime.TabIndex = 37;
            // 
            // panelWork
            // 
            this.panelWork.ColumnCount = 2;
            this.panelWork.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.panelWork.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelWork.Controls.Add(this.lWork, 0, 0);
            this.panelWork.Controls.Add(this.labelName, 1, 0);
            this.panelWork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWork.Location = new System.Drawing.Point(3, 114);
            this.panelWork.Name = "panelWork";
            this.panelWork.RowCount = 1;
            this.panelWork.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelWork.Size = new System.Drawing.Size(681, 46);
            this.panelWork.TabIndex = 36;
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            this.metroStyleManager1.Style = MetroFramework.MetroColorStyle.Brown;
            this.metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(730, 456);
            this.Controls.Add(this.panelCenter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(670, 320);
            this.Name = "Main";
            this.ShadowType = MetroFramework.Forms.MetroForm.MetroFormShadowType.None;
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.Text = "CAVA V.4.0";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Admin_Load);
            this.VisibleChanged += new System.EventHandler(this.Main_VisibleChanged);
            this.panelCenter.ResumeLayout(false);
            this.panelCenter.PerformLayout();
            this.panelDesc.ResumeLayout(false);
            this.panelTime.ResumeLayout(false);
            this.panelTime.PerformLayout();
            this.panelWork.ResumeLayout(false);
            this.panelWork.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Label labelName;
        public System.Windows.Forms.Label labelTime;
        public System.Windows.Forms.Button btnStart;
        public System.Windows.Forms.Label lWork;
        public System.Windows.Forms.Label lTime;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button btnChooseTask;
        private System.Windows.Forms.RichTextBox TextBoxDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn sMSDataGridViewTextBoxColumn;
        private MetroFramework.Components.MetroToolTip metroToolTip1;
        public System.Windows.Forms.Label FIOBox;
        private System.Windows.Forms.TableLayoutPanel panelCenter;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private System.Windows.Forms.TableLayoutPanel panelDesc;
        private System.Windows.Forms.TableLayoutPanel panelTime;
        private System.Windows.Forms.TableLayoutPanel panelWork;
    }
}