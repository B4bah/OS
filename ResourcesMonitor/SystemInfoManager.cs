using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace Homework
{
    public class SystemInfoManager
    {
        private ManagementClass _manager;

        public SystemInfoManager(string chapter)
        {
            _manager = new ManagementClass(chapter);
        }

        public struct Property
        {
            public string Name { get; set; }
            public string Value { get; set; }

            public Property(string name, string value)
            {
                Name = name;
                Value = value;
            }
        }

        public List<Property> GetInfo()
        {
            var result = new List<Property>();
            ManagementObjectCollection objects = _manager.GetInstances();
            PropertyDataCollection properties = _manager.Properties;

            foreach (ManagementObject obj in objects)
            {
                foreach (PropertyData prop in properties)
                {
                    object value = obj[prop.Name];
                    if (value != null)
                    {
                        result.Add(new Property(prop.Name, Convert.ToString(value)));
                    }
                }
            }
            return result;
        }

        public void PrintInfo(List<string> info)
        {
            foreach (var infoItem in info)
            {
                UI.Print(infoItem);
            }
        }
    }
}