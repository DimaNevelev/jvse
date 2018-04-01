using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace JFrogVSPlugin.IssueDetails
{
    /// <summary>
    /// Interaction logic for IssueDetails.xaml.
    /// </summary>
    [ProvideToolboxControl("JFrogVSPlugin.IssueDetails.IssueDetails", true)]
    public partial class IssueDetails : UserControl
    {
        public IssueDetails()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(string.Format(CultureInfo.CurrentUICulture, "We are inside {0}.Button1_Click()", this.ToString()));
        }
    }
}
