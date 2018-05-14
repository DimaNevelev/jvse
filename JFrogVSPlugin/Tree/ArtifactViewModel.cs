using Microsoft.VisualStudio.Imaging;
using Microsoft.VisualStudio.Imaging.Interop;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;


namespace JFrogVSPlugin.Data.ViewModels
{
    class ArtifactViewModel : BaseViewModel
    {
        #region Public Properties

        public string Key { get; set; }
        //public Severity Severity { get; set; }
        public int Issues { get; set; }
        public ObservableCollection<String> Dependencies { get; set; }
        public ObservableCollection<ArtifactViewModel> Children { get; set; }
        public ImageMoniker SeveretyMoniker { get; }


        public bool IsExpanded
        {
            get
            {
                return this.Children?.Count > 0 && this.Children[0] != null;
            }
            set
            {
                // If the UI tells us to expand...
                if (value == true)
                    // Find all children
                    Expand();
                // If the UI tells us to closeSS
                else
                   this.ClearChildren();
            }
        }
        #endregion

        public ArtifactViewModel(string key)
        {
            this.ExpandCommand = new RelayCommand(Expand);
            DataService dataService = DataService.Instance;
            this.Key = key;
            Component component = dataService.getComponent(key);
            this.SeveretyMoniker = JFrogMonikerSelector.GetSeverityMoniker(component.TopSeverity);
            if (component == null || component.Dependencies == null || component.Dependencies.Count == 0)
            {
                return;
            }
            this.Dependencies = new ObservableCollection<string>(component.Dependencies);
            // Setup an empty children
            this.ClearChildren();
        }

        

        #region Public Commands

        public ICommand ExpandCommand { get; set; }

        public void ExpandAll()
        {
            this.IsExpanded = true;
            if (this.Children != null)
            {
                foreach (var child in this.Children)
                {
                    child.ExpandAll();
                }
            }
        }
        #endregion


        private void Expand()
        {
            if(this.Dependencies == null || this.Dependencies.Count == 0)
            {
                return;
            }
            // todo some service should return dependencies
            this.Children = new ObservableCollection<ArtifactViewModel>();
            foreach (string key in this.Dependencies)
            {
                this.Children.Add(new ArtifactViewModel(key));
            }
        }

        private void ClearChildren()
        {
            this.Children = new ObservableCollection<ArtifactViewModel>
            {
                null
            };
        }
    }
}
