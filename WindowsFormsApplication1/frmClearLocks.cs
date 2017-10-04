using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using VisualEffects;
using VisualEffects.Animations.Effects;
using VisualEffects.Easing;

namespace WindowsFormsApplication1
{
    public partial class frmClearLocks : Form
    {

        public frmClearLocks()
        {
            InitializeComponent();
        }

        private void Search(string _searchStr, string _searchBy)
        {
            try
            {
                using (SqlConnection _conn = new SqlConnection())
                {
                    _conn.ConnectionString = @"Server=" + SearchMethods.dbServer + "; Initial Catalog=Boo;User ID=BOO_USER;Password=BOO_USER;";

                    dataGridView1.DataSource = null;
                    dataGridView1.Refresh();

                    string _sqlString = "";

                    if (_searchBy == "RECORD")
                    {
                        _sqlString = "select Record, [User], Workspace, [Date/Time], Workstation from v_clear_locks_cal where UPPER(RECORD) LIKE @S_NAME ORDER BY [Date/Time]";
                    }
                    else
                    {
                        _sqlString = "select [User], Record, Workspace, [Date/Time], Workstation from v_clear_locks_cal where UPPER([USER]) LIKE @S_NAME ORDER BY [USER], [Date/Time]";
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
            this.Animate(new TopAnchoredHeightEffect(), EasingFunctions.BackEaseOut, 259, 1000, 0);
        }

        private void frmClearLocks_Load(object sender, EventArgs e)
        {
            Height = 0;
        }

        private void btnFindByUser_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Trim().Length == 0) return;

            Search(txtUser.Text.Trim(), "USER");
        }
    }
}
