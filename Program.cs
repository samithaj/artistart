using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace artistArtGui
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length == 3)
                Application.Run(new Form1(args[0], args[1], args[2]));
            else
            {
                Application.Run(new Form1());
            }
        }



    }
}
