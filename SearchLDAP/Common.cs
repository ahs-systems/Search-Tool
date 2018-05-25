using System.Data.SqlClient;

namespace SearchLDAP
{
    public class Common
    {
        public static string EDM_Db = @"Server=wssqlc015v02\esp8; Database=esp_edm_prod;User Id=Espreport; Password=Esp4rep0rt;";
        public static string CAL_Db = @"Server=wssqlc015v02\esp8; Database=esp_cal_prod;User Id=Espreport; Password=Esp4rep0rt;";
        public static string NCS_Db = @"Server=wssqlc015v02\esp8; Database=esp_ncs_prod;User Id=Espreport; Password=Esp4rep0rt;";
        public static string BooServer = @"Server=wssqlc015V01.healthy.bewell.ca\esp8; Database=BOO;User Id=BOO_USER;Password=BOO_USER;";

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
                        if (_reader["AppID"].ToString() == "11")
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
    }
}
