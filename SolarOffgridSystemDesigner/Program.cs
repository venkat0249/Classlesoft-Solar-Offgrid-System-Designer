//author: Venkatesh Pampana. If you would like to contribute to this project, write to me : venkat@classlesoft.in
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SolarOffgridSystemDesigner
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
