using System;
using System.Windows.Forms;
using ClArc.Sync;

namespace WindowsFormsApp {
    static class Program {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Startup.Run();

            var usecaseBus = ServiceProvider.GetService<UseCaseBus>();
            Application.Run(new Form1(usecaseBus));
        }
    }
}
