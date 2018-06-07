using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PSSTool
{
    public partial class frmSelectZone : Form
    {
        public DialogResult _result;

        public frmSelectZone()
        {
            InitializeComponent();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            _result = DialogResult.Cancel;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _result = DialogResult.Cancel;
            Close();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (cboZone.selectedIndex == -1)
            {
                MessageBox.Show("Please select your zone to continue.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _result = DialogResult.OK;
            Close();
        }
    }
}
