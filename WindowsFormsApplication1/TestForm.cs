using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.DirectoryServices;
using System.Security.Principal;


namespace WindowsFormsApplication1
{
    public partial class TestForm : Form
    {

        public TestForm()
        {
            InitializeComponent();
        }

        private void AddMemberToGroup(

                                string bindString,

                                string newMember

                                )
        {

            try
            {
                

                DirectoryEntry ent = new DirectoryEntry(bindString);

                ent.Properties["member"].Add(newMember);

                ent.CommitChanges();

            }

            catch (Exception e)
            {

                MessageBox.Show(e.Message);

                return;

            }

        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddMemberToGroup("LDAP://healthy.bewell.ca/CN=CAL.SSRS.ESP.SCHEDULER,OU=Accounts/Users/CAL/General,DC=healthy,DC=bewell,DC=ca",
                "LDAP://CN=KLeung,OU=Accounts/Users/CAL/General,DC=healthy,DC=bewell,DC=ca");
        }
    }
}
