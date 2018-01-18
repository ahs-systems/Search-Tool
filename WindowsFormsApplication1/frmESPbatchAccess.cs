using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmESPbatchAccess : Form
    {
        public frmESPbatchAccess()
        {
            InitializeComponent();
        }

        private void frmESPbatchAccess_Load(object sender, EventArgs e)
        {
            Hide();
            transFrm.ShowSync(this, true, null);
            LoadUserGroups();
        }

        private void LoadUserGroups()
        {
            try
            {
                string text;
                var fileStream = new FileStream(Application.StartupPath + @"\SearchTool_UG.dat", FileMode.Open, FileAccess.Read);
                using (var streamReader = new StreamReader(fileStream, System.Text.Encoding.UTF8))
                {
                    text = streamReader.ReadToEnd();
                }

                string[] _userGroups = text.Split(',', '\n','\r');                

                lstUserGroups.Items.Clear();
                for (int i = 0; i < _userGroups.Length; i++)
                {
                    if (_userGroups[i].Trim() != "")
                    {
                        lstUserGroups.Items.Add(_userGroups[i]);
                    }
                }                

                if (lstUserGroups.Items.Count == 0)
                {
                    MessageBox.Show("No User Group Listed on the file.");
                    return;
                }
                else
                {
                    lblLstUserGroups.Text = "User Groups: (" + lstUserGroups.Items.Count + ")";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnAdd.Visible = btnRemove.Visible = btnExecute.Visible = false;
            lblUserGroup.Visible = txtUserGroup.Visible = btnSave.Visible = btnCancel.Visible = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnAdd.Visible = btnRemove.Visible = btnExecute.Visible = true;
            lblUserGroup.Visible = txtUserGroup.Visible = btnSave.Visible = btnCancel.Visible = false;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstUserGroups.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the user group you want to remove.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to remove User Group '" + lstUserGroups.SelectedItem.ToString().Trim() + "'?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            lstUserGroups.Items.RemoveAt(lstUserGroups.SelectedIndex);

            if (UpdateTheSourceFile())
            {
                LoadUserGroups();
                MessageBox.Show("User group successfully removed!");                
            }
            else
            {
                LoadUserGroups();
                MessageBox.Show("ERROR: ", "Error updating the source list.");
            }
        }

        private bool UpdateTheSourceFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(Application.StartupPath + @"\SearchTool_UG.dat"))
                {
                    for (int i = 0; i < lstUserGroups.Items.Count; i++)
                    {
                        writer.WriteLine(lstUserGroups.Items[i]);
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }


        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (lstUserGroups.Items.Count == 0)
            {
                MessageBox.Show("No user groups to execute the SQL Script");
                return;
            }

            if (txtShortDesc.Text.Trim() == "" || txtLongDesc.Text.Trim() == "")
            {
                MessageBox.Show("Blank field detected, please check again your inputs.");
                return;
            }

            try
            {
                btnExecute.Text = "Processing....";
                btnExecute.Enabled = false;
                btnExecute.Update();

                using (SqlConnection _conn = new SqlConnection(Common.ESPServer))
                {
                    _conn.Open();

                    using (SqlCommand cmd = _conn.CreateCommand())
                    {
                        List<string> _lstUserGroups = new List<string>();
                        int _recordCtr;

                        cmd.CommandText = "AddUserGroupAccess";
                        cmd.CommandType = CommandType.StoredProcedure;

                        for (int i = 0; i < lstUserGroups.Items.Count; i++)
                        {
                            _recordCtr = 0;

                            lstUserGroups.SelectedIndex = i;
                            lstUserGroups.Update();

                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@UserGroupName", SqlDbType.VarChar).Value = lstUserGroups.Items[i].ToString().Trim();
                            cmd.Parameters.Add("@UnitShortDesc", SqlDbType.VarChar).Value = txtShortDesc.Text.Trim();
                            cmd.Parameters.Add("@TCGroupDesc", SqlDbType.VarChar).Value = txtLongDesc.Text.Trim();
                            //cmd.Parameters.Add("@RightsInd", SqlDbType.TinyInt).Value = null;                                              

                            SqlDataReader _dr = cmd.ExecuteReader();
                            if (_dr.HasRows)
                            {
                                _recordCtr = 0;

                                while (_dr.Read())
                                {
                                    _recordCtr++;
                                    lblUserName.Text = _dr["User Name"] + " - " + _dr["Full Name"];
                                    lblUserName.Update();
                                }
                            }

                            _lstUserGroups.Add(lstUserGroups.Items[i].ToString().Trim() + " - " + _recordCtr + " record(s).");

                            _dr.Close();
                        }

                        StringBuilder _ret = new StringBuilder();
                        _ret.Append("RECORDS AFFECTED: \n\n");
                        for (int i = 0; i < _lstUserGroups.Count; i++)
                        {
                            _ret.Append("(");
                            _ret.Append((i + 1).ToString().PadLeft(2, '0'));
                            _ret.Append(") - ");
                            _ret.Append(_lstUserGroups[i]);
                            _ret.Append("\n");
                        }

                        lblUserName.Text = "";
                        MessageBox.Show(_ret.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                lblUserName.Text = "";

                btnExecute.Text = "Execute";
                btnExecute.Enabled = true;
                btnExecute.Update();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUserGroup.Text.Trim() == "")
            {
                MessageBox.Show("Blank field detected, please check again your input.");
                return;
            }

            lstUserGroups.Items.Add(txtUserGroup.Text.Trim());

            if (UpdateTheSourceFile())
            {                
                LoadUserGroups();
                btnCancel.PerformClick();
                MessageBox.Show("User group successfully added!");
            }
            else
            {
                LoadUserGroups();
                MessageBox.Show("ERROR: ", "Error updating the source list.");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
