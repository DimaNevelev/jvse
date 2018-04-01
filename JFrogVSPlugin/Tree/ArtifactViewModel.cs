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
            this.ExpandCommand = new RelayCommand(Expand);
            this.Key = key;
            string json = System.IO.File.ReadAllText(@"C:\Users\Dima\source\repos\jvse\data\tree.json");
            var componentsList = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, dynamic>>>(json);
            if (!componentsList.ContainsKey(this.Key) || !componentsList[this.Key].ContainsKey("dependencies"))
            {
                return;
            }

            string[] dependencies = componentsList[this.Key]["dependencies"].ToObject<string[]>();
            if (dependencies != null && dependencies.Length > 0)
            {
                this.Dependencies = new ObservableCollection<string>(dependencies);
            }
        }
        #region Public Commands

        public ICommand ExpandCommand { get; set; }
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
           // componentsList.
        }

        private void ClearChildren()
        {
            this.Children = null;
        }

        //public Artifact Artifact { get; set; }

    }
}
