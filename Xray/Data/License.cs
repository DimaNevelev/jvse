using System;
using System.Collections.Generic;
using System.Text;

namespace Xray.Data
{
    public class License
    {
        public List<string> Components { get; set; }
        public string FullName { get; set; }
        public string Name { get; set; }
        public List<string> MoreInfoUrl { get; set; }
    }
}
