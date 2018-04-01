using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace JFrogVSPlugin.Details
{
    /// <summary>
    /// Interaction logic for Details.xaml.
    /// </summary>
    [ProvideToolboxControl("JFrogVSPlugin.Details.Details", true)]
    public partial class Details : UserControl
    {
        public Details()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(string.Format(CultureInfo.CurrentUICulture, "We are inside {0}.Button1_Click()", this.ToString()));
        }
    }
}
