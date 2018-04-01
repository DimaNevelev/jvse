using System;
using System.Collections.Generic;
using System.Text;

namespace Xray.Data
{
    public class GeneralInfo
    {
        public String ComponentId { get; set; } = "";
        public String Name { get; set; } = "";
        public String Path { get; set; } = "";
        public String PkgType { get; set; } = "";
        public String Sha256 { get; set; } = "";
    }
}
