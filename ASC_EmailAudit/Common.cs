using System.Data.SqlClient;
using System.Windows.Forms;

namespace ASC_EmailAudit
{
    class Common
    {
        public static string ESPServerUsingLocalIdentity = @"Server=wssqlc015v02\esp8; Initial Catalog = esp_cal_prod; Integrated Security = SSPI;";
        public static string ESPServer = @"Server=wssqlc015v02\esp8; Database=esp_cal_prod;User Id=Espreport; Password=Esp4rep0rt;";
        public static string SystemsServer = @"Server=M292387\ESPSYSTEMS; Database=esp_systems;User Id=esp_systems;Password=esp_systems1;";
        public static string BooServer = @"Server=wssqlc015V01.healthy.bewell.ca\esp8; Database=BOO;User Id=BOO_USER;Password=BOO_USER;";
        public static string SSRS_Interface_Prod = @"Server=wssqlc015V01.healthy.bewell.ca\esp8; Database=SSRS_Interface_Prod;User Id=BOO_USER;Password=BOO_USER;";
        public static string LocalServer = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Application.StartupPath + @"\esp_systems.mdf;Integrated Security=True";

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

        public static void LoadIt(string _appName)
        {
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
                        if (_reader["AppID"].ToString() != "41")
                        {
                            MessageBox.Show(_reader["Err"].ToString(), "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Application.Exit();

                        }
                    }

                    _reader.Close();
                    _reader.Dispose();
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
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
