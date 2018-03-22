using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmEmailSuffixes : Form
    {
        public frmEmailSuffixes()
        {
            InitializeComponent();
        }

        private void ShowInvalidList()
        {
            try
            {
                using (SqlConnection _conn = new SqlConnection(Common.SSRS_Interface_Prod))
                {

                    dataGridView1.DataSource = null;
                    dataGridView1.Refresh();

                    string _sqlString = "select [Employee ID], [Employee Name], [Email Address], " +
                        "SUBSTRING([Email Address], CHARINDEX('@', [Email Address])+1, LEN([Email Address]) - CHARINDEX('@', [Email Address])) AS 'Invalid Suffix' " +
                        "from [ASC].v_Email_Address_Audit " +
                        "where zone = 'CAL' order by U_Desc, [Employee Name]";

                    using (SqlDataAdapter da = new SqlDataAdapter(_sqlString, _conn))
                    {
                        // clear the current content of the datagridview
                        dataGridView1.DataSource = null;
                        dataGridView1.Update();

                        DataTable t = new DataTable();
                        da.Fill(t);

                        dataGridView1.DataSource = t;

                        for (int i = 0; i < dataGridView1.ColumnCount; i++)
                        {
                            dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        }

                        lblItemsFound.Text = "Items Count: " + t.Rows.Count;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowValidList()
        {
            try
            {
                using (SqlConnection _conn = new SqlConnection(Common.SSRS_Interface_Prod))
                {

                    dataGridView1.DataSource = null;
                    dataGridView1.Refresh();

                    string _sqlString = "select SuffixText from email.Valid_Suffix order by SuffixText";

                    using (SqlDataAdapter da = new SqlDataAdapter(_sqlString, _conn))
                    {
                        // clear the current content of the datagridview
                        dataGridView1.DataSource = null;
                        dataGridView1.Update();

                        DataTable t = new DataTable();
                        da.Fill(t);

                        dataGridView1.DataSource = t;

                        for (int i = 0; i < dataGridView1.ColumnCount; i++)
                        {
                            dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        }

                        lblItemsFound.Text = "Items Count: " + t.Rows.Count;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmEmailSuffixes_Load(object sender, EventArgs e)
        {
            Hide();
            transFrm.ShowSync(this, false, null);
            Activate();

            ShowInvalidList();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnShowInvalid_Click(object sender, EventArgs e)
        {
            ShowInvalidList();
        }

        private void btnShowValidList_Click(object sender, EventArgs e)
        {
            ShowValidList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Columns.Count == 1)
            {
                MessageBox.Show("Please click first the \"Show List of Invalid Suffixes\" and then select from the list the one you want to add.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select first from the list the suffix you want to add.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string _emailSuffix = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value.ToString();

            DialogResult _res = MessageBox.Show("Are you sure you want to add \"" + _emailSuffix + 
                "\" to the list of valid suffixes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (_res == DialogResult.No)
            {
                return;
            }

            try
            {
                using (SqlConnection _conn = new SqlConnection(Common.SSRS_Interface_Prod))
                {
                    _conn.Open();

                    SqlCommand _cmd = new SqlCommand("email.sp_Update_Email_Suffix_List", _conn);
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Parameters.AddWithValue("Action", "Add");
                    _cmd.Parameters.AddWithValue("EmailSuffix", _emailSuffix.ToLower());
                    int _ret =_cmd.ExecuteNonQuery();
                    if (_ret != 0)
                    {
                        MessageBox.Show("\"" + _emailSuffix + "\" was successfully added to the valid list of email suffixes.","Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ShowInvalidList();
                    }
                    else
                    {
                        MessageBox.Show(" There was an error adding \"" + _emailSuffix + "\" to the valid list of email suffixes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRemoveFromList_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Columns.Count != 1)
            {
                MessageBox.Show("Please click first the \"Show Valid List of Suffixes\" and then select from the list the one you want to remove.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select first from the list the suffix you want to remove.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string _emailSuffix = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();

            DialogResult _res = MessageBox.Show("Are you sure you want to remove \"" + _emailSuffix +
                "\" from the list of valid suffixes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (_res == DialogResult.No)
            {
                return;
            }

            try
            {
                using (SqlConnection _conn = new SqlConnection(Common.SSRS_Interface_Prod))
                {
                    _conn.Open();

                    SqlCommand _cmd = new SqlCommand("email.sp_Update_Email_Suffix_List", _conn);
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Parameters.AddWithValue("Action", "Remove");
                    _cmd.Parameters.AddWithValue("EmailSuffix", _emailSuffix.ToLower());
                    int _ret = _cmd.ExecuteNonQuery();
                    if (_ret != 0)
                    {
                        MessageBox.Show("\"" + _emailSuffix + "\" was successfully removed from the valid list of email suffixes.", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ShowValidList();
                    }
                    else
                    {
                        MessageBox.Show("There was an error removing \"" + _emailSuffix + "\" from the valid list of email suffixes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
