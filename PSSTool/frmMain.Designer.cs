namespace PSSTool
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lblClose = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.btnGetLDAP = new Bunifu.Framework.UI.BunifuTileButton();
            this.bunifuTileButton2 = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnEmpUnitSearch = new Bunifu.Framework.UI.BunifuTileButton();
            this.timerClose = new System.Windows.Forms.Timer(this.components);
            this.lblMinimize = new System.Windows.Forms.Label();
            this.btnClearLocks = new Bunifu.Framework.UI.BunifuTileButton();
            this.SuspendLayout();
            // 
            // lblClose
            // 
            this.lblClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.lblClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClose.Image = ((System.Drawing.Image)(resources.GetObject("lblClose.Image")));
            this.lblClose.Location = new System.Drawing.Point(536, 3);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(22, 23);
            this.lblClose.TabIndex = 62;
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(562, 29);
            this.lblTitle.TabIndex = 61;
            this.lblTitle.Text = "PSS Tool v2018.07.05";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.lblTitle;
            this.bunifuDragControl1.Vertical = true;
            // 
            // btnGetLDAP
            // 
            this.btnGetLDAP.BackColor = System.Drawing.Color.Transparent;
            this.btnGetLDAP.color = System.Drawing.Color.Transparent;
            this.btnGetLDAP.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(73)))));
            this.btnGetLDAP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGetLDAP.Font = new System.Drawing.Font("Century Gothic", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetLDAP.ForeColor = System.Drawing.Color.DarkGray;
            this.btnGetLDAP.Image = ((System.Drawing.Image)(resources.GetObject("btnGetLDAP.Image")));
            this.btnGetLDAP.ImagePosition = 7;
            this.btnGetLDAP.ImageZoom = 30;
            this.btnGetLDAP.LabelPosition = 20;
            this.btnGetLDAP.LabelText = "LDAP Search";
            this.btnGetLDAP.Location = new System.Drawing.Point(18, 45);
            this.btnGetLDAP.Margin = new System.Windows.Forms.Padding(6);
            this.btnGetLDAP.Name = "btnGetLDAP";
            this.btnGetLDAP.Size = new System.Drawing.Size(121, 70);
            this.btnGetLDAP.TabIndex = 63;
            this.btnGetLDAP.Click += new System.EventHandler(this.btnGetLDAP_Click);
            // 
            // bunifuTileButton2
            // 
            this.bunifuTileButton2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTileButton2.color = System.Drawing.Color.Transparent;
            this.bunifuTileButton2.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(73)))));
            this.bunifuTileButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTileButton2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuTileButton2.ForeColor = System.Drawing.Color.DarkGray;
            this.bunifuTileButton2.Image = ((System.Drawing.Image)(resources.GetObject("bunifuTileButton2.Image")));
            this.bunifuTileButton2.ImagePosition = 0;
            this.bunifuTileButton2.ImageZoom = 30;
            this.bunifuTileButton2.LabelPosition = 35;
            this.bunifuTileButton2.LabelText = "Update Valid Email Suffixes in ASC";
            this.bunifuTileButton2.Location = new System.Drawing.Point(153, 45);
            this.bunifuTileButton2.Margin = new System.Windows.Forms.Padding(5);
            this.bunifuTileButton2.Name = "bunifuTileButton2";
            this.bunifuTileButton2.Size = new System.Drawing.Size(121, 70);
            this.bunifuTileButton2.TabIndex = 64;
            this.bunifuTileButton2.Click += new System.EventHandler(this.bunifuTileButton2_Click);
            // 
            // btnEmpUnitSearch
            // 
            this.btnEmpUnitSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnEmpUnitSearch.color = System.Drawing.Color.Transparent;
            this.btnEmpUnitSearch.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(73)))));
            this.btnEmpUnitSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEmpUnitSearch.Font = new System.Drawing.Font("Century Gothic", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmpUnitSearch.ForeColor = System.Drawing.Color.DarkGray;
            this.btnEmpUnitSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnEmpUnitSearch.Image")));
            this.btnEmpUnitSearch.ImagePosition = 0;
            this.btnEmpUnitSearch.ImageZoom = 32;
            this.btnEmpUnitSearch.LabelPosition = 32;
            this.btnEmpUnitSearch.LabelText = "Emp/Unit Search in ESP";
            this.btnEmpUnitSearch.Location = new System.Drawing.Point(288, 45);
            this.btnEmpUnitSearch.Margin = new System.Windows.Forms.Padding(6);
            this.btnEmpUnitSearch.Name = "btnEmpUnitSearch";
            this.btnEmpUnitSearch.Size = new System.Drawing.Size(121, 70);
            this.btnEmpUnitSearch.TabIndex = 65;
            this.btnEmpUnitSearch.Click += new System.EventHandler(this.btnEmpUnitSearch_Click);
            // 
            // timerClose
            // 
            this.timerClose.Interval = 3600000;
            this.timerClose.Tick += new System.EventHandler(this.timerClose_Tick);
            // 
            // lblMinimize
            // 
            this.lblMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.lblMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMinimize.Image = ((System.Drawing.Image)(resources.GetObject("lblMinimize.Image")));
            this.lblMinimize.Location = new System.Drawing.Point(513, 3);
            this.lblMinimize.Name = "lblMinimize";
            this.lblMinimize.Size = new System.Drawing.Size(22, 23);
            this.lblMinimize.TabIndex = 72;
            this.lblMinimize.Click += new System.EventHandler(this.lblMinimize_Click);
            // 
            // btnClearLocks
            // 
            this.btnClearLocks.BackColor = System.Drawing.Color.Transparent;
            this.btnClearLocks.color = System.Drawing.Color.Transparent;
            this.btnClearLocks.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(73)))));
            this.btnClearLocks.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearLocks.Font = new System.Drawing.Font("Century Gothic", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearLocks.ForeColor = System.Drawing.Color.DarkGray;
            this.btnClearLocks.Image = ((System.Drawing.Image)(resources.GetObject("btnClearLocks.Image")));
            this.btnClearLocks.ImagePosition = 3;
            this.btnClearLocks.ImageZoom = 25;
            this.btnClearLocks.LabelPosition = 35;
            this.btnClearLocks.LabelText = "Search Locked Records in ESP";
            this.btnClearLocks.Location = new System.Drawing.Point(423, 45);
            this.btnClearLocks.Margin = new System.Windows.Forms.Padding(6);
            this.btnClearLocks.Name = "btnClearLocks";
            this.btnClearLocks.Size = new System.Drawing.Size(121, 72);
            this.btnClearLocks.TabIndex = 73;
            this.btnClearLocks.Click += new System.EventHandler(this.btnClearLocks_Click);
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(45)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(562, 132);
            this.Controls.Add(this.btnClearLocks);
            this.Controls.Add(this.lblMinimize);
            this.Controls.Add(this.btnEmpUnitSearch);
            this.Controls.Add(this.bunifuTileButton2);
            this.Controls.Add(this.btnGetLDAP);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Label lblTitle;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuTileButton btnGetLDAP;
        private Bunifu.Framework.UI.BunifuTileButton bunifuTileButton2;
        private Bunifu.Framework.UI.BunifuTileButton btnEmpUnitSearch;
        private System.Windows.Forms.Timer timerClose;
        private System.Windows.Forms.Label lblMinimize;
        private Bunifu.Framework.UI.BunifuTileButton btnClearLocks;
    }
}

