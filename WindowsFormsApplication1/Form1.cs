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
using ExcelLibrary.SpreadSheet;
using VisualEffects.Animations.Effects;
using VisualEffects;
using VisualEffects.Easing;

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

        private void OpenConnection()
        {
            if (_conn.State == ConnectionState.Open) _conn.Close();
            _conn.Open();
            _comm = _conn.CreateCommand();
        }

        private void CloseConnection()
        {
            if (_conn.State == ConnectionState.Open)
            {
                if (_comm != null)
                {
                    _comm.Dispose();
                    _comm = null;
                }
                _conn.Close();
            }
        }

        private string GetPP(string _date)
        {
            try
            {
                string _ret = "";

                OpenConnection();
                _comm.CommandText = "select PP_NBR from payperiod where @V_DATE between pp_startdate and pp_enddate";
                _comm.Parameters.Add(new SqlParameter("V_DATE", _date));
                SqlDataReader _reader = _comm.ExecuteReader();
                _reader.Read();
                _ret = _reader["PP_NBR"].ToString();
                if (_reader.IsClosed != true) _reader.Close();
                CloseConnection();

                return _ret != "" ? _ret.PadLeft(2, '0') : _ret;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR:" + ex.Message);
                return "";
            }
        }

        private string GetPrevious_PP(string _date)
        {
            string _ret = "";

            OpenConnection();
            _comm.CommandText = "Select PP_NBR from payperiod where pp_startdate = ( " +
                                "select MAX(pp_startdate) AS PP_NBR from payperiod where pp_startdate < " +
                                "(select pp_startdate from payperiod where @V_DATE between pp_startdate and pp_enddate))";
            _comm.Parameters.Add(new SqlParameter("V_DATE", _date));
            SqlDataReader _reader = _comm.ExecuteReader();
            _reader.Read();
            _ret = _reader["PP_NBR"].ToString();
            if (_reader.IsClosed != true) _reader.Close();
            CloseConnection();

            return _ret != "" ? _ret.PadLeft(2, '0') : _ret;
        }

        private string GetPrevious_PPRange(string _date)
        {
            string _ret = "";

            OpenConnection();
            _comm.CommandText = "select FORMAT(max(pp_startdate),'ddMMMyy') +  ' - ' + FORMAT(MAX(PP_ENDDATE),'ddMMMyy') " +
                                "as PayPeriod from payperiod where pp_startdate < " +
                                "(select pp_startdate from payperiod where @V_DATE between pp_startdate and pp_enddate)";
            _comm.Parameters.Add(new SqlParameter("V_DATE", _date));
            SqlDataReader _reader = _comm.ExecuteReader();
            _reader.Read();
            _ret = _reader["PayPeriod"].ToString();
            if (_reader.IsClosed != true) _reader.Close();
            CloseConnection();

            return _ret;
        }

        private string GetStartPP(string _date)
        {
            string _ret = "";

            OpenConnection();
            _comm.CommandText = "select Convert(varchar(10),PP_StartDate,23) as StartDate from payperiod where @V_DATE between pp_startdate and pp_enddate";
            _comm.Parameters.Add(new SqlParameter("V_DATE", _date));
            SqlDataReader _reader = _comm.ExecuteReader();
            _reader.Read();
            _ret = _reader["StartDate"].ToString();
            if (_reader.IsClosed != true) _reader.Close();
            CloseConnection();

            return _ret;
        }

        private void txtOCode_TextChanged(object sender, EventArgs e)
        {
            _searchMode = 1;

            btnSendEmail.Visible = txtTCG.Visible = false;

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

            OpenConnection();
            _comm.CommandText = "SELECT LTRIM(RTRIM(O_CODE)) + ' - ' + O_DESC 'DESC' FROM OCCUPATION WHERE O_CODE LIKE @V_O_CODE order by o_code";
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
            CloseConnection();

            lblMsg.Text = "";
            Update();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                _conn.ConnectionString = @"Server=" + SearchMethods.dbServer + "; Initial Catalog=esp_cal_prod;Integrated Security=SSPI;";

                TopMost = true;

                // Show pay period
                lblPayPeriod.Text = "Pay Period: " + GetPP(dateTimePicker1.Value.ToString("yyyy-MM-dd"));

                // hide notify icon
                myNotifyIcon.Visible = false;

                //enable trigger of closing the application at early morning
                timerClose.Enabled = true;

                Height = 0;
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
                if (_searchMode == 1)
                {
                    Clipboard.SetText(lstResult.Items[lstResult.SelectedIndex].ToString().Trim());
                    // else Clipboard.SetText(lstResult.Items[lstResult.SelectedIndex].ToString().Trim().Substring(15));
                    lblMsg.Text = "Copied to clipboard !";
                    timer1.Enabled = true;
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

            OpenConnection();
            if (_searchEmpNo) // SEARCH BY EMP NO
            {
                _comm.CommandText = "SELECT LTRIM(RTRIM(E_EMPNBR)) + '  -  ' + LTRIM(RTRIM(E_LASTNAME)) + ', ' + LTRIM(RTRIM(E_FIRSTNAME)) 'DESC' FROM EMP WHERE E_EMPNBR LIKE @V_SEARCH AND LEN(E_EMPNBR) > 7 ORDER BY E_LASTNAME, E_FIRSTNAME";
            }
            else // SEARCH BY LAST NAME
            {
                _comm.CommandText = "SELECT LTRIM(RTRIM(E_EMPNBR)) + '  -  ' + LTRIM(RTRIM(E_LASTNAME)) + ', ' + LTRIM(RTRIM(E_FIRSTNAME)) 'DESC' FROM EMP WHERE UPPER(E_LASTNAME) LIKE @V_SEARCH AND LEN(E_EMPNBR) > 7 ORDER BY E_LASTNAME, E_FIRSTNAME";
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

            CloseConnection();

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
            string _ret = GetPP(dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            if (_ret != "") 
                lblPayPeriod.Text = "Pay Period: " + _ret;
            else
            {
                dateTimePicker1.Value = DateTime.Today;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string _tcg = "", _ssoEMail = "";

            if (lstResult.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an employee first.");
                return;
            }

            _tcg = GetTCG(lstResult.SelectedItem.ToString().Substring(0, 10));
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
            _sb.Append("&subject=" + _tcg.Replace("&", "%26") + " - " + lstResult.SelectedItem.ToString());
            System.Diagnostics.Process.Start(_sb.ToString());

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

        private void lstResult_Click(object sender, EventArgs e)
        {
            if (lstResult.SelectedIndex != -1 && _searchMode == 2)
            {
                btnSendEmail.Visible = txtTCG.Visible = true;
                string _tcg = GetTCG(lstResult.SelectedItem.ToString().Substring(0, 10));
                txtTCG.Text = _tcg == "" ? "--- INACTIVE ---" : "Timecard Group: " + _tcg;
            }
        }

        private string GetTCG(string _empID)
        {
            string _ret = "";

            OpenConnection();
            _comm.CommandText = "select emp.e_empid EMPID from emp " +
                 "inner join empPosition on emp.e_empid = empPosition.ep_empid " +
                 "inner join employmentStatus on emp.e_empid = employmentStatus.EMS_EmpID " +
                 "where emp.e_empnbr = @V_SEARCH and empPosition.ep_todate >= GetDAte() " +
                 "AND EmploymentStatus.EMS_EmploymentType = 1 AND EmploymentStatus.EMS_EndDate >= GetDAte() ";

            _comm.Parameters.Add(new SqlParameter("V_SEARCH", _empID));
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
            CloseConnection();

            return _ret;
        }

        private string GetPosition(string _code)
        {
            string _ret = "";

            OpenConnection();
            _comm.CommandText = "SELECT LTRIM(RTRIM(O_CODE)) + ' - ' + O_DESC 'DESC' FROM OCCUPATION WHERE O_CODE LIKE @V_O_CODE order by o_code, O_DESC DESC";
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

            CloseConnection();

            return _ret;
        }

        private string GetEmpName(string _empID)
        {
            string _ret = "";

            OpenConnection();
            _comm.CommandText = "SELECT LTRIM(RTRIM(E_LASTNAME)) + ', ' + LTRIM(RTRIM(E_FIRSTNAME)) 'EMPNAME' FROM EMP WHERE E_EMPNBR LIKE @V_SEARCH AND LEN(E_EMPNBR) > 7 ORDER BY E_ChangeDate DESC";

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

            CloseConnection();

            return _ret;
        }

        private void btnFile2_Click(object sender, EventArgs e)
        {          

            TopMost = false;

            frmUploadItems _frm = new frmUploadItems();            
            _frm.ShowDialog();
            UploadItemsParams _uploadParams = _frm.attr;
            _frm.Dispose();

            TopMost = true;

            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Title = "Please select the File 2 CSV File";
                openFileDialog1.Filter = "CSV Files (.csv)|*.csv|All Files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;

                bool userClickedOK = openFileDialog1.ShowDialog() == DialogResult.OK;

                if (!userClickedOK) return;

                btnFile2.Text = "Processing...";
                Cursor.Current = Cursors.WaitCursor;
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
                    worksheet.HeaderFooter.OddHeader.RightAlignedText = "Pay Period: " + GetPP(DateTime.Now.ToString("ddMMMyyyy"));
                    worksheet.HeaderFooter.OddHeader.CenteredText = "Positions Report";
                    worksheet.HeaderFooter.OddFooter.RightAlignedText = string.Format("Page {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
                    worksheet.View.PageBreakView = true;
                    worksheet.PrinterSettings.RepeatRows = new ExcelAddress("$1:$1");
                    worksheet.PrinterSettings.FitToPage = true; worksheet.PrinterSettings.FitToWidth = 1; worksheet.PrinterSettings.FitToHeight = 0;


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
                    string currEmp = "", currUnit = "", currOcc = "", currStat = "", currFTE = "", prevUnit = "", prevOcc = "";
                    bool switchColor = true, ThersAChange = false;

                    bool changeInUnit = false, changeInOcc = false;

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
                                    currEmp = values[1]; currUnit = prevUnit = values[20]; currOcc = prevOcc = values[21]; currStat = values[22]; currFTE = values[23]; // reset the base values
                                    ThersAChange = false; //reset the flags
                                    switchColor = !switchColor;
                                }
                            }
                            if (currUnit != values[20]) // change in unit
                            {
                                worksheet.Cells[lineCtr - 1, 11].Value = GetEmpName(values[1].Substring(0, 8));
                                worksheet.Cells[lineCtr, 7].Style.Font.Bold = true;
                                prevUnit = currUnit;
                                currUnit = values[20];
                                ThersAChange = changeInUnit = true;
                            }
                            if (currOcc != values[21]) // change in occupation
                            {
                                if (!ThersAChange) worksheet.Cells[lineCtr - 1, 11].Value = GetEmpName(values[1].Substring(0, 8));
                                worksheet.Cells[lineCtr, 8].Style.Font.Bold = true;
                                prevOcc = currOcc;
                                currOcc = values[21];
                                ThersAChange = changeInOcc = true;
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

                            #region AutoInsertInItemsReport                          
                            if (_uploadParams.uploadToItems)
                            {
                                if (changeInUnit)
                                {
                                    if (InsertInItems(new ChangeInUnitAndOrOcc
                                    {
                                        empNo = values[1].Trim(),
                                        prevUnit = prevUnit.Trim(),
                                        currUnit = currUnit.Trim(),
                                        prevPosCode = changeInOcc ? prevOcc : values[21].Trim(),
                                        currPosCode = values[21].Trim(),
                                        stat = values[22].Trim(),
                                        pp = _uploadParams.pp,
                                        ppYear = _uploadParams.ppYear,
                                        itemsReportLetter = _uploadParams.itemsReportLetter
                                    }))
                                    {
                                        values[0] = values[0] + "  ©";
                                    };
                                }
                                else if (!changeInUnit && changeInOcc)
                                {
                                    if (InsertInItems(new ChangeInOcc
                                    {
                                        empNo = values[1].Trim(),
                                        unit = currUnit.Trim(),
                                        prevPosCode = prevOcc,
                                        currPosCode = currOcc,
                                        pp = _uploadParams.pp,
                                        ppYear = _uploadParams.ppYear,
                                        itemsReportLetter = _uploadParams.itemsReportLetter
                                    }))
                                    {
                                        values[0] = values[0] + "  ©";
                                    };
                                }
                            }

                            changeInUnit = changeInOcc = false;
                            #endregion

                            worksheet.Row(lineCtr).Height = 25;
                            worksheet.Row(lineCtr).Style.Font.Size = 12;
                            worksheet.Row(lineCtr).Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                            worksheet.Cells[lineCtr, 1].Value = values[0]; worksheet.Cells[lineCtr, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            worksheet.Cells[lineCtr, 2].Value = values[1]; worksheet.Cells[lineCtr, 2].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            worksheet.Cells[lineCtr, 3].Value = values[15]; worksheet.Cells[lineCtr, 3].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            worksheet.Cells[lineCtr, 4].Value = values[16]; worksheet.Cells[lineCtr, 4].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            worksheet.Cells[lineCtr, 5].Value = values[17].Trim() != "" ? DateTime.ParseExact(values[17].PadLeft(8, '0'), "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("ddMMMyy") : ""; worksheet.Cells[lineCtr, 5].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            worksheet.Cells[lineCtr, 6].Value = values[18].Trim() != "" ? DateTime.ParseExact(values[18].PadLeft(8, '0'), "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("ddMMMyy") : ""; worksheet.Cells[lineCtr, 6].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
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
                btnFile2.Text = "Format File 2";
                Cursor.Current = Cursors.Default;
            }
        }

        private bool InsertInItems(ChangeInOcc _data)
        {
            if (GetSiteNum_ShortDesc(_data.unit) == -1) return false; // the unit is not existing

            bool _ret;

            try
            {
                using (SqlConnection myConnection = new SqlConnection())
                {
                    myConnection.ConnectionString = Common.SystemsServer; //@"Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=" + Application.StartupPath + @"\items.mdb;Uid=Admin;Pwd=;";
                    myConnection.Open();

                    SqlCommand myCommand = myConnection.CreateCommand();

                    myCommand.CommandText = "Insert into ItemsRpt_OccupationChange (ItemsReportLetter, PayPeriod, PayPeriod_Year, Site, Emp_Num, Emp_Name, Unit, OccFrom, OccTo, Comments, EnteredBy) values " +
                        "(@_ItemsReportLetter, @_PayPeriod, @_PayPeriod_Year, @_Site, @_Emp_Num, @_Emp_Name, @_Unit, @_OccFrom, @_OccTo, @_Comments, @_EnteredBy)";
                   

                    myCommand.Parameters.AddWithValue("_ItemsReportLetter", _data.itemsReportLetter);
                    myCommand.Parameters.AddWithValue("_PayPeriod", _data.pp);
                    myCommand.Parameters.AddWithValue("_PayPeriod_Year", _data.ppYear);
                    myCommand.Parameters.AddWithValue("_Site", (GetSiteNum_ShortDesc(_data.unit) + 1));
                    myCommand.Parameters.AddWithValue("_Emp_Num", _data.empNo);
                    myCommand.Parameters.AddWithValue("_Emp_Name", GetEmpName(_data.empNo.Substring(0, 8)));
                    myCommand.Parameters.AddWithValue("_Unit", _data.unit);
                    myCommand.Parameters.AddWithValue("_OccFrom", GetPosition(_data.prevPosCode));
                    myCommand.Parameters.AddWithValue("_OccTo", GetPosition(_data.currPosCode));
                    myCommand.Parameters.AddWithValue("_Comments", "");
                    myCommand.Parameters.AddWithValue("_EnteredBy", "AutoSystem");

                    myCommand.ExecuteNonQuery();
                    myCommand.Dispose();

                    _ret = true;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Auto Inserting 'Change in Occupation' [" + _data.empNo + "]: " + ex.Message, "ERROR");
                _ret = false;
            }

            return _ret;
        }

        private int GetSiteNum_ShortDesc(string _unitShortDesc)
        {
            int _ret = -1;
            try
            {
                using (SqlConnection myConnection = new SqlConnection())
                {
                    myConnection.ConnectionString = Common.ESPServer;
                    myConnection.Open();

                    SqlCommand myCommand = myConnection.CreateCommand();

                    myCommand.CommandText = "select Substring(U_Desc,1,2) AS U_PREFIX from unit where UPPER(U_ShortDesc) = UPPER(@_ShortDesc)";
                    myCommand.Parameters.AddWithValue("_ShortDesc", _unitShortDesc);

                    SqlDataReader myReader = myCommand.ExecuteReader();

                    if (myReader.HasRows)
                    {
                        myReader.Read();
                        if (myReader["U_PREFIX"].ToString() == "S2")
                        {
                            _ret = 5;
                        }
                        else
                        {
                            _ret = Convert.ToInt16(myReader["U_PREFIX"]) - 1;
                        }
                        if (_ret > 5) // invalid site number
                        {
                            _ret = -1;
                        }
                    }
                    myCommand.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ooops, there's an error (GetSiteNum_ShortDesc): " + ex.Message, "ERROR");
            }            

            return _ret;
        }

        private bool InsertInItems(ChangeInUnitAndOrOcc _data)
        {
            if (GetSiteNum_ShortDesc(_data.prevUnit) == -1) return false;

            bool _ret = false;

            try
            {
                using (SqlConnection myConnection = new SqlConnection())
                {
                    myConnection.ConnectionString = Common.SystemsServer; //@"Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=" + Application.StartupPath + @"\items.mdb;Uid=Admin;Pwd=;";
                    myConnection.Open();

                    SqlCommand myCommand = myConnection.CreateCommand();

                    myCommand.CommandText = "Insert into ItemsRpt_UnitToUnitTransfer (ItemsReportLetter, PayPeriod, PayPeriod_Year, Site, Emp_Num, Emp_Name, UnitFrom, UnitTo, Occupation, Status, ChangeInOccupation, ChangeInSite, Comments, EnteredBy) values " +
                            "(@_ItemsReportLetter, @_PayPeriod, @_PayPeriod_Year, @_Site, @_Emp_Num, @_Emp_Name, @_UnitFrom, @_UnitTo, @_Occupation, @_Status, @_ChangeInOccupation, @_ChangeInSite, @_Comments, @_EnteredBy)";
                    
                    myCommand.Parameters.AddWithValue("_ItemsReportLetter", _data.itemsReportLetter);
                    myCommand.Parameters.AddWithValue("_PayPeriod", _data.pp);
                    myCommand.Parameters.AddWithValue("_PayPeriod_Year", _data.ppYear);
                    myCommand.Parameters.AddWithValue("_Site", (GetSiteNum_ShortDesc(_data.prevUnit)+1));
                    myCommand.Parameters.AddWithValue("_Emp_Num", _data.empNo);
                    myCommand.Parameters.AddWithValue("_Emp_Name", GetEmpName(_data.empNo.Substring(0,8)));
                    myCommand.Parameters.AddWithValue("_UnitFrom", _data.prevUnit);
                    myCommand.Parameters.AddWithValue("_UnitTo", _data.currUnit);
                    myCommand.Parameters.AddWithValue("_Occupation", GetPosition(_data.currPosCode));
                    myCommand.Parameters.AddWithValue("_Status", _data.stat);
                    myCommand.Parameters.AddWithValue("_ChangeInOccupation", (_data.prevPosCode != _data.currPosCode).ToString());
                    myCommand.Parameters.AddWithValue("_ChangeInSite", (GetSiteNum_ShortDesc(_data.prevUnit) != GetSiteNum_ShortDesc(_data.currUnit)).ToString());
                    myCommand.Parameters.AddWithValue("_Comments", "");
                    myCommand.Parameters.AddWithValue("_EnteredBy", "AutoSystem");

                    myCommand.ExecuteNonQuery();
                    myCommand.Dispose();

                    _ret = true;
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Auto Inserting 'Change in Site' [" + _data.empNo + "]: " + ex.Message, "ERROR");
                _ret = false;
            }

            return _ret;
        }

        private void btnFile6_Click(object sender, EventArgs e)
        {
            //string[] _temp;

            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Title = "Please select the File 6 CSV File";
                openFileDialog1.Filter = "CSV Files (.csv)|*.csv|All Files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;

                bool userClickedOK = openFileDialog1.ShowDialog() == DialogResult.OK;

                if (!userClickedOK) return;
                btnFile6.Text = "Processing...";
                Cursor.Current = Cursors.WaitCursor;
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
                    worksheet.HeaderFooter.OddHeader.RightAlignedText = "Pay Period: " + GetPP(DateTime.Now.ToString("ddMMMyyyy"));
                    worksheet.HeaderFooter.OddHeader.CenteredText = "Terms and Trans From File 6";
                    worksheet.View.PageBreakView = true;
                    worksheet.PrinterSettings.FitToPage = true; worksheet.PrinterSettings.FitToWidth = 1; worksheet.PrinterSettings.FitToHeight = 0;
                    worksheet.PrinterSettings.RepeatRows = new ExcelAddress("$1:$1");
                    worksheet.HeaderFooter.OddFooter.RightAlignedText = string.Format("Page {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);

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
                                worksheet.Cells[lineCtr, 3].Value = values[18] == "" ? "" : DateTime.ParseExact(values[18].PadLeft(8, '0'), "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("ddMMMyyyy");
                                worksheet.Cells[lineCtr, 4].Value = GetEmpName(values[1].Substring(0, 8));
                                lineCtr++;
                            }
                        }

                        //_temp = values;
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
                MessageBox.Show("ERROR IN PROCESSING FILE 6: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnFile6.Text = "Format File 6";
                Cursor.Current = Cursors.Default;
            }
        }       

        private void btnBanks_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Title = "Please select Off Code vs Bank Excel File";
                openFileDialog1.Filter = "Excel File (.xlsx)|*.xlsx|All Files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;

                bool userClickedOK = openFileDialog1.ShowDialog() == DialogResult.OK;

                if (!userClickedOK) return;
                btnBanks.Text = "Processing...";
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
                        ExcelWorksheet worksheet = package2.Workbook.Worksheets.Add("System - Off Code vs Bank Hours");

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
                        worksheet.HeaderFooter.OddHeader.LeftAlignedText = DateTime.Now.ToString("ddMMMyyyy");

                        string _currDate = DateTime.Today.ToString("yyyy-MM-dd");
                        string _payPeriod = "";
                        if (GetStartPP(_currDate) == _currDate)
                        {
                            _payPeriod = GetPP(DateTime.ParseExact(_currDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture).AddDays(-1).ToString("yyyy-MM-dd"));
                        }
                        else
                        {
                            _payPeriod = GetPP(_currDate);
                        }

                        worksheet.HeaderFooter.OddHeader.RightAlignedText = "Pay Period: " + _payPeriod;
                        worksheet.HeaderFooter.OddHeader.CenteredText = "Off Codes vs Bank Hours";
                        worksheet.HeaderFooter.OddFooter.RightAlignedText = string.Format("Page {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
                        worksheet.View.PageBreakView = true;
                        worksheet.PrinterSettings.FitToPage = true; worksheet.PrinterSettings.FitToWidth = 1; worksheet.PrinterSettings.FitToHeight = 0;
                        worksheet.PrinterSettings.RepeatRows = new ExcelAddress("$1:$1");

                        worksheet.Cells[1, 1].Value = "Site"; worksheet.Cells[1, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin); worksheet.Column(1).Width = 4.70;
                        worksheet.Cells[1, 2].Value = "Unit"; worksheet.Cells[1, 2].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin); worksheet.Column(2).Width = 36.30;
                        worksheet.Cells[1, 3].Value = "Name"; worksheet.Cells[1, 3].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin); worksheet.Column(3).Width = 35;
                        worksheet.Cells[1, 4].Value = "Emp No."; worksheet.Cells[1, 4].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin); worksheet.Column(4).Width = 14;
                        worksheet.Cells[1, 5].Value = ""; worksheet.Cells[1, 5].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin); worksheet.Column(5).Width = 5.40;
                        worksheet.Cells[1, 6].Value = "Off Code"; worksheet.Cells[1, 6].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin); worksheet.Column(6).Width = 23;
                        worksheet.Cells[1, 7].Value = "Off"; worksheet.Cells[1, 7].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin); worksheet.Column(7).Width = 8.40;
                        worksheet.Cells[1, 8].Value = "Bank Hrs"; worksheet.Cells[1, 8].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin); worksheet.Column(8).Width = 9.3;
                        worksheet.Cells[1, 9].Value = "Difference"; worksheet.Cells[1, 9].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin); worksheet.Column(9).Width = 10.7;
                        worksheet.Cells[1, 10].Value = "Change To"; worksheet.Cells[1, 10].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin); worksheet.Column(10).Width = 12; 

                        var range = worksheet.Cells[1, 1, 1, 10];
                        range.Style.Font.Bold = true;
                        range.Style.Font.Size = 11;
                        range.Style.Font.Name = "Arial";
                        range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor(Color.LightBlue);

                        for (int i = 12; i <= totalRows; i++)
                        {
                            try
                            {
                                worksheet.Row(i - 10).Height = 25;
                                worksheet.Row(i - 10).Style.Font.Size = 12;
                                worksheet.Row(i - 10).Style.Font.Name = "Arial";
                                worksheet.Row(i - 10).Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                                worksheet.Cells[i - 10, 1].Value = currentWorksheet.Cells[i, 1].Value.ToString().Trim(); worksheet.Cells[i - 10, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                worksheet.Cells[i - 10, 2].Value = currentWorksheet.Cells[i, 2].Value; worksheet.Cells[i - 10, 2].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                worksheet.Cells[i - 10, 3].Value = currentWorksheet.Cells[i, 5].Value.ToString().Trim(); worksheet.Cells[i - 10, 3].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                worksheet.Cells[i - 10, 4].Value = currentWorksheet.Cells[i, 7].Value; worksheet.Cells[i - 10, 4].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                worksheet.Cells[i - 10, 5].Value = currentWorksheet.Cells[i, 8].Value; worksheet.Cells[i - 10, 5].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                worksheet.Cells[i - 10, 6].Value = currentWorksheet.Cells[i, 9].Value; worksheet.Cells[i - 10, 6].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                worksheet.Cells[i - 10, 7].Value = currentWorksheet.Cells[i, 11].Value; worksheet.Cells[i - 10, 7].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                worksheet.Cells[i - 10, 8].Value = Math.Floor(Convert.ToDouble(currentWorksheet.Cells[i, 13].Value) * 100) / 100; worksheet.Cells[i - 10, 8].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                worksheet.Cells[i - 10, 9].Value = Math.Round(Convert.ToDouble(currentWorksheet.Cells[i, 11].Value) - (Math.Floor(Convert.ToDouble(currentWorksheet.Cells[i, 13].Value) * 100) / 100), 3); worksheet.Cells[i - 10, 9].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                worksheet.Cells[i - 10, 10].Value = SearchMethods.ChangeTo(currentWorksheet.Cells[i, 8].Value.ToString(), currentWorksheet.Cells[i, 7].Value.ToString().Trim());
                                worksheet.Cells[i - 10, 10].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                worksheet.Cells[i - 10, 10].Style.Font.Italic = true;
                                worksheet.Cells[i - 10, 10].Style.Font.Color.SetColor(Color.Gray);
                                if (worksheet.Cells[i - 10, 10].Value.ToString().IndexOf('(') > -1)
                                {
                                    worksheet.Cells[i - 10, 10].Style.Font.Italic = false;
                                    if (worksheet.Cells[i - 10, 10].Value.ToString().IndexOf("A0U") > -1)
                                    {
                                        worksheet.Cells[i - 10, 10].Style.Font.Size = 8;
                                    }
                                    else
                                    {
                                        worksheet.Cells[i - 10, 10].Style.Font.Size = 6;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                return;
                            }

                            if (worksheet.Cells[i - 10, 3].Value.ToString().ToUpper().IndexOf("MULTI") > -1)
                            {
                                range = worksheet.Cells[i - 10, 1, i - 10, 9];
                                range.Style.Font.Size = 11;                                
                                range.Style.Font.Bold = range.Style.Font.Italic = true;                                
                            }

                            worksheet.Cells[i - 10, 10].Value = worksheet.Cells[i - 10, 10].Value + Common.CheckIfMultiJob(worksheet.Cells[i - 10, 4].Value.ToString().Trim());
                        }

                        //worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                        //worksheet.Cells.AutoFitColumns();

                        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                        saveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                        saveFileDialog1.FilterIndex = 1;
                        saveFileDialog1.FileName = "Banks Compare";
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
                btnBanks.Text = "Off Codes vs Banks";
                Cursor.Current = Cursors.Default;
                Update();
            }
        }

        

        private void ProcessFile2(string _sourceFile, string _destFolder)
        {

            TopMost = false;

            frmUploadItems _frm = new frmUploadItems();
            _frm.ShowDialog();
            UploadItemsParams _uploadParams = _frm.attr;
            _frm.Dispose();

            TopMost = true;

            try
            {
                using (var package = new ExcelPackage())
                {
                    // add a new worksheet to the empty workbook
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(_sourceFile);

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
                    worksheet.HeaderFooter.OddHeader.RightAlignedText = "Pay Period: " + GetPP(DateTime.Now.ToString("ddMMMyyyy"));
                    worksheet.HeaderFooter.OddHeader.CenteredText = "Positions Report";
                    worksheet.HeaderFooter.OddFooter.RightAlignedText = string.Format("Page {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
                    worksheet.View.PageBreakView = true;
                    worksheet.PrinterSettings.FitToPage = true; worksheet.PrinterSettings.FitToWidth = 1; worksheet.PrinterSettings.FitToHeight = 0;
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

                    string[] lines = System.IO.File.ReadAllLines(_sourceFile);

                    int lineCtr = 2;

                    bool firstEmp = true;
                    string currEmp = "", currUnit = "", currOcc = "", currStat = "", currFTE = "", prevUnit = "", prevOcc = "";
                    bool switchColor = true, ThersAChange = false;

                    bool changeInUnit = false, changeInOcc = false;

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
                                    currEmp = values[1]; currUnit = prevUnit = values[20]; currOcc = prevOcc = values[21]; currStat = values[22]; currFTE = values[23]; // reset the base values
                                    ThersAChange = false; //reset the flags
                                    switchColor = !switchColor;
                                }
                            }
                            if (currUnit != values[20]) // change in unit
                            {
                                worksheet.Cells[lineCtr - 1, 11].Value = GetEmpName(values[1].Substring(0, 8));
                                worksheet.Cells[lineCtr, 7].Style.Font.Bold = true;
                                prevUnit = currUnit;
                                currUnit = values[20];
                                ThersAChange = changeInUnit = true;
                            }
                            if (currOcc != values[21]) // change in occupation
                            {
                                if (!ThersAChange) worksheet.Cells[lineCtr - 1, 11].Value = GetEmpName(values[1].Substring(0, 8));
                                worksheet.Cells[lineCtr, 8].Style.Font.Bold = true;
                                prevOcc = currOcc;
                                currOcc = values[21];
                                ThersAChange = changeInOcc = true;
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

                            #region AutoInsertInItemsReport                          
                            if (_uploadParams.uploadToItems)
                            {
                                if (changeInUnit)
                                {
                                    if (InsertInItems(new ChangeInUnitAndOrOcc
                                    {
                                        empNo = values[1].Trim(),
                                        prevUnit = prevUnit.Trim(),
                                        currUnit = currUnit.Trim(),
                                        prevPosCode = changeInOcc ? prevOcc : values[21].Trim(),
                                        currPosCode = values[21].Trim(),
                                        stat = values[22].Trim(),
                                        pp = _uploadParams.pp,
                                        ppYear = _uploadParams.ppYear,
                                        itemsReportLetter = _uploadParams.itemsReportLetter
                                    }))
                                    {
                                        values[0] = values[0] + " (UT)";
                                    };
                                }
                                else if (!changeInUnit && changeInOcc)
                                {
                                    if (InsertInItems(new ChangeInOcc
                                    {
                                        empNo = values[1].Trim(),
                                        unit = currUnit.Trim(),
                                        prevPosCode = prevOcc,
                                        currPosCode = currOcc,
                                        pp = _uploadParams.pp,
                                        ppYear = _uploadParams.ppYear,
                                        itemsReportLetter = _uploadParams.itemsReportLetter
                                    }))
                                    {
                                        values[0] = values[0] + " (OC)";
                                    };
                                }
                            }

                            changeInUnit = changeInOcc = false;
                            #endregion

                            worksheet.Row(lineCtr).Height = 25;
                            worksheet.Row(lineCtr).Style.Font.Size = 12;
                            worksheet.Row(lineCtr).Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                            worksheet.Cells[lineCtr, 1].Value = values[0]; worksheet.Cells[lineCtr, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            worksheet.Cells[lineCtr, 2].Value = values[1]; worksheet.Cells[lineCtr, 2].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            worksheet.Cells[lineCtr, 3].Value = values[15]; worksheet.Cells[lineCtr, 3].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            worksheet.Cells[lineCtr, 4].Value = values[16]; worksheet.Cells[lineCtr, 4].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            worksheet.Cells[lineCtr, 5].Value = values[17].Trim() != "" ? DateTime.ParseExact(values[17].PadLeft(8, '0'), "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("ddMMMyy") : ""; worksheet.Cells[lineCtr, 5].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            worksheet.Cells[lineCtr, 6].Value = values[18].Trim() != "" ? DateTime.ParseExact(values[18].PadLeft(8, '0'), "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("ddMMMyy") : ""; worksheet.Cells[lineCtr, 6].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            worksheet.Cells[lineCtr, 7].Value = values[20]; worksheet.Cells[lineCtr, 7].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            worksheet.Cells[lineCtr, 8].Value = GetPosition(values[21]); worksheet.Cells[lineCtr, 8].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            worksheet.Cells[lineCtr, 9].Value = values[22]; worksheet.Cells[lineCtr, 9].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            worksheet.Cells[lineCtr, 10].Value = Convert.ToDecimal(values[23]).ToString("0.00"); worksheet.Cells[lineCtr, 10].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            worksheet.Cells[lineCtr, 11].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            range = worksheet.Cells[lineCtr, 1, lineCtr, 11];
                            range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            range.Style.Fill.BackgroundColor.SetColor(switchColor ? Color.White : Color.FromArgb(191, 191, 191));
                            lineCtr++;
                        }
                    }

                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                    package.SaveAs(new FileInfo(_destFolder + "Positions " + DateTime.Now.ToString("ddMMMyy") + ".xlsx"));
                    System.Diagnostics.Process.Start(_destFolder + "Positions " + DateTime.Now.ToString("ddMMMyy") + ".xlsx");
                }
            }
            catch
            {
                //MessageBox.Show("ERROR: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProcessFile6(string _sourceFile, string _destFolder)
        {
            try
            {
                using (var package = new ExcelPackage())
                {
                    // add a new worksheet to the empty workbook
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(_sourceFile);

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
                    worksheet.HeaderFooter.OddHeader.RightAlignedText = "Pay Period: " + GetPP(DateTime.Now.ToString("ddMMMyyyy"));
                    worksheet.HeaderFooter.OddHeader.CenteredText = "Terms and Trans From File 6";
                    worksheet.View.PageBreakView = true;
                    worksheet.PrinterSettings.FitToPage = true; worksheet.PrinterSettings.FitToWidth = 1; worksheet.PrinterSettings.FitToHeight = 0;
                    //worksheet.PrinterSettings.RepeatRows = new ExcelAddress("$2:$2");

                    //Setting Header Style
                    worksheet.Row(1).Height = 42;
                    worksheet.Column(1).Width = 3.29;
                    worksheet.Cells[1, 2].Value = "EE ID #"; worksheet.Column(2).Width = 12.30;
                    worksheet.Cells[1, 3].Value = "Eff Date"; worksheet.Column(3).Width = 11.43; //worksheet.Column(3).AutoFit(); //
                    worksheet.Cells[1, 4].Value = "EE Name"; worksheet.Column(4).Width = 27;
                    worksheet.Cells[1, 5].Value = "Transfer From"; worksheet.Column(5).Width = 35;
                    worksheet.Cells[1, 6].Value = "Transfer To"; worksheet.Column(6).Width = 35;
                    worksheet.Cells[1, 7].Value = "WFC License"; worksheet.Column(7).Width = 9.86; worksheet.Cells[1, 7].Style.WrapText = true;
                    worksheet.Cells[1, 8].Value = "Comments"; worksheet.Column(8).Width = 13;
                    var range = worksheet.Cells[1, 1, 1, 8];
                    range.Style.Font.Bold = true;
                    range.Style.Font.Size = 12;
                    range.Style.Font.Name = "Arial";

                    string[] lines = System.IO.File.ReadAllLines(_sourceFile);

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
                                worksheet.Cells[lineCtr, 3].Value = values[18] == "" ? "" : DateTime.ParseExact(values[18].PadLeft(8, '0'), "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("ddMMMyyyy");
                                worksheet.Cells[lineCtr, 4].Value = GetEmpName(values[1].Substring(0, 8));
                                lineCtr++;
                            }
                        }
                    }

                    if (!Directory.Exists(_destFolder + @"\Terms & Trans\"))
                    {
                        Directory.CreateDirectory(_destFolder + @"\Terms & Trans\");
                    }

                    package.SaveAs(new FileInfo(_destFolder + @"\Terms & Trans\File 6 - " + DateTime.Now.ToString("ddMMMyy") + ".xlsx"));
                    System.Diagnostics.Process.Start(_destFolder + @"\Terms & Trans\File 6 - " + DateTime.Now.ToString("ddMMMyy") + ".xlsx");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetFileListFromFTP()
        {
            string ftpAddr = "ftp://209.89.98.1/outbound";

            FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(ftpAddr);
            ftpRequest.Credentials = new NetworkCredential("esp-cal", "loon123**");
            ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
            FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse();
            StreamReader streamReader = new StreamReader(response.GetResponseStream());

            List<string> files = new List<string>();

            // get all current file from ftp
            string line = streamReader.ReadLine();
            while (!string.IsNullOrEmpty(line))
            {
                if (line.StartsWith("TSS_ESP_DEM_STG_") && line.IndexOf(DateTime.Now.ToString("yyyy-MM-dd")) > -1)
                {
                    files.Add(line);
                }
                line = streamReader.ReadLine();
            }

            streamReader.Close();

            if (files.Count > 3)
            {
                MessageBox.Show("It seems that there are more than 3 files, cannot proceed.\n\nSystem cannot decide which ones you need for today.\n\nYou need to manually ftp the right files.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (files.Count < 3)
            {
                MessageBox.Show("It seems that there are MISSING files, cannot proceed.\n\nSystem cannot decide which ones you need for today.\n\nYou need to manually ftp the right files.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string _payPeriod = "";
            string _currYear = "";
            string _currDate = DateTime.Today.ToString("yyyy-MM-dd");
            if (GetStartPP(_currDate) == _currDate)
            {
                _payPeriod = GetPP(DateTime.ParseExact(_currDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture).AddDays(-1).ToString("yyyy-MM-dd"));
            }
            else
            {
                _payPeriod = GetPP(_currDate);
            }

            if (Convert.ToInt16(_payPeriod) < 6 && DateTime.ParseExact(_currDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture).Month > 10)
            {
                _currYear = (DateTime.ParseExact(_currDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture).Year + 1).ToString();
            }
            else
            {
                _currYear = DateTime.ParseExact(_currDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture).Year.ToString();
            }

            string destFolder = @"\\jeeves.crha-health.ab.ca\rsss_systems\Operations - RSSS Systems Group\Employee Imports\" + _currYear + @"\PP " + _payPeriod + @"\";

            if (!Directory.Exists(destFolder))
            {
                Directory.CreateDirectory(destFolder);
            }

            foreach (string _s in files)
            {
                // get only file 1, 2 and 6
                if (_s.IndexOf("TSS_ESP_DEM_STG") > -1)
                {
                    GetTheFile(_s, destFolder);
                }
            }

            lblMsg.Text = "Done Processing.";
            timer1.Enabled = true;
        }

        private void GetTheFile(string _fileName, string _destFolder)
        {
            try
            {
                using (WebClient request = new WebClient())
                {
                    request.Credentials = new NetworkCredential("esp-cal", "loon123**");
                    request.DownloadFile("ftp://209.89.98.1/Outbound/" + _fileName, _destFolder + _fileName);                    
                }

                // make a copy of File 1
                if (_fileName.IndexOf("TSS_ESP_DEM_STG_1_O_") > -1 && File.Exists(_destFolder + _fileName))
                {
                    File.Copy(_destFolder + _fileName, _destFolder + "File 1 - " + DateTime.Today.ToString("ddMMMyyyy") + ".csv", true);
                }                

                // Process File 2
                if (_fileName.IndexOf("TSS_ESP_DEM_STG_2_O_") > -1 && File.Exists(_destFolder + _fileName))
                {
                    ProcessFile2(_destFolder + _fileName, _destFolder);
                }

                // Process File 6
                if (_fileName.IndexOf("TSS_ESP_DEM_STG_6_O_") > -1 && File.Exists(_destFolder + _fileName))
                {
                    ProcessFile6(_destFolder + _fileName, _destFolder);
                }
            }
            catch
            {
            }
        }

        private void btnFile126_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will get today's File 1, 2 and 6 from the FTP site and save it\non the shared folder then format File 2 and 6.\n\nDo you want to proceed? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            string _tempText = "";
            try
            {
                _tempText = btnFile126.Text;
                btnFile126.Text = "Processing...";
                Cursor.Current = Cursors.WaitCursor;
                Update();

                GetFileListFromFTP();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR:");
            }
            finally
            {
                btnFile126.Text = _tempText;
                Cursor.Current = Cursors.Default;
                Update();
            }
        }

        private void txtTCG_DoubleClick(object sender, EventArgs e)
        {
            if (txtTCG.Text != "---")
            {
                Clipboard.SetText(txtTCG.Text.Substring(16)); //only copy the actual timecard group
                lblMsg.Text = "Copied to clipboard !";
                timer1.Enabled = true;
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

        private void timerClose_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Hour > 1 && DateTime.Now.Hour < 5 && Cursor != Cursors.WaitCursor) Application.Exit();
        }

        private void frmSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_conn.State == ConnectionState.Open)
            {
                if (_comm != null)
                {
                    _comm.Dispose();
                    _comm = null;
                }
                _conn.Close();
            }
            _conn.Dispose();
        }

        private void btnRFLOA_Click(object sender, EventArgs e)
        {
            MessageBox.Show("On the next window, please select the 'Return From LOA' file that came from ePeople.\n\nPlease click OK to continue.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            RFLOA_Rehire("Return from LOA " + GetPrevious_PPRange(DateTime.Now.ToString("ddMMMyyyy")), "PayPeriod: " + GetPrevious_PP(DateTime.Now.ToString("ddMMMyyyy")), 
                         "Please select the 'Return From Leave' file", btnRFLOA, 
                         @"\\jeeves.crha-health.ab.ca\rsss_systems\Payroll\Return from LOA\RFL " + GetPrevious_PPRange(DateTime.Now.ToString("ddMMMyyyy")) + ".xlsx");
        }        

        private void btnRehire_Click(object sender, EventArgs e)
        {
            MessageBox.Show("On the next window, please select the 'Rehire' file that came from ePeople.\n\nPlease click OK to continue.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            RFLOA_Rehire("Rehire " + GetPrevious_PPRange(DateTime.Now.ToString("ddMMMyyyy")), "PayPeriod: " + GetPrevious_PP(DateTime.Now.ToString("ddMMMyyyy")),
                         "Please select the 'Rehire' file", btnRehire,
                         @"\\jeeves.crha-health.ab.ca\rsss_systems\Payroll\Rehires\Rehires " + GetPrevious_PPRange(DateTime.Now.ToString("ddMMMyyyy")) + ".xlsx");
        }

        private void RFLOA_Rehire(string _headerCenter, string _headerRight, string _openFileTitle, MBGlassStyleButton.MBGlassButton _btn, string _path)
        {
            string _origBtnText = _btn.Text;

            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Title = _openFileTitle;
                openFileDialog1.Filter = "XLS Files (.xls)|*.xls|CSV Files (.csv)|*.csv|All Files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;

                bool userClickedOK = openFileDialog1.ShowDialog() == DialogResult.OK;

                if (!userClickedOK) return;

                _btn.Text = "Processing...";
                Cursor.Current = Cursors.WaitCursor;
                Update();

                // Create the file using the FileInfo object
                var file = new FileInfo(_path);

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
                    worksheet.HeaderFooter.OddHeader.RightAlignedText = _headerRight;
                    worksheet.HeaderFooter.OddHeader.CenteredText = _headerCenter;
                    worksheet.HeaderFooter.OddFooter.RightAlignedText = string.Format("Page {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
                    worksheet.View.PageBreakView = true;
                    worksheet.PrinterSettings.RepeatRows = new ExcelAddress("$1:$1");
                    worksheet.PrinterSettings.FitToPage = true; worksheet.PrinterSettings.FitToWidth = 1; worksheet.PrinterSettings.FitToHeight = 0;

                    //Setting Header Style
                    worksheet.Row(1).Height = 25;
                    worksheet.Cells[1, 1].Value = "EE ID #"; //worksheet.Column(2).Width = 12.30;
                    worksheet.Cells[1, 2].Value = "Record #"; //worksheet.Column(3).Width = 10.43; //worksheet.Column(3).AutoFit(); //
                    worksheet.Cells[1, 3].Value = "EE Name"; //worksheet.Column(4).Width = 22;
                    worksheet.Cells[1, 4].Value = "Action"; //worksheet.Column(5).Width = 35;
                    worksheet.Cells[1, 5].Value = "Actn EffDt"; //worksheet.Column(6).Width = 35;
                    worksheet.Cells[1, 6].Value = "Actn Date"; //worksheet.Column(7).Width = 9.86; worksheet.Cells[1, 7].Style.WrapText = true;
                    worksheet.Cells[1, 7].Value = "Desc"; //worksheet.Column(8).Width = 15;
                    worksheet.Cells[1, 8].Value = "Job Code"; //worksheet.Column(8).Width = 15;
                    worksheet.Cells[1, 9].Value = "Empl Class"; //worksheet.Column(8).Width = 15;
                    worksheet.Cells[1, 10].Value = "FTE"; //worksheet.Column(8).Width = 15;
                    var range = worksheet.Cells[1, 1, 1, 10];
                    range.Style.Font.Bold = true;
                    range.Style.Font.Size = 11;
                    range.Style.Font.Name = "Arial";

                    string[] lines = System.IO.File.ReadAllLines(openFileDialog1.FileName);

                    int lineCtr = 2;

                    foreach (string line in lines)
                    {
                        string[] values = line.Replace("\"", "").Split(',');
                        if (values.Count() == 24)
                        {
                            if (values[22].Trim() == "001") // only with TCD values "1"
                            {
                                worksheet.Row(lineCtr).Height = 25;
                                worksheet.Row(lineCtr).Style.Font.Size = 12;
                                worksheet.Row(lineCtr).Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                                worksheet.Cells[lineCtr, 1].Value = values[1].Substring(1, 8);
                                worksheet.Cells[lineCtr, 2].Value = values[2];
                                worksheet.Cells[lineCtr, 3].Value = values[3] + ", " + values[4];
                                worksheet.Cells[lineCtr, 4].Value = values[5];
                                worksheet.Cells[lineCtr, 5].Value = DateTime.ParseExact(values[7], "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture).ToString("ddMMMyyyy");
                                worksheet.Cells[lineCtr, 6].Value = DateTime.ParseExact(values[8], "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture).ToString("ddMMMyyyy");
                                worksheet.Cells[lineCtr, 7].Value = values[10];
                                worksheet.Cells[lineCtr, 8].Value = values[13];
                                worksheet.Cells[lineCtr, 9].Value = values[16];
                                worksheet.Cells[lineCtr, 10].Value = values[19];
                                lineCtr++;

                                if (lineCtr % 9 == 0 && _btn.Name == "btnRFLOA") worksheet.Row(lineCtr).PageBreak = true;
                            }
                        }
                    }

                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                    worksheet.Column(2).Width = 38; // expand the width for column "Record #"                                       

                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    saveFileDialog1.FilterIndex = 1;
                    saveFileDialog1.FileName = _path;
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        package.SaveAs(new FileInfo(saveFileDialog1.FileName));
                        System.Diagnostics.Process.Start(saveFileDialog1.FileName);
                    }

                    //package.SaveAs(new FileInfo(_path));
                    //System.Diagnostics.Process.Start(_path);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _btn.Text = _origBtnText;
                Cursor.Current = Cursors.Default;
            }
        }

        private void mbUserLatestLogin_Click(object sender, EventArgs e)
        {
            HideMe();
            frmLatestLogin _frm = new frmLatestLogin();
            _frm.ShowDialog();
            ShowMe();
        }

        private void frmSearch_Deactivate(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal) Opacity = .7;
        }

        private void frmSearch_Activated(object sender, EventArgs e)
        {
            if (Opacity < 1) Opacity = 1;
        }

        private void frmSearch_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

            }
            else if (e.Button == MouseButtons.Right)
            {
                this.TopMost = false;
                frmCredits01 _frm = new frmCredits01();
                _frm.ShowDialog();
                this.TopMost = true;
            }
        }

        private void btnPriors_Click(object sender, EventArgs e)
        {
            Workbook book;
            Worksheet sheet;

            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Title = "Please select the Prior Pay Period Adjustment File";
                openFileDialog1.Filter = "Excel File (.xls)|*.xls|All Files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;

                bool userClickedOK = openFileDialog1.ShowDialog() == DialogResult.OK;

                if (!userClickedOK) return;
                btnPriors.Text = "Processing...";
                Cursor.Current = Cursors.WaitCursor;
                Update();

                book = Workbook.Load(openFileDialog1.FileName); 
                sheet = book.Worksheets[0];

                //MessageBox.Show("sheet.Cells.FirstRowIndex=" + sheet.Cells.FirstRowIndex + ", sheet.Cells.LastRowIndex=" + sheet.Cells.LastRowIndex + "\n\r");

                using (var package = new ExcelPackage())
                {
                    // add a new worksheet to the empty workbook
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Prior Pay Period Adj");

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
                    worksheet.HeaderFooter.OddHeader.RightAlignedText = "PP " + GetPrevious_PP(DateTime.Now.ToString("ddMMMyyyy"));
                    worksheet.HeaderFooter.OddHeader.CenteredText = "Prior Pay Period Adjustments Made By Scheduling";
                    worksheet.View.PageBreakView = true;
                    worksheet.PrinterSettings.FitToPage = true; worksheet.PrinterSettings.FitToWidth = 1; worksheet.PrinterSettings.FitToHeight = 0;

                    int outCurrRowIndex = 1;
                    int rowStartOfRecord = 1;
                    bool notIncluded = false;
                    for (int rowIndex = sheet.Cells.FirstRowIndex; rowIndex <= sheet.Cells.LastRowIndex; rowIndex++)
                    {
                        Row row = sheet.Cells.GetRow(rowIndex);

                        //MessageBox.Show("rowIndex=" + rowIndex + ", row.FirstColIndex=" + row.FirstColIndex + ", row.LastColIndex=" + row.LastColIndex + "\n\r");

                        if ((row.LastColIndex < 100) && (row.GetCell(0).StringValue.ToUpper().IndexOf("PRINTED BY") < 0)) // DONT PROCESS EMPTY ROWS AND ROWS WITH "PRINTED BY"
                        {
                            // insert page break for every EE record
                            if (row.FirstColIndex == 18 && (row.GetCell(18).StringValue.ToUpper().IndexOf("PAY PERIOD ADJUSTMENTS") > -1) && outCurrRowIndex != 1)
                            {
                                worksheet.Row(outCurrRowIndex - 1).PageBreak = true;
                            }

                            // get the start row of every record so you know when to start to delete if its not included
                            if (row.GetCell(18).StringValue.ToUpper().IndexOf("PAY PERIOD ADJUSTMENTS") > -1)
                            {
                                if (notIncluded) // remove the written record
                                {
                                    for (int _start = rowStartOfRecord; _start < outCurrRowIndex; _start++)
                                    {
                                        worksheet.DeleteRow(rowStartOfRecord);
                                    }
                                    worksheet = package.Workbook.Worksheets.First();
                                    outCurrRowIndex = rowStartOfRecord;
                                    notIncluded = false;
                                }
                                rowStartOfRecord = outCurrRowIndex;
                            }

                            // Check if the modification was made by systems, if it is then don't include it in the report
                            if (row.LastColIndex == 10)
                            {
                                notIncluded = IsSystemsMember(row.GetCell(10).StringValue.ToUpper());
                                //if (row.GetCell(10).StringValue.ToUpper() == "ROTCHELOSANTOSS") { 
                                //    MessageBox.Show("ASDF"); };
                            }


                            for (int colIndex = row.FirstColIndex; colIndex <= row.LastColIndex; colIndex++)
                            {
                                Cell cell = row.GetCell(colIndex);
                                if (cell.StringValue.Trim() != "") worksheet.Cells[outCurrRowIndex, colIndex + 1].Value = cell.StringValue;
                            }
                            outCurrRowIndex++;
                        }

                        // check the last record written if its should be included or not
                        if (notIncluded) // remove the written record
                        {
                            for (int _start = rowStartOfRecord; _start < outCurrRowIndex; _start++)
                            {
                                worksheet.DeleteRow(rowStartOfRecord);
                            }
                            worksheet = package.Workbook.Worksheets.First();
                        }
                    }

                    worksheet.DeleteColumn(1); worksheet.DeleteColumn(25); // DELETE COLUMN A AND Z
                    worksheet.Column(2).Width = worksheet.Column(3).Width = worksheet.Column(4).Width = worksheet.Column(5).Width = worksheet.Column(6).Width = worksheet.Column(7).Width =
                        worksheet.Column(8).Width = worksheet.Column(15).Width = worksheet.Column(16).Width = worksheet.Column(18).Width = worksheet.Column(20).Width =
                        worksheet.Column(21).Width = worksheet.Column(24).Width = 5; // set column width to 5 for columns B to H, O, P, R, T, U, X

                    if (worksheet.Cells[1, 18].Value != null)
                    {
                        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                        saveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                        saveFileDialog1.FilterIndex = 1;
                        saveFileDialog1.FileName = "Report - Pay Period Adjustments " + DateTime.Today.ToString("dd-MMM-yyyy");
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            package.SaveAs(new FileInfo(saveFileDialog1.FileName));
                            System.Diagnostics.Process.Start(saveFileDialog1.FileName);
                        }
                    }
                    else
                    {
                        MessageBox.Show("It's your lucky day. No prior pay period adjustments!");
                    }                   
                }                
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("OutOfMemoryException") > -1)
                {
                    MessageBox.Show("Error in opening the file.\n\r\n\rPlease open the file first in Excel and \"Enable Editing\" and then save it then try to open the file again.",
                        "Ooops, may mali.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("ERROR: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {                
                book = null;
                sheet = null;

                btnPriors.Text = "Prior Pay Period Adj";
                Cursor.Current = Cursors.Default;
                Update();
            }
        }

        private bool IsSystemsMember(string _userName)
        {
            List<string> systemMembers = new List<string>() { "BOLSON02", "SCOTTHASTINGS", "MIKAELMANAGAT", "ROTCHELOSANTOS", "DARWINDIZON", "BSANTOS", "LOURDESSHAHPORI", "ADELACRUZ02" };

            return systemMembers.Contains(_userName.Trim().ToUpper());
        }

        private void btnAHS_AA_Terms_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Title = "Please select the AHS_AA_TERMS Excel File";
                openFileDialog1.Filter = "Excel File (.xls)|*.xls|All Files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;

                bool userClickedOK = openFileDialog1.ShowDialog() == DialogResult.OK;

                if (!userClickedOK) return;
                btnAHS_AA_Terms.Text = "Processing...";
                Cursor.Current = Cursors.WaitCursor;
                Update();

                Workbook book = Workbook.Load(openFileDialog1.FileName);
                Worksheet sheet = book.Worksheets[0];

                //MessageBox.Show("sheet.Cells.FirstRowIndex=" + sheet.Cells.FirstRowIndex + ", sheet.Cells.LastRowIndex=" + sheet.Cells.LastRowIndex + "\n\r");

                using (var package = new ExcelPackage())
                {
                    // add a new worksheet to the empty workbook
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Terms");

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
                    worksheet.HeaderFooter.OddHeader.RightAlignedText = "PP " + GetPP(DateTime.Now.ToString("ddMMMyyyy"));                    
                    worksheet.HeaderFooter.OddHeader.CenteredText = "Terms " + CheckTermsAndTransStartDate(DateTime.Today.ToString("yyyy-MM-dd")) + " - " + DateTime.Today.AddDays(-1).ToString("ddMMMyyyy");
                    worksheet.HeaderFooter.OddFooter.RightAlignedText = string.Format("Page {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
                    worksheet.View.PageBreakView = true;
                    worksheet.PrinterSettings.FitToPage = true; worksheet.PrinterSettings.FitToWidth = 1; worksheet.PrinterSettings.FitToHeight = 0;
                    worksheet.PrinterSettings.RepeatRows = new ExcelAddress("$1:$1");

                    int outCurrRowIndex = 1;                                        
                    for (int rowIndex = sheet.Cells.FirstRowIndex + 1; rowIndex <= sheet.Cells.LastRowIndex; rowIndex++)
                    {
                        Row row = sheet.Cells.GetRow(rowIndex);

                        //MessageBox.Show("rowIndex=" + rowIndex + ", row.FirstColIndex=" + row.FirstColIndex + ", row.LastColIndex=" + row.LastColIndex + "\n\r");
                        if (row.GetCell(17).StringValue == "001" || rowIndex == 1)
                        {
                            for (int colIndex = row.FirstColIndex; colIndex <= row.LastColIndex; colIndex++)
                            {
                                Cell cell = row.GetCell(colIndex);
                                if (cell.StringValue.Trim() != "")
                                {
                                    if ((colIndex == 2 || colIndex == 19) && rowIndex > 1) // convert the numerical date value to normal date value, skip row 1 which is the header
                                    {
                                        worksheet.Cells[outCurrRowIndex, colIndex + 1].Value = cell.DateTimeValue.ToString("ddMMMyyyy");
                                    }
                                    else
                                    {
                                        worksheet.Cells[outCurrRowIndex, colIndex + 1].Value = cell.StringValue;
                                    }
                                }
                            }
                            worksheet.Row(outCurrRowIndex).Height = 25;
                            outCurrRowIndex++;
                        }
                    }

                    worksheet.DeleteColumn(4); worksheet.DeleteColumn(5); worksheet.DeleteColumn(6); worksheet.DeleteColumn(6); worksheet.DeleteColumn(6);
                    worksheet.DeleteColumn(6); worksheet.DeleteColumn(6); worksheet.DeleteColumn(6); worksheet.DeleteColumn(6); worksheet.DeleteColumn(6); worksheet.DeleteColumn(7);
                    worksheet.DeleteColumn(7);                    
                    
                    var range = worksheet.Cells[1, 1, 1, 8];
                    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                    range.Style.Font.Bold = true;

                    //worksheet.Cells[worksheet.Dimension.Address].AutoFilter = true;

                    worksheet.Cells[worksheet.Dimension.Address].Style.Font.Name = "Arial Unicode MS";
                    worksheet.Cells[worksheet.Dimension.Address].Style.Font.Size = 11;
                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                    worksheet.Column(2).Width = 22;
                    

                    if (worksheet.Cells[1, 1].Value != null)
                    {
                        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                        saveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                        saveFileDialog1.FilterIndex = 1;
                        saveFileDialog1.FileName = "Terms " + CheckTermsAndTransStartDate(DateTime.Today.ToString("yyyy-MM-dd")) + " - " + DateTime.Today.AddDays(-1).ToString("ddMMMyy");
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            package.SaveAs(new FileInfo(saveFileDialog1.FileName));
                            System.Diagnostics.Process.Start(saveFileDialog1.FileName);
                        }
                    }
                    else
                    {
                        MessageBox.Show("It's your lucky day. No Terms Report!");
                    }
                }

                book = null;
                sheet = null;
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Buffer cannot be null") > -1)
                {
                    MessageBox.Show("Error in opening the file.\n\r\n\rPlease open the file first in Excel and \"Enable Editing\" and then save it then try to open the file again.",
                        "Ooops, may mali.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("ERROR: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                btnAHS_AA_Terms.Text = "AHS_AA_TERMS";
                Cursor.Current = Cursors.Default;
                Update();
            }
        }

        private void btnTrans_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Title = "Please select the AHS_AA_TRANS Excel File";
                openFileDialog1.Filter = "Excel File (.xls)|*.xls|All Files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;

                bool userClickedOK = openFileDialog1.ShowDialog() == DialogResult.OK;

                if (!userClickedOK) return;
                btnTrans.Text = "Processing...";
                Cursor.Current = Cursors.WaitCursor;
                Update();

                Workbook book = Workbook.Load(openFileDialog1.FileName);
                Worksheet sheet = book.Worksheets[0];

                //MessageBox.Show("sheet.Cells.FirstRowIndex=" + sheet.Cells.FirstRowIndex + ", sheet.Cells.LastRowIndex=" + sheet.Cells.LastRowIndex + "\n\r");

                using (var package = new ExcelPackage())
                {
                    // add a new worksheet to the empty workbook
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Trans");

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
                    worksheet.HeaderFooter.OddHeader.RightAlignedText = "PP " + GetPP(DateTime.Now.ToString("ddMMMyyyy"));
                    worksheet.HeaderFooter.OddHeader.CenteredText = "Trans " + CheckTermsAndTransStartDate(DateTime.Today.ToString("yyyy-MM-dd")) + " - " + DateTime.Today.AddDays(-1).ToString("ddMMMyyyy");
                    worksheet.HeaderFooter.OddFooter.RightAlignedText = string.Format("Page {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
                    worksheet.View.PageBreakView = true;
                    worksheet.PrinterSettings.FitToPage = true; worksheet.PrinterSettings.FitToWidth = 1; worksheet.PrinterSettings.FitToHeight = 0;
                    worksheet.PrinterSettings.RepeatRows = new ExcelAddress("$1:$1");

                    int outCurrRowIndex = 1;
                    for (int rowIndex = sheet.Cells.FirstRowIndex + 1; rowIndex <= sheet.Cells.LastRowIndex; rowIndex++)
                    {
                        Row row = sheet.Cells.GetRow(rowIndex);

                        //MessageBox.Show("rowIndex=" + rowIndex + ", row.FirstColIndex=" + row.FirstColIndex + ", row.LastColIndex=" + row.LastColIndex + "\n\r");
                        if ((row.GetCell(7).StringValue != "TRM" && row.GetCell(5).StringValue == "001") || rowIndex == 1)
                        {
                            for (int colIndex = row.FirstColIndex; colIndex <= row.LastColIndex; colIndex++)
                            {
                                Cell cell = row.GetCell(colIndex);
                                if (cell.StringValue.Trim() != "")
                                {
                                    if (colIndex == 9 && rowIndex > 1) // convert the numerical date value to normal date value, skip row 1 which is the header
                                    {
                                        worksheet.Cells[outCurrRowIndex, colIndex + 1].Value = cell.DateTimeValue.ToString("ddMMMyyyy");
                                    }
                                    else
                                    {
                                        worksheet.Cells[outCurrRowIndex, colIndex + 1].Value = cell.StringValue;
                                    }
                                }
                            }
                            worksheet.Row(outCurrRowIndex).Height = 25;
                            outCurrRowIndex++;
                        }
                    }

                    worksheet.DeleteColumn(4); worksheet.DeleteColumn(5); worksheet.DeleteColumn(5); worksheet.DeleteColumn(6);
                    worksheet.DeleteColumn(8); worksheet.DeleteColumn(8); worksheet.DeleteColumn(8); worksheet.DeleteColumn(7); 
                    
                    var range = worksheet.Cells[1, 1, 1, 6];
                    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                    range.Style.Font.Bold = true;

                    //worksheet.Cells[worksheet.Dimension.Address].AutoFilter = true;

                    worksheet.Cells[worksheet.Dimension.Address].Style.Font.Name = "Arial Unicode MS";
                    worksheet.Cells[worksheet.Dimension.Address].Style.Font.Size = 11;
                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                    worksheet.Column(2).Width = 39;


                    if (worksheet.Cells[1, 1].Value != null)
                    {
                        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                        saveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                        saveFileDialog1.FilterIndex = 1;
                        saveFileDialog1.FileName = "Trans " + CheckTermsAndTransStartDate(DateTime.Today.ToString("yyyy-MM-dd")) + " - " + DateTime.Today.AddDays(-1).ToString("ddMMMyy");
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            package.SaveAs(new FileInfo(saveFileDialog1.FileName));
                            System.Diagnostics.Process.Start(saveFileDialog1.FileName);
                        }
                    }
                    else
                    {
                        MessageBox.Show("It's your lucky day. No Transfer Report!");
                    }
                }

                book = null;
                sheet = null;
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Buffer cannot be null") > -1)
                {
                    MessageBox.Show("Error in opening the file.\n\r\n\rPlease open the file first in Excel and \"Enable Editing\" and then save it then try to open the file again.",
                        "Ooops, may mali.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("ERROR: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                btnTrans.Text = "AHS_AA_TRANSFER_RPT";
                Cursor.Current = Cursors.Default;
                Update();
            }
        }

        /// <summary>
        /// Returns Proper StartDate when processing Terms and Trans Report
        /// </summary>
        /// <param name="_date">Format should be "yyyy-MM-dd"</param>
        /// <returns></returns>
        private string CheckTermsAndTransStartDate(string _date)
        {
            string _ret = "";            
            if (_date == GetStartPP(_date)) // Check if Mon of week 1, then Fri-Sun of Week 2
            {
                _ret = Convert.ToDateTime(_date).AddDays(-3).ToString("ddMMMyy");
            }
            else if (_date == Convert.ToDateTime(GetStartPP(_date)).AddDays(7).ToString("yyyy-MM-dd")) // Check if Mon of Week 2, then Mon-Sun of Week 1
            {
                _ret = Convert.ToDateTime(_date).AddDays(-7).ToString("ddMMMyy");
            }
            else if (_date == Convert.ToDateTime(GetStartPP(_date)).AddDays(11).ToString("yyyy-MM-dd")) // Check if Fri of Week 2, then Mon-Thu of Week 2 
            {
                _ret = Convert.ToDateTime(_date).AddDays(-4).ToString("ddMMMyy");
            }

            return _ret;
        }

        private void btnUserTrainings_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            System.Diagnostics.Process.Start("http://wssql07v03/Reports_PRDINST03/Pages/Report.aspx?ItemPath=%2fMyLearningLink%2fWorkforce+ESP%2fPSS+(Workforce+ESP)+Courses+-+Learner+Completions+Lookup&ViewMode=Detail");
            //HideMe();
            //frmTrainings _frm = new frmTrainings();
            //_frm.ShowDialog();
            //ShowMe();
        }

        private void ShowMe()
        {
            Show();
            this.Animate(new TopAnchoredHeightEffect(), EasingFunctions.BackEaseOut, 324, 1000, 0);
        }

        private void HideMe()
        {
            Hide();
            Height = 0;
        }

        private void btnClearLocks_Click(object sender, EventArgs e)
        {
            HideMe();         
            frmClearLocks _frm = new frmClearLocks();            
            _frm.ShowDialog();
            ShowMe();
        }

        private void frmSearch_Shown(object sender, EventArgs e)
        {
            this.Animate(new TopAnchoredHeightEffect(), EasingFunctions.BackEaseOut, 324, 1000, 0);
        }

        private void btnGetLDAP_Click(object sender, EventArgs e)
        {
            HideMe();
            frmLDAP _frm = new frmLDAP();
            _frm.ShowDialog();
            ShowMe();
        }

        private void btnExceptionLookup_Click(object sender, EventArgs e)
        {
            HideMe();
            exceptionLookupForm _frm = new exceptionLookupForm();
            _frm.ShowDialog();
            ShowMe();
        }

        private void btnItemsReport_Click(object sender, EventArgs e)
        {
            if (File.Exists(@"\\jeeves.crha-health.ab.ca\rsss_systems\Operations - RSSS Systems Group\Automated Files\ItemsReport.exe"))
            {
                WindowState = FormWindowState.Minimized;
                System.Diagnostics.Process.Start(@"\\jeeves.crha-health.ab.ca\rsss_systems\Operations - RSSS Systems Group\Automated Files\ItemsReport.exe");
            }
            else
            {
                MessageBox.Show("Cannot Find 'ItemsReport.exe' in 'Automated Files' folder.","Cannot Find File", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }        

        private void mnuCopyEmpNum_Click(object sender, EventArgs e)
        {
            string _clipText = lstResult.Items[lstResult.SelectedIndex].ToString().Trim().Substring(0, 10);
            Clipboard.SetText(_clipText);
            MessageBox.Show("'" + _clipText + "' copied to clipboard!");
        }

        private void mnuCopyEmpName_Click(object sender, EventArgs e)
        {
            string _clipText = lstResult.Items[lstResult.SelectedIndex].ToString().Trim().Substring(15);
            Clipboard.SetText(_clipText);
            MessageBox.Show("'" + _clipText + "' copied to clipboard!");
        }      

        private void mnuCopyBothNameAndNum_Click(object sender, EventArgs e)
        {
            string _clipText = lstResult.Items[lstResult.SelectedIndex].ToString().Trim().Substring(0);
            Clipboard.SetText(_clipText);
            MessageBox.Show("'" + _clipText + "' copied to clipboard!");
        }        

        private void lstResult_MouseUp(object sender, MouseEventArgs e)
        {
            if (_searchMode == 1 || lstResult.Items.Count == 0 || lstResult.SelectedIndex == -1)
            {
                return;
            }
            switch (e.Button)
            {
                case MouseButtons.Right:
                    {
                        mnuCopyFromList.Show(lstResult, new Point(e.X, e.Y));
                    }
                    break;
            }
        }
    }
}
