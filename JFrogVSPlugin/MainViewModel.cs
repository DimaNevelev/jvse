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

namespace JFrogVSPlugin
{
    class MainViewModel : BaseViewModel
    {
        #region Public Properties
        public TreeViewModel Tree { get; private set; }
        #endregion
        
        #region constractor
        public MainViewModel()
        {
            this.Tree = new TreeViewModel();
        }

        public void Refresh()
        {
            this.Tree = new TreeViewModel();
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
        #endregion
    }
}
