using JFrogVSPlugin.Data.ViewModels;
using Microsoft.VisualStudio.Imaging.Interop;
using System.Collections.Generic;

namespace JFrogVSPlugin.Data
{
    public class DataService
    {
        private static DataService instance;
        private Dictionary<string, Component> components;
        public List<string> RootElements { get; private set; }
        public HashSet<Severity> Severities {
            set
            {
                // todo filter rootElements and components
            }
        }
        private DataService()
        {
            InitializeComponent();
        }
        public static DataService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataService();
                }
                return instance;
            }
        }

        public void Refresh(bool hard)
        {

        }

        public Component getComponent(string key)
        {
            return components[key];
        }

        private void InitializeComponent()
        {
            this.RootElements = new List<string> { "aa:1.1", "c:3" };
            this.components = new Dictionary<string, Component>();
            Component component1 = new Component
            {
                Key = "aa:1.1",
                Artifact= "aa",
                Name = "aa",
                Group = "org.borg",
                Version = "1.1",
                Type = "Nuget",
                Dependencies = new List<string> {"b:2", "c:3", "a:1"},
                TopSeverity = Severity.Major,
                Issues = new List<Issue>
                {
                    new Issue(Severity.Minor, "some text1", "Securty", "c:3"),
                    new Issue(Severity.Normal, "some text1", "Securty", "c:3"),
                    new Issue(Severity.Major, "FasterXML jackson-databind through 2.8.10 and 2.9.x through 2.9.3 allows unauthenticated remote code execution because of an incomplete fix for the CVE-2017-7525 deserialization flaw. This is exploitable by sending maliciously crafted JSON input to the readValue method of the ObjectMapper, bypassing a blacklist that is ineffective if the Spring libraries are available in the classpath.", "Securty", "com.fasterxml.jackson.core:jackson-databind:2.9.3"),
                    new Issue(Severity.Major, "some text1", "Securty", "aa:1.1"),
                    new Issue(Severity.Major, "FasterXML jackson-databind through 2.8.10 and 2.9.x through 2.9.3 allows unauthenticated remote code execution because of an incomplete fix for the CVE-2017-7525 deserialization flaw. This is exploitable by sending maliciously crafted JSON input to the readValue method of the ObjectMapper, bypassing a blacklist that is ineffective if the Spring libraries are available in the classpath.", "Securty", "com.fasterxml.jackson.core:jackson-databind:2.9.3")
                }
            };
            this.components.Add(component1.Key, component1);

            Component component2 = new Component
            {
                Key = "a:1",
                Name = "a",
                Group = "org.borg",
                Artifact = "a",
                Version = "1",
                Type = "Nuget",
                TopSeverity = Severity.Normal
            };
            this.components.Add(component2.Key, component2);

            Component component3 = new Component
            {
                Key = "b:2",
                Name = "b",
                Group = "org.borg",
                Artifact = "b",
                Version = "2",
                Type = "Nuget",
                Dependencies = new List<string> { "c:3" },
                TopSeverity = Severity.Minor,
                Issues = new List<Issue>
                {
                    new Issue(Severity.Minor, "some text3", "Securty", "c:3"),
                    new Issue(Severity.Normal, "some tex3", "Securty", "c:3")
                }
            };
            this.components.Add(component3.Key, component3);

            Component component4 = new Component
            {
                Key = "c:3",
                Name = "c",
                Group = "org.borg",
                Artifact = "c",
                Version = "3",
                Type = "Nuget",
                TopSeverity = Severity.Minor,
                Issues = new List<Issue>
                {
                    new Issue(Severity.Minor, "some text4", "Securty", "c:3"),
                    new Issue(Severity.Normal, "some text4", "Securty", "c:3")
                }
            };
            this.components.Add(component4.Key, component4);
        }
    }

    public class Component : BaseViewModel
    {
        public string Key { get; set; }
        public string Group { get; set; }
        public string Package { get; set; }
        public string Artifact { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string Type { get; set; }
        public string Licenses { get; set; }
        public Severity TopSeverity { get; set; }
        public List<string> Dependencies { get; set; }
        public List<Issue> Issues { get; set; }
    }

    public class Issue : BaseViewModel
    {
        public Issue() { }
        public Issue(Severity severity, string summery, string issueType, string component)
        {
            this.Severity = severity;
            this.Summary = summery;
            this.IssueType = issueType;
            this.Component = component;
        }
        public Severity Severity { get; set; }
        public string Summary { get; set; }
        public string IssueType { get; set; }
        public string Component { get; set; }
        public ImageMoniker SeveretyMoniker {
            get
            {
                return JFrogMonikerSelector.SeverityToMoniker(Severity);
            }
        }
    }

    public enum Severity
    {
        Critical, Major, Minor, Normal, Unknown
    }

    public enum RefreshType
    {
        Hard, Soft, None
    }

}

