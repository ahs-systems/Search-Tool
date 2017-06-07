using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using OfficeOpenXml;
using System.IO;
using VisualEffects;
using VisualEffects.Animations.Effects;
using VisualEffects.Easing;

namespace WindowsFormsApplication1
{
    public partial class frmTrainings : Form
    {
        bool firstLoading = true;

        public frmTrainings()
        {
            InitializeComponent();
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Title = "Please select My Learning Link Excel File";
                openFileDialog1.Filter = "Excel File (.xlsx)|*.xlsx|All Files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;

                bool userClickedOK = openFileDialog1.ShowDialog() == DialogResult.OK;

                if (!userClickedOK) return;
                btnLoadData.Text = "Processing...";
                Cursor.Current = Cursors.WaitCursor;
                Update();

                using (ExcelPackage package = new ExcelPackage(new FileInfo(openFileDialog1.FileName)))
                {
                    ExcelWorkbook workBook = package.Workbook;

                    using (OdbcConnection myConnection = new OdbcConnection())
                    {
                        myConnection.ConnectionString = @"Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=" + Application.StartupPath + @"\trainings.accdb;Uid=Admin;Pwd=;";
                        myConnection.Open();

                        OdbcCommand myCommand = myConnection.CreateCommand();

                        myCommand.CommandText = "DELETE FROM TRAININGS"; // refresh the database with new data
                        myCommand.ExecuteNonQuery();
                        myCommand.CommandText = "ALTER TABLE TRAININGS ALTER COLUMN ID COUNTER(1,1)"; // refresh the database with new data
                        myCommand.ExecuteNonQuery();
                        //myCommand.CommandText = "alter table TRAININGS alter column id AUTOINCREMENT"; // refresh the database with new data
                        //myCommand.ExecuteNonQuery();

                        foreach (var excelWorksheet in package.Workbook.Worksheets)
                        {
                            if (excelWorksheet.Name.ToUpper().IndexOf("COURSE DASHBOARD") > -1) continue; // skip the Course Dashboard sheet

                            string _course = excelWorksheet.Cells[10, 1].Value != null ? excelWorksheet.Cells[10, 1].Value.ToString() : excelWorksheet.Name;

                            int totalRows = excelWorksheet.Dimension.End.Row;

                            for (int i = 10; i <= totalRows; i++)
                            {
                                myCommand.CommandText = "INSERT into TRAININGS (empNum, empName, emailAdd, jobTitle, dept, site, city, zone, manager, regDate, status, statDate, course) values " +
                                    "('" + excelWorksheet.Cells[i, 5].Value.ToString().Replace("'", "`") + // empNum
                                    "', '" + excelWorksheet.Cells[i, 6].Value.ToString().ToUpper().Replace("'", "`") + //empName
                                    "', '" + excelWorksheet.Cells[i, 9].Value.ToString().Replace("'", "`") + //email address
                                    "', '" + excelWorksheet.Cells[i, 16].Value.ToString().Replace("'", "`") + // jobTitle
                                    "', '" + excelWorksheet.Cells[i, 18].Value.ToString().Replace("'", "`") + // dept
                                    "', '" + excelWorksheet.Cells[i, 19].Value.ToString().Replace("'", "`") + // site
                                    "', '" + excelWorksheet.Cells[i, 20].Value.ToString().Replace("'", "`") + // city
                                    "', '" + excelWorksheet.Cells[i, 21].Value.ToString().Replace("'", "`") + // zone
                                    "', '" + (excelWorksheet.Cells[i, 22].Value == null ? "" : excelWorksheet.Cells[i, 22].Value.ToString().Replace("'", "`")) + // manager
                                    "', #" + excelWorksheet.Cells[i, 23].Value + // regDate
                                    "#, '" + excelWorksheet.Cells[i, 24].Value.ToString().Replace("'", "`") + // status
                                    "', #" + excelWorksheet.Cells[i, 25].Value + // statDate
                                    "#, '" + _course.Replace("'", "`") + "')";
                                myCommand.ExecuteNonQuery();
                            }

                            //int totalCols = excelWorksheet.Dimension.End.Column;
                            //MessageBox.Show(_course);
                        }

                        myCommand.CommandText = "UPDATE updated SET dateUpdated = NOW()";
                        myCommand.ExecuteNonQuery();

                        myCommand.CommandText = "SELECT dateUpdated from UPDATED"; 
                        OdbcDataReader _dr = myCommand.ExecuteReader();
                        _dr.Read();
                        lblUpdated.Text = "Last Updated: " + _dr["dateUpdated"].ToString();
                        _dr.Close();

                        dataGridView1.DataSource = null;
                        dataGridView1.Refresh();

                        MessageBox.Show("Done!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLoadData.Text = "Load Data from Excel";
                Cursor.Current = Cursors.Default;
                Update();
            }
        }

        private void LoadLastUpdatedDate()
        {
            try
            {
                using (OdbcConnection myConnection = new OdbcConnection())
                {
                    myConnection.ConnectionString = @"Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=" + Application.StartupPath + @"\trainings.accdb;Uid=Admin;Pwd=;";
                    myConnection.Open();

                    OdbcCommand myCommand = myConnection.CreateCommand();

                    myCommand.CommandText = "SELECT FORMAT(dateUpdated,'(dddd) MMM dd, yyyy hh:mm:ss am/pm') AS _dateUpdated from UPDATED"; 

                    OdbcDataReader _dr = myCommand.ExecuteReader();
                    _dr.Read();

                    lblUpdated.Text = "Last Updated: " +  _dr["_dateUpdated"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR in loading last updated date: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmTrainings_Shown(object sender, EventArgs e)
        {
            if (firstLoading)
            {
                LoadLastUpdatedDate();
                firstLoading = false;
            }

            this.Animate(new TopAnchoredHeightEffect(), EasingFunctions.BackEaseOut, 284, 1000, 0);
        }

        private void btnSearchName_Click(object sender, EventArgs e)
        {
            try
            {
                using (OdbcConnection myConnection = new OdbcConnection())
                {
                    myConnection.ConnectionString = @"Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=" + Application.StartupPath + @"\trainings.accdb;Uid=Admin;Pwd=;";
                    myConnection.Open();

                    dataGridView1.DataSource = null;
                    dataGridView1.Rows.Clear();
                    dataGridView1.Columns.Clear();

                    //using (OdbcDataAdapter a = new OdbcDataAdapter("SELECT Course, Status, format(statDate,'ddMMMyyyy') as [Date], empNum as EMP_ID, STRCONV(empName,3) as Name from trainings where empName LIKE '%" + txtEmpName.Text.Trim().ToUpper() + "%' ORDER BY EMPNAME, statDate DESC",myConnection))
                    using (OdbcDataAdapter a = new OdbcDataAdapter("SELECT Course, Status, format(statDate,'ddMMMyyyy') as [Date], empNum as EMP_ID, STRCONV(empName,3) as Name from trainings where empName LIKE ? ORDER BY EMPNAME, statDate DESC", myConnection))
                    {
                        a.SelectCommand.Parameters.AddWithValue("SEARCH_STR", "%" + txtEmpName.Text.Trim().ToUpper() + "%");
                        // 3
                        // Use DataAdapter to fill DataTable
                        DataTable t = new DataTable();
                        a.Fill(t);
                        // 4
                        // Render data onto the screen
                        dataGridView1.DataSource = t;

                        dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //.Fill;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR in loading last updated date: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtEmpName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnSearchName_Click(sender, e);
                txtEmpName.SelectionStart = 0;
                txtEmpName.SelectionLength = txtEmpName.Text.Length;
            }
        }

        private void btnSearchByEmpNo_Click(object sender, EventArgs e)
        {
            try
            {
                using (OdbcConnection myConnection = new OdbcConnection())
                {
                    myConnection.ConnectionString = @"Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=" + Application.StartupPath + @"\trainings.accdb;Uid=Admin;Pwd=;";
                    myConnection.Open();

                    dataGridView1.DataSource = null;
                    dataGridView1.Rows.Clear();
                    dataGridView1.Columns.Clear();

                    //using (OdbcDataAdapter a = new OdbcDataAdapter("SELECT Course, Status, format(statDate,'ddMMMyyyy') as [Date], empNum as EMP_ID, STRCONV(empName,3) as Name from trainings where empNum ='" + txtEmpNo.Text.Trim() + "' ORDER BY EMPNAME, statDate DESC", myConnection))
                    using (OdbcDataAdapter a = new OdbcDataAdapter("SELECT Course, Status, format(statDate,'ddMMMyyyy') as [Date], empNum as EMP_ID, STRCONV(empName,3) as Name from trainings where empNum = ? ORDER BY EMPNAME, statDate DESC", myConnection))
                    {
                        a.SelectCommand.Parameters.AddWithValue("SEARCH_STR", txtEmpNo.Text.Trim().ToUpper());
                        // 3
                        // Use DataAdapter to fill DataTable
                        DataTable t = new DataTable();
                        a.Fill(t);
                        // 4
                        // Render data onto the screen
                        dataGridView1.DataSource = t;

                        dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR in loading last updated date: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtEmpNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnSearchByEmpNo_Click(sender, e);
                txtEmpNo.SelectionStart = 0;
                txtEmpNo.SelectionLength = txtEmpNo.Text.Length;
            }
        }

        private void frmTrainings_Load(object sender, EventArgs e)
        {
            Height = 0;
        }
    }
}
