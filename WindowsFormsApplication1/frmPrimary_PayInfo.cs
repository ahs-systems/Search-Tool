using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmPrimary_PayInfo : Form
    {
        AutoCompleteStringCollection unitsLongDesc = new AutoCompleteStringCollection();

        public frmPrimary_PayInfo()
        {
            InitializeComponent();
        }

        private void frmPrimary_PayInfo_Load(object sender, EventArgs e)
        {
            Hide();
            transFrm.ShowSync(this, true, null);
            txtSearchStr.Focus();

            Common.PopulateUnitLongDesc(ref unitsLongDesc);
            txtSearchStr.AutoCompleteCustomSource = unitsLongDesc;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Search(string _searchStr)
        {
            try
            {
                using (SqlConnection _conn = new SqlConnection())
                {
                    _conn.ConnectionString = Common.ESPServer;

                    dataGridView1.DataSource = null;
                    dataGridView1.Refresh();

                    string _sqlString = "select RTRIM(E.E_EmpNbr) AS EMP_ID, RTRIM(E.E_LastName) AS LastName, RTRIM(E.E_FirstName) AS FirstName, RTRIM(U.U_Desc) as 'Primary', " +
                        "RTRIM((SELECT TCG_Desc from TimeCardGroup where TCG_TCardGroupID = " +
                        " (select TOP 1 ETCI_TimeCardGroupID from EmpTimeCardInfo ETCI where ETCI_EmpID = EP.EP_EmpID ORDER BY ETCI_PayPeriodID DESC))) as 'Pay Info', " +
                        "case " +
                        "   when(SELECT TCG_Desc from TimeCardGroup where TCG_TCardGroupID = " +
                        "       (select TOP 1 ETCI_TimeCardGroupID from EmpTimeCardInfo ETCI where ETCI_EmpID = EP.EP_EmpID ORDER BY ETCI_PayPeriodID DESC)) <> U.U_Desc then 'Primary <> Pay Info' " +
                        "	else '---' " +
                        "end as Result " +
                        "from EmpPosition EP " +
                        "join Unit U on EP.EP_UnitID = U.U_UnitID " +
                        "join Emp E on EP.EP_EmpID = E.E_EmpID " +
                        "where EP.EP_UnitID = (select U_UnitID from Unit where upper(U_Desc) = @unitName) " +
                        "and EP.EP_PrimaryInd = 1 and EP.EP_ToDate > getdate() " +
                        "ORDER BY E.E_LastName";

                    using (SqlDataAdapter da = new SqlDataAdapter(_sqlString, _conn))
                    {
                        da.SelectCommand.Parameters.AddWithValue("@unitName", _searchStr.ToUpper());

                        DataTable t = new DataTable();
                        da.Fill(t);
                        dataGridView1.DataSource = t;

                        dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                        lblItemsFound.Text = "Employee Count: " + t.Rows.Count;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ListNFP()
        {
            try
            {
                using (SqlConnection _conn = new SqlConnection())
                {
                    _conn.ConnectionString = Common.ESPServer;

                    dataGridView1.DataSource = null;
                    dataGridView1.Refresh();

                    string _sqlString = "select RTrim(E.E_EmpNbr) AS EMP_ID, Rtrim(E.E_LastName) AS LastName, Rtrim(E.E_FirstName) AS FirstName, " +
                        "Rtrim((SELECT TCG_Desc from TimeCardGroup where TCG_TCardGroupID =  " +
                        " (select TOP 1 ETCI_TimeCardGroupID from EmpTimeCardInfo ETCI where ETCI_EmpID = EP.EP_EmpID ORDER BY ETCI_PayPeriodID DESC))) as 'Pay Info',  " +
                        "  Rtrim(U.U_Desc) as 'Primary'  " +
                        "from EmpPosition EP  " +
                        "join Unit U on EP.EP_UnitID = U.U_UnitID  " +
                        "join Emp E on EP.EP_EmpID = E.E_EmpID  " +
                        "where  " +
                        "(SELECT TCG_Desc from TimeCardGroup where TCG_TCardGroupID =  " +
                        " (select TOP 1 ETCI_TimeCardGroupID from EmpTimeCardInfo ETCI where ETCI_EmpID = EP.EP_EmpID ORDER BY ETCI_PayPeriodID DESC)) = 'Not For Payroll'  " +
                        " AND U.U_Desc <> 'Not For Payroll'  " +
                        "and EP.EP_PrimaryInd = 1 and EP.EP_ToDate > getdate()  " +
                        "ORDER BY E.E_LastName";

                    using (SqlDataAdapter da = new SqlDataAdapter(_sqlString, _conn))
                    {
                        //da.SelectCommand.Parameters.AddWithValue("@unitName", _searchStr.ToUpper());

                        DataTable t = new DataTable();
                        da.Fill(t);
                        dataGridView1.DataSource = t;

                        dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                        lblItemsFound.Text = "Employee Count: " + t.Rows.Count;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearchStr.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the unit to search");
                return;
            }
            Search(txtSearchStr.Text.Trim());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtSearchStr.Text = "";
            ListNFP();
        }

        private void dataGridView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (dataGridView1.Rows.Count != 0 && dataGridView1.CurrentCell.RowIndex != -1)
            {
                switch (e.Button)
                {
                    case MouseButtons.Right:
                        {
                            mnuCopyFromList.Show(dataGridView1, new Point(e.X, e.Y));
                        }
                        break;
                }
            }
        }

        private void mnuCopyEmpNum_Click(object sender, EventArgs e)
        {
            string _clipText = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString().Substring(0, 8);
            string _name =  dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value + "  " +
                            dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value + ", " +
                            dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value;
            Clipboard.SetText(_clipText);
            MessageBox.Show("Employee number '" + _clipText + "' copied to clipboard!\n\n" + _name, "Copied", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
