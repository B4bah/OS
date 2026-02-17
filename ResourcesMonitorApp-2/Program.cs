using System;
using System.Windows.Forms;

using SystemInfoApp_2.UI;
using SystemInfoApp_2.Models;
using SystemInfoApp_2.Data;

namespace SystemInfoApp_2
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}