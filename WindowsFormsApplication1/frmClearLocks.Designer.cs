namespace WindowsFormsApplication1
{
    partial class frmClearLocks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClearLocks));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSearchName = new System.Windows.Forms.Button();
            this.txtSearchStr = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnFindByUser = new System.Windows.Forms.Button();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblItemsFound = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearchName
            // 
            this.btnSearchName.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSearchName.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchName.Image")));
            this.btnSearchName.Location = new System.Drawing.Point(340, 10);
            this.btnSearchName.Name = "btnSearchName";
            this.btnSearchName.Size = new System.Drawing.Size(38, 34);
            this.btnSearchName.TabIndex = 42;
            this.btnSearchName.UseVisualStyleBackColor = true;
            this.btnSearchName.Click += new System.EventHandler(this.btnSearchName_Click);
            // 
            // txtSearchStr
            // 
            this.txtSearchStr.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtSearchStr.Location = new System.Drawing.Point(174, 16);
            this.txtSearchStr.Name = "txtSearchStr";
            this.txtSearchStr.Size = new System.Drawing.Size(160, 20);
            this.txtSearchStr.TabIndex = 40;
            this.txtSearchStr.Tag = "btnSearchName";
            this.txtSearchStr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchStr_KeyPress);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.label2.Location = new System.Drawing.Point(2, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 48);
            this.label2.TabIndex = 41;
            this.label2.Text = "Search By Record (Enter part of the name or unit): ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 61);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(820, 125);
            this.dataGridView1.TabIndex = 43;
            // 
            // btnFindByUser
            // 
            this.btnFindByUser.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnFindByUser.Image = ((System.Drawing.Image)(resources.GetObject("btnFindByUser.Image")));
            this.btnFindByUser.Location = new System.Drawing.Point(802, 10);
            this.btnFindByUser.Name = "btnFindByUser";
            this.btnFindByUser.Size = new System.Drawing.Size(38, 34);
            this.btnFindByUser.TabIndex = 46;
            this.btnFindByUser.UseVisualStyleBackColor = true;
            this.btnFindByUser.Click += new System.EventHandler(this.btnFindByUser_Click);
            // 
            // txtUser
            // 
            this.txtUser.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtUser.Location = new System.Drawing.Point(636, 18);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(160, 20);
            this.txtUser.TabIndex = 44;
            this.txtUser.Tag = "btnFindByUser";
            this.txtUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchStr_KeyPress);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.label1.Location = new System.Drawing.Point(407, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 37);
            this.label1.TabIndex = 45;
            this.label1.Text = "Search By User (Enter part of the name of the user locking a record):";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblItemsFound
            // 
            this.lblItemsFound.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblItemsFound.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemsFound.ForeColor = System.Drawing.Color.Crimson;
            this.lblItemsFound.Location = new System.Drawing.Point(12, 181);
            this.lblItemsFound.Name = "lblItemsFound";
            this.lblItemsFound.Size = new System.Drawing.Size(113, 37);
            this.lblItemsFound.TabIndex = 47;
            this.lblItemsFound.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmClearLocks
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(844, 215);
            this.Controls.Add(this.btnFindByUser);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnSearchName);
            this.Controls.Add(this.txtSearchStr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblItemsFound);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmClearLocks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Clear Locks";
            this.Load += new System.EventHandler(this.frmClearLocks_Load);
            this.Shown += new System.EventHandler(this.frmClearLocks_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearchName;
        private System.Windows.Forms.TextBox txtSearchStr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnFindByUser;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblItemsFound;
    }
}