using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class Common
    {
        public static string ESPServer = @"Server=wssqlc015v02\esp8; Initial Catalog = esp_cal_prod; Integrated Security = SSPI;";
        public static string SystemsServer = @"Server=M292387\ESPSYSTEMS; Database=esp_systems;User Id=esp_systems;Password=esp_systems1;";
        public static string BooServer = @"Server=wssqlc015V01.healthy.bewell.ca\esp8; Database=BOO;User Id=BOO_USER;Password=BOO_USER;";
        public static string LocalServer = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Application.StartupPath + @"\esp_systems.mdf;Integrated Security=True";

        public static string CurrentUser { get; set; }

        public static string GetPP(string _date)
        {
            SqlConnection _conn = new SqlConnection(ESPServer);

            try
            {
                string _ret = "";

                _conn.Open();
                SqlCommand _comm = _conn.CreateCommand();
                _comm.CommandText = "select PP_NBR from payperiod where @V_DATE between pp_startdate and pp_enddate";
                _comm.Parameters.Add(new SqlParameter("V_DATE", _date));
                SqlDataReader _reader = _comm.ExecuteReader();
                _reader.Read();
                _ret = _reader["PP_NBR"].ToString();
                if (_reader.IsClosed != true) _reader.Close();

                return _ret != "" ? _ret.PadLeft(2, '0') : _ret;
            }
            catch
            {
                return "";
            }
            finally
            {
                if (_conn.State == System.Data.ConnectionState.Open) _conn.Close();
            }
        }

        public static string CheckIfMultiJob(string _empNbr)
        {
            SqlConnection _conn = new SqlConnection(ESPServer);

            try
            {
                string _ret = "";

                _conn.Open();
                SqlCommand _comm = _conn.CreateCommand();
                _comm.CommandText = "select e.E_EmpNbr, count(ep.EP_PrimaryInd) as 'Primary Positions' " +
                        "from Emp e  " +
                        "join EmpPosition ep " +
                        "on e.E_EmpID = ep.EP_EmpID " +
                        "where ep.EP_ToDate > getdate() " +
                        "and ep.EP_PrimaryInd = 1 " +
                        "and e.E_EmpNbr = @V_EmpNbr " +
                        "group by e.E_EmpNbr " +
                        "having count(ep.EP_PrimaryInd) > 1 ";
                _comm.Parameters.Add(new SqlParameter("V_EmpNbr", _empNbr));
                SqlDataReader _reader = _comm.ExecuteReader();
                _ret = _reader.HasRows ? "(M)" : "";
                if (_reader.IsClosed != true) _reader.Close();

                return _ret;
            }
            catch
            {
                return "(e)";
            }
            finally
            {
                if (_conn.State == System.Data.ConnectionState.Open) _conn.Close();
            }
        }
    }

    public class ChangeInUnitAndOrOcc
    {
        public string empNo { get; set; }
        public string prevUnit { get; set; }
        public string currUnit { get; set; }
        public string prevPosCode { get; set; }
        public string currPosCode { get; set; }
        public string stat { get; set; }
        public string pp { get; set; }
        public string ppYear { get; set; }
        public string itemsReportLetter { get; set; }
    }

    public class ChangeInOcc
    {
        public string empNo { get; set; }
        public string unit { get; set; }        
        public string prevPosCode { get; set; }
        public string currPosCode { get; set; }        
        public string pp { get; set; }
        public string ppYear { get; set; }
        public string itemsReportLetter { get; set; }
    }

    public class UploadItemsParams
    {
        public bool uploadToItems { get; set; }
        public string pp { get; set; }
        public string ppYear { get; set; }
        public string itemsReportLetter { get; set; }
    }
}
