using System;
using System.Windows.Forms;
using System.IO;

namespace Teeworlds_Config_Creator
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Parameter auslesen
            string[] CommandLineArgs = Environment.GetCommandLineArgs();
            //Wenn Parameter "-delete" ist wird die angegebene Datei gelöscht
            if (CommandLineArgs.Length > 1)
            {
                if (CommandLineArgs[1] == "-delete")
                {
                    if (File.Exists(CommandLineArgs[2]))
                    {
                        System.Threading.Thread.Sleep(5000);
                        File.Delete(CommandLineArgs[2]);
                    }
                }
            }
            Application.Run(new TCC());
        }
    }
}
