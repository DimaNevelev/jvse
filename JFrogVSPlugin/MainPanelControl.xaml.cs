namespace JFrogVSPlugin
{
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Controls;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.Globalization;
    using JFrogVSPlugin.Data;

    /// <summary>
    /// Interaction logic for MainPanelControl.
    /// </summary>
    public partial class MainPanelControl : UserControl
    {
     
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPanelControl"/> class.
        /// </summary>
        public MainPanelControl()
        {
            this.InitializeComponent();
            this.DataContext = new MainViewModel();
        }

        /// <summary>
        /// Handles Refresh button.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event args.</param>
        private void RefreshTree(object sender, RoutedEventArgs e)
        {
            ((MainViewModel)this.DataContext).Refresh();
        }

        /// <summary>
        /// Handles click on the button by displaying a message box.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event args.</param>
        private void ColapseTree(object sender, RoutedEventArgs e)
        {
            ((MainViewModel)this.DataContext).Refresh();
        }

        /// <summary>
        /// Handles click on the button by displaying a message box.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event args.</param>
        private void ExpandTree(object sender, RoutedEventArgs e)
        {

            ((MainViewModel)this.DataContext).ExpandAll();
        }

        /// <summary>
        /// Handles click on the button by displaying a message box.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event args.</param>
        private void CollapseTree(object sender, RoutedEventArgs e)
        {
            ((MainViewModel)this.DataContext).CollapseAll();
        }

        private void HandleCheck(object sender, RoutedEventArgs e)
        {
            text1.Text = "The CheckBox " + ((CheckBox)e.Source).Content + " is checked.";
            if (((CheckBox)e.Source).Content.Equals("All"))
            {
                cbCriticall.IsChecked = true;
                cbMajor.IsChecked = true;
                cbMinor.IsChecked  = true;
                cbUnknown.IsChecked = true;
                cbNormal.IsChecked = true;
            }
            ((MainViewModel)this.DataContext).AddSeverityToFilter(((CheckBox)e.Source).Content.ToString());
        }

        private void HandleUnchecked(object sender, RoutedEventArgs e)
        {
            text1.Text = "The CheckBox " + ((CheckBox)e.Source).Content + " is unchecked.";
            if (((CheckBox)e.Source).Content.Equals("All"))
            {
                cbCriticall.IsChecked = false;
                cbMajor.IsChecked = false;
                cbMinor.IsChecked = false;
                cbUnknown.IsChecked = false;
                cbNormal.IsChecked = false;
            }
            ((MainViewModel)this.DataContext).AddSeverityToFilter(((CheckBox)e.Source).Content.ToString());
        }
        private void OpenFilter(object sender, RoutedEventArgs e)
        {
            FilterPopup.IsOpen = true;
        }
    }
}