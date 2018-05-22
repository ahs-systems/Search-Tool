namespace ASC_EmailAudit
{
    partial class frmEmailSuffixes
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
            BunifuAnimatorNS.Animation animation2 = new BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmailSuffixes));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblClose = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.transFrm = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblItemsFound = new System.Windows.Forms.Label();
            this.btnAdd = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnShowInvalid = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnShowValidList = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnRemoveFromList = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblClose
            // 
            this.lblClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.lblClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transFrm.SetDecoration(this.lblClose, BunifuAnimatorNS.DecorationType.None);
            this.lblClose.Image = ((System.Drawing.Image)(resources.GetObject("lblClose.Image")));
            this.lblClose.Location = new System.Drawing.Point(657, 1);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(22, 23);
            this.lblClose.TabIndex = 64;
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
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
            this.lblTitle.Size = new System.Drawing.Size(684, 29);
            this.lblTitle.TabIndex = 63;
            this.lblTitle.Text = "ASC Email Audit - ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.lblTitle;
            this.bunifuDragControl1.Vertical = true;
            // 
            // transFrm
            // 
            this.transFrm.AnimationType = BunifuAnimatorNS.AnimationType.ScaleAndRotate;
            this.transFrm.Cursor = null;
            animation2.AnimateOnlyDifferences = true;
            animation2.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.BlindCoeff")));
            animation2.LeafCoeff = 0F;
            animation2.MaxTime = 1F;
            animation2.MinTime = 0F;
            animation2.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicCoeff")));
            animation2.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicShift")));
            animation2.MosaicSize = 0;
            animation2.Padding = new System.Windows.Forms.Padding(30);
            animation2.RotateCoeff = 0.5F;
            animation2.RotateLimit = 0.2F;
            animation2.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.ScaleCoeff")));
            animation2.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.SlideCoeff")));
            animation2.TimeCoeff = 0F;
            animation2.TransparencyCoeff = 0F;
            this.transFrm.DefaultAnimation = animation2;
            this.transFrm.MaxAnimationTime = 2000;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.transFrm.SetDecoration(this.dataGridView1, BunifuAnimatorNS.DecorationType.None);
            this.dataGridView1.Location = new System.Drawing.Point(12, 91);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(59)))), ((int)(((byte)(5)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(59)))), ((int)(((byte)(5)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(658, 264);
            this.dataGridView1.TabIndex = 67;
            // 
            // lblItemsFound
            // 
            this.lblItemsFound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.transFrm.SetDecoration(this.lblItemsFound, BunifuAnimatorNS.DecorationType.None);
            this.lblItemsFound.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemsFound.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.lblItemsFound.Location = new System.Drawing.Point(12, 359);
            this.lblItemsFound.Name = "lblItemsFound";
            this.lblItemsFound.Size = new System.Drawing.Size(191, 37);
            this.lblItemsFound.TabIndex = 68;
            this.lblItemsFound.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAdd
            // 
            this.btnAdd.Activecolor = System.Drawing.Color.Transparent;
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdd.BorderRadius = 0;
            this.btnAdd.ButtonText = "Add Selected Invalid Suffix";
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transFrm.SetDecoration(this.btnAdd, BunifuAnimatorNS.DecorationType.None);
            this.btnAdd.DisabledColor = System.Drawing.Color.Gray;
            this.btnAdd.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAdd.Iconcolor = System.Drawing.Color.Transparent;
            this.btnAdd.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnAdd.Iconimage")));
            this.btnAdd.Iconimage_right = null;
            this.btnAdd.Iconimage_right_Selected = null;
            this.btnAdd.Iconimage_Selected = null;
            this.btnAdd.IconMarginLeft = 0;
            this.btnAdd.IconMarginRight = 0;
            this.btnAdd.IconRightVisible = true;
            this.btnAdd.IconRightZoom = 0D;
            this.btnAdd.IconVisible = true;
            this.btnAdd.IconZoom = 60D;
            this.btnAdd.IsTab = false;
            this.btnAdd.Location = new System.Drawing.Point(162, 39);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Normalcolor = System.Drawing.Color.Transparent;
            this.btnAdd.OnHovercolor = System.Drawing.Color.Transparent;
            this.btnAdd.OnHoverTextColor = System.Drawing.Color.White;
            this.btnAdd.selected = false;
            this.btnAdd.Size = new System.Drawing.Size(141, 45);
            this.btnAdd.TabIndex = 69;
            this.btnAdd.Text = "Add Selected Invalid Suffix";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.btnAdd.TextFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnShowInvalid
            // 
            this.btnShowInvalid.Activecolor = System.Drawing.Color.Transparent;
            this.btnShowInvalid.BackColor = System.Drawing.Color.Transparent;
            this.btnShowInvalid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnShowInvalid.BorderRadius = 0;
            this.btnShowInvalid.ButtonText = "Show List Of Invalid Suffix";
            this.btnShowInvalid.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transFrm.SetDecoration(this.btnShowInvalid, BunifuAnimatorNS.DecorationType.None);
            this.btnShowInvalid.DisabledColor = System.Drawing.Color.Gray;
            this.btnShowInvalid.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowInvalid.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnShowInvalid.Iconcolor = System.Drawing.Color.Transparent;
            this.btnShowInvalid.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnShowInvalid.Iconimage")));
            this.btnShowInvalid.Iconimage_right = null;
            this.btnShowInvalid.Iconimage_right_Selected = null;
            this.btnShowInvalid.Iconimage_Selected = null;
            this.btnShowInvalid.IconMarginLeft = 0;
            this.btnShowInvalid.IconMarginRight = 0;
            this.btnShowInvalid.IconRightVisible = true;
            this.btnShowInvalid.IconRightZoom = 0D;
            this.btnShowInvalid.IconVisible = true;
            this.btnShowInvalid.IconZoom = 60D;
            this.btnShowInvalid.IsTab = false;
            this.btnShowInvalid.Location = new System.Drawing.Point(15, 39);
            this.btnShowInvalid.Name = "btnShowInvalid";
            this.btnShowInvalid.Normalcolor = System.Drawing.Color.Transparent;
            this.btnShowInvalid.OnHovercolor = System.Drawing.Color.Transparent;
            this.btnShowInvalid.OnHoverTextColor = System.Drawing.Color.White;
            this.btnShowInvalid.selected = false;
            this.btnShowInvalid.Size = new System.Drawing.Size(141, 45);
            this.btnShowInvalid.TabIndex = 70;
            this.btnShowInvalid.Text = "Show List Of Invalid Suffix";
            this.btnShowInvalid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShowInvalid.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.btnShowInvalid.TextFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowInvalid.Click += new System.EventHandler(this.btnShowInvalid_Click);
            // 
            // btnShowValidList
            // 
            this.btnShowValidList.Activecolor = System.Drawing.Color.Transparent;
            this.btnShowValidList.BackColor = System.Drawing.Color.Transparent;
            this.btnShowValidList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnShowValidList.BorderRadius = 0;
            this.btnShowValidList.ButtonText = "Show Valid List of Suffixes";
            this.btnShowValidList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transFrm.SetDecoration(this.btnShowValidList, BunifuAnimatorNS.DecorationType.None);
            this.btnShowValidList.DisabledColor = System.Drawing.Color.Gray;
            this.btnShowValidList.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowValidList.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnShowValidList.Iconcolor = System.Drawing.Color.Transparent;
            this.btnShowValidList.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnShowValidList.Iconimage")));
            this.btnShowValidList.Iconimage_right = null;
            this.btnShowValidList.Iconimage_right_Selected = null;
            this.btnShowValidList.Iconimage_Selected = null;
            this.btnShowValidList.IconMarginLeft = 0;
            this.btnShowValidList.IconMarginRight = 0;
            this.btnShowValidList.IconRightVisible = true;
            this.btnShowValidList.IconRightZoom = 0D;
            this.btnShowValidList.IconVisible = true;
            this.btnShowValidList.IconZoom = 60D;
            this.btnShowValidList.IsTab = false;
            this.btnShowValidList.Location = new System.Drawing.Point(382, 40);
            this.btnShowValidList.Name = "btnShowValidList";
            this.btnShowValidList.Normalcolor = System.Drawing.Color.Transparent;
            this.btnShowValidList.OnHovercolor = System.Drawing.Color.Transparent;
            this.btnShowValidList.OnHoverTextColor = System.Drawing.Color.White;
            this.btnShowValidList.selected = false;
            this.btnShowValidList.Size = new System.Drawing.Size(141, 45);
            this.btnShowValidList.TabIndex = 72;
            this.btnShowValidList.Text = "Show Valid List of Suffixes";
            this.btnShowValidList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShowValidList.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.btnShowValidList.TextFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowValidList.Click += new System.EventHandler(this.btnShowValidList_Click);
            // 
            // btnRemoveFromList
            // 
            this.btnRemoveFromList.Activecolor = System.Drawing.Color.Transparent;
            this.btnRemoveFromList.BackColor = System.Drawing.Color.Transparent;
            this.btnRemoveFromList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemoveFromList.BorderRadius = 0;
            this.btnRemoveFromList.ButtonText = "Remove Selected Valid Suffix";
            this.btnRemoveFromList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transFrm.SetDecoration(this.btnRemoveFromList, BunifuAnimatorNS.DecorationType.None);
            this.btnRemoveFromList.DisabledColor = System.Drawing.Color.Gray;
            this.btnRemoveFromList.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveFromList.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRemoveFromList.Iconcolor = System.Drawing.Color.Transparent;
            this.btnRemoveFromList.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnRemoveFromList.Iconimage")));
            this.btnRemoveFromList.Iconimage_right = null;
            this.btnRemoveFromList.Iconimage_right_Selected = null;
            this.btnRemoveFromList.Iconimage_Selected = null;
            this.btnRemoveFromList.IconMarginLeft = 0;
            this.btnRemoveFromList.IconMarginRight = 0;
            this.btnRemoveFromList.IconRightVisible = true;
            this.btnRemoveFromList.IconRightZoom = 0D;
            this.btnRemoveFromList.IconVisible = true;
            this.btnRemoveFromList.IconZoom = 60D;
            this.btnRemoveFromList.IsTab = false;
            this.btnRemoveFromList.Location = new System.Drawing.Point(529, 40);
            this.btnRemoveFromList.Name = "btnRemoveFromList";
            this.btnRemoveFromList.Normalcolor = System.Drawing.Color.Transparent;
            this.btnRemoveFromList.OnHovercolor = System.Drawing.Color.Transparent;
            this.btnRemoveFromList.OnHoverTextColor = System.Drawing.Color.White;
            this.btnRemoveFromList.selected = false;
            this.btnRemoveFromList.Size = new System.Drawing.Size(141, 45);
            this.btnRemoveFromList.TabIndex = 71;
            this.btnRemoveFromList.Text = "Remove Selected Valid Suffix";
            this.btnRemoveFromList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemoveFromList.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.btnRemoveFromList.TextFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveFromList.Click += new System.EventHandler(this.btnRemoveFromList_Click);
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.transFrm.SetDecoration(this.bunifuSeparator1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(341, 40);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(8, 40);
            this.bunifuSeparator1.TabIndex = 73;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = true;
            // 
            // frmEmailSuffixes
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(45)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(684, 401);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.btnShowValidList);
            this.Controls.Add(this.btnRemoveFromList);
            this.Controls.Add(this.btnShowInvalid);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblItemsFound);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.lblTitle);
            this.transFrm.SetDecoration(this, BunifuAnimatorNS.DecorationType.BottomMirror);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEmailSuffixes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmEmailSuffixes";
            this.Load += new System.EventHandler(this.frmEmailSuffixes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Label lblTitle;
        private BunifuAnimatorNS.BunifuTransition transFrm;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblItemsFound;
        private Bunifu.Framework.UI.BunifuFlatButton btnAdd;
        private Bunifu.Framework.UI.BunifuFlatButton btnShowInvalid;
        private Bunifu.Framework.UI.BunifuFlatButton btnShowValidList;
        private Bunifu.Framework.UI.BunifuFlatButton btnRemoveFromList;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
    }
}