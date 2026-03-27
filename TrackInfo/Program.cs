using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using TrackInfo.Models;
using TrackInfo.Interfaces;
using TrackInfo.Visitors;

namespace TrackInfo
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            TrackStore trackStore = new TrackStore();
            
        }
    }
}
