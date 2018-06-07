namespace PSSTool
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
            this.lblClose = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.lstResult = new System.Windows.Forms.ListBox();
            this.txtOCode = new System.Windows.Forms.TextBox();
            this.txtEmpNo = new System.Windows.Forms.TextBox();
            this.txtTCG = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.btnSendEmail = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboZone = new System.Windows.Forms.ComboBox();
            this.mnuCopyFromList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuCopyEmpNum = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopyEmpName = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopyBothNameAndNum = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopyFromList.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblClose
            // 
            this.lblClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.lblClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClose.Image = ((System.Drawing.Image)(resources.GetObject("lblClose.Image")));
            this.lblClose.Location = new System.Drawing.Point(672, 3);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(22, 23);
            this.lblClose.TabIndex = 64;
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
            this.lblTitle.Size = new System.Drawing.Size(701, 29);
            this.lblTitle.TabIndex = 63;
            this.lblTitle.Text = "   Search";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.lblTitle;
            this.bunifuDragControl1.Vertical = true;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Image = ((System.Drawing.Image)(resources.GetObject("label4.Image")));
            this.label4.Location = new System.Drawing.Point(31, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 25);
            this.label4.TabIndex = 71;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(49, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(252, 26);
            this.label2.TabIndex = 69;
            this.label2.Text = "Emp No or LastName or FirstName:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUnit
            // 
            this.txtUnit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.txtUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUnit.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnit.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtUnit.Location = new System.Drawing.Point(307, 163);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(241, 26);
            this.txtUnit.TabIndex = 72;
            this.txtUnit.TextChanged += new System.EventHandler(this.txtUnit_TextChanged);
            // 
            // lstResult
            // 
            this.lstResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.lstResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstResult.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstResult.ForeColor = System.Drawing.Color.GreenYellow;
            this.lstResult.FormattingEnabled = true;
            this.lstResult.ItemHeight = 16;
            this.lstResult.Location = new System.Drawing.Point(26, 203);
            this.lstResult.Name = "lstResult";
            this.lstResult.Size = new System.Drawing.Size(522, 114);
            this.lstResult.TabIndex = 65;
            this.lstResult.Click += new System.EventHandler(this.lstResult_Click);
            this.lstResult.SelectedIndexChanged += new System.EventHandler(this.lstResult_Click);
            this.lstResult.DoubleClick += new System.EventHandler(this.lstResult_DoubleClick);
            this.lstResult.MouseLeave += new System.EventHandler(this.lstResult_MouseLeave);
            this.lstResult.MouseHover += new System.EventHandler(this.lstResult_MouseHover);
            this.lstResult.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lstResult_MouseUp);
            // 
            // txtOCode
            // 
            this.txtOCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.txtOCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOCode.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOCode.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtOCode.Location = new System.Drawing.Point(307, 83);
            this.txtOCode.Name = "txtOCode";
            this.txtOCode.Size = new System.Drawing.Size(92, 26);
            this.txtOCode.TabIndex = 66;
            this.txtOCode.TextChanged += new System.EventHandler(this.txtOCode_TextChanged);
            // 
            // txtEmpNo
            // 
            this.txtEmpNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.txtEmpNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmpNo.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmpNo.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtEmpNo.Location = new System.Drawing.Point(307, 123);
            this.txtEmpNo.Name = "txtEmpNo";
            this.txtEmpNo.Size = new System.Drawing.Size(241, 26);
            this.txtEmpNo.TabIndex = 68;
            this.txtEmpNo.TextChanged += new System.EventHandler(this.txtEmpNo_TextChanged);
            // 
            // txtTCG
            // 
            this.txtTCG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.txtTCG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTCG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtTCG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtTCG.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTCG.ForeColor = System.Drawing.Color.GreenYellow;
            this.txtTCG.Location = new System.Drawing.Point(26, 325);
            this.txtTCG.Name = "txtTCG";
            this.txtTCG.Size = new System.Drawing.Size(522, 23);
            this.txtTCG.TabIndex = 70;
            this.txtTCG.Text = "label3";
            this.txtTCG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtTCG.Visible = false;
            this.txtTCG.DoubleClick += new System.EventHandler(this.txtTCG_DoubleClick);
            this.txtTCG.MouseLeave += new System.EventHandler(this.txtTCG_MouseLeave);
            this.txtTCG.MouseHover += new System.EventHandler(this.txtTCG_MouseHover);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Image = ((System.Drawing.Image)(resources.GetObject("label5.Image")));
            this.label5.Location = new System.Drawing.Point(235, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 25);
            this.label5.TabIndex = 74;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Image = ((System.Drawing.Image)(resources.GetObject("label7.Image")));
            this.label7.Location = new System.Drawing.Point(134, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 25);
            this.label7.TabIndex = 75;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(135, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 35);
            this.label3.TabIndex = 67;
            this.label3.Text = "Occupation Code:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(224, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 20);
            this.label6.TabIndex = 73;
            this.label6.Text = "Unit:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMsg
            // 
            this.lblMsg.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.lblMsg.Location = new System.Drawing.Point(23, 357);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(522, 27);
            this.lblMsg.TabIndex = 76;
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.btnSendEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.792453F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnSendEmail.Image = ((System.Drawing.Image)(resources.GetObject("btnSendEmail.Image")));
            this.btnSendEmail.Location = new System.Drawing.Point(554, 203);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(136, 48);
            this.btnSendEmail.TabIndex = 77;
            this.btnSendEmail.Text = "Send Email";
            this.btnSendEmail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSendEmail.UseVisualStyleBackColor = false;
            this.btnSendEmail.Visible = false;
            this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(219, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 19);
            this.label1.TabIndex = 78;
            this.label1.Text = "Database:";
            // 
            // cboZone
            // 
            this.cboZone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.cboZone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboZone.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboZone.ForeColor = System.Drawing.Color.Gainsboro;
            this.cboZone.FormattingEnabled = true;
            this.cboZone.Items.AddRange(new object[] {
            "CAL",
            "NCS",
            "EDM"});
            this.cboZone.Location = new System.Drawing.Point(307, 43);
            this.cboZone.Name = "cboZone";
            this.cboZone.Size = new System.Drawing.Size(121, 26);
            this.cboZone.TabIndex = 79;
            this.cboZone.SelectedIndexChanged += new System.EventHandler(this.cboZone_SelectedIndexChanged);
            // 
            // mnuCopyFromList
            // 
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
            // frmSearch
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(45)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(701, 403);
            this.Controls.Add(this.cboZone);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSendEmail);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.lstResult);
            this.Controls.Add(this.txtOCode);
            this.Controls.Add(this.txtEmpNo);
            this.Controls.Add(this.txtTCG);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmSearch";
            this.Load += new System.EventHandler(this.frmSearch_Load);
            this.mnuCopyFromList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Label lblTitle;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.ListBox lstResult;
        private System.Windows.Forms.TextBox txtOCode;
        private System.Windows.Forms.TextBox txtEmpNo;
        private System.Windows.Forms.Label txtTCG;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Button btnSendEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboZone;
        private System.Windows.Forms.ContextMenuStrip mnuCopyFromList;
        private System.Windows.Forms.ToolStripMenuItem mnuCopyEmpNum;
        private System.Windows.Forms.ToolStripMenuItem mnuCopyEmpName;
        private System.Windows.Forms.ToolStripMenuItem mnuCopyBothNameAndNum;
    }
}