namespace CAVA
{
    partial class mini
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mini));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.NI = new System.Windows.Forms.NotifyIcon(this.components);
            this.NICont = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateDataGridView = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iSREGDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.updateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cAVADataSet = new CAVA.CAVADataSet();
            this.btnStart = new MetroFramework.Controls.MetroTile();
            this.btnCreate = new MetroFramework.Controls.MetroTile();
            this.label1 = new System.Windows.Forms.Label();
            this.timerIsReg = new System.Windows.Forms.Timer(this.components);
            this.updateTableAdapter = new CAVA.CAVADataSetTableAdapters.UpdateTableAdapter();
            this.tableAdapterManager = new CAVA.CAVADataSetTableAdapters.TableAdapterManager();
            this.comboBox1 = new MetroFramework.Controls.MetroComboBox();
            this.metroStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.computersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.computersTableAdapter = new CAVA.CAVADataSetTableAdapters.ComputersTableAdapter();
            this.computersDataGridView = new System.Windows.Forms.DataGridView();
            this.computersId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.computersName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.computersTestName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.computersIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.computersTest_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.computersStart = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.computersStop = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.computersTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.computersState = new System.Windows.Forms.DataGridViewImageColumn();
            this.computersConnected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.NICont.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updateDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updateBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cAVADataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.computersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.computersDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Interval = 1000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // NI
            // 
            this.NI.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.NI.BalloonTipText = "Подождите, приложение запускается";
            this.NI.BalloonTipTitle = "CAVA";
            this.NI.ContextMenuStrip = this.NICont;
            this.NI.Icon = ((System.Drawing.Icon)(resources.GetObject("NI.Icon")));
            this.NI.Text = "CAVA";
            this.NI.Visible = true;
            this.NI.BalloonTipClicked += new System.EventHandler(this.NI_BalloonTipClicked);
            // 
            // NICont
            // 
            this.NICont.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.NICont.Name = "NICont";
            this.NICont.Size = new System.Drawing.Size(214, 26);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.settingsToolStripMenuItem.Text = "Настройки подключения";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // updateDataGridView
            // 
            this.updateDataGridView.AutoGenerateColumns = false;
            this.updateDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.updateDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.isDataGridViewTextBoxColumn,
            this.pathDataGridViewTextBoxColumn,
            this.iSREGDataGridViewCheckBoxColumn});
            this.updateDataGridView.DataSource = this.updateBindingSource;
            this.updateDataGridView.Location = new System.Drawing.Point(1, 355);
            this.updateDataGridView.Name = "updateDataGridView";
            this.updateDataGridView.Size = new System.Drawing.Size(300, 220);
            this.updateDataGridView.TabIndex = 7;
            this.updateDataGridView.Visible = false;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isDataGridViewTextBoxColumn
            // 
            this.isDataGridViewTextBoxColumn.DataPropertyName = "Is";
            this.isDataGridViewTextBoxColumn.HeaderText = "Is";
            this.isDataGridViewTextBoxColumn.Name = "isDataGridViewTextBoxColumn";
            // 
            // pathDataGridViewTextBoxColumn
            // 
            this.pathDataGridViewTextBoxColumn.DataPropertyName = "Path";
            this.pathDataGridViewTextBoxColumn.HeaderText = "Path";
            this.pathDataGridViewTextBoxColumn.Name = "pathDataGridViewTextBoxColumn";
            // 
            // iSREGDataGridViewCheckBoxColumn
            // 
            this.iSREGDataGridViewCheckBoxColumn.DataPropertyName = "ISREG";
            this.iSREGDataGridViewCheckBoxColumn.HeaderText = "ISREG";
            this.iSREGDataGridViewCheckBoxColumn.Name = "iSREGDataGridViewCheckBoxColumn";
            // 
            // updateBindingSource
            // 
            this.updateBindingSource.DataMember = "Update";
            this.updateBindingSource.DataSource = this.cAVADataSet;
            // 
            // cAVADataSet
            // 
            this.cAVADataSet.DataSetName = "CAVADataSet";
            this.cAVADataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(72, 89);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(160, 72);
            this.btnStart.Style = MetroFramework.MetroColorStyle.Brown;
            this.btnStart.TabIndex = 96;
            this.btnStart.Text = "Начать";
            this.btnStart.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnStart.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnStart.TileImage = ((System.Drawing.Image)(resources.GetObject("btnStart.TileImage")));
            this.btnStart.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnStart.UseTileImage = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.Location = new System.Drawing.Point(72, 189);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(160, 72);
            this.btnCreate.Style = MetroFramework.MetroColorStyle.Brown;
            this.btnCreate.TabIndex = 97;
            this.btnCreate.Text = "Создать";
            this.btnCreate.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnCreate.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnCreate.TileImage = ((System.Drawing.Image)(resources.GetObject("btnCreate.TileImage")));
            this.btnCreate.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnCreate.UseTileImage = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gulim", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(106, 296);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 20);
            this.label1.TabIndex = 98;
            this.label1.Text = "ALEX ALL";
            // 
            // timerIsReg
            // 
            this.timerIsReg.Enabled = true;
            this.timerIsReg.Interval = 500;
            this.timerIsReg.Tick += new System.EventHandler(this.timerIsReg_Tick);
            // 
            // updateTableAdapter
            // 
            this.updateTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.AccordanceLTableAdapter = null;
            this.tableAdapterManager.AccordanceResultsTableAdapter = null;
            this.tableAdapterManager.AccordanceRTableAdapter = null;
            this.tableAdapterManager.AccTableAdapter = null;
            this.tableAdapterManager.AnswerResultsTableAdapter = null;
            this.tableAdapterManager.AnswerTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ClasTableAdapter = null;
            this.tableAdapterManager.ComputersTableAdapter = null;
            this.tableAdapterManager.PupilTableAdapter = null;
            this.tableAdapterManager.QuestionsResultsTableAdapter = null;
            this.tableAdapterManager.QuestionsTableAdapter = null;
            this.tableAdapterManager.SubTableAdapter = null;
            this.tableAdapterManager.TableResultSettingsTableAdapter = null;
            this.tableAdapterManager.TeacherTableAdapter = null;
            this.tableAdapterManager.TestResultsTableAdapter = null;
            this.tableAdapterManager.TestTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = CAVA.CAVADataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.UpdateTableAdapter = this.updateTableAdapter;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ItemHeight = 23;
            this.comboBox1.Items.AddRange(new object[] {
            "RU",
            "BE",
            "EN"});
            this.comboBox1.Location = new System.Drawing.Point(236, 311);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(56, 29);
            this.comboBox1.Style = MetroFramework.MetroColorStyle.Brown;
            this.comboBox1.TabIndex = 99;
            this.comboBox1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.metroComboBox1_SelectedIndexChanged);
            // 
            // metroStyleManager
            // 
            this.metroStyleManager.Owner = this;
            this.metroStyleManager.Style = MetroFramework.MetroColorStyle.Brown;
            this.metroStyleManager.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // computersBindingSource
            // 
            this.computersBindingSource.DataMember = "Computers";
            this.computersBindingSource.DataSource = this.cAVADataSet;
            // 
            // computersTableAdapter
            // 
            this.computersTableAdapter.ClearBeforeFill = true;
            // 
            // computersDataGridView
            // 
            this.computersDataGridView.AllowUserToAddRows = false;
            this.computersDataGridView.AllowUserToDeleteRows = false;
            this.computersDataGridView.AutoGenerateColumns = false;
            this.computersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.computersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.computersId,
            this.computersName,
            this.computersTestName,
            this.computersIP,
            this.computersTest_Id,
            this.computersStart,
            this.computersStop,
            this.computersTime,
            this.computersState,
            this.computersConnected});
            this.computersDataGridView.DataSource = this.computersBindingSource;
            this.computersDataGridView.Location = new System.Drawing.Point(309, 106);
            this.computersDataGridView.Name = "computersDataGridView";
            this.computersDataGridView.ReadOnly = true;
            this.computersDataGridView.Size = new System.Drawing.Size(300, 220);
            this.computersDataGridView.TabIndex = 99;
            this.computersDataGridView.Visible = false;
            // 
            // computersId
            // 
            this.computersId.DataPropertyName = "Id";
            this.computersId.HeaderText = "Id";
            this.computersId.Name = "computersId";
            this.computersId.ReadOnly = true;
            this.computersId.Width = 29;
            // 
            // computersName
            // 
            this.computersName.DataPropertyName = "Name";
            this.computersName.HeaderText = "Name";
            this.computersName.Name = "computersName";
            this.computersName.ReadOnly = true;
            this.computersName.Width = 5;
            // 
            // computersTestName
            // 
            this.computersTestName.DataPropertyName = "TestName";
            this.computersTestName.HeaderText = "TestName";
            this.computersTestName.Name = "computersTestName";
            this.computersTestName.ReadOnly = true;
            this.computersTestName.Width = 30;
            // 
            // computersIP
            // 
            this.computersIP.DataPropertyName = "IP";
            this.computersIP.HeaderText = "IP";
            this.computersIP.Name = "computersIP";
            this.computersIP.ReadOnly = true;
            this.computersIP.Width = 30;
            // 
            // computersTest_Id
            // 
            this.computersTest_Id.DataPropertyName = "Test_Id";
            this.computersTest_Id.HeaderText = "Test_Id";
            this.computersTest_Id.Name = "computersTest_Id";
            this.computersTest_Id.ReadOnly = true;
            this.computersTest_Id.Width = 30;
            // 
            // computersStart
            // 
            this.computersStart.DataPropertyName = "Start";
            this.computersStart.HeaderText = "Start";
            this.computersStart.Name = "computersStart";
            this.computersStart.ReadOnly = true;
            this.computersStart.Width = 30;
            // 
            // computersStop
            // 
            this.computersStop.DataPropertyName = "Stop";
            this.computersStop.HeaderText = "Stop";
            this.computersStop.Name = "computersStop";
            this.computersStop.ReadOnly = true;
            this.computersStop.Width = 30;
            // 
            // computersTime
            // 
            this.computersTime.DataPropertyName = "Time";
            this.computersTime.HeaderText = "Time";
            this.computersTime.Name = "computersTime";
            this.computersTime.ReadOnly = true;
            this.computersTime.Width = 30;
            // 
            // computersState
            // 
            this.computersState.DataPropertyName = "State";
            this.computersState.HeaderText = "State";
            this.computersState.Name = "computersState";
            this.computersState.ReadOnly = true;
            this.computersState.Width = 30;
            // 
            // computersConnected
            // 
            this.computersConnected.DataPropertyName = "Connected";
            this.computersConnected.HeaderText = "Connected";
            this.computersConnected.Name = "computersConnected";
            this.computersConnected.ReadOnly = true;
            this.computersConnected.Width = 30;
            // 
            // mini
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 349);
            this.Controls.Add(this.computersDataGridView);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.updateDataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(298, 346);
            this.Name = "mini";
            this.Opacity = 0D;
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroForm.MetroFormShadowType.None;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Style = MetroFramework.MetroColorStyle.Brown;
            this.Tag = "Cava Enter";
            this.Text = "CAVA V.4.0";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mini_FormClosing);
            this.Load += new System.EventHandler(this.mini_Load);
            this.VisibleChanged += new System.EventHandler(this.mini_VisibleChanged);
            this.NICont.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.updateDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updateBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cAVADataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.computersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.computersDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.DataGridView updateDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn gameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn enterDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pVDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn powerDataGridViewTextBoxColumn;
        private System.Windows.Forms.ContextMenuStrip NICont;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        public System.Windows.Forms.NotifyIcon NI;
        private MetroFramework.Controls.MetroTile btnStart;
        private MetroFramework.Controls.MetroTile btnCreate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timerIsReg;
        private CAVADataSet cAVADataSet;
        private System.Windows.Forms.BindingSource updateBindingSource;
        private CAVADataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn isDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn iSREGDataGridViewCheckBoxColumn;
        private MetroFramework.Controls.MetroComboBox comboBox1;
        internal CAVADataSetTableAdapters.UpdateTableAdapter updateTableAdapter;
        private MetroFramework.Components.MetroStyleManager metroStyleManager;
        private System.Windows.Forms.BindingSource computersBindingSource;
        private CAVADataSetTableAdapters.ComputersTableAdapter computersTableAdapter;
        private System.Windows.Forms.DataGridView computersDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn computersId;
        private System.Windows.Forms.DataGridViewTextBoxColumn computersName;
        private System.Windows.Forms.DataGridViewTextBoxColumn computersTestName;
        private System.Windows.Forms.DataGridViewTextBoxColumn computersIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn computersTest_Id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn computersStart;
        private System.Windows.Forms.DataGridViewCheckBoxColumn computersStop;
        private System.Windows.Forms.DataGridViewTextBoxColumn computersTime;
        private System.Windows.Forms.DataGridViewImageColumn computersState;
        private System.Windows.Forms.DataGridViewCheckBoxColumn computersConnected;
    }
}