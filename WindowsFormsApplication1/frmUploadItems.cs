using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmUploadItems : Form
    {
        public UploadItemsParams attr = new UploadItemsParams();

        public frmUploadItems()
        {
            InitializeComponent();
        }

        private void chkUploadToItems_CheckedChanged(object sender, EventArgs e)
        {
            grpItems.Enabled = attr.uploadToItems = chkUploadToItems.Checked;             
        }

        private void frmUploadItems_Load(object sender, EventArgs e)
        {
            cboYearPP.Items.Add(DateTime.Today.Year + 1); cboYearPP.Items.Add(DateTime.Today.Year); cboYearPP.Items.Add(DateTime.Today.Year - 1); 
            cboYearPP.SelectedIndex = 1;

            cboPP.SelectedItem = Common.GetPP(DateTime.Now.ToString("yyyy-MM-dd"));
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (chkUploadToItems.Checked)
            {
                if (cboItemsReport.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select first the Items Report Letter from the dropdown list.");
                    cboItemsReport.Focus();
                    return;
                }
                attr.pp = cboPP.SelectedItem.ToString();
                attr.ppYear = cboYearPP.SelectedItem.ToString();
                attr.itemsReportLetter = cboItemsReport.SelectedItem.ToString();
            }
            Close();
        }
    }
}
