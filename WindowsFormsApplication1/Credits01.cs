using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SearchTool
{
    public partial class frmCredits01 : Form
    {
        public frmCredits01()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmCredits2 _frm = new frmCredits2();
            _frm.ShowDialog();
        }

        private void frmCredits01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

            }
            else if (e.Button == MouseButtons.Right)
            {
                Hide();
                frmCredits _frm = new frmCredits();
                _frm.ShowDialog();
                Close();
            }
        }
    }
}
