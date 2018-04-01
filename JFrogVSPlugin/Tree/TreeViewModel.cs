using JFrogVSPlugin.Data.ViewModels;
using System.Collections.ObjectModel;
using Newtonsoft.Json;


namespace JFrogVSPlugin.Tree
{
    class TreeViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// TODO
        /// </summary>
        public ObservableCollection<ArtifactViewModel> Artifacts { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// TODO
        /// </summary>
        public TreeViewModel()
        {
            dynamic rootElementsJson = JsonConvert.DeserializeObject(System.IO.File.ReadAllText(@"C:\Users\Dima\source\repos\jvse\data\root-elements.json"));
            this.Artifacts = new ObservableCollection<ArtifactViewModel>();

            foreach (dynamic obj in rootElementsJson)
            {
                Artifacts.Add(new ArtifactViewModel(obj.Name));
            }
        }

        #endregion
    }
}
