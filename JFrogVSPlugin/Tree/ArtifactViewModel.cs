using Newtonsoft.Json;
using System;
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
        public ObservableCollection<ArtifactViewModel>  Children { get; set; }
        public bool Expandable { get { return this.Dependencies != null && this.Dependencies.Count > 0; } }

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
            this.Key = key;
            dynamic componentsList = JsonConvert.DeserializeObject(System.IO.File.ReadAllText(@"C:\Dima\tree.json"));
            var component = componentsList.get(this.Key);
            if (component.dependencies != null && component.dependencies.length > 0)
            {
                this.Dependencies = new ObservableCollection<String>(component.dependencies);
            }
        }
        #region Public Commands

        public ICommand ExpandCommand { get; set; }

        public ArtifactViewModel()
        {
            this.ExpandCommand = new RelayCommand(Expand);
        }
        #endregion


        private void Expand()
        {
            // todo some service should return dependencies
            this.Children = new ObservableCollection<ArtifactViewModel>();
            foreach (string key in this.Dependencies)
            {
                this.Children.Add(new ArtifactViewModel(key));
            }
           // componentsList.
        }

        private void ClearChildren()
        {
            this.Children = null;
        }

        //public Artifact Artifact { get; set; }

    }
}
