namespace JFrogVSPlugin
{
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Controls;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.Globalization;


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

    }
}