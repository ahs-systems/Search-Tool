namespace WindowsFormsApplication1
{
    partial class frmUploadItems
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
            this.cboItemsReport = new System.Windows.Forms.ComboBox();
            this.cboYearPP = new System.Windows.Forms.ComboBox();
            this.cboPP = new System.Windows.Forms.ComboBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.chkUploadToItems = new System.Windows.Forms.CheckBox();
            this.grpItems = new System.Windows.Forms.GroupBox();
            this.btnContinue = new MBGlassStyleButton.MBGlassButton();
            this.grpItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboItemsReport
            // 
            this.cboItemsReport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboItemsReport.FormattingEnabled = true;
            this.cboItemsReport.Items.AddRange(new object[] {
            "Items Report A",
            "Items Report B",
            "Items Report C"});
            this.cboItemsReport.Location = new System.Drawing.Point(371, 34);
            this.cboItemsReport.Name = "cboItemsReport";
            this.cboItemsReport.Size = new System.Drawing.Size(140, 21);
            this.cboItemsReport.TabIndex = 60;
            // 
            // cboYearPP
            // 
            this.cboYearPP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboYearPP.FormattingEnabled = true;
            this.cboYearPP.Location = new System.Drawing.Point(206, 34);
            this.cboYearPP.Name = "cboYearPP";
            this.cboYearPP.Size = new System.Drawing.Size(140, 21);
            this.cboYearPP.TabIndex = 59;
            // 
            // cboPP
            // 
            this.cboPP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPP.FormattingEnabled = true;
            this.cboPP.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26"});
            this.cboPP.Location = new System.Drawing.Point(89, 34);
            this.cboPP.Name = "cboPP";
            this.cboPP.Size = new System.Drawing.Size(65, 21);
            this.cboPP.TabIndex = 58;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label34.Location = new System.Drawing.Point(11, 36);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(69, 15);
            this.label34.TabIndex = 61;
            this.label34.Text = "Pay Period:";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label35.Location = new System.Drawing.Point(166, 37);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(35, 15);
            this.label35.TabIndex = 62;
            this.label35.Text = "Year:";
            // 
            // chkUploadToItems
            // 
            this.chkUploadToItems.AutoSize = true;
            this.chkUploadToItems.Location = new System.Drawing.Point(19, 8);
            this.chkUploadToItems.Name = "chkUploadToItems";
            this.chkUploadToItems.Size = new System.Drawing.Size(186, 19);
            this.chkUploadToItems.TabIndex = 63;
            this.chkUploadToItems.Text = "Upload File 2 to Items Report";
            this.chkUploadToItems.UseVisualStyleBackColor = true;
            this.chkUploadToItems.CheckedChanged += new System.EventHandler(this.chkUploadToItems_CheckedChanged);
            // 
            // grpItems
            // 
            this.grpItems.Controls.Add(this.cboItemsReport);
            this.grpItems.Controls.Add(this.label35);
            this.grpItems.Controls.Add(this.label34);
            this.grpItems.Controls.Add(this.cboYearPP);
            this.grpItems.Controls.Add(this.cboPP);
            this.grpItems.Enabled = false;
            this.grpItems.Location = new System.Drawing.Point(12, 12);
            this.grpItems.Name = "grpItems";
            this.grpItems.Size = new System.Drawing.Size(529, 86);
            this.grpItems.TabIndex = 64;
            this.grpItems.TabStop = false;
            // 
            // btnContinue
            // 
            this.btnContinue.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnContinue.BackColor = System.Drawing.Color.Transparent;
            this.btnContinue.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.btnContinue.BaseStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnContinue.FlatAppearance.BorderSize = 0;
            this.btnContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContinue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnContinue.ImageSize = new System.Drawing.Size(24, 24);
            this.btnContinue.Location = new System.Drawing.Point(207, 112);
            this.btnContinue.MenuListPosition = new System.Drawing.Point(0, 0);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnContinue.OnStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnContinue.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnContinue.PressStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnContinue.Size = new System.Drawing.Size(140, 33);
            this.btnContinue.TabIndex = 65;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = false;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // frmUploadItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 166);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.chkUploadToItems);
            this.Controls.Add(this.grpItems);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmUploadItems";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmUploadItems_Load);
            this.grpItems.ResumeLayout(false);
            this.grpItems.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboItemsReport;
        private System.Windows.Forms.ComboBox cboYearPP;
        private System.Windows.Forms.ComboBox cboPP;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.CheckBox chkUploadToItems;
        private System.Windows.Forms.GroupBox grpItems;
        private MBGlassStyleButton.MBGlassButton btnContinue;
    }
}