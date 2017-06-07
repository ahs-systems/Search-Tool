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

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        SqlConnection _conn = new SqlConnection();
        SqlCommand _comm;

        public Form1()
        {
            InitializeComponent();
            this.Shown += new System.EventHandler(this.Form1_Shown);
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
                if (line.IndexOf(DateTime.Now.ToString("yyyy-MM-dd")) > -1)
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
            string _currDate = "2016-03-21";//DateTime.Today.ToString("yyyy-MM-dd");
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

            string destFolder = @"\\jeeves.crha-health.ab.ca\rsss_systems\Operations - RSSS Systems Group\Employee Imports\Test Folder\" + _currYear + @"\PP " + _payPeriod + @"\";

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

            //MessageBox.Show("Done!");
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

        private void ProcessFile2(string _sourceFile, string _destFolder)
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
                                worksheet.Cells[lineCtr, 3].Value = DateTime.ParseExact(values[18].PadLeft(8, '0'), "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("ddMMMyyyy");
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
                }
            }
            catch
            {
            }
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

            return _ret != "" ? _ret.PadLeft(2, '0') : _ret;
        }

        private string GetStartPP(string _date)
        {
            string _ret = "";

            _comm.CommandText = "select Convert(varchar(10),PP_StartDate,23) as StartDate from payperiod where @V_DATE between pp_startdate and pp_enddate";
            _comm.Parameters.Clear();
            _comm.Parameters.Add(new SqlParameter("V_DATE", _date));
            SqlDataReader _reader = _comm.ExecuteReader();
            _reader.Read();
            _ret = _reader["StartDate"].ToString();
            if (_reader.IsClosed != true) _reader.Close();

            return _ret;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                _conn.ConnectionString = @"Server=wssqlc015v01\esp; Initial Catalog=esp_cal_prod;Integrated Security=SSPI;";
                if (_conn.State == ConnectionState.Open) _conn.Close();
                _conn.Open();
                _comm = _conn.CreateCommand();                

                this.TopMost = true;                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Update();
            GetFileListFromFTP();
            Close();
        }
    }
}
