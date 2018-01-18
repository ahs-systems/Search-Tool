using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Sandbox
{
    public partial class Form1 : Form
    {
        WinEventDelegate dele = null;

        public Form1()
        {
            InitializeComponent();
            dele = new WinEventDelegate(WinEventProc);
            IntPtr m_hhook = SetWinEventHook(EVENT_SYSTEM_FOREGROUND, EVENT_SYSTEM_FOREGROUND, IntPtr.Zero, dele, 0, 0, WINEVENT_OUTOFCONTEXT);
        }

        delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);

        [DllImport("user32.dll")]
        static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr hmodWinEventProc, WinEventDelegate lpfnWinEventProc, uint idProcess, uint idThread, uint dwFlags);

        private const uint WINEVENT_OUTOFCONTEXT = 0;
        private const uint EVENT_SYSTEM_FOREGROUND = 3;

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetWindowTextLength(IntPtr hWnd);



        private string GetActiveWindowTitle()
        {
            //const int nChars = 256;
            //IntPtr handle = IntPtr.Zero;
            //StringBuilder Buff = new StringBuilder(nChars);
            //handle = GetForegroundWindow();

            //if (GetWindowText(handle, Buff, nChars) > 0)
            //{
            //    return Buff.ToString();
            //}
            //return null;

            string strTitle = string.Empty;
            IntPtr handle = GetForegroundWindow();
            // Obtain the length of the text   
            int intLength = GetWindowTextLength(handle) + 1;
            StringBuilder stringBuilder = new StringBuilder(intLength);
            if (GetWindowText(handle, stringBuilder, intLength) > 0)
            {
                strTitle = stringBuilder.ToString();
            }
            return strTitle;
        }

        public void WinEventProc(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {
            string _ret = GetActiveWindowTitle();
            if (_ret.Trim().ToUpper() == "ALBERTA HEALTH SERVICES" || _ret == "Timeout Warning. Click OK to not end the session. - Alberta Health Services")
            {
                SendKeys.Send("{TAB}");
                SendKeys.Send("{ENTER}");
            }
            Log.Text += _ret + "\r\n";
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            bunifuTransition1.ShowSync(this, true, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form2 _frm = new Form2();
            _frm.ShowDialog();
            Hide();
            bunifuTransition1.ShowSync(this, true, null);
            this.Focus();
        }
    }
}
