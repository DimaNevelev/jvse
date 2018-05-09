using JFrogVSPlugin.Data.ViewModels;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using JFrogVSPlugin.IssueDetails;
using JFrogVSPlugin.Data;
using System.Collections.Generic;

namespace JFrogVSPlugin.Tree
{
    class TreeViewModel : BaseViewModel
    {
        #region Private properties

        private string selectedKey;

        #endregion
        #region Public Properties

        /// <summary>
        /// TODO
        /// </summary>
        public ObservableCollection<ArtifactViewModel> Artifacts { get; set; }

        public ObservableCollection<Issue> IssueDetails { get; set; }

        public Component SelectedComponent { get; set; }

        public string SelectedKey
        {
            get { return selectedKey; }
            set
            {
                selectedKey = value;
                RaisePropertyChanged("SelectedKey");
                DataService dataService = DataService.Instance;
                SelectedComponent = dataService.getComponent(value);
                if (SelectedComponent != null && SelectedComponent.Issues != null)
                {
                    IssueDetails = new ObservableCollection<Issue>(SelectedComponent.Issues);
                } else
                {
                    IssueDetails = new ObservableCollection<Issue>();
                }
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// TODO
        /// </summary>
        public TreeViewModel(RefreshType refreshType, HashSet<Severity> severities)
        {
            DataService dataService = DataService.Instance;

            switch (refreshType)
            {
                case RefreshType.Hard:
                    {
                        dataService.Refresh(true);
                        break;
                    }

                case RefreshType.Soft:
                    {
                        dataService.Refresh(false);
                        break;
                    }
            }

            this.Artifacts = new ObservableCollection<ArtifactViewModel>();
            dataService.Severities = severities;
            foreach (string key in dataService.RootElements)
            {
                Artifacts.Add(new ArtifactViewModel(key));
            }
        }
        #endregion
    }
}
