using System.Data.SqlClient;

namespace PSSTool
{
    public class Common
    {
        public static string CAL_Db = @"Server=wssqlc015v02\esp8; Database=esp_cal_prod;User Id=BOO_USER; Password=BOO_USER;";
        public static string EDM_Db = @"Server=wssqlc015v02\esp8; Database=esp_edm_prod;User Id=BOO_USER; Password=BOO_USER;";
        public static string NCS_Db = @"Server=wssqlc015v02\esp8; Database=esp_ncs_prod;User Id=BOO_USER; Password=BOO_USER;";
        public static string BooServer = @"Server=wssqlc015V01.healthy.bewell.ca\esp8; Database=BOO;User Id=BOO_USER;Password=BOO_USER;";
        public static string SSRS_Interface_Prod = @"Server=wssqlc015V01.healthy.bewell.ca\esp8; Database=SSRS_Interface_Prod;User Id=BOO_USER;Password=BOO_USER;";


        public static string GetUsersZone(string _currentUser)
        {
            try
            {
                using (SqlConnection myConnection = new SqlConnection())
                {
                    string _ret = "";

                    myConnection.ConnectionString = Common.BooServer;
                    myConnection.Open();

                    SqlCommand myCommand = myConnection.CreateCommand();

                    myCommand.CommandText = "SELECT zone FROM AppUsers WHERE username = '" + _currentUser.ToUpper() + "' AND [status] = 1";

                    SqlDataReader myReader = myCommand.ExecuteReader();

                    if (myReader.HasRows)
                    {
                        while (myReader.Read())
                        {
                            _ret = _ret + myReader["zone"].ToString().Trim().ToUpper() + "','";
                        }

                        // remove the last "',"
                        _ret = "'" + _ret.Substring(0, _ret.Length - 2);
                    }

                    myCommand.Dispose();

                    return _ret;
                }
            }
            catch
            {
                return "";
            }
        }

        public static string GetZoneConnectionString(string _zone)
        {
            string _ret = "";

            switch (_zone.ToUpper())
            {
                case "CAL":
                    _ret = CAL_Db;
                    break;
                case "NCS":
                    _ret = NCS_Db;
                    break;
                case "EDM":
                    _ret = EDM_Db;
                    break;
            }

            return _ret;
        }

        public static string GetEmpName(string _empID, string _dbServer)
        {
            string _ret = "--- Name Not Found ---";
            try
            {
                using (SqlConnection myConnection = new SqlConnection(_dbServer))
                {
                    SqlCommand _comm = myConnection.CreateCommand();

                    myConnection.Open();

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
            catch (System.Exception)
            {
                _ret = "--- ERROR in Getting Emp Name ---";
            }
            return _ret;
        }

        public static bool LoadIt(string _appName, ref string _msg)
        {
            bool _ret = false;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(BooServer))
                {
                    SqlCommand _comm = myConnection.CreateCommand();

                    myConnection.Open();

                    _comm.CommandText = "SELECT AppID, Err from AppLists where UPPER(AppName) = @app";

                    _comm.Parameters.Clear();
                    _comm.Parameters.Add(new SqlParameter("app", _appName.ToUpper()));

                    SqlDataReader _reader = _comm.ExecuteReader();
                    if (_reader.HasRows)
                    {
                        _reader.Read();
                        if (_reader["AppID"].ToString() == "51")
                        {
                            _ret = true;
                        }
                        else
                        {
                            _msg = _reader["Err"].ToString();
                        }
                    }

                    _reader.Close();
                    _reader.Dispose();
                }
            }
            catch (System.Exception)
            {
                _ret = false;
            }
            return _ret;
        }

        public static bool CheckUsers(string _currentUser)
        {
            try
            {
                using (SqlConnection myConnection = new SqlConnection())
                {
                    bool _ret = false;

                    myConnection.ConnectionString = Common.BooServer;
                    myConnection.Open();

                    SqlCommand myCommand = myConnection.CreateCommand();

                    myCommand.CommandText = "SELECT username FROM AppUsers WHERE username = '" + _currentUser.ToUpper() + "' AND [status] = 1";

                    SqlDataReader myReader = myCommand.ExecuteReader();

                    // if found then it is a valid user
                    _ret = myReader.HasRows;

                    myCommand.Dispose();

                    return _ret;
                }
            }
            catch
            {
                return false;
            }
        }

        public static string GetTCG(string _empID, string _zone)
        {
            string _ret = "";

            using (SqlConnection _conn = new SqlConnection(GetZoneConnectionString(_zone)))
            {
                _conn.Open();

                SqlCommand _comm = _conn.CreateCommand();
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

                    //_comm.CommandText = "select tcg_desc from timecardgroup where tcg_tcardgroupid = " +
                    //    "(select tc_tcardgroupid from timecard where tc_empid = " + _retEmpID + " and " +
                    //    "tc_payperiodid = (select max(tc_payperiodid) from timecard where tc_empid = " + _retEmpID + "))";

                    _comm.CommandText = "SELECT TCG_Desc from TimeCardGroup where TCG_TCardGroupID =  " +
                                        "(select TOP 1 ETCI_TimeCardGroupID from EmpTimeCardInfo ETCI where ETCI_EmpID = " +
                                        "(select E_EmpID from emp where E_EmpNbr = @_empID) " +
                                        "AND ETCI_PayPeriodID <= (select PP_PayPeriodID from PayPeriod where getdate() between PP_StartDate and PP_EndDate) " +
                                        "ORDER BY ETCI_PayPeriodID DESC)";

                    _comm.Parameters.Clear();
                    _comm.Parameters.AddWithValue("_empID", _empID);
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
                    _ret = GetEmpName(_empID.Substring(0, 8), GetZoneConnectionString(_zone)); // Check if the name is already existing in ESP ,if it is then it means it is just INACTIVE
                    if (!_ret.ToUpper().Contains("NAME NOT FOUND"))
                    {
                        _ret = "--- INACTIVE ---";
                    }
                }

                _reader.Close();
            }

            return _ret;
        }
    }
}
