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
    /// Interaction logic for OwnerMainWindow.xaml
    /// </summary>
    public partial class OwnerMainWindow : Window
    {
        public OwnerMainWindow()
        {
            InitializeComponent();
        }

        private void OwnerMainButton_Click(object sender, RoutedEventArgs e)
        {
            AddAccommodationView addAccommodation = new AddAccommodationView();
            addAccommodation.Show();
        }
    }
}
