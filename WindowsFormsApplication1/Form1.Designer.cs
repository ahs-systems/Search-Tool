namespace WindowsFormsApplication1
{
    partial class frmSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearch));
            this.lstResult = new System.Windows.Forms.ListBox();
            this.txtOCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmpNo = new System.Windows.Forms.TextBox();
            this.lblMsg = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.myNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuSendEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFile126 = new MBGlassStyleButton.MBGlassButton();
            this.btnFile2 = new MBGlassStyleButton.MBGlassButton();
            this.btnFile6 = new MBGlassStyleButton.MBGlassButton();
            this.btnBanks = new MBGlassStyleButton.MBGlassButton();
            this.txtTCG = new System.Windows.Forms.Label();
            this.timerClose = new System.Windows.Forms.Timer(this.components);
            this.btnRFLOA = new MBGlassStyleButton.MBGlassButton();
            this.btnRehire = new MBGlassStyleButton.MBGlassButton();
            this.mbUserLatestLogin = new MBGlassStyleButton.MBGlassButton();
            this.btnPriors = new MBGlassStyleButton.MBGlassButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPayPeriod = new System.Windows.Forms.Label();
            this.btnAHS_AA_Terms = new MBGlassStyleButton.MBGlassButton();
            this.btnTrans = new MBGlassStyleButton.MBGlassButton();
            this.btnUserTrainings = new MBGlassStyleButton.MBGlassButton();
            this.btnClearLocks = new MBGlassStyleButton.MBGlassButton();
            this.btnGetLDAP = new MBGlassStyleButton.MBGlassButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnExceptionLookup = new MBGlassStyleButton.MBGlassButton();
            this.btnItemsReport = new MBGlassStyleButton.MBGlassButton();
            this.mnuCopyFromList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuCopyEmpNum = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopyEmpName = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopyBothNameAndNum = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSickOnStat = new MBGlassStyleButton.MBGlassButton();
            this.btnTL_SYS = new MBGlassStyleButton.MBGlassButton();
            this.btnAA_Exception = new MBGlassStyleButton.MBGlassButton();
            this.btnV_FireCategories = new MBGlassStyleButton.MBGlassButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabMisc = new System.Windows.Forms.TabPage();
            this.tabFormattingTools = new System.Windows.Forms.TabPage();
            this.btnLOAwithNoRptTime = new MBGlassStyleButton.MBGlassButton();
            this.tabSearch = new System.Windows.Forms.TabPage();
            this.btnSendEmail = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.mnuCopyFromList.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabMisc.SuspendLayout();
            this.tabFormattingTools.SuspendLayout();
            this.tabSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstResult
            // 
            this.lstResult.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lstResult.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lstResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lstResult.FormattingEnabled = true;
            this.lstResult.ItemHeight = 16;
            this.lstResult.Location = new System.Drawing.Point(16, 41);
            this.lstResult.Name = "lstResult";
            this.lstResult.Size = new System.Drawing.Size(410, 82);
            this.lstResult.TabIndex = 1;
            this.lstResult.Click += new System.EventHandler(this.lstResult_Click);
            this.lstResult.SelectedIndexChanged += new System.EventHandler(this.lstResult_Click);
            this.lstResult.DoubleClick += new System.EventHandler(this.lstResult_DoubleClick);
            this.lstResult.MouseLeave += new System.EventHandler(this.lstResult_MouseLeave);
            this.lstResult.MouseHover += new System.EventHandler(this.lstResult_MouseHover);
            this.lstResult.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lstResult_MouseUp);
            // 
            // txtOCode
            // 
            this.txtOCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtOCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOCode.Location = new System.Drawing.Point(96, 9);
            this.txtOCode.Name = "txtOCode";
            this.txtOCode.Size = new System.Drawing.Size(65, 22);
            this.txtOCode.TabIndex = 2;
            this.txtOCode.TextChanged += new System.EventHandler(this.txtOCode_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.792453F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(35, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Occupation:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.792453F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(198, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Emp No or LastName:";
            // 
            // txtEmpNo
            // 
            this.txtEmpNo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtEmpNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmpNo.Location = new System.Drawing.Point(305, 8);
            this.txtEmpNo.Name = "txtEmpNo";
            this.txtEmpNo.Size = new System.Drawing.Size(100, 22);
            this.txtEmpNo.TabIndex = 4;
            this.txtEmpNo.TextChanged += new System.EventHandler(this.txtEmpNo_TextChanged);
            // 
            // lblMsg
            // 
            this.lblMsg.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMsg.AutoSize = true;
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(16, 158);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 17);
            this.lblMsg.TabIndex = 6;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // myNotifyIcon
            // 
            this.myNotifyIcon.BalloonTipText = "Click to open again";
            this.myNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("myNotifyIcon.Icon")));
            this.myNotifyIcon.Text = "Search";
            this.myNotifyIcon.Visible = true;
            this.myNotifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.myNotifyIcon_MouseClick);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(6, 15);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(183, 19);
            this.dateTimePicker1.TabIndex = 7;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSendEmail});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(189, 26);
            // 
            // mnuSendEmail
            // 
            this.mnuSendEmail.Name = "mnuSendEmail";
            this.mnuSendEmail.Size = new System.Drawing.Size(188, 22);
            this.mnuSendEmail.Text = "Send Email To SSO";
            // 
            // btnFile126
            // 
            this.btnFile126.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnFile126.BackColor = System.Drawing.Color.Transparent;
            this.btnFile126.BaseColor = System.Drawing.Color.LightGray;
            this.btnFile126.BaseStrokeColor = System.Drawing.Color.Silver;
            this.btnFile126.FlatAppearance.BorderSize = 0;
            this.btnFile126.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFile126.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.792453F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFile126.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnFile126.Image = ((System.Drawing.Image)(resources.GetObject("btnFile126.Image")));
            this.btnFile126.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFile126.ImageSize = new System.Drawing.Size(24, 24);
            this.btnFile126.Location = new System.Drawing.Point(15, 14);
            this.btnFile126.MenuListPosition = new System.Drawing.Point(0, 0);
            this.btnFile126.Name = "btnFile126";
            this.btnFile126.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnFile126.OnStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnFile126.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnFile126.PressStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnFile126.Size = new System.Drawing.Size(173, 42);
            this.btnFile126.TabIndex = 15;
            this.btnFile126.Text = "FTP File 1,2 and 6 then\r\nFormat File 2 and 6 ";
            this.btnFile126.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFile126.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFile126.UseVisualStyleBackColor = false;
            this.btnFile126.Click += new System.EventHandler(this.btnFile126_Click);
            // 
            // btnFile2
            // 
            this.btnFile2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnFile2.BackColor = System.Drawing.Color.Transparent;
            this.btnFile2.BaseColor = System.Drawing.Color.LightGray;
            this.btnFile2.BaseStrokeColor = System.Drawing.Color.Silver;
            this.btnFile2.FlatAppearance.BorderSize = 0;
            this.btnFile2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFile2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnFile2.Image = ((System.Drawing.Image)(resources.GetObject("btnFile2.Image")));
            this.btnFile2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFile2.ImageSize = new System.Drawing.Size(24, 24);
            this.btnFile2.Location = new System.Drawing.Point(440, 9);
            this.btnFile2.MenuListPosition = new System.Drawing.Point(0, 0);
            this.btnFile2.Name = "btnFile2";
            this.btnFile2.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnFile2.OnStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnFile2.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnFile2.PressStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnFile2.Radius = 5;
            this.btnFile2.Size = new System.Drawing.Size(141, 42);
            this.btnFile2.TabIndex = 16;
            this.btnFile2.Text = "Format File 2";
            this.btnFile2.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnFile2.UseVisualStyleBackColor = false;
            this.btnFile2.Click += new System.EventHandler(this.btnFile2_Click);
            // 
            // btnFile6
            // 
            this.btnFile6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnFile6.BackColor = System.Drawing.Color.Transparent;
            this.btnFile6.BaseColor = System.Drawing.Color.LightGray;
            this.btnFile6.BaseStrokeColor = System.Drawing.Color.Silver;
            this.btnFile6.FlatAppearance.BorderSize = 0;
            this.btnFile6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFile6.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnFile6.Image = ((System.Drawing.Image)(resources.GetObject("btnFile6.Image")));
            this.btnFile6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFile6.ImageSize = new System.Drawing.Size(24, 24);
            this.btnFile6.Location = new System.Drawing.Point(440, 57);
            this.btnFile6.MenuListPosition = new System.Drawing.Point(0, 0);
            this.btnFile6.Name = "btnFile6";
            this.btnFile6.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnFile6.OnStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnFile6.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnFile6.PressStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnFile6.Radius = 5;
            this.btnFile6.Size = new System.Drawing.Size(141, 42);
            this.btnFile6.TabIndex = 17;
            this.btnFile6.Text = "Format File 6";
            this.btnFile6.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnFile6.UseVisualStyleBackColor = false;
            this.btnFile6.Click += new System.EventHandler(this.btnFile6_Click);
            // 
            // btnBanks
            // 
            this.btnBanks.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnBanks.BackColor = System.Drawing.Color.Transparent;
            this.btnBanks.BaseColor = System.Drawing.Color.LightGray;
            this.btnBanks.BaseStrokeColor = System.Drawing.Color.Silver;
            this.btnBanks.FlatAppearance.BorderSize = 0;
            this.btnBanks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBanks.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnBanks.Image = ((System.Drawing.Image)(resources.GetObject("btnBanks.Image")));
            this.btnBanks.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBanks.ImageSize = new System.Drawing.Size(24, 24);
            this.btnBanks.Location = new System.Drawing.Point(4, 105);
            this.btnBanks.MenuListPosition = new System.Drawing.Point(0, 0);
            this.btnBanks.Name = "btnBanks";
            this.btnBanks.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnBanks.OnStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnBanks.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnBanks.PressStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnBanks.Radius = 5;
            this.btnBanks.Size = new System.Drawing.Size(141, 42);
            this.btnBanks.TabIndex = 18;
            this.btnBanks.Text = "Off Codes vs \r\nBanks";
            this.btnBanks.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBanks.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBanks.UseVisualStyleBackColor = false;
            this.btnBanks.Click += new System.EventHandler(this.btnBanks_Click);
            // 
            // txtTCG
            // 
            this.txtTCG.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTCG.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtTCG.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtTCG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTCG.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.txtTCG.Location = new System.Drawing.Point(16, 132);
            this.txtTCG.Name = "txtTCG";
            this.txtTCG.Size = new System.Drawing.Size(410, 23);
            this.txtTCG.TabIndex = 20;
            this.txtTCG.Text = "label3";
            this.txtTCG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtTCG.Visible = false;
            this.txtTCG.DoubleClick += new System.EventHandler(this.txtTCG_DoubleClick);
            this.txtTCG.MouseLeave += new System.EventHandler(this.txtTCG_MouseLeave);
            this.txtTCG.MouseHover += new System.EventHandler(this.txtTCG_MouseHover);
            // 
            // timerClose
            // 
            this.timerClose.Interval = 3600000;
            this.timerClose.Tick += new System.EventHandler(this.timerClose_Tick);
            // 
            // btnRFLOA
            // 
            this.btnRFLOA.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnRFLOA.BackColor = System.Drawing.Color.Transparent;
            this.btnRFLOA.BaseColor = System.Drawing.Color.LightGray;
            this.btnRFLOA.BaseStrokeColor = System.Drawing.Color.Silver;
            this.btnRFLOA.FlatAppearance.BorderSize = 0;
            this.btnRFLOA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRFLOA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRFLOA.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnRFLOA.Image = ((System.Drawing.Image)(resources.GetObject("btnRFLOA.Image")));
            this.btnRFLOA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRFLOA.ImageSize = new System.Drawing.Size(24, 24);
            this.btnRFLOA.Location = new System.Drawing.Point(149, 57);
            this.btnRFLOA.MenuListPosition = new System.Drawing.Point(0, 0);
            this.btnRFLOA.Name = "btnRFLOA";
            this.btnRFLOA.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnRFLOA.OnStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnRFLOA.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnRFLOA.PressStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnRFLOA.Radius = 5;
            this.btnRFLOA.Size = new System.Drawing.Size(141, 42);
            this.btnRFLOA.TabIndex = 21;
            this.btnRFLOA.Text = "Return From LOA";
            this.btnRFLOA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRFLOA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRFLOA.UseVisualStyleBackColor = false;
            this.btnRFLOA.Click += new System.EventHandler(this.btnRFLOA_Click);
            // 
            // btnRehire
            // 
            this.btnRehire.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnRehire.BackColor = System.Drawing.Color.Transparent;
            this.btnRehire.BaseColor = System.Drawing.Color.LightGray;
            this.btnRehire.BaseStrokeColor = System.Drawing.Color.Silver;
            this.btnRehire.FlatAppearance.BorderSize = 0;
            this.btnRehire.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRehire.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnRehire.Image = ((System.Drawing.Image)(resources.GetObject("btnRehire.Image")));
            this.btnRehire.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRehire.ImageSize = new System.Drawing.Size(24, 24);
            this.btnRehire.Location = new System.Drawing.Point(149, 9);
            this.btnRehire.MenuListPosition = new System.Drawing.Point(0, 0);
            this.btnRehire.Name = "btnRehire";
            this.btnRehire.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnRehire.OnStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnRehire.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnRehire.PressStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnRehire.Radius = 5;
            this.btnRehire.Size = new System.Drawing.Size(141, 42);
            this.btnRehire.TabIndex = 22;
            this.btnRehire.Text = "Rehires";
            this.btnRehire.UseVisualStyleBackColor = false;
            this.btnRehire.Click += new System.EventHandler(this.btnRehire_Click);
            // 
            // mbUserLatestLogin
            // 
            this.mbUserLatestLogin.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.mbUserLatestLogin.BackColor = System.Drawing.Color.Transparent;
            this.mbUserLatestLogin.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.mbUserLatestLogin.BaseStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.mbUserLatestLogin.FlatAppearance.BorderSize = 0;
            this.mbUserLatestLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mbUserLatestLogin.ForeColor = System.Drawing.Color.DarkBlue;
            this.mbUserLatestLogin.Image = ((System.Drawing.Image)(resources.GetObject("mbUserLatestLogin.Image")));
            this.mbUserLatestLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mbUserLatestLogin.ImageSize = new System.Drawing.Size(24, 24);
            this.mbUserLatestLogin.Location = new System.Drawing.Point(206, 61);
            this.mbUserLatestLogin.MenuListPosition = new System.Drawing.Point(0, 0);
            this.mbUserLatestLogin.Name = "mbUserLatestLogin";
            this.mbUserLatestLogin.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.mbUserLatestLogin.OnStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.mbUserLatestLogin.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.mbUserLatestLogin.PressStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.mbUserLatestLogin.Size = new System.Drawing.Size(173, 42);
            this.mbUserLatestLogin.TabIndex = 25;
            this.mbUserLatestLogin.Text = "User Latest Login";
            this.mbUserLatestLogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mbUserLatestLogin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.mbUserLatestLogin.UseVisualStyleBackColor = false;
            this.mbUserLatestLogin.Click += new System.EventHandler(this.mbUserLatestLogin_Click);
            // 
            // btnPriors
            // 
            this.btnPriors.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPriors.BackColor = System.Drawing.Color.Transparent;
            this.btnPriors.BaseColor = System.Drawing.Color.LightGray;
            this.btnPriors.BaseStrokeColor = System.Drawing.Color.Silver;
            this.btnPriors.FlatAppearance.BorderSize = 0;
            this.btnPriors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPriors.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPriors.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnPriors.Image = ((System.Drawing.Image)(resources.GetObject("btnPriors.Image")));
            this.btnPriors.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPriors.ImageSize = new System.Drawing.Size(24, 24);
            this.btnPriors.Location = new System.Drawing.Point(4, 153);
            this.btnPriors.MenuListPosition = new System.Drawing.Point(0, 0);
            this.btnPriors.Name = "btnPriors";
            this.btnPriors.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnPriors.OnStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnPriors.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnPriors.PressStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnPriors.Radius = 5;
            this.btnPriors.Size = new System.Drawing.Size(141, 42);
            this.btnPriors.TabIndex = 26;
            this.btnPriors.Text = "Prior Pay \r\nPeriod Adjust";
            this.btnPriors.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPriors.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPriors.UseVisualStyleBackColor = false;
            this.btnPriors.Click += new System.EventHandler(this.btnPriors_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.lblPayPeriod);
            this.groupBox1.Location = new System.Drawing.Point(16, 173);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 42);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            // 
            // lblPayPeriod
            // 
            this.lblPayPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayPeriod.Location = new System.Drawing.Point(195, 12);
            this.lblPayPeriod.Name = "lblPayPeriod";
            this.lblPayPeriod.Size = new System.Drawing.Size(111, 23);
            this.lblPayPeriod.TabIndex = 8;
            this.lblPayPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAHS_AA_Terms
            // 
            this.btnAHS_AA_Terms.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAHS_AA_Terms.BackColor = System.Drawing.Color.Transparent;
            this.btnAHS_AA_Terms.BaseColor = System.Drawing.Color.LightGray;
            this.btnAHS_AA_Terms.BaseStrokeColor = System.Drawing.Color.Silver;
            this.btnAHS_AA_Terms.FlatAppearance.BorderSize = 0;
            this.btnAHS_AA_Terms.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAHS_AA_Terms.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.792453F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAHS_AA_Terms.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnAHS_AA_Terms.Image = ((System.Drawing.Image)(resources.GetObject("btnAHS_AA_Terms.Image")));
            this.btnAHS_AA_Terms.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAHS_AA_Terms.ImageSize = new System.Drawing.Size(24, 24);
            this.btnAHS_AA_Terms.Location = new System.Drawing.Point(4, 9);
            this.btnAHS_AA_Terms.MenuListPosition = new System.Drawing.Point(0, 0);
            this.btnAHS_AA_Terms.Name = "btnAHS_AA_Terms";
            this.btnAHS_AA_Terms.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAHS_AA_Terms.OnStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnAHS_AA_Terms.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnAHS_AA_Terms.PressStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnAHS_AA_Terms.Radius = 5;
            this.btnAHS_AA_Terms.Size = new System.Drawing.Size(141, 42);
            this.btnAHS_AA_Terms.TabIndex = 28;
            this.btnAHS_AA_Terms.Text = "AHS_AA_TERMS";
            this.btnAHS_AA_Terms.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAHS_AA_Terms.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAHS_AA_Terms.UseVisualStyleBackColor = false;
            this.btnAHS_AA_Terms.Click += new System.EventHandler(this.btnAHS_AA_Terms_Click);
            // 
            // btnTrans
            // 
            this.btnTrans.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnTrans.BackColor = System.Drawing.Color.Transparent;
            this.btnTrans.BaseColor = System.Drawing.Color.LightGray;
            this.btnTrans.BaseStrokeColor = System.Drawing.Color.Silver;
            this.btnTrans.FlatAppearance.BorderSize = 0;
            this.btnTrans.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTrans.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.792453F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrans.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnTrans.Image = ((System.Drawing.Image)(resources.GetObject("btnTrans.Image")));
            this.btnTrans.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTrans.ImageSize = new System.Drawing.Size(24, 24);
            this.btnTrans.Location = new System.Drawing.Point(4, 57);
            this.btnTrans.MenuListPosition = new System.Drawing.Point(0, 0);
            this.btnTrans.Name = "btnTrans";
            this.btnTrans.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnTrans.OnStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnTrans.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnTrans.PressStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnTrans.Radius = 5;
            this.btnTrans.Size = new System.Drawing.Size(141, 42);
            this.btnTrans.TabIndex = 29;
            this.btnTrans.Text = "AHS_AA_\r\nTRANSFER_RPT";
            this.btnTrans.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTrans.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnTrans.UseVisualStyleBackColor = false;
            this.btnTrans.Click += new System.EventHandler(this.btnTrans_Click);
            // 
            // btnUserTrainings
            // 
            this.btnUserTrainings.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnUserTrainings.BackColor = System.Drawing.Color.Transparent;
            this.btnUserTrainings.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.btnUserTrainings.BaseStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnUserTrainings.FlatAppearance.BorderSize = 0;
            this.btnUserTrainings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserTrainings.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.792453F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserTrainings.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnUserTrainings.Image = ((System.Drawing.Image)(resources.GetObject("btnUserTrainings.Image")));
            this.btnUserTrainings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserTrainings.ImageSize = new System.Drawing.Size(24, 24);
            this.btnUserTrainings.Location = new System.Drawing.Point(397, 109);
            this.btnUserTrainings.MenuListPosition = new System.Drawing.Point(0, 0);
            this.btnUserTrainings.Name = "btnUserTrainings";
            this.btnUserTrainings.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnUserTrainings.OnStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnUserTrainings.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnUserTrainings.PressStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnUserTrainings.Size = new System.Drawing.Size(173, 42);
            this.btnUserTrainings.TabIndex = 30;
            this.btnUserTrainings.Text = "Open SSRS \r\nUser Trainings";
            this.btnUserTrainings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUserTrainings.UseVisualStyleBackColor = false;
            this.btnUserTrainings.Click += new System.EventHandler(this.btnUserTrainings_Click);
            // 
            // btnClearLocks
            // 
            this.btnClearLocks.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnClearLocks.BackColor = System.Drawing.Color.Transparent;
            this.btnClearLocks.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.btnClearLocks.BaseStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnClearLocks.FlatAppearance.BorderSize = 0;
            this.btnClearLocks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearLocks.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnClearLocks.Image = ((System.Drawing.Image)(resources.GetObject("btnClearLocks.Image")));
            this.btnClearLocks.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearLocks.ImageSize = new System.Drawing.Size(24, 24);
            this.btnClearLocks.Location = new System.Drawing.Point(206, 14);
            this.btnClearLocks.MenuListPosition = new System.Drawing.Point(0, 0);
            this.btnClearLocks.Name = "btnClearLocks";
            this.btnClearLocks.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnClearLocks.OnStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnClearLocks.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnClearLocks.PressStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnClearLocks.Size = new System.Drawing.Size(173, 42);
            this.btnClearLocks.TabIndex = 31;
            this.btnClearLocks.Text = "Clear Locks (Lists)";
            this.btnClearLocks.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClearLocks.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClearLocks.UseVisualStyleBackColor = false;
            this.btnClearLocks.Click += new System.EventHandler(this.btnClearLocks_Click);
            // 
            // btnGetLDAP
            // 
            this.btnGetLDAP.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnGetLDAP.BackColor = System.Drawing.Color.Transparent;
            this.btnGetLDAP.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.btnGetLDAP.BaseStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnGetLDAP.FlatAppearance.BorderSize = 0;
            this.btnGetLDAP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetLDAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetLDAP.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnGetLDAP.Image = ((System.Drawing.Image)(resources.GetObject("btnGetLDAP.Image")));
            this.btnGetLDAP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGetLDAP.ImageSize = new System.Drawing.Size(24, 24);
            this.btnGetLDAP.Location = new System.Drawing.Point(16, 61);
            this.btnGetLDAP.MenuListPosition = new System.Drawing.Point(0, 0);
            this.btnGetLDAP.Name = "btnGetLDAP";
            this.btnGetLDAP.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnGetLDAP.OnStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnGetLDAP.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnGetLDAP.PressStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnGetLDAP.Size = new System.Drawing.Size(173, 42);
            this.btnGetLDAP.TabIndex = 32;
            this.btnGetLDAP.Text = "Get LDAP Username";
            this.btnGetLDAP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGetLDAP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGetLDAP.UseVisualStyleBackColor = false;
            this.btnGetLDAP.Click += new System.EventHandler(this.btnGetLDAP_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
            this.label3.Location = new System.Drawing.Point(5, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 25);
            this.label3.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Image = ((System.Drawing.Image)(resources.GetObject("label4.Image")));
            this.label4.Location = new System.Drawing.Point(170, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 25);
            this.label4.TabIndex = 24;
            // 
            // btnExceptionLookup
            // 
            this.btnExceptionLookup.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnExceptionLookup.BackColor = System.Drawing.Color.Transparent;
            this.btnExceptionLookup.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.btnExceptionLookup.BaseStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnExceptionLookup.FlatAppearance.BorderSize = 0;
            this.btnExceptionLookup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExceptionLookup.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnExceptionLookup.Image = ((System.Drawing.Image)(resources.GetObject("btnExceptionLookup.Image")));
            this.btnExceptionLookup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExceptionLookup.ImageSize = new System.Drawing.Size(24, 24);
            this.btnExceptionLookup.Location = new System.Drawing.Point(206, 109);
            this.btnExceptionLookup.MenuListPosition = new System.Drawing.Point(0, 0);
            this.btnExceptionLookup.Name = "btnExceptionLookup";
            this.btnExceptionLookup.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnExceptionLookup.OnStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnExceptionLookup.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnExceptionLookup.PressStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnExceptionLookup.Size = new System.Drawing.Size(173, 42);
            this.btnExceptionLookup.TabIndex = 33;
            this.btnExceptionLookup.Text = "Exception Lookup";
            this.btnExceptionLookup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExceptionLookup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExceptionLookup.UseVisualStyleBackColor = false;
            this.btnExceptionLookup.Click += new System.EventHandler(this.btnExceptionLookup_Click);
            // 
            // btnItemsReport
            // 
            this.btnItemsReport.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnItemsReport.BackColor = System.Drawing.Color.Transparent;
            this.btnItemsReport.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.btnItemsReport.BaseStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnItemsReport.FlatAppearance.BorderSize = 0;
            this.btnItemsReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnItemsReport.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnItemsReport.Image = ((System.Drawing.Image)(resources.GetObject("btnItemsReport.Image")));
            this.btnItemsReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnItemsReport.ImageSize = new System.Drawing.Size(24, 24);
            this.btnItemsReport.Location = new System.Drawing.Point(397, 14);
            this.btnItemsReport.MenuListPosition = new System.Drawing.Point(0, 0);
            this.btnItemsReport.Name = "btnItemsReport";
            this.btnItemsReport.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnItemsReport.OnStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnItemsReport.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnItemsReport.PressStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnItemsReport.Size = new System.Drawing.Size(173, 42);
            this.btnItemsReport.TabIndex = 34;
            this.btnItemsReport.Text = "Open Items Report";
            this.btnItemsReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnItemsReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnItemsReport.UseVisualStyleBackColor = false;
            this.btnItemsReport.Click += new System.EventHandler(this.btnItemsReport_Click);
            // 
            // mnuCopyFromList
            // 
            this.mnuCopyFromList.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.mnuCopyFromList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCopyEmpNum,
            this.mnuCopyEmpName,
            this.mnuCopyBothNameAndNum});
            this.mnuCopyFromList.Name = "mnuCopyFromList";
            this.mnuCopyFromList.Size = new System.Drawing.Size(311, 76);
            this.mnuCopyFromList.Text = "CopyFromList";
            // 
            // mnuCopyEmpNum
            // 
            this.mnuCopyEmpNum.Image = ((System.Drawing.Image)(resources.GetObject("mnuCopyEmpNum.Image")));
            this.mnuCopyEmpNum.Name = "mnuCopyEmpNum";
            this.mnuCopyEmpNum.Size = new System.Drawing.Size(310, 24);
            this.mnuCopyEmpNum.Text = "Copy Emp # to clipboard";
            this.mnuCopyEmpNum.Click += new System.EventHandler(this.mnuCopyEmpNum_Click);
            // 
            // mnuCopyEmpName
            // 
            this.mnuCopyEmpName.Image = ((System.Drawing.Image)(resources.GetObject("mnuCopyEmpName.Image")));
            this.mnuCopyEmpName.Name = "mnuCopyEmpName";
            this.mnuCopyEmpName.Size = new System.Drawing.Size(310, 24);
            this.mnuCopyEmpName.Text = "Copy Emp Name to clipboard";
            this.mnuCopyEmpName.Click += new System.EventHandler(this.mnuCopyEmpName_Click);
            // 
            // mnuCopyBothNameAndNum
            // 
            this.mnuCopyBothNameAndNum.Image = ((System.Drawing.Image)(resources.GetObject("mnuCopyBothNameAndNum.Image")));
            this.mnuCopyBothNameAndNum.Name = "mnuCopyBothNameAndNum";
            this.mnuCopyBothNameAndNum.Size = new System.Drawing.Size(310, 24);
            this.mnuCopyBothNameAndNum.Text = "Copy Both Emp Name and # to clipboard";
            this.mnuCopyBothNameAndNum.Click += new System.EventHandler(this.mnuCopyBothNameAndNum_Click);
            // 
            // btnSickOnStat
            // 
            this.btnSickOnStat.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSickOnStat.BackColor = System.Drawing.Color.Transparent;
            this.btnSickOnStat.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.btnSickOnStat.BaseStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSickOnStat.FlatAppearance.BorderSize = 0;
            this.btnSickOnStat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSickOnStat.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSickOnStat.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnSickOnStat.Image = ((System.Drawing.Image)(resources.GetObject("btnSickOnStat.Image")));
            this.btnSickOnStat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSickOnStat.ImageSize = new System.Drawing.Size(24, 24);
            this.btnSickOnStat.Location = new System.Drawing.Point(16, 109);
            this.btnSickOnStat.MenuListPosition = new System.Drawing.Point(0, 0);
            this.btnSickOnStat.Name = "btnSickOnStat";
            this.btnSickOnStat.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSickOnStat.OnStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnSickOnStat.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnSickOnStat.PressStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnSickOnStat.Size = new System.Drawing.Size(173, 42);
            this.btnSickOnStat.TabIndex = 35;
            this.btnSickOnStat.Text = "Upload Sick On A Stat file \r\nfrom ePeople to Boo DB";
            this.btnSickOnStat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSickOnStat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSickOnStat.UseVisualStyleBackColor = false;
            this.btnSickOnStat.Click += new System.EventHandler(this.btnSickOnStat_Click);
            // 
            // btnTL_SYS
            // 
            this.btnTL_SYS.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnTL_SYS.BackColor = System.Drawing.Color.Transparent;
            this.btnTL_SYS.BaseColor = System.Drawing.Color.LightGray;
            this.btnTL_SYS.BaseStrokeColor = System.Drawing.Color.Silver;
            this.btnTL_SYS.FlatAppearance.BorderSize = 0;
            this.btnTL_SYS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTL_SYS.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnTL_SYS.Image = ((System.Drawing.Image)(resources.GetObject("btnTL_SYS.Image")));
            this.btnTL_SYS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTL_SYS.ImageSize = new System.Drawing.Size(24, 24);
            this.btnTL_SYS.Location = new System.Drawing.Point(295, 9);
            this.btnTL_SYS.MenuListPosition = new System.Drawing.Point(0, 0);
            this.btnTL_SYS.Name = "btnTL_SYS";
            this.btnTL_SYS.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnTL_SYS.OnStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnTL_SYS.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnTL_SYS.PressStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnTL_SYS.Radius = 5;
            this.btnTL_SYS.Size = new System.Drawing.Size(141, 42);
            this.btnTL_SYS.TabIndex = 36;
            this.btnTL_SYS.Text = "TL_SYS";
            this.btnTL_SYS.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnTL_SYS.UseVisualStyleBackColor = false;
            this.btnTL_SYS.Click += new System.EventHandler(this.btnTL_SYS_Click);
            // 
            // btnAA_Exception
            // 
            this.btnAA_Exception.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAA_Exception.BackColor = System.Drawing.Color.Transparent;
            this.btnAA_Exception.BaseColor = System.Drawing.Color.LightGray;
            this.btnAA_Exception.BaseStrokeColor = System.Drawing.Color.Silver;
            this.btnAA_Exception.FlatAppearance.BorderSize = 0;
            this.btnAA_Exception.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAA_Exception.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAA_Exception.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnAA_Exception.Image = ((System.Drawing.Image)(resources.GetObject("btnAA_Exception.Image")));
            this.btnAA_Exception.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAA_Exception.ImageSize = new System.Drawing.Size(24, 24);
            this.btnAA_Exception.Location = new System.Drawing.Point(295, 57);
            this.btnAA_Exception.MenuListPosition = new System.Drawing.Point(0, 0);
            this.btnAA_Exception.Name = "btnAA_Exception";
            this.btnAA_Exception.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAA_Exception.OnStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnAA_Exception.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnAA_Exception.PressStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnAA_Exception.Radius = 5;
            this.btnAA_Exception.Size = new System.Drawing.Size(141, 42);
            this.btnAA_Exception.TabIndex = 37;
            this.btnAA_Exception.Text = "AA_EXCEPTION";
            this.btnAA_Exception.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAA_Exception.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAA_Exception.UseVisualStyleBackColor = false;
            this.btnAA_Exception.Click += new System.EventHandler(this.btnAA_Exception_Click);
            // 
            // btnV_FireCategories
            // 
            this.btnV_FireCategories.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnV_FireCategories.BackColor = System.Drawing.Color.Transparent;
            this.btnV_FireCategories.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.btnV_FireCategories.BaseStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnV_FireCategories.FlatAppearance.BorderSize = 0;
            this.btnV_FireCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnV_FireCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnV_FireCategories.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnV_FireCategories.Image = ((System.Drawing.Image)(resources.GetObject("btnV_FireCategories.Image")));
            this.btnV_FireCategories.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnV_FireCategories.ImageSize = new System.Drawing.Size(24, 24);
            this.btnV_FireCategories.Location = new System.Drawing.Point(397, 60);
            this.btnV_FireCategories.MenuListPosition = new System.Drawing.Point(0, 0);
            this.btnV_FireCategories.Name = "btnV_FireCategories";
            this.btnV_FireCategories.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnV_FireCategories.OnStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnV_FireCategories.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnV_FireCategories.PressStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnV_FireCategories.Size = new System.Drawing.Size(173, 42);
            this.btnV_FireCategories.TabIndex = 38;
            this.btnV_FireCategories.Text = "Open vFire \r\nCateGories";
            this.btnV_FireCategories.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnV_FireCategories.UseVisualStyleBackColor = false;
            this.btnV_FireCategories.Click += new System.EventHandler(this.btnV_FireCategories_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabMisc);
            this.tabControl1.Controls.Add(this.tabFormattingTools);
            this.tabControl1.Controls.Add(this.tabSearch);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(9, 11);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(6, 10);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(593, 267);
            this.tabControl1.TabIndex = 39;
            // 
            // tabMisc
            // 
            this.tabMisc.Controls.Add(this.btnGetLDAP);
            this.tabMisc.Controls.Add(this.btnExceptionLookup);
            this.tabMisc.Controls.Add(this.btnClearLocks);
            this.tabMisc.Controls.Add(this.btnUserTrainings);
            this.tabMisc.Controls.Add(this.btnV_FireCategories);
            this.tabMisc.Controls.Add(this.mbUserLatestLogin);
            this.tabMisc.Controls.Add(this.btnSickOnStat);
            this.tabMisc.Controls.Add(this.btnItemsReport);
            this.tabMisc.Controls.Add(this.btnFile126);
            this.tabMisc.ImageIndex = 2;
            this.tabMisc.Location = new System.Drawing.Point(4, 39);
            this.tabMisc.Name = "tabMisc";
            this.tabMisc.Padding = new System.Windows.Forms.Padding(3);
            this.tabMisc.Size = new System.Drawing.Size(585, 224);
            this.tabMisc.TabIndex = 1;
            this.tabMisc.Text = "Misc.";
            this.tabMisc.UseVisualStyleBackColor = true;
            // 
            // tabFormattingTools
            // 
            this.tabFormattingTools.Controls.Add(this.btnLOAwithNoRptTime);
            this.tabFormattingTools.Controls.Add(this.btnAA_Exception);
            this.tabFormattingTools.Controls.Add(this.btnBanks);
            this.tabFormattingTools.Controls.Add(this.btnRFLOA);
            this.tabFormattingTools.Controls.Add(this.btnRehire);
            this.tabFormattingTools.Controls.Add(this.btnTL_SYS);
            this.tabFormattingTools.Controls.Add(this.btnPriors);
            this.tabFormattingTools.Controls.Add(this.btnAHS_AA_Terms);
            this.tabFormattingTools.Controls.Add(this.btnTrans);
            this.tabFormattingTools.Controls.Add(this.btnFile2);
            this.tabFormattingTools.Controls.Add(this.btnFile6);
            this.tabFormattingTools.ImageIndex = 1;
            this.tabFormattingTools.Location = new System.Drawing.Point(4, 39);
            this.tabFormattingTools.Name = "tabFormattingTools";
            this.tabFormattingTools.Padding = new System.Windows.Forms.Padding(3);
            this.tabFormattingTools.Size = new System.Drawing.Size(585, 224);
            this.tabFormattingTools.TabIndex = 0;
            this.tabFormattingTools.Text = "Formatting Tools";
            this.tabFormattingTools.UseVisualStyleBackColor = true;
            // 
            // btnLOAwithNoRptTime
            // 
            this.btnLOAwithNoRptTime.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnLOAwithNoRptTime.BackColor = System.Drawing.Color.Transparent;
            this.btnLOAwithNoRptTime.BaseColor = System.Drawing.Color.LightGray;
            this.btnLOAwithNoRptTime.BaseStrokeColor = System.Drawing.Color.Silver;
            this.btnLOAwithNoRptTime.FlatAppearance.BorderSize = 0;
            this.btnLOAwithNoRptTime.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLOAwithNoRptTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.792453F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLOAwithNoRptTime.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnLOAwithNoRptTime.Image = ((System.Drawing.Image)(resources.GetObject("btnLOAwithNoRptTime.Image")));
            this.btnLOAwithNoRptTime.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLOAwithNoRptTime.ImageSize = new System.Drawing.Size(24, 24);
            this.btnLOAwithNoRptTime.Location = new System.Drawing.Point(149, 105);
            this.btnLOAwithNoRptTime.MenuListPosition = new System.Drawing.Point(0, 0);
            this.btnLOAwithNoRptTime.Name = "btnLOAwithNoRptTime";
            this.btnLOAwithNoRptTime.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnLOAwithNoRptTime.OnStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnLOAwithNoRptTime.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnLOAwithNoRptTime.PressStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnLOAwithNoRptTime.Radius = 5;
            this.btnLOAwithNoRptTime.Size = new System.Drawing.Size(141, 42);
            this.btnLOAwithNoRptTime.TabIndex = 38;
            this.btnLOAwithNoRptTime.Text = "AHS_AA_RPTD_\r\nNO_TIME";
            this.btnLOAwithNoRptTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLOAwithNoRptTime.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnLOAwithNoRptTime.UseVisualStyleBackColor = false;
            this.btnLOAwithNoRptTime.Click += new System.EventHandler(this.btnLOAwithNoRptTime_Click);
            // 
            // tabSearch
            // 
            this.tabSearch.Controls.Add(this.txtUnit);
            this.tabSearch.Controls.Add(this.label6);
            this.tabSearch.Controls.Add(this.btnSendEmail);
            this.tabSearch.Controls.Add(this.lstResult);
            this.tabSearch.Controls.Add(this.lblMsg);
            this.tabSearch.Controls.Add(this.txtOCode);
            this.tabSearch.Controls.Add(this.label3);
            this.tabSearch.Controls.Add(this.label1);
            this.tabSearch.Controls.Add(this.txtEmpNo);
            this.tabSearch.Controls.Add(this.groupBox1);
            this.tabSearch.Controls.Add(this.txtTCG);
            this.tabSearch.Controls.Add(this.label2);
            this.tabSearch.Controls.Add(this.label4);
            this.tabSearch.Controls.Add(this.label5);
            this.tabSearch.ImageIndex = 0;
            this.tabSearch.Location = new System.Drawing.Point(4, 39);
            this.tabSearch.Name = "tabSearch";
            this.tabSearch.Size = new System.Drawing.Size(585, 224);
            this.tabSearch.TabIndex = 2;
            this.tabSearch.Text = "Search";
            this.tabSearch.UseVisualStyleBackColor = true;
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.Enabled = false;
            this.btnSendEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.792453F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendEmail.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSendEmail.Image = ((System.Drawing.Image)(resources.GetObject("btnSendEmail.Image")));
            this.btnSendEmail.Location = new System.Drawing.Point(432, 64);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(136, 48);
            this.btnSendEmail.TabIndex = 28;
            this.btnSendEmail.Text = "Send Email to SSC";
            this.btnSendEmail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSendEmail.UseVisualStyleBackColor = true;
            this.btnSendEmail.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "search.png");
            this.imageList1.Images.SetKeyName(1, "format.png");
            this.imageList1.Images.SetKeyName(2, "others.png");
            // 
            // txtUnit
            // 
            this.txtUnit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUnit.Location = new System.Drawing.Point(469, 9);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(110, 22);
            this.txtUnit.TabIndex = 29;
            this.txtUnit.TextChanged += new System.EventHandler(this.txtUnit_TextChanged);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Image = ((System.Drawing.Image)(resources.GetObject("label5.Image")));
            this.label5.Location = new System.Drawing.Point(416, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 25);
            this.label5.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.792453F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(444, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Unit:";
            // 
            // frmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 287);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SömëKindä Tööl v2017.09.26";
            this.Activated += new System.EventHandler(this.frmSearch_Activated);
            this.Deactivate += new System.EventHandler(this.frmSearch_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSearch_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.frmSearch_Shown);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.frmSearch_MouseDoubleClick);
            this.Resize += new System.EventHandler(this.frmSearch_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.mnuCopyFromList.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabMisc.ResumeLayout(false);
            this.tabFormattingTools.ResumeLayout(false);
            this.tabSearch.ResumeLayout(false);
            this.tabSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstResult;
        private System.Windows.Forms.TextBox txtOCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmpNo;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NotifyIcon myNotifyIcon;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuSendEmail;
        private MBGlassStyleButton.MBGlassButton btnFile126;
        private MBGlassStyleButton.MBGlassButton btnFile2;
        private MBGlassStyleButton.MBGlassButton btnFile6;
        private MBGlassStyleButton.MBGlassButton btnBanks;
        private System.Windows.Forms.Label txtTCG;
        private System.Windows.Forms.Timer timerClose;
        private MBGlassStyleButton.MBGlassButton btnRFLOA;
        private MBGlassStyleButton.MBGlassButton btnRehire;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private MBGlassStyleButton.MBGlassButton mbUserLatestLogin;
        private MBGlassStyleButton.MBGlassButton btnPriors;
        private System.Windows.Forms.GroupBox groupBox1;
        private MBGlassStyleButton.MBGlassButton btnAHS_AA_Terms;
        private MBGlassStyleButton.MBGlassButton btnTrans;
        private MBGlassStyleButton.MBGlassButton btnUserTrainings;
        private MBGlassStyleButton.MBGlassButton btnClearLocks;
        private MBGlassStyleButton.MBGlassButton btnGetLDAP;
        private MBGlassStyleButton.MBGlassButton btnExceptionLookup;
        private MBGlassStyleButton.MBGlassButton btnItemsReport;
        private System.Windows.Forms.ContextMenuStrip mnuCopyFromList;
        private System.Windows.Forms.ToolStripMenuItem mnuCopyEmpNum;
        private System.Windows.Forms.ToolStripMenuItem mnuCopyEmpName;
        private System.Windows.Forms.ToolStripMenuItem mnuCopyBothNameAndNum;
        private MBGlassStyleButton.MBGlassButton btnSickOnStat;
        private MBGlassStyleButton.MBGlassButton btnTL_SYS;
        private MBGlassStyleButton.MBGlassButton btnAA_Exception;
        private MBGlassStyleButton.MBGlassButton btnV_FireCategories;
        private System.Windows.Forms.Label lblPayPeriod;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabFormattingTools;
        private System.Windows.Forms.TabPage tabMisc;
        private System.Windows.Forms.TabPage tabSearch;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnSendEmail;
        private MBGlassStyleButton.MBGlassButton btnLOAwithNoRptTime;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}

