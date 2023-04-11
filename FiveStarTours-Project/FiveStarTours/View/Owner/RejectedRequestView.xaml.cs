using FiveStarTours.Model;
using FiveStarTours.Repository;
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

namespace FiveStarTours.View.Owner
{
    /// <summary>
    /// Interaction logic for FullRequestView.xaml
    /// </summary>
    public partial class RejectedRequestView : Window
    {
        public RejectedRequestView(ReservationChange selectedRequest)
        {
            InitializeComponent();
            DataContext = this;

            _selectedRequest = selectedRequest;
        }

        public ReservationChange _selectedRequest { get; set; }



        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
