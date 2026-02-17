using System;
using System.Collections.Generic;
using System.Management;

using SystemInfoApp_2.Models;

namespace SystemInfoApp_2.Data
{
    public static class WmiDataProvider
    {
        public static List<WmiCategory> GetCategories()
        {
            return new List<WmiCategory>
    {
        new WmiCategory
        {
            CategoryName = "Cooling",
            Classes = new List<WmiClassInfo>
            {
                new WmiClassInfo { ClassName = "Win32_Fan", DisplayName = "Fans" },
                new WmiClassInfo { ClassName = "Win32_TemperatureProbe", DisplayName = "Temperature Sensors" }
            }
        },
        new WmiCategory
        {
            CategoryName = "Input Devices",
            Classes = new List<WmiClassInfo>
            {
                new WmiClassInfo { ClassName = "Win32_Keyboard", DisplayName = "Keyboard" },
                new WmiClassInfo { ClassName = "Win32_PointingDevice", DisplayName = "Pointing Devices" }
            }
        },
        new WmiCategory
        {
            CategoryName = "Storage",
            Classes = new List<WmiClassInfo>
            {
                new WmiClassInfo { ClassName = "Win32_CDROMDrive", DisplayName = "CD/DVD Drives" },
                new WmiClassInfo { ClassName = "Win32_DiskDrive", DisplayName = "Disk Drives" },
                new WmiClassInfo { ClassName = "Win32_FloppyDisk", DisplayName = "Floppy Disks" }
            }
        },
        new WmiCategory
        {
            CategoryName = "Motherboard / Controllers / Ports",
            Classes = new List<WmiClassInfo>
            {
                new WmiClassInfo { ClassName = "Win32_MotherboardDevice", DisplayName = "Motherboard Devices" },
                new WmiClassInfo { ClassName = "Win32_BIOS", DisplayName = "BIOS" },
                new WmiClassInfo { ClassName = "Win32_PhysicalMemory", DisplayName = "Physical Memory" },
                new WmiClassInfo { ClassName = "Win32_Processor", DisplayName = "CPU" }
            }
        },
        new WmiCategory
        {
            CategoryName = "Network",
            Classes = new List<WmiClassInfo>
            {
                new WmiClassInfo { ClassName = "Win32_NetworkAdapter", DisplayName = "Network Adapters" }
            }
        },
        new WmiCategory
        {
            CategoryName = "Power",
            Classes = new List<WmiClassInfo>
            {
                new WmiClassInfo { ClassName = "Win32_Battery", DisplayName = "Batteries" },
                new WmiClassInfo { ClassName = "Win32_PowerManagementEvent", DisplayName = "Power Management Events" }
            }
        },
        new WmiCategory
        {
            CategoryName = "Printers",
            Classes = new List<WmiClassInfo>
            {
                new WmiClassInfo { ClassName = "Win32_Printer", DisplayName = "Printers" },
                new WmiClassInfo { ClassName = "Win32_PrintJob", DisplayName = "Print Jobs" }
            }
        },
        new WmiCategory
        {
            CategoryName = "Modems",
            Classes = new List<WmiClassInfo>
            {
                new WmiClassInfo { ClassName = "Win32_POTSModem", DisplayName = "Modems" }
            }
        },
        new WmiCategory
        {
            CategoryName = "Video",
            Classes = new List<WmiClassInfo>
            {
                new WmiClassInfo { ClassName = "Win32_DesktopMonitor", DisplayName = "Monitors" },
                new WmiClassInfo { ClassName = "Win32_DisplayConfiguration", DisplayName = "Display Configuration" },
                new WmiClassInfo { ClassName = "Win32_VideoController", DisplayName = "Video Controllers" },
                new WmiClassInfo { ClassName = "Win32_VideoSettings", DisplayName = "Video Settings" }
            }
        }
    };
        }

        public static List<WmiProperty> GetProperties(string className)
        {
            var result = new List<WmiProperty>();
            try
            {
                var manager = new ManagementClass(className);
                foreach (var obj in manager.GetInstances())
                {
                    // Явно указываем полное имя для встроенного PropertyData
                    foreach (System.Management.PropertyData prop in manager.Properties)
                    {
                        object value = obj[prop.Name];
                        if (value != null)
                        {
                            result.Add(new WmiProperty
                            {
                                ClassName = className,
                                PropertyName = prop.Name,
                                PropertyValue = Convert.ToString(value)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Add(new WmiProperty
                {
                    ClassName = className,
                    PropertyName = "Error",
                    PropertyValue = ex.Message
                });
            }
            return result;
        }
    }
}