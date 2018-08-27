using System;
using System.Windows.Forms;
using System.Net;

namespace Sandbox
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IPAddress[] ipAddr = Dns.GetHostAddresses(textBox1.Text.ToUpper());
            if (ipAddr.Length == 1)
            {                
                System.Diagnostics.Process.Start("https://" + ipAddr[0] + ":4343/index.html");
            }
            else
            {
                MessageBox.Show("More than one IP address found on the machine");
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
