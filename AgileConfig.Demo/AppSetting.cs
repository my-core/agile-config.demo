using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgileConfig.Demo
{
    public class AppSetting
    {
        public bool IsProduction { get; set; }
        public string AppId { get; set; }
        public string AppSecret { get; set; }
        public List<string> IpList { get; set; }
    }
}
