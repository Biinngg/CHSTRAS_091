using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CHSTRAS_091_UI
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new uiTyping01_Option());
        }
    }
}
