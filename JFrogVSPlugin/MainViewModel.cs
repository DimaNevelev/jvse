using JFrogVSPlugin.Data.ViewModels;
using JFrogVSPlugin.Tree;
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
        public TreeViewModel Tree { get; }      
        #endregion

        #region constractor
        public MainViewModel()
        {
            Tree = new TreeViewModel();
        }
        #endregion
    }
}
