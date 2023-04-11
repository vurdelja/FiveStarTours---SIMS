using FiveStarTours.Model;
using FiveStarTours.Model.Enums;
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

namespace FiveStarTours.View.Traveler
{
    /// <summary>
    /// Interaction logic for ChangeReservation.xaml
    /// </summary>
    public partial class ChangeReservation : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private AccommodationReservationsRepository _accommodationReservationsRepository;
        private ReservationChangeRepository _reservationChangeRepository;
        public DateTime NewStartDate { get; set; }
        public DateTime NewEndDate { get; set; }
        public static ObservableCollection<AccommodationReservation> AccommodationReservations { get; set; }
        public AccommodationReservation SelectedAccommodationReservation { get; set; }
        private string _visitationDays;
        public string VisitationDays
        {
            get => _visitationDays;
            set
            {
                _visitationDays = value;
                OnPropertyChanged();
            }
        }
        private string _accommodationName;
        public string AccommodationName
        {
            get => _accommodationName;
            set
            {
                _accommodationName = value;
                OnPropertyChanged();
            }
        }
        private string _guestNumber;
        public string GuestNumber
        {
            get => _guestNumber;
            set
            {
                _guestNumber = value;
                OnPropertyChanged();
            }
        }
        public ChangeReservation(AccommodationReservation selectedReservation)
        {
            InitializeComponent();
            this.DataContext = this;
            SelectedAccommodationReservation = selectedReservation;
            _accommodationReservationsRepository = AccommodationReservationsRepository.GetInstace();
            _reservationChangeRepository = new ReservationChangeRepository();
            NewStartDate = DateTime.Now;
            NewEndDate = DateTime.Now;

        }
        protected virtual void OnPropertyChanged([CallerMemberName] string properyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(properyName));
        }

        private void SubmitChanges(object sender, RoutedEventArgs e)
        {
            ReservationChange reservationChange = new ReservationChange(-1, SelectedAccommodationReservation, NewStartDate, NewEndDate, ReservationChangeStatusType.Processing, false, "");
            _reservationChangeRepository.Save(reservationChange);
            
        }
    }
}

