// -----------------------------------------------------------
// This program is private software, based on C# source code.
// To sell or change credits of this software is forbidden,
// except if someone approves it from GiveAF INC. team.
// -----------------------------------------------------------
// Copyrights (c) 2016 GiveAF INC. All rights reserved.
// -----------------------------------------------------------

#region

using System;
using System.Windows.Forms;

#endregion

namespace GiveAF
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}