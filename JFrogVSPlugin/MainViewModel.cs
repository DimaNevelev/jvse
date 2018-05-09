using JFrogVSPlugin.Data.ViewModels;
using JFrogVSPlugin.Tree;
using Microsoft.VisualStudio.PlatformUI;
using Microsoft.VisualStudio.Imaging.Interop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JFrogVSPlugin.Data;

namespace JFrogVSPlugin
{
    class MainViewModel : BaseViewModel
    {
        #region Public Properties
        public TreeViewModel Tree { get; private set; }
        #endregion

        #region Private Properties
        private HashSet<Severity> Severities { get; set; }
        #endregion

        #region constractor
        public MainViewModel()
        {
            Severities = new HashSet<Severity>();
            ResetSeverities();
            this.Tree = new TreeViewModel(RefreshType.Soft, Severities);
        }

        public void Refresh()
        {
            this.Tree = new TreeViewModel(RefreshType.Hard, Severities);
        }

        public void ExpandAll()
        {
            if (Tree.Artifacts != null)
            {
                foreach (var artifact in Tree.Artifacts)
                {
                    artifact.ExpandAll();
                }
            }
        }
        public void CollapseAll()
        {
            if (Tree.Artifacts != null)
            {
                foreach (var artifact in Tree.Artifacts)
                {
                    artifact.IsExpanded = false;
                }
            }
        }

        public void AddSeverityToFilter(string severityName)
        {
            if (severityName.Equals("All"))
            {
                ResetSeverities();
            }
            else
            {
                Severity severity = (Severity)Enum.Parse(typeof(Severity), severityName);
                Severities.Add(severity);
            }
            this.Tree = new TreeViewModel(RefreshType.None, Severities);
        }

        public void RemoveSeverityFromFilter(string severityName)
        {
            if (severityName.Equals("All"))
            {
                Severities = new HashSet<Severity>();
            }
            this.Tree = new TreeViewModel(RefreshType.None, Severities);
        }

        public void ResetSeverities()
        {
            foreach (Severity severity in Enum.GetValues(typeof(Severity)))
            {
                Severities.Add(severity);
            }
        }
        #endregion
    }
}
