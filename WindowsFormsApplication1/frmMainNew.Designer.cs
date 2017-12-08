using System.Drawing;

namespace WindowsFormsApplication1
{
    partial class frmMainNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainNew));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlHandle = new System.Windows.Forms.Panel();
            this.btnSearch = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnFormatting = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnMisc = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnFile126 = new Bunifu.Framework.UI.BunifuTileButton();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnClearLocks = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnItemsReport = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnGetLDAP = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnUserLatestLogin = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnV_FireCategories = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnSickOnStat = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnUserTrainings = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnESPbatchAccess = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnExceptionLookup = new Bunifu.Framework.UI.BunifuTileButton();
            this.lblClose = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlMisc = new System.Windows.Forms.Panel();
            this.pnlFormatting = new System.Windows.Forms.Panel();
            this.btnEmailNegStat = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnFile6 = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnFile2 = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnAA_Exception = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnTL_SYS = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnUploadFile1 = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnLOAwithNoRptTime = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnRFLOA = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnRehire = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnPriors = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnBanks = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnTrans = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnAHS_AA_Terms = new Bunifu.Framework.UI.BunifuTileButton();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.btnSendEmail = new System.Windows.Forms.Button();
            this.lstResult = new System.Windows.Forms.ListBox();
            this.lblMsg = new System.Windows.Forms.Label();
            this.txtOCode = new System.Windows.Forms.TextBox();
            this.txtEmpNo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblPayPeriod = new System.Windows.Forms.Label();
            this.txtTCG = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.timerClose = new System.Windows.Forms.Timer(this.components);
            this.myNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.mnuCopyFromList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuCopyEmpNum = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopyEmpName = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopyBothNameAndNum = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuSendEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlMain.SuspendLayout();
            this.pnlMisc.SuspendLayout();
            this.pnlFormatting.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.mnuCopyFromList.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.pnlMain.Controls.Add(this.pnlHandle);
            this.pnlMain.Controls.Add(this.btnSearch);
            this.pnlMain.Controls.Add(this.btnFormatting);
            this.pnlMain.Controls.Add(this.btnMisc);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(130, 756);
            this.pnlMain.TabIndex = 1;
            this.pnlMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.frmMainNew_MouseDoubleClick);
            // 
            // pnlHandle
            // 
            this.pnlHandle.BackColor = System.Drawing.Color.Transparent;
            this.pnlHandle.Location = new System.Drawing.Point(1, 2);
            this.pnlHandle.Name = "pnlHandle";
            this.pnlHandle.Size = new System.Drawing.Size(734, 29);
            this.pnlHandle.TabIndex = 18;
            this.toolTip1.SetToolTip(this.pnlHandle, "SömëKindä Tööl v2017.12.08");
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnSearch.color = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnSearch.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Font = new System.Drawing.Font("Century Gothic", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImagePosition = 15;
            this.btnSearch.ImageZoom = 50;
            this.btnSearch.LabelPosition = 30;
            this.btnSearch.LabelText = "Search";
            this.btnSearch.Location = new System.Drawing.Point(9, 230);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(111, 103);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnFormatting
            // 
            this.btnFormatting.BackColor = System.Drawing.Color.Transparent;
            this.btnFormatting.color = System.Drawing.Color.Transparent;
            this.btnFormatting.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnFormatting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFormatting.Font = new System.Drawing.Font("Century Gothic", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFormatting.ForeColor = System.Drawing.Color.White;
            this.btnFormatting.Image = ((System.Drawing.Image)(resources.GetObject("btnFormatting.Image")));
            this.btnFormatting.ImagePosition = 13;
            this.btnFormatting.ImageZoom = 50;
            this.btnFormatting.LabelPosition = 40;
            this.btnFormatting.LabelText = "Formatting Tools";
            this.btnFormatting.Location = new System.Drawing.Point(9, 127);
            this.btnFormatting.Margin = new System.Windows.Forms.Padding(4);
            this.btnFormatting.Name = "btnFormatting";
            this.btnFormatting.Size = new System.Drawing.Size(111, 103);
            this.btnFormatting.TabIndex = 3;
            this.btnFormatting.Click += new System.EventHandler(this.btnFormatting_Click);
            // 
            // btnMisc
            // 
            this.btnMisc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnMisc.color = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnMisc.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnMisc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMisc.Font = new System.Drawing.Font("Century Gothic", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMisc.ForeColor = System.Drawing.Color.White;
            this.btnMisc.Image = ((System.Drawing.Image)(resources.GetObject("btnMisc.Image")));
            this.btnMisc.ImagePosition = 15;
            this.btnMisc.ImageZoom = 50;
            this.btnMisc.LabelPosition = 30;
            this.btnMisc.LabelText = "Misc.";
            this.btnMisc.Location = new System.Drawing.Point(9, 24);
            this.btnMisc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMisc.Name = "btnMisc";
            this.btnMisc.Size = new System.Drawing.Size(111, 103);
            this.btnMisc.TabIndex = 2;
            this.btnMisc.Click += new System.EventHandler(this.btnMisc_Click);
            // 
            // btnFile126
            // 
            this.btnFile126.BackColor = System.Drawing.Color.Transparent;
            this.btnFile126.color = System.Drawing.Color.Transparent;
            this.btnFile126.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.btnFile126.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFile126.Font = new System.Drawing.Font("Century Gothic", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFile126.ForeColor = System.Drawing.Color.DarkGray;
            this.btnFile126.Image = ((System.Drawing.Image)(resources.GetObject("btnFile126.Image")));
            this.btnFile126.ImagePosition = 7;
            this.btnFile126.ImageZoom = 45;
            this.btnFile126.LabelPosition = 30;
            this.btnFile126.LabelText = "FTP File 1, 2 and 6";
            this.btnFile126.Location = new System.Drawing.Point(15, 6);
            this.btnFile126.Margin = new System.Windows.Forms.Padding(6);
            this.btnFile126.Name = "btnFile126";
            this.btnFile126.Size = new System.Drawing.Size(121, 92);
            this.btnFile126.TabIndex = 0;
            this.toolTip1.SetToolTip(this.btnFile126, "FTP file 1, 2 and 6 and then automatically formats File 2 and 6");
            this.btnFile126.Click += new System.EventHandler(this.btnFile126_Click);
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this;
            this.bunifuDragControl1.Vertical = true;
            // 
            // bunifuDragControl2
            // 
            this.bunifuDragControl2.Fixed = true;
            this.bunifuDragControl2.Horizontal = true;
            this.bunifuDragControl2.TargetControl = this.pnlHandle;
            this.bunifuDragControl2.Vertical = true;
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 200;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.ToolTipTitle = "Info:";
            // 
            // btnClearLocks
            // 
            this.btnClearLocks.BackColor = System.Drawing.Color.Transparent;
            this.btnClearLocks.color = System.Drawing.Color.Transparent;
            this.btnClearLocks.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.btnClearLocks.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearLocks.Font = new System.Drawing.Font("Century Gothic", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearLocks.ForeColor = System.Drawing.Color.DarkGray;
            this.btnClearLocks.Image = ((System.Drawing.Image)(resources.GetObject("btnClearLocks.Image")));
            this.btnClearLocks.ImagePosition = 7;
            this.btnClearLocks.ImageZoom = 45;
            this.btnClearLocks.LabelPosition = 30;
            this.btnClearLocks.LabelText = "Clear Lock";
            this.btnClearLocks.Location = new System.Drawing.Point(168, 4);
            this.btnClearLocks.Margin = new System.Windows.Forms.Padding(6);
            this.btnClearLocks.Name = "btnClearLocks";
            this.btnClearLocks.Size = new System.Drawing.Size(121, 92);
            this.btnClearLocks.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btnClearLocks, "Check who\'s locking a particular record");
            this.btnClearLocks.Click += new System.EventHandler(this.btnClearLocks_Click);
            // 
            // btnItemsReport
            // 
            this.btnItemsReport.BackColor = System.Drawing.Color.Transparent;
            this.btnItemsReport.color = System.Drawing.Color.Transparent;
            this.btnItemsReport.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.btnItemsReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnItemsReport.Font = new System.Drawing.Font("Century Gothic", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItemsReport.ForeColor = System.Drawing.Color.DarkGray;
            this.btnItemsReport.Image = ((System.Drawing.Image)(resources.GetObject("btnItemsReport.Image")));
            this.btnItemsReport.ImagePosition = 7;
            this.btnItemsReport.ImageZoom = 45;
            this.btnItemsReport.LabelPosition = 30;
            this.btnItemsReport.LabelText = "Items Report";
            this.btnItemsReport.Location = new System.Drawing.Point(321, 3);
            this.btnItemsReport.Margin = new System.Windows.Forms.Padding(6);
            this.btnItemsReport.Name = "btnItemsReport";
            this.btnItemsReport.Size = new System.Drawing.Size(121, 92);
            this.btnItemsReport.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btnItemsReport, "Opens the Items Report app");
            this.btnItemsReport.Click += new System.EventHandler(this.btnItemsReport_Click);
            // 
            // btnGetLDAP
            // 
            this.btnGetLDAP.BackColor = System.Drawing.Color.Transparent;
            this.btnGetLDAP.color = System.Drawing.Color.Transparent;
            this.btnGetLDAP.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.btnGetLDAP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGetLDAP.Font = new System.Drawing.Font("Century Gothic", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetLDAP.ForeColor = System.Drawing.Color.DarkGray;
            this.btnGetLDAP.Image = ((System.Drawing.Image)(resources.GetObject("btnGetLDAP.Image")));
            this.btnGetLDAP.ImagePosition = 7;
            this.btnGetLDAP.ImageZoom = 45;
            this.btnGetLDAP.LabelPosition = 30;
            this.btnGetLDAP.LabelText = "LDAP Info";
            this.btnGetLDAP.Location = new System.Drawing.Point(15, 106);
            this.btnGetLDAP.Margin = new System.Windows.Forms.Padding(6);
            this.btnGetLDAP.Name = "btnGetLDAP";
            this.btnGetLDAP.Size = new System.Drawing.Size(121, 92);
            this.btnGetLDAP.TabIndex = 5;
            this.toolTip1.SetToolTip(this.btnGetLDAP, "Get LDAP Info");
            this.btnGetLDAP.Click += new System.EventHandler(this.btnGetLDAP_Click);
            // 
            // btnUserLatestLogin
            // 
            this.btnUserLatestLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnUserLatestLogin.color = System.Drawing.Color.Transparent;
            this.btnUserLatestLogin.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.btnUserLatestLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUserLatestLogin.Font = new System.Drawing.Font("Century Gothic", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserLatestLogin.ForeColor = System.Drawing.Color.DarkGray;
            this.btnUserLatestLogin.Image = ((System.Drawing.Image)(resources.GetObject("btnUserLatestLogin.Image")));
            this.btnUserLatestLogin.ImagePosition = 7;
            this.btnUserLatestLogin.ImageZoom = 45;
            this.btnUserLatestLogin.LabelPosition = 30;
            this.btnUserLatestLogin.LabelText = "User Latest Login";
            this.btnUserLatestLogin.Location = new System.Drawing.Point(168, 106);
            this.btnUserLatestLogin.Margin = new System.Windows.Forms.Padding(6);
            this.btnUserLatestLogin.Name = "btnUserLatestLogin";
            this.btnUserLatestLogin.Size = new System.Drawing.Size(121, 92);
            this.btnUserLatestLogin.TabIndex = 6;
            this.toolTip1.SetToolTip(this.btnUserLatestLogin, "Get user latest login");
            this.btnUserLatestLogin.Click += new System.EventHandler(this.btnUserLatestLogin_Click);
            // 
            // btnV_FireCategories
            // 
            this.btnV_FireCategories.BackColor = System.Drawing.Color.Transparent;
            this.btnV_FireCategories.color = System.Drawing.Color.Transparent;
            this.btnV_FireCategories.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.btnV_FireCategories.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnV_FireCategories.Font = new System.Drawing.Font("Century Gothic", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnV_FireCategories.ForeColor = System.Drawing.Color.DarkGray;
            this.btnV_FireCategories.Image = ((System.Drawing.Image)(resources.GetObject("btnV_FireCategories.Image")));
            this.btnV_FireCategories.ImagePosition = 7;
            this.btnV_FireCategories.ImageZoom = 45;
            this.btnV_FireCategories.LabelPosition = 30;
            this.btnV_FireCategories.LabelText = "vFire Categories";
            this.btnV_FireCategories.Location = new System.Drawing.Point(321, 105);
            this.btnV_FireCategories.Margin = new System.Windows.Forms.Padding(6);
            this.btnV_FireCategories.Name = "btnV_FireCategories";
            this.btnV_FireCategories.Size = new System.Drawing.Size(121, 92);
            this.btnV_FireCategories.TabIndex = 7;
            this.toolTip1.SetToolTip(this.btnV_FireCategories, "Open vFire Categories");
            this.btnV_FireCategories.Click += new System.EventHandler(this.btnV_FireCategories_Click);
            // 
            // btnSickOnStat
            // 
            this.btnSickOnStat.BackColor = System.Drawing.Color.Transparent;
            this.btnSickOnStat.color = System.Drawing.Color.Transparent;
            this.btnSickOnStat.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.btnSickOnStat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSickOnStat.Font = new System.Drawing.Font("Century Gothic", 6.792453F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSickOnStat.ForeColor = System.Drawing.Color.DarkGray;
            this.btnSickOnStat.Image = ((System.Drawing.Image)(resources.GetObject("btnSickOnStat.Image")));
            this.btnSickOnStat.ImagePosition = 1;
            this.btnSickOnStat.ImageZoom = 45;
            this.btnSickOnStat.LabelPosition = 35;
            this.btnSickOnStat.LabelText = "Upload Sick on a Stat File from ePeople";
            this.btnSickOnStat.Location = new System.Drawing.Point(15, 221);
            this.btnSickOnStat.Margin = new System.Windows.Forms.Padding(5);
            this.btnSickOnStat.Name = "btnSickOnStat";
            this.btnSickOnStat.Size = new System.Drawing.Size(121, 92);
            this.btnSickOnStat.TabIndex = 8;
            this.toolTip1.SetToolTip(this.btnSickOnStat, "Upload Sick on a Stat File from ePeople to BOO database");
            this.btnSickOnStat.Click += new System.EventHandler(this.btnSickOnStat_Click);
            // 
            // btnUserTrainings
            // 
            this.btnUserTrainings.BackColor = System.Drawing.Color.Transparent;
            this.btnUserTrainings.color = System.Drawing.Color.Transparent;
            this.btnUserTrainings.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.btnUserTrainings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUserTrainings.Font = new System.Drawing.Font("Century Gothic", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserTrainings.ForeColor = System.Drawing.Color.DarkGray;
            this.btnUserTrainings.Image = ((System.Drawing.Image)(resources.GetObject("btnUserTrainings.Image")));
            this.btnUserTrainings.ImagePosition = 1;
            this.btnUserTrainings.ImageZoom = 45;
            this.btnUserTrainings.LabelPosition = 35;
            this.btnUserTrainings.LabelText = "User Trainings (SSRS)";
            this.btnUserTrainings.Location = new System.Drawing.Point(321, 220);
            this.btnUserTrainings.Margin = new System.Windows.Forms.Padding(6);
            this.btnUserTrainings.Name = "btnUserTrainings";
            this.btnUserTrainings.Size = new System.Drawing.Size(121, 92);
            this.btnUserTrainings.TabIndex = 10;
            this.toolTip1.SetToolTip(this.btnUserTrainings, "Open User Trainings data from SSRS");
            this.btnUserTrainings.Click += new System.EventHandler(this.btnUserTrainings_Click);
            // 
            // btnESPbatchAccess
            // 
            this.btnESPbatchAccess.BackColor = System.Drawing.Color.Transparent;
            this.btnESPbatchAccess.color = System.Drawing.Color.Transparent;
            this.btnESPbatchAccess.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.btnESPbatchAccess.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnESPbatchAccess.Font = new System.Drawing.Font("Century Gothic", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnESPbatchAccess.ForeColor = System.Drawing.Color.DarkGray;
            this.btnESPbatchAccess.Image = ((System.Drawing.Image)(resources.GetObject("btnESPbatchAccess.Image")));
            this.btnESPbatchAccess.ImagePosition = 7;
            this.btnESPbatchAccess.ImageZoom = 45;
            this.btnESPbatchAccess.LabelPosition = 30;
            this.btnESPbatchAccess.LabelText = "ESP Batch Access";
            this.btnESPbatchAccess.Location = new System.Drawing.Point(474, 221);
            this.btnESPbatchAccess.Margin = new System.Windows.Forms.Padding(6);
            this.btnESPbatchAccess.Name = "btnESPbatchAccess";
            this.btnESPbatchAccess.Size = new System.Drawing.Size(121, 92);
            this.btnESPbatchAccess.TabIndex = 11;
            this.toolTip1.SetToolTip(this.btnESPbatchAccess, "ESP batch access for unit implementation");
            this.btnESPbatchAccess.Click += new System.EventHandler(this.btnESPbatchAccess_Click);
            // 
            // btnExceptionLookup
            // 
            this.btnExceptionLookup.BackColor = System.Drawing.Color.Transparent;
            this.btnExceptionLookup.color = System.Drawing.Color.Transparent;
            this.btnExceptionLookup.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.btnExceptionLookup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExceptionLookup.Font = new System.Drawing.Font("Century Gothic", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExceptionLookup.ForeColor = System.Drawing.Color.DarkGray;
            this.btnExceptionLookup.Image = ((System.Drawing.Image)(resources.GetObject("btnExceptionLookup.Image")));
            this.btnExceptionLookup.ImagePosition = 1;
            this.btnExceptionLookup.ImageZoom = 45;
            this.btnExceptionLookup.LabelPosition = 35;
            this.btnExceptionLookup.LabelText = "Exception Lookup";
            this.btnExceptionLookup.Location = new System.Drawing.Point(168, 220);
            this.btnExceptionLookup.Margin = new System.Windows.Forms.Padding(6);
            this.btnExceptionLookup.Name = "btnExceptionLookup";
            this.btnExceptionLookup.Size = new System.Drawing.Size(121, 92);
            this.btnExceptionLookup.TabIndex = 9;
            this.btnExceptionLookup.Click += new System.EventHandler(this.btnExceptionLookup_Click);
            // 
            // lblClose
            // 
            this.lblClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClose.Font = new System.Drawing.Font("Arial Black", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClose.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblClose.Location = new System.Drawing.Point(713, 9);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(20, 20);
            this.lblClose.TabIndex = 12;
            this.lblClose.Text = "X";
            this.lblClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // label1
            // 
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Arial Black", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.OrangeRed;
            this.label1.Location = new System.Drawing.Point(680, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "_";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pnlMisc
            // 
            this.pnlMisc.Controls.Add(this.btnUserTrainings);
            this.pnlMisc.Controls.Add(this.btnFile126);
            this.pnlMisc.Controls.Add(this.btnClearLocks);
            this.pnlMisc.Controls.Add(this.btnESPbatchAccess);
            this.pnlMisc.Controls.Add(this.btnItemsReport);
            this.pnlMisc.Controls.Add(this.btnGetLDAP);
            this.pnlMisc.Controls.Add(this.btnExceptionLookup);
            this.pnlMisc.Controls.Add(this.btnUserLatestLogin);
            this.pnlMisc.Controls.Add(this.btnSickOnStat);
            this.pnlMisc.Controls.Add(this.btnV_FireCategories);
            this.pnlMisc.Location = new System.Drawing.Point(132, 32);
            this.pnlMisc.Name = "pnlMisc";
            this.pnlMisc.Size = new System.Drawing.Size(603, 325);
            this.pnlMisc.TabIndex = 14;
            this.pnlMisc.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.frmMainNew_MouseDoubleClick);
            // 
            // pnlFormatting
            // 
            this.pnlFormatting.Controls.Add(this.btnEmailNegStat);
            this.pnlFormatting.Controls.Add(this.btnFile6);
            this.pnlFormatting.Controls.Add(this.btnFile2);
            this.pnlFormatting.Controls.Add(this.btnAA_Exception);
            this.pnlFormatting.Controls.Add(this.btnTL_SYS);
            this.pnlFormatting.Controls.Add(this.btnUploadFile1);
            this.pnlFormatting.Controls.Add(this.btnLOAwithNoRptTime);
            this.pnlFormatting.Controls.Add(this.btnRFLOA);
            this.pnlFormatting.Controls.Add(this.btnRehire);
            this.pnlFormatting.Controls.Add(this.btnPriors);
            this.pnlFormatting.Controls.Add(this.btnBanks);
            this.pnlFormatting.Controls.Add(this.btnTrans);
            this.pnlFormatting.Controls.Add(this.btnAHS_AA_Terms);
            this.pnlFormatting.Location = new System.Drawing.Point(136, 411);
            this.pnlFormatting.Name = "pnlFormatting";
            this.pnlFormatting.Size = new System.Drawing.Size(603, 325);
            this.pnlFormatting.TabIndex = 15;
            this.pnlFormatting.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.frmMainNew_MouseDoubleClick);
            // 
            // btnEmailNegStat
            // 
            this.btnEmailNegStat.BackColor = System.Drawing.Color.Transparent;
            this.btnEmailNegStat.color = System.Drawing.Color.Transparent;
            this.btnEmailNegStat.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.btnEmailNegStat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEmailNegStat.Font = new System.Drawing.Font("Century Gothic", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmailNegStat.ForeColor = System.Drawing.Color.DarkGray;
            this.btnEmailNegStat.Image = ((System.Drawing.Image)(resources.GetObject("btnEmailNegStat.Image")));
            this.btnEmailNegStat.ImagePosition = 1;
            this.btnEmailNegStat.ImageZoom = 27;
            this.btnEmailNegStat.LabelPosition = 35;
            this.btnEmailNegStat.LabelText = "Format Negative Stats";
            this.btnEmailNegStat.Location = new System.Drawing.Point(334, 171);
            this.btnEmailNegStat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEmailNegStat.Name = "btnEmailNegStat";
            this.btnEmailNegStat.Size = new System.Drawing.Size(104, 64);
            this.btnEmailNegStat.TabIndex = 34;
            this.btnEmailNegStat.Click += new System.EventHandler(this.btnEmailNegStat_Click);
            // 
            // btnFile6
            // 
            this.btnFile6.BackColor = System.Drawing.Color.Transparent;
            this.btnFile6.color = System.Drawing.Color.Transparent;
            this.btnFile6.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.btnFile6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFile6.Font = new System.Drawing.Font("Century Gothic", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFile6.ForeColor = System.Drawing.Color.DarkGray;
            this.btnFile6.Image = ((System.Drawing.Image)(resources.GetObject("btnFile6.Image")));
            this.btnFile6.ImagePosition = 1;
            this.btnFile6.ImageZoom = 40;
            this.btnFile6.LabelPosition = 23;
            this.btnFile6.LabelText = "Format File 6";
            this.btnFile6.Location = new System.Drawing.Point(470, 89);
            this.btnFile6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFile6.Name = "btnFile6";
            this.btnFile6.Size = new System.Drawing.Size(104, 64);
            this.btnFile6.TabIndex = 33;
            this.btnFile6.Click += new System.EventHandler(this.btnFile6_Click);
            // 
            // btnFile2
            // 
            this.btnFile2.BackColor = System.Drawing.Color.Transparent;
            this.btnFile2.color = System.Drawing.Color.Transparent;
            this.btnFile2.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.btnFile2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFile2.Font = new System.Drawing.Font("Century Gothic", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFile2.ForeColor = System.Drawing.Color.DarkGray;
            this.btnFile2.Image = ((System.Drawing.Image)(resources.GetObject("btnFile2.Image")));
            this.btnFile2.ImagePosition = 1;
            this.btnFile2.ImageZoom = 40;
            this.btnFile2.LabelPosition = 23;
            this.btnFile2.LabelText = "Format File 2";
            this.btnFile2.Location = new System.Drawing.Point(470, 7);
            this.btnFile2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFile2.Name = "btnFile2";
            this.btnFile2.Size = new System.Drawing.Size(104, 64);
            this.btnFile2.TabIndex = 32;
            this.btnFile2.Click += new System.EventHandler(this.btnFile2_Click);
            // 
            // btnAA_Exception
            // 
            this.btnAA_Exception.BackColor = System.Drawing.Color.Transparent;
            this.btnAA_Exception.color = System.Drawing.Color.Transparent;
            this.btnAA_Exception.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.btnAA_Exception.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAA_Exception.Font = new System.Drawing.Font("Century Gothic", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAA_Exception.ForeColor = System.Drawing.Color.DarkGray;
            this.btnAA_Exception.Image = ((System.Drawing.Image)(resources.GetObject("btnAA_Exception.Image")));
            this.btnAA_Exception.ImagePosition = 1;
            this.btnAA_Exception.ImageZoom = 40;
            this.btnAA_Exception.LabelPosition = 23;
            this.btnAA_Exception.LabelText = "AA_EXCEPTION";
            this.btnAA_Exception.Location = new System.Drawing.Point(334, 87);
            this.btnAA_Exception.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAA_Exception.Name = "btnAA_Exception";
            this.btnAA_Exception.Size = new System.Drawing.Size(104, 64);
            this.btnAA_Exception.TabIndex = 29;
            this.btnAA_Exception.Click += new System.EventHandler(this.btnAA_Exception_Click);
            // 
            // btnTL_SYS
            // 
            this.btnTL_SYS.BackColor = System.Drawing.Color.Transparent;
            this.btnTL_SYS.color = System.Drawing.Color.Transparent;
            this.btnTL_SYS.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.btnTL_SYS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTL_SYS.Font = new System.Drawing.Font("Century Gothic", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTL_SYS.ForeColor = System.Drawing.Color.DarkGray;
            this.btnTL_SYS.Image = ((System.Drawing.Image)(resources.GetObject("btnTL_SYS.Image")));
            this.btnTL_SYS.ImagePosition = 1;
            this.btnTL_SYS.ImageZoom = 40;
            this.btnTL_SYS.LabelPosition = 23;
            this.btnTL_SYS.LabelText = "TL_SYS";
            this.btnTL_SYS.Location = new System.Drawing.Point(334, 7);
            this.btnTL_SYS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTL_SYS.Name = "btnTL_SYS";
            this.btnTL_SYS.Size = new System.Drawing.Size(104, 64);
            this.btnTL_SYS.TabIndex = 28;
            this.btnTL_SYS.Click += new System.EventHandler(this.btnTL_SYS_Click);
            // 
            // btnUploadFile1
            // 
            this.btnUploadFile1.BackColor = System.Drawing.Color.Transparent;
            this.btnUploadFile1.color = System.Drawing.Color.Transparent;
            this.btnUploadFile1.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.btnUploadFile1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUploadFile1.Font = new System.Drawing.Font("Century Gothic", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadFile1.ForeColor = System.Drawing.Color.DarkGray;
            this.btnUploadFile1.Image = ((System.Drawing.Image)(resources.GetObject("btnUploadFile1.Image")));
            this.btnUploadFile1.ImagePosition = 1;
            this.btnUploadFile1.ImageZoom = 30;
            this.btnUploadFile1.LabelPosition = 35;
            this.btnUploadFile1.LabelText = "Upload File 1 for NFP Checking";
            this.btnUploadFile1.Location = new System.Drawing.Point(470, 171);
            this.btnUploadFile1.Name = "btnUploadFile1";
            this.btnUploadFile1.Size = new System.Drawing.Size(104, 64);
            this.btnUploadFile1.TabIndex = 27;
            this.btnUploadFile1.Click += new System.EventHandler(this.btnUploadFile1_Click);
            // 
            // btnLOAwithNoRptTime
            // 
            this.btnLOAwithNoRptTime.BackColor = System.Drawing.Color.Transparent;
            this.btnLOAwithNoRptTime.color = System.Drawing.Color.Transparent;
            this.btnLOAwithNoRptTime.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.btnLOAwithNoRptTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLOAwithNoRptTime.Font = new System.Drawing.Font("Century Gothic", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLOAwithNoRptTime.ForeColor = System.Drawing.Color.DarkGray;
            this.btnLOAwithNoRptTime.Image = ((System.Drawing.Image)(resources.GetObject("btnLOAwithNoRptTime.Image")));
            this.btnLOAwithNoRptTime.ImagePosition = 1;
            this.btnLOAwithNoRptTime.ImageZoom = 27;
            this.btnLOAwithNoRptTime.LabelPosition = 35;
            this.btnLOAwithNoRptTime.LabelText = "AHS_AA_RPTD_ NO_TIME";
            this.btnLOAwithNoRptTime.Location = new System.Drawing.Point(181, 171);
            this.btnLOAwithNoRptTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLOAwithNoRptTime.Name = "btnLOAwithNoRptTime";
            this.btnLOAwithNoRptTime.Size = new System.Drawing.Size(104, 64);
            this.btnLOAwithNoRptTime.TabIndex = 26;
            this.btnLOAwithNoRptTime.Click += new System.EventHandler(this.btnLOAwithNoRptTime_Click);
            // 
            // btnRFLOA
            // 
            this.btnRFLOA.BackColor = System.Drawing.Color.Transparent;
            this.btnRFLOA.color = System.Drawing.Color.Transparent;
            this.btnRFLOA.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.btnRFLOA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRFLOA.Font = new System.Drawing.Font("Century Gothic", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRFLOA.ForeColor = System.Drawing.Color.DarkGray;
            this.btnRFLOA.Image = ((System.Drawing.Image)(resources.GetObject("btnRFLOA.Image")));
            this.btnRFLOA.ImagePosition = 1;
            this.btnRFLOA.ImageZoom = 30;
            this.btnRFLOA.LabelPosition = 35;
            this.btnRFLOA.LabelText = "Return from LOA";
            this.btnRFLOA.Location = new System.Drawing.Point(181, 89);
            this.btnRFLOA.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRFLOA.Name = "btnRFLOA";
            this.btnRFLOA.Size = new System.Drawing.Size(104, 64);
            this.btnRFLOA.TabIndex = 25;
            this.btnRFLOA.Click += new System.EventHandler(this.btnRFLOA_Click);
            // 
            // btnRehire
            // 
            this.btnRehire.BackColor = System.Drawing.Color.Transparent;
            this.btnRehire.color = System.Drawing.Color.Transparent;
            this.btnRehire.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.btnRehire.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRehire.Font = new System.Drawing.Font("Century Gothic", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRehire.ForeColor = System.Drawing.Color.DarkGray;
            this.btnRehire.Image = ((System.Drawing.Image)(resources.GetObject("btnRehire.Image")));
            this.btnRehire.ImagePosition = 1;
            this.btnRehire.ImageZoom = 40;
            this.btnRehire.LabelPosition = 23;
            this.btnRehire.LabelText = "Rehires";
            this.btnRehire.Location = new System.Drawing.Point(181, 7);
            this.btnRehire.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRehire.Name = "btnRehire";
            this.btnRehire.Size = new System.Drawing.Size(104, 64);
            this.btnRehire.TabIndex = 24;
            this.btnRehire.Click += new System.EventHandler(this.btnRehire_Click);
            // 
            // btnPriors
            // 
            this.btnPriors.BackColor = System.Drawing.Color.Transparent;
            this.btnPriors.color = System.Drawing.Color.Transparent;
            this.btnPriors.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.btnPriors.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPriors.Font = new System.Drawing.Font("Century Gothic", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPriors.ForeColor = System.Drawing.Color.DarkGray;
            this.btnPriors.Image = ((System.Drawing.Image)(resources.GetObject("btnPriors.Image")));
            this.btnPriors.ImagePosition = 1;
            this.btnPriors.ImageZoom = 25;
            this.btnPriors.LabelPosition = 35;
            this.btnPriors.LabelText = "Prior Pay Period Adjustment";
            this.btnPriors.Location = new System.Drawing.Point(22, 247);
            this.btnPriors.Name = "btnPriors";
            this.btnPriors.Size = new System.Drawing.Size(104, 64);
            this.btnPriors.TabIndex = 23;
            this.btnPriors.Click += new System.EventHandler(this.btnPriors_Click);
            // 
            // btnBanks
            // 
            this.btnBanks.BackColor = System.Drawing.Color.Transparent;
            this.btnBanks.color = System.Drawing.Color.Transparent;
            this.btnBanks.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.btnBanks.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBanks.Font = new System.Drawing.Font("Century Gothic", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBanks.ForeColor = System.Drawing.Color.DarkGray;
            this.btnBanks.Image = ((System.Drawing.Image)(resources.GetObject("btnBanks.Image")));
            this.btnBanks.ImagePosition = 1;
            this.btnBanks.ImageZoom = 30;
            this.btnBanks.LabelPosition = 35;
            this.btnBanks.LabelText = "Off Codes Vs Banks";
            this.btnBanks.Location = new System.Drawing.Point(22, 165);
            this.btnBanks.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBanks.Name = "btnBanks";
            this.btnBanks.Size = new System.Drawing.Size(104, 64);
            this.btnBanks.TabIndex = 22;
            this.btnBanks.Click += new System.EventHandler(this.btnBanks_Click);
            // 
            // btnTrans
            // 
            this.btnTrans.BackColor = System.Drawing.Color.Transparent;
            this.btnTrans.color = System.Drawing.Color.Transparent;
            this.btnTrans.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.btnTrans.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTrans.Font = new System.Drawing.Font("Century Gothic", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrans.ForeColor = System.Drawing.Color.DarkGray;
            this.btnTrans.Image = ((System.Drawing.Image)(resources.GetObject("btnTrans.Image")));
            this.btnTrans.ImagePosition = 1;
            this.btnTrans.ImageZoom = 30;
            this.btnTrans.LabelPosition = 35;
            this.btnTrans.LabelText = "AHS_AA_ TRANSFER_RPT";
            this.btnTrans.Location = new System.Drawing.Point(22, 83);
            this.btnTrans.Name = "btnTrans";
            this.btnTrans.Size = new System.Drawing.Size(104, 64);
            this.btnTrans.TabIndex = 21;
            this.btnTrans.Click += new System.EventHandler(this.btnTrans_Click);
            // 
            // btnAHS_AA_Terms
            // 
            this.btnAHS_AA_Terms.BackColor = System.Drawing.Color.Transparent;
            this.btnAHS_AA_Terms.color = System.Drawing.Color.Transparent;
            this.btnAHS_AA_Terms.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.btnAHS_AA_Terms.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAHS_AA_Terms.Font = new System.Drawing.Font("Century Gothic", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAHS_AA_Terms.ForeColor = System.Drawing.Color.DarkGray;
            this.btnAHS_AA_Terms.Image = ((System.Drawing.Image)(resources.GetObject("btnAHS_AA_Terms.Image")));
            this.btnAHS_AA_Terms.ImagePosition = 1;
            this.btnAHS_AA_Terms.ImageZoom = 40;
            this.btnAHS_AA_Terms.LabelPosition = 23;
            this.btnAHS_AA_Terms.LabelText = "AHS_AA_TERMS";
            this.btnAHS_AA_Terms.Location = new System.Drawing.Point(22, 1);
            this.btnAHS_AA_Terms.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAHS_AA_Terms.Name = "btnAHS_AA_Terms";
            this.btnAHS_AA_Terms.Size = new System.Drawing.Size(104, 64);
            this.btnAHS_AA_Terms.TabIndex = 20;
            this.btnAHS_AA_Terms.Click += new System.EventHandler(this.btnAHS_AA_Terms_Click);
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.label4);
            this.pnlSearch.Controls.Add(this.label2);
            this.pnlSearch.Controls.Add(this.txtUnit);
            this.pnlSearch.Controls.Add(this.btnSendEmail);
            this.pnlSearch.Controls.Add(this.lstResult);
            this.pnlSearch.Controls.Add(this.lblMsg);
            this.pnlSearch.Controls.Add(this.txtOCode);
            this.pnlSearch.Controls.Add(this.txtEmpNo);
            this.pnlSearch.Controls.Add(this.groupBox1);
            this.pnlSearch.Controls.Add(this.txtTCG);
            this.pnlSearch.Controls.Add(this.label5);
            this.pnlSearch.Controls.Add(this.label7);
            this.pnlSearch.Controls.Add(this.label3);
            this.pnlSearch.Controls.Add(this.label6);
            this.pnlSearch.Location = new System.Drawing.Point(884, 275);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(603, 325);
            this.pnlSearch.TabIndex = 17;
            this.pnlSearch.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.frmMainNew_MouseDoubleClick);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Image = ((System.Drawing.Image)(resources.GetObject("label4.Image")));
            this.label4.Location = new System.Drawing.Point(18, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 25);
            this.label4.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(42, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(252, 26);
            this.label2.TabIndex = 37;
            this.label2.Text = "Emp No or LastName or FirstName:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUnit
            // 
            this.txtUnit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtUnit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.txtUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUnit.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtUnit.Location = new System.Drawing.Point(300, 80);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(149, 20);
            this.txtUnit.TabIndex = 43;
            this.txtUnit.TextChanged += new System.EventHandler(this.txtUnit_TextChanged);
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.btnSendEmail.Enabled = false;
            this.btnSendEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.792453F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnSendEmail.Image = ((System.Drawing.Image)(resources.GetObject("btnSendEmail.Image")));
            this.btnSendEmail.Location = new System.Drawing.Point(454, 132);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(136, 48);
            this.btnSendEmail.TabIndex = 42;
            this.btnSendEmail.Text = "Send Email to SSC";
            this.btnSendEmail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSendEmail.UseVisualStyleBackColor = false;
            this.btnSendEmail.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // lstResult
            // 
            this.lstResult.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lstResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.lstResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstResult.Font = new System.Drawing.Font("Courier New", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstResult.ForeColor = System.Drawing.Color.GreenYellow;
            this.lstResult.FormattingEnabled = true;
            this.lstResult.ItemHeight = 16;
            this.lstResult.Location = new System.Drawing.Point(17, 117);
            this.lstResult.Name = "lstResult";
            this.lstResult.Size = new System.Drawing.Size(432, 82);
            this.lstResult.TabIndex = 33;
            this.lstResult.Click += new System.EventHandler(this.lstResult_Click);
            this.lstResult.SelectedIndexChanged += new System.EventHandler(this.lstResult_Click);
            this.lstResult.DoubleClick += new System.EventHandler(this.lstResult_DoubleClick);
            this.lstResult.MouseLeave += new System.EventHandler(this.lstResult_MouseLeave);
            this.lstResult.MouseHover += new System.EventHandler(this.lstResult_MouseHover);
            this.lstResult.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lstResult_MouseUp);
            // 
            // lblMsg
            // 
            this.lblMsg.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMsg.AutoSize = true;
            this.lblMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.lblMsg.Location = new System.Drawing.Point(19, 233);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 15);
            this.lblMsg.TabIndex = 38;
            // 
            // txtOCode
            // 
            this.txtOCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtOCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.txtOCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOCode.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtOCode.Location = new System.Drawing.Point(300, 7);
            this.txtOCode.Name = "txtOCode";
            this.txtOCode.Size = new System.Drawing.Size(92, 20);
            this.txtOCode.TabIndex = 34;
            this.txtOCode.TextChanged += new System.EventHandler(this.txtOCode_TextChanged);
            // 
            // txtEmpNo
            // 
            this.txtEmpNo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtEmpNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.txtEmpNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmpNo.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtEmpNo.Location = new System.Drawing.Point(300, 43);
            this.txtEmpNo.Name = "txtEmpNo";
            this.txtEmpNo.Size = new System.Drawing.Size(149, 20);
            this.txtEmpNo.TabIndex = 36;
            this.txtEmpNo.TextChanged += new System.EventHandler(this.txtEmpNo_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.lblPayPeriod);
            this.groupBox1.Location = new System.Drawing.Point(19, 248);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(430, 42);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(6, 15);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(203, 19);
            this.dateTimePicker1.TabIndex = 7;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // lblPayPeriod
            // 
            this.lblPayPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayPeriod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.lblPayPeriod.Location = new System.Drawing.Point(215, 13);
            this.lblPayPeriod.Name = "lblPayPeriod";
            this.lblPayPeriod.Size = new System.Drawing.Size(111, 23);
            this.lblPayPeriod.TabIndex = 8;
            this.lblPayPeriod.Text = "test";
            this.lblPayPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTCG
            // 
            this.txtTCG.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTCG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.txtTCG.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtTCG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTCG.ForeColor = System.Drawing.Color.GreenYellow;
            this.txtTCG.Location = new System.Drawing.Point(17, 204);
            this.txtTCG.Name = "txtTCG";
            this.txtTCG.Size = new System.Drawing.Size(432, 23);
            this.txtTCG.TabIndex = 39;
            this.txtTCG.Text = "label3";
            this.txtTCG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtTCG.Visible = false;
            this.txtTCG.DoubleClick += new System.EventHandler(this.txtTCG_DoubleClick);
            this.txtTCG.MouseLeave += new System.EventHandler(this.txtTCG_MouseLeave);
            this.txtTCG.MouseHover += new System.EventHandler(this.txtTCG_MouseHover);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Image = ((System.Drawing.Image)(resources.GetObject("label5.Image")));
            this.label5.Location = new System.Drawing.Point(218, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 25);
            this.label5.TabIndex = 45;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Image = ((System.Drawing.Image)(resources.GetObject("label7.Image")));
            this.label7.Location = new System.Drawing.Point(119, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 25);
            this.label7.TabIndex = 46;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(128, -2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 35);
            this.label3.TabIndex = 35;
            this.label3.Text = "Occupation Code:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(217, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 20);
            this.label6.TabIndex = 44;
            this.label6.Text = "Unit:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timerClose
            // 
            this.timerClose.Interval = 3600000;
            this.timerClose.Tick += new System.EventHandler(this.timerClose_Tick);
            // 
            // myNotifyIcon
            // 
            this.myNotifyIcon.BalloonTipText = "Click to open again";
            this.myNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("myNotifyIcon.Icon")));
            this.myNotifyIcon.Text = "Search";
            this.myNotifyIcon.Visible = true;
            this.myNotifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.myNotifyIcon_MouseClick);
            // 
            // mnuCopyFromList
            // 
            this.mnuCopyFromList.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.mnuCopyFromList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCopyEmpNum,
            this.mnuCopyEmpName,
            this.mnuCopyBothNameAndNum});
            this.mnuCopyFromList.Name = "mnuCopyFromList";
            this.mnuCopyFromList.Size = new System.Drawing.Size(333, 76);
            this.mnuCopyFromList.Text = "CopyFromList";
            // 
            // mnuCopyEmpNum
            // 
            this.mnuCopyEmpNum.Image = ((System.Drawing.Image)(resources.GetObject("mnuCopyEmpNum.Image")));
            this.mnuCopyEmpNum.Name = "mnuCopyEmpNum";
            this.mnuCopyEmpNum.Size = new System.Drawing.Size(332, 24);
            this.mnuCopyEmpNum.Text = "Copy Emp # to clipboard";
            this.mnuCopyEmpNum.Click += new System.EventHandler(this.mnuCopyEmpNum_Click);
            // 
            // mnuCopyEmpName
            // 
            this.mnuCopyEmpName.Image = ((System.Drawing.Image)(resources.GetObject("mnuCopyEmpName.Image")));
            this.mnuCopyEmpName.Name = "mnuCopyEmpName";
            this.mnuCopyEmpName.Size = new System.Drawing.Size(332, 24);
            this.mnuCopyEmpName.Text = "Copy Emp Name to clipboard";
            this.mnuCopyEmpName.Click += new System.EventHandler(this.mnuCopyEmpName_Click);
            // 
            // mnuCopyBothNameAndNum
            // 
            this.mnuCopyBothNameAndNum.Image = ((System.Drawing.Image)(resources.GetObject("mnuCopyBothNameAndNum.Image")));
            this.mnuCopyBothNameAndNum.Name = "mnuCopyBothNameAndNum";
            this.mnuCopyBothNameAndNum.Size = new System.Drawing.Size(332, 24);
            this.mnuCopyBothNameAndNum.Text = "Copy Both Emp Name and # to clipboard";
            this.mnuCopyBothNameAndNum.Click += new System.EventHandler(this.mnuCopyBothNameAndNum_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSendEmail});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(193, 28);
            // 
            // mnuSendEmail
            // 
            this.mnuSendEmail.Name = "mnuSendEmail";
            this.mnuSendEmail.Size = new System.Drawing.Size(192, 24);
            this.mnuSendEmail.Text = "Send Email To SSO";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // frmMainNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(23)))), ((int)(((byte)(41)))));
            this.ClientSize = new System.Drawing.Size(1561, 756);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlFormatting);
            this.Controls.Add(this.pnlMisc);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMainNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SömëKindä Tööl v2017.12.05";
            this.Activated += new System.EventHandler(this.frmMainNew_Activated);
            this.Deactivate += new System.EventHandler(this.frmMainNew_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMainNew_FormClosing);
            this.Load += new System.EventHandler(this.frmMainNew_Load);
            this.Shown += new System.EventHandler(this.frmMainNew_Shown);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.frmMainNew_MouseDoubleClick);
            this.Resize += new System.EventHandler(this.frmMainNew_Resize);
            this.pnlMain.ResumeLayout(false);
            this.pnlMisc.ResumeLayout(false);
            this.pnlFormatting.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.mnuCopyFromList.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlMain;
        private Bunifu.Framework.UI.BunifuTileButton btnMisc;
        private Bunifu.Framework.UI.BunifuTileButton btnFile126;
        private Bunifu.Framework.UI.BunifuTileButton btnSearch;
        private Bunifu.Framework.UI.BunifuTileButton btnFormatting;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl2;
        private System.Windows.Forms.ToolTip toolTip1;
        private Bunifu.Framework.UI.BunifuTileButton btnESPbatchAccess;
        private Bunifu.Framework.UI.BunifuTileButton btnUserTrainings;
        private Bunifu.Framework.UI.BunifuTileButton btnExceptionLookup;
        private Bunifu.Framework.UI.BunifuTileButton btnSickOnStat;
        private Bunifu.Framework.UI.BunifuTileButton btnV_FireCategories;
        private Bunifu.Framework.UI.BunifuTileButton btnUserLatestLogin;
        private Bunifu.Framework.UI.BunifuTileButton btnGetLDAP;
        private Bunifu.Framework.UI.BunifuTileButton btnItemsReport;
        private Bunifu.Framework.UI.BunifuTileButton btnClearLocks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Panel pnlFormatting;
        private System.Windows.Forms.Panel pnlMisc;
        private System.Windows.Forms.Panel pnlSearch;
        private Bunifu.Framework.UI.BunifuTileButton btnPriors;
        private Bunifu.Framework.UI.BunifuTileButton btnBanks;
        private Bunifu.Framework.UI.BunifuTileButton btnTrans;
        private Bunifu.Framework.UI.BunifuTileButton btnAHS_AA_Terms;
        private Bunifu.Framework.UI.BunifuTileButton btnFile6;
        private Bunifu.Framework.UI.BunifuTileButton btnFile2;
        private Bunifu.Framework.UI.BunifuTileButton btnAA_Exception;
        private Bunifu.Framework.UI.BunifuTileButton btnTL_SYS;
        private Bunifu.Framework.UI.BunifuTileButton btnUploadFile1;
        private Bunifu.Framework.UI.BunifuTileButton btnLOAwithNoRptTime;
        private Bunifu.Framework.UI.BunifuTileButton btnRFLOA;
        private Bunifu.Framework.UI.BunifuTileButton btnRehire;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSendEmail;
        private System.Windows.Forms.ListBox lstResult;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.TextBox txtOCode;
        private System.Windows.Forms.TextBox txtEmpNo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblPayPeriod;
        private System.Windows.Forms.Label txtTCG;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timerClose;
        private System.Windows.Forms.NotifyIcon myNotifyIcon;
        private System.Windows.Forms.ContextMenuStrip mnuCopyFromList;
        private System.Windows.Forms.ToolStripMenuItem mnuCopyEmpNum;
        private System.Windows.Forms.ToolStripMenuItem mnuCopyEmpName;
        private System.Windows.Forms.ToolStripMenuItem mnuCopyBothNameAndNum;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuSendEmail;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel pnlHandle;
        private Bunifu.Framework.UI.BunifuTileButton btnEmailNegStat;
    }
}