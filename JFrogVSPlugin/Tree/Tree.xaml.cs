using JFrogVSPlugin.Data.ViewModels;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

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
            this.DataContext = new TreeViewModel();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(string.Format(CultureInfo.CurrentUICulture, "We are inside {0}.Button1_Click()", this.ToString()));
        }
    }
}
