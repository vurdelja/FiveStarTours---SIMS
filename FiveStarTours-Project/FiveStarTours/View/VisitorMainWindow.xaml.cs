using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FiveStarTours.View
{
    /// <summary>
    /// Interaction logic for VisitorMainWindow.xaml
    /// </summary>
    public partial class VisitorMainWindow : Window
    {
        public VisitorMainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //CC.Content = new ToursListingView();
            ToursListingView toursListing = new ToursListingView();
            toursListing.Show();
       }

        /*private class CC
        {
            public static ToursListingView Content { get; internal set; }
        }*/
    }
}
