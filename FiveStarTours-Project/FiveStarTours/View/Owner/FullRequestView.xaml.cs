using FiveStarTours.Model;
using FiveStarTours.Repository;
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
using System.Windows.Shapes;

namespace FiveStarTours.View.Owner
{
    /// <summary>
    /// Interaction logic for FullRequestView.xaml
    /// </summary>
    public partial class FullRequestView : Window
    {
        public ReservationChange _selectedRequest { get; set; }


        private readonly ReservationChangeRepository _requestRepository;
        public ReservationChange reservationChange { get; set; }



        public FullRequestView(ReservationChange selectedRequest)
        {
            InitializeComponent();
            DataContext = this;

            _selectedRequest = selectedRequest;
            _requestRepository = ReservationChangeRepository.GetInstance();

            reservationChange = new ReservationChange();
            reservationChange = _selectedRequest;
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void DeclineButton_Click(object sender, RoutedEventArgs e)
        {
            _selectedRequest.Status = Model.Enums.ReservationChangeStatusType.Rejected;
            _requestRepository.Update(_selectedRequest);
            Close();
        }


        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
