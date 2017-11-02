using OfficeOpenXml;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FormatFile2And6
{
    public partial class frmMain : Form
    {
        string ConnStr;

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnFile2_Click(object sender, EventArgs e)
        {
            if (!ZoneSelected()) return;

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Please select the File 2 CSV File";
            openFileDialog1.Filter = "CSV Files (.csv)|*.csv|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            bool userClickedOK = openFileDialog1.ShowDialog() == DialogResult.OK;

            if (!userClickedOK) return;

            btnFile2.Text = "Processing...";
            Cursor.Current = Cursors.WaitCursor;
            Update();

            ProcessFile2(openFileDialog1.FileName);

            btnFile2.Text = "Format File 2";
            Cursor.Current = Cursors.Default;
        }

        private bool ZoneSelected()
        {
            if (cboZone.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the zone first.", "Select a zone");
            }
            return cboZone.SelectedIndex != -1;
        }

        private string GetPP(string _date)
        {
            try
            {
                string _ret = "";

                using (SqlConnection _conn = new SqlConnection())
                {
                    _conn.ConnectionString = ConnStr;
                    _conn.Open();
                    using (SqlCommand _comm = _conn.CreateCommand())
                    {
                        _comm.CommandText = "select PP_NBR from payperiod where @V_DATE between pp_startdate and pp_enddate";
                        _comm.Parameters.Add(new SqlParameter("V_DATE", _date));
                        SqlDataReader _reader = _comm.ExecuteReader();
                        _reader.Read();
                        _ret = _reader["PP_NBR"].ToString();
                        if (_reader.IsClosed != true) _reader.Close();
                        _reader.Dispose();
                    }
                }

                return _ret != "" ? _ret.PadLeft(2, '0') : _ret;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR:" + ex.Message);
                return "";
            }
        }

        private string GetTCG(string _empID)
        {
            string _ret = "";

            using (SqlConnection _conn = new SqlConnection())
            {
                _conn.ConnectionString = ConnStr;
                _conn.Open();
                using (SqlCommand _comm = _conn.CreateCommand())
                {
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
                    else
                    {
                        _ret = GetEmpName(_empID.Substring(0, 8)); // Check if the name is already existing in ESP ,if it is then it means it is just INACTIVE
                        if (!_ret.ToUpper().Contains("NAME NOT FOUND"))
                        {
                            _ret = "--- INACTIVE ---";
                        }
                    }
                    _reader.Close();
                }
            }

            return _ret;
        }

        private void ProcessFile2(string _sourceFile, string _destFolder = "")
        {

            try
            {
                using (var package = new ExcelPackage())
                {
                    // add a new worksheet to the empty workbook
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Positions");

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
                    worksheet.HeaderFooter.OddHeader.LeftAlignedText = DateTime.Now.ToString("ddMMMyyyy HH:mm:ss");
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
                    int empLineCtr = 0;

                    bool firstEmp = true;
                    string currEmp = "", currUnit = "", currOcc = "", currStat = "", currFTE = "", prevUnit = "", prevOcc = "";
                    bool switchColor = true, ThersAChange = false;

                    bool changeInUnit = false;
                    bool changeInOcc = false;
                    //bool falseChangeUnit = false;

                    foreach (string line in lines)
                    {
                        string[] values = line.Split(',');
                        if (values.Count() == 40)
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
                                    if (empLineCtr == 1)
                                    {
                                        string _ret = CheckIfComingFromNFPOrInactive(currEmp);

                                        if (_ret != "")
                                        {
                                            worksheet.Cells[lineCtr - 1, 11].Value = _ret;
                                        }
                                        else
                                        {
                                            worksheet.Cells[lineCtr - 1, 11].Value = GetEmpName(currEmp.Substring(0, 8));
                                        }
                                    }
                                    else if (!ThersAChange)
                                    {
                                        string _ret = CheckIfComingFromNFPOrInactive(currEmp);

                                        if (_ret != "")
                                        {
                                            worksheet.Cells[lineCtr - 1, 11].Value = GetEmpName(currEmp.Substring(0, 8));
                                            worksheet.Cells[lineCtr, 11].Value = _ret;
                                        }
                                        else
                                        {
                                            worksheet.Cells[lineCtr - empLineCtr, 11].Value = "(No change? Pls. Check)";
                                        }
                                    }

                                    empLineCtr = 0;

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
                                ThersAChange = true;

                                string _ret = CheckIfComingFromNFPOrInactive(values[1]);

                                if (_ret != "")
                                {
                                    worksheet.Cells[lineCtr - 1, 11].Value = GetEmpName(currEmp.Substring(0, 8));
                                    worksheet.Cells[lineCtr, 11].Value = _ret;
                                }
                                else
                                {
                                    changeInUnit = true;
                                }
                            }
                            if (currOcc != values[21]) // change in occupation
                            {
                                if (!ThersAChange) worksheet.Cells[lineCtr - 1, 11].Value = GetEmpName(values[1].Substring(0, 8));
                                worksheet.Cells[lineCtr, 8].Style.Font.Bold = true;
                                prevOcc = currOcc;
                                currOcc = values[21];
                                ThersAChange = true;

                                string _ret = CheckIfComingFromNFPOrInactive(values[1]);

                                if (_ret != "")
                                {
                                    worksheet.Cells[lineCtr - 1, 11].Value = GetEmpName(currEmp.Substring(0, 8));
                                    worksheet.Cells[lineCtr, 11].Value = _ret;
                                }
                                else
                                {
                                    changeInOcc = true;
                                }
                            }
                            if (currStat != values[22]) // change in status
                            {
                                if (!ThersAChange) worksheet.Cells[lineCtr - 1, 11].Value = "Status";
                                worksheet.Cells[lineCtr, 9].Style.Font.Bold = true;
                                currStat = values[22];
                                if (currFTE != values[23]) // Change in FTE
                                {
                                    if (!ThersAChange) worksheet.Cells[lineCtr - 1, 11].Value = "Status / FTE";
                                    worksheet.Cells[lineCtr, 10].Style.Font.Bold = true;
                                    currFTE = values[23];
                                }
                                ThersAChange = true;

                                string _ret = CheckIfComingFromNFPOrInactive(values[1]);

                                if (_ret != "")
                                {
                                    worksheet.Cells[lineCtr - 1, 11].Value = GetEmpName(currEmp.Substring(0, 8));
                                    worksheet.Cells[lineCtr, 11].Value = _ret;
                                }
                            }
                            if (currFTE != values[23]) // change in FTE
                            {
                                if (!ThersAChange) worksheet.Cells[lineCtr - 1, 11].Value = "FTE";
                                worksheet.Cells[lineCtr, 10].Style.Font.Bold = true;
                                currFTE = values[23];
                                ThersAChange = true;

                                string _ret = CheckIfComingFromNFPOrInactive(values[1]);

                                if (_ret != "")
                                {
                                    worksheet.Cells[lineCtr - 1, 11].Value = GetEmpName(currEmp.Substring(0, 8));
                                    worksheet.Cells[lineCtr, 11].Value = _ret;
                                }
                            }

                            #region AutoInsertInItemsReport                          
                            //if (_uploadParams.uploadToItems)
                            //{
                            //    if (changeInUnit)
                            //    {
                            //        // InsertInItems return 0 = not successful; 1 = sucessfull; 2 = not inserted / already existing
                            //        byte _ret = InsertInItems(new ChangeInUnitAndOrOcc
                            //        {
                            //            empNo = values[1].Trim(),
                            //            prevUnit = prevUnit.Trim(),
                            //            currUnit = currUnit.Trim(),
                            //            prevPosCode = changeInOcc ? prevOcc : values[21].Trim(),
                            //            currPosCode = values[21].Trim(),
                            //            stat = values[22].Trim(),
                            //            pp = _uploadParams.pp,
                            //            ppYear = _uploadParams.ppYear,
                            //            itemsReportLetter = _uploadParams.itemsReportLetter
                            //        });
                            //        if (_ret == 1)
                            //        {
                            //            values[0] = "(Unit Trns)";
                            //        }
                            //        else if (_ret == 2)
                            //        {
                            //            worksheet.Cells[lineCtr, 11].Value = "(Prev. Entered)";
                            //            worksheet.Cells[lineCtr, 11].Style.Font.Size = 10;
                            //            worksheet.Cells[lineCtr, 11].Style.Font.Italic = true;
                            //        }
                            //    }
                            //    else if (!changeInUnit && changeInOcc)
                            //    {
                            //        // InsertInItems return 0 = not successful; 1 = sucessfull; 2 = not inserted / already existing
                            //        byte _ret = InsertInItems(new ChangeInOcc
                            //        {
                            //            empNo = values[1].Trim(),
                            //            unit = currUnit.Trim(),
                            //            prevPosCode = prevOcc,
                            //            currPosCode = currOcc,
                            //            pp = _uploadParams.pp,
                            //            ppYear = _uploadParams.ppYear,
                            //            itemsReportLetter = _uploadParams.itemsReportLetter
                            //        });
                            //        if (_ret == 1)
                            //        {
                            //            values[0] = "(Occ Chg)";
                            //        }
                            //        else if (_ret == 2)
                            //        {
                            //            worksheet.Cells[lineCtr, 11].Value = "(Prev. Entered)";
                            //            worksheet.Cells[lineCtr, 11].Style.Font.Size = 10;
                            //            worksheet.Cells[lineCtr, 11].Style.Font.Italic = true;
                            //        }
                            //    }
                            //}

                            //changeInUnit = changeInOcc = false;
                            #endregion

                            worksheet.Row(lineCtr).Height = 25;
                            worksheet.Row(lineCtr).Style.Font.Name = "Verdana";
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
                            empLineCtr++;
                        }
                    }

                    // Check if the last line is a one Liner, if it is then process it as you would a one liner
                    if (empLineCtr == 1)
                    {
                        string _ret = CheckIfComingFromNFPOrInactive(currEmp);

                        if (_ret != "")
                        {
                            worksheet.Cells[lineCtr - 1, 11].Value = GetEmpName(currEmp.Substring(0, 8));
                            worksheet.Cells[lineCtr, 11].Value = _ret;
                        }
                        else
                        {
                            worksheet.Cells[lineCtr - empLineCtr, 11].Value = "(No change? Pls. Check)";
                        }
                    }

                    // Check if the last line is "No Change?"
                    if (!ThersAChange && empLineCtr > 1)
                    {
                        string _ret = CheckIfComingFromNFPOrInactive(currEmp);

                        if (_ret != "")
                        {
                            worksheet.Cells[lineCtr - 1, 11].Value = GetEmpName(currEmp.Substring(0, 8));
                            worksheet.Cells[lineCtr, 11].Value = _ret;
                        }
                        else
                        {
                            worksheet.Cells[lineCtr - empLineCtr, 11].Value = "(No change? Pls. Check)";
                        }
                    }


                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();


                    if (_destFolder != "")
                    {
                        package.SaveAs(new FileInfo(_destFolder + "Positions " + DateTime.Now.ToString("ddMMMyy") + ".xlsx"));
                        System.Diagnostics.Process.Start(_destFolder + "Positions " + DateTime.Now.ToString("ddMMMyy") + ".xlsx");
                    }
                    else
                    {
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string CheckIfComingFromNFPOrInactive(string _empNo)
        {
            string _tcg = GetTCG(_empNo).ToUpper();
            string _ret = "";

            if (_tcg.Contains("NOT FOR PAYROLL") || _tcg.Contains("INACTIVE"))
            {
                if (_tcg.IndexOf("NOT FOR PAYROLL") > -1) // NFP
                {
                    _ret = "(From NFP? Pls Check)";
                }
                else // Inactive
                {
                    _ret = "(Re-hire? Pls Check)";
                }

                // insert the EE in the list to check for previous NPF or previous INACTIVE
                //using (SqlConnection _conn = new SqlConnection(Common.SystemsServer))
                //{
                //    _conn.Open();
                //    using (SqlCommand _comm = _conn.CreateCommand())
                //    {
                //        _comm.CommandText = "SELECT EmpID FROM NFPChecking WHERE EmpID = @_empID AND CurrentStat = 0";
                //        _comm.Parameters.AddWithValue("_empID", _empNo);
                //        SqlDataReader _dr = _comm.ExecuteReader();
                //        if (!_dr.HasRows)
                //        {
                //            _dr.Close();
                //            _comm.Parameters.Clear();
                //            _comm.CommandText = "INSERT INTO NFPChecking (Type, EmpID, Name, Prev_Unit, CurrentStat) VALUES (2, @_empID, @_name, @_prevUnit, 0)";
                //            _comm.Parameters.AddWithValue("_empID", _empNo);
                //            _comm.Parameters.AddWithValue("_name", GetEmpName(_empNo.Substring(0, 8)));
                //            _comm.Parameters.AddWithValue("_prevUnit", _tcg);
                //        }
                //    }
                //}
            }

            return _ret;
        }

        private string GetPosition(string _code)
        {
            string _ret = "";

            using (SqlConnection _conn = new SqlConnection())
            {
                _conn.ConnectionString = ConnStr;
                _conn.Open();
                using (SqlCommand _comm = _conn.CreateCommand())
                {
                    _comm.CommandText = "SELECT LTRIM(RTRIM(O_CODE)) + ' - ' + O_DESC 'DESC' FROM OCCUPATION WHERE O_CODE LIKE @V_O_CODE AND O_OccClassID <> 612 order by o_code, O_DESC DESC";
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
                }
            }

            return _ret;
        }

        private string GetEmpName(string _empID)
        {
            string _ret = "--- Name Not Found ---";

            using (SqlConnection _conn = new SqlConnection())
            {
                _conn.ConnectionString = ConnStr;
                _conn.Open();
                using (SqlCommand _comm = _conn.CreateCommand())
                {
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
                }
            }

            return _ret;
        }

        private void btnFile6_Click(object sender, EventArgs e)
        {
            if (!ZoneSelected()) return;

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

                ProcessFile6(openFileDialog1.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR IN PROCESSING FILE 6: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnFile6.Text = "Format File 6 From File 1";
                Cursor.Current = Cursors.Default;
            }
        }

        private void ProcessFile6(string _sourceFile, string _destFolder = "")
        {
            try
            {
                using (var package = new ExcelPackage())
                {
                    // add a new worksheet to the empty workbook
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Terms and Trans");

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
                    worksheet.HeaderFooter.OddHeader.LeftAlignedText = DateTime.Now.ToString("ddMMMyyyy HH:mm:ss");
                    worksheet.HeaderFooter.OddHeader.RightAlignedText = "Pay Period: " + GetPP(DateTime.Now.ToString("ddMMMyyyy"));
                    worksheet.HeaderFooter.OddHeader.CenteredText = "Terms and Trans From File 6";
                    worksheet.HeaderFooter.OddFooter.RightAlignedText = string.Format("Page {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
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
                        if (values.Count() == 40)
                        {
                            if (values[16].Trim() == "0") // only with values "0"
                            {
                                worksheet.Row(lineCtr).Height = 25;
                                worksheet.Row(lineCtr).Style.Font.Name = "Verdana";
                                worksheet.Row(lineCtr).Style.Font.Size = 10;
                                worksheet.Row(lineCtr).Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                                worksheet.Cells[lineCtr, 1].Value = values[0];
                                worksheet.Cells[lineCtr, 2].Value = values[1];
                                worksheet.Cells[lineCtr, 3].Value = values[18] == "" ? "" : DateTime.ParseExact(values[18].PadLeft(8, '0'), "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("ddMMMyyyy");
                                worksheet.Cells[lineCtr, 4].Value = GetEmpName(values[1].Substring(0, 8));
                                worksheet.Cells[lineCtr, 5].Value = GetTCG(values[1]);
                                lineCtr++;
                            }
                        }
                    }

                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                    worksheet.Column(1).Width = 3.29;
                    worksheet.Column(2).Width = 13;
                    worksheet.Column(3).Width = 12;
                    worksheet.Column(6).Width = 35;
                    worksheet.Column(7).Width = 9.86; worksheet.Cells[1, 7].Style.WrapText = true;

                    if (_destFolder != "")
                    {
                        if (!Directory.Exists(_destFolder + @"\Terms & Trans\"))
                        {
                            Directory.CreateDirectory(_destFolder + @"\Terms & Trans\");
                        }
                        package.SaveAs(new FileInfo(_destFolder + @"\Terms & Trans\File 6 - " + DateTime.Now.ToString("ddMMMyy") + ".xlsx"));
                        System.Diagnostics.Process.Start(_destFolder + @"\Terms & Trans\File 6 - " + DateTime.Now.ToString("ddMMMyy") + ".xlsx");
                    }
                    else
                    {
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConnStr = @"Server=wssqlc015v02\esp8; Initial Catalog=esp_ncs_prod; User Id=BOO_USER;Password=BOO_USER;";
        }

        private void cboZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboZone.SelectedIndex)
            {
                case 0: // Edmonton
                    ConnStr = @"Server=wssqlc015v02\esp8; Initial Catalog=esp_edm_prod; User Id=BOO_USER;Password=BOO_USER;";
                    break;
                case 1: // NCS
                    ConnStr = @"Server=wssqlc015v02\esp8; Initial Catalog=esp_ncs_prod; User Id=BOO_USER;Password=BOO_USER;";
                    break;
            }

        }
    }
}
