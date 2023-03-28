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

namespace FiveStarTours.View.Traveler
{
    /// <summary>
    /// Interaction logic for NewDates.xaml
    /// </summary>
    public partial class NewDates : Page
    {
        public NewDates()
        {
            InitializeComponent();
        }

        private void back(object sender, RoutedEventArgs e)
        {
            Reservation rs = new Reservation();
            rs.Show();
        }
    }
}
