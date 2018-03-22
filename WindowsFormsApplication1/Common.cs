using System;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class Common
    {
        public static string ESPServerUsingLocalIdentity = @"Server=wssqlc015v02\esp8; Initial Catalog = esp_cal_prod; Integrated Security = SSPI;";
        public static string ESPServer = @"Server=wssqlc015v02\esp8; Database=esp_cal_prod;User Id=Espreport; Password=Esp4rep0rt;";
        public static string SystemsServer = @"Server=M292387\ESPSYSTEMS; Database=esp_systems;User Id=esp_systems;Password=esp_systems1;";
        public static string BooServer = @"Server=wssqlc015V01.healthy.bewell.ca\esp8; Database=BOO;User Id=BOO_USER;Password=BOO_USER;";
        public static string SSRS_Interface_Prod = @"Server=wssqlc015V01.healthy.bewell.ca\esp8; Database=SSRS_Interface_Prod;User Id=BOO_USER;Password=BOO_USER;";
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

        public static string GetUnionGroup(string empID)
        {
            SqlConnection _conn = new SqlConnection(ESPServer);

            try
            {
                string _ret = "";

                _conn.Open();
                SqlCommand _comm = _conn.CreateCommand();
                _comm.CommandText = "SELECT UNN_Desc FROM Emp " +
                                    "Join EmpSeniority ON E_EmpID = ESN_EmpID " +
                                    "Join UnionGroup ON ESN_UnionGroupID = UNN_UnionID " +
                                    "WHERE E_EmpNbr = @empID";
                _comm.Parameters.Add(new SqlParameter("empID", empID));
                SqlDataReader _reader = _comm.ExecuteReader();
                if (_reader.HasRows)
                {
                    _reader.Read();
                    _ret = _reader["UNN_Desc"].ToString();
                }
                if (_reader.IsClosed != true) _reader.Close();

                return _ret;
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

        public static bool CheckUsers(string _currentUser)
        {
            try
            {
                string text;
                var fileStream = new FileStream(Application.StartupPath + @"\SearchTool_Users.dat", FileMode.Open, FileAccess.Read);
                using (var streamReader = new StreamReader(fileStream, System.Text.Encoding.UTF8))
                {
                    text = streamReader.ReadToEnd();
                }

                string[] _users = text.Split(',', '\n', '\r');

                _currentUser = _currentUser.ToUpper();
                for (int i = 0; i < _users.Length; i++)
                {
                    if (Common.Decrypt(_users[i], "rsss").Contains(_currentUser))
                    {
                        return true;
                    }
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        public static string Decrypt(string strEncrypted, string strKey)
        {
            try
            {
                TripleDESCryptoServiceProvider objDESCrypto =
                    new TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider objHashMD5 = new MD5CryptoServiceProvider();
                byte[] byteHash, byteBuff;
                string strTempKey = strKey;
                byteHash = objHashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(strTempKey));
                objHashMD5 = null;
                objDESCrypto.Key = byteHash;
                objDESCrypto.Mode = CipherMode.ECB; //CBC, CFB
                byteBuff = Convert.FromBase64String(strEncrypted);
                string strDecrypted = ASCIIEncoding.ASCII.GetString
                (objDESCrypto.CreateDecryptor().TransformFinalBlock
                (byteBuff, 0, byteBuff.Length));
                objDESCrypto = null;
                return strDecrypted;
            }
            catch
            {
                return "ERROR";
            }
        }

        public static string Encrypt(string strToEncrypt, string strKey)
        {
            try
            {
                TripleDESCryptoServiceProvider objDESCrypto =
                    new TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider objHashMD5 = new MD5CryptoServiceProvider();
                byte[] byteHash, byteBuff;
                string strTempKey = strKey;
                byteHash = objHashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(strTempKey));
                objHashMD5 = null;
                objDESCrypto.Key = byteHash;
                objDESCrypto.Mode = CipherMode.ECB; //CBC, CFB
                byteBuff = ASCIIEncoding.ASCII.GetBytes(strToEncrypt);
                return Convert.ToBase64String(objDESCrypto.CreateEncryptor().
                    TransformFinalBlock(byteBuff, 0, byteBuff.Length));
            }
            catch
            {
                return "ERROR";
            }
        }

        public static void PopulateUnitLongDesc(ref AutoCompleteStringCollection _unitsLongDesc)
        {
            try
            {
                using (SqlConnection myConnection = new SqlConnection())
                {
                    myConnection.ConnectionString = Common.ESPServer;
                    myConnection.Open();

                    SqlCommand myCommand = myConnection.CreateCommand();

                    myCommand.CommandText = "select U_Desc from unit where (U_Desc like '0%' OR U_Desc like 'N%') AND U_Active = 1 ORDER BY U_DESC";

                    SqlDataReader myReader = myCommand.ExecuteReader();

                    if (myReader.HasRows)
                    {
                        while (myReader.Read())
                            _unitsLongDesc.Add(myReader["U_Desc"].ToString().Trim());
                    }

                    myCommand.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ooops, there's an error: " + ex.Message, "ERROR");
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
                        if (_reader["AppID"].ToString() != "2")
                        {
                            MessageBox.Show(_reader["Err"].ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }

    public class SSTCryptographer
    {
        private static string _key;

        public SSTCryptographer()
        {
        }


        public static string Key
        {
            set
            {
                _key = value;
            }
        }

        /// <summary>
        /// Encrypt the given string using the default key.
        /// </summary>
        /// <param name="strToEncrypt">The string to be encrypted.</param>
        /// <returns>The encrypted string.</returns>
        public static string Encrypt(string strToEncrypt)
        {
            try
            {
                return Encrypt(strToEncrypt, _key);
            }
            catch
            {
                return "ERROR";
            }

        }

        /// <summary>
        /// Decrypt the given string using the default key.
        /// </summary>
        /// <param name="strEncrypted">The string to be decrypted.</param>
        /// <returns>The decrypted string.</returns>
        public static string Decrypt(string strEncrypted)
        {
            try
            {
                return Decrypt(strEncrypted, _key);
            }
            catch (Exception ex)
            {
                return "Wrong Input. " + ex.Message;
            }
        }

        /// <summary>
        /// Encrypt the given string using the specified key.
        /// </summary>
        /// <param name="strToEncrypt">The string to be encrypted.</param>
        /// <param name="strKey">The encryption key.</param>
        /// <returns>The encrypted string.</returns>
        public static string Encrypt(string strToEncrypt, string strKey)
        {
            try
            {
                TripleDESCryptoServiceProvider objDESCrypto = new TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider objHashMD5 = new MD5CryptoServiceProvider();

                byte[] byteHash, byteBuff;
                string strTempKey = strKey;

                byteHash = objHashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(strTempKey));
                objHashMD5 = null;
                objDESCrypto.Key = byteHash;
                objDESCrypto.Mode = CipherMode.ECB; //CBC, CFB

                byteBuff = ASCIIEncoding.ASCII.GetBytes(strToEncrypt);
                return Convert.ToBase64String(objDESCrypto.CreateEncryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
            }
            catch (Exception ex)
            {
                return "Wrong Input. " + ex.Message;
            }
        }


        /// <summary>
        /// Decrypt the given string using the specified key.
        /// </summary>
        /// <param name="strEncrypted">The string to be decrypted.</param>
        /// <param name="strKey">The decryption key.</param>
        /// <returns>The decrypted string.</returns>
        public static string Decrypt(string strEncrypted, string strKey)
        {
            try
            {
                TripleDESCryptoServiceProvider objDESCrypto = new TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider objHashMD5 = new MD5CryptoServiceProvider();

                byte[] byteHash, byteBuff;
                string strTempKey = strKey;

                byteHash = objHashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(strTempKey));
                objHashMD5 = null;
                objDESCrypto.Key = byteHash;
                objDESCrypto.Mode = CipherMode.ECB; //CBC, CFB

                byteBuff = Convert.FromBase64String(strEncrypted);
                string strDecrypted = ASCIIEncoding.ASCII.GetString(objDESCrypto.CreateDecryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
                objDESCrypto = null;

                return strDecrypted;
            }
            catch (Exception ex)
            {
                return "Wrong Input. " + ex.Message;
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
