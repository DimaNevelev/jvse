using System;
using System.Collections.Generic;
using System.Text;

namespace Xray.Data
{
    public class Issue
    {
        public String Created { get; set; }
        public String Description { get; set; }
        public String IssueType { get; set; } = "N/A";
        public String Provider { get; set; }
        public Severity Severity { get; set; } = Severity.Normal;
        public String Summary { get; set; }
        public String Component { get; set; } = "";
    }
}
