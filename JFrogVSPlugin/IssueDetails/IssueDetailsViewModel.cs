using JFrogVSPlugin.Data;
using JFrogVSPlugin.Data.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFrogVSPlugin.IssueDetails
{
    public class IssueDetailsViewModel : BaseViewModel
    {
        #region Public Properties
        public ObservableCollection<Issue> IssueDetails { get; set; }
        #endregion

        public IssueDetailsViewModel(string SelectedKey)
        {
            DataService dataService = DataService.Instance;
            Component component = dataService.getComponent(SelectedKey);


            if (component == null || component.Issues == null || component.Issues.Count == 0)
            {
                // todo clean existing
                return;
            }
            IssueDetails = new ObservableCollection<Issue>(component.Issues);
        }
    }
}
