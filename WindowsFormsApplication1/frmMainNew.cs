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
    public partial class frmMainNew : Form
    {
        public frmMainNew()
        {
            InitializeComponent();
        }

        private void frmMainNew_Load(object sender, EventArgs e)
        {
            this.Size = new Size(855, 369);
            this.StartPosition = FormStartPosition.CenterScreen;
            //Opacity = .95;

            pnlFormatting.Visible = false;
            pnlFormatting.Location = new Point(132, 44);
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnFile126_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuTileButton3_Click(object sender, EventArgs e)
        {
            pnlMisc.Visible = false;
            pnlFormatting.Visible = true;
        }

        private void btnMisc_Click(object sender, EventArgs e)
        {
            pnlMisc.Visible = true;
            pnlFormatting.Visible = false;
        }
    }
}
