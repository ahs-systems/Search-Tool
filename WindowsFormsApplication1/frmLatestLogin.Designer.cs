namespace WindowsFormsApplication1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLatestLogin));
            this.txtEmpName = new System.Windows.Forms.TextBox();
            this.lstResult = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLastLoginDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmpNo = new System.Windows.Forms.TextBox();
            this.btnSearchName = new System.Windows.Forms.Button();
            this.btnSearchByEmpNo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtEmpName
            // 
            this.txtEmpName.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtEmpName.Location = new System.Drawing.Point(184, 10);
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.Size = new System.Drawing.Size(160, 20);
            this.txtEmpName.TabIndex = 0;
            this.txtEmpName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmpName_KeyPress);
            // 
            // lstResult
            // 
            this.lstResult.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lstResult.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lstResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lstResult.FormattingEnabled = true;
            this.lstResult.Location = new System.Drawing.Point(8, 84);
            this.lstResult.Name = "lstResult";
            this.lstResult.Size = new System.Drawing.Size(382, 108);
            this.lstResult.TabIndex = 25;
            this.lstResult.Click += new System.EventHandler(this.lstResult_Click);
            this.lstResult.SelectedIndexChanged += new System.EventHandler(this.lstResult_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(12, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Part of first name or last name:";
            // 
            // lblLastLoginDate
            // 
            this.lblLastLoginDate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblLastLoginDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastLoginDate.ForeColor = System.Drawing.Color.Maroon;
            this.lblLastLoginDate.Location = new System.Drawing.Point(10, 198);
            this.lblLastLoginDate.Name = "lblLastLoginDate";
            this.lblLastLoginDate.Size = new System.Drawing.Size(378, 23);
            this.lblLastLoginDate.TabIndex = 29;
            this.lblLastLoginDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(69, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Employeer Number:";
            // 
            // txtEmpNo
            // 
            this.txtEmpNo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtEmpNo.Location = new System.Drawing.Point(184, 52);
            this.txtEmpNo.Name = "txtEmpNo";
            this.txtEmpNo.Size = new System.Drawing.Size(160, 20);
            this.txtEmpNo.TabIndex = 32;
            this.txtEmpNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmpNo_KeyPress);
            // 
            // btnSearchName
            // 
            this.btnSearchName.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSearchName.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchName.Image")));
            this.btnSearchName.Location = new System.Drawing.Point(351, 3);
            this.btnSearchName.Name = "btnSearchName";
            this.btnSearchName.Size = new System.Drawing.Size(38, 34);
            this.btnSearchName.TabIndex = 33;
            this.btnSearchName.UseVisualStyleBackColor = true;
            this.btnSearchName.Click += new System.EventHandler(this.btnSearchName_Click);
            // 
            // btnSearchByEmpNo
            // 
            this.btnSearchByEmpNo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSearchByEmpNo.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchByEmpNo.Image")));
            this.btnSearchByEmpNo.Location = new System.Drawing.Point(351, 45);
            this.btnSearchByEmpNo.Name = "btnSearchByEmpNo";
            this.btnSearchByEmpNo.Size = new System.Drawing.Size(38, 34);
            this.btnSearchByEmpNo.TabIndex = 34;
            this.btnSearchByEmpNo.UseVisualStyleBackColor = true;
            this.btnSearchByEmpNo.Click += new System.EventHandler(this.btnSearchByEmpNo_Click);
            // 
            // frmLatestLogin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(397, 228);
            this.Controls.Add(this.btnSearchByEmpNo);
            this.Controls.Add(this.btnSearchName);
            this.Controls.Add(this.txtEmpNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblLastLoginDate);
            this.Controls.Add(this.txtEmpName);
            this.Controls.Add(this.lstResult);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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
    }
}