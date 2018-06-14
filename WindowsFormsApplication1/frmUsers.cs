using System;
using System.Windows.Forms;

namespace SearchTool
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

        private void frmUsers_Load(object sender, EventArgs e)
        {
            Hide();
            transFrm.ShowSync(this, true, null);
            Activate();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
