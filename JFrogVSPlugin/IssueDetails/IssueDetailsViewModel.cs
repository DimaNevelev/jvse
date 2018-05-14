using JFrogVSPlugin.Data;
using JFrogVSPlugin.Data.ViewModels;
using System.Collections.ObjectModel;

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
                return;
            }
            IssueDetails = new ObservableCollection<Issue>(component.Issues);
        }
    }
}
