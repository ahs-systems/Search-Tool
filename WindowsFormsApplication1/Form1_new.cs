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

namespace WindowsFormsApplication1
{
    public partial class frmSearch : Form
    {
        SqlConnection _conn = new SqlConnection();
        SqlCommand _comm;

        byte _searchMode; //1=occupation, 2=employee

        public frmSearch()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {




        }

        private string GetPP(string _date)
        {
            string _ret = "";

            _comm.CommandText = "select PP_NBR from payperiod where @V_DATE between pp_startdate and pp_enddate";
            _comm.Parameters.Clear();
            _comm.Parameters.Add(new SqlParameter("V_DATE", _date));
            SqlDataReader _reader = _comm.ExecuteReader();
            _reader.Read();
            _ret = _reader["PP_NBR"].ToString();
            if (_reader.IsClosed != true) _reader.Close();

            if (_ret != "") _ret = "Pay period: " + _ret;

            return _ret;
        }

        private void txtOCode_TextChanged(object sender, EventArgs e)
        {
            _searchMode = 1;

            btnSendEmail.Visible = false;

            string _searchString = "";

            if (txtOCode.Text.Trim().Length == 0)
            {
                lstResult.Items.Clear();               
                return;
            }

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

            _comm.CommandText = "SELECT LTRIM(RTRIM(O_CODE)) + ' - ' + O_DESC 'DESC' FROM OCCUPATION WHERE O_CODE LIKE @V_O_CODE order by o_code";
            _comm.Parameters.Clear();
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

            lblMsg.Text = "";
            Update();
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

                this.TopMost = true;

                // Show pay period
                lblPayPeriod.Text = GetPP(dateTimePicker1.Value.ToString("yyyy-MM-dd"));

                // hide notify icon
                myNotifyIcon.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lstResult_DoubleClick(object sender, EventArgs e)
        {
            if (lstResult.SelectedIndex != -1)
            {
                if (_searchMode == 1) Clipboard.SetText(lstResult.Items[lstResult.SelectedIndex].ToString().Trim());
                else Clipboard.SetText(lstResult.Items[lstResult.SelectedIndex].ToString().Trim().Substring(15));
                lblMsg.Text = "Copied to clipboard";
                timer1.Enabled = true;
            }
        }

        private void txtEmpNo_TextChanged(object sender, EventArgs e)
        {
            _searchMode = 2;

            string _searchString = "";
            bool _searchEmpNo = false;

            if (txtEmpNo.Text.Trim().Length == 0)
            {
                lstResult.Items.Clear();
                btnSendEmail.Visible = false;
                return;
            }

            if ("0123456789".IndexOf(txtEmpNo.Text.Trim()[0]) != -1)
            {
                _searchString = txtEmpNo.Text.Trim().PadLeft(8, '0');
                _searchEmpNo = true;
            }
            else
            {
                _searchString = txtEmpNo.Text.Trim().ToUpper();
            }

            if (_searchEmpNo)
            {
                _comm.CommandText = "SELECT LTRIM(RTRIM(E_EMPNBR)) + '  -  ' + LTRIM(RTRIM(E_LASTNAME)) + ', ' + LTRIM(RTRIM(E_FIRSTNAME)) 'DESC' FROM EMP WHERE E_EMPNBR LIKE @V_SEARCH AND LEN(E_EMPNBR) > 7 ORDER BY E_LASTNAME, E_FIRSTNAME";
            }
            else // SEARCH BY LAST NAME
            {
                _comm.CommandText = "SELECT LTRIM(RTRIM(E_EMPNBR)) + '  -  ' + LTRIM(RTRIM(E_LASTNAME)) + ', ' + LTRIM(RTRIM(E_FIRSTNAME)) 'DESC' FROM EMP WHERE UPPER(E_LASTNAME) LIKE @V_SEARCH AND LEN(E_EMPNBR) > 7 ORDER BY E_LASTNAME, E_FIRSTNAME";
            }

            lblMsg.Text = "Please wait...";
            Update();

            _comm.Parameters.Clear();
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

            lblMsg.Text = "";
            Update();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            timer1.Enabled = false;
        }

        private void frmSearch_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                myNotifyIcon.Visible = true;
                myNotifyIcon.ShowBalloonTip(500);
                this.ShowInTaskbar = false;
            }
        }


        private void myNotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            myNotifyIcon.Visible = false;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            lblPayPeriod.Text = GetPP(dateTimePicker1.Value.ToString("yyyy-MM-dd"));
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string _tcg = "", _ssoEMail = "";

            if (lstResult.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an employee first.");
                return;
            }

            _tcg = GetTCG(lstResult.SelectedItem.ToString().Substring(0, 8));
            if (_tcg == "")
            {
                MessageBox.Show("Sorry, the EE may no longer be active.");
                return;
            }

            _ssoEMail = GetSSOEmail(_tcg);

            if (_ssoEMail == "")
            {
                MessageBox.Show("Sorry, the EE is NFP.");
                return;
            }

            StringBuilder _sb = new StringBuilder();

            _sb.Append("mailto:" + _ssoEMail);
            _sb.Append("&subject=" + _tcg.Replace("&","%26") + " - " + lstResult.SelectedItem.ToString());
            System.Diagnostics.Process.Start(_sb.ToString());

        }

        private string GetSSOEmail(string _tcg)
        {
            string _ret = "";

            switch (_tcg.Substring(0,2)) {
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

        private void lstResult_Click(object sender, EventArgs e)
        {
            if (lstResult.SelectedIndex != -1 && _searchMode == 2)
            {
                btnSendEmail.Visible = true;
            }
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

        private string GetPosition(string _code)
        {
            string _ret = "";

            _comm.CommandText = "SELECT LTRIM(RTRIM(O_CODE)) + ' - ' + O_DESC 'DESC' FROM OCCUPATION WHERE O_CODE LIKE @V_O_CODE order by o_code";
            _comm.Parameters.Clear();
            _comm.Parameters.Add(new SqlParameter("V_O_CODE", _code.Trim().ToUpper() + "%"));
            SqlDataReader _reader = _comm.ExecuteReader();
            if (_reader.HasRows)
            {
                _reader.Read();
                _ret = _reader["DESC"].ToString();
            }
            else
            {
                _ret = _code;
            }
            if (_reader.IsClosed != true) _reader.Close();
            _reader.Dispose();

            return _ret;
        }

        private string GetEmpName(string _empID)
        {
            string _ret = "";

            _comm.CommandText = "SELECT LTRIM(RTRIM(E_LASTNAME)) + ', ' + LTRIM(RTRIM(E_FIRSTNAME)) 'EMPNAME' FROM EMP WHERE E_EMPNBR LIKE @V_SEARCH AND LEN(E_EMPNBR) > 7 ORDER BY E_LASTNAME, E_FIRSTNAME";

            _comm.Parameters.Clear();
            _comm.Parameters.Add(new SqlParameter("V_SEARCH", _empID + "%"));
            SqlDataReader _reader = _comm.ExecuteReader();
            if (_reader.HasRows)
            {
                _reader.Read();
                _ret = _reader["EMPNAME"].ToString();
            }

            _reader.Close();
            _reader.Dispose();

            return _ret;
        }

        private void btnFile2_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Title = "Please select the File 2 CSV File";
                openFileDialog1.Filter = "CSV Files (.csv)|*.csv|All Files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;

                bool userClickedOK = openFileDialog1.ShowDialog() == DialogResult.OK;

                if (!userClickedOK) return;

                btnFile2.Text = "Processing...";
                this.Cursor = Cursors.WaitCursor;
                Update();

                // Set the file name and get the output directory
                var fileName = "Example.xlsx";
                var outputDir = Application.StartupPath;

                // Create the file using the FileInfo object
                var file = new FileInfo(outputDir + @"\" + fileName);

                using (var package = new ExcelPackage())
                {
                    // add a new worksheet to the empty workbook
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(openFileDialog1.SafeFileName);

                    // Set Page Settings
                    worksheet.PrinterSettings.Orientation = eOrientation.Landscape;
                    worksheet.PrinterSettings.ShowGridLines = true;
                    worksheet.PrinterSettings.HorizontalCentered = true;
                    worksheet.PrinterSettings.TopMargin = (decimal)1.5 / 2.54M;
                    worksheet.PrinterSettings.BottomMargin = (decimal)1.5 / 2.54M;
                    worksheet.PrinterSettings.LeftMargin = (decimal)0.25 / 2.54M;
                    worksheet.PrinterSettings.RightMargin = (decimal)0.25 / 2.54M;
                    worksheet.PrinterSettings.HeaderMargin = (decimal)0.5 / 2.54M;
                    worksheet.PrinterSettings.FooterMargin = (decimal)0.5 / 2.54M;
                    worksheet.HeaderFooter.OddHeader.LeftAlignedText = DateTime.Now.ToString("ddMMMyyyy");
                    worksheet.HeaderFooter.OddHeader.RightAlignedText = GetPP(DateTime.Now.ToString("ddMMMyyyy"));
                    worksheet.HeaderFooter.OddHeader.CenteredText = "Positions Report";
                    worksheet.HeaderFooter.OddFooter.RightAlignedText = string.Format("Page {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
                    worksheet.View.PageBreakView = true;
                    worksheet.PrinterSettings.RepeatRows = new ExcelAddress("$1:$1");


                    //Setting Header Style
                    //worksheet.Row(1).Height = 42;
                    //worksheet.Column(1).Width = 3.29;
                    worksheet.Cells[1, 2].Value = "EE ID #"; worksheet.Cells[1, 2].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    worksheet.Cells[1, 3].Value = "POS"; worksheet.Cells[1, 3].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    worksheet.Cells[1, 4].Value = "Prim"; worksheet.Cells[1, 4].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    worksheet.Cells[1, 5].Value = "Start Date"; worksheet.Cells[1, 5].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    worksheet.Cells[1, 6].Value = "End Date"; worksheet.Cells[1, 6].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    worksheet.Cells[1, 7].Value = "Unit"; worksheet.Cells[1, 7].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    worksheet.Cells[1, 8].Value = "Occ"; worksheet.Cells[1, 8].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    worksheet.Cells[1, 9].Value = "Stat"; worksheet.Cells[1, 9].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    worksheet.Cells[1, 10].Value = "FTE"; worksheet.Cells[1, 10].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    worksheet.Cells[1, 11].Value = "Comments"; worksheet.Cells[1, 11].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    var range = worksheet.Cells[1, 1, 1, 11];
                    range.Style.Font.Bold = true;
                    range.Style.Font.Size = 12;
                    range.Style.Font.Name = "Arial";

                    string[] lines = System.IO.File.ReadAllLines(openFileDialog1.FileName);

                    int lineCtr = 2;

                    bool firstEmp = true;
                    string currEmp = "", currUnit = "", currOcc = "", currStat = "", currFTE = "";
                    bool switchColor = true, ThersAChange = false;

                    foreach (string line in lines)
                    {
                        string[] values = line.Split(',');
                        if (values.Count() == 38)
                        {
                            if (firstEmp)
                            {
                                firstEmp = false;
                                currEmp = values[1]; currUnit = values[20]; currOcc = values[21]; currStat = values[22]; currFTE = values[23];
                            }
                            else
                            {
                                if (currEmp != values[1]) // change in empno
                                {
                                    currEmp = values[1]; currUnit = values[20]; currOcc = values[21]; currStat = values[22]; currFTE = values[23];
                                    ThersAChange = false;
                                    switchColor = !switchColor;
                                }
                            }

                            if (currUnit != values[20])
                            {
                                worksheet.Cells[lineCtr - 1, 11].Value = GetEmpName(values[1].Substring(0, 8));
                                worksheet.Cells[lineCtr, 7].Style.Font.Bold = true;
                                currUnit = values[20];
                                ThersAChange = true;
                            }
                            if (currOcc != values[21])
                            {
                                if (!ThersAChange) worksheet.Cells[lineCtr - 1, 11].Value = GetEmpName(values[1].Substring(0, 8));
                                worksheet.Cells[lineCtr, 8].Style.Font.Bold = true;
                                currOcc = values[21];
                                ThersAChange = true;
                            }
                            if (currStat != values[22])
                            {
                                if (!ThersAChange) worksheet.Cells[lineCtr - 1, 11].Value = "Status";
                                worksheet.Cells[lineCtr, 9].Style.Font.Bold = true;
                                currStat = values[22];
                                if (currFTE != values[23])
                                {
                                    if (!ThersAChange) worksheet.Cells[lineCtr - 1, 11].Value = "Status / FTE";
                                    worksheet.Cells[lineCtr, 10].Style.Font.Bold = true;
                                    currFTE = values[23];
                                }
                                ThersAChange = true;
                            }
                            if (currFTE != values[23])
                            {
                                if (!ThersAChange) worksheet.Cells[lineCtr - 1, 11].Value = "FTE";
                                worksheet.Cells[lineCtr, 10].Style.Font.Bold = true;
                                currFTE = values[23];
                                ThersAChange = true;
                            }

                            worksheet.Row(lineCtr).Height = 25;
                            worksheet.Row(lineCtr).Style.Font.Size = 12;
                            worksheet.Row(lineCtr).Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                            worksheet.Cells[lineCtr, 1].Value = values[0]; worksheet.Cells[lineCtr, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            worksheet.Cells[lineCtr, 2].Value = values[1]; worksheet.Cells[lineCtr, 2].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            worksheet.Cells[lineCtr, 3].Value = values[15]; worksheet.Cells[lineCtr, 3].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            worksheet.Cells[lineCtr, 4].Value = values[16]; worksheet.Cells[lineCtr, 4].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            worksheet.Cells[lineCtr, 5].Value = DateTime.ParseExact(values[17].PadLeft(8, '0'), "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("ddMMMyy"); worksheet.Cells[lineCtr, 5].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            worksheet.Cells[lineCtr, 6].Value = values[18] != "" ? DateTime.ParseExact(values[18].PadLeft(8, '0'), "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("ddMMMyy") : ""; worksheet.Cells[lineCtr, 6].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            worksheet.Cells[lineCtr, 7].Value = values[20]; worksheet.Cells[lineCtr, 7].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            worksheet.Cells[lineCtr, 8].Value = GetPosition(values[21]); worksheet.Cells[lineCtr, 8].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            worksheet.Cells[lineCtr, 9].Value = values[22]; worksheet.Cells[lineCtr, 9].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            worksheet.Cells[lineCtr, 10].Value = Convert.ToDecimal(values[23]).ToString("0.00"); worksheet.Cells[lineCtr, 10].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            worksheet.Cells[lineCtr, 11].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            range = worksheet.Cells[lineCtr, 1, lineCtr, 11];
                            range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            range.Style.Fill.BackgroundColor.SetColor(switchColor ? Color.White : Color.FromArgb(191, 191, 191));

                            //worksheet.Row(lineCtr).Style.Fill.BackgroundColor.SetColor(switchColor ? Color.White : Color.Gray);


                            //worksheet.Cells[lineCtr, 3].Value = DateTime.ParseExact(values[18].PadLeft(8, '0'), "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("ddMMMyyyy");
                            //worksheet.Cells[lineCtr, 4].Value = GetEmpName(values[1].Substring(0, 8));
                            lineCtr++;
                        }
                    }

                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    saveFileDialog1.FilterIndex = 1;
                    saveFileDialog1.FileName = "Positions " + DateTime.Now.ToString("ddMMMyy");
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        package.SaveAs(new FileInfo(saveFileDialog1.FileName));
                        System.Diagnostics.Process.Start(saveFileDialog1.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnFile2.Text = "Process File 2";
                this.Cursor = Cursors.Default;
            }
        }

        private void btnFile6_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Title = "Please select the File 6 CSV File";
                openFileDialog1.Filter = "CSV Files (.csv)|*.csv|All Files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;

                bool userClickedOK = openFileDialog1.ShowDialog() == DialogResult.OK;

                if (!userClickedOK) return;
                btnFile6.Text = "Processing...";
                this.Cursor = Cursors.WaitCursor;
                Update();

                // Set the file name and get the output directory
                var fileName = "Example.xlsx";
                var outputDir = Application.StartupPath;

                // Create the file using the FileInfo object
                var file = new FileInfo(outputDir + @"\" + fileName);

                using (var package = new ExcelPackage())
                {
                    // add a new worksheet to the empty workbook
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(openFileDialog1.SafeFileName);

                    // Set Page Settings
                    worksheet.PrinterSettings.Orientation = eOrientation.Landscape;
                    worksheet.PrinterSettings.ShowGridLines = true;
                    worksheet.PrinterSettings.HorizontalCentered = true;
                    worksheet.PrinterSettings.TopMargin = (decimal)1.5 / 2.54M;
                    worksheet.PrinterSettings.BottomMargin = (decimal)1.5 / 2.54M;
                    worksheet.PrinterSettings.LeftMargin = (decimal)1 / 2.54M;
                    worksheet.PrinterSettings.RightMargin = (decimal)1 / 2.54M;
                    worksheet.PrinterSettings.HeaderMargin = (decimal)0.5 / 2.54M;
                    worksheet.PrinterSettings.FooterMargin = (decimal)0.5 / 2.54M;
                    worksheet.HeaderFooter.OddHeader.LeftAlignedText = DateTime.Now.ToString("ddMMMyyyy");
                    worksheet.HeaderFooter.OddHeader.RightAlignedText = GetPP(DateTime.Now.ToString("ddMMMyyyy"));
                    worksheet.HeaderFooter.OddHeader.CenteredText = "Terms and Trans From File 6";
                    worksheet.View.PageBreakView = true;
                    //worksheet.PrinterSettings.RepeatRows = new ExcelAddress("$2:$2");

                    //Setting Header Style
                    worksheet.Row(1).Height = 42;
                    worksheet.Column(1).Width = 3.29;
                    worksheet.Cells[1, 2].Value = "EE ID #"; worksheet.Column(2).Width = 12.30;
                    worksheet.Cells[1, 3].Value = "Eff Date"; worksheet.Column(3).Width = 10.43; //worksheet.Column(3).AutoFit(); //
                    worksheet.Cells[1, 4].Value = "EE Name"; worksheet.Column(4).Width = 22;
                    worksheet.Cells[1, 5].Value = "Transfer From"; worksheet.Column(5).Width = 35;
                    worksheet.Cells[1, 6].Value = "Transfer To"; worksheet.Column(6).Width = 35;
                    worksheet.Cells[1, 7].Value = "WFC License"; worksheet.Column(7).Width = 9.86; worksheet.Cells[1, 7].Style.WrapText = true;
                    worksheet.Cells[1, 8].Value = "Comments"; worksheet.Column(8).Width = 15;
                    var range = worksheet.Cells[1, 1, 1, 8];
                    range.Style.Font.Bold = true;
                    range.Style.Font.Size = 12;
                    range.Style.Font.Name = "Arial";

                    string[] lines = System.IO.File.ReadAllLines(openFileDialog1.FileName);

                    int lineCtr = 2;

                    foreach (string line in lines)
                    {
                        string[] values = line.Split(',');
                        if (values.Count() == 38)
                        {
                            if (values[16].Trim() == "0") // only with values "0"
                            {
                                worksheet.Row(lineCtr).Height = 25;
                                worksheet.Row(lineCtr).Style.Font.Size = 12;
                                worksheet.Row(lineCtr).Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                                worksheet.Cells[lineCtr, 1].Value = values[0];
                                worksheet.Cells[lineCtr, 2].Value = values[1];
                                worksheet.Cells[lineCtr, 3].Value = DateTime.ParseExact(values[18].PadLeft(8, '0'), "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("ddMMMyyyy");
                                worksheet.Cells[lineCtr, 4].Value = GetEmpName(values[1].Substring(0, 8));
                                lineCtr++;
                            }
                        }
                    }

                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    saveFileDialog1.FilterIndex = 1;
                    saveFileDialog1.FileName = "File 6 - " + DateTime.Now.ToString("ddMMMyy");
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        package.SaveAs(new FileInfo(saveFileDialog1.FileName));
                        System.Diagnostics.Process.Start(saveFileDialog1.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnFile6.Text = "Process File 6";
                this.Cursor = Cursors.Default;
            }
        }

        public void Convert(String filesFolder)
        {
            //files = Directory.GetFiles(filesFolder);

            //var app = new Microsoft.Office.Interop.Excel.Application();
            //var wb = app.Workbooks.Open(file);
            //wb.SaveAs(Filename: file + "x", FileFormat: Microsoft.Office.Interop.Excel.XlFileFormat.);
            //wb.Close();
            //app.Quit();
        }

        private void btnPrior_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Title = "Please Prior Pay Period Excel File";
                openFileDialog1.Filter = "Excel File (*.xls)|*.xls|All Files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;

                bool userClickedOK = openFileDialog1.ShowDialog() == DialogResult.OK;

                if (!userClickedOK) return;
                btnPrior.Text = "Processing...";
                this.Cursor = Cursors.WaitCursor;
                Update();

                //var app = new Microsoft.Office.Interop.Excel.Application();
                //var wb = app.Workbooks.Open(openFileDialog1.FileName);
                //wb.SaveAs(Filename: openFileDialog1.FileName + "x", FileFormat: Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel7);
                //wb.Close();
                //app.Quit();

                //MemoryStream ms = new MemoryStream();
                //using (FileStream fs = File.OpenRead(openFileDialog1.FileName))
                //using (ExcelPackage package = new ExcelPackage(fs))
                using (ExcelPackage package = new ExcelPackage(new FileInfo(openFileDialog1.FileName)))
                {
                    ExcelWorkbook workBook = package.Workbook;
                    ExcelWorksheet currentWorksheet = workBook.Worksheets.First();

                    int totalRows = currentWorksheet.Dimension.End.Row;
                    int totalCols = currentWorksheet.Dimension.End.Column;

                    for (int i = 2; i <= totalRows; i++)
                    {
                        try
                        {
                            currentWorksheet.Cells[i, 1].Value = "AAA";

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            return;
                        }
                    }

                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    saveFileDialog1.FilterIndex = 1;
                    saveFileDialog1.FileName = "Report - Pay Period Adjustments " + DateTime.Now.ToString("dd-MMM-yyyy");
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        package.SaveAs(new FileInfo(saveFileDialog1.FileName));
                        System.Diagnostics.Process.Start(saveFileDialog1.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnPrior.Text = "Process Prior File";
                this.Cursor = Cursors.Default;
            }
        }
    }
}
