using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Crystals.Models;
using System.Threading;
using System.Diagnostics;

namespace Crystals
{
    static class Program
    {
        //Static Object for Database Handling.
        public static CrudDB db;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool mutexCreated = true;
            using (Mutex mutex = new Mutex(true, "CRYSTAL-4BFCE54B-7836-4D11-B0CD-91AAED489293", out mutexCreated))
            {
                if (mutexCreated)
                {
                    try
                    {
                        Program.db = new CrudDB();
                        Boolean success = Program.db.connectDB();
                        if (success == false)
                        {
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.SQLError("ERR:201 Failed to Connect DB "+ex.Message);
                        string msg = "Failed to initialize Application! Please restart and Try again." + "\r\n" + "If the problem persists contact us at support@camycent.com. ";
                        MessageBox.Show(msg, "Application Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new MainForm("admin", "admin"));
                    //Application.Run(new LoginForm());
                }
                else
                {
                    MessageBox.Show("Another instance of application is already running.", "Already running", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
