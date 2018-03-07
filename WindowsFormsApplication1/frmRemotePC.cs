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
            IPAddress[] ipAddr = Dns.GetHostAddresses(txtBarcode.Text.Trim().ToUpper());
            if (ipAddr.Length == 1)
            {
                System.Diagnostics.Process.Start("https://" + ipAddr[0] + ":4343/index.html");
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
    }
}
