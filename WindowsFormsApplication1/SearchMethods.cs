using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SearchTool
{
    class SearchMethods
    {
        public static string dbServer = @"wssqlc015v02\esp8";

        public static string ChangeTo(string _code, string _EmpNum, double _diff)
        {
            string _ret = "";

            if (_diff == 0)
            {
                return "(Pls. Check)";
            }

            switch (_code.Trim())
            {
                case "A0K":
                case "A0M":
                case "A15":
                case "ASC":
                case "A0L":
                    _ret = CheckIfGSS(_EmpNum) ? "(Check if A0U)" : "A23";
                    break;
                case "A10":
                    _ret = "A24";
                    break;
                case "A5A":
                case "A0E":
                case "A1H":
                    _ret = "A09";
                    break;
                case "A48":
                    // Don't process A48 during Tue and Fri of Week 2
                    //long noOfDays = DateAndTime.DateDiff(DateInterval.Day, Convert.ToDateTime(SearchMethods.GetStartPPDate(DateTime.Today.AddDays(-3).ToString("yyyy-MM-dd"))), DateTime.Today);
                    //if (noOfDays > 12)
                    //{
                    //    _ret = "UrCall / A09";
                    //}
                    //else
                    //{
                    //    _ret = "(Leave It 4Now)";
                    //} 
                    _ret = "(Leave It 4Now)";
                    break;
                case "A1F":
                    _ret = "(Check VAC)";
                    break;
                case "A1P":
                    _ret = CheckIfAUPE_AUX(_EmpNum) ? "(AUPE Aux)" : "A09";
                    break;
                case "A5B":
                    //_ret = CheckIfAUPE(_EmpNum) ? "A09" : "(Not AUPE)";
                    //_ret = CheckIfAUPE_AUX(_EmpNum) ? "A09" : "(Not AUPE Aux)";
                    _ret = "(Invalid code)";
                    break;
                case "A06":
                    _ret = "-----";
                    break;
            }

            return _ret;
        }

        private static bool CheckIfUNA_HSAA(string _EmpNum)
        {
            SqlConnection _conn = new SqlConnection(Common.ESPServer);
            SqlCommand _comm = null;

            bool _ret;

            try
            {
                _conn.Open();
                _comm = _conn.CreateCommand();
                _comm.CommandText = "select uo_occID from unionocc where uo_occid in " +
                    "(select ep_occid from EmpPOsition where ep_empid = (select top 1 E_EmpID from emp where emp.e_empnbr = @V_SEARCH) " +
                    "and ep_todate >= @V_START_DATE_PP and ep_primaryind = 1) and UO_UnionID in (115, 112, 109, 114, 101, 102, 100)";
                // check table uniongroup, add 103, 104, 121 to add AUPE GSS in the filter

                _comm.Parameters.Add(new SqlParameter("V_SEARCH", _EmpNum));
                _comm.Parameters.Add(new SqlParameter("V_START_DATE_PP", GetStartPPDate(DateTime.Today.AddDays(-3).ToString("yyyy-MM-dd"))));
                SqlDataReader _reader = _comm.ExecuteReader();
                if (_reader.HasRows)
                {
                    _ret = true;
                }
                else
                {
                    _ret = false;
                }
                _reader.Dispose();
            }
            catch
            {
                _ret = true;
            }
            finally
            {
                if (_conn.State == System.Data.ConnectionState.Open)
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

            return _ret;
        }

        private static bool CheckIfAUPE_AUX(string _EmpNum)
        {
            SqlConnection _conn = new SqlConnection(Common.ESPServer);
            SqlCommand _comm = null;

            bool _ret;

            try
            {
                _conn.Open();
                _comm = _conn.CreateCommand();
                _comm.CommandText = "select uo_occID from unionocc where uo_occid in " +
                    "(select ep_occid from EmpPOsition where ep_empid = (select top 1 E_EmpID from emp where emp.e_empnbr = @V_SEARCH) " +
                    "and ep_todate >= @V_START_DATE_PP and ep_primaryind = 1) and UO_UnionID in (123, 106, 105)";
                // Check table uniongroup, include 121, 104, 103 if you want to include all AUPE
                _comm.Parameters.Add(new SqlParameter("V_SEARCH", _EmpNum));
                _comm.Parameters.Add(new SqlParameter("V_START_DATE_PP", GetStartPPDate(DateTime.Today.AddDays(-3).ToString("yyyy-MM-dd"))));
                SqlDataReader _reader = _comm.ExecuteReader();
                if (_reader.HasRows)
                {
                    _ret = true;
                }
                else
                {
                    _ret = false;
                }
                _reader.Dispose();
            }
            catch
            {
                _ret = true;
            }
            finally
            {
                if (_conn.State == System.Data.ConnectionState.Open)
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

            return _ret;
        }

        public static bool CheckIfGSS(string _EmpNum)
        {
            SqlConnection _conn = new SqlConnection(Common.ESPServer);
            SqlCommand _comm = null;

            bool _ret;

            try
            {
                _conn.Open();
                _comm = _conn.CreateCommand();
                _comm.CommandText = "select uo_occID from unionocc where uo_occid in " +
                    "(select ep_occid from EmpPosition where ep_empid = (select top 1 E_EmpID from emp where emp.e_empnbr = @V_SEARCH) " +
                    "and ep_todate >= @V_START_DATE_PP and ep_primaryind = 1 AND EP_FTERating > 0) and UO_UnionID in (121, 104, 103)";
                _comm.Parameters.Add(new SqlParameter("V_SEARCH", _EmpNum));
                _comm.Parameters.Add(new SqlParameter("V_START_DATE_PP", GetStartPPDate(DateTime.Today.AddDays(-3).ToString("yyyy-MM-dd"))));

                SqlDataReader _reader = _comm.ExecuteReader();

                //string temp; temp =  GetStartPPDate(DateTime.Today.ToString("yyyy-MM-dd"));

                //if (_EmpNum == "01030201" || _EmpNum == "01119963")
                //{                    

                //    _ret = true;
                //}

                if (_reader.HasRows)
                {
                    _ret = true;
                }
                else
                {
                    _ret = false;
                }
                _reader.Dispose();
            }
            catch
            {
                _ret = true;
            }
            finally
            {
                if (_conn.State == System.Data.ConnectionState.Open)
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

            return _ret;
        }

        public static string GetStartPPDate(string _date)
        {
            SqlConnection _conn = new SqlConnection(Common.ESPServer);
            SqlCommand _comm = null;

            string _ret = "";

            try
            {
                _conn.Open();
                _comm = _conn.CreateCommand();
                _comm.CommandText = "select Convert(varchar(10),PP_StartDate,23) as StartDate from payperiod where @V_DATE between pp_startdate and pp_enddate";
                _comm.Parameters.Add(new SqlParameter("V_DATE", _date));
                SqlDataReader _reader = _comm.ExecuteReader();
                if (_reader.HasRows)
                {
                    _reader.Read();
                    _ret = _reader["StartDate"].ToString();
                }

                _reader.Dispose();
            }
            catch
            {
                _ret = "";
            }
            finally
            {
                if (_conn.State == System.Data.ConnectionState.Open)
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

            return _ret;
        }

        public static string GetPPnumber(string _date)
        {
            SqlConnection _conn = new SqlConnection(Common.ESPServer);
            SqlCommand _comm = null;

            string _ret = "";

            try
            {
                _conn.Open();
                _comm = _conn.CreateCommand();
                _comm.CommandText = "select REPLACE(STR(PP_Nbr, 2), SPACE(1), '0') as PP from PayPeriod where @V_DATE between PP_StartDate and PP_EndDate";
                _comm.Parameters.Add(new SqlParameter("V_DATE", _date));
                SqlDataReader _reader = _comm.ExecuteReader();
                if (_reader.HasRows)
                {
                    _reader.Read();
                    _ret = _reader["PP"].ToString();
                }
                _reader.Dispose();
            }
            catch
            {
                _ret = "";
            }
            finally
            {
                if (_conn.State == System.Data.ConnectionState.Open)
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

            return _ret;
        }

        public static string GetPreviousPPStartDate(string _date)
        {
            SqlConnection _conn = new SqlConnection(Common.ESPServer);
            SqlCommand _comm = null;

            string _ret = "";

            try
            {
                _conn.Open();
                _comm = _conn.CreateCommand();
                _comm.CommandText = "select FORMAT(max(pp_startdate),'yyyy-MM-dd') from payperiod where PP_StartDate < " +
                    "(select PP_StartDate from PayPeriod where @V_DATE between PP_StartDate and PP_EndDate)";
                _comm.Parameters.Add(new SqlParameter("V_DATE", _date));
                SqlDataReader _reader = _comm.ExecuteReader();
                if (_reader.HasRows)
                {
                    _reader.Read();
                    _ret = _reader["StartDate"].ToString();
                }

                _reader.Dispose();
            }
            catch
            {
                _ret = "";
            }
            finally
            {
                if (_conn.State == System.Data.ConnectionState.Open)
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

            return _ret;
        }

        public static string[] GetUsersByName(string _searchStr)
        {
            SqlConnection _conn = new SqlConnection(Common.ESPServer);
            SqlCommand _comm = null;

            List<string> _tempStorage = new List<string>();
            string[] _ret;

            try
            {
                _conn.Open();
                _comm = _conn.CreateCommand();
                _comm.CommandText = "select CONCAT(US_USERID, ' - ', RTRIM(LTRIM(US_FULLNAME)),'  (Username: ',US_USERNAME,')') as NAME from users where UPPER(US_FULLNAME) LIKE @V_SEARCH ORDER BY US_FULLNAME";
                _comm.Parameters.Add(new SqlParameter("V_SEARCH", "%" + _searchStr + "%"));
                SqlDataReader _reader = _comm.ExecuteReader();
                if (_reader.HasRows)
                {
                    while (_reader.Read())
                    {
                        _tempStorage.Add(_reader["NAME"].ToString());
                    }
                }
                else
                {
                    _tempStorage.Add("ERROR: No Data Found.");
                }
                _reader.Dispose();
            }
            catch (Exception ex)
            {
                _tempStorage.Add("ERROR: " + ex.Message);
            }
            finally
            {
                if (_conn.State == System.Data.ConnectionState.Open)
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

            _ret = _tempStorage.ToArray();
            return _ret;
        }

        public static string[] GetUsersByEmpNo(string _searchStr)
        {
            SqlConnection _conn = new SqlConnection(Common.ESPServer);
            SqlCommand _comm = null;

            List<string> _tempStorage = new List<string>();
            string[] _ret;

            try
            {
                _conn.Open();
                _comm = _conn.CreateCommand();
                _comm.CommandText = "select CONCAT(US_USERID, ' - ', RTRIM(LTRIM(US_FULLNAME)),'  (Username: ',US_USERNAME,')') as NAME from users " +
                        "where US_BrowserEmpID IN (select E_EMPID from emp where E_EmpNbr LIKE @V_SEARCH)";
                _comm.Parameters.Add(new SqlParameter("V_SEARCH", "%" + _searchStr + "%"));
                SqlDataReader _reader = _comm.ExecuteReader();
                if (_reader.HasRows)
                {
                    while (_reader.Read())
                    {
                        _tempStorage.Add(_reader["NAME"].ToString());
                    }
                }
                else
                {
                    _tempStorage.Add("ERROR: No Data Found.");
                }
                _reader.Dispose();
            }
            catch (Exception ex)
            {
                _tempStorage.Add("ERROR: " + ex.Message);
            }
            finally
            {
                if (_conn.State == System.Data.ConnectionState.Open)
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

            _ret = _tempStorage.ToArray();
            return _ret;
        }

        public static string GetLatestLogin(string _userID)
        {
            SqlConnection _conn = new SqlConnection(Common.ESPServer);
            SqlCommand _comm = null;

            string _ret;

            try
            {
                _conn.Open();
                _comm = _conn.CreateCommand();
                _comm.CommandText = "select ISNULL(CONVERT(NVARCHAR,max(al_date),100),'NO DATA FOUND') as LATESTLOGIN  from auditlogin where al_userid = @V_SEARCH";
                _comm.Parameters.Add(new SqlParameter("V_SEARCH", _userID));
                SqlDataReader _reader = _comm.ExecuteReader();
                if (_reader.HasRows)
                {
                    _reader.Read();
                    _ret = "Last Login: " + _reader["LATESTLOGIN"].ToString();
                }
                else
                {
                    _ret = "-- No Data Found. --";
                }
                _reader.Dispose();
            }
            catch (Exception ex)
            {
                _ret = ex.Message;
            }
            finally
            {
                if (_conn.State == System.Data.ConnectionState.Open)
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

            return _ret;

        }
    }
}
