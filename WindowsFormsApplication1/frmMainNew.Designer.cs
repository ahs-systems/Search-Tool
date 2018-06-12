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
            BunifuAnimatorNS.Animation animation14 = new BunifuAnimatorNS.Animation();
            BunifuAnimatorNS.Animation animation13 = new BunifuAnimatorNS.Animation();
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
            this.bunifuTileButton1 = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnRemote = new Bunifu.Framework.UI.BunifuTileButton();
            this.bunifuTileButton2 = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnExceptionLookup = new Bunifu.Framework.UI.BunifuTileButton();
            this.lblClose = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlMisc = new System.Windows.Forms.Panel();
            this.btnUploadFile1 = new Bunifu.Framework.UI.BunifuTileButton();
            this.pnlFormatting = new System.Windows.Forms.Panel();
            this.btnFormatSickOnStat = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnFormatA06 = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnFormatTAER = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnEmailNegStat = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnFile6 = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnFile2 = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnAA_Exception = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnTL_SYS = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnLOAwithNoRptTime = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnRFLOA = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnRehire = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnPriors = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnBanks = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnTrans = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnAHS_AA_Terms = new Bunifu.Framework.UI.BunifuTileButton();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
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
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.timerClose = new System.Windows.Forms.Timer(this.components);
            this.myNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.mnuCopyFromList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuCopyEmpNum = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopyEmpName = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopyBothNameAndNum = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuSendEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.transPanel = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.mnuFormat2and6 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.formatFile2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatFile6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transFrm = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.pnlMain.SuspendLayout();
            this.pnlMisc.SuspendLayout();
            this.pnlFormatting.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.mnuCopyFromList.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.mnuFormat2and6.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(109)))), ((int)(((byte)(130)))));
            this.pnlMain.Controls.Add(this.pnlHandle);
            this.pnlMain.Controls.Add(this.btnSearch);
            this.pnlMain.Controls.Add(this.btnFormatting);
            this.pnlMain.Controls.Add(this.btnMisc);
            this.transFrm.SetDecoration(this.pnlMain, BunifuAnimatorNS.DecorationType.None);
            this.transPanel.SetDecoration(this.pnlMain, BunifuAnimatorNS.DecorationType.None);
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
            this.transFrm.SetDecoration(this.pnlHandle, BunifuAnimatorNS.DecorationType.None);
            this.transPanel.SetDecoration(this.pnlHandle, BunifuAnimatorNS.DecorationType.None);
            this.pnlHandle.Location = new System.Drawing.Point(1, 2);
            this.pnlHandle.Name = "pnlHandle";
            this.pnlHandle.Size = new System.Drawing.Size(734, 29);
            this.pnlHandle.TabIndex = 18;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(109)))), ((int)(((byte)(130)))));
            this.btnSearch.color = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(109)))), ((int)(((byte)(130)))));
            this.btnSearch.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(73)))));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transFrm.SetDecoration(this.btnSearch, BunifuAnimatorNS.DecorationType.BottomMirror);
            this.transPanel.SetDecoration(this.btnSearch, BunifuAnimatorNS.DecorationType.None);
            this.btnSearch.Font = new System.Drawing.Font("Century Gothic", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImagePosition = 15;
            this.btnSearch.ImageZoom = 50;
            this.btnSearch.LabelPosition = 30;
            this.btnSearch.LabelText = "Search";
            this.btnSearch.Location = new System.Drawing.Point(9, 230);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(111, 103);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnFormatting
            // 
            this.btnFormatting.BackColor = System.Drawing.Color.Transparent;
            this.btnFormatting.color = System.Drawing.Color.Transparent;
            this.btnFormatting.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(73)))));
            this.btnFormatting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transFrm.SetDecoration(this.btnFormatting, BunifuAnimatorNS.DecorationType.BottomMirror);
            this.transPanel.SetDecoration(this.btnFormatting, BunifuAnimatorNS.DecorationType.None);
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
            this.btnMisc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(109)))), ((int)(((byte)(130)))));
            this.btnMisc.color = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(109)))), ((int)(((byte)(130)))));
            this.btnMisc.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(73)))));
            this.btnMisc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transFrm.SetDecoration(this.btnMisc, BunifuAnimatorNS.DecorationType.BottomMirror);
            this.transPanel.SetDecoration(this.btnMisc, BunifuAnimatorNS.DecorationType.None);
            this.btnMisc.Font = new System.Drawing.Font("Century Gothic", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMisc.ForeColor = System.Drawing.Color.White;
            this.btnMisc.Image = ((System.Drawing.Image)(resources.GetObject("btnMisc.Image")));
            this.btnMisc.ImagePosition = 15;
            this.btnMisc.ImageZoom = 50;
            this.btnMisc.LabelPosition = 30;
            this.btnMisc.LabelText = "Misc.";
            this.btnMisc.Location = new System.Drawing.Point(9, 24);
            this.btnMisc.Margin = new System.Windows.Forms.Padding(4);
            this.btnMisc.Name = "btnMisc";
            this.btnMisc.Size = new System.Drawing.Size(111, 103);
            this.btnMisc.TabIndex = 2;
            this.btnMisc.Click += new System.EventHandler(this.btnMisc_Click);
            // 
            // btnFile126
            // 
            this.btnFile126.BackColor = System.Drawing.Color.Transparent;
            this.btnFile126.color = System.Drawing.Color.Transparent;
            this.btnFile126.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(73)))));
            this.btnFile126.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transFrm.SetDecoration(this.btnFile126, BunifuAnimatorNS.DecorationType.None);
            this.transPanel.SetDecoration(this.btnFile126, BunifuAnimatorNS.DecorationType.None);
            this.btnFile126.Font = new System.Drawing.Font("Century Gothic", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFile126.ForeColor = System.Drawing.Color.DarkGray;
            this.btnFile126.Image = ((System.Drawing.Image)(resources.GetObject("btnFile126.Image")));
            this.btnFile126.ImagePosition = 7;
            this.btnFile126.ImageZoom = 30;
            this.btnFile126.LabelPosition = 20;
            this.btnFile126.LabelText = "FTP File 1, 2 and 6";
            this.btnFile126.Location = new System.Drawing.Point(15, 8);
            this.btnFile126.Margin = new System.Windows.Forms.Padding(6);
            this.btnFile126.Name = "btnFile126";
            this.btnFile126.Size = new System.Drawing.Size(121, 70);
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
            this.toolTip1.AutomaticDelay = 100;
            this.toolTip1.AutoPopDelay = 7000;
            this.toolTip1.InitialDelay = 100;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 20;
            this.toolTip1.ToolTipTitle = "Info:";
            // 
            // btnClearLocks
            // 
            this.btnClearLocks.BackColor = System.Drawing.Color.Transparent;
            this.btnClearLocks.color = System.Drawing.Color.Transparent;
            this.btnClearLocks.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(73)))));
            this.btnClearLocks.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transFrm.SetDecoration(this.btnClearLocks, BunifuAnimatorNS.DecorationType.None);
            this.transPanel.SetDecoration(this.btnClearLocks, BunifuAnimatorNS.DecorationType.None);
            this.btnClearLocks.Font = new System.Drawing.Font("Century Gothic", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearLocks.ForeColor = System.Drawing.Color.DarkGray;
            this.btnClearLocks.Image = ((System.Drawing.Image)(resources.GetObject("btnClearLocks.Image")));
            this.btnClearLocks.ImagePosition = 7;
            this.btnClearLocks.ImageZoom = 30;
            this.btnClearLocks.LabelPosition = 20;
            this.btnClearLocks.LabelText = "View Locks";
            this.btnClearLocks.Location = new System.Drawing.Point(167, 8);
            this.btnClearLocks.Margin = new System.Windows.Forms.Padding(6);
            this.btnClearLocks.Name = "btnClearLocks";
            this.btnClearLocks.Size = new System.Drawing.Size(121, 70);
            this.btnClearLocks.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btnClearLocks, "Check who\'s locking a particular record");
            this.btnClearLocks.Click += new System.EventHandler(this.btnClearLocks_Click);
            // 
            // btnItemsReport
            // 
            this.btnItemsReport.BackColor = System.Drawing.Color.Transparent;
            this.btnItemsReport.color = System.Drawing.Color.Transparent;
            this.btnItemsReport.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(73)))));
            this.btnItemsReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transFrm.SetDecoration(this.btnItemsReport, BunifuAnimatorNS.DecorationType.None);
            this.transPanel.SetDecoration(this.btnItemsReport, BunifuAnimatorNS.DecorationType.None);
            this.btnItemsReport.Font = new System.Drawing.Font("Century Gothic", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItemsReport.ForeColor = System.Drawing.Color.DarkGray;
            this.btnItemsReport.Image = ((System.Drawing.Image)(resources.GetObject("btnItemsReport.Image")));
            this.btnItemsReport.ImagePosition = 7;
            this.btnItemsReport.ImageZoom = 30;
            this.btnItemsReport.LabelPosition = 20;
            this.btnItemsReport.LabelText = "Items Report";
            this.btnItemsReport.Location = new System.Drawing.Point(319, 8);
            this.btnItemsReport.Margin = new System.Windows.Forms.Padding(6);
            this.btnItemsReport.Name = "btnItemsReport";
            this.btnItemsReport.Size = new System.Drawing.Size(121, 70);
            this.btnItemsReport.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btnItemsReport, "Opens the Items Report app");
            this.btnItemsReport.Click += new System.EventHandler(this.btnItemsReport_Click);
            // 
            // btnGetLDAP
            // 
            this.btnGetLDAP.BackColor = System.Drawing.Color.Transparent;
            this.btnGetLDAP.color = System.Drawing.Color.Transparent;
            this.btnGetLDAP.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(73)))));
            this.btnGetLDAP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transFrm.SetDecoration(this.btnGetLDAP, BunifuAnimatorNS.DecorationType.None);
            this.transPanel.SetDecoration(this.btnGetLDAP, BunifuAnimatorNS.DecorationType.None);
            this.btnGetLDAP.Font = new System.Drawing.Font("Century Gothic", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetLDAP.ForeColor = System.Drawing.Color.DarkGray;
            this.btnGetLDAP.Image = ((System.Drawing.Image)(resources.GetObject("btnGetLDAP.Image")));
            this.btnGetLDAP.ImagePosition = 7;
            this.btnGetLDAP.ImageZoom = 30;
            this.btnGetLDAP.LabelPosition = 20;
            this.btnGetLDAP.LabelText = "LDAP Search";
            this.btnGetLDAP.Location = new System.Drawing.Point(15, 87);
            this.btnGetLDAP.Margin = new System.Windows.Forms.Padding(6);
            this.btnGetLDAP.Name = "btnGetLDAP";
            this.btnGetLDAP.Size = new System.Drawing.Size(121, 70);
            this.btnGetLDAP.TabIndex = 5;
            this.toolTip1.SetToolTip(this.btnGetLDAP, "Get LDAP Info");
            this.btnGetLDAP.Click += new System.EventHandler(this.btnGetLDAP_Click);
            // 
            // btnUserLatestLogin
            // 
            this.btnUserLatestLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnUserLatestLogin.color = System.Drawing.Color.Transparent;
            this.btnUserLatestLogin.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(73)))));
            this.btnUserLatestLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transFrm.SetDecoration(this.btnUserLatestLogin, BunifuAnimatorNS.DecorationType.None);
            this.transPanel.SetDecoration(this.btnUserLatestLogin, BunifuAnimatorNS.DecorationType.None);
            this.btnUserLatestLogin.Font = new System.Drawing.Font("Century Gothic", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserLatestLogin.ForeColor = System.Drawing.Color.DarkGray;
            this.btnUserLatestLogin.Image = ((System.Drawing.Image)(resources.GetObject("btnUserLatestLogin.Image")));
            this.btnUserLatestLogin.ImagePosition = 7;
            this.btnUserLatestLogin.ImageZoom = 35;
            this.btnUserLatestLogin.LabelPosition = 20;
            this.btnUserLatestLogin.LabelText = "Search Latest Login";
            this.btnUserLatestLogin.Location = new System.Drawing.Point(167, 87);
            this.btnUserLatestLogin.Margin = new System.Windows.Forms.Padding(6);
            this.btnUserLatestLogin.Name = "btnUserLatestLogin";
            this.btnUserLatestLogin.Size = new System.Drawing.Size(121, 70);
            this.btnUserLatestLogin.TabIndex = 6;
            this.toolTip1.SetToolTip(this.btnUserLatestLogin, "Get user latest login");
            this.btnUserLatestLogin.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnUserLatestLogin_MouseClick);
            this.btnUserLatestLogin.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.btnUserLatestLogin_MouseDoubleClick);
            // 
            // btnV_FireCategories
            // 
            this.btnV_FireCategories.BackColor = System.Drawing.Color.Transparent;
            this.btnV_FireCategories.color = System.Drawing.Color.Transparent;
            this.btnV_FireCategories.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(73)))));
            this.btnV_FireCategories.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transFrm.SetDecoration(this.btnV_FireCategories, BunifuAnimatorNS.DecorationType.None);
            this.transPanel.SetDecoration(this.btnV_FireCategories, BunifuAnimatorNS.DecorationType.None);
            this.btnV_FireCategories.Font = new System.Drawing.Font("Century Gothic", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnV_FireCategories.ForeColor = System.Drawing.Color.DarkGray;
            this.btnV_FireCategories.Image = ((System.Drawing.Image)(resources.GetObject("btnV_FireCategories.Image")));
            this.btnV_FireCategories.ImagePosition = 7;
            this.btnV_FireCategories.ImageZoom = 35;
            this.btnV_FireCategories.LabelPosition = 20;
            this.btnV_FireCategories.LabelText = "vFire Categories";
            this.btnV_FireCategories.Location = new System.Drawing.Point(319, 87);
            this.btnV_FireCategories.Margin = new System.Windows.Forms.Padding(6);
            this.btnV_FireCategories.Name = "btnV_FireCategories";
            this.btnV_FireCategories.Size = new System.Drawing.Size(121, 70);
            this.btnV_FireCategories.TabIndex = 7;
            this.toolTip1.SetToolTip(this.btnV_FireCategories, "Open vFire Categories");
            this.btnV_FireCategories.Click += new System.EventHandler(this.btnV_FireCategories_Click);
            // 
            // btnSickOnStat
            // 
            this.btnSickOnStat.BackColor = System.Drawing.Color.Transparent;
            this.btnSickOnStat.color = System.Drawing.Color.Transparent;
            this.btnSickOnStat.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(73)))));
            this.btnSickOnStat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transFrm.SetDecoration(this.btnSickOnStat, BunifuAnimatorNS.DecorationType.None);
            this.transPanel.SetDecoration(this.btnSickOnStat, BunifuAnimatorNS.DecorationType.None);
            this.btnSickOnStat.Font = new System.Drawing.Font("Century Gothic", 6.792453F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSickOnStat.ForeColor = System.Drawing.Color.DarkGray;
            this.btnSickOnStat.Image = ((System.Drawing.Image)(resources.GetObject("btnSickOnStat.Image")));
            this.btnSickOnStat.ImagePosition = 1;
            this.btnSickOnStat.ImageZoom = 30;
            this.btnSickOnStat.LabelPosition = 30;
            this.btnSickOnStat.LabelText = "Upload Sick on a Stat File from ePeople";
            this.btnSickOnStat.Location = new System.Drawing.Point(15, 168);
            this.btnSickOnStat.Margin = new System.Windows.Forms.Padding(5);
            this.btnSickOnStat.Name = "btnSickOnStat";
            this.btnSickOnStat.Size = new System.Drawing.Size(121, 70);
            this.btnSickOnStat.TabIndex = 8;
            this.toolTip1.SetToolTip(this.btnSickOnStat, "Upload Sick on a Stat File from ePeople to BOO database");
            this.btnSickOnStat.Click += new System.EventHandler(this.btnSickOnStat_Click);
            // 
            // btnUserTrainings
            // 
            this.btnUserTrainings.BackColor = System.Drawing.Color.Transparent;
            this.btnUserTrainings.color = System.Drawing.Color.Transparent;
            this.btnUserTrainings.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(73)))));
            this.btnUserTrainings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transFrm.SetDecoration(this.btnUserTrainings, BunifuAnimatorNS.DecorationType.None);
            this.transPanel.SetDecoration(this.btnUserTrainings, BunifuAnimatorNS.DecorationType.None);
            this.btnUserTrainings.Font = new System.Drawing.Font("Century Gothic", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserTrainings.ForeColor = System.Drawing.Color.DarkGray;
            this.btnUserTrainings.Image = ((System.Drawing.Image)(resources.GetObject("btnUserTrainings.Image")));
            this.btnUserTrainings.ImagePosition = 1;
            this.btnUserTrainings.ImageZoom = 35;
            this.btnUserTrainings.LabelPosition = 20;
            this.btnUserTrainings.LabelText = "User Trainings (SSRS)";
            this.btnUserTrainings.Location = new System.Drawing.Point(319, 168);
            this.btnUserTrainings.Margin = new System.Windows.Forms.Padding(6);
            this.btnUserTrainings.Name = "btnUserTrainings";
            this.btnUserTrainings.Size = new System.Drawing.Size(121, 70);
            this.btnUserTrainings.TabIndex = 10;
            this.toolTip1.SetToolTip(this.btnUserTrainings, "Open User Trainings data from SSRS");
            this.btnUserTrainings.Click += new System.EventHandler(this.btnUserTrainings_Click);
            // 
            // btnESPbatchAccess
            // 
            this.btnESPbatchAccess.BackColor = System.Drawing.Color.Transparent;
            this.btnESPbatchAccess.color = System.Drawing.Color.Transparent;
            this.btnESPbatchAccess.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(73)))));
            this.btnESPbatchAccess.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transFrm.SetDecoration(this.btnESPbatchAccess, BunifuAnimatorNS.DecorationType.None);
            this.transPanel.SetDecoration(this.btnESPbatchAccess, BunifuAnimatorNS.DecorationType.None);
            this.btnESPbatchAccess.Font = new System.Drawing.Font("Century Gothic", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnESPbatchAccess.ForeColor = System.Drawing.Color.DarkGray;
            this.btnESPbatchAccess.Image = ((System.Drawing.Image)(resources.GetObject("btnESPbatchAccess.Image")));
            this.btnESPbatchAccess.ImagePosition = 7;
            this.btnESPbatchAccess.ImageZoom = 35;
            this.btnESPbatchAccess.LabelPosition = 20;
            this.btnESPbatchAccess.LabelText = "ESP Batch Access";
            this.btnESPbatchAccess.Location = new System.Drawing.Point(15, 249);
            this.btnESPbatchAccess.Margin = new System.Windows.Forms.Padding(6);
            this.btnESPbatchAccess.Name = "btnESPbatchAccess";
            this.btnESPbatchAccess.Size = new System.Drawing.Size(121, 70);
            this.btnESPbatchAccess.TabIndex = 11;
            this.toolTip1.SetToolTip(this.btnESPbatchAccess, "ESP batch access for unit implementation");
            this.btnESPbatchAccess.Click += new System.EventHandler(this.btnESPbatchAccess_Click);
            // 
            // bunifuTileButton1
            // 
            this.bunifuTileButton1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTileButton1.color = System.Drawing.Color.Transparent;
            this.bunifuTileButton1.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(73)))));
            this.bunifuTileButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transFrm.SetDecoration(this.bunifuTileButton1, BunifuAnimatorNS.DecorationType.None);
            this.transPanel.SetDecoration(this.bunifuTileButton1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTileButton1.Font = new System.Drawing.Font("Century Gothic", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuTileButton1.ForeColor = System.Drawing.Color.DarkGray;
            this.bunifuTileButton1.Image = ((System.Drawing.Image)(resources.GetObject("bunifuTileButton1.Image")));
            this.bunifuTileButton1.ImagePosition = 7;
            this.bunifuTileButton1.ImageZoom = 35;
            this.bunifuTileButton1.LabelPosition = 20;
            this.bunifuTileButton1.LabelText = "Primary vs Pay Info";
            this.bunifuTileButton1.Location = new System.Drawing.Point(167, 168);
            this.bunifuTileButton1.Margin = new System.Windows.Forms.Padding(6);
            this.bunifuTileButton1.Name = "bunifuTileButton1";
            this.bunifuTileButton1.Size = new System.Drawing.Size(121, 70);
            this.bunifuTileButton1.TabIndex = 12;
            this.toolTip1.SetToolTip(this.bunifuTileButton1, "Check Primary vs Pay Info if there are mismatch per unit");
            this.bunifuTileButton1.Click += new System.EventHandler(this.bunifuTileButton1_Click);
            // 
            // btnRemote
            // 
            this.btnRemote.BackColor = System.Drawing.Color.Transparent;
            this.btnRemote.color = System.Drawing.Color.Transparent;
            this.btnRemote.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(73)))));
            this.btnRemote.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transFrm.SetDecoration(this.btnRemote, BunifuAnimatorNS.DecorationType.None);
            this.transPanel.SetDecoration(this.btnRemote, BunifuAnimatorNS.DecorationType.None);
            this.btnRemote.Font = new System.Drawing.Font("Century Gothic", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemote.ForeColor = System.Drawing.Color.DarkGray;
            this.btnRemote.Image = ((System.Drawing.Image)(resources.GetObject("btnRemote.Image")));
            this.btnRemote.ImagePosition = 0;
            this.btnRemote.ImageZoom = 35;
            this.btnRemote.LabelPosition = 35;
            this.btnRemote.LabelText = "Remote a PC using LanDesk";
            this.btnRemote.Location = new System.Drawing.Point(471, 6);
            this.btnRemote.Margin = new System.Windows.Forms.Padding(6);
            this.btnRemote.Name = "btnRemote";
            this.btnRemote.Size = new System.Drawing.Size(121, 70);
            this.btnRemote.TabIndex = 13;
            this.toolTip1.SetToolTip(this.btnRemote, "Remote control a PC using LANDESK");
            this.btnRemote.Click += new System.EventHandler(this.btnRemote_Click);
            // 
            // bunifuTileButton2
            // 
            this.bunifuTileButton2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTileButton2.color = System.Drawing.Color.Transparent;
            this.bunifuTileButton2.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(73)))));
            this.bunifuTileButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transFrm.SetDecoration(this.bunifuTileButton2, BunifuAnimatorNS.DecorationType.None);
            this.transPanel.SetDecoration(this.bunifuTileButton2, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTileButton2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuTileButton2.ForeColor = System.Drawing.Color.DarkGray;
            this.bunifuTileButton2.Image = ((System.Drawing.Image)(resources.GetObject("bunifuTileButton2.Image")));
            this.bunifuTileButton2.ImagePosition = 0;
            this.bunifuTileButton2.ImageZoom = 30;
            this.bunifuTileButton2.LabelPosition = 35;
            this.bunifuTileButton2.LabelText = "Update Valid Email Suffixes in ASC";
            this.bunifuTileButton2.Location = new System.Drawing.Point(471, 87);
            this.bunifuTileButton2.Margin = new System.Windows.Forms.Padding(5);
            this.bunifuTileButton2.Name = "bunifuTileButton2";
            this.bunifuTileButton2.Size = new System.Drawing.Size(121, 70);
            this.bunifuTileButton2.TabIndex = 14;
            this.toolTip1.SetToolTip(this.bunifuTileButton2, "Update the list of valid email suffixes in ASC");
            this.bunifuTileButton2.Click += new System.EventHandler(this.bunifuTileButton2_Click);
            // 
            // btnExceptionLookup
            // 
            this.btnExceptionLookup.BackColor = System.Drawing.Color.Transparent;
            this.btnExceptionLookup.color = System.Drawing.Color.Transparent;
            this.btnExceptionLookup.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(73)))));
            this.btnExceptionLookup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transFrm.SetDecoration(this.btnExceptionLookup, BunifuAnimatorNS.DecorationType.None);
            this.transPanel.SetDecoration(this.btnExceptionLookup, BunifuAnimatorNS.DecorationType.None);
            this.btnExceptionLookup.Font = new System.Drawing.Font("Century Gothic", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExceptionLookup.ForeColor = System.Drawing.Color.DarkGray;
            this.btnExceptionLookup.Image = ((System.Drawing.Image)(resources.GetObject("btnExceptionLookup.Image")));
            this.btnExceptionLookup.ImagePosition = 1;
            this.btnExceptionLookup.ImageZoom = 35;
            this.btnExceptionLookup.LabelPosition = 20;
            this.btnExceptionLookup.LabelText = "Exception Lookup";
            this.btnExceptionLookup.Location = new System.Drawing.Point(167, 249);
            this.btnExceptionLookup.Margin = new System.Windows.Forms.Padding(6);
            this.btnExceptionLookup.Name = "btnExceptionLookup";
            this.btnExceptionLookup.Size = new System.Drawing.Size(121, 70);
            this.btnExceptionLookup.TabIndex = 9;
            this.btnExceptionLookup.Click += new System.EventHandler(this.btnExceptionLookup_Click);
            // 
            // lblClose
            // 
            this.lblClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transPanel.SetDecoration(this.lblClose, BunifuAnimatorNS.DecorationType.None);
            this.transFrm.SetDecoration(this.lblClose, BunifuAnimatorNS.DecorationType.None);
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
            this.transPanel.SetDecoration(this.label1, BunifuAnimatorNS.DecorationType.None);
            this.transFrm.SetDecoration(this.label1, BunifuAnimatorNS.DecorationType.None);
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
            this.pnlMisc.Controls.Add(this.bunifuTileButton2);
            this.pnlMisc.Controls.Add(this.btnRemote);
            this.pnlMisc.Controls.Add(this.bunifuTileButton1);
            this.pnlMisc.Controls.Add(this.btnUserTrainings);
            this.pnlMisc.Controls.Add(this.btnFile126);
            this.pnlMisc.Controls.Add(this.btnClearLocks);
            this.pnlMisc.Controls.Add(this.btnESPbatchAccess);
            this.pnlMisc.Controls.Add(this.btnItemsReport);
            this.pnlMisc.Controls.Add(this.btnUploadFile1);
            this.pnlMisc.Controls.Add(this.btnGetLDAP);
            this.pnlMisc.Controls.Add(this.btnExceptionLookup);
            this.pnlMisc.Controls.Add(this.btnUserLatestLogin);
            this.pnlMisc.Controls.Add(this.btnSickOnStat);
            this.pnlMisc.Controls.Add(this.btnV_FireCategories);
            this.transFrm.SetDecoration(this.pnlMisc, BunifuAnimatorNS.DecorationType.None);
            this.transPanel.SetDecoration(this.pnlMisc, BunifuAnimatorNS.DecorationType.None);
            this.pnlMisc.Location = new System.Drawing.Point(132, 32);
            this.pnlMisc.Name = "pnlMisc";
            this.pnlMisc.Size = new System.Drawing.Size(603, 325);
            this.pnlMisc.TabIndex = 14;
            this.pnlMisc.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.frmMainNew_MouseDoubleClick);
            // 
            // btnUploadFile1
            // 
            this.btnUploadFile1.BackColor = System.Drawing.Color.Transparent;
            this.btnUploadFile1.color = System.Drawing.Color.Transparent;
            this.btnUploadFile1.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(73)))));
            this.btnUploadFile1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transFrm.SetDecoration(this.btnUploadFile1, BunifuAnimatorNS.DecorationType.None);
            this.transPanel.SetDecoration(this.btnUploadFile1, BunifuAnimatorNS.DecorationType.None);
            this.btnUploadFile1.Font = new System.Drawing.Font("Century Gothic", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadFile1.ForeColor = System.Drawing.Color.DarkGray;
            this.btnUploadFile1.Image = ((System.Drawing.Image)(resources.GetObject("btnUploadFile1.Image")));
            this.btnUploadFile1.ImagePosition = 1;
            this.btnUploadFile1.ImageZoom = 35;
            this.btnUploadFile1.LabelPosition = 30;
            this.btnUploadFile1.LabelText = "Upload File 1 for NFP Checking";
            this.btnUploadFile1.Location = new System.Drawing.Point(319, 249);
            this.btnUploadFile1.Name = "btnUploadFile1";
            this.btnUploadFile1.Size = new System.Drawing.Size(121, 70);
            this.btnUploadFile1.TabIndex = 27;
            this.btnUploadFile1.Click += new System.EventHandler(this.btnUploadFile1_Click);
            // 
            // pnlFormatting
            // 
            this.pnlFormatting.Controls.Add(this.btnFormatSickOnStat);
            this.pnlFormatting.Controls.Add(this.btnFormatA06);
            this.pnlFormatting.Controls.Add(this.btnFormatTAER);
            this.pnlFormatting.Controls.Add(this.btnEmailNegStat);
            this.pnlFormatting.Controls.Add(this.btnFile6);
            this.pnlFormatting.Controls.Add(this.btnFile2);
            this.pnlFormatting.Controls.Add(this.btnAA_Exception);
            this.pnlFormatting.Controls.Add(this.btnTL_SYS);
            this.pnlFormatting.Controls.Add(this.btnLOAwithNoRptTime);
            this.pnlFormatting.Controls.Add(this.btnRFLOA);
            this.pnlFormatting.Controls.Add(this.btnRehire);
            this.pnlFormatting.Controls.Add(this.btnPriors);
            this.pnlFormatting.Controls.Add(this.btnBanks);
            this.pnlFormatting.Controls.Add(this.btnTrans);
            this.pnlFormatting.Controls.Add(this.btnAHS_AA_Terms);
            this.transFrm.SetDecoration(this.pnlFormatting, BunifuAnimatorNS.DecorationType.None);
            this.transPanel.SetDecoration(this.pnlFormatting, BunifuAnimatorNS.DecorationType.None);
            this.pnlFormatting.Location = new System.Drawing.Point(136, 411);
            this.pnlFormatting.Name = "pnlFormatting";
            this.pnlFormatting.Size = new System.Drawing.Size(603, 325);
            this.pnlFormatting.TabIndex = 15;
            this.pnlFormatting.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.frmMainNew_MouseDoubleClick);
            // 
            // btnFormatSickOnStat
            // 
            this.btnFormatSickOnStat.BackColor = System.Drawing.Color.Transparent;
            this.btnFormatSickOnStat.color = System.Drawing.Color.Transparent;
            this.btnFormatSickOnStat.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(73)))));
            this.btnFormatSickOnStat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transFrm.SetDecoration(this.btnFormatSickOnStat, BunifuAnimatorNS.DecorationType.None);
            this.transPanel.SetDecoration(this.btnFormatSickOnStat, BunifuAnimatorNS.DecorationType.None);
            this.btnFormatSickOnStat.Font = new System.Drawing.Font("Century Gothic", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFormatSickOnStat.ForeColor = System.Drawing.Color.DarkGray;
            this.btnFormatSickOnStat.Image = ((System.Drawing.Image)(resources.GetObject("btnFormatSickOnStat.Image")));
            this.btnFormatSickOnStat.ImagePosition = 5;
            this.btnFormatSickOnStat.ImageZoom = 30;
            this.btnFormatSickOnStat.LabelPosition = 20;
            this.btnFormatSickOnStat.LabelText = "Format Sick On A Stat";
            this.btnFormatSickOnStat.Location = new System.Drawing.Point(470, 171);
            this.btnFormatSickOnStat.Name = "btnFormatSickOnStat";
            this.btnFormatSickOnStat.Size = new System.Drawing.Size(120, 70);
            this.btnFormatSickOnStat.TabIndex = 37;
            this.btnFormatSickOnStat.Click += new System.EventHandler(this.btnFormatSickOnStat_Click);
            // 
            // btnFormatA06
            // 
            this.btnFormatA06.BackColor = System.Drawing.Color.Transparent;
            this.btnFormatA06.color = System.Drawing.Color.Transparent;
            this.btnFormatA06.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(73)))));
            this.btnFormatA06.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transFrm.SetDecoration(this.btnFormatA06, BunifuAnimatorNS.DecorationType.None);
            this.transPanel.SetDecoration(this.btnFormatA06, BunifuAnimatorNS.DecorationType.None);
            this.btnFormatA06.Font = new System.Drawing.Font("Century Gothic", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFormatA06.ForeColor = System.Drawing.Color.DarkGray;
            this.btnFormatA06.Image = ((System.Drawing.Image)(resources.GetObject("btnFormatA06.Image")));
            this.btnFormatA06.ImagePosition = 1;
            this.btnFormatA06.ImageZoom = 30;
            this.btnFormatA06.LabelPosition = 20;
            this.btnFormatA06.LabelText = "Format A06";
            this.btnFormatA06.Location = new System.Drawing.Point(320, 247);
            this.btnFormatA06.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFormatA06.Name = "btnFormatA06";
            this.btnFormatA06.Size = new System.Drawing.Size(121, 70);
            this.btnFormatA06.TabIndex = 36;
            this.btnFormatA06.Click += new System.EventHandler(this.btnFormatA06_Click);
            // 
            // btnFormatTAER
            // 
            this.btnFormatTAER.BackColor = System.Drawing.Color.Transparent;
            this.btnFormatTAER.color = System.Drawing.Color.Transparent;
            this.btnFormatTAER.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(73)))));
            this.btnFormatTAER.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transFrm.SetDecoration(this.btnFormatTAER, BunifuAnimatorNS.DecorationType.None);
            this.transPanel.SetDecoration(this.btnFormatTAER, BunifuAnimatorNS.DecorationType.None);
            this.btnFormatTAER.Font = new System.Drawing.Font("Century Gothic", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFormatTAER.ForeColor = System.Drawing.Color.DarkGray;
            this.btnFormatTAER.Image = ((System.Drawing.Image)(resources.GetObject("btnFormatTAER.Image")));
            this.btnFormatTAER.ImagePosition = 1;
            this.btnFormatTAER.ImageZoom = 35;
            this.btnFormatTAER.LabelPosition = 20;
            this.btnFormatTAER.LabelText = "Format TAER";
            this.btnFormatTAER.Location = new System.Drawing.Point(171, 247);
            this.btnFormatTAER.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFormatTAER.Name = "btnFormatTAER";
            this.btnFormatTAER.Size = new System.Drawing.Size(121, 70);
            this.btnFormatTAER.TabIndex = 35;
            this.btnFormatTAER.Click += new System.EventHandler(this.btnFormatTAER_Click);
            // 
            // btnEmailNegStat
            // 
            this.btnEmailNegStat.BackColor = System.Drawing.Color.Transparent;
            this.btnEmailNegStat.color = System.Drawing.Color.Transparent;
            this.btnEmailNegStat.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(73)))));
            this.btnEmailNegStat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transFrm.SetDecoration(this.btnEmailNegStat, BunifuAnimatorNS.DecorationType.None);
            this.transPanel.SetDecoration(this.btnEmailNegStat, BunifuAnimatorNS.DecorationType.None);
            this.btnEmailNegStat.Font = new System.Drawing.Font("Century Gothic", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmailNegStat.ForeColor = System.Drawing.Color.DarkGray;
            this.btnEmailNegStat.Image = ((System.Drawing.Image)(resources.GetObject("btnEmailNegStat.Image")));
            this.btnEmailNegStat.ImagePosition = 1;
            this.btnEmailNegStat.ImageZoom = 35;
            this.btnEmailNegStat.LabelPosition = 20;
            this.btnEmailNegStat.LabelText = "Format Negative Stats";
            this.btnEmailNegStat.Location = new System.Drawing.Point(320, 171);
            this.btnEmailNegStat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEmailNegStat.Name = "btnEmailNegStat";
            this.btnEmailNegStat.Size = new System.Drawing.Size(121, 70);
            this.btnEmailNegStat.TabIndex = 34;
            this.btnEmailNegStat.Click += new System.EventHandler(this.btnEmailNegStat_Click);
            // 
            // btnFile6
            // 
            this.btnFile6.BackColor = System.Drawing.Color.Transparent;
            this.btnFile6.color = System.Drawing.Color.Transparent;
            this.btnFile6.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(73)))));
            this.btnFile6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transFrm.SetDecoration(this.btnFile6, BunifuAnimatorNS.DecorationType.None);
            this.transPanel.SetDecoration(this.btnFile6, BunifuAnimatorNS.DecorationType.None);
            this.btnFile6.Font = new System.Drawing.Font("Century Gothic", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFile6.ForeColor = System.Drawing.Color.DarkGray;
            this.btnFile6.Image = ((System.Drawing.Image)(resources.GetObject("btnFile6.Image")));
            this.btnFile6.ImagePosition = 1;
            this.btnFile6.ImageZoom = 35;
            this.btnFile6.LabelPosition = 20;
            this.btnFile6.LabelText = "Format File 6";
            this.btnFile6.Location = new System.Drawing.Point(469, 87);
            this.btnFile6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFile6.Name = "btnFile6";
            this.btnFile6.Size = new System.Drawing.Size(121, 70);
            this.btnFile6.TabIndex = 33;
            this.btnFile6.Click += new System.EventHandler(this.btnFile6_Click);
            // 
            // btnFile2
            // 
            this.btnFile2.BackColor = System.Drawing.Color.Transparent;
            this.btnFile2.color = System.Drawing.Color.Transparent;
            this.btnFile2.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(73)))));
            this.btnFile2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transFrm.SetDecoration(this.btnFile2, BunifuAnimatorNS.DecorationType.None);
            this.transPanel.SetDecoration(this.btnFile2, BunifuAnimatorNS.DecorationType.None);
            this.btnFile2.Font = new System.Drawing.Font("Century Gothic", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFile2.ForeColor = System.Drawing.Color.DarkGray;
            this.btnFile2.Image = ((System.Drawing.Image)(resources.GetObject("btnFile2.Image")));
            this.btnFile2.ImagePosition = 1;
            this.btnFile2.ImageZoom = 35;
            this.btnFile2.LabelPosition = 20;
            this.btnFile2.LabelText = "Format File 2";
            this.btnFile2.Location = new System.Drawing.Point(470, 7);
            this.btnFile2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFile2.Name = "btnFile2";
            this.btnFile2.Size = new System.Drawing.Size(121, 70);
            this.btnFile2.TabIndex = 32;
            this.btnFile2.Click += new System.EventHandler(this.btnFile2_Click);
            // 
            // btnAA_Exception
            // 
            this.btnAA_Exception.BackColor = System.Drawing.Color.Transparent;
            this.btnAA_Exception.color = System.Drawing.Color.Transparent;
            this.btnAA_Exception.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(73)))));
            this.btnAA_Exception.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transFrm.SetDecoration(this.btnAA_Exception, BunifuAnimatorNS.DecorationType.None);
            this.transPanel.SetDecoration(this.btnAA_Exception, BunifuAnimatorNS.DecorationType.None);
            this.btnAA_Exception.Font = new System.Drawing.Font("Century Gothic", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAA_Exception.ForeColor = System.Drawing.Color.DarkGray;
            this.btnAA_Exception.Image = ((System.Drawing.Image)(resources.GetObject("btnAA_Exception.Image")));
            this.btnAA_Exception.ImagePosition = 1;
            this.btnAA_Exception.ImageZoom = 35;
            this.btnAA_Exception.LabelPosition = 20;
            this.btnAA_Exception.LabelText = "AA_EXCEPTION";
            this.btnAA_Exception.Location = new System.Drawing.Point(320, 87);
            this.btnAA_Exception.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAA_Exception.Name = "btnAA_Exception";
            this.btnAA_Exception.Size = new System.Drawing.Size(121, 70);
            this.btnAA_Exception.TabIndex = 29;
            this.btnAA_Exception.Click += new System.EventHandler(this.btnAA_Exception_Click);
            // 
            // btnTL_SYS
            // 
            this.btnTL_SYS.BackColor = System.Drawing.Color.Transparent;
            this.btnTL_SYS.color = System.Drawing.Color.Transparent;
            this.btnTL_SYS.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(73)))));
            this.btnTL_SYS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transFrm.SetDecoration(this.btnTL_SYS, BunifuAnimatorNS.DecorationType.None);
            this.transPanel.SetDecoration(this.btnTL_SYS, BunifuAnimatorNS.DecorationType.None);
            this.btnTL_SYS.Font = new System.Drawing.Font("Century Gothic", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTL_SYS.ForeColor = System.Drawing.Color.DarkGray;
            this.btnTL_SYS.Image = ((System.Drawing.Image)(resources.GetObject("btnTL_SYS.Image")));
            this.btnTL_SYS.ImagePosition = 1;
            this.btnTL_SYS.ImageZoom = 35;
            this.btnTL_SYS.LabelPosition = 20;
            this.btnTL_SYS.LabelText = "TL_SYS";
            this.btnTL_SYS.Location = new System.Drawing.Point(320, 7);
            this.btnTL_SYS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTL_SYS.Name = "btnTL_SYS";
            this.btnTL_SYS.Size = new System.Drawing.Size(121, 70);
            this.btnTL_SYS.TabIndex = 28;
            this.btnTL_SYS.Click += new System.EventHandler(this.btnTL_SYS_Click);
            // 
            // btnLOAwithNoRptTime
            // 
            this.btnLOAwithNoRptTime.BackColor = System.Drawing.Color.Transparent;
            this.btnLOAwithNoRptTime.color = System.Drawing.Color.Transparent;
            this.btnLOAwithNoRptTime.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(73)))));
            this.btnLOAwithNoRptTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transFrm.SetDecoration(this.btnLOAwithNoRptTime, BunifuAnimatorNS.DecorationType.None);
            this.transPanel.SetDecoration(this.btnLOAwithNoRptTime, BunifuAnimatorNS.DecorationType.None);
            this.btnLOAwithNoRptTime.Font = new System.Drawing.Font("Century Gothic", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLOAwithNoRptTime.ForeColor = System.Drawing.Color.DarkGray;
            this.btnLOAwithNoRptTime.Image = ((System.Drawing.Image)(resources.GetObject("btnLOAwithNoRptTime.Image")));
            this.btnLOAwithNoRptTime.ImagePosition = 1;
            this.btnLOAwithNoRptTime.ImageZoom = 35;
            this.btnLOAwithNoRptTime.LabelPosition = 20;
            this.btnLOAwithNoRptTime.LabelText = "AA_RPTD_NO_TIME";
            this.btnLOAwithNoRptTime.Location = new System.Drawing.Point(171, 171);
            this.btnLOAwithNoRptTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLOAwithNoRptTime.Name = "btnLOAwithNoRptTime";
            this.btnLOAwithNoRptTime.Size = new System.Drawing.Size(121, 70);
            this.btnLOAwithNoRptTime.TabIndex = 26;
            this.btnLOAwithNoRptTime.Click += new System.EventHandler(this.btnLOAwithNoRptTime_Click);
            // 
            // btnRFLOA
            // 
            this.btnRFLOA.BackColor = System.Drawing.Color.Transparent;
            this.btnRFLOA.color = System.Drawing.Color.Transparent;
            this.btnRFLOA.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(73)))));
            this.btnRFLOA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transFrm.SetDecoration(this.btnRFLOA, BunifuAnimatorNS.DecorationType.None);
            this.transPanel.SetDecoration(this.btnRFLOA, BunifuAnimatorNS.DecorationType.None);
            this.btnRFLOA.Font = new System.Drawing.Font("Century Gothic", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRFLOA.ForeColor = System.Drawing.Color.DarkGray;
            this.btnRFLOA.Image = ((System.Drawing.Image)(resources.GetObject("btnRFLOA.Image")));
            this.btnRFLOA.ImagePosition = 1;
            this.btnRFLOA.ImageZoom = 35;
            this.btnRFLOA.LabelPosition = 20;
            this.btnRFLOA.LabelText = "Return from LOA";
            this.btnRFLOA.Location = new System.Drawing.Point(171, 89);
            this.btnRFLOA.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRFLOA.Name = "btnRFLOA";
            this.btnRFLOA.Size = new System.Drawing.Size(121, 70);
            this.btnRFLOA.TabIndex = 25;
            this.btnRFLOA.Click += new System.EventHandler(this.btnRFLOA_Click);
            // 
            // btnRehire
            // 
            this.btnRehire.BackColor = System.Drawing.Color.Transparent;
            this.btnRehire.color = System.Drawing.Color.Transparent;
            this.btnRehire.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(73)))));
            this.btnRehire.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transFrm.SetDecoration(this.btnRehire, BunifuAnimatorNS.DecorationType.None);
            this.transPanel.SetDecoration(this.btnRehire, BunifuAnimatorNS.DecorationType.None);
            this.btnRehire.Font = new System.Drawing.Font("Century Gothic", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRehire.ForeColor = System.Drawing.Color.DarkGray;
            this.btnRehire.Image = ((System.Drawing.Image)(resources.GetObject("btnRehire.Image")));
            this.btnRehire.ImagePosition = 1;
            this.btnRehire.ImageZoom = 35;
            this.btnRehire.LabelPosition = 20;
            this.btnRehire.LabelText = "Rehires";
            this.btnRehire.Location = new System.Drawing.Point(171, 7);
            this.btnRehire.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRehire.Name = "btnRehire";
            this.btnRehire.Size = new System.Drawing.Size(121, 70);
            this.btnRehire.TabIndex = 24;
            this.btnRehire.Click += new System.EventHandler(this.btnRehire_Click);
            // 
            // btnPriors
            // 
            this.btnPriors.BackColor = System.Drawing.Color.Transparent;
            this.btnPriors.color = System.Drawing.Color.Transparent;
            this.btnPriors.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(73)))));
            this.btnPriors.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transFrm.SetDecoration(this.btnPriors, BunifuAnimatorNS.DecorationType.None);
            this.transPanel.SetDecoration(this.btnPriors, BunifuAnimatorNS.DecorationType.None);
            this.btnPriors.Font = new System.Drawing.Font("Century Gothic", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPriors.ForeColor = System.Drawing.Color.DarkGray;
            this.btnPriors.Image = ((System.Drawing.Image)(resources.GetObject("btnPriors.Image")));
            this.btnPriors.ImagePosition = 1;
            this.btnPriors.ImageZoom = 32;
            this.btnPriors.LabelPosition = 30;
            this.btnPriors.LabelText = "Prior Pay Period Adjustment";
            this.btnPriors.Location = new System.Drawing.Point(22, 247);
            this.btnPriors.Name = "btnPriors";
            this.btnPriors.Size = new System.Drawing.Size(121, 70);
            this.btnPriors.TabIndex = 23;
            this.btnPriors.Click += new System.EventHandler(this.btnPriors_Click);
            // 
            // btnBanks
            // 
            this.btnBanks.BackColor = System.Drawing.Color.Transparent;
            this.btnBanks.color = System.Drawing.Color.Transparent;
            this.btnBanks.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(73)))));
            this.btnBanks.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transFrm.SetDecoration(this.btnBanks, BunifuAnimatorNS.DecorationType.None);
            this.transPanel.SetDecoration(this.btnBanks, BunifuAnimatorNS.DecorationType.None);
            this.btnBanks.Font = new System.Drawing.Font("Century Gothic", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBanks.ForeColor = System.Drawing.Color.DarkGray;
            this.btnBanks.Image = ((System.Drawing.Image)(resources.GetObject("btnBanks.Image")));
            this.btnBanks.ImagePosition = 1;
            this.btnBanks.ImageZoom = 35;
            this.btnBanks.LabelPosition = 20;
            this.btnBanks.LabelText = "Off Codes Vs Banks";
            this.btnBanks.Location = new System.Drawing.Point(22, 171);
            this.btnBanks.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBanks.Name = "btnBanks";
            this.btnBanks.Size = new System.Drawing.Size(121, 70);
            this.btnBanks.TabIndex = 22;
            this.btnBanks.Click += new System.EventHandler(this.btnBanks_Click);
            // 
            // btnTrans
            // 
            this.btnTrans.BackColor = System.Drawing.Color.Transparent;
            this.btnTrans.color = System.Drawing.Color.Transparent;
            this.btnTrans.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(73)))));
            this.btnTrans.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transFrm.SetDecoration(this.btnTrans, BunifuAnimatorNS.DecorationType.None);
            this.transPanel.SetDecoration(this.btnTrans, BunifuAnimatorNS.DecorationType.None);
            this.btnTrans.Font = new System.Drawing.Font("Century Gothic", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrans.ForeColor = System.Drawing.Color.DarkGray;
            this.btnTrans.Image = ((System.Drawing.Image)(resources.GetObject("btnTrans.Image")));
            this.btnTrans.ImagePosition = 1;
            this.btnTrans.ImageZoom = 35;
            this.btnTrans.LabelPosition = 20;
            this.btnTrans.LabelText = "AHS_AA_ TRANSFER_RPT";
            this.btnTrans.Location = new System.Drawing.Point(22, 87);
            this.btnTrans.Name = "btnTrans";
            this.btnTrans.Size = new System.Drawing.Size(121, 70);
            this.btnTrans.TabIndex = 21;
            this.btnTrans.Click += new System.EventHandler(this.btnTrans_Click);
            // 
            // btnAHS_AA_Terms
            // 
            this.btnAHS_AA_Terms.BackColor = System.Drawing.Color.Transparent;
            this.btnAHS_AA_Terms.color = System.Drawing.Color.Transparent;
            this.btnAHS_AA_Terms.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(73)))));
            this.btnAHS_AA_Terms.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transFrm.SetDecoration(this.btnAHS_AA_Terms, BunifuAnimatorNS.DecorationType.None);
            this.transPanel.SetDecoration(this.btnAHS_AA_Terms, BunifuAnimatorNS.DecorationType.None);
            this.btnAHS_AA_Terms.Font = new System.Drawing.Font("Century Gothic", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAHS_AA_Terms.ForeColor = System.Drawing.Color.DarkGray;
            this.btnAHS_AA_Terms.Image = ((System.Drawing.Image)(resources.GetObject("btnAHS_AA_Terms.Image")));
            this.btnAHS_AA_Terms.ImagePosition = 1;
            this.btnAHS_AA_Terms.ImageZoom = 35;
            this.btnAHS_AA_Terms.LabelPosition = 20;
            this.btnAHS_AA_Terms.LabelText = "AHS_AA_TERMS";
            this.btnAHS_AA_Terms.Location = new System.Drawing.Point(22, 7);
            this.btnAHS_AA_Terms.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAHS_AA_Terms.Name = "btnAHS_AA_Terms";
            this.btnAHS_AA_Terms.Size = new System.Drawing.Size(121, 70);
            this.btnAHS_AA_Terms.TabIndex = 20;
            this.btnAHS_AA_Terms.Click += new System.EventHandler(this.btnAHS_AA_Terms_Click);
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.label6);
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
            this.pnlSearch.Controls.Add(this.label7);
            this.pnlSearch.Controls.Add(this.label3);
            this.pnlSearch.Controls.Add(this.label5);
            this.transFrm.SetDecoration(this.pnlSearch, BunifuAnimatorNS.DecorationType.None);
            this.transPanel.SetDecoration(this.pnlSearch, BunifuAnimatorNS.DecorationType.None);
            this.pnlSearch.Location = new System.Drawing.Point(884, 275);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(603, 325);
            this.pnlSearch.TabIndex = 17;
            this.pnlSearch.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.frmMainNew_MouseDoubleClick);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.transPanel.SetDecoration(this.label6, BunifuAnimatorNS.DecorationType.None);
            this.transFrm.SetDecoration(this.label6, BunifuAnimatorNS.DecorationType.None);
            this.label6.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(253, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 20);
            this.label6.TabIndex = 44;
            this.label6.Text = "Unit:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.transPanel.SetDecoration(this.label4, BunifuAnimatorNS.DecorationType.None);
            this.transFrm.SetDecoration(this.label4, BunifuAnimatorNS.DecorationType.None);
            this.label4.Image = ((System.Drawing.Image)(resources.GetObject("label4.Image")));
            this.label4.Location = new System.Drawing.Point(36, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 25);
            this.label4.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.transPanel.SetDecoration(this.label2, BunifuAnimatorNS.DecorationType.None);
            this.transFrm.SetDecoration(this.label2, BunifuAnimatorNS.DecorationType.None);
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(42, 37);
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
            this.transPanel.SetDecoration(this.txtUnit, BunifuAnimatorNS.DecorationType.None);
            this.transFrm.SetDecoration(this.txtUnit, BunifuAnimatorNS.DecorationType.None);
            this.txtUnit.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnit.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtUnit.Location = new System.Drawing.Point(300, 78);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(290, 26);
            this.txtUnit.TabIndex = 43;
            this.txtUnit.TextChanged += new System.EventHandler(this.txtUnit_TextChanged);
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.transPanel.SetDecoration(this.btnSendEmail, BunifuAnimatorNS.DecorationType.BottomMirror);
            this.transFrm.SetDecoration(this.btnSendEmail, BunifuAnimatorNS.DecorationType.None);
            this.btnSendEmail.Enabled = false;
            this.btnSendEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.792453F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnSendEmail.Image = ((System.Drawing.Image)(resources.GetObject("btnSendEmail.Image")));
            this.btnSendEmail.Location = new System.Drawing.Point(454, 130);
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
            this.transFrm.SetDecoration(this.lstResult, BunifuAnimatorNS.DecorationType.None);
            this.transPanel.SetDecoration(this.lstResult, BunifuAnimatorNS.DecorationType.None);
            this.lstResult.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstResult.ForeColor = System.Drawing.Color.GreenYellow;
            this.lstResult.FormattingEnabled = true;
            this.lstResult.ItemHeight = 16;
            this.lstResult.Location = new System.Drawing.Point(17, 115);
            this.lstResult.Name = "lstResult";
            this.lstResult.Size = new System.Drawing.Size(432, 98);
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
            this.transPanel.SetDecoration(this.lblMsg, BunifuAnimatorNS.DecorationType.None);
            this.transFrm.SetDecoration(this.lblMsg, BunifuAnimatorNS.DecorationType.None);
            this.lblMsg.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.lblMsg.Location = new System.Drawing.Point(19, 257);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 18);
            this.lblMsg.TabIndex = 38;
            // 
            // txtOCode
            // 
            this.txtOCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtOCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.txtOCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.transPanel.SetDecoration(this.txtOCode, BunifuAnimatorNS.DecorationType.None);
            this.transFrm.SetDecoration(this.txtOCode, BunifuAnimatorNS.DecorationType.None);
            this.txtOCode.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOCode.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtOCode.Location = new System.Drawing.Point(300, 6);
            this.txtOCode.Name = "txtOCode";
            this.txtOCode.Size = new System.Drawing.Size(92, 26);
            this.txtOCode.TabIndex = 34;
            this.txtOCode.TextChanged += new System.EventHandler(this.txtOCode_TextChanged);
            // 
            // txtEmpNo
            // 
            this.txtEmpNo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtEmpNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.txtEmpNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.transPanel.SetDecoration(this.txtEmpNo, BunifuAnimatorNS.DecorationType.None);
            this.transFrm.SetDecoration(this.txtEmpNo, BunifuAnimatorNS.DecorationType.None);
            this.txtEmpNo.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmpNo.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtEmpNo.Location = new System.Drawing.Point(300, 41);
            this.txtEmpNo.Name = "txtEmpNo";
            this.txtEmpNo.Size = new System.Drawing.Size(290, 26);
            this.txtEmpNo.TabIndex = 36;
            this.txtEmpNo.TextChanged += new System.EventHandler(this.txtEmpNo_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.lblPayPeriod);
            this.transFrm.SetDecoration(this.groupBox1, BunifuAnimatorNS.DecorationType.None);
            this.transPanel.SetDecoration(this.groupBox1, BunifuAnimatorNS.DecorationType.None);
            this.groupBox1.Location = new System.Drawing.Point(19, 271);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(430, 42);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            // 
            // dateTimePicker1
            // 
            this.transPanel.SetDecoration(this.dateTimePicker1, BunifuAnimatorNS.DecorationType.None);
            this.transFrm.SetDecoration(this.dateTimePicker1, BunifuAnimatorNS.DecorationType.None);
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(6, 15);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(203, 18);
            this.dateTimePicker1.TabIndex = 7;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // lblPayPeriod
            // 
            this.transPanel.SetDecoration(this.lblPayPeriod, BunifuAnimatorNS.DecorationType.None);
            this.transFrm.SetDecoration(this.lblPayPeriod, BunifuAnimatorNS.DecorationType.None);
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
            this.txtTCG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTCG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transPanel.SetDecoration(this.txtTCG, BunifuAnimatorNS.DecorationType.None);
            this.transFrm.SetDecoration(this.txtTCG, BunifuAnimatorNS.DecorationType.None);
            this.txtTCG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtTCG.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTCG.ForeColor = System.Drawing.Color.GreenYellow;
            this.txtTCG.Location = new System.Drawing.Point(17, 227);
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
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.transPanel.SetDecoration(this.label7, BunifuAnimatorNS.DecorationType.None);
            this.transFrm.SetDecoration(this.label7, BunifuAnimatorNS.DecorationType.None);
            this.label7.Image = ((System.Drawing.Image)(resources.GetObject("label7.Image")));
            this.label7.Location = new System.Drawing.Point(145, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 25);
            this.label7.TabIndex = 46;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.transPanel.SetDecoration(this.label3, BunifuAnimatorNS.DecorationType.None);
            this.transFrm.SetDecoration(this.label3, BunifuAnimatorNS.DecorationType.None);
            this.label3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(128, -2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 35);
            this.label3.TabIndex = 35;
            this.label3.Text = "Occupation Code:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.transPanel.SetDecoration(this.label5, BunifuAnimatorNS.DecorationType.None);
            this.transFrm.SetDecoration(this.label5, BunifuAnimatorNS.DecorationType.None);
            this.label5.Image = ((System.Drawing.Image)(resources.GetObject("label5.Image")));
            this.label5.Location = new System.Drawing.Point(219, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 25);
            this.label5.TabIndex = 45;
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
            this.transFrm.SetDecoration(this.mnuCopyFromList, BunifuAnimatorNS.DecorationType.None);
            this.transPanel.SetDecoration(this.mnuCopyFromList, BunifuAnimatorNS.DecorationType.None);
            this.mnuCopyFromList.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.mnuCopyFromList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCopyEmpNum,
            this.mnuCopyEmpName,
            this.mnuCopyBothNameAndNum});
            this.mnuCopyFromList.Name = "mnuCopyFromList";
            this.mnuCopyFromList.Size = new System.Drawing.Size(295, 76);
            this.mnuCopyFromList.Text = "CopyFromList";
            // 
            // mnuCopyEmpNum
            // 
            this.mnuCopyEmpNum.Image = ((System.Drawing.Image)(resources.GetObject("mnuCopyEmpNum.Image")));
            this.mnuCopyEmpNum.Name = "mnuCopyEmpNum";
            this.mnuCopyEmpNum.Size = new System.Drawing.Size(294, 24);
            this.mnuCopyEmpNum.Text = "Copy Emp # to clipboard";
            this.mnuCopyEmpNum.Click += new System.EventHandler(this.mnuCopyEmpNum_Click);
            // 
            // mnuCopyEmpName
            // 
            this.mnuCopyEmpName.Image = ((System.Drawing.Image)(resources.GetObject("mnuCopyEmpName.Image")));
            this.mnuCopyEmpName.Name = "mnuCopyEmpName";
            this.mnuCopyEmpName.Size = new System.Drawing.Size(294, 24);
            this.mnuCopyEmpName.Text = "Copy Emp Name to clipboard";
            this.mnuCopyEmpName.Click += new System.EventHandler(this.mnuCopyEmpName_Click);
            // 
            // mnuCopyBothNameAndNum
            // 
            this.mnuCopyBothNameAndNum.Image = ((System.Drawing.Image)(resources.GetObject("mnuCopyBothNameAndNum.Image")));
            this.mnuCopyBothNameAndNum.Name = "mnuCopyBothNameAndNum";
            this.mnuCopyBothNameAndNum.Size = new System.Drawing.Size(294, 24);
            this.mnuCopyBothNameAndNum.Text = "Copy Both Emp Name and # to clipboard";
            this.mnuCopyBothNameAndNum.Click += new System.EventHandler(this.mnuCopyBothNameAndNum_Click);
            // 
            // contextMenuStrip1
            // 
            this.transFrm.SetDecoration(this.contextMenuStrip1, BunifuAnimatorNS.DecorationType.None);
            this.transPanel.SetDecoration(this.contextMenuStrip1, BunifuAnimatorNS.DecorationType.None);
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSendEmail});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(174, 26);
            // 
            // mnuSendEmail
            // 
            this.mnuSendEmail.Name = "mnuSendEmail";
            this.mnuSendEmail.Size = new System.Drawing.Size(173, 22);
            this.mnuSendEmail.Text = "Send Email To SSO";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // transPanel
            // 
            this.transPanel.AnimationType = BunifuAnimatorNS.AnimationType.HorizSlide;
            this.transPanel.Cursor = null;
            animation14.AnimateOnlyDifferences = true;
            animation14.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation14.BlindCoeff")));
            animation14.LeafCoeff = 0F;
            animation14.MaxTime = 1F;
            animation14.MinTime = 0F;
            animation14.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation14.MosaicCoeff")));
            animation14.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation14.MosaicShift")));
            animation14.MosaicSize = 0;
            animation14.Padding = new System.Windows.Forms.Padding(0);
            animation14.RotateCoeff = 0F;
            animation14.RotateLimit = 0F;
            animation14.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation14.ScaleCoeff")));
            animation14.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation14.SlideCoeff")));
            animation14.TimeCoeff = 0F;
            animation14.TransparencyCoeff = 0F;
            this.transPanel.DefaultAnimation = animation14;
            // 
            // mnuFormat2and6
            // 
            this.mnuFormat2and6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(109)))), ((int)(((byte)(130)))));
            this.transFrm.SetDecoration(this.mnuFormat2and6, BunifuAnimatorNS.DecorationType.None);
            this.transPanel.SetDecoration(this.mnuFormat2and6, BunifuAnimatorNS.DecorationType.None);
            this.mnuFormat2and6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuFormat2and6.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formatFile2ToolStripMenuItem,
            this.formatFile6ToolStripMenuItem});
            this.mnuFormat2and6.Name = "mnuFormat2and6";
            this.mnuFormat2and6.Size = new System.Drawing.Size(156, 48);
            // 
            // formatFile2ToolStripMenuItem
            // 
            this.formatFile2ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.formatFile2ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("formatFile2ToolStripMenuItem.Image")));
            this.formatFile2ToolStripMenuItem.Name = "formatFile2ToolStripMenuItem";
            this.formatFile2ToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.formatFile2ToolStripMenuItem.Text = "Format File 2";
            // 
            // formatFile6ToolStripMenuItem
            // 
            this.formatFile6ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.formatFile6ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("formatFile6ToolStripMenuItem.Image")));
            this.formatFile6ToolStripMenuItem.Name = "formatFile6ToolStripMenuItem";
            this.formatFile6ToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.formatFile6ToolStripMenuItem.Text = "Format File 6";
            // 
            // transFrm
            // 
            this.transFrm.AnimationType = BunifuAnimatorNS.AnimationType.ScaleAndRotate;
            this.transFrm.Cursor = null;
            animation13.AnimateOnlyDifferences = true;
            animation13.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation13.BlindCoeff")));
            animation13.LeafCoeff = 0F;
            animation13.MaxTime = 1F;
            animation13.MinTime = 0F;
            animation13.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation13.MosaicCoeff")));
            animation13.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation13.MosaicShift")));
            animation13.MosaicSize = 0;
            animation13.Padding = new System.Windows.Forms.Padding(30);
            animation13.RotateCoeff = 0.5F;
            animation13.RotateLimit = 0.2F;
            animation13.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation13.ScaleCoeff")));
            animation13.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation13.SlideCoeff")));
            animation13.TimeCoeff = 0F;
            animation13.TransparencyCoeff = 0F;
            this.transFrm.DefaultAnimation = animation13;
            this.transFrm.TimeStep = 0.03F;
            // 
            // frmMainNew
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(45)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(1512, 756);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlFormatting);
            this.Controls.Add(this.pnlMisc);
            this.Controls.Add(this.pnlMain);
            this.transFrm.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.transPanel.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMainNew";
            this.Opacity = 0.8D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SömëKindä Tööl v2018.06.11";
            this.Activated += new System.EventHandler(this.frmMainNew_Activated);
            this.Deactivate += new System.EventHandler(this.frmMainNew_Deactivate);
            this.Load += new System.EventHandler(this.frmMainNew_Load);
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
            this.mnuFormat2and6.ResumeLayout(false);
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
        private BunifuAnimatorNS.BunifuTransition transPanel;
        private BunifuAnimatorNS.BunifuTransition transFrm;
        private Bunifu.Framework.UI.BunifuTileButton btnFormatTAER;
        private Bunifu.Framework.UI.BunifuTileButton bunifuTileButton1;
        private Bunifu.Framework.UI.BunifuTileButton btnRemote;
        private Bunifu.Framework.UI.BunifuTileButton bunifuTileButton2;
        private Bunifu.Framework.UI.BunifuTileButton btnFormatA06;
        private Bunifu.Framework.UI.BunifuTileButton btnFormatSickOnStat;
        private System.Windows.Forms.ContextMenuStrip mnuFormat2and6;
        private System.Windows.Forms.ToolStripMenuItem formatFile2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formatFile6ToolStripMenuItem;
    }
}