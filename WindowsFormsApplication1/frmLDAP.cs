using Microsoft.Exchange.WebServices.Data;
using System;
using System.DirectoryServices;
using System.IO;
using System.Windows.Forms;

//using EASendEmail;

namespace WindowsFormsApplication1
{
    public partial class frmLDAP : Form
    {
        public frmLDAP()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var employeeID = textBox1.Text.Trim();

            if (employeeID == "")
            {
                MessageBox.Show("Blank field detected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SearchResultCollection results = FindByID("healthy.bewell.ca", employeeID);

            ShowData(results, listBox1);
        }

        public static SearchResultCollection FindByName(string domain, string firstName, string lastName)
        {            
            string filter;
            if (lastName == "")
            {
                filter = string.Format("(&(givenName={0}))", firstName);
            }
            else if (firstName == "")
            {
                filter = string.Format("(&(sn={0}))", lastName);
            }
            else
            {
                filter = string.Format("(&(sn={0})(givenName={1}))", lastName, firstName);
            }           

            return SearchLDAP(domain, filter);
        }

        private static SearchResultCollection SearchLDAP(string _domain, string _filter)
        {
            var rootEntry = new DirectoryEntry("LDAP://" + _domain);

            var searcher = new DirectorySearcher(rootEntry, _filter);
            searcher.PropertiesToLoad.Add("sAMAccountName");
            searcher.PropertiesToLoad.Add("mail");
            searcher.PropertiesToLoad.Add("employeeNumber");
            searcher.PropertiesToLoad.Add("givenName");
            searcher.PropertiesToLoad.Add("sn");
            searcher.PropertiesToLoad.Add("manager");
            searcher.PropertiesToLoad.Add("departmentnumber");
            searcher.PropertiesToLoad.Add("title");

            return searcher.FindAll();
        }

        private static string SearchDisplayName(string domain, string searchStr)
        {
            string _ret = "";
            string ldapName = "";
            string[] _searchStr = { "", "" };
            try
            {
                _searchStr = searchStr.Split(',');

                ldapName = _searchStr[0].Substring(3);

                var rootEntry = new DirectoryEntry("LDAP://" + domain);
                string filter = string.Format("(&(sAMAccountName={0}))", ldapName);
                var searcher = new DirectorySearcher(rootEntry, filter);
                searcher.PropertiesToLoad.Add("displayName");
                SearchResultCollection results = searcher.FindAll();

                if (results != null)
                {
                    _ret = results[0].Properties["displayName"].Count > 0 ? results[0].Properties["displayName"][0].ToString() : "Mgr Not Found";
                }
            }
            catch
            {
                _ret = ldapName.Replace(@"\", ",") + (ldapName.IndexOf(@"\") > -1 ? _searchStr[1] : "");
            }

            return _ret;
        }

        public static SearchResultCollection FindByID(string domain, string idNumber)
        {
            var filter = string.Format("(employeeNumber=" + idNumber + ")");

            return SearchLDAP(domain, filter);

            //if (results != null)
            //{
            //    foreach (SearchResult result in results)
            //    {
            //        foreach (DictionaryEntry property in result.Properties)
            //        {
            //            Console.Write(property.Key + ": ");
            //            foreach (var val in (property.Value as ResultPropertyValueCollection))
            //            {
            //                Console.Write(val + "; ");
            //            }
            //            Console.WriteLine("");
            //        }
            //    }
            //}            
        }

        public static SearchResultCollection FindByLDAP(string domain, string ldapName)
        {
            var filter = string.Format("(sAMAccountName=" + ldapName + ")");

            return SearchLDAP(domain, filter);
        }

        private void checkLDAPByName_Click(object sender, EventArgs e)
        {

            var firstName = firstNameTextBox.Text.Trim();
            var lastName = lastNameTextBox.Text.Trim();

            if (firstName == "" && lastName == "")
            {
                MessageBox.Show("Blank field detected.");
                return;
            }

            SearchResultCollection results = FindByName("healthy.bewell.ca", firstName, lastName);

            ShowData(results, listBox1);
        }

        private void ShowData(SearchResultCollection results, ListBox _listBox)
        {
            try
            {
                _listBox.Items.Clear();

                if (results.Count > 0)
                {

                    foreach (SearchResult result in results)
                    {
                        string _empNo = result.Properties["employeeNumber"].Count > 0 ? result.Properties["employeeNumber"][0].ToString() : "No EmpNo";
                        string _ldapName = result.Properties["sAMAccountName"].Count > 0 ? result.Properties["sAMAccountName"][0].ToString() : "No LDAP Name";
                        string _firstName = result.Properties["givenName"].Count > 0 ? result.Properties["givenName"][0].ToString() : "No FirstName";
                        string _lastName = result.Properties["sn"].Count > 0 ? result.Properties["sn"][0].ToString() : "No LastName";
                        string _mail = result.Properties["mail"].Count > 0 ? result.Properties["mail"][0].ToString() : "No email";
                        string _manager = result.Properties["manager"].Count > 0 ? SearchDisplayName("healthy.bewell.ca", result.Properties["manager"][0].ToString()) : "Mgr Not Found";
                        string _location = result.Properties["departmentnumber"].Count > 0 
                            ? result.Properties["departmentnumber"][0].ToString().Substring(result.Properties["departmentnumber"][0].ToString().IndexOf(":") + 1) 
                            : "Location Not Found";
                        string _position = result.Properties["title"].Count > 0 ? result.Properties["title"][0].ToString() : "Title Not Found";

                        _listBox.Items.Add(_empNo + " | " + _ldapName + " | " + _lastName + ", " + _firstName + " | " + _mail + " | " + _manager + " | " + _location + " | " + _position);
                    }

                    //string _manager = result.Properties["manager"].Count > 0 ? result.Properties["manager"][0].ToString() : "Mgr Not Found";

                    //foreach (string propName in result.Properties.PropertyNames)
                    //{
                    //    ResultPropertyValueCollection valueCollection = result.Properties[propName];
                    //    foreach (Object propertyValue in valueCollection)
                    //    {
                    //        Console.WriteLine("Property: " + propName + ": " + propertyValue.ToString());
                    //    }
                    //}

                    if (_listBox.Items.Count == 1)
                    {
                        _listBox.SelectedIndex = 0;
                    }
                    else
                    {
                        txtEmpNo.Text = txtLocation.Text = txtEmpName.Text = txtManager.Text = txtLDAP.Text = txtEmail.Text = txtPosition.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Not Found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmLDAP_Shown(object sender, EventArgs e)
        {
            //this.Animate(new TopAnchoredHeightEffect(), EasingFunctions.BackEaseOut, 397, 1000, 0);
        }

        private void frmLDAP_Load(object sender, EventArgs e)
        {
            Hide();
            transFrm.ShowSync(this, true, null);
            Activate();
            textBox1.Focus();
        }

        private void firstNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                checkLDAPByName_Click(sender, e);
                ((TextBox)sender).SelectionStart = 0;
                ((TextBox)sender).SelectionLength = ((TextBox)sender).Text.Length;
            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count < 1) return;

            string[] _details = listBox1.Items[listBox1.SelectedIndex].ToString().Split('|');

            txtEmpNo.Text = _details[0].Trim();
            txtEmpName.Text = _details[2].Trim();
            txtLDAP.Text = _details[1].Trim();
            txtEmail.Text = _details[3].Trim();
            txtManager.Text = _details[4].Trim();
            txtLocation.Text = _details[5].Trim();
            txtPosition.Text = _details[6].Trim();
        }

        private int GetNthIndex(string s, char t, int n)
        {
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == t)
                {
                    count++;
                    if (count == n)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                button1_Click(sender, e);
                ((TextBox)sender).SelectionStart = 0;
                ((TextBox)sender).SelectionLength = ((TextBox)sender).Text.Length;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                #region Send an email using EWS
                var service = new ExchangeService(ExchangeVersion.Exchange2007_SP1);
                service.Credentials = new WebCredentials("RSSS.Help@albertahealthservices.ca", "Support2017b");
                service.TraceEnabled = true;
                service.TraceFlags = TraceFlags.All;
                service.AutodiscoverUrl("RSSS.Help@albertahealthservices.ca", RedirectionUrlValidationCallback);
                EmailMessage email = new EmailMessage(service);

                email.ToRecipients.Add("darwin.dizon@albertahealthservices.ca");
                email.Subject = "HelloWorld";
                email.Importance = Importance.High;
                email.Body = new MessageBody("1 email using EWS Managed API");
                email.Body.BodyType = BodyType.HTML;
                email.Send();
                MessageBox.Show("sent!");
                #endregion

                //var service = new ExchangeService(ExchangeVersion.Exchange2007_SP1);
                //service.Credentials = new WebCredentials("RSSS.Help@albertahealthservices.ca", "Support2016c");                
                //service.AutodiscoverUrl("RSSS.Help@albertahealthservices.ca", RedirectionUrlValidationCallback);

                ////FindItemsResults<Item> findResults = service.FindItems(WellKnownFolderName.Inbox, "darwin", new ItemView(100));
                ////foreach (Item item in findResults.Items)
                ////    Console.WriteLine(item.Subject);
                ////MessageBox.Show("Done!");

                //int ctr = 0;
                //int offset = 0;
                //int pageSize = 50;
                //bool more = true;
                //ItemView view = new ItemView(pageSize, offset, OffsetBasePoint.Beginning);
                ////view.PropertySet = PropertySet.IdOnly;
                ////view.PropertySet = PropertySet.FirstClassProperties;
                //FindItemsResults<Item> findResults = null;
                //List<EmailMessage> emails = new List<EmailMessage>();

                //while (more)
                //{                    
                //    findResults = service.FindItems(WellKnownFolderName.Inbox, view);
                //    service.LoadPropertiesForItems(findResults.Items, new PropertySet(EmailMessageSchema.Sender, EmailMessageSchema.Subject, EmailMessageSchema.Body));
                //    foreach (var item in findResults.Items)
                //    {
                //        //emails.Add((EmailMessage)item);
                //        if (item.Subject.ToUpper().IndexOf("SENIORITY") > -1)
                //        {
                //            emails.Add((EmailMessage)item);
                //            ctr++;
                //        }
                //    }
                //    more = findResults.MoreAvailable;
                //    if (more)
                //    {
                //        view.Offset += pageSize;
                //    }
                //}              

                //MessageBox.Show(ctr + " found. " + WebUtility.HtmlDecode(Regex.Replace(emails[0].Body.Text, "<[^>]*(>|$)", string.Empty))); 
                ////MessageBox.Show(ctr + " found. " + emails[0].Body.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static bool RedirectionUrlValidationCallback(string redirectionUrl)
        {
            var redirectionUri = new Uri(redirectionUrl);
            var result = redirectionUri.Scheme == "https";
            return result;
        }

        private void btnSearchByLDAP_Click(object sender, EventArgs e)
        {
            var ldapName = txtSearchByLDAP.Text.Trim();

            if (ldapName == "")
            {
                MessageBox.Show("Blank field detected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SearchResultCollection results = FindByLDAP("healthy.bewell.ca", ldapName);

            ShowData(results, listBox1);
        }

        private void txtSearchByLDAP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnSearchByLDAP_Click(sender, e);
                ((TextBox)sender).SelectionStart = 0;
                ((TextBox)sender).SelectionLength = ((TextBox)sender).Text.Length;
            }
        }

        private void btnBatchByID_Click(object sender, EventArgs e)
        {
            string _origBtnText = ((Button)sender).Text;

            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Title = "Select the comma delimited file that contains the employee ID's";
                openFileDialog1.Filter = "CSV Files|*.csv|Text Files|*.txt";
                openFileDialog1.FilterIndex = 1;

                bool userClickedOK = openFileDialog1.ShowDialog() == DialogResult.OK;

                if (!userClickedOK) return;

                ((Button)sender).Text = "Processing...";
                Cursor.Current = Cursors.WaitCursor;
                this.Enabled = false;
                Update();

                string text;
                var fileStream = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                using (var streamReader = new StreamReader(fileStream, System.Text.Encoding.UTF8))
                {
                    text = streamReader.ReadToEnd();
                }

                string[] _sourceIDs = text.Split(',', '\n');

                if (_sourceIDs.Length == 0)
                {
                    MessageBox.Show("No ID's to process on the file.");
                    return;
                }
                else if (_sourceIDs.Length > 1000)
                {
                    MessageBox.Show("The app can only process max of 1000 ID's at a time.");
                    return;
                }

                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "CSV files (*.csv)|*.csv";
                saveFileDialog1.FilterIndex = 1;
                //saveFileDialog1.FileName = "Terms " + CheckTermsAndTransStartDate(DateTime.Today.ToString("yyyy-MM-dd")) + " - " + DateTime.Today.AddDays(-1).ToString("ddMMMyy");
                if (saveFileDialog1.ShowDialog() != DialogResult.OK || saveFileDialog1.FileName.Trim() == "")
                {
                    //package.SaveAs(new FileInfo(saveFileDialog1.FileName));
                    //System.Diagnostics.Process.Start(saveFileDialog1.FileName);
                    return;
                }


                using (StreamWriter writer = new StreamWriter(saveFileDialog1.FileName))
                {
                    writer.WriteLine("Employee #, LDAP Name, Last Name, First Name, Email Address");

                    foreach (string _id in _sourceIDs)
                    {
                        string _data = "";

                        if (_id.Trim().Length == 0)
                        {
                            continue;
                        }
                        else if (_id.Trim().Length < 8)
                        {
                            _data = _id.Trim() + ", '---INVALID ID---";
                        }
                        else
                        {
                            SearchResultCollection results = FindByID("healthy.bewell.ca", _id.Trim().Substring(0, 8));

                            if (results.Count > 0)
                            {

                                foreach (SearchResult result in results)
                                {
                                    string _empNo = result.Properties["employeeNumber"].Count > 0 ? result.Properties["employeeNumber"][0].ToString() : "No EmpNo";
                                    string _ldapName = result.Properties["sAMAccountName"].Count > 0 ? result.Properties["sAMAccountName"][0].ToString() : "No LDAP Name";
                                    string _firstName = result.Properties["givenName"].Count > 0 ? result.Properties["givenName"][0].ToString() : "No FirstName";
                                    string _lastName = result.Properties["sn"].Count > 0 ? result.Properties["sn"][0].ToString() : "No LastName";
                                    string _mail = result.Properties["mail"].Count > 0 ? result.Properties["mail"][0].ToString() : "No email";
                                    string _manager = result.Properties["manager"].Count > 0 ? SearchDisplayName("healthy.bewell.ca", result.Properties["manager"][0].ToString()) : "Mgr Not Found";

                                    _data = "'" + _empNo + ", " + _ldapName + ", " + _lastName + ", " + _firstName + ", " + _mail;
                                }

                                if (listBox1.Items.Count == 1)
                                {
                                    listBox1.SelectedIndex = 0;
                                }
                            }
                            else
                            {
                                _data = _id.Trim() + ", '---Data NOT FOUND---";
                            }
                        }

                        writer.WriteLine(_data);

                        Update();
                    }

                }

                MessageBox.Show("Done!");

                System.Diagnostics.Process.Start(saveFileDialog1.FileName);

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ((Button)sender).Text = _origBtnText;
                Cursor.Current = Cursors.Default;
                this.Enabled = true;
            }
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
