using FiveStarTours.View;
using FiveStarTours.View.Traveler;
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
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace FiveStarTours
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OwnerButtonClick_Checked(object sender, RoutedEventArgs e)
        {
            OwnerMainWindow ownerWindow = new OwnerMainWindow();
            ownerWindow.Show();
        }

        private void TravelerButtonClick_Checked(object sender, RoutedEventArgs e)
        {
            TravelerMain tm = new TravelerMain();
            tm.Show();  

        }

        private void GuideButtonClick_Checked(object sender, RoutedEventArgs e)
        {
            Tours tours = new Tours();
            tours.Show();
        }

        private void VisitorButtonClick_Checked(object sender, RoutedEventArgs e)
        {
            VisitorMainWindow visitorWindow = new VisitorMainWindow();
            this.Visibility = Visibility.Hidden;
            visitorWindow.Show();
        }

        private void DriverButtonClick_Checked(object sender, RoutedEventArgs e)
        {
            DriverMainWindow driverWindow = new DriverMainWindow();
            driverWindow.Show();
        }
    }
}
