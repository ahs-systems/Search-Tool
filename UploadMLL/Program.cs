using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using OfficeOpenXml;
using System.IO;

namespace UploadMLL
{
    class Program
    {
        static string _appDir;

        static void Main(string[] args)
        {
            _appDir = AppDomain.CurrentDomain.BaseDirectory;
            Console.Write("\nFetching data from excel file:\n\n" + @"\\jeeves.crha-health.ab.ca\rsss_systems\MLL Files\PSS Online Courses Dashboard.xlsx" + "\n\nSometimes it takes a while.\nPlease be patient ... :)\n...");
            UploadMLL(@"\\jeeves.crha-health.ab.ca\rsss_systems\MLL Files\PSS Online Courses Dashboard.xlsx");
            //UploadMLL(@"S:\MLL Files\PSS Online Courses Dashboard.xlsx");
        }

        private static void UploadMLL(string _filename)
        {
            int xctr = 0;

            try
            {
                using (OdbcConnection myConnection = new OdbcConnection())
                {
                    //_appDir = @"S:\Operations - RSSS Systems Group\Automated Files\Test Folder\";

                    myConnection.ConnectionString = @"Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=" + _appDir + "trainings.accdb;Uid=Admin;Pwd=;";
                    myConnection.Open();

                    OdbcCommand myCommand = myConnection.CreateCommand();

                    myCommand.CommandText = "DELETE FROM TRAININGS"; // refresh the database with new data
                    myCommand.ExecuteNonQuery();
                    myCommand.CommandText = "ALTER TABLE TRAININGS ALTER COLUMN ID COUNTER(1,1)"; // refresh the database with new data
                    myCommand.ExecuteNonQuery();

                    using (ExcelPackage package = new ExcelPackage(new FileInfo(_filename)))
                    {
                        ExcelWorkbook workBook = package.Workbook;

                        foreach (var excelWorksheet in package.Workbook.Worksheets)
                        {
                            if (excelWorksheet.Name.ToUpper().IndexOf("COURSE DASHBOARD") > -1) continue; // skip the Course Dashboard sheet

                            string _course = excelWorksheet.Cells[10, 1].Value != null ? excelWorksheet.Cells[10, 1].Value.ToString() : excelWorksheet.Name;

                            int totalRows = excelWorksheet.Dimension.End.Row;

                            for (int i = 10; i <= totalRows; i++)
                            {
                                xctr = i;
                                myCommand.CommandText = "INSERT into TRAININGS (empNum, empName, emailAdd, jobTitle, dept, site, city, zone, manager, regDate, status, statDate, course) values " +
                                    "('" + (excelWorksheet.Cells[i, 5].Value == null ? "" : excelWorksheet.Cells[i, 5].Value.ToString().Replace("'", "`")) + // empNum
                                    "', '" + (excelWorksheet.Cells[i, 6].Value == null ? "" : excelWorksheet.Cells[i, 6].Value.ToString().ToUpper().Replace("'", "`")) + //empName
                                    "', '" + (excelWorksheet.Cells[i, 9].Value == null ? "" : excelWorksheet.Cells[i, 9].Value.ToString().Replace("'", "`")) + //email address
                                    "', '" + (excelWorksheet.Cells[i, 16].Value == null ? "" : excelWorksheet.Cells[i, 16].Value.ToString().Replace("'", "`")) + // jobTitle
                                    "', '" + (excelWorksheet.Cells[i, 18].Value == null ? "" : excelWorksheet.Cells[i, 18].Value.ToString().Replace("'", "`")) + // dept
                                    "', '" + (excelWorksheet.Cells[i, 19].Value == null ? "" : excelWorksheet.Cells[i, 19].Value.ToString().Replace("'", "`")) + // site
                                    "', '" + (excelWorksheet.Cells[i, 20].Value == null ? "" : excelWorksheet.Cells[i, 20].Value.ToString().Replace("'", "`")) + // city
                                    "', '" + (excelWorksheet.Cells[i, 21].Value == null ? "" : excelWorksheet.Cells[i, 21].Value.ToString().Replace("'", "`")) + // zone
                                    "', '" + (excelWorksheet.Cells[i, 22].Value == null ? "" : excelWorksheet.Cells[i, 22].Value.ToString().Replace("'", "`")) + // manager
                                    "', #" + excelWorksheet.Cells[i, 23].Value + // regDate
                                    "#, '" + excelWorksheet.Cells[i, 24].Value.ToString().Replace("'", "`") + // status
                                    "', #" + excelWorksheet.Cells[i, 25].Value + // statDate
                                    "#, '" + _course.Replace("'", "`") + "')";
                                myCommand.ExecuteNonQuery();
                            }                            
                        }

                        myCommand.CommandText = "UPDATE updated SET dateUpdated = NOW()";
                        myCommand.ExecuteNonQuery();                                                
                    }
                }
                // copy the updated access db to Automated Files Folder
                File.Copy(_appDir + "trainings.accdb", @"\\jeeves.crha-health.ab.ca\rsss_systems\Operations - RSSS Systems Group\Automated Files\trainings.accdb", true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ": " + xctr);
                Console.ReadLine();
            }
        }
    }
}
