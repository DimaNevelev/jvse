using System.Collections.Generic;
using Xray.Data;
using Newtonsoft.Json;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.Shell;
using EnvDTE;
using NuGet.VisualStudio;
using System.ComponentModel.Composition;

namespace JFrogVSPlugin.Utils
{
    public class TreeStructure
    {
        public static List<Artifact> GetRootElemnts()
        {
            dynamic rootElementsJson = JsonConvert.DeserializeObject(System.IO.File.ReadAllText(@"C:\Dima\root-elements.json"));
            dynamic allArtifacts = JsonConvert.DeserializeObject(System.IO.File.ReadAllText(@"C:\Dima\tree.json"));
            List<Artifact> rootElements = new List<Artifact>();
            foreach (var element in rootElementsJson)
            {
                var artifact = new Artifact();
                rootElements.Add(getArtifact(element.Name, allArtifacts));
            }
            return rootElements;
        }

        private static Artifact getArtifact(string artifactKey, dynamic artifacts)
        {
            Artifact artifact = new Artifact();
            artifact.general.Name = artifactKey;
            artifact.general.ComponentId = artifactKey;
            artifact.general.Sha256 = "1111";
            artifact.general.PkgType = artifacts.get(artifactKey).type;
            artifact.Issues = getIssues(artifacts.get(artifactKey).Issues);
            artifact.Dependencies = artifacts.get(artifactKey).dependencies;
            return artifact;
        }

        private static HashSet<Issue> getIssues(dynamic issuesObject)
        {
            HashSet <Issue> issues = new HashSet<Issue>();
            foreach (dynamic issueObject in issuesObject)
            {
                Issue issue = new Issue();
                issues.Add(issue);
            }
            return issues;
        }
    }
}