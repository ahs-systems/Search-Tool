namespace WindowsFormsApplication1
{
    partial class frmTrainings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTrainings));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSearchByEmpNo = new System.Windows.Forms.Button();
            this.btnSearchName = new System.Windows.Forms.Button();
            this.txtEmpNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmpName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnLoadData = new MBGlassStyleButton.MBGlassButton();
            this.lblUpdated = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearchByEmpNo
            // 
            this.btnSearchByEmpNo.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchByEmpNo.Image")));
            this.btnSearchByEmpNo.Location = new System.Drawing.Point(351, 47);
            this.btnSearchByEmpNo.Name = "btnSearchByEmpNo";
            this.btnSearchByEmpNo.Size = new System.Drawing.Size(38, 34);
            this.btnSearchByEmpNo.TabIndex = 40;
            this.btnSearchByEmpNo.UseVisualStyleBackColor = true;
            this.btnSearchByEmpNo.Click += new System.EventHandler(this.btnSearchByEmpNo_Click);
            // 
            // btnSearchName
            // 
            this.btnSearchName.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchName.Image")));
            this.btnSearchName.Location = new System.Drawing.Point(351, 5);
            this.btnSearchName.Name = "btnSearchName";
            this.btnSearchName.Size = new System.Drawing.Size(38, 34);
            this.btnSearchName.TabIndex = 39;
            this.btnSearchName.UseVisualStyleBackColor = true;
            this.btnSearchName.Click += new System.EventHandler(this.btnSearchName_Click);
            // 
            // txtEmpNo
            // 
            this.txtEmpNo.Location = new System.Drawing.Point(184, 54);
            this.txtEmpNo.Name = "txtEmpNo";
            this.txtEmpNo.Size = new System.Drawing.Size(160, 20);
            this.txtEmpNo.TabIndex = 38;
            this.txtEmpNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmpNo_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(69, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Employee Number:";
            // 
            // txtEmpName
            // 
            this.txtEmpName.Location = new System.Drawing.Point(184, 12);
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.Size = new System.Drawing.Size(160, 20);
            this.txtEmpName.TabIndex = 35;
            this.txtEmpName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmpName_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(12, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "Part of first name or last name:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 114);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(731, 125);
            this.dataGridView1.TabIndex = 41;
            // 
            // btnLoadData
            // 
            this.btnLoadData.BackColor = System.Drawing.Color.Transparent;
            this.btnLoadData.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.btnLoadData.BaseStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnLoadData.FlatAppearance.BorderSize = 0;
            this.btnLoadData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnLoadData.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadData.Image")));
            this.btnLoadData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadData.ImageSize = new System.Drawing.Size(24, 24);
            this.btnLoadData.Location = new System.Drawing.Point(512, 70);
            this.btnLoadData.MenuListPosition = new System.Drawing.Point(0, 0);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnLoadData.OnStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnLoadData.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnLoadData.PressStrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnLoadData.Size = new System.Drawing.Size(231, 33);
            this.btnLoadData.TabIndex = 42;
            this.btnLoadData.Text = "Manually Load Data from Excel";
            this.btnLoadData.UseVisualStyleBackColor = false;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // lblUpdated
            // 
            this.lblUpdated.AutoSize = true;
            this.lblUpdated.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdated.ForeColor = System.Drawing.Color.DarkRed;
            this.lblUpdated.Location = new System.Drawing.Point(12, 86);
            this.lblUpdated.Name = "lblUpdated";
            this.lblUpdated.Size = new System.Drawing.Size(23, 17);
            this.lblUpdated.TabIndex = 43;
            this.lblUpdated.Text = "---";
            // 
            // frmTrainings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(755, 252);
            this.Controls.Add(this.lblUpdated);
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnSearchByEmpNo);
            this.Controls.Add(this.btnSearchName);
            this.Controls.Add(this.txtEmpNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEmpName);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTrainings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Trainings";
            this.Load += new System.EventHandler(this.frmTrainings_Load);
            this.Shown += new System.EventHandler(this.frmTrainings_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearchByEmpNo;
        private System.Windows.Forms.Button btnSearchName;
        private System.Windows.Forms.TextBox txtEmpNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmpName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private MBGlassStyleButton.MBGlassButton btnLoadData;
        private System.Windows.Forms.Label lblUpdated;
    }
}