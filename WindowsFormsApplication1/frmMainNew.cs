using Bunifu.Framework.UI;
using ExcelLibrary.SpreadSheet;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmMainNew : Form
    {
        SqlConnection _conn = new SqlConnection();
        SqlCommand _comm;
        BunifuTileButton _prevActiveButton = null;

        byte _searchMode; //1=occupation, 2=employee, 3=unit

        public frmMainNew()
        {
            InitializeComponent();
            this.Size = new Size(751, 369);
        }

        private void frmMainNew_Load(object sender, EventArgs e)
        {
            // set toolip for the pnlHandle
            toolTip1.SetToolTip(pnlHandle, Text);

            // Check if valid user
            if (!Common.CheckUsers(System.Security.Principal.WindowsIdentity.GetCurrent().Name.Replace(@"HEALTHY\", "").ToUpper()))
            {
                MessageBox.Show("Invalid user. Application will abort.", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            // Show the form
            Hide();
            transFrm.ShowSync(this, true, null);

            // Center the form
            StartPosition = FormStartPosition.CenterScreen;

            // Position the panels
            pnlFormatting.Visible = pnlSearch.Visible = false;
            pnlFormatting.Location = pnlSearch.Location = new Point(132, 44);

            try
            {
                _conn.ConnectionString = Common.ESPServer; //@"Server=" + SearchMethods.dbServer + "; Initial Catalog=esp_cal_prod;Integrated Security=SSPI;";

                TopMost = true;

                // Show pay period
                lblPayPeriod.Text = "Pay Period: " + Common.GetPP(dateTimePicker1.Value.ToString("yyyy-MM-dd"));

                // hide notify icon
                myNotifyIcon.Visible = false;

                //enable trigger of closing the application at early morning
                timerClose.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // Initialize the current selected button
            ChangeBtnBackColor(btnMisc);
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ChangeBtnBackColor(BunifuTileButton _btn)
        {
            if (_prevActiveButton != null)
            {
                _prevActiveButton.color = Color.FromArgb(9, 109, 130);

                //switch (_prevActiveButton.Name)
                //{
                //    case "btnMisc":
                //        bunifuTransition1.HideSync(pnlMisc, true, null);
                //        break;
                //}
            }

            _btn.color = Color.FromArgb(4, 84, 100);

            _prevActiveButton = _btn;
        }

        private void btnMisc_Click(object sender, EventArgs e)
        {
            ChangeBtnBackColor((BunifuTileButton)sender);
            pnlSearch.Visible = pnlFormatting.Visible = false;
            //pnlMisc.Visible = false;
            transPanel.ShowSync(pnlMisc, true, null);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ChangeBtnBackColor((BunifuTileButton)sender);
            //pnlSearch.Visible = true;
            pnlMisc.Visible = pnlFormatting.Visible = false;
            transPanel.ShowSync(pnlSearch, true, null);
        }

        private void btnFormatting_Click(object sender, EventArgs e)
        {
            ChangeBtnBackColor((BunifuTileButton)sender);
            //pnlFormatting.Visible = true;
            pnlSearch.Visible = pnlMisc.Visible = false;
            transPanel.ShowSync(pnlFormatting, true, null);
        }

        private void timerClose_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Hour > 1 && DateTime.Now.Hour < 5 && Cursor != Cursors.WaitCursor) Application.Exit();
        }

        private void frmMainNew_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                myNotifyIcon.Visible = true;
                myNotifyIcon.ShowBalloonTip(500);
                this.ShowInTaskbar = false;
            }
        }

        private void frmMainNew_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.TopMost = false;
                frmCredits01 _frm = new frmCredits01();
                _frm.ShowDialog();
                this.TopMost = true;
            }
        }

        private void frmMainNew_Deactivate(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal) Opacity = .7;
        }

        private void frmMainNew_Activated(object sender, EventArgs e)
        {
            if (Opacity < 1) Opacity = 1;
        }

        private void frmMainNew_FormClosing(object sender, FormClosingEventArgs e)
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

        private void ShowMe()
        {
            Show();
            Update();
        }

        private void HideMe()
        {
            Hide();
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

            btnSendEmail.Enabled = txtTCG.Visible = false;


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
            _comm.CommandText = "SELECT LTRIM(RTRIM(O_CODE)) + ' - ' + O_DESC 'DESC' FROM OCCUPATION WHERE O_CODE LIKE @V_O_CODE AND O_OccClassID <> 612 order by o_code";
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

            lblMsg.Text = lstResult.Items.Count + " record(s) found.";
            Update();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                _conn.ConnectionString = Common.ESPServer; //@"Server=" + SearchMethods.dbServer + "; Initial Catalog=esp_cal_prod;Integrated Security=SSPI;";

                TopMost = true;

                // Show pay period
                lblPayPeriod.Text = "Pay Period: " + Common.GetPP(dateTimePicker1.Value.ToString("yyyy-MM-dd"));

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
            btnSendEmail.Enabled = txtTCG.Visible = false;

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
                _comm.CommandText = "SELECT LTRIM(RTRIM(E_EMPNBR)) + '  -  ' + LTRIM(RTRIM(E_LASTNAME)) + ', ' + LTRIM(RTRIM(E_FIRSTNAME)) 'DESC' FROM EMP WHERE (UPPER(E_LASTNAME) LIKE @V_SEARCH OR UPPER(E_FIRSTNAME) LIKE @V_SEARCH) AND LEN(E_EMPNBR) > 7 ORDER BY E_LASTNAME, E_FIRSTNAME";
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

            lblMsg.Text = lstResult.Items.Count + " record(s) found.";
            Update();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void myNotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            myNotifyIcon.Visible = false;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string _ret = Common.GetPP(dateTimePicker1.Value.ToString("yyyy-MM-dd"));
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
            if (_tcg.ToUpper().IndexOf("INACTIVE") > -1)
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
                btnSendEmail.Enabled = txtTCG.Visible = true;
                string _tcg = GetTCG(lstResult.SelectedItem.ToString().Substring(0, 10));
                txtTCG.Text = "Timecard Group: " + _tcg;
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
            else
            {
                _ret = GetEmpName(_empID.Substring(0, 8)); // Check if the name is already existing in ESP ,if it is then it means it is just INACTIVE
                if (!_ret.ToUpper().Contains("NAME NOT FOUND"))
                {
                    _ret = "--- INACTIVE ---";
                }
            }

            _reader.Close();
            CloseConnection();

            return _ret;
        }

        private string GetTCG_ForTermsAndTrans(string _empID, string _mode)
        {
            string _ret = "";

            using (SqlConnection _conn = new SqlConnection())
            {
                _conn.ConnectionString = Common.ESPServer;
                _conn.Open();
                using (SqlCommand _comm = _conn.CreateCommand())
                {
                    _comm.CommandText = "select emp.e_empid EMPID, EMP.E_EmpNbr EMPNBR from emp " +
                                        "inner join empPosition on emp.e_empid = empPosition.ep_empid " +
                                        "inner join employmentStatus on emp.e_empid = employmentStatus.EMS_EmpID " +
                                        "where emp.e_empnbr like @V_SEARCH and empPosition.ep_todate >= GetDAte() " +
                                        "AND EmploymentStatus.EMS_EmploymentType = 1 AND EmploymentStatus.EMS_EndDate >= GetDAte() " +
                                        "GROUP BY EMP.E_EmpID, EMP.E_EmpNbr";

                    _comm.Parameters.Add(new SqlParameter("V_SEARCH", _empID.Substring(0, 8) + "%"));
                    SqlDataReader _reader = _comm.ExecuteReader();
                    if (_reader.HasRows)
                    {
                        _reader.Read();

                        string _retEmpID = _reader["EMPID"].ToString();
                        string _retEmpNbr = _reader["EMPNBR"].ToString();

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

                        if (_mode == "TRANS" && _ret.ToUpper().Contains("NOT FOR PAYROLL") && _retEmpNbr.Trim() == _empID)
                        {
                            _ret = "OK";
                        }
                    }
                    else
                    {
                        //if (_mode == "TERMS") _ret = "OK";
                        _ret = "OK";
                    }

                    _reader.Close();
                }
            }

            return _ret;
        }

        private string GetPosition(string _code)
        {
            string _ret = "";

            OpenConnection();
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

            CloseConnection();

            return _ret;
        }

        private string GetEmpName(string _empID)
        {
            string _ret = "--- Name Not Found ---";

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

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Please select the File 2 CSV File";
            openFileDialog1.Filter = "CSV Files (.csv)|*.csv|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            bool userClickedOK = openFileDialog1.ShowDialog() == DialogResult.OK;

            if (!userClickedOK) return;

            btnFile2.LabelText = "Processing...";
            Cursor.Current = Cursors.WaitCursor;
            btnFile2.Update();

            ProcessFile2(openFileDialog1.FileName);

            btnFile2.LabelText = "Format File 2";
            Cursor.Current = Cursors.Default;
        }

        private byte InsertInItems(ChangeInOcc _data)
        {
            if (GetSiteNum_ShortDesc(_data.unit) == -1) return 0; // the unit is not existing

            byte _ret = 0;

            try
            {
                using (SqlConnection myConnection = new SqlConnection())
                {
                    myConnection.ConnectionString = Common.SystemsServer; //@"Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=" + Application.StartupPath + @"\items.mdb;Uid=Admin;Pwd=;";
                    myConnection.Open();

                    SqlCommand myCommand = myConnection.CreateCommand();

                    // Check if the record is already existing 
                    myCommand.CommandText = "SELECT * FROM ItemsRpt_OccupationChange WHERE PayPeriod = @_PayPeriod AND PayPeriod_Year = @_PayPeriod_Year and ItemsReportLetter = @_ItemsReportLetter " +
                            "AND Emp_Num = @_Emp_num";
                    myCommand.Parameters.AddWithValue("_PayPeriod", _data.pp);
                    myCommand.Parameters.AddWithValue("_PayPeriod_Year", _data.ppYear);
                    myCommand.Parameters.AddWithValue("_ItemsReportLetter", _data.itemsReportLetter);
                    myCommand.Parameters.AddWithValue("_Emp_Num", _data.empNo);
                    SqlDataReader _dr = myCommand.ExecuteReader();
                    if (_dr.HasRows)
                    {
                        _ret = 2;
                        _dr.Close();
                    }
                    else // if not existing then proceed in inserting the record
                    {
                        _dr.Close();
                        myCommand.Parameters.Clear();

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
                        _ret = 1;
                    }

                    myCommand.Dispose();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Auto Inserting 'Change in Occupation' [" + _data.empNo + "]: " + ex.Message, "ERROR");
                _ret = 0;
            }

            return _ret;
        }

        private byte InsertInItems(ChangeInUnitAndOrOcc _data)
        {
            if (GetSiteNum_ShortDesc(_data.prevUnit) == -1) return 0;

            byte _ret = 0;

            try
            {
                using (SqlConnection myConnection = new SqlConnection())
                {
                    myConnection.ConnectionString = Common.SystemsServer; //@"Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=" + Application.StartupPath + @"\items.mdb;Uid=Admin;Pwd=;";
                    myConnection.Open();

                    SqlCommand myCommand = myConnection.CreateCommand();

                    // Check if the record is already existing 
                    myCommand.CommandText = "SELECT * FROM ItemsRpt_UnitToUnitTransfer WHERE PayPeriod = @_PayPeriod AND PayPeriod_Year = @_PayPeriod_Year and ItemsReportLetter = @_ItemsReportLetter " +
                            "AND Emp_Num = @_Emp_num";
                    myCommand.Parameters.AddWithValue("_PayPeriod", _data.pp);
                    myCommand.Parameters.AddWithValue("_PayPeriod_Year", _data.ppYear);
                    myCommand.Parameters.AddWithValue("_ItemsReportLetter", _data.itemsReportLetter);
                    myCommand.Parameters.AddWithValue("_Emp_Num", _data.empNo);
                    SqlDataReader _dr = myCommand.ExecuteReader();
                    if (_dr.HasRows)
                    {
                        _ret = 2;
                        _dr.Close();
                    }
                    else // if not existing then proceed in inserting the record
                    {
                        _dr.Close();
                        myCommand.Parameters.Clear();


                        myCommand.CommandText = "Insert into ItemsRpt_UnitToUnitTransfer (ItemsReportLetter, PayPeriod, PayPeriod_Year, Site, Emp_Num, Emp_Name, UnitFrom, UnitTo, Occupation, Status, ChangeInOccupation, ChangeInSite, Comments, EnteredBy) values " +
                                "(@_ItemsReportLetter, @_PayPeriod, @_PayPeriod_Year, @_Site, @_Emp_Num, @_Emp_Name, @_UnitFrom, @_UnitTo, @_Occupation, @_Status, @_ChangeInOccupation, @_ChangeInSite, @_Comments, @_EnteredBy)";

                        myCommand.Parameters.AddWithValue("_ItemsReportLetter", _data.itemsReportLetter);
                        myCommand.Parameters.AddWithValue("_PayPeriod", _data.pp);
                        myCommand.Parameters.AddWithValue("_PayPeriod_Year", _data.ppYear);
                        myCommand.Parameters.AddWithValue("_Site", (GetSiteNum_ShortDesc(_data.prevUnit) + 1));
                        myCommand.Parameters.AddWithValue("_Emp_Num", _data.empNo);
                        myCommand.Parameters.AddWithValue("_Emp_Name", GetEmpName(_data.empNo.Substring(0, 8)));
                        myCommand.Parameters.AddWithValue("_UnitFrom", _data.prevUnit);
                        myCommand.Parameters.AddWithValue("_UnitTo", _data.currUnit);
                        myCommand.Parameters.AddWithValue("_Occupation", GetPosition(_data.currPosCode));
                        myCommand.Parameters.AddWithValue("_Status", _data.stat);
                        myCommand.Parameters.AddWithValue("_ChangeInOccupation", (_data.prevPosCode != _data.currPosCode).ToString());
                        myCommand.Parameters.AddWithValue("_ChangeInSite", (GetSiteNum_ShortDesc(_data.prevUnit) != GetSiteNum_ShortDesc(_data.currUnit)).ToString());
                        myCommand.Parameters.AddWithValue("_Comments", "");
                        myCommand.Parameters.AddWithValue("_EnteredBy", "AutoSystem");

                        myCommand.ExecuteNonQuery();
                        _ret = 1;
                    }

                    myCommand.Dispose();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Auto Inserting 'Change in Site' [" + _data.empNo + "]: " + ex.Message, "ERROR");
                _ret = 0;
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
                btnFile6.LabelText = "Processing...";
                Cursor.Current = Cursors.WaitCursor;
                btnFile6.Update();

                ProcessFile6(openFileDialog1.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR IN PROCESSING FILE 6: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnFile6.LabelText = "Format File 6";
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
                btnBanks.LabelText = "Processing...";
                Cursor = Cursors.WaitCursor;
                btnBanks.Update();

                using (ExcelPackage package = new ExcelPackage(new FileInfo(openFileDialog1.FileName)))
                {
                    ExcelWorkbook workBook = package.Workbook;
                    ExcelWorksheet currentWorksheet = workBook.Worksheets.First();

                    int totalRows = currentWorksheet.Dimension.End.Row;
                    int totalCols = currentWorksheet.Dimension.End.Column;

                    #region New Formatting
                    //using (ExcelPackage package2 = new ExcelPackage())
                    //{
                    //    ExcelWorksheet worksheet = package2.Workbook.Worksheets.Add("System - Off Code vs Bank Hours");

                    //    // Set Page Settings
                    //    worksheet.PrinterSettings.Orientation = eOrientation.Landscape;
                    //    worksheet.PrinterSettings.ShowGridLines = true;
                    //    worksheet.PrinterSettings.HorizontalCentered = true;
                    //    worksheet.PrinterSettings.TopMargin = (decimal)1.5 / 2.54M;
                    //    worksheet.PrinterSettings.BottomMargin = (decimal)1.5 / 2.54M;
                    //    worksheet.PrinterSettings.LeftMargin = (decimal)0.3 / 2.54M;
                    //    worksheet.PrinterSettings.RightMargin = (decimal)0.3 / 2.54M;
                    //    worksheet.PrinterSettings.HeaderMargin = (decimal)0.5 / 2.54M;
                    //    worksheet.PrinterSettings.FooterMargin = (decimal)0.5 / 2.54M;
                    //    worksheet.HeaderFooter.OddHeader.LeftAlignedText = DateTime.Now.ToString("ddMMMyyyy");

                    //    string _currDate = DateTime.Today.ToString("yyyy-MM-dd");
                    //    string _payPeriod = "";
                    //    if (GetStartPP(_currDate) == _currDate)
                    //    {
                    //        _payPeriod = Common.GetPP(DateTime.ParseExact(_currDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture).AddDays(-1).ToString("yyyy-MM-dd"));
                    //    }
                    //    else
                    //    {
                    //        _payPeriod = Common.GetPP(_currDate);
                    //    }

                    //    worksheet.HeaderFooter.OddHeader.RightAlignedText = "Pay Period: " + _payPeriod;
                    //    worksheet.HeaderFooter.OddHeader.CenteredText = "Off Codes vs Bank Hours";
                    //    worksheet.HeaderFooter.OddFooter.RightAlignedText = string.Format("Page {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
                    //    worksheet.View.PageBreakView = true;
                    //    worksheet.PrinterSettings.FitToPage = true; worksheet.PrinterSettings.FitToWidth = 1; worksheet.PrinterSettings.FitToHeight = 0;
                    //    worksheet.PrinterSettings.RepeatRows = new ExcelAddress("$1:$1");

                    //    //worksheet.Cells[1, 1].Value = "Site"; worksheet.Cells[1, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin); worksheet.Column(1).Width = 4.70;
                    //    worksheet.Cells[1, 1].Value = "Unit"; worksheet.Cells[1, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin); worksheet.Column(1).Width = 36.30;
                    //    worksheet.Cells[1, 2].Value = "Name"; worksheet.Cells[1, 2].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin); worksheet.Column(2).Width = 35;
                    //    worksheet.Cells[1, 3].Value = "Emp No."; worksheet.Cells[1, 3].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin); worksheet.Column(3).Width = 14;
                    //    worksheet.Cells[1, 4].Value = ""; worksheet.Cells[1, 4].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin); worksheet.Column(4).Width = 5.40;
                    //    worksheet.Cells[1, 5].Value = "Off Code"; worksheet.Cells[1, 5].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin); worksheet.Column(5).Width = 23;
                    //    worksheet.Cells[1, 6].Value = "Off"; worksheet.Cells[1, 6].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin); worksheet.Column(6).Width = 8.40;
                    //    worksheet.Cells[1, 7].Value = "Bank Hrs"; worksheet.Cells[1, 7].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin); worksheet.Column(7).Width = 9.3;
                    //    worksheet.Cells[1, 8].Value = "Difference"; worksheet.Cells[1, 8].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin); worksheet.Column(8).Width = 10.7;
                    //    worksheet.Cells[1, 9].Value = "Change To"; worksheet.Cells[1, 9].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin); worksheet.Column(9).Width = 12;

                    //    var range = worksheet.Cells[1, 1, 1, 9];
                    //    range.Style.Font.Bold = true;
                    //    range.Style.Font.Size = 11;
                    //    range.Style.Font.Name = "Arial";
                    //    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    //    range.Style.Fill.BackgroundColor.SetColor(Color.LightBlue);


                    //    for (int i = 10; i <= totalRows; i++)
                    //    {
                    //        try
                    //        {
                    //            worksheet.Row(i - 8).Height = 27;
                    //            worksheet.Row(i - 8).Style.Font.Size = 12;
                    //            worksheet.Row(i - 8).Style.Font.Name = "Arial";
                    //            worksheet.Row(i - 8).Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                    //            worksheet.Cells[i - 8, 1].Value = currentWorksheet.Cells[i, 1].Value; worksheet.Cells[i - 8, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    //            worksheet.Cells[i - 8, 2].Value = currentWorksheet.Cells[i, 2].Value.ToString().Trim(); worksheet.Cells[i - 8, 2].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    //            worksheet.Cells[i - 8, 3].Value = currentWorksheet.Cells[i, 3].Value; worksheet.Cells[i - 8, 3].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    //            worksheet.Cells[i - 8, 4].Value = currentWorksheet.Cells[i, 4].Value; worksheet.Cells[i - 8, 4].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    //            worksheet.Cells[i - 8, 5].Value = currentWorksheet.Cells[i, 5].Value; worksheet.Cells[i - 8, 5].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    //            worksheet.Cells[i - 8, 6].Value = currentWorksheet.Cells[i, 6].Value; worksheet.Cells[i - 8, 6].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    //            worksheet.Cells[i - 8, 7].Value = Math.Floor(Convert.ToDouble(currentWorksheet.Cells[i, 7].Value) * 100) / 100; worksheet.Cells[i - 8, 7].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    //            worksheet.Cells[i - 8, 8].Value = Math.Round(Convert.ToDouble(currentWorksheet.Cells[i, 6].Value) - (Math.Floor(Convert.ToDouble(currentWorksheet.Cells[i, 7].Value) * 100) / 100), 3); worksheet.Cells[i - 8, 8].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    //            worksheet.Cells[i - 8, 9].Value = SearchMethods.ChangeTo(currentWorksheet.Cells[i, 4].Value.ToString(), currentWorksheet.Cells[i, 3].Value.ToString().Trim(), Convert.ToDouble(worksheet.Cells[i - 8, 8].Value));

                    //            // Check for multiple primaries
                    //            worksheet.Cells[i - 8, 9].Value = worksheet.Cells[i - 8, 9].Value + Common.CheckIfMultiJob(worksheet.Cells[i - 8, 3].Value.ToString().Trim());

                    //            worksheet.Cells[i - 8, 9].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    //            worksheet.Cells[i - 8, 9].Style.Font.Italic = true;
                    //            worksheet.Cells[i - 8, 9].Style.Font.Color.SetColor(Color.Gray);

                    //            if (worksheet.Cells[i - 8, 9].Value.ToString().IndexOf('(') > -1) // check for opening parenthesis in column 10 for notes
                    //            {
                    //                worksheet.Cells[i - 8, 9].Style.Font.Size = 8;
                    //            }

                    //            #region compute the split in timecard
                    //            // check if the unpaid code start with "(" ex (Aupe aux), else get the first 3 letters (ex. A24(M) => A24)
                    //            string _unpaidCode = "";
                    //            if (!worksheet.Cells[i - 8, 9].Value.ToString().StartsWith("(") && worksheet.Cells[i - 8, 9].Value.ToString().Length > 2)
                    //            {
                    //                _unpaidCode = worksheet.Cells[i - 8, 9].Value.ToString().Substring(0, 3);
                    //            }

                    //            // Check for A48, don't process the split for those ones
                    //            if (worksheet.Cells[i - 8, 4].Value.ToString().Trim() == "A48")
                    //            {
                    //                for (int i2 = 10; i2 < 14; i2++)
                    //                {
                    //                    worksheet.Cells[i - 8, i2].Value = "####";
                    //                    worksheet.Cells[i - 8, i2].Style.Font.Color.SetColor(Color.FromArgb(135, 135, 135));
                    //                }

                    //                // decrease the font size for row with A48
                    //                range = worksheet.Cells[i - 8, 10, i - 8, 13];
                    //                range.Style.Font.Name = "Verdana";
                    //                range.Style.Font.Size = 10;
                    //            }
                    //            else
                    //            {
                    //                string[] _split = GetTheSplit(worksheet.Cells[i - 8, 3].Value.ToString().Trim(), worksheet.Cells[i - 8, 4].Value.ToString().Trim(), _unpaidCode,
                    //                Convert.ToDouble(worksheet.Cells[i - 8, 6].Value), Convert.ToDouble(worksheet.Cells[i - 8, 7].Value), Convert.ToDouble(worksheet.Cells[i - 8, 8].Value));
                    //                for (int i2 = 10; i2 < _split.Length + 10; i2++)
                    //                {
                    //                    worksheet.Cells[i - 8, i2].Value = _split[i2 - 10];
                    //                    worksheet.Cells[i - 8, i2].Style.Font.Color.SetColor(Color.FromArgb(135, 135, 135));
                    //                    worksheet.Cells[i - 8, i2].Style.Font.Italic = true;
                    //                    worksheet.Cells[i - 8, i2].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Dotted);
                    //                    worksheet.Cells[i - 8, i2].Style.Border.Top.Color.SetColor(Color.Gray);
                    //                    worksheet.Cells[i - 8, i2].Style.Border.Right.Color.SetColor(Color.Gray);
                    //                    worksheet.Cells[i - 8, i2].Style.Border.Bottom.Color.SetColor(Color.Gray);
                    //                    worksheet.Cells[i - 8, i2].Style.Border.Left.Color.SetColor(Color.Gray);
                    //                }
                    //            }
                    //            #endregion


                    //        }
                    //        catch (Exception ex)
                    //        {
                    //            MessageBox.Show(ex.Message);
                    //            return;
                    //        }

                    //        // Italicized the font if there is the word "MULTI" in the first name
                    //        if (worksheet.Cells[i - 8, 2].Value.ToString().ToUpper().IndexOf("MULTI") > -1)
                    //        {
                    //            range = worksheet.Cells[i - 8, 1, i - 8, 8];
                    //            range.Style.Font.Size = 11;
                    //            range.Style.Font.Bold = range.Style.Font.Italic = true;
                    //        }


                    //    }


                    //    //worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                    //    //worksheet.Cells.AutoFitColumns();

                    //    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    //    saveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    //    saveFileDialog1.FilterIndex = 1;
                    //    saveFileDialog1.FileName = "Banks Compare";
                    //    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    //    {
                    //        #region Without Split Computation
                    //        //package2.SaveAs(new FileInfo(saveFileDialog1.FileName));
                    //        //System.Diagnostics.Process.Start(saveFileDialog1.FileName);
                    //        #endregion

                    //        #region With Split Computation
                    //        int lastCharPosition = saveFileDialog1.FileName.LastIndexOf('\\');
                    //        string tempFile = saveFileDialog1.FileName.Substring(0, lastCharPosition + 1) + "temp.xlsx";
                    //        package2.SaveAs(new FileInfo(tempFile));

                    //        // Save a copy to be use by SSO
                    //        using (ExcelPackage packageCopy = new ExcelPackage(new FileInfo(tempFile)))
                    //        {
                    //            ExcelWorkbook workBookCopy = packageCopy.Workbook;
                    //            ExcelWorksheet worksheetCopy = workBookCopy.Worksheets.First();
                    //            for (int i = 0; i < 4; i++) //delete the last 4 columns
                    //            {
                    //                worksheetCopy.DeleteColumn(10); // For old formatting -> worksheetCopy.DeleteColumn(11);
                    //            }
                    //            var rangeCopy = worksheetCopy.Cells[2, 9, worksheetCopy.Dimension.End.Row, 9];
                    //            rangeCopy.Value = "";
                    //            packageCopy.SaveAs(new FileInfo(saveFileDialog1.FileName));
                    //        }

                    //        // Save a copy for RSSS use
                    //        using (ExcelPackage packageCopy = new ExcelPackage(new FileInfo(tempFile)))
                    //        {
                    //            ExcelWorkbook workBookCopy = packageCopy.Workbook;
                    //            ExcelWorksheet worksheetCopy = workBookCopy.Worksheets.First();
                    //            for (int i = 0; i < 1; i++) // for new formatting -> Delete the first column (Unit) ; for old formatting -> for (int i = 0; i < 2; i++) (Delete the first 2 columns)
                    //            {
                    //                worksheetCopy.DeleteColumn(1);
                    //            }
                    //            worksheetCopy.Cells[worksheet.Dimension.Address].AutoFitColumns();
                    //            worksheetCopy.Cells.AutoFitColumns();
                    //            worksheetCopy.Column(1).Width = 36; // adjust column width for "Name"
                    //            worksheetCopy.Column(3).Width = 6; // adjust column width for "Off Code Desc"
                    //            worksheetCopy.Column(4).Width = 20; // adjust column width for "Off Code Desc" 
                    //            worksheetCopy.Column(11).Width = 6; // adjust column width for off codes' true value 
                    //            worksheetCopy.Cells["I1:L1"].Merge = true;
                    //            worksheetCopy.Cells[1, 9].Value = "Pls. ignore these columns if they just only confuse you more :)";
                    //            worksheetCopy.Cells[1, 9].Style.Font.Size = 9;
                    //            worksheetCopy.Cells[1, 9].Style.Font.Bold = true;
                    //            worksheetCopy.Cells[1, 9].Style.Font.Italic = true;
                    //            worksheetCopy.Cells[1, 9].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    //            worksheetCopy.Column(11).Style.Font.Name = "Verdana";
                    //            worksheetCopy.Column(11).Style.Font.Size = 10;
                    //            worksheetCopy.Column(11).Style.Font.Italic = false;
                    //            lastCharPosition = saveFileDialog1.FileName.LastIndexOf('.');
                    //            packageCopy.SaveAs(new FileInfo(saveFileDialog1.FileName.Insert(lastCharPosition, " - for RSSS")));
                    //            System.Diagnostics.Process.Start(saveFileDialog1.FileName.Insert(lastCharPosition, " - for RSSS"));
                    //        }

                    //        // Delete the temp file
                    //        File.Delete(tempFile);
                    //        #endregion 
                    //    }
                    //}
                    #endregion

                    #region Old Formatting
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
                            _payPeriod = Common.GetPP(DateTime.ParseExact(_currDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture).AddDays(-1).ToString("yyyy-MM-dd"));
                        }
                        else
                        {
                            _payPeriod = Common.GetPP(_currDate);
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
                                worksheet.Row(i - 10).Height = 27;
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
                                worksheet.Cells[i - 10, 10].Value = SearchMethods.ChangeTo(currentWorksheet.Cells[i, 8].Value.ToString(), currentWorksheet.Cells[i, 7].Value.ToString().Trim(), Convert.ToDouble(worksheet.Cells[i - 10, 9].Value));

                                // Check for multiple primaries
                                worksheet.Cells[i - 10, 10].Value = worksheet.Cells[i - 10, 10].Value + Common.CheckIfMultiJob(worksheet.Cells[i - 10, 4].Value.ToString().Trim());

                                worksheet.Cells[i - 10, 10].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                worksheet.Cells[i - 10, 10].Style.Font.Italic = true;
                                worksheet.Cells[i - 10, 10].Style.Font.Color.SetColor(Color.Gray);
                                if (worksheet.Cells[i - 10, 10].Value.ToString().IndexOf('(') > -1) // check for opening parenthesis in column 10 for notes
                                {
                                    worksheet.Cells[i - 10, 10].Style.Font.Size = 8;
                                }

                                #region compute the split in timecard
                                // check if the unpaid code start with "(" ex (Aupe aux), else get the first 3 letters (ex. A24(M) => A24)
                                string _unpaidCode = "";
                                if (!worksheet.Cells[i - 10, 10].Value.ToString().StartsWith("(") && worksheet.Cells[i - 10, 10].Value.ToString().Length > 2)
                                {
                                    _unpaidCode = worksheet.Cells[i - 10, 10].Value.ToString().Substring(0, 3);
                                }

                                // Check for A48, don't process the split for those
                                if (worksheet.Cells[i - 10, 5].Value.ToString().Trim() == "A48")
                                {
                                    for (int i2 = 11; i2 < 15; i2++)
                                    {
                                        worksheet.Cells[i - 10, i2].Value = "-----";
                                    }
                                }
                                else
                                {
                                    string[] _split = GetTheSplit(worksheet.Cells[i - 10, 4].Value.ToString().Trim(), worksheet.Cells[i - 10, 5].Value.ToString().Trim(), _unpaidCode,
                                    Convert.ToDouble(worksheet.Cells[i - 10, 7].Value), Convert.ToDouble(worksheet.Cells[i - 10, 8].Value), Convert.ToDouble(worksheet.Cells[i - 10, 9].Value));

                                    for (int i2 = 11; i2 < _split.Length + 11; i2++)
                                    {
                                        worksheet.Cells[i - 10, i2].Value = _split[i2 - 11];
                                        worksheet.Cells[i - 10, i2].Style.Font.Color.SetColor(Color.FromArgb(135, 135, 135));
                                        worksheet.Cells[i - 10, i2].Style.Font.Italic = true;
                                        worksheet.Cells[i - 10, i2].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Dotted);
                                        worksheet.Cells[i - 10, i2].Style.Border.Top.Color.SetColor(Color.Gray);
                                        worksheet.Cells[i - 10, i2].Style.Border.Right.Color.SetColor(Color.Gray);
                                        worksheet.Cells[i - 10, i2].Style.Border.Bottom.Color.SetColor(Color.Gray);
                                        worksheet.Cells[i - 10, i2].Style.Border.Left.Color.SetColor(Color.Gray);
                                    }
                                }
                                #endregion

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


                        }

                        //worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                        //worksheet.Cells.AutoFitColumns();

                        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                        saveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                        saveFileDialog1.FilterIndex = 1;
                        saveFileDialog1.FileName = "Banks Compare";
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            #region Without Split Computation
                            //package2.SaveAs(new FileInfo(saveFileDialog1.FileName));
                            //System.Diagnostics.Process.Start(saveFileDialog1.FileName);
                            #endregion

                            #region With Split Computation
                            int lastCharPosition = saveFileDialog1.FileName.LastIndexOf('\\');
                            string tempFile = saveFileDialog1.FileName.Substring(0, lastCharPosition + 1) + "temp.xlsx";
                            package2.SaveAs(new FileInfo(tempFile));

                            // Save a copy to be use by SSO
                            using (ExcelPackage packageCopy = new ExcelPackage(new FileInfo(tempFile)))
                            {
                                ExcelWorkbook workBookCopy = packageCopy.Workbook;
                                ExcelWorksheet worksheetCopy = workBookCopy.Worksheets.First();
                                for (int i = 0; i < 4; i++) //delete the last 4 columns
                                {
                                    worksheetCopy.DeleteColumn(11);
                                }
                                var rangeCopy = worksheetCopy.Cells[2, 10, worksheetCopy.Dimension.End.Row, 10];
                                rangeCopy.Value = "";
                                packageCopy.SaveAs(new FileInfo(saveFileDialog1.FileName));
                            }

                            // Save a copy for RSSS use
                            using (ExcelPackage packageCopy = new ExcelPackage(new FileInfo(tempFile)))
                            {
                                ExcelWorkbook workBookCopy = packageCopy.Workbook;
                                ExcelWorksheet worksheetCopy = workBookCopy.Worksheets.First();
                                for (int i = 0; i < 2; i++) // Delete the first 2 columns
                                {
                                    worksheetCopy.DeleteColumn(1);
                                }
                                worksheetCopy.Cells[worksheet.Dimension.Address].AutoFitColumns();
                                worksheetCopy.Cells.AutoFitColumns();
                                worksheetCopy.Column(1).Width = 36; // adjust column width for "Name"
                                worksheetCopy.Column(3).Width = 6; // adjust column width for "Off Code Desc"
                                worksheetCopy.Column(4).Width = 20; // adjust column width for "Off Code Desc" 
                                worksheetCopy.Column(11).Width = 6; // adjust column width for off codes' true value 
                                worksheetCopy.Cells["I1:L1"].Merge = true;
                                worksheetCopy.Cells[1, 9].Value = "Pls. ignore these columns if they just only confuse you more :)";
                                worksheetCopy.Cells[1, 9].Style.Font.Size = 8;
                                worksheetCopy.Cells[1, 9].Style.Font.Bold = true;
                                worksheetCopy.Cells[1, 9].Style.Font.Italic = true;
                                worksheetCopy.Cells[1, 9].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                                worksheetCopy.Column(11).Style.Font.Name = "Verdana";
                                worksheetCopy.Column(11).Style.Font.Size = 10;
                                worksheetCopy.Column(11).Style.Font.Italic = false;
                                lastCharPosition = saveFileDialog1.FileName.LastIndexOf('.');
                                packageCopy.SaveAs(new FileInfo(saveFileDialog1.FileName.Insert(lastCharPosition, " - for RSSS")));
                                System.Diagnostics.Process.Start(saveFileDialog1.FileName.Insert(lastCharPosition, " - for RSSS"));
                            }

                            // Delete the temp file
                            File.Delete(tempFile);
                            #endregion 
                        }
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnBanks.LabelText = "Off Codes vs" + Environment.NewLine + "Banks";
                Cursor = Cursors.Default;
                Update();
            }
        }

        #region Async Code for ProcessBanks
        //private async void test()
        //{
        //    var _ret = await ProcessBanks("");
        //}

        //private async Task<ExcelPackage> ProcessBanks(string _fileName)
        //{
        //    ExcelPackage _ret = null;
        //    try
        //    {

        //        using (ExcelPackage package = new ExcelPackage(new FileInfo(_fileName)))
        //        {
        //            ExcelWorkbook workBook = package.Workbook;
        //            ExcelWorksheet currentWorksheet = workBook.Worksheets.First();

        //            int totalRows = currentWorksheet.Dimension.End.Row;
        //            int totalCols = currentWorksheet.Dimension.End.Column;

        //            using (ExcelPackage package2 = new ExcelPackage())
        //            {
        //                ExcelWorksheet worksheet = package2.Workbook.Worksheets.Add("System - Off Code vs Bank Hours");

        //                // Set Page Settings
        //                worksheet.PrinterSettings.Orientation = eOrientation.Landscape;
        //                worksheet.PrinterSettings.ShowGridLines = true;
        //                worksheet.PrinterSettings.HorizontalCentered = true;
        //                worksheet.PrinterSettings.TopMargin = (decimal)1.5 / 2.54M;
        //                worksheet.PrinterSettings.BottomMargin = (decimal)1.5 / 2.54M;
        //                worksheet.PrinterSettings.LeftMargin = (decimal)0.3 / 2.54M;
        //                worksheet.PrinterSettings.RightMargin = (decimal)0.3 / 2.54M;
        //                worksheet.PrinterSettings.HeaderMargin = (decimal)0.5 / 2.54M;
        //                worksheet.PrinterSettings.FooterMargin = (decimal)0.5 / 2.54M;
        //                worksheet.HeaderFooter.OddHeader.LeftAlignedText = DateTime.Now.ToString("ddMMMyyyy");

        //                string _currDate = DateTime.Today.ToString("yyyy-MM-dd");
        //                string _payPeriod = "";
        //                if (GetStartPP(_currDate) == _currDate)
        //                {
        //                    _payPeriod = GetPP(DateTime.ParseExact(_currDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture).AddDays(-1).ToString("yyyy-MM-dd"));
        //                }
        //                else
        //                {
        //                    _payPeriod = GetPP(_currDate);
        //                }

        //                worksheet.HeaderFooter.OddHeader.RightAlignedText = "Pay Period: " + _payPeriod;
        //                worksheet.HeaderFooter.OddHeader.CenteredText = "Off Codes vs Bank Hours";
        //                worksheet.HeaderFooter.OddFooter.RightAlignedText = string.Format("Page {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
        //                worksheet.View.PageBreakView = true;
        //                worksheet.PrinterSettings.FitToPage = true; worksheet.PrinterSettings.FitToWidth = 1; worksheet.PrinterSettings.FitToHeight = 0;
        //                worksheet.PrinterSettings.RepeatRows = new ExcelAddress("$1:$1");

        //                worksheet.Cells[1, 1].Value = "Site"; worksheet.Cells[1, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin); worksheet.Column(1).Width = 4.70;
        //                worksheet.Cells[1, 2].Value = "Unit"; worksheet.Cells[1, 2].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin); worksheet.Column(2).Width = 36.30;
        //                worksheet.Cells[1, 3].Value = "Name"; worksheet.Cells[1, 3].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin); worksheet.Column(3).Width = 35;
        //                worksheet.Cells[1, 4].Value = "Emp No."; worksheet.Cells[1, 4].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin); worksheet.Column(4).Width = 14;
        //                worksheet.Cells[1, 5].Value = ""; worksheet.Cells[1, 5].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin); worksheet.Column(5).Width = 5.40;
        //                worksheet.Cells[1, 6].Value = "Off Code"; worksheet.Cells[1, 6].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin); worksheet.Column(6).Width = 23;
        //                worksheet.Cells[1, 7].Value = "Off"; worksheet.Cells[1, 7].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin); worksheet.Column(7).Width = 8.40;
        //                worksheet.Cells[1, 8].Value = "Bank Hrs"; worksheet.Cells[1, 8].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin); worksheet.Column(8).Width = 9.3;
        //                worksheet.Cells[1, 9].Value = "Difference"; worksheet.Cells[1, 9].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin); worksheet.Column(9).Width = 10.7;
        //                worksheet.Cells[1, 10].Value = "Change To"; worksheet.Cells[1, 10].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin); worksheet.Column(10).Width = 12;

        //                var range = worksheet.Cells[1, 1, 1, 10];
        //                range.Style.Font.Bold = true;
        //                range.Style.Font.Size = 11;
        //                range.Style.Font.Name = "Arial";
        //                range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
        //                range.Style.Fill.BackgroundColor.SetColor(Color.LightBlue);

        //                for (int i = 12; i <= totalRows; i++)
        //                {
        //                    try
        //                    {
        //                        worksheet.Row(i - 10).Height = 25;
        //                        worksheet.Row(i - 10).Style.Font.Size = 12;
        //                        worksheet.Row(i - 10).Style.Font.Name = "Arial";
        //                        worksheet.Row(i - 10).Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

        //                        worksheet.Cells[i - 10, 1].Value = currentWorksheet.Cells[i, 1].Value.ToString().Trim(); worksheet.Cells[i - 10, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
        //                        worksheet.Cells[i - 10, 2].Value = currentWorksheet.Cells[i, 2].Value; worksheet.Cells[i - 10, 2].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
        //                        worksheet.Cells[i - 10, 3].Value = currentWorksheet.Cells[i, 5].Value.ToString().Trim(); worksheet.Cells[i - 10, 3].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
        //                        worksheet.Cells[i - 10, 4].Value = currentWorksheet.Cells[i, 7].Value; worksheet.Cells[i - 10, 4].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
        //                        worksheet.Cells[i - 10, 5].Value = currentWorksheet.Cells[i, 8].Value; worksheet.Cells[i - 10, 5].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
        //                        worksheet.Cells[i - 10, 6].Value = currentWorksheet.Cells[i, 9].Value; worksheet.Cells[i - 10, 6].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
        //                        worksheet.Cells[i - 10, 7].Value = currentWorksheet.Cells[i, 11].Value; worksheet.Cells[i - 10, 7].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
        //                        worksheet.Cells[i - 10, 8].Value = Math.Floor(Convert.ToDouble(currentWorksheet.Cells[i, 13].Value) * 100) / 100; worksheet.Cells[i - 10, 8].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
        //                        worksheet.Cells[i - 10, 9].Value = Math.Round(Convert.ToDouble(currentWorksheet.Cells[i, 11].Value) - (Math.Floor(Convert.ToDouble(currentWorksheet.Cells[i, 13].Value) * 100) / 100), 3); worksheet.Cells[i - 10, 9].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
        //                        worksheet.Cells[i - 10, 10].Value = SearchMethods.ChangeTo(currentWorksheet.Cells[i, 8].Value.ToString(), currentWorksheet.Cells[i, 7].Value.ToString().Trim());

        //                        // Check for multiple primaries
        //                        worksheet.Cells[i - 10, 10].Value = worksheet.Cells[i - 10, 10].Value + Common.CheckIfMultiJob(worksheet.Cells[i - 10, 4].Value.ToString().Trim());

        //                        worksheet.Cells[i - 10, 10].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
        //                        worksheet.Cells[i - 10, 10].Style.Font.Italic = true;
        //                        worksheet.Cells[i - 10, 10].Style.Font.Color.SetColor(Color.Gray);
        //                        if (worksheet.Cells[i - 10, 10].Value.ToString().IndexOf('(') > -1) // check for opening parenthesis in column 10 for notes
        //                        {
        //                            worksheet.Cells[i - 10, 10].Style.Font.Size = 8;
        //                        }

        //                        #region compute the split in timecard
        //                        // check if the unpaid code start with "(" ex (Aupe aux), else get the first 3 letters (ex. A24(M) => A24)
        //                        string _unpaidCode = "";
        //                        if (!worksheet.Cells[i - 10, 10].Value.ToString().StartsWith("(") && worksheet.Cells[i - 10, 10].Value.ToString().Length > 2)
        //                        {
        //                            _unpaidCode = worksheet.Cells[i - 10, 10].Value.ToString().Substring(0, 3);
        //                        }

        //                        string[] _split = GetTheSplit(worksheet.Cells[i - 10, 4].Value.ToString().Trim(), worksheet.Cells[i - 10, 5].Value.ToString().Trim(), _unpaidCode,
        //                            Convert.ToDouble(worksheet.Cells[i - 10, 7].Value), Convert.ToDouble(worksheet.Cells[i - 10, 8].Value), Convert.ToDouble(worksheet.Cells[i - 10, 9].Value));
        //                        for (int i2 = 11; i2 < _split.Length + 11; i2++)
        //                        {
        //                            worksheet.Cells[i - 10, i2].Value = _split[i2 - 11];
        //                            worksheet.Cells[i - 10, i2].Style.Font.Color.SetColor(Color.FromArgb(169, 169, 169));
        //                            worksheet.Cells[i - 10, i2].Style.Font.Italic = true;
        //                            worksheet.Cells[i - 10, i2].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Dotted);
        //                            worksheet.Cells[i - 10, i2].Style.Border.Top.Color.SetColor(Color.Gray);
        //                            worksheet.Cells[i - 10, i2].Style.Border.Right.Color.SetColor(Color.Gray);
        //                            worksheet.Cells[i - 10, i2].Style.Border.Bottom.Color.SetColor(Color.Gray);
        //                            worksheet.Cells[i - 10, i2].Style.Border.Left.Color.SetColor(Color.Gray);
        //                        }
        //                        #endregion


        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        throw new Exception(ex.Message);
        //                    }

        //                    if (worksheet.Cells[i - 10, 3].Value.ToString().ToUpper().IndexOf("MULTI") > -1)
        //                    {
        //                        range = worksheet.Cells[i - 10, 1, i - 10, 9];
        //                        range.Style.Font.Size = 11;
        //                        range.Style.Font.Bold = range.Style.Font.Italic = true;
        //                    }
        //                }
        //                _ret = package2;
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        _ret = null;
        //    }
        //    return _ret;
        //}
        #endregion

        private string[] GetTheSplit(string _empNo, string _offCode, string _unpaidCode, double _off, double _bnkHrs, double _diff)
        {
            string[] _ret = new string[] { "-----", "-----", "-----", "-----" }; //_ret[0] = date, _ret[1] = estimated raw value,  _ret[2] = actual value, _ret[3] = unpaid bal

            if (_offCode == "A06") return _ret;

            _off = Math.Round(_off, 2);
            _bnkHrs = Math.Round(_bnkHrs, 2);
            _diff = Math.Round(_diff, 2);

            // Check if its a Sick Time, then check for all sick time off codes in the timecard for the current pay period
            string _listOfOffCodes = "";
            if ("A15, A0K, A0L, A0M".Contains(_offCode))
            {
                _listOfOffCodes = "'A15','A0K','A0L','A0M'";
            }
            else // else just check the specific off code
            {
                _listOfOffCodes = "'" + _offCode + "'";
            }

            try
            {
                using (SqlConnection myConnection = new SqlConnection())
                {
                    myConnection.ConnectionString = Common.ESPServer; //@"Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=" + Application.StartupPath + @"\items.mdb;Uid=Admin;Pwd=;";
                    myConnection.Open();

                    SqlCommand myCommand = myConnection.CreateCommand();

                    myCommand.CommandText = "SELECT Round((datediff(MINUTE, tce.TCE_ShiftStartTime, tce.TCE_ShiftEndTime) / 60.0) - TCE_Quantity,2) as TimeDiff, " +
                                "Format(TCE.TCE_Date,'MMM-dd') as TCE_Date, TCE.TCE_Quantity FROM TimeCardEntry as tce " +
                                "JOIN paycode as pc on tce.TCE_PayCodeID = pc.pc_paycodeid  " +
                                "WHERE tce.TCE_TimeCardID =  " +
                                "(SELECT TC_TimeCardID FROM timecard WHERE " +
                                "TC_EmpID = (SELECT E_EmpID FROM emp WHERE E_EmpNbr = @_empNum)  " +
                                "AND TC_PayPeriodID = (SELECT PP_PayPeriodID FROM PayPeriod WHERE GETDATE()-3 between PP_StartDate AND PP_EndDate)) " +
                                "AND tce.TCE_EntryTypeInd IN(1, 2, 38, 70, 94, 166, 198, 262, 294) AND tce.TCE_PayCodeType = 2 " +
                                "AND pc.PC_Type = 2 AND pc.PC_Nbr IN (" + _listOfOffCodes + ") " +
                                "ORDER BY tce.tce_date, tce.TCE_DateEntered, TCE_ShiftStartTime";

                    myCommand.Parameters.AddWithValue("_empNum", _empNo);

                    SqlDataReader _dr = myCommand.ExecuteReader();

                    double _total = 0;
                    double _curr = 0;
                    double _prevTotal = 0;
                    string _offCodeSuffix = "  (" + _offCode + ")";

                    //if (_empNo == "01069999-0")
                    //{
                    //    ;
                    //}

                    bool _exitWhile = false;
                    while (_dr.Read())
                    {
                        if (_exitWhile)
                        {
                            _ret[3] += " ^";
                            break;
                        }
                        _off = Math.Round(Convert.ToDouble(_dr["TCE_Quantity"]), 2);
                        _curr = Convert.ToDouble(_dr["TCE_Quantity"]);
                        _total = Math.Round(_total + _curr, 2);
                        if (_bnkHrs < _total)
                        {
                            _ret[0] = _dr["TCE_Date"].ToString();
                            //if (_off % 7.75 == 0 && (_bnkHrs - _prevTotal) > 0)
                            //{
                            //    _ret[1] = Math.Round(((_bnkHrs - _prevTotal) + .5), 2) + _offCodeSuffix;
                            //}
                            //else if (_off % 11.08 == 0 && (_bnkHrs - _prevTotal) > 0)
                            //{
                            //    _ret[1] = Math.Round(((_bnkHrs - _prevTotal) + 1.17), 2) + _offCodeSuffix;
                            //}
                            //else if (_off % 11.25 == 0 && (_bnkHrs - _prevTotal) > 0)
                            //{
                            //    _ret[1] = Math.Round(((_bnkHrs - _prevTotal) + 1), 2) + _offCodeSuffix;
                            //}
                            if ((_bnkHrs - _prevTotal) > 0)
                            {
                                _ret[1] = Math.Round((_bnkHrs - _prevTotal) + Convert.ToDouble(_dr["TimeDiff"]), 2) + _offCodeSuffix;
                            }
                            //else if (_bnkHrs == 0)
                            //{
                            //    _ret[1] = "0 " + _offCodeSuffix;
                            //}
                            else
                            {
                                _ret[1] = "-----";
                            }
                            _ret[2] = Math.Round((_bnkHrs - _prevTotal), 2).ToString();
                            _ret[3] = Math.Round((_total - _bnkHrs), 2) + (_unpaidCode != "" ? "  (" + _unpaidCode + ")" : "");
                            _exitWhile = true;
                        }
                        _prevTotal = _total;
                    }
                }
            }
            catch
            {
                _ret = new string[] { "Err", "Err", "Err" };
            }

            return _ret;

        }

        // return blank string if not from NFP or not Inactive
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
                    _ret = "(New hire? Pls Check)";
                }

                // insert the EE in the list to check for previous NPF or previous INACTIVE
                using (SqlConnection _conn = new SqlConnection(Common.SystemsServer))
                {
                    _conn.Open();
                    using (SqlCommand _comm = _conn.CreateCommand())
                    {
                        _comm.CommandText = "SELECT EmpID FROM NFPChecking WHERE EmpID = @_empID AND CurrentStat = 0";
                        _comm.Parameters.AddWithValue("_empID", _empNo);
                        SqlDataReader _dr = _comm.ExecuteReader();
                        if (!_dr.HasRows)
                        {
                            _dr.Close();
                            _comm.Parameters.Clear();
                            _comm.CommandText = "INSERT INTO NFPChecking (Type, EmpID, Name, Prev_Unit, CurrentStat) VALUES (2, @_empID, @_name, @_prevUnit, 0)";
                            _comm.Parameters.AddWithValue("_empID", _empNo);
                            _comm.Parameters.AddWithValue("_name", GetEmpName(_empNo.Substring(0, 8)));
                            _comm.Parameters.AddWithValue("_prevUnit", _tcg);
                            _comm.ExecuteNonQuery();
                        }
                    }
                }
            }

            return _ret;
        }

        private void ProcessFile1(string _sourceFile)
        {
            try
            {
                string[] lines = File.ReadAllLines(_sourceFile);
                int _ctrProcessed = 0;
                int _ctrNFP = 0;
                foreach (string line in lines)
                {
                    string[] values = line.Split(',');
                    if (values.Count() == 38)
                    {
                        if (values[0] == "1" || (values[0] == "5" && values[32].Trim() != ""))
                        {
                            string _tcg = GetTCG(values[1]);
                            if (_tcg.ToUpper().Contains("NOT FOR PAYROLL") || _tcg.ToUpper().Contains("INACTIVE")) // check all those that their current Timecard Group is "Not for Payroll" or "INACTIVE"
                            {
                                _ctrNFP++;
                                using (SqlConnection _conn = new SqlConnection(Common.SystemsServer))
                                {
                                    _conn.Open();
                                    using (SqlCommand _comm = _conn.CreateCommand())
                                    {
                                        _comm.CommandText = "SELECT EmpID FROM NFPChecking WHERE EmpID = @_empID AND CurrentStat = 0";
                                        _comm.Parameters.AddWithValue("_empID", values[1]);
                                        SqlDataReader _dr = _comm.ExecuteReader();
                                        if (!_dr.HasRows)
                                        {
                                            _dr.Close();
                                            _comm.Parameters.Clear();
                                            _comm.CommandText = "INSERT INTO NFPChecking (Type, EmpID, Name, Prev_Unit, CurrentStat) VALUES (@_type, @_empID, @_name, @_prevUnit, 0)";
                                            _comm.Parameters.AddWithValue("_type", values[0]);
                                            _comm.Parameters.AddWithValue("_empID", values[1]);
                                            _comm.Parameters.AddWithValue("_name", GetEmpName(values[1].Substring(0, 8)));
                                            _comm.Parameters.AddWithValue("_prevUnit", _tcg);
                                            _ctrProcessed = _ctrProcessed + _comm.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                MessageBox.Show(_ctrNFP + " record(s) from File 1 are currently set as NFP or Inactive in ESP.\n\n" + _ctrProcessed + " record(s) were uploaded to the list.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProcessFile2(string _sourceFile, string _destFolder = "")
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
                    worksheet.HeaderFooter.OddHeader.RightAlignedText = "Pay Period: " + Common.GetPP(DateTime.Now.ToString("ddMMMyyyy"));
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
                        if (values.Count() == 38)
                        {
                            if (firstEmp)
                            {
                                firstEmp = false;
                                currEmp = values[1]; currUnit = values[20]; currOcc = values[21]; currStat = values[22]; currFTE = values[23];
                            }
                            else
                            {
                                if (currEmp.Substring(0, 8) != values[1].Substring(0, 8)) // change in empno first 8 digits w/o the record dash number
                                {
                                    if (empLineCtr == 1)
                                    {
                                        string _ret = CheckIfComingFromNFPOrInactive(currEmp);

                                        if (_ret != "")
                                        {
                                            worksheet.Cells[lineCtr - empLineCtr, 11].Value = _ret;
                                        }
                                        else
                                        {
                                            worksheet.Cells[lineCtr - empLineCtr, 11].Value = GetEmpName(currEmp.Substring(0, 8));
                                        }
                                    }
                                    else if (!ThersAChange)
                                    {
                                        string _ret = CheckIfComingFromNFPOrInactive(currEmp);

                                        if (_ret != "")
                                        {
                                            worksheet.Cells[lineCtr - empLineCtr, 11].Value = GetEmpName(currEmp.Substring(0, 8));
                                            worksheet.Cells[(lineCtr - empLineCtr) + 1, 11].Value = _ret; // put the _ret value on the next line
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
                                worksheet.Cells[lineCtr - empLineCtr, 11].Value = GetEmpName(values[1].Substring(0, 8));
                                worksheet.Cells[lineCtr, 7].Style.Font.Bold = true;
                                prevUnit = currUnit;
                                currUnit = values[20];
                                ThersAChange = true;

                                string _ret = CheckIfComingFromNFPOrInactive(values[1]);

                                if (_ret != "")
                                {
                                    worksheet.Cells[lineCtr - empLineCtr, 11].Value = GetEmpName(currEmp.Substring(0, 8));
                                    worksheet.Cells[(lineCtr - empLineCtr) + 1, 11].Value = _ret;
                                }
                                else
                                {
                                    changeInUnit = true;
                                }
                            }
                            if (currOcc != values[21]) // change in occupation
                            {
                                if (!ThersAChange) worksheet.Cells[lineCtr - empLineCtr, 11].Value = GetEmpName(values[1].Substring(0, 8));
                                worksheet.Cells[lineCtr, 8].Style.Font.Bold = true;
                                prevOcc = currOcc;
                                currOcc = values[21];
                                ThersAChange = true;

                                string _ret = CheckIfComingFromNFPOrInactive(values[1]);

                                if (_ret != "")
                                {
                                    worksheet.Cells[lineCtr - empLineCtr, 11].Value = GetEmpName(currEmp.Substring(0, 8));
                                    worksheet.Cells[(lineCtr - empLineCtr) + 1, 11].Value = _ret;
                                }
                                else
                                {
                                    changeInOcc = true;
                                }
                            }
                            if (currStat != values[22]) // change in status
                            {
                                if (!ThersAChange) worksheet.Cells[lineCtr - empLineCtr, 11].Value = "Status";
                                worksheet.Cells[lineCtr, 9].Style.Font.Bold = true;
                                currStat = values[22];
                                if (currFTE != values[23]) // Change in FTE
                                {
                                    if (!ThersAChange) worksheet.Cells[lineCtr - empLineCtr, 11].Value = "Status / FTE";
                                    worksheet.Cells[lineCtr, 10].Style.Font.Bold = true;
                                    currFTE = values[23];
                                }
                                ThersAChange = true;

                                string _ret = CheckIfComingFromNFPOrInactive(values[1]);

                                if (_ret != "")
                                {
                                    worksheet.Cells[lineCtr - empLineCtr, 11].Value = GetEmpName(currEmp.Substring(0, 8));
                                    worksheet.Cells[(lineCtr - empLineCtr) + 1, 11].Value = _ret;
                                }
                            }
                            if (currFTE != values[23]) // change in FTE
                            {
                                if (!ThersAChange) worksheet.Cells[lineCtr - empLineCtr, 11].Value = "FTE";
                                worksheet.Cells[lineCtr, 10].Style.Font.Bold = true;
                                currFTE = values[23];
                                ThersAChange = true;

                                string _ret = CheckIfComingFromNFPOrInactive(values[1]);

                                if (_ret != "")
                                {
                                    worksheet.Cells[lineCtr - empLineCtr, 11].Value = GetEmpName(currEmp.Substring(0, 8));
                                    worksheet.Cells[(lineCtr - empLineCtr) + 1, 11].Value = _ret;
                                }
                            }

                            #region AutoInsertInItemsReport                          
                            if (_uploadParams.uploadToItems)
                            {
                                if (changeInUnit)
                                {
                                    // InsertInItems return 0 = not successful; 1 = sucessfull; 2 = not inserted / already existing
                                    byte _ret = InsertInItems(new ChangeInUnitAndOrOcc
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
                                    });
                                    if (_ret == 1)
                                    {
                                        // values[0] = "(Unit Trns)";
                                        worksheet.Cells[lineCtr - empLineCtr, 1].Value = "(Unit Trns)";
                                    }
                                    else if (_ret == 2)
                                    {
                                        worksheet.Cells[lineCtr - empLineCtr, 11].Value = "(Prev. Entered)";
                                        worksheet.Cells[lineCtr - empLineCtr, 11].Style.Font.Size = 10;
                                        worksheet.Cells[lineCtr - empLineCtr, 11].Style.Font.Italic = true;
                                    }
                                }
                                else if (!changeInUnit && changeInOcc)
                                {
                                    // InsertInItems return 0 = not successful; 1 = sucessfull; 2 = not inserted / already existing
                                    byte _ret = InsertInItems(new ChangeInOcc
                                    {
                                        empNo = values[1].Trim(),
                                        unit = currUnit.Trim(),
                                        prevPosCode = prevOcc,
                                        currPosCode = currOcc,
                                        pp = _uploadParams.pp,
                                        ppYear = _uploadParams.ppYear,
                                        itemsReportLetter = _uploadParams.itemsReportLetter
                                    });
                                    if (_ret == 1)
                                    {
                                        //values[0] = "(Occ Chg)";
                                        worksheet.Cells[lineCtr - empLineCtr, 1].Value = "(Occ Chg)";
                                    }
                                    else if (_ret == 2)
                                    {
                                        worksheet.Cells[lineCtr - empLineCtr, 11].Value = "(Prev. Entered)";
                                        worksheet.Cells[lineCtr - empLineCtr, 11].Style.Font.Size = 10;
                                        worksheet.Cells[lineCtr - empLineCtr, 11].Style.Font.Italic = true;
                                    }
                                }
                            }

                            changeInUnit = changeInOcc = false;
                            #endregion

                            worksheet.Row(lineCtr).Height = 23;
                            worksheet.Row(lineCtr).Style.Font.Name = "Verdana";
                            worksheet.Row(lineCtr).Style.Font.Size = 11;
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

                    // Check if the last line is a one Liner, if it is then process it the same way as you normally process it
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

                    // Check if the last line is "No Change?"
                    if (!ThersAChange && empLineCtr > 1)
                    {
                        string _ret = CheckIfComingFromNFPOrInactive(currEmp);

                        if (_ret != "")
                        {
                            worksheet.Cells[lineCtr - empLineCtr, 11].Value = GetEmpName(currEmp.Substring(0, 8));
                            worksheet.Cells[lineCtr, 11].Value = _ret;
                        }
                        else
                        {
                            worksheet.Cells[lineCtr - empLineCtr, 11].Value = "(No change? Pls. Check)";
                        }
                    }

                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                    // Hide the column for the "POS" and "Prim"
                    worksheet.Column(3).Hidden = true;
                    worksheet.Column(4).Hidden = true;


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
                    worksheet.HeaderFooter.OddHeader.RightAlignedText = "Pay Period: " + Common.GetPP(DateTime.Now.ToString("ddMMMyyyy"));
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
                        if (values.Count() == 38)
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
                _payPeriod = Common.GetPP(DateTime.ParseExact(_currDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture).AddDays(-1).ToString("yyyy-MM-dd"));
            }
            else
            {
                _payPeriod = Common.GetPP(_currDate);
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
                    ProcessFile1(_destFolder + _fileName);
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
                _tempText = btnFile126.LabelText;
                btnFile126.LabelText = "Processing...";
                Cursor.Current = Cursors.WaitCursor;
                btnFile126.Update();

                GetFileListFromFTP();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR:");
            }
            finally
            {
                btnFile126.LabelText = _tempText;
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

        private void RFLOA_Rehire(string _headerCenter, string _headerRight, string _openFileTitle, BunifuTileButton _btn, string _path)
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

                _btn.LabelText = "Processing...";
                Cursor.Current = Cursors.WaitCursor;
                _btn.Update();

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
                    worksheet.HeaderFooter.OddHeader.LeftAlignedText = DateTime.Now.ToString("ddMMMyyyy hh:mm tt");
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
                                worksheet.Row(lineCtr).Height = 35;
                                worksheet.Row(lineCtr).Style.Font.Name = "Arial";
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
                _btn.LabelText = _origBtnText;
                Cursor.Current = Cursors.Default;
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
                btnPriors.LabelText = "Processing...";
                Cursor.Current = Cursors.WaitCursor;
                btnPriors.Update();

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

                btnPriors.LabelText = "Prior Pay Period Adj";
                Cursor.Current = Cursors.Default;
                Update();
            }
        }

        private bool IsSystemsMember(string _userName)
        {
            //List<string> systemMembers = new List<string>() { "YEGORNIKITIN", "SCOTTHASTINGS", "MIKAELMANAGAT", "ROTCHELOSANTOS", "DARWINDIZON", "BSANTOS", "LOURDESSHAHPORI", "ADELACRUZ02" };
            //return systemMembers.Contains(_userName.Trim().ToUpper());
            return Common.CheckUsers(_userName);
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
                btnAHS_AA_Terms.LabelText = "Processing...";
                Cursor.Current = Cursors.WaitCursor;
                btnAHS_AA_Terms.Update();

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
                    worksheet.HeaderFooter.OddHeader.LeftAlignedText = DateTime.Now.ToString("ddMMMyyyy HH:mm:ss");
                    worksheet.HeaderFooter.OddHeader.RightAlignedText = "PP " + Common.GetPP(DateTime.Now.ToString("ddMMMyyyy"));
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
                        if (row.GetCell(17).StringValue.Trim() == "001" || rowIndex == 1)
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

                            // Check if previously done
                            if (rowIndex > 1)
                            {
                                string _ret = GetTCG_ForTermsAndTrans(worksheet.Cells[outCurrRowIndex, 1].Value.ToString().Trim() + "-" + worksheet.Cells[outCurrRowIndex, 2].Value.ToString().Trim(), "TERMS");
                                if (_ret == "OK")
                                {
                                    worksheet.Cells[outCurrRowIndex, 2].Value = worksheet.Cells[outCurrRowIndex, 2].Value + " - PREV. DONE";
                                }
                            }

                            worksheet.Row(outCurrRowIndex).Height = 25;
                            outCurrRowIndex++;
                        }
                    }

                    // Delete the un-needed columns
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
                btnAHS_AA_Terms.LabelText = "AHS_AA_TERMS";
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
                btnTrans.LabelText = "Processing...";
                Cursor.Current = Cursors.WaitCursor;
                btnTrans.Update();

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
                    worksheet.HeaderFooter.OddHeader.LeftAlignedText = DateTime.Now.ToString("ddMMMyyyy HH:mm:ss");
                    worksheet.HeaderFooter.OddHeader.RightAlignedText = "PP " + Common.GetPP(DateTime.Now.ToString("ddMMMyyyy"));
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
                        if ((row.GetCell(7).StringValue.Trim() != "TRM" && row.GetCell(5).StringValue.Trim() == "001") || rowIndex == 1)
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

                            // Check if previously done
                            if (rowIndex > 1)
                            {
                                string _ret = GetTCG_ForTermsAndTrans(worksheet.Cells[outCurrRowIndex, 1].Value.ToString().Trim() + "-" + worksheet.Cells[outCurrRowIndex, 2].Value.ToString().Trim(), "TRANS");
                                if (_ret == "OK")
                                {
                                    worksheet.Cells[outCurrRowIndex, 2].Value = worksheet.Cells[outCurrRowIndex, 2].Value + " - PREV. DONE";
                                }
                            }

                            worksheet.Row(outCurrRowIndex).Height = 25;
                            outCurrRowIndex++;
                        }
                    }

                    // DELETE ALL THE UN-NEEDED COLUMNS
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
                btnTrans.LabelText = "AHS_AA_TRANSFER_RPT";
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

        private void btnClearLocks_Click(object sender, EventArgs e)
        {
            HideMe();
            frmClearLocks _frm = new frmClearLocks();
            _frm.ShowDialog();
            ShowMe();
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
                MessageBox.Show("Cannot Find 'ItemsReport.exe' in 'Automated Files' folder.", "Cannot Find File", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void mnuCopyEmpNum_Click(object sender, EventArgs e)
        {
            string _clipText = lstResult.Items[lstResult.SelectedIndex].ToString().Trim().Substring(0, 8);
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

        private void btnSickOnStat_Click(object sender, EventArgs e)
        {
            var _btn = (BunifuTileButton)sender;

            string _origBtnText = _btn.LabelText;

            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Title = "Select the file that came from ePeople";
                openFileDialog1.Filter = "XLS Files (.xls)|*.xls|CSV Files (.csv)|*.csv|All Files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;

                bool userClickedOK = openFileDialog1.ShowDialog() == DialogResult.OK;

                if (!userClickedOK) return;

                _btn.LabelText = "Processing...";
                Cursor.Current = Cursors.WaitCursor;
                _btn.Update();

                string[] lines = File.ReadAllLines(openFileDialog1.FileName);

                int _ctr = 0;
                using (SqlConnection myConnection = new SqlConnection())
                {
                    myConnection.ConnectionString = Common.BooServer;
                    myConnection.Open();

                    SqlCommand myCommand = myConnection.CreateCommand();

                    // clear the table 
                    myCommand.CommandText = "TRUNCATE TABLE CAL_EXCEL_SOURCE";
                    myCommand.ExecuteNonQuery();

                    foreach (string line in lines)
                    {
                        string[] values = line.Replace("\"", "").Split(',');
                        if (values.Count() == 13)
                        {
                            if (values[10] == "001")
                            {
                                myCommand.CommandText = "INSERT INTO CAL_EXCEL_SOURCE (ID, Name, [Rpt Dt], Quantity, Workgroup) VALUES (" +
                                    "@_id, @_name, @_rptDt, @_qty, @_workGroup)";
                                myCommand.Parameters.Clear();
                                myCommand.Parameters.AddWithValue("_id", values[0]);
                                myCommand.Parameters.AddWithValue("_name", values[2].Trim() + ", " + values[3].Trim());
                                myCommand.Parameters.AddWithValue("_rptDt", values[5]);
                                myCommand.Parameters.AddWithValue("_qty", values[8]);
                                myCommand.Parameters.AddWithValue("_workGroup", values[11]);
                                _ctr = _ctr + myCommand.ExecuteNonQuery();
                            }
                        }
                    }
                    myCommand.Dispose();
                    MessageBox.Show(_ctr + " record(s) uploaded to Boo Database\n\n[CAL_EXCEL_SOURCE table]", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _btn.LabelText = _origBtnText;
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnTL_SYS_Click(object sender, EventArgs e)
        {
            Workbook book;
            Worksheet sheet;

            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Title = "Please select the TL_SYS File";
                openFileDialog1.Filter = "Excel File (.xls)|*.xls|All Files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;

                bool userClickedOK = openFileDialog1.ShowDialog() == DialogResult.OK;

                if (!userClickedOK) return;
                btnTL_SYS.LabelText = "Processing...";
                Cursor.Current = Cursors.WaitCursor;
                btnTL_SYS.Update();

                book = Workbook.Load(openFileDialog1.FileName);
                sheet = book.Worksheets[0];

                //MessageBox.Show("sheet.Cells.FirstRowIndex=" + sheet.Cells.FirstRowIndex + ", sheet.Cells.LastRowIndex=" + sheet.Cells.LastRowIndex + "\n\r");

                using (var package = new ExcelPackage())
                {
                    // add a new worksheet to the empty workbook
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("For Payroll");

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
                    worksheet.HeaderFooter.OddHeader.RightAlignedText = "PP " + Common.GetPP(DateTime.Now.ToString("ddMMMyyyy"));
                    worksheet.HeaderFooter.OddHeader.CenteredText = "AHS_AA_EXCEPTION_TLSYS";
                    worksheet.View.PageBreakView = true;
                    worksheet.PrinterSettings.FitToPage = true; worksheet.PrinterSettings.FitToWidth = 1; worksheet.PrinterSettings.FitToHeight = 0;

                    int outCurrRowIndex = 2;

                    for (int rowIndex = sheet.Cells.FirstRowIndex + 2; rowIndex <= sheet.Cells.LastRowIndex; rowIndex++)
                    {
                        Row row = sheet.Cells.GetRow(rowIndex);

                        if (row.GetCell(10).StringValue.Trim() == "001")
                        {
                            worksheet.Row(outCurrRowIndex).Style.Font.Size = 10;
                            worksheet.Row(outCurrRowIndex).Style.Font.Name = "Arial Unicode MS";
                            worksheet.Row(outCurrRowIndex).Height = 20;
                            worksheet.Cells[outCurrRowIndex, 1].Value = row.GetCell(0).StringValue;
                            worksheet.Cells[outCurrRowIndex, 2].Value = row.GetCell(1).StringValue;
                            worksheet.Cells[outCurrRowIndex, 3].Value = row.GetCell(2).StringValue;
                            worksheet.Cells[outCurrRowIndex, 4].Value = row.GetCell(3).DateTimeValue.ToString("ddMMMyyyy");
                            worksheet.Cells[outCurrRowIndex, 5].Value = row.GetCell(7).StringValue;
                            worksheet.Cells[outCurrRowIndex, 6].Value = row.GetCell(9).StringValue;
                            worksheet.Cells[outCurrRowIndex, 7].Value = row.GetCell(11).StringValue;
                            worksheet.Cells[outCurrRowIndex, 8].Value = row.GetCell(12).StringValue;
                            worksheet.Cells[outCurrRowIndex, 9].Value = row.GetCell(13).StringValue;
                            worksheet.Cells[outCurrRowIndex, 10].Value = row.GetCell(15).StringValue;
                            worksheet.Cells[outCurrRowIndex, 11].Value = row.GetCell(16).StringValue;

                            outCurrRowIndex++;
                        }
                    }

                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                    worksheet.Cells.AutoFitColumns();

                    //Setting Header Style
                    worksheet.Row(1).Height = 25;
                    worksheet.Cells[1, 1].Value = "ID"; worksheet.Cells[1, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Double);
                    worksheet.Cells[1, 2].Value = "Empl Rcd#"; worksheet.Column(2).Width = 12; worksheet.Cells[1, 2].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Double);
                    worksheet.Cells[1, 3].Value = "Name"; worksheet.Cells[1, 3].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Double);
                    worksheet.Cells[1, 4].Value = "Rpt Dt"; worksheet.Cells[1, 4].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Double);
                    worksheet.Cells[1, 5].Value = "Msg Data1"; worksheet.Cells[1, 5].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Double);
                    worksheet.Cells[1, 6].Value = "TCD Group"; worksheet.Column(6).Width = 12; worksheet.Cells[1, 6].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Double);
                    worksheet.Cells[1, 7].Value = "User"; worksheet.Cells[1, 7].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Double);
                    worksheet.Cells[1, 8].Value = "Descr"; worksheet.Cells[1, 8].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Double);
                    worksheet.Cells[1, 9].Value = "Severity"; worksheet.Cells[1, 9].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Double);
                    worksheet.Cells[1, 10].Value = "TRC"; worksheet.Cells[1, 10].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Double);
                    worksheet.Cells[1, 11].Value = "Quantity"; worksheet.Cells[1, 11].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Double);
                    var range = worksheet.Cells[1, 1, 1, 11];
                    range.Style.Font.Bold = true;
                    range.Style.Font.Size = 10;
                    range.Style.Font.Name = "Arial Unicode MS";
                    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                    range.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    saveFileDialog1.FilterIndex = 1;
                    saveFileDialog1.FileName = openFileDialog1.FileName.Substring(openFileDialog1.FileName.LastIndexOf("\\") + 1) + " - Payroll.xlsx";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        package.SaveAs(new FileInfo(saveFileDialog1.FileName));
                        System.Diagnostics.Process.Start(saveFileDialog1.FileName);
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

                btnTL_SYS.LabelText = "TL_SYS";
                Cursor.Current = Cursors.Default;
                Update();
            }
        }

        private void btnAA_Exception_Click(object sender, EventArgs e)
        {
            Workbook book;
            Worksheet sheet;

            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Title = "Please select the AHS_AA_EXCEPTION File";
                openFileDialog1.Filter = "Excel File (.xls)|*.xls|All Files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;

                bool userClickedOK = openFileDialog1.ShowDialog() == DialogResult.OK;

                if (!userClickedOK) return;
                btnAA_Exception.LabelText = "Processing...";
                Cursor.Current = Cursors.WaitCursor;
                btnAA_Exception.Update();

                book = Workbook.Load(openFileDialog1.FileName);
                sheet = book.Worksheets[0];

                //MessageBox.Show("sheet.Cells.FirstRowIndex=" + sheet.Cells.FirstRowIndex + ", sheet.Cells.LastRowIndex=" + sheet.Cells.LastRowIndex + "\n\r");

                using (var package = new ExcelPackage())
                {
                    // add a new worksheet to the empty workbook
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("For Payroll");

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
                    worksheet.HeaderFooter.OddHeader.RightAlignedText = "PP " + Common.GetPP(DateTime.Now.ToString("ddMMMyyyy"));
                    worksheet.HeaderFooter.OddHeader.CenteredText = "AHS_AA_EXCEPTION";
                    worksheet.View.PageBreakView = true;
                    worksheet.PrinterSettings.FitToPage = true; worksheet.PrinterSettings.FitToWidth = 1; worksheet.PrinterSettings.FitToHeight = 0;

                    int outCurrRowIndex = 2;

                    for (int rowIndex = sheet.Cells.FirstRowIndex + 2; rowIndex <= sheet.Cells.LastRowIndex; rowIndex++)
                    {
                        Row row = sheet.Cells.GetRow(rowIndex);

                        if (row.GetCell(10).StringValue.Trim() == "001" && !IsSystemsMember(row.GetCell(11).StringValue.Trim().ToUpper()))
                        {
                            worksheet.Row(outCurrRowIndex).Style.Font.Size = 10;
                            worksheet.Row(outCurrRowIndex).Style.Font.Name = "Arial Unicode MS";
                            worksheet.Row(outCurrRowIndex).Height = 20;
                            worksheet.Cells[outCurrRowIndex, 1].Value = row.GetCell(0).StringValue;
                            worksheet.Cells[outCurrRowIndex, 2].Value = row.GetCell(1).StringValue;
                            worksheet.Cells[outCurrRowIndex, 3].Value = row.GetCell(2).StringValue;
                            worksheet.Cells[outCurrRowIndex, 4].Value = row.GetCell(3).DateTimeValue.ToString("ddMMMyyyy");
                            worksheet.Cells[outCurrRowIndex, 5].Value = row.GetCell(7).StringValue;
                            worksheet.Cells[outCurrRowIndex, 6].Value = row.GetCell(9).StringValue;
                            worksheet.Cells[outCurrRowIndex, 7].Value = row.GetCell(11).StringValue;
                            worksheet.Cells[outCurrRowIndex, 8].Value = row.GetCell(14).StringValue;
                            worksheet.Cells[outCurrRowIndex, 9].Value = row.GetCell(16).StringValue;
                            worksheet.Cells[outCurrRowIndex, 10].Value = row.GetCell(17).StringValue;

                            outCurrRowIndex++;
                        }
                    }

                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                    worksheet.Cells.AutoFitColumns();

                    //Setting Header Style
                    worksheet.Row(1).Height = 25;
                    worksheet.Cells[1, 1].Value = "ID"; worksheet.Cells[1, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Double);
                    worksheet.Cells[1, 2].Value = "Empl Rcd#"; worksheet.Column(2).Width = 12; worksheet.Cells[1, 2].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Double);
                    worksheet.Cells[1, 3].Value = "Name"; worksheet.Cells[1, 3].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Double);
                    worksheet.Cells[1, 4].Value = "Rpt Dt"; worksheet.Cells[1, 4].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Double);
                    worksheet.Cells[1, 5].Value = "Msg Data1"; worksheet.Cells[1, 5].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Double);
                    worksheet.Cells[1, 6].Value = "TCD Group"; worksheet.Column(6).Width = 12; worksheet.Cells[1, 6].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Double);
                    worksheet.Cells[1, 7].Value = "User"; worksheet.Cells[1, 7].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Double);
                    worksheet.Cells[1, 8].Value = "Severity"; worksheet.Cells[1, 8].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Double);
                    worksheet.Cells[1, 9].Value = "TRC"; worksheet.Cells[1, 9].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Double);
                    worksheet.Cells[1, 10].Value = "Quantity"; worksheet.Cells[1, 10].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Double);
                    var range = worksheet.Cells[1, 1, 1, 10];
                    range.Style.Font.Bold = true;
                    range.Style.Font.Size = 10;
                    range.Style.Font.Name = "Arial Unicode MS";
                    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                    range.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    saveFileDialog1.FilterIndex = 1;
                    saveFileDialog1.FileName = openFileDialog1.FileName.Substring(openFileDialog1.FileName.LastIndexOf("\\") + 1) + " - Payroll.xlsx";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        package.SaveAs(new FileInfo(saveFileDialog1.FileName));
                        System.Diagnostics.Process.Start(saveFileDialog1.FileName);
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

                btnAA_Exception.LabelText = "AA_EXCEPTION";
                Cursor.Current = Cursors.Default;
                Update();
            }
        }

        private void btnV_FireCategories_Click(object sender, EventArgs e)
        {
            if (File.Exists(@"\\jeeves.crha-health.ab.ca\rsss_systems\Operations - RSSS Systems Group\Automated Files\vFireCat.exe"))
            {
                WindowState = FormWindowState.Minimized;
                System.Diagnostics.Process.Start(@"\\jeeves.crha-health.ab.ca\rsss_systems\Operations - RSSS Systems Group\Automated Files\vFireCat.exe");
            }
            else
            {
                MessageBox.Show("Cannot Find 'vFireCat.exe' in 'Automated Files' folder.", "Cannot Find File", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnLOAwithNoRptTime_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Please select the 3 files you got from ePeople for the last 3 pay periods you want to process.\n\nThe filenames will be use as the data for the \"Pay Period\" column on the report.\n\nClick OK to continue.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Title = "Please select the 3 Excel file";
                openFileDialog1.Filter = "Excel File (.xls)|*.xls|All Files (*.*)|*.*";
                openFileDialog1.Multiselect = true;
                openFileDialog1.FilterIndex = 1;

                bool userClickedOK = openFileDialog1.ShowDialog() == DialogResult.OK;

                if (!userClickedOK) return;

                //check if 3 files were selected
                if (openFileDialog1.FileNames.Count() != 3)
                {
                    MessageBox.Show("Please select 3 files.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                btnLOAwithNoRptTime.LabelText = "Processing...";
                Cursor.Current = Cursors.WaitCursor;
                btnLOAwithNoRptTime.Update();

                using (var package = new ExcelPackage())
                {
                    // add a new worksheet to the empty workbook
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("For SSC");

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
                    //worksheet.HeaderFooter.OddHeader.RightAlignedText = "PP " + GetPP(DateTime.Now.ToString("ddMMMyyyy"));
                    worksheet.HeaderFooter.OddHeader.CenteredText = "AHS_AA_RPTD_NO_TIME";
                    worksheet.View.PageBreakView = true;
                    worksheet.PrinterSettings.FitToPage = true; worksheet.PrinterSettings.FitToWidth = 1; worksheet.PrinterSettings.FitToHeight = 0;

                    Workbook book;
                    Worksheet sheet;

                    List<string[]> _data = new List<string[]>();

                    for (int i = 0; i < openFileDialog1.FileNames.Count(); i++)
                    {
                        book = Workbook.Load(openFileDialog1.FileNames[i]);
                        sheet = book.Worksheets[0];

                        for (int rowIndex = sheet.Cells.FirstRowIndex + 2; rowIndex <= sheet.Cells.LastRowIndex; rowIndex++)
                        {
                            Row row = sheet.Cells.GetRow(rowIndex);

                            if (row.GetCell(6).StringValue.Trim() == "001")
                            {

                                _data.Add(new string[] {
                                    row.GetCell(1).StringValue,
                                    row.GetCell(2).StringValue,
                                    row.GetCell(3).StringValue,
                                    row.GetCell(5).StringValue,
                                    row.GetCell(8).StringValue,
                                    Path.GetFileNameWithoutExtension(openFileDialog1.FileNames[i])
                                });
                            }
                        }
                    }

                    book = null;
                    sheet = null;

                    var _items = _data.OrderBy(r => r[4]).ToList();

                    int outCurrRowIndex = 2;
                    for (int i = 0; i < _data.Count; i++)
                    {
                        worksheet.Row(outCurrRowIndex).Style.Font.Size = 10;
                        worksheet.Row(outCurrRowIndex).Style.Font.Name = "Arial Unicode MS";
                        worksheet.Row(outCurrRowIndex).Height = 20;
                        worksheet.Cells[outCurrRowIndex, 1].Value = _items[i][0];
                        worksheet.Cells[outCurrRowIndex, 2].Value = _items[i][1];
                        worksheet.Cells[outCurrRowIndex, 3].Value = _items[i][2];
                        worksheet.Cells[outCurrRowIndex, 4].Value = _items[i][3];
                        worksheet.Cells[outCurrRowIndex, 5].Value = _items[i][4];
                        worksheet.Cells[outCurrRowIndex, 6].Value = _items[i][5]; ;

                        outCurrRowIndex++;
                    }

                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                    worksheet.Cells.AutoFitColumns();

                    //Setting Header Style
                    worksheet.Row(1).Height = 25;
                    worksheet.Cells[1, 1].Value = "ID"; worksheet.Cells[1, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Double);
                    worksheet.Cells[1, 2].Value = "Empl Rcd#"; worksheet.Column(2).Width = 12; worksheet.Cells[1, 2].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Double);
                    worksheet.Cells[1, 3].Value = "Name"; worksheet.Cells[1, 3].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Double);
                    worksheet.Cells[1, 4].Value = "LOA Type"; worksheet.Cells[1, 4].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Double);
                    worksheet.Cells[1, 5].Value = "TCD Group Name"; worksheet.Cells[1, 5].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Double);
                    worksheet.Cells[1, 6].Value = "Pay Period"; worksheet.Column(6).Width = 12; worksheet.Cells[1, 6].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Double);
                    var range = worksheet.Cells[1, 1, 1, 6];
                    range.Style.Font.Bold = true;
                    range.Style.Font.Size = 10;
                    range.Style.Font.Name = "Arial Unicode MS";
                    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.Yellow);
                    range.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    saveFileDialog1.FilterIndex = 1;
                    saveFileDialog1.FileName = "LOA With No Time Reported " + DateTime.Today.ToString("ddMMMyyyy") + " PP  - for SSC.xlsx";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        package.SaveAs(new FileInfo(saveFileDialog1.FileName));
                        System.Diagnostics.Process.Start(saveFileDialog1.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message +
                    "\n\r\n\rPlease try open the files first in Excel and \"Enable Editing\" and then save it then try to open the files again.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLOAwithNoRptTime.LabelText = @"AHS_AA_RPTD_" + Environment.NewLine + "NO_TIME";
                Cursor.Current = Cursors.Default;
                Update();
            }
        }

        private void txtUnit_TextChanged(object sender, EventArgs e)
        {
            _searchMode = 3;
            btnSendEmail.Enabled = txtTCG.Visible = false;

            if (txtUnit.Text.Trim().Length == 0)
            {
                lstResult.Items.Clear();
                return;
            }

            if (txtUnit.Text.Trim().Length < 2) return;

            lblMsg.Text = "Please wait...";
            Update();

            OpenConnection();

            _comm.CommandText = "select U_desc + ' | ' + Rtrim(LTrim(U_ShortDesc)) AS Units from unit where " +
                "(UPPER(U_Desc) LIKE @_SearchStr OR UPPER(U_ShortDesc) LIKE @_SearchStr) AND U_Active = 1 order by U_Desc";

            _comm.Parameters.Add(new SqlParameter("_SearchStr", "%" + txtUnit.Text.Trim().ToUpper() + "%"));
            SqlDataReader _reader = _comm.ExecuteReader();
            if (_reader.HasRows)
            {
                lstResult.Items.Clear();
                while (_reader.Read())
                {
                    lstResult.Items.Add(_reader["Units"].ToString());
                }
            }
            else
            {
                lstResult.Items.Clear();
            }
            _reader.Close();

            CloseConnection();

            lblMsg.Text = lstResult.Items.Count + " record(s) found.";
            Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnUploadFile1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Please select the file that contains type 1 demo data";
            openFileDialog1.Filter = "CSV Files (.csv)|*.csv|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            bool userClickedOK = openFileDialog1.ShowDialog() == DialogResult.OK;

            if (!userClickedOK) return;

            ProcessFile1(openFileDialog1.FileName);
        }

        private void btnESPbatchAccess_Click(object sender, EventArgs e)
        {
            HideMe();
            frmESPbatchAccess _frm = new frmESPbatchAccess();
            _frm.ShowDialog();
            ShowMe();
        }

        private void btnEmailNegStat_Click(object sender, EventArgs e)
        {
            try
            {
                btnEmailNegStat.LabelText = "Processing...";
                Cursor.Current = Cursors.WaitCursor;
                btnEmailNegStat.Update();

                // Open the file from Time and Labour
                MessageBox.Show("Select the Excel file that came from Time and Labour that contains the list of EE with negative stat banks.\n\nClick OK to continue.", "Select the Excel file", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Title = "Please select the Excel file that came from Time and Labour";
                openFileDialog1.Filter = "Excel Files (.xlsx)|*.xlsx|All Files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;

                bool userClickedOK = openFileDialog1.ShowDialog() == DialogResult.OK;

                if (!userClickedOK) return;

                string _timeAndLabourFile = openFileDialog1.FileName;

                // Open the file from Linh or SSRS
                MessageBox.Show("Now, select the Excel file that came from SSRS that contains the list of EE with \"Rotation-Statutory-On\".\n\nClick OK to continue.", "Select the Excel file", MessageBoxButtons.OK, MessageBoxIcon.Information);
                openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Title = "Please select the Excel file that came from SSRS";
                openFileDialog1.Filter = "Excel Files (.xlsx)|*.xlsx|All Files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;

                userClickedOK = openFileDialog1.ShowDialog() == DialogResult.OK;

                if (!userClickedOK) return;

                string _ssrsFile = openFileDialog1.FileName;

                List<string> _withRotationalShifts = new List<string>();
                List<string> _finalList = new List<string>();
                List<string[]> _data = new List<string[]>();

                // load  the list of ee with rotational shifts
                using (ExcelPackage package = new ExcelPackage(new FileInfo(_ssrsFile)))
                {
                    ExcelWorkbook workBook = package.Workbook;
                    ExcelWorksheet currentWorksheet = workBook.Worksheets.First();

                    int totalRows = currentWorksheet.Dimension.End.Row;
                    int totalCols = currentWorksheet.Dimension.End.Column;

                    for (int i = 2; i <= totalRows; i++)
                    {
                        _withRotationalShifts.Add(currentWorksheet.Cells[i, 1].Value.ToString().Trim());
                    }
                }

                using (ExcelPackage package = new ExcelPackage(new FileInfo(_timeAndLabourFile)))
                {
                    ExcelWorkbook workBook = package.Workbook;
                    ExcelWorksheet currentWorksheet = workBook.Worksheets["CAL"];

                    int totalRows = currentWorksheet.Dimension.End.Row;
                    int totalCols = currentWorksheet.Dimension.End.Column;

                    for (int i = 2; i <= totalRows; i++)
                    {
                        if (currentWorksheet.Cells[i, 3].Value != null && currentWorksheet.Cells[i, 16].Value != null &&
                            (_withRotationalShifts.SingleOrDefault(empIdToCheck => empIdToCheck.Contains(currentWorksheet.Cells[i, 3].Value.ToString().Trim())) == null) &&
                            (_finalList.SingleOrDefault(empIdToCheck => empIdToCheck.Contains(currentWorksheet.Cells[i, 3].Value.ToString().Trim())) == null))
                        {
                            try
                            {

                                string _tcg = GetTCG(currentWorksheet.Cells[i, 3].Value.ToString().Trim());

                                if (!_tcg.ToUpper().Contains("NOT FOR PAYROLL")) // Exclude NFPs
                                {
                                    _data.Add(new string[] {
                                            currentWorksheet.Cells[i, 3].Value != null ? currentWorksheet.Cells[i, 3].Value.ToString().Trim() : "",     // EMP ID
                                            currentWorksheet.Cells[i, 4].Value != null ? currentWorksheet.Cells[i, 4].Value.ToString().Trim() : "",     // Name
                                            currentWorksheet.Cells[i, 15].Value != null ? currentWorksheet.Cells[i, 15].Value.ToString().Trim() : "",   // Manager Name
                                            currentWorksheet.Cells[i, 16].Value != null ? currentWorksheet.Cells[i, 16].Value.ToString().Trim() : "",   // Manager Emai Address
                                            currentWorksheet.Cells[i, 10].Value != null ? Convert.ToDateTime(currentWorksheet.Cells[i, 10].Value).ToString("dd-MMM-yyyy") : "",     // Date Of Incident
                                            currentWorksheet.Cells[i, 11].Value != null ? currentWorksheet.Cells[i, 11].Value.ToString().Trim() : "",   // End Balance
                                            _tcg    // Timecard Group
                                        });
                                }

                                _finalList.Add(currentWorksheet.Cells[i, 3].Value.ToString().Trim());

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(i + ex.Message);
                                return;
                            }
                        }
                    }
                }

                using (ExcelPackage package2 = new ExcelPackage())
                {
                    ExcelWorksheet worksheet = package2.Workbook.Worksheets.Add("CAL - Filtered List");

                    worksheet.Cells[1, 1].Value = "Emp ID"; worksheet.Cells[1, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin); worksheet.Column(1).Width = 4.70;
                    worksheet.Cells[1, 2].Value = "Name"; worksheet.Cells[1, 2].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin); worksheet.Column(2).Width = 36.30;
                    worksheet.Cells[1, 3].Value = "Manager Name"; worksheet.Cells[1, 3].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin); worksheet.Column(3).Width = 35;
                    worksheet.Cells[1, 4].Value = "Manager Email Address"; worksheet.Cells[1, 4].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin); worksheet.Column(4).Width = 14;
                    worksheet.Cells[1, 5].Value = "Last Reported Date"; worksheet.Cells[1, 5].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin); worksheet.Column(5).Width = 7.40;
                    worksheet.Cells[1, 6].Value = "End Balance"; worksheet.Cells[1, 6].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin); worksheet.Column(6).Width = 9.40;
                    worksheet.Cells[1, 7].Value = "Unit"; worksheet.Cells[1, 7].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin); worksheet.Column(7).Width = 5.40;

                    var range = worksheet.Cells[1, 1, 1, 7];
                    range.Style.Font.Bold = true;
                    range.Style.Font.Size = 11;
                    range.Style.Font.Name = "Arial";
                    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.LightBlue);

                    //currentWorksheet.Cells[i, 3].Value.ToString().Trim()

                    List<string[]> _items = _data.OrderBy(r => r[6]).ThenBy(r => r[1]).ToList();
                    _data.Clear(); _data = null; // clear the content to free up memory

                    int _currentOutRow = 2;
                    for (int i = 0; i < _items.Count; i++)
                    {

                        worksheet.Row(_currentOutRow).Height = 17;
                        worksheet.Row(_currentOutRow).Style.Font.Size = 9;
                        worksheet.Row(_currentOutRow).Style.Font.Name = "Arial";
                        worksheet.Row(_currentOutRow).Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                        worksheet.Cells[_currentOutRow, 1].Value = _items[i][0]; worksheet.Cells[_currentOutRow, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        worksheet.Cells[_currentOutRow, 2].Value = _items[i][1]; worksheet.Cells[_currentOutRow, 2].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        worksheet.Cells[_currentOutRow, 3].Value = _items[i][2]; worksheet.Cells[_currentOutRow, 3].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        worksheet.Cells[_currentOutRow, 4].Value = _items[i][3]; worksheet.Cells[_currentOutRow, 4].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        worksheet.Cells[_currentOutRow, 5].Value = _items[i][4]; worksheet.Cells[_currentOutRow, 5].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        worksheet.Cells[_currentOutRow, 6].Value = _items[i][5]; worksheet.Cells[_currentOutRow, 6].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        worksheet.Cells[_currentOutRow, 7].Value = _items[i][6]; worksheet.Cells[_currentOutRow, 7].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        _currentOutRow++;
                    }

                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                    worksheet.Cells.AutoFitColumns();

                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    saveFileDialog1.FilterIndex = 1;
                    saveFileDialog1.FileName = "Neg Stat Mail Merge";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        package2.SaveAs(new FileInfo(saveFileDialog1.FileName));
                        System.Diagnostics.Process.Start(saveFileDialog1.FileName);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                btnEmailNegStat.LabelText = "Format Negative Stats";
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnUserLatestLogin_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                HideMe();
                this.TopMost = false;
                frmUsers _frm = new frmUsers();
                _frm.ShowDialog();
                this.TopMost = true;
                ShowMe();
            }
        }

        private void btnUserLatestLogin_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                HideMe();
                frmLatestLogin _frm = new frmLatestLogin();
                _frm.ShowDialog();
                ShowMe();
            }
        }

        private void btnFormatTAER_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Title = "Select the TAER file from ePeople";
                openFileDialog1.Filter = "XLS Files (.xls)|*.xls|CSV Files (.csv)|*.csv|All Files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;

                bool userClickedOK = openFileDialog1.ShowDialog() == DialogResult.OK;

                if (!userClickedOK)
                {
                    return;
                }

                HideMe();
                frmPPandStartDate _frm = new frmPPandStartDate();
                if (_frm.ShowDialog() == DialogResult.Cancel)
                {
                    ShowMe();
                    return;
                }
                string _pp = _frm.cboPP.SelectedItem.ToString().Substring(0, 5);
                DateTime _ppStartDate = DateTime.Parse(_frm.cboPP.SelectedItem.ToString().Substring(9, 12));
                bool isItFinalRun = _frm.chkFinal.Checked;
                ShowMe();


                ((BunifuTileButton)sender).LabelText = "Processing...";
                Cursor.Current = Cursors.WaitCursor;
                ((BunifuTileButton)sender).Update();

                List<string[]> _unknownError = new List<string[]>();
                List<string[]> _banks = new List<string[]>();
                List<string[]> _priors = new List<string[]>();
                List<string[]> _lowAndMedium = new List<string[]>();
                List<string[]> _Negatives = new List<string[]>();
                List<string[]> _Schedulers = new List<string[]>();
                List<string[]> _a1pAux = new List<string[]>();
                List<string[]> _actingPay = new List<string[]>();

                using (var package = new ExcelPackage())
                {
                    // add a new worksheet to the empty workbook
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Original");

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
                    worksheet.HeaderFooter.OddHeader.LeftAlignedText = DateTime.Now.ToString("ddMMMyyyy hh:mm tt");
                    worksheet.HeaderFooter.OddHeader.RightAlignedText = "";
                    worksheet.HeaderFooter.OddHeader.CenteredText = "";
                    worksheet.HeaderFooter.OddFooter.RightAlignedText = string.Format("Page {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
                    worksheet.View.PageBreakView = true;
                    worksheet.PrinterSettings.RepeatRows = new ExcelAddress("$1:$1");
                    worksheet.PrinterSettings.FitToPage = true; worksheet.PrinterSettings.FitToWidth = 1; worksheet.PrinterSettings.FitToHeight = 0;

                    //Setting Header Style
                    worksheet.Row(1).Height = 20;
                    worksheet.Cells[1, 1].Value = "Exception ID"; //worksheet.Column(2).Width = 12.30;
                    worksheet.Cells[1, 2].Value = "Empl ID"; //worksheet.Column(3).Width = 10.43; //worksheet.Column(3).AutoFit(); //
                    worksheet.Cells[1, 3].Value = "Empl Rcd#"; //worksheet.Column(4).Width = 22;
                    worksheet.Cells[1, 4].Value = "Rpt Dt"; //worksheet.Column(5).Width = 35;
                    worksheet.Cells[1, 5].Value = "Exception Status"; //worksheet.Column(6).Width = 35;
                    worksheet.Cells[1, 6].Value = "Severity"; //worksheet.Column(7).Width = 9.86; worksheet.Cells[1, 7].Style.WrapText = true;
                    worksheet.Cells[1, 7].Value = "Error Message"; //worksheet.Column(8).Width = 15;
                    worksheet.Cells[1, 8].Value = "DeptID"; //worksheet.Column(8).Width = 15;
                    worksheet.Cells[1, 9].Value = "Name"; //worksheet.Column(8).Width = 15;
                    worksheet.Cells[1, 10].Value = "TCD Group"; //worksheet.Column(8).Width = 15;
                    worksheet.Cells[1, 11].Value = "TCD Type";
                    var range = worksheet.Cells[1, 1, 1, 11];
                    range.Style.Font.Bold = true;
                    range.Style.Font.Size = 10;
                    range.Style.Font.Name = "Arial";

                    Workbook book = Workbook.Load(openFileDialog1.FileName);
                    Worksheet sheet = book.Worksheets[0];
                    int lineCtr = 2;

                    // Loop thru the Excel file from ePeople
                    for (int rowIndex = sheet.Cells.FirstRowIndex + 9; rowIndex <= sheet.Cells.LastRowIndex; rowIndex++)
                    {
                        Row row = sheet.Cells.GetRow(rowIndex);

                        if (row.GetCell(0).StringValue.Trim() != "")
                        {
                            worksheet.Row(lineCtr).Height = 20;
                            worksheet.Row(lineCtr).Style.Font.Name = "Arial";
                            worksheet.Row(lineCtr).Style.Font.Size = 10;
                            //worksheet.Row(lineCtr).Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                            worksheet.Cells[lineCtr, 1].Value = row.GetCell(0).StringValue;     // Exception ID
                            worksheet.Cells[lineCtr, 2].Value = row.GetCell(1).StringValue;     // Empl ID
                            worksheet.Cells[lineCtr, 3].Value = row.GetCell(2).StringValue;     // Rcd #
                            worksheet.Cells[lineCtr, 4].Value = Convert.ToDateTime(row.GetCell(3).DateTimeValue).ToString("yyyy/MM/dd");  //  Rpt Dt   
                            worksheet.Cells[lineCtr, 5].Value = row.GetCell(4).StringValue;     // Exception Status
                            worksheet.Cells[lineCtr, 6].Value = row.GetCell(5).StringValue;     // Severity
                            worksheet.Cells[lineCtr, 7].Value = row.GetCell(6).StringValue;     // Error Message
                            worksheet.Cells[lineCtr, 8].Value = row.GetCell(7).StringValue;     // Dept ID
                            worksheet.Cells[lineCtr, 9].Value = row.GetCell(8).StringValue;     // Name
                            worksheet.Cells[lineCtr, 10].Value = row.GetCell(9).StringValue;    // TCD Group   
                            worksheet.Cells[lineCtr, 11].Value = row.GetCell(10).StringValue;   // TCD Type
                            lineCtr++;

                            // Check if its Low and Medium
                            if (row.GetCell(6).StringValue.StartsWith("Report > 12hrs on Day:") ||
                                row.GetCell(6).StringValue.StartsWith("Greater than 16hrs Reg&OT") ||
                                row.GetCell(6).StringValue.StartsWith("Report  > 90hrs in period"))
                            {
                                _lowAndMedium.Add(new string[] {
                                    row.GetCell(1).StringValue,
                                    row.GetCell(2).StringValue,
                                    Convert.ToDateTime(row.GetCell(3).DateTimeValue).ToString("yyyy/MM/dd"),
                                    row.GetCell(4).StringValue,
                                    row.GetCell(5).StringValue,
                                    row.GetCell(6).StringValue,
                                    row.GetCell(7).StringValue,
                                    row.GetCell(8).StringValue,
                                    row.GetCell(9).StringValue.Substring(0, row.GetCell(9).StringValue.IndexOf("-")-1),
                                    row.GetCell(9).StringValue.Substring(row.GetCell(9).StringValue.IndexOf("-")+2)
                                });
                            }

                            // Check if A1P
                            else if ((row.GetCell(6).StringValue.StartsWith("A1P more than 7.75hrs reported") ||
                                    row.GetCell(6).StringValue.StartsWith("Invalid TRC Maximum")) &&
                                    Common.GetUnionGroup(row.GetCell(1).StringValue.Trim() + "-" + row.GetCell(2).StringValue.Trim()).StartsWith("AUPE Aux"))
                            {
                                _a1pAux.Add(new string[] {
                                    row.GetCell(1).StringValue,
                                    row.GetCell(2).StringValue,
                                    Convert.ToDateTime(row.GetCell(3).DateTimeValue).ToString("yyyy/MM/dd"),
                                    row.GetCell(4).StringValue,
                                    row.GetCell(5).StringValue,
                                    row.GetCell(6).StringValue,
                                    row.GetCell(7).StringValue,
                                    row.GetCell(8).StringValue,
                                    row.GetCell(9).StringValue.Substring(0, row.GetCell(9).StringValue.IndexOf("-")-1),
                                    row.GetCell(9).StringValue.Substring(row.GetCell(9).StringValue.IndexOf("-")+2)
                                });
                            }

                            // Check if its Priors
                            else if (Convert.ToDateTime(row.GetCell(3).DateTimeValue) < _ppStartDate)
                            {
                                _priors.Add(new string[] {
                                    row.GetCell(1).StringValue,
                                    row.GetCell(2).StringValue,
                                    Convert.ToDateTime(row.GetCell(3).DateTimeValue).ToString("yyyy/MM/dd"),
                                    row.GetCell(4).StringValue,
                                    row.GetCell(5).StringValue,
                                    row.GetCell(6).StringValue,
                                    row.GetCell(7).StringValue,
                                    row.GetCell(8).StringValue,
                                    row.GetCell(9).StringValue.Substring(0, row.GetCell(9).StringValue.IndexOf("-")-1),
                                    row.GetCell(9).StringValue.Substring(row.GetCell(9).StringValue.IndexOf("-")+2)
                                });
                            }

                            // Check if its Banks
                            else if (row.GetCell(6).StringValue.StartsWith("A1P -Coded Less Than Recommend") ||
                                    row.GetCell(6).StringValue.StartsWith("A1P more than 7.75hrs reported") ||
                                    row.GetCell(6).StringValue.StartsWith("Employee not associated to any Benefit Plan") ||
                                    row.GetCell(6).StringValue.StartsWith("Exceed Max Neg Hrs on Comp Pln") ||
                                    row.GetCell(6).StringValue.StartsWith("Payout Created For Term EE") ||
                                    row.GetCell(6).StringValue.StartsWith("Exceeds Maximum Banking Hours") ||
                                    row.GetCell(6).StringValue.StartsWith("Invalid Comp Time TRC/Comp Time Balance") ||
                                    row.GetCell(6).StringValue.StartsWith("Leave Balance is less than the allowed minimum balance") ||
                                    row.GetCell(6).StringValue.StartsWith("Negative Comp Time balance not allowed") ||
                                    row.GetCell(6).StringValue.StartsWith("Not enough comp bank balance"))
                            {
                                _banks.Add(new string[] {
                                    row.GetCell(1).StringValue,
                                    row.GetCell(2).StringValue,
                                    Convert.ToDateTime(row.GetCell(3).DateTimeValue).ToString("yyyy/MM/dd"),
                                    row.GetCell(4).StringValue,
                                    row.GetCell(5).StringValue,
                                    row.GetCell(6).StringValue,
                                    row.GetCell(7).StringValue,
                                    row.GetCell(8).StringValue,
                                    row.GetCell(9).StringValue.Substring(0, row.GetCell(9).StringValue.IndexOf("-")-1),
                                    row.GetCell(9).StringValue.Substring(row.GetCell(9).StringValue.IndexOf("-")+2)
                                });
                            }

                            // Check if its Schedulers
                            else if (row.GetCell(6).StringValue.StartsWith("Acting Hours less than 2") ||
                                    row.GetCell(6).StringValue.StartsWith("Acting JobCode outside Union") ||
                                    row.GetCell(6).StringValue.StartsWith("Invalid TRC") ||
                                    row.GetCell(6).StringValue.StartsWith("TRC not in TRC Table") ||
                                    row.GetCell(6).StringValue.StartsWith("Acting JobCode Same as Current") ||
                                    row.GetCell(6).StringValue.StartsWith("Employee Ineligible") ||
                                    row.GetCell(6).StringValue.StartsWith("Could not Determine Acting Pay"))
                            {
                                _Schedulers.Add(new string[] {
                                    row.GetCell(1).StringValue,
                                    row.GetCell(2).StringValue,
                                    Convert.ToDateTime(row.GetCell(3).DateTimeValue).ToString("yyyy/MM/dd"),
                                    row.GetCell(4).StringValue,
                                    row.GetCell(5).StringValue,
                                    row.GetCell(6).StringValue,
                                    row.GetCell(7).StringValue,
                                    row.GetCell(8).StringValue,
                                    row.GetCell(9).StringValue.Substring(0, row.GetCell(9).StringValue.IndexOf("-")-1),
                                    row.GetCell(9).StringValue.Substring(row.GetCell(9).StringValue.IndexOf("-")+2)
                                });
                            }

                            // Check if "Acting Pay Rate < Current Rate"
                            else if (row.GetCell(6).StringValue.StartsWith("Acting Pay Rate < Current Rate"))
                            {
                                _actingPay.Add(new string[] {
                                    row.GetCell(1).StringValue,
                                    row.GetCell(2).StringValue,
                                    Convert.ToDateTime(row.GetCell(3).DateTimeValue).ToString("yyyy/MM/dd"),
                                    row.GetCell(4).StringValue,
                                    row.GetCell(5).StringValue,
                                    row.GetCell(6).StringValue,
                                    row.GetCell(7).StringValue,
                                    row.GetCell(8).StringValue,
                                    row.GetCell(9).StringValue.Substring(0, row.GetCell(9).StringValue.IndexOf("-")-1),
                                    row.GetCell(9).StringValue.Substring(row.GetCell(9).StringValue.IndexOf("-")+2)
                                });
                            }

                            // Check if Negatives
                            else if (row.GetCell(6).StringValue.StartsWith("Negative Hours Reported"))
                            {
                                _Negatives.Add(new string[] {
                                    row.GetCell(1).StringValue,
                                    row.GetCell(2).StringValue,
                                    Convert.ToDateTime(row.GetCell(3).DateTimeValue).ToString("yyyy/MM/dd"),
                                    row.GetCell(4).StringValue,
                                    row.GetCell(5).StringValue,
                                    row.GetCell(6).StringValue,
                                    row.GetCell(7).StringValue,
                                    row.GetCell(8).StringValue,
                                    row.GetCell(9).StringValue.Substring(0, row.GetCell(9).StringValue.IndexOf("-")-1),
                                    row.GetCell(9).StringValue.Substring(row.GetCell(9).StringValue.IndexOf("-")+2)
                                });
                            }

                            // All Other Errors, put it in the "Unknown Error" tab
                            else
                            {
                                _unknownError.Add(new string[] {
                                    row.GetCell(1).StringValue,
                                    row.GetCell(2).StringValue,
                                    Convert.ToDateTime(row.GetCell(3).DateTimeValue).ToString("yyyy/MM/dd"),
                                    row.GetCell(4).StringValue,
                                    row.GetCell(5).StringValue,
                                    row.GetCell(6).StringValue,
                                    row.GetCell(7).StringValue,
                                    row.GetCell(8).StringValue,
                                    row.GetCell(9).StringValue.Substring(0, row.GetCell(9).StringValue.IndexOf("-")-1),
                                    row.GetCell(9).StringValue.Substring(row.GetCell(9).StringValue.IndexOf("-")+2)
                                });
                            }
                        }
                    }

                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                    AddTabInTAER(package, "Unknown Error", _pp, _unknownError, "OTHERS", false, isItFinalRun);
                    AddTabInTAER(package, "Banks", _pp, _banks, "OTHERS", true, isItFinalRun);
                    AddTabInTAER(package, "Priors", _pp, _priors, "PRIORS", true, isItFinalRun);
                    AddTabInTAER(package, "Low & Medium", _pp, _lowAndMedium, "OTHERS", false, isItFinalRun);
                    AddTabInTAER(package, "Negatives", _pp, _Negatives, "PRIORS", false, isItFinalRun);
                    AddTabInTAER(package, "Schedulers", _pp, _Schedulers, "OTHERS", true, isItFinalRun);
                    AddTabInTAER(package, "A1P Aux", _pp, _a1pAux, "OTHERS", false, isItFinalRun);
                    AddTabInTAER(package, "Acting Pay", _pp, _actingPay, "OTHERS", false, isItFinalRun);

                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    saveFileDialog1.FilterIndex = 1;
                    saveFileDialog1.FileName = "TAER " + DateTime.Today.ToString("ddMMMyyyy");
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
                ((BunifuTileButton)sender).LabelText = "Format TAER";
                Cursor.Current = Cursors.Default;
            }
        }

        private void AddTabInTAER(ExcelPackage package, string _title, string _payPeriod, List<string[]> _data, string _sortOrder, bool _legalPaper, bool _isItFinalRun)
        {
            // add a new worksheet to the empty workbook
            ExcelWorksheet _ws = package.Workbook.Worksheets.Add(_title);

            // Set Page Settings
            _ws.PrinterSettings.Orientation = eOrientation.Landscape;
            if (_legalPaper)
            {
                _ws.PrinterSettings.PaperSize = ePaperSize.Legal;
            }
            _ws.PrinterSettings.ShowGridLines = true;
            _ws.PrinterSettings.HorizontalCentered = true;
            _ws.PrinterSettings.TopMargin = (decimal)1.5 / 2.54M;
            _ws.PrinterSettings.BottomMargin = (decimal)1.5 / 2.54M;
            _ws.PrinterSettings.LeftMargin = (decimal)0.25 / 2.54M;
            _ws.PrinterSettings.RightMargin = (decimal)0.25 / 2.54M;
            _ws.PrinterSettings.HeaderMargin = (decimal)0.5 / 2.54M;
            _ws.PrinterSettings.FooterMargin = (decimal)0.5 / 2.54M;
            _ws.HeaderFooter.OddHeader.LeftAlignedText = DateTime.Now.ToString("ddMMMyyyy hh:mm tt");
            _ws.HeaderFooter.OddHeader.RightAlignedText = _payPeriod;
            _ws.HeaderFooter.OddHeader.CenteredText = _isItFinalRun ? "FINAL TAER - " + _title : "TAER - " + _title;
            _ws.HeaderFooter.OddFooter.RightAlignedText = string.Format("Page {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
            _ws.View.PageBreakView = true;
            _ws.PrinterSettings.RepeatRows = new ExcelAddress("$1:$1");
            _ws.PrinterSettings.FitToPage = true; _ws.PrinterSettings.FitToWidth = 1; _ws.PrinterSettings.FitToHeight = 0;

            //Setting Header Style
            _ws.Row(1).Height = 20;
            _ws.Cells[1, 1].Value = "Empl ID"; //_wsPriors.Column(3).Width = 10.43; //_wsPriors.Column(3).AutoFit(); //
            _ws.Cells[1, 2].Value = "Rcd#"; //_wsPriors.Column(4).Width = 22;
            _ws.Cells[1, 3].Value = "Rpt Dt"; //_wsPriors.Column(5).Width = 35;
            _ws.Cells[1, 4].Value = "Status"; //_wsPriors.Column(6).Width = 35;
            _ws.Cells[1, 5].Value = "Sev"; //_wsPriors.Column(7).Width = 9.86; _wsPriors.Cells[1, 7].Style.WrapText = true;
            _ws.Cells[1, 6].Value = "Error Message"; //_wsPriors.Column(8).Width = 15;
            _ws.Cells[1, 7].Value = "DeptID"; //_wsPriors.Column(8).Width = 15;
            _ws.Cells[1, 8].Value = "Name"; //_wsPriors.Column(8).Width = 15;
            _ws.Cells[1, 9].Value = "TCD#"; //_wsPriors.Column(8).Width = 15;
            _ws.Cells[1, 10].Value = "TCD Group Name";
            var range = _ws.Cells[1, 1, 1, 10];
            range.Style.Font.Bold = true;
            range.Style.Font.Size = 10;
            range.Style.Font.Name = "Arial";

            // Sort order for Priors
            List<string[]> _items;
            if (_sortOrder == "PRIORS") // By Error then by Group then by ID
            {
                _items = _data.OrderBy(r => r[5]).ThenBy(r => r[9]).ThenBy(r => r[0]).ToList();
            }
            else // By Group then By ID then by Date
            {
                _items = _data.OrderBy(r => r[9]).ThenBy(r => r[0]).ThenBy(r => r[2]).ToList();
            }

            int lineCtr = 2;

            for (int i = 0; i < _items.Count; i++)
            {
                _ws.Row(lineCtr).Style.Font.Size = 10;
                _ws.Row(lineCtr).Style.Font.Name = "Arial";
                _ws.Row(lineCtr).Height = 20;
                _ws.Row(lineCtr).Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                _ws.Cells[lineCtr, 1].Value = _items[i][0];
                _ws.Cells[lineCtr, 2].Value = _items[i][1];
                _ws.Cells[lineCtr, 3].Value = _items[i][2];
                _ws.Cells[lineCtr, 4].Value = _items[i][3];
                _ws.Cells[lineCtr, 5].Value = _items[i][4];
                _ws.Cells[lineCtr, 6].Value = _items[i][5];
                _ws.Cells[lineCtr, 7].Value = _items[i][6];
                _ws.Cells[lineCtr, 8].Value = _items[i][7];
                _ws.Cells[lineCtr, 9].Value = _items[i][8];
                _ws.Cells[lineCtr, 10].Value = _items[i][9];
                lineCtr++;
            }

            _ws.Cells[_ws.Dimension.Address].AutoFitColumns();
            _ws.Cells.AutoFitColumns();

            // adjust the column width 
            _ws.Column(2).Width = 5; // "Recd #"
            if (_legalPaper)
            {
                _ws.Column(4).Width = 26; // "Status"
            }
            else
            {
                _ws.Column(4).Width = 21; //"Status"
            }
            _ws.Column(5).Width = 4; // "Sev"
            _ws.Column(9).Width = 5; // "TCD #" 
        }
    }
}
