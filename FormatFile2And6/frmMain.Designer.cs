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
            this.SuspendLayout();
            // 
            // btnFile2
            // 
            this.btnFile2.Location = new System.Drawing.Point(32, 24);
            this.btnFile2.Name = "btnFile2";
            this.btnFile2.Size = new System.Drawing.Size(159, 48);
            this.btnFile2.TabIndex = 0;
            this.btnFile2.Text = "Format File 2";
            this.btnFile2.UseVisualStyleBackColor = true;
            this.btnFile2.Click += new System.EventHandler(this.btnFile2_Click);
            // 
            // btnFile6
            // 
            this.btnFile6.Location = new System.Drawing.Point(218, 24);
            this.btnFile6.Name = "btnFile6";
            this.btnFile6.Size = new System.Drawing.Size(159, 48);
            this.btnFile6.TabIndex = 1;
            this.btnFile6.Text = "Format File 6";
            this.btnFile6.UseVisualStyleBackColor = true;
            this.btnFile6.Click += new System.EventHandler(this.btnFile6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 98);
            this.Controls.Add(this.btnFile6);
            this.Controls.Add(this.btnFile2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Format File 2 and 6";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFile2;
        private System.Windows.Forms.Button btnFile6;
    }
}

