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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnFile2 = new System.Windows.Forms.Button();
            this.btnFile6 = new System.Windows.Forms.Button();
            this.cboZone = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnFile2
            // 
            this.btnFile2.Image = ((System.Drawing.Image)(resources.GetObject("btnFile2.Image")));
            this.btnFile2.Location = new System.Drawing.Point(24, 54);
            this.btnFile2.Name = "btnFile2";
            this.btnFile2.Size = new System.Drawing.Size(159, 48);
            this.btnFile2.TabIndex = 0;
            this.btnFile2.Text = "Format File 2";
            this.btnFile2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFile2.UseVisualStyleBackColor = true;
            this.btnFile2.Click += new System.EventHandler(this.btnFile2_Click);
            // 
            // btnFile6
            // 
            this.btnFile6.Image = ((System.Drawing.Image)(resources.GetObject("btnFile6.Image")));
            this.btnFile6.Location = new System.Drawing.Point(210, 54);
            this.btnFile6.Name = "btnFile6";
            this.btnFile6.Size = new System.Drawing.Size(159, 48);
            this.btnFile6.TabIndex = 1;
            this.btnFile6.Text = "Format File 6 from File 1";
            this.btnFile6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFile6.UseVisualStyleBackColor = true;
            this.btnFile6.Click += new System.EventHandler(this.btnFile6_Click);
            // 
            // cboZone
            // 
            this.cboZone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboZone.FormattingEnabled = true;
            this.cboZone.Items.AddRange(new object[] {
            "Edmonton",
            "NCS"});
            this.cboZone.Location = new System.Drawing.Point(68, 11);
            this.cboZone.Name = "cboZone";
            this.cboZone.Size = new System.Drawing.Size(186, 24);
            this.cboZone.TabIndex = 2;
            this.cboZone.SelectedIndexChanged += new System.EventHandler(this.cboZone_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Zone: ";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 114);
            this.Controls.Add(this.cboZone);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFile6);
            this.Controls.Add(this.btnFile2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Format File 2 and 6 ver 2017.10.23";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFile2;
        private System.Windows.Forms.Button btnFile6;
        private System.Windows.Forms.ComboBox cboZone;
        private System.Windows.Forms.Label label1;
    }
}

