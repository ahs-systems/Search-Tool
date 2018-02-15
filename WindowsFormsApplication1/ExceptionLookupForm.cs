using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class exceptionLookupForm : Form
    {
        public exceptionLookupForm()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            progress.Value = 0;
            progress.PerformStep();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = @"Data Source=wssqlc015v02\esp8; Initial Catalog=esp_cal_train; Trusted_Connection=true";

                progress.PerformStep();

                string sqlStatement = @"SELECT EX.EX_ExceptionID AS 'Exception ID',
											CASE EX.EX_Type
												WHEN 1 THEN 'Off Reason?'
												WHEN 2 THEN 'Book Off'
												WHEN 3 THEN 'Off Reason?'
											END		
											AS 'Type',
											E.E_EmpNbr AS 'Employee #',
											(RTRIM(E.E_LastName) + ', ' + RTRIM(E.E_FirstName)) AS 'Employee Name',
											CONVERT(VARCHAR,EX.EX_Date,107) AS 'Date',
											SD.SD_Symbol AS 'Shift Icon',
											(CONVERT(VARCHAR(5),SD.SD_StartTime,114) + ' - ' + CONVERT(VARCHAR(5),SD.SD_EndTime,114)) AS 'Shift Time',
											U.U_Desc AS 'Unit',
											R.R_Desc AS 'Rotation Name',
											(SELECT TOP 1 RRD_Position FROM RotationRowDetail WHERE RRD_RotRowID = EX.EX_RotRowID) AS 'Row',
											O.O_Desc AS 'Occupation',
											(RTRIM(RGCC.RGCC_Code) + '  -  ' + RGCC.RGCC_Desc) AS 'Cost Center',
											CASE EX.EX_Completed
												WHEN 1 THEN 'YES'
												ELSE 'NO'
											END AS 'Relief Required?',
											EX.EX_CreateDate AS 'Exception Created',
											EX.EX_ChangeDate AS 'Exception Changed',
											USR.US_UserName AS 'Changed By',
											USRG.UG_GroupName AS 'Access Type'
									FROM Exception EX
										JOIN Emp E 	ON EX.EX_EmpID = E.E_EmpID
										JOIN ShiftDetail SD ON EX.EX_ShiftID = SD.SD_ShiftID
										JOIN Unit U ON EX.EX_UnitID = U.U_UnitID
										JOIN RotationRow RR ON EX.EX_RotRowID = RR.RR_RotRowID
										JOIN Rotation R ON RR.RR_RotationID = R.R_RotationID
										JOIN Occupation O ON EX.EX_OccID = O.O_OccID
										JOIN RegularCostCenter RGCC ON EX.EX_CostCenterID = RGCC.RGCC_CostCenterID
										JOIN Users USR ON EX.EX_ChangeUserID = USR.US_UserID
										JOIN UserGroup USRG ON USR.US_GroupID = USRG.UG_GroupID
									WHERE EX.EX_ExceptionID = '" + exceptionIDText.Text + "'";


                SqlCommand command = new SqlCommand(sqlStatement, conn);

                progress.PerformStep();

                try
                {
                    conn.Open();
                    progress.PerformStep();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        progress.PerformStep();

                        if (reader.Read())
                        {
                            empNo.Text = ((string)reader["Employee #"]);
                            progress.PerformStep();
                            empName.Text = ((string)reader["Employee Name"]);
                            progress.PerformStep();
                            exceptionType.Text = ((string)reader["Type"]);
                            progress.PerformStep();
                            exceptionDate.Text = ((string)reader["Date"]);
                            progress.PerformStep();
                            shiftIcon.Text = ((string)reader["Shift Icon"]);
                            progress.PerformStep();
                            shiftTime.Text = ((string)reader["Shift Time"]);
                            progress.PerformStep();
                            reliefReq.Text = ((string)reader["Relief Required?"]);
                            progress.PerformStep();
                            occupationText.Text = ((string)reader["Occupation"]);
                            progress.PerformStep();
                            unitName.Text = ((string)reader["Unit"]);
                            progress.PerformStep();
                            rotationName.Text = ((string)reader["Rotation Name"]);
                            progress.PerformStep();
                            workplanRow.Text = ((string)reader["Row"].ToString());
                            progress.PerformStep();
                            costCenter.Text = ((string)reader["Cost Center"]);
                            progress.PerformStep();
                            creationDate.Text = ((string)reader["Exception Created"].ToString());
                            progress.PerformStep();
                            changeDate.Text = ((string)reader["Exception Changed"].ToString());
                            progress.PerformStep();
                            changeBy.Text = ((string)reader["Changed By"]);
                            progress.PerformStep();
                            accessType.Text = ((string)reader["Access Type"]);
                            progress.PerformStep();
                        }
                        else
                        {
                            foreach (Control c in this.Controls)
                            {
                                if (c.GetType() == typeof(TextBox))
                                {
                                    c.Text = "";
                                }
                            }

                            exceptionIDText.Text = "No Data";
                            exceptionIDText.SelectAll();
                            exceptionIDText.Focus();

                        }
                    }
                }

                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }

            }
        }

        private void exceptionIDText_TextChanged(object sender, EventArgs e)
        {
            progress.Value = 0;
        }

        private void exceptionLookupForm_Load(object sender, EventArgs e)
        {
            // Show the form
            Hide();
            transFrm.ShowSync(this, true, null);
            Activate();
        }

        private void exceptionLookupForm_Shown(object sender, EventArgs e)
        {
            //this.Animate(new TopAnchoredHeightEffect(), EasingFunctions.BackEaseOut, 330, 1000, 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
