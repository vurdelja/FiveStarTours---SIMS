using FiveStarTours.Model;
using FiveStarTours.Repository;
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
    /// Interaction logic for GuestReviewsView.xaml
    /// </summary>
    public partial class GuestReviewsView : Window
    {
        public static ObservableCollection<AccommodationReservation> Reservations { get; set; }

        public AccommodationReservation SelectedReservation { get; set; }   //SELEKTOVANA
        private readonly AccommodationReservationsRepository _repository;

        public GuestReviewsView()
        {
            InitializeComponent();
            DataContext = this;
            _repository = new AccommodationReservationsRepository();
            Reservations = new ObservableCollection<AccommodationReservation>(_repository.GetRatedByOwner());

        }

        private void ViewReviewButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedReservation != null)
            {
                FullGuestReviewView fullReview = new FullGuestReviewView(SelectedReservation);
                fullReview.Show();
                Close();
            }
            else
            {
                MessageBox.Show("You must select the review.");
            }


        }

        private void MaybeLaterButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
