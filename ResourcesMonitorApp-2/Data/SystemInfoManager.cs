using System;
using System.Collections.Generic;
using System.Management;

using SystemInfoApp_2.Models;

namespace SystemInfoApp_2.Data
{
    public class SystemInfoManager
    {
        private ManagementClass _manager;
        private string _className; // добавим поле

        public SystemInfoManager(string className)
        {
            _manager = new ManagementClass(className);
            _className = className; // сохраняем
        }

        public List<WmiProperty> GetInfo()
        {
            var result = new List<WmiProperty>();
            ManagementObjectCollection objects = _manager.GetInstances();
            PropertyDataCollection properties = _manager.Properties;

            foreach (var obj in objects)
            {
                foreach (System.Management.PropertyData prop in properties)
                {
                    object value = obj[prop.Name];
                    if (value != null)
                    {
                        result.Add(new WmiProperty
                        {
                            ClassName = _className, // используем сохранённое имя
                            PropertyName = prop.Name,
                            PropertyValue = Convert.ToString(value)
                        });
                    }
                }
            }
            return result;
        }
    }
}