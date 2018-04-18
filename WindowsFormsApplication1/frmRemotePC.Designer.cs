namespace WindowsFormsApplication1
{
    partial class frmRemotePC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRemotePC));
            this.lblClose = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.transFrm = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.rdoOldClient = new System.Windows.Forms.RadioButton();
            this.rdoWebClient = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblClose
            // 
            this.lblClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.transFrm.SetDecoration(this.lblClose, BunifuAnimatorNS.DecorationType.None);
            this.lblClose.Image = ((System.Drawing.Image)(resources.GetObject("lblClose.Image")));
            this.lblClose.Location = new System.Drawing.Point(409, 1);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(22, 23);
            this.lblClose.TabIndex = 63;
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.transFrm.SetDecoration(this.lblTitle, BunifuAnimatorNS.DecorationType.None);
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(434, 29);
            this.lblTitle.TabIndex = 62;
            this.lblTitle.Text = "Remote a PC using LANDESK";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // txtBarcode
            // 
            this.txtBarcode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtBarcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.txtBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.transFrm.SetDecoration(this.txtBarcode, BunifuAnimatorNS.DecorationType.None);
            this.txtBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtBarcode.Location = new System.Drawing.Point(158, 128);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(110, 22);
            this.txtBarcode.TabIndex = 64;
            this.txtBarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBarcode_KeyPress);
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.transFrm.SetDecoration(this.label10, BunifuAnimatorNS.DecorationType.None);
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.label10.Location = new System.Drawing.Point(42, 129);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 15);
            this.label10.TabIndex = 65;
            this.label10.Text = "Computer Barcode:";
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(109)))), ((int)(((byte)(130)))));
            this.transFrm.SetDecoration(this.btnConnect, BunifuAnimatorNS.DecorationType.None);
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnConnect.Image = ((System.Drawing.Image)(resources.GetObject("btnConnect.Image")));
            this.btnConnect.Location = new System.Drawing.Point(292, 118);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(118, 40);
            this.btnConnect.TabIndex = 66;
            this.btnConnect.Text = "Connect";
            this.btnConnect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.lblTitle;
            this.bunifuDragControl1.Vertical = true;
            // 
            // rdoOldClient
            // 
            this.rdoOldClient.AutoSize = true;
            this.rdoOldClient.BackColor = System.Drawing.Color.Transparent;
            this.rdoOldClient.Checked = true;
            this.transFrm.SetDecoration(this.rdoOldClient, BunifuAnimatorNS.DecorationType.None);
            this.rdoOldClient.ForeColor = System.Drawing.Color.LightGray;
            this.rdoOldClient.Location = new System.Drawing.Point(26, 16);
            this.rdoOldClient.Name = "rdoOldClient";
            this.rdoOldClient.Size = new System.Drawing.Size(165, 17);
            this.rdoOldClient.TabIndex = 67;
            this.rdoOldClient.TabStop = true;
            this.rdoOldClient.Text = "Old LanDesk Client (Desktop)";
            this.rdoOldClient.UseVisualStyleBackColor = false;
            // 
            // rdoWebClient
            // 
            this.rdoWebClient.AutoSize = true;
            this.rdoWebClient.BackColor = System.Drawing.Color.Transparent;
            this.transFrm.SetDecoration(this.rdoWebClient, BunifuAnimatorNS.DecorationType.None);
            this.rdoWebClient.ForeColor = System.Drawing.Color.LightGray;
            this.rdoWebClient.Location = new System.Drawing.Point(26, 39);
            this.rdoWebClient.Name = "rdoWebClient";
            this.rdoWebClient.Size = new System.Drawing.Size(119, 17);
            this.rdoWebClient.TabIndex = 68;
            this.rdoWebClient.Text = "New Client (WebUI)";
            this.rdoWebClient.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoWebClient);
            this.groupBox1.Controls.Add(this.rdoOldClient);
            this.transFrm.SetDecoration(this.groupBox1, BunifuAnimatorNS.DecorationType.None);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.groupBox1.Location = new System.Drawing.Point(24, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 65);
            this.groupBox1.TabIndex = 69;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connect Option";
            // 
            // frmRemotePC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(45)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(434, 177);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.lblTitle);
            this.transFrm.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRemotePC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Remote a PC using LANDESK";
            this.Load += new System.EventHandler(this.frmRemotePC_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Label lblTitle;
        private BunifuAnimatorNS.BunifuTransition transFrm;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.RadioButton rdoOldClient;
        private System.Windows.Forms.RadioButton rdoWebClient;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}