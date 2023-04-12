using FiveStarTours.Model;
using FiveStarTours.Repository;
using FiveStarTours.Services;
using FiveStarTours.View.Traveler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ManageRequestsView.xaml
    /// </summary>
    public partial class ManageRequestsView : Window
    {
        public User LoggedInUser { get; set; }
        public static ObservableCollection<ReservationChange> Requests { get; set; }

        public ReservationChange SelectedRequest { get; set; }   //SELEKTOVANA

        private readonly ReservationChangeService _service;

        
        public ManageRequestsView(User user)
        {
            InitializeComponent();
            DataContext = this;

            LoggedInUser = user;

            _service = new ReservationChangeService();
            Requests = new ObservableCollection<ReservationChange>(_service.GetAllProcessing());
        }

        private void ViewRequestButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedRequest != null)
            {
                FullRequestView fullRequest = new FullRequestView(SelectedRequest);
                fullRequest.Show();
                Close();
            }
            else
            {
                MessageBox.Show("You must select the request.");
            }


        }

        private void MaybeLaterButton_Click(object sender, RoutedEventArgs e)
        {
            OwnerMainWindow main = new OwnerMainWindow(LoggedInUser);
            main.Show();
            Close();
        }
        
    }
}
