namespace WindowsFormsApplication1
{
    partial class exceptionLookupForm
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
            BunifuAnimatorNS.Animation animation4 = new BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(exceptionLookupForm));
            this.exceptionIDText = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.exceptionType = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.empName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.empNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.exceptionDate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.shiftIcon = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.shiftTime = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.unitName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.rotationName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.workplanRow = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.costCenter = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.reliefReq = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.creationDate = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.changeDate = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.changeBy = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.occupationText = new System.Windows.Forms.TextBox();
            this.accessType = new System.Windows.Forms.TextBox();
            this.transFrm = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // exceptionIDText
            // 
            this.exceptionIDText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.exceptionIDText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.transFrm.SetDecoration(this.exceptionIDText, BunifuAnimatorNS.DecorationType.None);
            this.exceptionIDText.ForeColor = System.Drawing.Color.Gainsboro;
            this.exceptionIDText.Location = new System.Drawing.Point(254, 43);
            this.exceptionIDText.Name = "exceptionIDText";
            this.exceptionIDText.Size = new System.Drawing.Size(100, 20);
            this.exceptionIDText.TabIndex = 0;
            this.exceptionIDText.TextChanged += new System.EventHandler(this.exceptionIDText_TextChanged);
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(109)))), ((int)(((byte)(130)))));
            this.transFrm.SetDecoration(this.searchButton, BunifuAnimatorNS.DecorationType.None);
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.searchButton.Location = new System.Drawing.Point(360, 34);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(81, 36);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(45)))), ((int)(((byte)(54)))));
            this.transFrm.SetDecoration(this.label1, BunifuAnimatorNS.DecorationType.None);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(178, 44);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Exception ID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // progress
            // 
            this.transFrm.SetDecoration(this.progress, BunifuAnimatorNS.DecorationType.None);
            this.progress.Location = new System.Drawing.Point(172, 76);
            this.progress.Maximum = 20;
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(269, 10);
            this.progress.Step = 1;
            this.progress.TabIndex = 3;
            // 
            // exceptionType
            // 
            this.exceptionType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.exceptionType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.transFrm.SetDecoration(this.exceptionType, BunifuAnimatorNS.DecorationType.None);
            this.exceptionType.ForeColor = System.Drawing.Color.Gainsboro;
            this.exceptionType.Location = new System.Drawing.Point(96, 148);
            this.exceptionType.Name = "exceptionType";
            this.exceptionType.ReadOnly = true;
            this.exceptionType.Size = new System.Drawing.Size(150, 20);
            this.exceptionType.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(45)))), ((int)(((byte)(54)))));
            this.transFrm.SetDecoration(this.label2, BunifuAnimatorNS.DecorationType.None);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(9, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Exception Type";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(45)))), ((int)(((byte)(54)))));
            this.transFrm.SetDecoration(this.label3, BunifuAnimatorNS.DecorationType.None);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(6, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Employee Name";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // empName
            // 
            this.empName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.empName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.transFrm.SetDecoration(this.empName, BunifuAnimatorNS.DecorationType.None);
            this.empName.ForeColor = System.Drawing.Color.Gainsboro;
            this.empName.Location = new System.Drawing.Point(96, 122);
            this.empName.Name = "empName";
            this.empName.ReadOnly = true;
            this.empName.Size = new System.Drawing.Size(150, 20);
            this.empName.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(45)))), ((int)(((byte)(54)))));
            this.transFrm.SetDecoration(this.label4, BunifuAnimatorNS.DecorationType.None);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(27, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Employee #";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // empNo
            // 
            this.empNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.empNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.transFrm.SetDecoration(this.empNo, BunifuAnimatorNS.DecorationType.None);
            this.empNo.ForeColor = System.Drawing.Color.Gainsboro;
            this.empNo.Location = new System.Drawing.Point(96, 96);
            this.empNo.Name = "empNo";
            this.empNo.ReadOnly = true;
            this.empNo.Size = new System.Drawing.Size(150, 20);
            this.empNo.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(45)))), ((int)(((byte)(54)))));
            this.transFrm.SetDecoration(this.label5, BunifuAnimatorNS.DecorationType.None);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(10, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Exception Date";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // exceptionDate
            // 
            this.exceptionDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.exceptionDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.transFrm.SetDecoration(this.exceptionDate, BunifuAnimatorNS.DecorationType.None);
            this.exceptionDate.ForeColor = System.Drawing.Color.Gainsboro;
            this.exceptionDate.Location = new System.Drawing.Point(96, 174);
            this.exceptionDate.Name = "exceptionDate";
            this.exceptionDate.ReadOnly = true;
            this.exceptionDate.Size = new System.Drawing.Size(150, 20);
            this.exceptionDate.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(45)))), ((int)(((byte)(54)))));
            this.transFrm.SetDecoration(this.label6, BunifuAnimatorNS.DecorationType.None);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(38, 202);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Shift Icon";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // shiftIcon
            // 
            this.shiftIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.shiftIcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.transFrm.SetDecoration(this.shiftIcon, BunifuAnimatorNS.DecorationType.None);
            this.shiftIcon.ForeColor = System.Drawing.Color.Gainsboro;
            this.shiftIcon.Location = new System.Drawing.Point(96, 200);
            this.shiftIcon.Name = "shiftIcon";
            this.shiftIcon.ReadOnly = true;
            this.shiftIcon.Size = new System.Drawing.Size(150, 20);
            this.shiftIcon.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(45)))), ((int)(((byte)(54)))));
            this.transFrm.SetDecoration(this.label7, BunifuAnimatorNS.DecorationType.None);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(36, 228);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Shift Time";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // shiftTime
            // 
            this.shiftTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.shiftTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.transFrm.SetDecoration(this.shiftTime, BunifuAnimatorNS.DecorationType.None);
            this.shiftTime.ForeColor = System.Drawing.Color.Gainsboro;
            this.shiftTime.Location = new System.Drawing.Point(96, 226);
            this.shiftTime.Name = "shiftTime";
            this.shiftTime.ReadOnly = true;
            this.shiftTime.Size = new System.Drawing.Size(150, 20);
            this.shiftTime.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(45)))), ((int)(((byte)(54)))));
            this.transFrm.SetDecoration(this.label8, BunifuAnimatorNS.DecorationType.None);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(324, 122);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Unit Name";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // unitName
            // 
            this.unitName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.unitName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.transFrm.SetDecoration(this.unitName, BunifuAnimatorNS.DecorationType.None);
            this.unitName.ForeColor = System.Drawing.Color.Gainsboro;
            this.unitName.Location = new System.Drawing.Point(388, 121);
            this.unitName.Name = "unitName";
            this.unitName.ReadOnly = true;
            this.unitName.Size = new System.Drawing.Size(206, 20);
            this.unitName.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(45)))), ((int)(((byte)(54)))));
            this.transFrm.SetDecoration(this.label9, BunifuAnimatorNS.DecorationType.None);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.label9.Location = new System.Drawing.Point(303, 148);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Rotation Name";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rotationName
            // 
            this.rotationName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.rotationName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.transFrm.SetDecoration(this.rotationName, BunifuAnimatorNS.DecorationType.None);
            this.rotationName.ForeColor = System.Drawing.Color.Gainsboro;
            this.rotationName.Location = new System.Drawing.Point(388, 147);
            this.rotationName.Name = "rotationName";
            this.rotationName.ReadOnly = true;
            this.rotationName.Size = new System.Drawing.Size(206, 20);
            this.rotationName.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(45)))), ((int)(((byte)(54)))));
            this.transFrm.SetDecoration(this.label10, BunifuAnimatorNS.DecorationType.None);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.label10.Location = new System.Drawing.Point(303, 174);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Workplan Row";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // workplanRow
            // 
            this.workplanRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.workplanRow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.transFrm.SetDecoration(this.workplanRow, BunifuAnimatorNS.DecorationType.None);
            this.workplanRow.ForeColor = System.Drawing.Color.Gainsboro;
            this.workplanRow.Location = new System.Drawing.Point(388, 173);
            this.workplanRow.Name = "workplanRow";
            this.workplanRow.ReadOnly = true;
            this.workplanRow.Size = new System.Drawing.Size(206, 20);
            this.workplanRow.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(45)))), ((int)(((byte)(54)))));
            this.transFrm.SetDecoration(this.label11, BunifuAnimatorNS.DecorationType.None);
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.label11.Location = new System.Drawing.Point(319, 200);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "Cost Centre";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // costCenter
            // 
            this.costCenter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.costCenter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.transFrm.SetDecoration(this.costCenter, BunifuAnimatorNS.DecorationType.None);
            this.costCenter.ForeColor = System.Drawing.Color.Gainsboro;
            this.costCenter.Location = new System.Drawing.Point(388, 199);
            this.costCenter.Name = "costCenter";
            this.costCenter.ReadOnly = true;
            this.costCenter.Size = new System.Drawing.Size(206, 20);
            this.costCenter.TabIndex = 22;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(45)))), ((int)(((byte)(54)))));
            this.transFrm.SetDecoration(this.label12, BunifuAnimatorNS.DecorationType.None);
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.label12.Location = new System.Drawing.Point(27, 254);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "Relief Req?";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // reliefReq
            // 
            this.reliefReq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.reliefReq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.transFrm.SetDecoration(this.reliefReq, BunifuAnimatorNS.DecorationType.None);
            this.reliefReq.ForeColor = System.Drawing.Color.Gainsboro;
            this.reliefReq.Location = new System.Drawing.Point(96, 252);
            this.reliefReq.Name = "reliefReq";
            this.reliefReq.ReadOnly = true;
            this.reliefReq.Size = new System.Drawing.Size(150, 20);
            this.reliefReq.TabIndex = 24;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(45)))), ((int)(((byte)(54)))));
            this.transFrm.SetDecoration(this.label13, BunifuAnimatorNS.DecorationType.None);
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.label13.Location = new System.Drawing.Point(287, 226);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(94, 13);
            this.label13.TabIndex = 27;
            this.label13.Text = "Exception Created";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // creationDate
            // 
            this.creationDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.creationDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.transFrm.SetDecoration(this.creationDate, BunifuAnimatorNS.DecorationType.None);
            this.creationDate.ForeColor = System.Drawing.Color.Gainsboro;
            this.creationDate.Location = new System.Drawing.Point(388, 225);
            this.creationDate.Name = "creationDate";
            this.creationDate.ReadOnly = true;
            this.creationDate.Size = new System.Drawing.Size(206, 20);
            this.creationDate.TabIndex = 26;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(45)))), ((int)(((byte)(54)))));
            this.transFrm.SetDecoration(this.label14, BunifuAnimatorNS.DecorationType.None);
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.label14.Location = new System.Drawing.Point(258, 252);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(123, 13);
            this.label14.TabIndex = 29;
            this.label14.Text = "Exception Last Changed";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // changeDate
            // 
            this.changeDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.changeDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.transFrm.SetDecoration(this.changeDate, BunifuAnimatorNS.DecorationType.None);
            this.changeDate.ForeColor = System.Drawing.Color.Gainsboro;
            this.changeDate.Location = new System.Drawing.Point(388, 251);
            this.changeDate.Name = "changeDate";
            this.changeDate.ReadOnly = true;
            this.changeDate.Size = new System.Drawing.Size(206, 20);
            this.changeDate.TabIndex = 28;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(45)))), ((int)(((byte)(54)))));
            this.transFrm.SetDecoration(this.label15, BunifuAnimatorNS.DecorationType.None);
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.label15.Location = new System.Drawing.Point(85, 293);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 13);
            this.label15.TabIndex = 31;
            this.label15.Text = "Changed By";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // changeBy
            // 
            this.changeBy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.changeBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.transFrm.SetDecoration(this.changeBy, BunifuAnimatorNS.DecorationType.None);
            this.changeBy.ForeColor = System.Drawing.Color.Gainsboro;
            this.changeBy.Location = new System.Drawing.Point(157, 290);
            this.changeBy.Name = "changeBy";
            this.changeBy.ReadOnly = true;
            this.changeBy.Size = new System.Drawing.Size(106, 20);
            this.changeBy.TabIndex = 30;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(45)))), ((int)(((byte)(54)))));
            this.transFrm.SetDecoration(this.label16, BunifuAnimatorNS.DecorationType.None);
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.label16.Location = new System.Drawing.Point(319, 96);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(62, 13);
            this.label16.TabIndex = 33;
            this.label16.Text = "Occupation";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // occupationText
            // 
            this.occupationText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.occupationText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.transFrm.SetDecoration(this.occupationText, BunifuAnimatorNS.DecorationType.None);
            this.occupationText.ForeColor = System.Drawing.Color.Gainsboro;
            this.occupationText.Location = new System.Drawing.Point(388, 95);
            this.occupationText.Name = "occupationText";
            this.occupationText.ReadOnly = true;
            this.occupationText.Size = new System.Drawing.Size(206, 20);
            this.occupationText.TabIndex = 32;
            // 
            // accessType
            // 
            this.accessType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.accessType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.transFrm.SetDecoration(this.accessType, BunifuAnimatorNS.DecorationType.None);
            this.accessType.ForeColor = System.Drawing.Color.Gainsboro;
            this.accessType.Location = new System.Drawing.Point(269, 290);
            this.accessType.Name = "accessType";
            this.accessType.ReadOnly = true;
            this.accessType.Size = new System.Drawing.Size(251, 20);
            this.accessType.TabIndex = 34;
            // 
            // transFrm
            // 
            this.transFrm.AnimationType = BunifuAnimatorNS.AnimationType.ScaleAndRotate;
            this.transFrm.Cursor = null;
            animation4.AnimateOnlyDifferences = true;
            animation4.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.BlindCoeff")));
            animation4.LeafCoeff = 0F;
            animation4.MaxTime = 1F;
            animation4.MinTime = 0F;
            animation4.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.MosaicCoeff")));
            animation4.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation4.MosaicShift")));
            animation4.MosaicSize = 0;
            animation4.Padding = new System.Windows.Forms.Padding(30);
            animation4.RotateCoeff = 0.5F;
            animation4.RotateLimit = 0.2F;
            animation4.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.ScaleCoeff")));
            animation4.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.SlideCoeff")));
            animation4.TimeCoeff = 0F;
            animation4.TransparencyCoeff = 0F;
            this.transFrm.DefaultAnimation = animation4;
            this.transFrm.MaxAnimationTime = 2000;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.lblTitle;
            this.bunifuDragControl1.Vertical = true;
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
            this.lblTitle.Size = new System.Drawing.Size(607, 29);
            this.lblTitle.TabIndex = 51;
            this.lblTitle.Text = "Exception Lookup";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(109)))), ((int)(((byte)(130)))));
            this.transFrm.SetDecoration(this.btnClose, BunifuAnimatorNS.DecorationType.None);
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Century Gothic", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(496, 326);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(98, 42);
            this.btnClose.TabIndex = 50;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // exceptionLookupForm
            // 
            this.AcceptButton = this.searchButton;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(45)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(607, 380);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.accessType);
            this.Controls.Add(this.occupationText);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.changeBy);
            this.Controls.Add(this.changeDate);
            this.Controls.Add(this.creationDate);
            this.Controls.Add(this.reliefReq);
            this.Controls.Add(this.costCenter);
            this.Controls.Add(this.workplanRow);
            this.Controls.Add(this.rotationName);
            this.Controls.Add(this.unitName);
            this.Controls.Add(this.shiftTime);
            this.Controls.Add(this.shiftIcon);
            this.Controls.Add(this.exceptionDate);
            this.Controls.Add(this.empNo);
            this.Controls.Add(this.empName);
            this.Controls.Add(this.exceptionType);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.exceptionIDText);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.transFrm.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "exceptionLookupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Exception Lookup";
            this.Load += new System.EventHandler(this.exceptionLookupForm_Load);
            this.Shown += new System.EventHandler(this.exceptionLookupForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox exceptionIDText;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.TextBox exceptionType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox empName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox empNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox exceptionDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox shiftIcon;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox shiftTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox unitName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox rotationName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox workplanRow;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox costCenter;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox reliefReq;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox creationDate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox changeDate;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox changeBy;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox occupationText;
        private System.Windows.Forms.TextBox accessType;
        private BunifuAnimatorNS.BunifuTransition transFrm;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
    }
}

