using System.Collections.Generic;

namespace SystemInfoApp_2.Models
{
    public class WmiCategory
    {
        public string CategoryName { get; set; }
        public List<WmiClassInfo> Classes { get; set; }
    }
}
