using System;
using System.Windows.Forms;
using SecurityPanelApp;  // <-- thêm dòng này

namespace Apdung2
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
