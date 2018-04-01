using System;
using System.Collections.Generic;
using System.Text;

namespace Xray.Data
{
    public class Artifact
    {
        public GeneralInfo general { get; set; } = new GeneralInfo();
        public HashSet<Issue> Issues { get; set; } = new HashSet<Issue>();
        public HashSet<License> Licences { get; set; } = new HashSet<License>();
        public List<string> Dependencies { get; set; } = new List<string>();
        public object Dependency { get; set; }
    }
}
