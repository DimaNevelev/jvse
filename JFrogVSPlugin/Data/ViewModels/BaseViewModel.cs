using PropertyChanged;
using System.ComponentModel;

namespace JFrogVSPlugin.Data.ViewModels
{
 //   [ImplementPropertyChanged]
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) =>{};
    }
}
