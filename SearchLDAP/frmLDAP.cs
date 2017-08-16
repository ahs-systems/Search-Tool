﻿//using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Net;
using System.Text.RegularExpressions;
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
                MessageBox.Show("ERROR: " +ex.Message, "Ooops, may mali.");
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
                _ret = ldapName.Replace(@"\",",") + (ldapName.IndexOf(@"\") > -1 ? _searchStr[1] : "");
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
            //Height = 0;
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            
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
    }
}