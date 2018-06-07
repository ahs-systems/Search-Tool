using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSSTool
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGetLDAP_Click(object sender, EventArgs e)
        {
            Hide();
            frmLDAP _frm = new frmLDAP();
            _frm.ShowDialog();
            Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Text = lblTitle.Text;

            // Check if valid user
            string _username = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Replace(@"HEALTHY\", "");
            if (!Common.CheckUsers(_username.ToUpper()))
            {
                MessageBox.Show("Error: Unknown user.\n\nApplication will now close.", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            LoadIt();
        }

        private void LoadIt()
        {
            string _msg = "";

            if (!Common.LoadIt("PSSTool", ref _msg))
            {
                MessageBox.Show(_msg, "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            Hide();
            frmEmailSuffixes _frm = new frmEmailSuffixes();
            _frm.ShowDialog();
            Show();
        }

        // Exit the program every early morning
        private void timerClose_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Hour > 1 && DateTime.Now.Hour < 5 && Cursor != Cursors.WaitCursor) Application.Exit();
        }

        private void btnEmpUnitSearch_Click(object sender, EventArgs e)
        {
            Hide();
            frmSearch _frm = new frmSearch();
            _frm.ShowDialog();
            Show();
        }
    }
}
