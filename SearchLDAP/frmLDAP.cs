//using Microsoft.Exchange.WebServices.Data;
using Bunifu.Framework.UI;
using Microsoft.Exchange.WebServices.Data;
using System;
using System.DirectoryServices;
using System.IO;
using System.Windows.Forms;
//using VisualEffects;
//using VisualEffects.Animations.Effects;
//using VisualEffects.Easing;
//using EASendEmail;

namespace SearchLDAP
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

            try
            {

                SearchResultCollection results = FindByID("healthy.bewell.ca", employeeID);

                listBox1.Items.Clear();

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
                        //string _manager = result.Properties["manager"].Count > 0 ? result.Properties["manager"][0].ToString() : "Mgr Not Found";

                        //foreach (string propName in result.Properties.PropertyNames)
                        //{
                        //    ResultPropertyValueCollection valueCollection = result.Properties[propName];
                        //    foreach (Object propertyValue in valueCollection)
                        //    {
                        //        Console.WriteLine("Property: " + propName + ": " + propertyValue.ToString());
                        //    }
                        //}


                        listBox1.Items.Add(_empNo + " | " + _ldapName + " | " + _lastName + ", " + _firstName + " | " + _mail + " | " + _manager);
                    }

                    if (listBox1.Items.Count == 1)
                    {
                        listBox1.SelectedIndex = 0;
                    }
                }
                else
                {
                    MessageBox.Show("Not Found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "Ooops, may mali.");
            }
        }

        public static SearchResultCollection FindByName(string domain, string firstName, string lastName)
        {
            //var rootEntry = new DirectoryEntry("LDAP://" + domain);
            //var filter = string.Format("(&(sn={0})(givenName={1}))", lastName, firstName);
            //var searcher = new DirectorySearcher(rootEntry, filter, properties);
            //searcher.PropertiesToLoad.Add("sAMAccountName");

            var rootEntry = new DirectoryEntry("LDAP://" + domain);
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
            var searcher = new DirectorySearcher(rootEntry, filter);
            searcher.PropertiesToLoad.Add("sAMAccountName");
            searcher.PropertiesToLoad.Add("mail");
            searcher.PropertiesToLoad.Add("employeeNumber");
            searcher.PropertiesToLoad.Add("givenName");
            searcher.PropertiesToLoad.Add("sn");
            searcher.PropertiesToLoad.Add("manager");

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
            var rootEntry = new DirectoryEntry("LDAP://" + domain);
            var filter = string.Format("(employeeNumber=" + idNumber + ")");
            var searcher = new DirectorySearcher(rootEntry, filter);

            searcher.PropertiesToLoad.Add("sAMAccountName");
            searcher.PropertiesToLoad.Add("mail");
            searcher.PropertiesToLoad.Add("employeeNumber");
            searcher.PropertiesToLoad.Add("sn");
            searcher.PropertiesToLoad.Add("givenName");
            searcher.PropertiesToLoad.Add("manager");

            SearchResultCollection results = searcher.FindAll();

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

            return results;
        }

        public static SearchResultCollection FindByLDAP(string domain, string ldapName)
        {
            var rootEntry = new DirectoryEntry("LDAP://" + domain);
            var filter = string.Format("(sAMAccountName=" + ldapName + ")");
            var searcher = new DirectorySearcher(rootEntry, filter);

            searcher.PropertiesToLoad.Add("sAMAccountName");
            searcher.PropertiesToLoad.Add("mail");
            searcher.PropertiesToLoad.Add("employeeNumber");
            searcher.PropertiesToLoad.Add("sn");
            searcher.PropertiesToLoad.Add("givenName");
            searcher.PropertiesToLoad.Add("manager");

            SearchResultCollection results = searcher.FindAll();

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

            return results;
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

            try
            {
                SearchResultCollection results = FindByName("healthy.bewell.ca", firstName, lastName);

                listBox1.Items.Clear();

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

                        listBox1.Items.Add(_empNo + " | " + _ldapName + " | " + _lastName + ", " + _firstName + " | " + _mail + " | " + _manager);
                    }

                    if (listBox1.Items.Count == 1)
                    {
                        listBox1.SelectedIndex = 0;
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
            //this.Animate(new TopAnchoredHeightEffect(), EasingFunctions.BackEaseOut, 384, 1000, 0);
        }

        private void frmLDAP_Load(object sender, EventArgs e)
        {
            // Show the form
            //Hide();
            //transFrm.ShowSync(this, true, null);
            //Activate();

            //foreach (string propName in result.Properties.PropertyNames)
            //{
            //    ResultPropertyValueCollection valueCollection = result.Properties[propName];
            //    foreach (Object propertyValue in valueCollection)
            //    {
            CheckApp(); //    ResultPropertyValueCollection valueCollection = result.Properties[propName];
            //        Console.WriteLine("Property: " + propName + ": " + propertyValue.ToString());
            //    }
            //}

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

            try
            {

                SearchResultCollection results = FindByLDAP("healthy.bewell.ca", ldapName);

                listBox1.Items.Clear();

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
                        //string _manager = result.Properties["manager"].Count > 0 ? result.Properties["manager"][0].ToString() : "Mgr Not Found";

                        //foreach (string propName in result.Properties.PropertyNames)
                        //{
                        //    ResultPropertyValueCollection valueCollection = result.Properties[propName];
                        //    foreach (Object propertyValue in valueCollection)
                        //    {
                        //        Console.WriteLine("Property: " + propName + ": " + propertyValue.ToString());
                        //    }
                        //}


                        listBox1.Items.Add(_empNo + " | " + _ldapName + " | " + _lastName + ", " + _firstName + " | " + _mail + " | " + _manager);
                    }

                    if (listBox1.Items.Count == 1)
                    {
                        listBox1.SelectedIndex = 0;
                    }
                }
                else
                {
                    MessageBox.Show("Not Found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "Ooops, may mali.");
            }
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

        private void CheckApp()
        {
            string _msg = "";

            if (!Common.CheckApp("SearchLDAP", ref _msg))
            {
                MessageBox.Show(_msg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void btnBatchByID_Click(object sender, EventArgs e)
        {
            string _origBtnText = ((BunifuFlatButton)sender).Text;

            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Title = "Select the comma delimited file that contains the employee ID's";
                openFileDialog1.Filter = "All Files|*.*|CSV Files|*.csv|Text Files|*.txt";
                openFileDialog1.FilterIndex = 1;

                bool userClickedOK = openFileDialog1.ShowDialog() == DialogResult.OK;

                if (!userClickedOK) return;

                ((BunifuFlatButton)sender).Text = "Processing...";
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

                MessageBox.Show("Done!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);


                System.Diagnostics.Process.Start(saveFileDialog1.FileName);

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ((BunifuFlatButton)sender).Text = _origBtnText;
                Cursor.Current = Cursors.Default;
                this.Enabled = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                #region Send an email using EWS
                var service = new ExchangeService(ExchangeVersion.Exchange2007_SP1);
                service.Credentials = new WebCredentials("RSSS.Help@albertahealthservices.ca", "Support2017b");
                //service.Credentials = new WebCredentials("Darwin.Dizon@albertahealthservices.ca", "");
                service.TraceEnabled = true;
                service.TraceFlags = TraceFlags.All;
                service.AutodiscoverUrl("RSSS.Help@albertahealthservices.ca", RedirectionUrlValidationCallback);
                EmailMessage email = new EmailMessage(service);

                email.ToRecipients.Add("darwin.dizon@albertahealthservices.ca");
                email.Subject = "HelloWorld " + DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss");
                email.Importance = Importance.High;
                email.Body = new MessageBody("1 email using EWS Managed API");
                email.Body.BodyType = BodyType.HTML;
                email.Sender = "test@ahs.ca";
                email.SendAndSaveCopy();
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

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDemoFiles_Click(object sender, EventArgs e)
        {
            int lineCtr = 0;

            Hide();
            frmSelectZone _frm = new frmSelectZone();
            _frm.ShowDialog();
            if (_frm._result == DialogResult.OK)
            {
                string _origBtnText = ((BunifuFlatButton)sender).Text;
                string _dbServer = "";

                switch (_frm.cboZone.selectedIndex)
                {
                    case 0: // Calgary
                        _dbServer = Common.CAL_Db;
                        break;
                    case 1: // Edmonton
                        _dbServer = Common.EDM_Db;
                        break;
                    case 2: // NCS
                        _dbServer = Common.NCS_Db;
                        break;
                }

                try
                {
                    OpenFileDialog openFileDialog1 = new OpenFileDialog();
                    openFileDialog1.Title = "Select the demo files you want to process.";
                    openFileDialog1.Filter = "CSV Files|*.csv|Text Files|*.txt";
                    openFileDialog1.FilterIndex = 1;
                    openFileDialog1.Multiselect = true;

                    bool userClickedOK = openFileDialog1.ShowDialog() == DialogResult.OK;

                    if (!userClickedOK || openFileDialog1.FileNames.Length == 0)
                    {
                        Show();
                        Activate();
                        return;
                    }

                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "CSV files (*.csv)|*.csv";
                    saveFileDialog1.FilterIndex = 1;
                    if (saveFileDialog1.ShowDialog() != DialogResult.OK || saveFileDialog1.FileName.Trim() == "")
                    {
                        Show();
                        Activate();
                        return;
                    }

                    ((BunifuFlatButton)sender).Text = "Processing...";
                    Cursor.Current = Cursors.WaitCursor;
                    Enabled = false;
                    Update();

                    using (StreamWriter writer = new StreamWriter(saveFileDialog1.FileName))
                    {
                        writer.WriteLine("Employee #,Last Name,First Name");

                        for (int i = 0; i < openFileDialog1.FileNames.Length; i++)
                        {
                            string[] lines = File.ReadAllLines(openFileDialog1.FileNames[i]);

                            foreach (string line in lines)
                            {
                                string[] _data = line.Split(',');

                                if (_data.Length > 1 && _data[1].Trim().Length > 7)
                                {
                                    string _empNumber = _data[1].Trim().Substring(0, 8);
                                    string _empName = Common.GetEmpName(_empNumber, _dbServer).Replace(", ", ",");
                                    if (_empName == "--- Name Not Found ---")
                                    {
                                        SearchResultCollection results = FindByID("healthy.bewell.ca", _empNumber);
                                        if (results.Count > 0)
                                        {
                                            SearchResult result = results[0];

                                            string _firstName = result.Properties["givenName"].Count > 0 ? result.Properties["givenName"][0].ToString() : "No FirstName";
                                            string _lastName = result.Properties["sn"].Count > 0 ? result.Properties["sn"][0].ToString() : "No LastName";

                                            _empName = _lastName + "," + _firstName;
                                        }
                                    }
                                    writer.WriteLine("'" + _data[1].Trim() + "," + _empName);

                                    lineCtr++;
                                }
                            }
                        }
                    }

                    System.Diagnostics.Process.Start(saveFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    ((BunifuFlatButton)sender).Text = _origBtnText;
                    Cursor.Current = Cursors.Default;
                    Enabled = true;
                }
            }
            Show();
            Activate();
            MessageBox.Show(lineCtr + " record(s) processed.");
        }
    }
}
