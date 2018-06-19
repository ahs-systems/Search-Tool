using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;


namespace PSSTool
{
    public partial class frmClearLocks : Form
    {
        string CurrentUser;
        string UserZone;

        public frmClearLocks()
        {
            InitializeComponent();
            Hide();
        }

        private void Search(string _searchStr, string _searchBy)
        {
            try
            {
                using (SqlConnection _conn = new SqlConnection())
                {
                    switch (UserZone)
                    {
                        case "CAL":
                            _conn.ConnectionString = Common.CAL_Db;
                            break;
                        case "EDM":
                            _conn.ConnectionString = Common.EDM_Db;
                            break;
                        case "NCS":
                            _conn.ConnectionString = Common.NCS_Db;
                            break;
                        default:
                            break;
                    }



                    dataGridView1.DataSource = null;
                    dataGridView1.Refresh();

                    string _sqlString = "";

                    
                    string _mainSQL =
                            "select                                                                                    " +
                            "  hostname [Workstation],                                                                 " +
                            "  US_FullName [User],                                                                     " +
                            "  convert(varchar, instance, 120) [Date/Time],                                            " +
                            "                                                                                          " +
                            "  case [type]                                                                             " +
                            "  when 999  then 'Tools'                                                                  " +
                            "  when 5016 then 'Employees'                                                              " +
                            "  when 5044 then 'Work Plans'                                                             " +
                            "  when 5045 then 'Work Plans'                                                             " +
                            "  when 5069 then 'Time Cards'                                                             " +
                            "  when 5084 then 'Workbook'                                                               " +
                            "  when 6000 then 'Assignments'                                                            " +
                            "  when 6001 then 'Assignments'                                                            " +
                            "  when 8000 then 'Review Request'                                                         " +
                            "  else null                                                                               " +
                            "  end [Workspace],                                                                        " +
                            "                                                                                          " +
                            "  case                                                                                    " +
                            "  when ([type] = 999 and id = 0) then 'Time Card Generate'                                " +
                            "  when [type] = 5016 then (rtrim(E1.E_FirstName) + ' ' + rtrim(E1.E_LastName))            " +
                            "  when ([type] = 5044 or [type] = 5045) then (rtrim(R1.R_Desc))                           " +
                            "  when [type] = 5069 then (rtrim(E2.E_FirstName) + ' ' + rtrim(E2.E_LastName))            " +
                            "  when [type] = 5084 then (rtrim(WT_Desc))                                                " +
                            "  when [type] = 6000 then (rtrim(R2.R_Desc))                                              " +
                            "  when [type] = 6001 then (rtrim(E3.E_FirstName) + ' ' + rtrim(E3.E_LastName))            " +
                            "  when [type] = 8000 then ('Request ' + cast(id as varchar))                              " +
                            "  else null                                                                               " +
                            "  end [Record]                                                                            " +
                            "                                                                                          " +
                            "from                                                                                      " +
                            "            dbo.Softlocks                                                                 " +
                            "  left join dbo.Users       on (who = US_UserID)                                          " +
                            "  left join dbo.Emp E1      on ([type] = 5016 and id = E1.E_EmpID)                        " +
                            "  left join dbo.Rotation R1 on (([type] = 5044 or [type] = 5045) and id = R1.R_RotationID)" +
                            "  left join dbo.TimeCard    on ([type] = 5069 and id = TC_TimeCardID)                     " +
                            "  left join dbo.Emp E2      on ([type] = 5069 and TC_EmpID = E2.E_EmpID)                  " +
                            "  left join dbo.WBTask      on ([type] = 5084 and id = WT_TaskID)                         " +
                            "  left join dbo.Rotation R2 on ([type] = 6000 and id = R2.R_RotationID)                   " +
                            "  left join dbo.Emp E3      on ([type] = 6001 and id = E3.E_EmpID)                        ";
                    if (_searchBy == "RECORD")
                    {
                        _sqlString = "select Record, [User], Workspace, [Date/Time], Workstation from (" + _mainSQL + ") AS TempLock where UPPER(RECORD) LIKE @S_NAME ORDER BY [Date/Time]";
                    }
                    else
                    {
                        _sqlString = "select [User], Record, Workspace, [Date/Time], Workstation from (" + _mainSQL + ") AS TempLock where UPPER([USER]) LIKE @S_NAME ORDER BY [USER], [Date/Time]";
                    }

                    using (SqlDataAdapter da = new SqlDataAdapter(_sqlString, _conn))
                    {
                        da.SelectCommand.Parameters.AddWithValue("@S_NAME", "%" + _searchStr.ToUpper() + "%");

                        DataTable t = new DataTable();
                        da.Fill(t);
                        dataGridView1.DataSource = t;

                        dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                        lblItemsFound.Text = "Items Found: " + t.Rows.Count;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearchName_Click(object sender, EventArgs e)
        {
            if (txtSearchStr.Text.Trim().Length == 0) return;

            Search(txtSearchStr.Text.Trim(), "RECORD");
        }

        private void txtSearchStr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                var _searchBtn = this.Controls.Find(((TextBox)sender).Tag.ToString(), true).FirstOrDefault();
                ((Button)_searchBtn).PerformClick();
            }
        }

        private void frmClearLocks_Shown(object sender, EventArgs e)
        {
            //this.Animate(new TopAnchoredHeightEffect(), EasingFunctions.BackEaseOut, 259, 1000, 0);
        }

        private void frmClearLocks_Load(object sender, EventArgs e)
        {
            // Get Current User
            CurrentUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Replace(@"HEALTHY\", "");

            // Set the User's zone
            UserZone = Common.GetUsersZone(CurrentUser).Substring(1, 3);

            lblTitle.Text += ": " + UserZone + "-DB";

            txtSearchStr.Focus();
        }

        private void btnFindByUser_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Trim().Length == 0) return;

            Search(txtUser.Text.Trim(), "USER");
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
