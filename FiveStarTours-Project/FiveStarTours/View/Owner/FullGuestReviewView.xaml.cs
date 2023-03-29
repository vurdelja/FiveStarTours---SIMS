using FiveStarTours.Model;
using FiveStarTours.Repository;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for FullGuestReviewView.xaml
    /// </summary>
    public partial class FullGuestReviewView : Window
    {
        public AccommodationReservation _selectedReservation { get; set; }

        private readonly AccommodationReservationsRepository _repository;
        //private readonly GuestRatingsRepository _rateRepository;


        public FullGuestReviewView(AccommodationReservation selectedReservation)
        {
            InitializeComponent();
            DataContext = this;

            _selectedReservation = selectedReservation;


            _repository = new AccommodationReservationsRepository();
            //_rateRepository = new GuestRatingsRepository();

        }
    }
}
