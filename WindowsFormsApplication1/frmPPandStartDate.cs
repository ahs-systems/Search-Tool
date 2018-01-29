using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class frmPPandStartDate : Form
    {
        public frmPPandStartDate()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void frmPPandStartDate_Load(object sender, EventArgs e)
        {
            SqlConnection _conn = new SqlConnection(Common.ESPServer);
            SqlCommand _comm = null;            

            try
            {
                _conn.Open();
                _comm = _conn.CreateCommand();
                _comm.CommandText = "select top 3 'PP ' + REPLACE(STR(PP_Nbr, 2), SPACE(1), '0') + '  [ ' + FORMAT(PP_StartDate,'MMM dd, yyyy') + ' to ' + FORMAT(PP_EndDate,'MMM dd, yyyy') + ' ]' AS PP " +
                                    "from payperiod WHERE PP_StartDate < GETDATE() - 7 order by PP_PayPeriodID desc";
                //_comm.Parameters.Add(new SqlParameter("V_DATE", _date));
                SqlDataReader _reader = _comm.ExecuteReader();
                if (_reader.HasRows)
                {
                    while (_reader.Read())
                    {
                        cboPP.Items.Add(_reader["PP"].ToString());
                    }
                }
                _reader.Dispose();
                cboPP.SelectedIndex = 0;
            }
            catch 
            {                
                btnContinue.Enabled = false;
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
        }
    }
}
