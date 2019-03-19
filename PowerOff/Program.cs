using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PowerOff
{
    static class Program
    {
        private static System.Threading.Mutex mutex;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            mutex = new System.Threading.Mutex(true, "OnlyOneInstance");
            if (mutex.WaitOne(0, false))
            {
                Application.Run(new frmMain());
            }
            else
            {
                MessageBox.Show("程序已经在运行中。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }
        }
    }
}
