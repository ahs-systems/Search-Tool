using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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
                MessageBox.Show("More than one IP address found on the machine, cannot connect.");
            }
        }
    }
}
