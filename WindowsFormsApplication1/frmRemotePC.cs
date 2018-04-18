using System;
using System.Net;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmRemotePC : Form
    {
        public frmRemotePC()
        {
            InitializeComponent();
        }

        private void frmRemotePC_Load(object sender, EventArgs e)
        {
            Hide();
            transFrm.ShowSync(this, true, null);
            Activate();
            txtBarcode.Focus();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                IPAddress[] ipAddr = Dns.GetHostAddresses(txtBarcode.Text.Trim().ToUpper());
                if (ipAddr.Length == 1)
                {
                    if (rdoWebClient.Checked)
                    {
                        MessageBox.Show("If you will receive a message \n\n\"There is a problem with this website’s security certificate.\"\n\non the next window, just click on\n\n\"Continue to this website (not recommended).\"\n\nto continue.\n\nThen enter your network username and password.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        System.Diagnostics.Process.Start("https://" + ipAddr[0] + ":4343/index.html");
                    }
                    else
                    {
                        System.Diagnostics.Process.Start("\"" + @"C:\Program Files (x86)\LANDesk\ServerManager\RCViewer\isscntr.exe" + "\"", " -swsldcalcore01 -a" + ipAddr[0] + " -c\"Remote Control\"");
                    }
                }
                else
                {
                    string _msg = "More than one IP address found on the machine, cannot connect.\n\n Try to connect using LANDESK directly.\n\nIP addresses found:\n";
                    for (int i = 0; i < ipAddr.Length; i++)
                    {
                        _msg += ipAddr[i] + "\n";
                    }
                    MessageBox.Show(_msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR in remoting: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnConnect.PerformClick();                
            }
        }
    }
}
