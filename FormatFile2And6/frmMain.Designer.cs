namespace FormatFile2And6
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboZone = new Bunifu.Framework.UI.BunifuDropdown();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFile2 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnFile6 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.lblExit = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timerClose = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(99, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Zone: ";
            // 
            // cboZone
            // 
            this.cboZone.BackColor = System.Drawing.Color.Transparent;
            this.cboZone.BorderRadius = 3;
            this.cboZone.DisabledColor = System.Drawing.Color.Gray;
            this.cboZone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboZone.ForeColor = System.Drawing.Color.White;
            this.cboZone.Items = new string[] {
        "Edmonton",
        "NCS"};
            this.cboZone.Location = new System.Drawing.Point(154, 45);
            this.cboZone.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboZone.Name = "cboZone";
            this.cboZone.NomalColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(128)))), ((int)(((byte)(30)))));
            this.cboZone.onHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(106)))), ((int)(((byte)(25)))));
            this.cboZone.selectedIndex = -1;
            this.cboZone.Size = new System.Drawing.Size(217, 35);
            this.cboZone.TabIndex = 4;
            this.cboZone.onItemSelected += new System.EventHandler(this.cboZone_SelectedIndexChanged);
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.panel1;
            this.bunifuDragControl1.Vertical = true;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(481, 28);
            this.panel1.TabIndex = 10;
            // 
            // btnFile2
            // 
            this.btnFile2.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(106)))), ((int)(((byte)(25)))));
            this.btnFile2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(128)))), ((int)(((byte)(30)))));
            this.btnFile2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFile2.BorderRadius = 0;
            this.btnFile2.ButtonText = "Format File 2";
            this.btnFile2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFile2.DisabledColor = System.Drawing.Color.Gray;
            this.btnFile2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.792453F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFile2.Iconcolor = System.Drawing.Color.Transparent;
            this.btnFile2.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnFile2.Iconimage")));
            this.btnFile2.Iconimage_right = null;
            this.btnFile2.Iconimage_right_Selected = null;
            this.btnFile2.Iconimage_Selected = null;
            this.btnFile2.IconMarginLeft = 0;
            this.btnFile2.IconMarginRight = 0;
            this.btnFile2.IconRightVisible = true;
            this.btnFile2.IconRightZoom = 0D;
            this.btnFile2.IconVisible = true;
            this.btnFile2.IconZoom = 50D;
            this.btnFile2.IsTab = false;
            this.btnFile2.Location = new System.Drawing.Point(37, 112);
            this.btnFile2.Name = "btnFile2";
            this.btnFile2.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(128)))), ((int)(((byte)(30)))));
            this.btnFile2.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(106)))), ((int)(((byte)(25)))));
            this.btnFile2.OnHoverTextColor = System.Drawing.Color.White;
            this.btnFile2.selected = false;
            this.btnFile2.Size = new System.Drawing.Size(184, 57);
            this.btnFile2.TabIndex = 6;
            this.btnFile2.Text = "Format File 2";
            this.btnFile2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnFile2.Textcolor = System.Drawing.Color.White;
            this.btnFile2.TextFont = new System.Drawing.Font("Century Gothic", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFile2.Click += new System.EventHandler(this.btnFile2_Click);
            // 
            // btnFile6
            // 
            this.btnFile6.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(106)))), ((int)(((byte)(25)))));
            this.btnFile6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(128)))), ((int)(((byte)(30)))));
            this.btnFile6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFile6.BorderRadius = 0;
            this.btnFile6.ButtonText = "Format Type 6 From File 1";
            this.btnFile6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFile6.DisabledColor = System.Drawing.Color.Gray;
            this.btnFile6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.792453F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFile6.Iconcolor = System.Drawing.Color.Transparent;
            this.btnFile6.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnFile6.Iconimage")));
            this.btnFile6.Iconimage_right = null;
            this.btnFile6.Iconimage_right_Selected = null;
            this.btnFile6.Iconimage_Selected = null;
            this.btnFile6.IconMarginLeft = 0;
            this.btnFile6.IconMarginRight = 0;
            this.btnFile6.IconRightVisible = true;
            this.btnFile6.IconRightZoom = 0D;
            this.btnFile6.IconVisible = true;
            this.btnFile6.IconZoom = 50D;
            this.btnFile6.IsTab = false;
            this.btnFile6.Location = new System.Drawing.Point(259, 112);
            this.btnFile6.Name = "btnFile6";
            this.btnFile6.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(128)))), ((int)(((byte)(30)))));
            this.btnFile6.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(106)))), ((int)(((byte)(25)))));
            this.btnFile6.OnHoverTextColor = System.Drawing.Color.White;
            this.btnFile6.selected = false;
            this.btnFile6.Size = new System.Drawing.Size(184, 57);
            this.btnFile6.TabIndex = 7;
            this.btnFile6.Text = "Format Type 6 From File 1";
            this.btnFile6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnFile6.Textcolor = System.Drawing.Color.White;
            this.btnFile6.TextFont = new System.Drawing.Font("Century Gothic", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFile6.Click += new System.EventHandler(this.btnFile6_Click);
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.Font = new System.Drawing.Font("Century Gothic", 8.150944F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentUser.ForeColor = System.Drawing.Color.DimGray;
            this.lblCurrentUser.Location = new System.Drawing.Point(211, 179);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(265, 21);
            this.lblCurrentUser.TabIndex = 9;
            this.lblCurrentUser.Text = "ver 2017.11.07";
            this.lblCurrentUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblExit
            // 
            this.lblExit.AutoSize = true;
            this.lblExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.22642F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(128)))), ((int)(((byte)(30)))));
            this.lblExit.Location = new System.Drawing.Point(454, 4);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(25, 24);
            this.lblExit.TabIndex = 5;
            this.lblExit.Text = "X";
            this.lblExit.Click += new System.EventHandler(this.lblExit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Arial", 12.22642F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(128)))), ((int)(((byte)(30)))));
            this.label2.Location = new System.Drawing.Point(426, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 22);
            this.label2.TabIndex = 8;
            this.label2.Text = "_";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // timerClose
            // 
            this.timerClose.Interval = 3600000;
            this.timerClose.Tick += new System.EventHandler(this.timerClose_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(28)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(481, 201);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblExit);
            this.Controls.Add(this.lblCurrentUser);
            this.Controls.Add(this.btnFile6);
            this.Controls.Add(this.btnFile2);
            this.Controls.Add(this.cboZone);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Format File 2 and 6 ver 2017.11.03";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuDropdown cboZone;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuFlatButton btnFile6;
        private Bunifu.Framework.UI.BunifuFlatButton btnFile2;
        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timerClose;
    }
}

