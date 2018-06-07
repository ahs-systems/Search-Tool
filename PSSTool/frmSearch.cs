using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSSTool
{
    public partial class frmSearch : Form
    {

        byte _searchMode; //1=occupation, 2=employee, 3=unit
        string CurrentUser;

        public frmSearch()
        {
            InitializeComponent();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            // update form title
            Text = lblTitle.Text;

            // Get Current User
            CurrentUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Replace(@"HEALTHY\", "");

            // Set the default zone
            cboZone.SelectedItem = Common.GetUsersZone(CurrentUser).Substring(1, 3);
        }

        private void txtOCode_TextChanged(object sender, EventArgs e)
        {
            _searchMode = 1;

            btnSendEmail.Visible = txtTCG.Visible = false;

            string _searchString = "";

            if (txtOCode.Text.Trim().Length == 0)
            {
                lblMsg.Text = "";
                lstResult.Items.Clear();
                return;
            }

            txtEmpNo.Text = txtUnit.Text = "";

            if ("0123456789".IndexOf(txtOCode.Text.Trim()[0]) != -1)
            {
                _searchString = txtOCode.Text.Trim().PadLeft(4, '0');
            }
            else
            {
                _searchString = txtOCode.Text.Trim().ToUpper();
            }

            lblMsg.Text = "Please wait...";
            Update();

            using (SqlConnection _conn = new SqlConnection(Common.GetZoneConnectionString(cboZone.SelectedItem.ToString())))
            {
                _conn.Open();

                SqlCommand _comm = _conn.CreateCommand();
                _comm.CommandText = "SELECT LTRIM(RTRIM(O_CODE)) + ' - ' + O_DESC 'DESC' FROM OCCUPATION WHERE O_CODE LIKE @V_O_CODE AND O_OccClassID <> 612 order by o_code";
                _comm.Parameters.Add(new SqlParameter("V_O_CODE", _searchString + "%")); //) + "
                SqlDataReader _reader = _comm.ExecuteReader();
                if (_reader.HasRows)
                {
                    lstResult.Items.Clear();
                    while (_reader.Read())
                    {
                        lstResult.Items.Add(_reader["DESC"].ToString());
                    }
                }
                else
                {
                    lstResult.Items.Clear();
                }
                _reader.Close();
            }

            lblMsg.Text = lstResult.Items.Count + " record(s) found.";
            Update();
        }

        private void lstResult_MouseHover(object sender, EventArgs e)
        {
            if (lstResult.Items.Count > 0)
            {
                if (_searchMode == 1) lblMsg.Text = "Double click to copy the selected occupation to the clipboard."; // searching occupation
                else if (_searchMode == 2) lblMsg.Text = "Select an EE and right click to copy it to clipboard."; // searching employee
            }
        }

        private void lstResult_MouseLeave(object sender, EventArgs e)
        {
            lblMsg.Text = "";
        }

        private void lstResult_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right:
                    {
                        if (_searchMode == 1 || _searchMode == 3 || lstResult.Items.Count == 0)
                        {
                            return;
                        }
                        else if (lstResult.SelectedIndex == -1)
                        {
                            MessageBox.Show("Select an employee first then right click.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        mnuCopyFromList.Show(lstResult, new Point(e.X, e.Y));
                    }
                    break;
            }
        }

        private void lstResult_Click(object sender, EventArgs e)
        {
            if (lstResult.SelectedIndex != -1 && _searchMode == 2)
            {
                btnSendEmail.Visible = txtTCG.Visible = true;
                string _tcg = Common.GetTCG(lstResult.SelectedItem.ToString().Substring(0, 10), cboZone.SelectedItem.ToString());
                txtTCG.Text = "Timecard Group: " + _tcg;
            }
        }

        private void lstResult_DoubleClick(object sender, EventArgs e)
        {
            if (lstResult.SelectedIndex != -1)
            {
                if (_searchMode == 1)
                {
                    Clipboard.SetText(lstResult.Items[lstResult.SelectedIndex].ToString().Trim());
                    // else Clipboard.SetText(lstResult.Items[lstResult.SelectedIndex].ToString().Trim().Substring(15));
                    lblMsg.Text = "Copied to clipboard !";
                }
            }
        }

        private void txtEmpNo_TextChanged(object sender, EventArgs e)
        {
            _searchMode = 2;
            btnSendEmail.Visible = txtTCG.Visible = false;

            string _searchString = "";
            bool _searchEmpNo = false;

            if (txtEmpNo.Text.Trim().Length == 0)
            {
                lstResult.Items.Clear();
                return;
            }

            // Search with atleast 2 characters or numbers
            if (txtEmpNo.Text.Trim().Length < 2)
            {
                return;
            }

            txtOCode.Text = txtUnit.Text = "";

            if ("0123456789".IndexOf(txtEmpNo.Text.Trim()[0]) != -1)
            {
                _searchString = txtEmpNo.Text.Trim().PadLeft(8, '0');
                _searchEmpNo = true;
            }
            else
            {
                _searchString = txtEmpNo.Text.Trim().ToUpper();
            }

            lblMsg.Text = "Please wait...";
            Update();

            using (SqlConnection _conn = new SqlConnection(Common.GetZoneConnectionString(cboZone.SelectedItem.ToString())))
            {
                _conn.Open();

                SqlCommand _comm = _conn.CreateCommand();
                if (_searchEmpNo) // SEARCH BY EMP NO
                {
                    _comm.CommandText = "SELECT LTRIM(RTRIM(E_EMPNBR)) + '  -  ' + LTRIM(RTRIM(E_LASTNAME)) + ', ' + LTRIM(RTRIM(E_FIRSTNAME)) 'DESC' FROM EMP WHERE E_EMPNBR LIKE @V_SEARCH AND LEN(E_EMPNBR) > 7 ORDER BY E_LASTNAME, E_FIRSTNAME";
                }
                else // SEARCH BY LAST NAME
                {
                    _comm.CommandText = "SELECT LTRIM(RTRIM(E_EMPNBR)) + '  -  ' + LTRIM(RTRIM(E_LASTNAME)) + ', ' + LTRIM(RTRIM(E_FIRSTNAME)) 'DESC' FROM EMP WHERE (UPPER(E_LASTNAME) LIKE @V_SEARCH OR UPPER(E_FIRSTNAME) LIKE @V_SEARCH) AND LEN(E_EMPNBR) > 7 ORDER BY E_LASTNAME, E_FIRSTNAME";
                }

                _comm.Parameters.Add(new SqlParameter("V_SEARCH", _searchString + "%")); //) + "
                SqlDataReader _reader = _comm.ExecuteReader();
                if (_reader.HasRows)
                {
                    lstResult.Items.Clear();
                    while (_reader.Read())
                    {
                        lstResult.Items.Add(_reader["DESC"].ToString());
                    }
                }
                else
                {
                    lstResult.Items.Clear();
                }
                _reader.Close();
            }

            lblMsg.Text = lstResult.Items.Count + " record(s) found.";
            Update();
        }

        private void txtTCG_DoubleClick(object sender, EventArgs e)
        {
            if (txtTCG.Text != "---")
            {
                Clipboard.SetText(txtTCG.Text.Substring(16)); //only copy the actual timecard group
                lblMsg.Text = "Copied to clipboard !";
            }
        }

        private void txtTCG_MouseHover(object sender, EventArgs e)
        {
            if (txtTCG.Text.IndexOf("---") < 0) // EE has timecard group
            {
                lblMsg.Text = "Double click to copy the Timecard Group to the clipboard.";
            }
        }

        private void txtTCG_MouseLeave(object sender, EventArgs e)
        {
            if (lblMsg.Text == "Double click to copy the Timecard Group to the clipboard.") lblMsg.Text = "";
        }

        private void cboZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstResult.Items.Clear();
        }

        private void mnuCopyEmpNum_Click(object sender, EventArgs e)
        {
            string _clipText = lstResult.Items[lstResult.SelectedIndex].ToString().Trim().Substring(0, 8);
            Clipboard.SetText(_clipText);
            MessageBox.Show("'" + _clipText + "' copied to clipboard!");
        }

        private void mnuCopyEmpName_Click(object sender, EventArgs e)
        {
            string _clipText = lstResult.Items[lstResult.SelectedIndex].ToString().Trim().Substring(
                lstResult.Items[lstResult.SelectedIndex].ToString().Trim().IndexOf(" - ") + 4);
            Clipboard.SetText(_clipText);
            MessageBox.Show("'" + _clipText + "' copied to clipboard!");
        }

        private void mnuCopyBothNameAndNum_Click(object sender, EventArgs e)
        {
            string _clipText = lstResult.Items[lstResult.SelectedIndex].ToString().Trim().Substring(0);
            Clipboard.SetText(_clipText);
            MessageBox.Show("'" + _clipText + "' copied to clipboard!");
        }

        private void txtUnit_TextChanged(object sender, EventArgs e)
        {
            _searchMode = 3;
            btnSendEmail.Visible = txtTCG.Visible = false;

            if (txtUnit.Text.Trim().Length == 0)
            {
                lstResult.Items.Clear();
                return;
            }

            txtOCode.Text = txtEmpNo.Text = "";

            if (txtUnit.Text.Trim().Length < 2) return;

            lblMsg.Text = "Please wait...";
            Update();

            using (SqlConnection _conn = new SqlConnection(Common.GetZoneConnectionString(cboZone.SelectedItem.ToString())))
            {
                _conn.Open();

                SqlCommand _comm = _conn.CreateCommand();

                _comm.CommandText = "select U_desc + ' | ' + Rtrim(LTrim(U_ShortDesc)) AS Units from unit where " +
                "(UPPER(U_Desc) LIKE @_SearchStr OR UPPER(U_ShortDesc) LIKE @_SearchStr) AND U_Active = 1 order by U_Desc";

                _comm.Parameters.Add(new SqlParameter("_SearchStr", "%" + txtUnit.Text.Trim().ToUpper() + "%"));
                SqlDataReader _reader = _comm.ExecuteReader();
                if (_reader.HasRows)
                {
                    lstResult.Items.Clear();
                    while (_reader.Read())
                    {
                        lstResult.Items.Add(_reader["Units"].ToString());
                    }
                }
                else
                {
                    lstResult.Items.Clear();
                }
                _reader.Close();
            }

            lblMsg.Text = lstResult.Items.Count + " record(s) found.";
            Update();
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            string _tcg = "", _ssoEMail = "";

            if (lstResult.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an employee first.");
                return;
            }

            _tcg = Common.GetTCG(lstResult.SelectedItem.ToString().Substring(0, 10), cboZone.SelectedItem.ToString());
            if (_tcg.ToUpper().IndexOf("INACTIVE") > -1)
            {
                MessageBox.Show("Sorry, the EE may no longer be active.");
                return;
            }

            if (_tcg.ToUpper().IndexOf("NOT FOR PAYROLL") > -1)
            {
                MessageBox.Show("Sorry, the EE is set for NOT FOR PAYROLL.");
                return;
            }

            //_ssoEMail = GetSSOEmail(_tcg);

            //if (_ssoEMail == "")
            //{
            //    MessageBox.Show("Sorry, the EE is NFP.");
            //    return;
            //}

            StringBuilder _sb = new StringBuilder();

            _sb.Append("mailto:" + _ssoEMail);
            _sb.Append("&subject=" + _tcg.Replace("&", "%26") + " - " + lstResult.SelectedItem.ToString());
            System.Diagnostics.Process.Start(_sb.ToString());
        }
    }
}
