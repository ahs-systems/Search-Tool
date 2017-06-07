using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using OfficeOpenXml;
using System.IO;
using System.Net;

namespace CheckIfESP
{
    public partial class Form1 : Form
    {
        SqlConnection _conn = new SqlConnection();
        SqlCommand _comm;

        public Form1()
        {
            InitializeComponent();
        }

        private string GetSSOEmail(string _tcg)
        {
            string _ret = "";

            switch (_tcg.Substring(0, 2))
            {
                case "01":
                    _ret = "ACH webform <ACH.webform@albertahealthservices.ca>; CAL.ACH Scheduler <ach.scheduler@albertahealthservices.ca>";
                    break;
                case "02":
                    _ret = "FMC webform <FMC.webform@albertahealthservices.ca>; CAL.FMC Scheduler <fmc.scheduler@albertahealthservices.ca>";
                    break;
                case "03":
                    _ret = "PLC webform <PLC.webform@albertahealthservices.ca>; CAL.PLC Scheduler <plc.scheduler@albertahealthservices.ca>";
                    break;
                case "04":
                    _ret = "RGH webform <RGH.webform@albertahealthservices.ca>; CAL.RGH Scheduler <rgh.scheduler@albertahealthservices.ca>";
                    break;
                case "05":
                    _ret = "COM webform <COM.webform@albertahealthservices.ca>; CAL.SPT Scheduler <spt.scheduler@albertahealthservices.ca>";
                    break;
                case "06":
                    _ret = "SHC Webform <SHC.Webform@albertahealthservices.ca>; CAL.SHC.Scheduler <SHC.Scheduler@albertahealthservices.ca>";
                    break;
                case "S2":
                    _ret = "AHS.Staffing Service Team16 <AHS.StaffingServiceTeam16@albertahealthservices.ca>";
                    break;
                default:
                    _ret = "";
                    break;
            }

            return _ret;
        }

        private string GetTCG(string _empID)
        {
            string _ret = "";

            _comm.CommandText = "select emp.e_empid EMPID from emp " +
                 "inner join empPosition on emp.e_empid = empPosition.ep_empid " +
                 "inner join employmentStatus on emp.e_empid = employmentStatus.EMS_EmpID " +
                 "where emp.e_empnbr LIKE @V_SEARCH and empPosition.ep_todate >= GetDAte() " +
                 "AND EmploymentStatus.EMS_EmploymentType = 1 AND EmploymentStatus.EMS_EndDate >= GetDAte() ";

            _comm.Parameters.Clear();
            _comm.Parameters.Add(new SqlParameter("V_SEARCH", _empID + "%"));
            SqlDataReader _reader = _comm.ExecuteReader();
            if (_reader.HasRows)
            {
                _reader.Read();

                string _retEmpID = _reader["EMPID"].ToString();

                _comm.CommandText = "select tcg_desc from timecardgroup where tcg_tcardgroupid = " +
                    "(select tc_tcardgroupid from timecard where tc_empid = " + _retEmpID + " and " +
                    "tc_payperiodid = (select max(tc_payperiodid) from timecard where tc_empid = " + _retEmpID + "))";

                _comm.Parameters.Clear();
                _reader.Close();
                _reader = _comm.ExecuteReader();

                if (_reader.HasRows)
                {
                    _reader.Read();
                    _ret = _reader["tcg_desc"].ToString().Trim();
                }

            }

            _reader.Close();

            return _ret;
        }

        private string CheckEmpIfActive(string _empID)
        {           

            string _tcg = "", _ssoEMail = "";
            
            if (_empID.Trim().Length < 8) return "Not valid EmpNo";

            _tcg = GetTCG(_empID.Substring(0, 8));
            if (_tcg == "")
            {
                return "NOT ACTIVE";
            }

            _ssoEMail = GetSSOEmail(_tcg);

            if (_ssoEMail == "")
            {
                return "NFP";
            }

            return "ACTIVE";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Title = "Please select Excel File";
                openFileDialog1.Filter = "Excel File (.xlsx)|*.xlsx|All Files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;

                bool userClickedOK = openFileDialog1.ShowDialog() == DialogResult.OK;

                if (!userClickedOK) return;
                button1.Text = "Processing...";
                Cursor.Current = Cursors.WaitCursor;
                Update();

                using (ExcelPackage package = new ExcelPackage(new FileInfo(openFileDialog1.FileName)))
                {
                    ExcelWorkbook workBook = package.Workbook;
                    ExcelWorksheet currentWorksheet = workBook.Worksheets.First();

                    int totalRows = currentWorksheet.Dimension.End.Row;
                    int totalCols = currentWorksheet.Dimension.End.Column;

                    using (ExcelPackage package2 = new ExcelPackage())
                    {
                        ExcelWorksheet worksheet = package2.Workbook.Worksheets.Add("Emp");

                        // Set Page Settings
                        worksheet.PrinterSettings.Orientation = eOrientation.Landscape;
                        worksheet.PrinterSettings.ShowGridLines = true;
                        worksheet.PrinterSettings.HorizontalCentered = true;
                        worksheet.PrinterSettings.TopMargin = (decimal)1.5 / 2.54M;
                        worksheet.PrinterSettings.BottomMargin = (decimal)1.5 / 2.54M;
                        worksheet.PrinterSettings.LeftMargin = (decimal)0.3 / 2.54M;
                        worksheet.PrinterSettings.RightMargin = (decimal)0.3 / 2.54M;
                        worksheet.PrinterSettings.HeaderMargin = (decimal)0.5 / 2.54M;
                        worksheet.PrinterSettings.FooterMargin = (decimal)0.5 / 2.54M;
                        //worksheet.HeaderFooter.OddHeader.LeftAlignedText = DateTime.Now.ToString("ddMMMyyyy");
                        //worksheet.HeaderFooter.OddHeader.RightAlignedText = "Pay Period: " + GetPP(DateTime.Now.ToString("ddMMMyyyy"));
                        //worksheet.HeaderFooter.OddHeader.CenteredText = "Off Code vs Bank Hours";
                        //worksheet.HeaderFooter.OddFooter.RightAlignedText = string.Format("Page {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
                        worksheet.View.PageBreakView = true;
                        //worksheet.PrinterSettings.RepeatRows = new ExcelAddress("$1:$1");

                        //worksheet.Cells[1, 1].Value = "Site"; worksheet.Cells[1, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin); worksheet.Column(1).Width = 4.70;
                        //worksheet.Cells[1, 2].Value = "Unit"; worksheet.Cells[1, 2].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin); worksheet.Column(2).Width = 36.30;
                        //worksheet.Cells[1, 3].Value = "Name"; worksheet.Cells[1, 3].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin); worksheet.Column(3).Width = 35;
                        //worksheet.Cells[1, 4].Value = "Emp No."; worksheet.Cells[1, 4].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin); worksheet.Column(4).Width = 14;
                        //worksheet.Cells[1, 5].Value = ""; worksheet.Cells[1, 5].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin); worksheet.Column(5).Width = 5.40;
                        //worksheet.Cells[1, 6].Value = "Off Code"; worksheet.Cells[1, 6].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin); worksheet.Column(6).Width = 23;
                        //worksheet.Cells[1, 7].Value = "Off"; worksheet.Cells[1, 7].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin); worksheet.Column(7).Width = 8.40;
                        //worksheet.Cells[1, 8].Value = "Bank Hrs"; worksheet.Cells[1, 8].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin); worksheet.Column(8).Width = 9.3;
                        //worksheet.Cells[1, 9].Value = "Difference"; worksheet.Cells[1, 9].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin); worksheet.Column(9).Width = 10.7;
                        //worksheet.Cells[1, 10].Value = "Change To"; worksheet.Cells[1, 10].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin); worksheet.Column(10).Width = 11;

                        //var range = worksheet.Cells[1, 1, 1, 10];
                        //range.Style.Font.Bold = true;
                        //range.Style.Font.Size = 11;
                        //range.Style.Font.Name = "Arial";
                        //range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        //range.Style.Fill.BackgroundColor.SetColor(Color.LightBlue);

                        for (int i = 1; i <= totalRows; i++)
                        {
                            try
                            {
                                worksheet.Row(i).Height = 20;
                                worksheet.Row(i).Style.Font.Size = 10;
                                worksheet.Row(i).Style.Font.Name = "Arial";
                                worksheet.Row(i).Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                                worksheet.Cells[i, 1].Value = currentWorksheet.Cells[i, 1].Value.ToString().Trim(); worksheet.Cells[i, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                worksheet.Cells[i, 2].Value = CheckEmpIfActive(currentWorksheet.Cells[i, 1].Value.ToString()); worksheet.Cells[i, 2].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                //worksheet.Cells[i, 3].Value = currentWorksheet.Cells[i, 5].Value.ToString().Trim(); worksheet.Cells[i, 3].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                //worksheet.Cells[i, 4].Value = currentWorksheet.Cells[i, 7].Value; worksheet.Cells[i, 4].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                //worksheet.Cells[i, 5].Value = currentWorksheet.Cells[i, 8].Value; worksheet.Cells[i, 5].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                //worksheet.Cells[i, 6].Value = currentWorksheet.Cells[i, 9].Value; worksheet.Cells[i, 6].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                //worksheet.Cells[i, 7].Value = currentWorksheet.Cells[i, 11].Value; worksheet.Cells[i, 7].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                //worksheet.Cells[i, 8].Value = Math.Floor(Convert.ToDouble(currentWorksheet.Cells[i, 13].Value) * 100) / 100; worksheet.Cells[i, 8].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                //worksheet.Cells[i, 9].Value = Convert.ToDouble(currentWorksheet.Cells[i, 11].Value) - (Math.Floor(Convert.ToDouble(currentWorksheet.Cells[i, 13].Value) * 100) / 100); worksheet.Cells[i, 9].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                //worksheet.Cells[i, 10].Value = ""; worksheet.Cells[i, 10].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                return;
                            }
                        }

                        //worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                        worksheet.Cells.AutoFitColumns();

                        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                        saveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                        saveFileDialog1.FilterIndex = 1;
                        //saveFileDialog1.FileName = "Bank Compare";
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            package2.SaveAs(new FileInfo(saveFileDialog1.FileName));
                            System.Diagnostics.Process.Start(saveFileDialog1.FileName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                button1.Text = "CheckIfESP";
                Cursor.Current = Cursors.Default;
                Update();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                _conn.ConnectionString = @"Server=wssqlc015v01\esp; Initial Catalog=esp_cal_prod;Integrated Security=SSPI;";
                if (_conn.State == ConnectionState.Open) _conn.Close();
                _conn.Open();
                _comm = _conn.CreateCommand();
                //MessageBox.Show("Connection successful!");

                //this.TopMost = true;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
