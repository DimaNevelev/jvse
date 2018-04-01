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
            dynamic rootElementsJson = JsonConvert.DeserializeObject(System.IO.File.ReadAllText(@"C:\Dima\root-elements.json"));
            this.Artifacts = new ObservableCollection<ArtifactViewModel>();

            foreach (string key in rootElementsJson)
            {
                this.Artifacts.Add(new ArtifactViewModel(key));
            }
        }

        #endregion
    }
}
