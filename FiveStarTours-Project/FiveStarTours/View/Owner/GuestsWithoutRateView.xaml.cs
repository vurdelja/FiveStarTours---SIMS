using FiveStarTours.Model;
using FiveStarTours.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for GuestsWIthoutRateView.xaml
    /// </summary>
    public partial class GuestsWithoutRateView : Window
    {
        public static ObservableCollection<AccommodationReservation> Reservations { get; set; }

        public AccommodationReservation SelectedReservation { get; set; }   //SELEKTOVANA
        private readonly AccommodationReservationsRepository _repository;

        public GuestsWithoutRateView()
        {
            InitializeComponent();
            DataContext = this;
            _repository = new AccommodationReservationsRepository();
            Reservations = new ObservableCollection<AccommodationReservation>(_repository.GetUnratedAndLessThanFiveDaysAgo());

        }

        private void RateGuestsButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedReservation != null)
            {
                GuestRatingView guestRatingView = new GuestRatingView(SelectedReservation);
                guestRatingView.Show();
                Close();
                
            }
            else
            {
                MessageBox.Show("You must select the guest.");
            }
        }

        private void MaybeLaterButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
