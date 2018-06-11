using System;
using System.Linq;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class frmLatestLogin : Form
    {
        public frmLatestLogin()
        {
            InitializeComponent();
        }

        private void frmLatestLogin_Load(object sender, EventArgs e)
        {
            Hide();
            transFrm.ShowSync(this, true, null);
            Activate();
            txtEmpNo.Focus();
        }

        private void Search(Func<string, string[]> myMethod, string _input)
        {
            if (_input.Length == 0) return;

            lblLastLoginDate.Text = "";

            if (lstResult.Items.Count > 0) lstResult.Items.Clear();

            //string[] _ret = SearchMethods.GetUsersByName(txtEmpName.Text.Trim());
            string[] _ret = myMethod(_input);

            if (_ret.Count() > 0)
            {
                for (int i = 0; i < _ret.Count(); i++)
                {
                    lstResult.Items.Add(_ret[i]);
                }
                if (lstResult.Items.Count == 1)
                {
                    lstResult.SelectedIndex = 0;
                    lstResult_Click(null, null);
                }
            }
        }

        private void lstResult_Click(object sender, EventArgs e)
        {
            if (lstResult.SelectedIndex != -1 && !lstResult.SelectedItem.ToString().StartsWith("ERROR:"))
            {
                lblLastLoginDate.Text = SearchMethods.GetLatestLogin(lstResult.SelectedItem.ToString().Substring(0, lstResult.SelectedItem.ToString().IndexOf('-') - 1));
            }
        }

        private void btnSearchName_Click(object sender, EventArgs e)
        {
            Search(SearchMethods.GetUsersByName, txtEmpName.Text.Trim());
        }

        private void btnSearchByEmpNo_Click(object sender, EventArgs e)
        {
            Search(SearchMethods.GetUsersByEmpNo, txtEmpNo.Text.Trim());
        }

        private void txtEmpName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Search(SearchMethods.GetUsersByName, txtEmpName.Text.Trim());
                txtEmpName.SelectionStart = 0;
                txtEmpName.SelectionLength = txtEmpName.Text.Length;
            }
        }

        private void txtEmpNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Search(SearchMethods.GetUsersByEmpNo, txtEmpNo.Text.Trim());
                txtEmpNo.SelectionStart = 0;
                txtEmpNo.SelectionLength = txtEmpNo.Text.Length;
            }
        }

        private void frmLatestLogin_Shown(object sender, EventArgs e)
        {
            //this.Animate(new TopAnchoredHeightEffect(), EasingFunctions.BackEaseOut, 268, 1000, 0);
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lblMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
