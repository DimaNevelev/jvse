using JFrogVSPlugin.Data.ViewModels;
using Microsoft.VisualStudio.Shell.Interop;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using Xray.Data;
using EnvDTE;
using EnvDTE80;

namespace JFrogVSPlugin.Tree
{
    /// <summary>
    /// Interaction logic for Tree.xaml.
    /// </summary>
    [ProvideToolboxControl("JFrogVSPlugin.Tree.Tree", true)]
    public partial class Tree : UserControl
    {

        public Tree()
        {
            InitializeComponent();
           // this.DataContext = new TreeViewModel();
        }

        private void SelectionChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            ((TreeViewModel)this.DataContext).SelectedKey = ((ArtifactViewModel)e.NewValue).Key;
        }
    }
}
