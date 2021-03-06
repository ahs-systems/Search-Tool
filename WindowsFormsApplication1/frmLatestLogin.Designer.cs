﻿namespace SearchTool
{
    partial class frmLatestLogin
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
            BunifuAnimatorNS.Animation animation1 = new BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLatestLogin));
            this.txtEmpName = new System.Windows.Forms.TextBox();
            this.lstResult = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLastLoginDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmpNo = new System.Windows.Forms.TextBox();
            this.btnSearchName = new System.Windows.Forms.Button();
            this.btnSearchByEmpNo = new System.Windows.Forms.Button();
            this.transFrm = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.lblMinimize = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtEmpName
            // 
            this.txtEmpName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.txtEmpName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.transFrm.SetDecoration(this.txtEmpName, BunifuAnimatorNS.DecorationType.None);
            this.txtEmpName.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtEmpName.Location = new System.Drawing.Point(184, 42);
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.Size = new System.Drawing.Size(160, 20);
            this.txtEmpName.TabIndex = 0;
            this.txtEmpName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmpName_KeyPress);
            // 
            // lstResult
            // 
            this.lstResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.lstResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.transFrm.SetDecoration(this.lstResult, BunifuAnimatorNS.DecorationType.None);
            this.lstResult.ForeColor = System.Drawing.Color.GreenYellow;
            this.lstResult.FormattingEnabled = true;
            this.lstResult.Location = new System.Drawing.Point(8, 116);
            this.lstResult.Name = "lstResult";
            this.lstResult.Size = new System.Drawing.Size(382, 106);
            this.lstResult.TabIndex = 25;
            this.lstResult.Click += new System.EventHandler(this.lstResult_Click);
            this.lstResult.SelectedIndexChanged += new System.EventHandler(this.lstResult_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.transFrm.SetDecoration(this.label2, BunifuAnimatorNS.DecorationType.None);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(18, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Part of first name or last name:";
            // 
            // lblLastLoginDate
            // 
            this.transFrm.SetDecoration(this.lblLastLoginDate, BunifuAnimatorNS.DecorationType.None);
            this.lblLastLoginDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastLoginDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.lblLastLoginDate.Location = new System.Drawing.Point(10, 230);
            this.lblLastLoginDate.Name = "lblLastLoginDate";
            this.lblLastLoginDate.Size = new System.Drawing.Size(378, 23);
            this.lblLastLoginDate.TabIndex = 29;
            this.lblLastLoginDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.transFrm.SetDecoration(this.label1, BunifuAnimatorNS.DecorationType.None);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(69, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Employeer Number:";
            // 
            // txtEmpNo
            // 
            this.txtEmpNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.txtEmpNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.transFrm.SetDecoration(this.txtEmpNo, BunifuAnimatorNS.DecorationType.None);
            this.txtEmpNo.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtEmpNo.Location = new System.Drawing.Point(184, 84);
            this.txtEmpNo.Name = "txtEmpNo";
            this.txtEmpNo.Size = new System.Drawing.Size(160, 20);
            this.txtEmpNo.TabIndex = 32;
            this.txtEmpNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmpNo_KeyPress);
            // 
            // btnSearchName
            // 
            this.transFrm.SetDecoration(this.btnSearchName, BunifuAnimatorNS.DecorationType.None);
            this.btnSearchName.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchName.Image")));
            this.btnSearchName.Location = new System.Drawing.Point(351, 35);
            this.btnSearchName.Name = "btnSearchName";
            this.btnSearchName.Size = new System.Drawing.Size(38, 34);
            this.btnSearchName.TabIndex = 33;
            this.btnSearchName.UseVisualStyleBackColor = true;
            this.btnSearchName.Click += new System.EventHandler(this.btnSearchName_Click);
            // 
            // btnSearchByEmpNo
            // 
            this.transFrm.SetDecoration(this.btnSearchByEmpNo, BunifuAnimatorNS.DecorationType.None);
            this.btnSearchByEmpNo.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchByEmpNo.Image")));
            this.btnSearchByEmpNo.Location = new System.Drawing.Point(351, 77);
            this.btnSearchByEmpNo.Name = "btnSearchByEmpNo";
            this.btnSearchByEmpNo.Size = new System.Drawing.Size(38, 34);
            this.btnSearchByEmpNo.TabIndex = 34;
            this.btnSearchByEmpNo.UseVisualStyleBackColor = true;
            this.btnSearchByEmpNo.Click += new System.EventHandler(this.btnSearchByEmpNo_Click);
            // 
            // transFrm
            // 
            this.transFrm.AnimationType = BunifuAnimatorNS.AnimationType.ScaleAndRotate;
            this.transFrm.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(30);
            animation1.RotateCoeff = 0.5F;
            animation1.RotateLimit = 0.2F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 0F;
            this.transFrm.DefaultAnimation = animation1;
            this.transFrm.MaxAnimationTime = 2000;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.transFrm.SetDecoration(this.lblTitle, BunifuAnimatorNS.DecorationType.None);
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(397, 29);
            this.lblTitle.TabIndex = 53;
            this.lblTitle.Text = "Search Latest Login";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblClose
            // 
            this.lblClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.transFrm.SetDecoration(this.lblClose, BunifuAnimatorNS.DecorationType.None);
            this.lblClose.Image = ((System.Drawing.Image)(resources.GetObject("lblClose.Image")));
            this.lblClose.Location = new System.Drawing.Point(369, 3);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(22, 23);
            this.lblClose.TabIndex = 62;
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.lblTitle;
            this.bunifuDragControl1.Vertical = true;
            // 
            // lblMinimize
            // 
            this.lblMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.lblMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transFrm.SetDecoration(this.lblMinimize, BunifuAnimatorNS.DecorationType.None);
            this.lblMinimize.Image = ((System.Drawing.Image)(resources.GetObject("lblMinimize.Image")));
            this.lblMinimize.Location = new System.Drawing.Point(346, 3);
            this.lblMinimize.Name = "lblMinimize";
            this.lblMinimize.Size = new System.Drawing.Size(22, 23);
            this.lblMinimize.TabIndex = 70;
            this.lblMinimize.Click += new System.EventHandler(this.lblMinimize_Click);
            // 
            // frmLatestLogin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(45)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(397, 261);
            this.Controls.Add(this.lblMinimize);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnSearchByEmpNo);
            this.Controls.Add(this.btnSearchName);
            this.Controls.Add(this.txtEmpNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblLastLoginDate);
            this.Controls.Add(this.txtEmpName);
            this.Controls.Add(this.lstResult);
            this.Controls.Add(this.label2);
            this.transFrm.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLatestLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Search Latest Login";
            this.Load += new System.EventHandler(this.frmLatestLogin_Load);
            this.Shown += new System.EventHandler(this.frmLatestLogin_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEmpName;
        private System.Windows.Forms.ListBox lstResult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblLastLoginDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmpNo;
        private System.Windows.Forms.Button btnSearchName;
        private System.Windows.Forms.Button btnSearchByEmpNo;
        private BunifuAnimatorNS.BunifuTransition transFrm;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Label lblMinimize;
    }
}