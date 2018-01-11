using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmUsers : Form
    {
        public frmUsers()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            txtOutput.Text = Common.Encrypt(txtInput.Text.Trim().ToUpper(), "rsss");
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            txtOutput.Text = Common.Decrypt(txtInput.Text.Trim(), "rsss");
        }
    }
}
