﻿namespace PSSTool
{
    partial class frmLDAP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLDAP));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearchName = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLDAP = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEmpName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtManager = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEmpNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSearchByLDAP = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSearchByLDAP = new System.Windows.Forms.TextBox();
            this.btnBatchByLDAPName = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblTitle = new System.Windows.Forms.Label();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.lblClose = new System.Windows.Forms.Label();
            this.transFrm = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.btnBatchByID = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnImportDemoFiles = new Bunifu.Framework.UI.BunifuFlatButton();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblMinimize = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.transFrm.SetDecoration(this.textBox1, BunifuAnimatorNS.DecorationType.None);
            this.textBox1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.textBox1.Location = new System.Drawing.Point(266, 50);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(145, 26);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.transFrm.SetDecoration(this.listBox1, BunifuAnimatorNS.DecorationType.None);
            this.listBox1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.ForeColor = System.Drawing.Color.GreenYellow;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(20, 327);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(727, 122);
            this.listBox1.TabIndex = 2;
            this.listBox1.Click += new System.EventHandler(this.listBox1_Click);
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_Click);
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.firstNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.transFrm.SetDecoration(this.firstNameTextBox, BunifuAnimatorNS.DecorationType.None);
            this.firstNameTextBox.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstNameTextBox.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.firstNameTextBox.Location = new System.Drawing.Point(266, 134);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(145, 26);
            this.firstNameTextBox.TabIndex = 5;
            this.firstNameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.firstNameTextBox_KeyPress);
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.lastNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.transFrm.SetDecoration(this.lastNameTextBox, BunifuAnimatorNS.DecorationType.None);
            this.lastNameTextBox.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastNameTextBox.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lastNameTextBox.Location = new System.Drawing.Point(417, 134);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(141, 26);
            this.lastNameTextBox.TabIndex = 6;
            this.lastNameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.firstNameTextBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.transFrm.SetDecoration(this.label2, BunifuAnimatorNS.DecorationType.None);
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(155, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Search By Emp ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.transFrm.SetDecoration(this.label3, BunifuAnimatorNS.DecorationType.None);
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(10, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(254, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Search By First Name or Last Name (or both):";
            // 
            // btnSearchName
            // 
            this.btnSearchName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(45)))), ((int)(((byte)(54)))));
            this.btnSearchName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transFrm.SetDecoration(this.btnSearchName, BunifuAnimatorNS.DecorationType.None);
            this.btnSearchName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(45)))), ((int)(((byte)(54)))));
            this.btnSearchName.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchName.Image")));
            this.btnSearchName.Location = new System.Drawing.Point(417, 43);
            this.btnSearchName.Name = "btnSearchName";
            this.btnSearchName.Size = new System.Drawing.Size(33, 33);
            this.btnSearchName.TabIndex = 34;
            this.btnSearchName.UseVisualStyleBackColor = false;
            this.btnSearchName.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.transFrm.SetDecoration(this.label4, BunifuAnimatorNS.DecorationType.None);
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(270, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "First Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.transFrm.SetDecoration(this.label5, BunifuAnimatorNS.DecorationType.None);
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(400, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "Last Name";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(45)))), ((int)(((byte)(54)))));
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transFrm.SetDecoration(this.button2, BunifuAnimatorNS.DecorationType.None);
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(45)))), ((int)(((byte)(54)))));
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(564, 134);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(33, 33);
            this.button2.TabIndex = 37;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.checkLDAPByName_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.transFrm.SetDecoration(this.label1, BunifuAnimatorNS.DecorationType.None);
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(81)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(7, 259);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 18);
            this.label1.TabIndex = 38;
            this.label1.Text = "LDAP Name:";
            // 
            // txtLDAP
            // 
            this.txtLDAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.txtLDAP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.transFrm.SetDecoration(this.txtLDAP, BunifuAnimatorNS.DecorationType.None);
            this.txtLDAP.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLDAP.ForeColor = System.Drawing.Color.YellowGreen;
            this.txtLDAP.Location = new System.Drawing.Point(99, 256);
            this.txtLDAP.Name = "txtLDAP";
            this.txtLDAP.ReadOnly = true;
            this.txtLDAP.Size = new System.Drawing.Size(240, 26);
            this.txtLDAP.TabIndex = 39;
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.transFrm.SetDecoration(this.txtEmail, BunifuAnimatorNS.DecorationType.None);
            this.txtEmail.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.Color.YellowGreen;
            this.txtEmail.Location = new System.Drawing.Point(452, 256);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(295, 26);
            this.txtEmail.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.transFrm.SetDecoration(this.label6, BunifuAnimatorNS.DecorationType.None);
            this.label6.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(81)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(406, 259);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 18);
            this.label6.TabIndex = 40;
            this.label6.Text = "Email:";
            // 
            // txtEmpName
            // 
            this.txtEmpName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.txtEmpName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.transFrm.SetDecoration(this.txtEmpName, BunifuAnimatorNS.DecorationType.None);
            this.txtEmpName.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmpName.ForeColor = System.Drawing.Color.YellowGreen;
            this.txtEmpName.Location = new System.Drawing.Point(99, 223);
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.ReadOnly = true;
            this.txtEmpName.Size = new System.Drawing.Size(240, 26);
            this.txtEmpName.TabIndex = 43;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.transFrm.SetDecoration(this.label7, BunifuAnimatorNS.DecorationType.None);
            this.label7.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(81)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(12, 225);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 18);
            this.label7.TabIndex = 42;
            this.label7.Text = "Emp Name:";
            // 
            // button1
            // 
            this.transFrm.SetDecoration(this.button1, BunifuAnimatorNS.DecorationType.None);
            this.button1.Location = new System.Drawing.Point(-52, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 31);
            this.button1.TabIndex = 44;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txtManager
            // 
            this.txtManager.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.txtManager.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.transFrm.SetDecoration(this.txtManager, BunifuAnimatorNS.DecorationType.None);
            this.txtManager.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtManager.ForeColor = System.Drawing.Color.YellowGreen;
            this.txtManager.Location = new System.Drawing.Point(452, 222);
            this.txtManager.Name = "txtManager";
            this.txtManager.ReadOnly = true;
            this.txtManager.Size = new System.Drawing.Size(295, 26);
            this.txtManager.TabIndex = 46;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.transFrm.SetDecoration(this.label8, BunifuAnimatorNS.DecorationType.None);
            this.label8.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(81)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(416, 225);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 18);
            this.label8.TabIndex = 45;
            this.label8.Text = "Mgr:";
            // 
            // txtEmpNo
            // 
            this.txtEmpNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.txtEmpNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.transFrm.SetDecoration(this.txtEmpNo, BunifuAnimatorNS.DecorationType.None);
            this.txtEmpNo.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmpNo.ForeColor = System.Drawing.Color.YellowGreen;
            this.txtEmpNo.Location = new System.Drawing.Point(99, 190);
            this.txtEmpNo.Name = "txtEmpNo";
            this.txtEmpNo.ReadOnly = true;
            this.txtEmpNo.Size = new System.Drawing.Size(240, 26);
            this.txtEmpNo.TabIndex = 48;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.transFrm.SetDecoration(this.label9, BunifuAnimatorNS.DecorationType.None);
            this.label9.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(81)))), ((int)(((byte)(0)))));
            this.label9.Location = new System.Drawing.Point(42, 192);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 18);
            this.label9.TabIndex = 47;
            this.label9.Text = "Emp #:";
            // 
            // btnSearchByLDAP
            // 
            this.btnSearchByLDAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(45)))), ((int)(((byte)(54)))));
            this.btnSearchByLDAP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transFrm.SetDecoration(this.btnSearchByLDAP, BunifuAnimatorNS.DecorationType.None);
            this.btnSearchByLDAP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchByLDAP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(45)))), ((int)(((byte)(54)))));
            this.btnSearchByLDAP.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchByLDAP.Image")));
            this.btnSearchByLDAP.Location = new System.Drawing.Point(417, 90);
            this.btnSearchByLDAP.Name = "btnSearchByLDAP";
            this.btnSearchByLDAP.Size = new System.Drawing.Size(33, 33);
            this.btnSearchByLDAP.TabIndex = 51;
            this.btnSearchByLDAP.UseVisualStyleBackColor = false;
            this.btnSearchByLDAP.Click += new System.EventHandler(this.btnSearchByLDAP_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.transFrm.SetDecoration(this.label10, BunifuAnimatorNS.DecorationType.None);
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.label10.Location = new System.Drawing.Point(128, 96);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(136, 15);
            this.label10.TabIndex = 50;
            this.label10.Text = "Search By LDAP Name:";
            // 
            // txtSearchByLDAP
            // 
            this.txtSearchByLDAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.txtSearchByLDAP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.transFrm.SetDecoration(this.txtSearchByLDAP, BunifuAnimatorNS.DecorationType.None);
            this.txtSearchByLDAP.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchByLDAP.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtSearchByLDAP.Location = new System.Drawing.Point(266, 94);
            this.txtSearchByLDAP.Name = "txtSearchByLDAP";
            this.txtSearchByLDAP.Size = new System.Drawing.Size(145, 26);
            this.txtSearchByLDAP.TabIndex = 49;
            this.txtSearchByLDAP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchByLDAP_KeyPress);
            // 
            // btnBatchByLDAPName
            // 
            this.transFrm.SetDecoration(this.btnBatchByLDAPName, BunifuAnimatorNS.DecorationType.None);
            this.btnBatchByLDAPName.Image = ((System.Drawing.Image)(resources.GetObject("btnBatchByLDAPName.Image")));
            this.btnBatchByLDAPName.Location = new System.Drawing.Point(-25, 90);
            this.btnBatchByLDAPName.Name = "btnBatchByLDAPName";
            this.btnBatchByLDAPName.Size = new System.Drawing.Size(137, 38);
            this.btnBatchByLDAPName.TabIndex = 53;
            this.btnBatchByLDAPName.Text = "Batch By LDAP Name";
            this.btnBatchByLDAPName.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBatchByLDAPName.UseVisualStyleBackColor = true;
            this.btnBatchByLDAPName.Visible = false;
            // 
            // label11
            // 
            this.transFrm.SetDecoration(this.label11, BunifuAnimatorNS.DecorationType.None);
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.792453F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Silver;
            this.label11.Location = new System.Drawing.Point(604, 80);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(159, 26);
            this.label11.TabIndex = 54;
            this.label11.Text = "( Comma CSV or Line Feed Delimited Text File)";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 10000;
            this.toolTip1.InitialDelay = 200;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 100;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.transFrm.SetDecoration(this.lblTitle, BunifuAnimatorNS.DecorationType.None);
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(767, 29);
            this.lblTitle.TabIndex = 59;
            this.lblTitle.Text = "  LDAP Search v2018.05.25";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.lblTitle;
            this.bunifuDragControl1.Vertical = true;
            // 
            // lblClose
            // 
            this.lblClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.lblClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transFrm.SetDecoration(this.lblClose, BunifuAnimatorNS.DecorationType.None);
            this.lblClose.Image = ((System.Drawing.Image)(resources.GetObject("lblClose.Image")));
            this.lblClose.Location = new System.Drawing.Point(738, 2);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(22, 23);
            this.lblClose.TabIndex = 60;
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
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
            this.transFrm.TimeStep = 0.01F;
            // 
            // label12
            // 
            this.transFrm.SetDecoration(this.label12, BunifuAnimatorNS.DecorationType.None);
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.792453F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Silver;
            this.label12.Location = new System.Drawing.Point(603, 160);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(159, 26);
            this.label12.TabIndex = 62;
            this.label12.Text = "(For Items Report Use)";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBatchByID
            // 
            this.btnBatchByID.Activecolor = System.Drawing.Color.Transparent;
            this.btnBatchByID.BackColor = System.Drawing.Color.Transparent;
            this.btnBatchByID.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBatchByID.BorderRadius = 0;
            this.btnBatchByID.ButtonText = "Batch By ID";
            this.btnBatchByID.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transFrm.SetDecoration(this.btnBatchByID, BunifuAnimatorNS.DecorationType.None);
            this.btnBatchByID.DisabledColor = System.Drawing.Color.Gray;
            this.btnBatchByID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBatchByID.Iconcolor = System.Drawing.Color.Transparent;
            this.btnBatchByID.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnBatchByID.Iconimage")));
            this.btnBatchByID.Iconimage_right = null;
            this.btnBatchByID.Iconimage_right_Selected = null;
            this.btnBatchByID.Iconimage_Selected = null;
            this.btnBatchByID.IconMarginLeft = 0;
            this.btnBatchByID.IconMarginRight = 0;
            this.btnBatchByID.IconRightVisible = true;
            this.btnBatchByID.IconRightZoom = 0D;
            this.btnBatchByID.IconVisible = true;
            this.btnBatchByID.IconZoom = 90D;
            this.btnBatchByID.IsTab = false;
            this.btnBatchByID.Location = new System.Drawing.Point(619, 35);
            this.btnBatchByID.Name = "btnBatchByID";
            this.btnBatchByID.Normalcolor = System.Drawing.Color.Transparent;
            this.btnBatchByID.OnHovercolor = System.Drawing.Color.Transparent;
            this.btnBatchByID.OnHoverTextColor = System.Drawing.Color.White;
            this.btnBatchByID.selected = false;
            this.btnBatchByID.Size = new System.Drawing.Size(126, 45);
            this.btnBatchByID.TabIndex = 63;
            this.btnBatchByID.Text = "Batch By ID";
            this.btnBatchByID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnBatchByID.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.btnBatchByID.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBatchByID.Click += new System.EventHandler(this.btnBatchByID_Click);
            // 
            // btnImportDemoFiles
            // 
            this.btnImportDemoFiles.Activecolor = System.Drawing.Color.Transparent;
            this.btnImportDemoFiles.BackColor = System.Drawing.Color.Transparent;
            this.btnImportDemoFiles.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImportDemoFiles.BorderRadius = 0;
            this.btnImportDemoFiles.ButtonText = "Import Demo Files";
            this.btnImportDemoFiles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transFrm.SetDecoration(this.btnImportDemoFiles, BunifuAnimatorNS.DecorationType.None);
            this.btnImportDemoFiles.DisabledColor = System.Drawing.Color.Gray;
            this.btnImportDemoFiles.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnImportDemoFiles.Iconcolor = System.Drawing.Color.Transparent;
            this.btnImportDemoFiles.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnImportDemoFiles.Iconimage")));
            this.btnImportDemoFiles.Iconimage_right = null;
            this.btnImportDemoFiles.Iconimage_right_Selected = null;
            this.btnImportDemoFiles.Iconimage_Selected = null;
            this.btnImportDemoFiles.IconMarginLeft = 0;
            this.btnImportDemoFiles.IconMarginRight = 0;
            this.btnImportDemoFiles.IconRightVisible = true;
            this.btnImportDemoFiles.IconRightZoom = 0D;
            this.btnImportDemoFiles.IconVisible = true;
            this.btnImportDemoFiles.IconZoom = 90D;
            this.btnImportDemoFiles.IsTab = false;
            this.btnImportDemoFiles.Location = new System.Drawing.Point(619, 122);
            this.btnImportDemoFiles.Name = "btnImportDemoFiles";
            this.btnImportDemoFiles.Normalcolor = System.Drawing.Color.Transparent;
            this.btnImportDemoFiles.OnHovercolor = System.Drawing.Color.Transparent;
            this.btnImportDemoFiles.OnHoverTextColor = System.Drawing.Color.White;
            this.btnImportDemoFiles.selected = false;
            this.btnImportDemoFiles.Size = new System.Drawing.Size(143, 45);
            this.btnImportDemoFiles.TabIndex = 64;
            this.btnImportDemoFiles.Text = "Import Demo Files";
            this.btnImportDemoFiles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnImportDemoFiles.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.btnImportDemoFiles.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportDemoFiles.Click += new System.EventHandler(this.btnDemoFiles_Click);
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.transFrm.SetDecoration(this.txtStatus, BunifuAnimatorNS.DecorationType.None);
            this.txtStatus.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.ForeColor = System.Drawing.Color.YellowGreen;
            this.txtStatus.Location = new System.Drawing.Point(452, 188);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(295, 26);
            this.txtStatus.TabIndex = 66;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.transFrm.SetDecoration(this.label13, BunifuAnimatorNS.DecorationType.None);
            this.label13.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(81)))), ((int)(((byte)(0)))));
            this.label13.Location = new System.Drawing.Point(402, 191);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 18);
            this.label13.TabIndex = 65;
            this.label13.Text = "Status:";
            // 
            // txtLocation
            // 
            this.txtLocation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.txtLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.transFrm.SetDecoration(this.txtLocation, BunifuAnimatorNS.DecorationType.None);
            this.txtLocation.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocation.ForeColor = System.Drawing.Color.YellowGreen;
            this.txtLocation.Location = new System.Drawing.Point(452, 290);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.ReadOnly = true;
            this.txtLocation.Size = new System.Drawing.Size(295, 26);
            this.txtLocation.TabIndex = 70;
            // 
            // txtPosition
            // 
            this.txtPosition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.txtPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.transFrm.SetDecoration(this.txtPosition, BunifuAnimatorNS.DecorationType.None);
            this.txtPosition.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPosition.ForeColor = System.Drawing.Color.YellowGreen;
            this.txtPosition.Location = new System.Drawing.Point(99, 289);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.ReadOnly = true;
            this.txtPosition.Size = new System.Drawing.Size(240, 26);
            this.txtPosition.TabIndex = 68;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.transFrm.SetDecoration(this.label14, BunifuAnimatorNS.DecorationType.None);
            this.label14.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(81)))), ((int)(((byte)(0)))));
            this.label14.Location = new System.Drawing.Point(51, 293);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 18);
            this.label14.TabIndex = 67;
            this.label14.Text = "Title:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.transFrm.SetDecoration(this.label15, BunifuAnimatorNS.DecorationType.None);
            this.label15.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(81)))), ((int)(((byte)(0)))));
            this.label15.Location = new System.Drawing.Point(389, 294);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(63, 18);
            this.label15.TabIndex = 69;
            this.label15.Text = "Location:";
            // 
            // lblMinimize
            // 
            this.lblMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.lblMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transFrm.SetDecoration(this.lblMinimize, BunifuAnimatorNS.DecorationType.None);
            this.lblMinimize.Image = ((System.Drawing.Image)(resources.GetObject("lblMinimize.Image")));
            this.lblMinimize.Location = new System.Drawing.Point(714, 2);
            this.lblMinimize.Name = "lblMinimize";
            this.lblMinimize.Size = new System.Drawing.Size(22, 23);
            this.lblMinimize.TabIndex = 71;
            this.lblMinimize.Click += new System.EventHandler(this.lblMinimize_Click);
            // 
            // lblCount
            // 
            this.transFrm.SetDecoration(this.lblCount, BunifuAnimatorNS.DecorationType.None);
            this.lblCount.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.lblCount.Location = new System.Drawing.Point(21, 453);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(109, 28);
            this.lblCount.TabIndex = 72;
            this.lblCount.Text = "Count:";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmLDAP
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(45)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(767, 486);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.lblMinimize);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.txtPosition);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnImportDemoFiles);
            this.Controls.Add(this.btnBatchByID);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnBatchByLDAPName);
            this.Controls.Add(this.btnSearchByLDAP);
            this.Controls.Add(this.txtSearchByLDAP);
            this.Controls.Add(this.txtEmpNo);
            this.Controls.Add(this.txtManager);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtEmpName);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtLDAP);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSearchName);
            this.Controls.Add(this.lastNameTextBox);
            this.Controls.Add(this.firstNameTextBox);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.transFrm.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLDAP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search LDAP and Email";
            this.Load += new System.EventHandler(this.frmLDAP_Load);
            this.Shown += new System.EventHandler(this.frmLDAP_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearchName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLDAP;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEmpName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtManager;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtEmpNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSearchByLDAP;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSearchByLDAP;
        private System.Windows.Forms.Button btnBatchByLDAPName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblTitle;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.Label lblClose;
        private BunifuAnimatorNS.BunifuTransition transFrm;
        private System.Windows.Forms.Label label12;
        private Bunifu.Framework.UI.BunifuFlatButton btnBatchByID;
        private Bunifu.Framework.UI.BunifuFlatButton btnImportDemoFiles;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblMinimize;
        private System.Windows.Forms.Label lblCount;
    }
}

