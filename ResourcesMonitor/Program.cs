using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Management;

namespace Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SystemInfoManager manager = new SystemInfoManager("Win32_Processor");
            List<string> systemInfo = manager.GetInfo();
            manager.PrintInfo(systemInfo);
        }
    }
}
