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

namespace DelinquentSummary
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Please select the CSV Files";
            openFileDialog1.Multiselect = true;
            openFileDialog1.Filter = "CSV Files (.csv)|*.csv|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            bool userClickedOK = openFileDialog1.ShowDialog() == DialogResult.OK;

            if (!userClickedOK) return;

            listBox1.Items.Clear();
            foreach (String file in openFileDialog1.FileNames)
            {
                listBox1.Items.Add(file);
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                btnProcess.Text = "Processing...";
                Update();

                if (listBox1.Items.Count == 0)
                {
                    MessageBox.Show("No files to process");
                    return;
                }

                using (OdbcConnection myConnection = new OdbcConnection())
                {
                    //myConnection.ConnectionString = @"Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=\\jeeves.crha-health.ab.ca\rsss_systems\Operations - RSSS Systems Group\Automated Files\logs.mdb;Uid=Admin;Pwd=;";
                    myConnection.ConnectionString = @"Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=" + Application.StartupPath + @"\units.dat;Uid=Admin;Pwd=;";
                    myConnection.Open();

                    OdbcCommand myCommand = myConnection.CreateCommand();
                    myCommand.CommandText = "Delete from units";
                    myCommand.ExecuteNonQuery();

                    for (int i = 0; i < listBox1.Items.Count; i++)
                    {
                        string[] lines = System.IO.File.ReadAllLines(listBox1.Items[i].ToString());

                        foreach (string line in lines)
                        {
                            if (line.IndexOf(",") < 0)
                            {
                                myCommand.CommandText = "Insert into units (units, cnt) values ('" + line.Trim().Replace("'", "`") + "', 1)";
                                myCommand.ExecuteNonQuery();
                            }
                        }
                    }

                    myCommand.CommandText = "SELECT UNITS, SUM(CNT) As [# OF INSTANCE] from uNITS GROUP BY UNITS ORDER BY SUM(CNT) DESC, UNITS ASC";

                    OdbcDataAdapter _da = new OdbcDataAdapter(myCommand);
                    DataTable _dt = new DataTable();
                    _da.Fill(_dt);

                    using (ExcelPackage pck = new ExcelPackage())
                    {
                        ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Deliquents");
                        ws.Cells["A1"].LoadFromDataTable(_dt, true);
                        ws.Cells[ws.Dimension.Address].AutoFitColumns();

                        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                        saveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                        saveFileDialog1.FilterIndex = 1;
                        saveFileDialog1.FileName = "Deliquents Summary " + DateTime.Now.ToString("ddMMMyy");
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            pck.SaveAs(new FileInfo(saveFileDialog1.FileName));
                            System.Diagnostics.Process.Start(saveFileDialog1.FileName);
                        }
                    }

                    _da.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
            finally
            {
                btnProcess.Text = "Process the files";
            }
        }
    }
}
