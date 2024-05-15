using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace diplomrestart
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
            Application.Run(new frmMain());

            string appPath = "C:\\Users\\stepa\\source\\repos\\diplomrestart\\diplomrestart.sln";

            // Создаем объект ярлыка
            using (Process shortcut = new Process())
            {
                // Задаем параметры для ярлыка
                shortcut.StartInfo.FileName = appPath;

                // Запускаем приложение через ярлык
                shortcut.Start();
            }
        }

    }
}
