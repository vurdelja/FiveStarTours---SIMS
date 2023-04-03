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

namespace FiveStarTours.View.Traveler
{
    /// <summary>
    /// Interaction logic for ReservationsView.xaml
    /// </summary>
    public partial class ReservationsView : Window, INotifyPropertyChanged
    {
        public static ObservableCollection<AccommodationReservation> Reservations { get; set; }
        public AccommodationReservation SelectedReservation { get; set; }
        private readonly AccommodationReservationsRepository accommodationReservationsRepository;


        public ReservationsView()
        {
            InitializeComponent();
            DataContext = this;
            accommodationReservationsRepository= new AccommodationReservationsRepository();
            Reservations = new ObservableCollection<AccommodationReservation>(accommodationReservationsRepository.GetAll());
        }
        private string _guestName;
        public string GuestName
        {
            get => _guestName;
            set
            {
                _guestName = value;
                OnPropertyChanged();
            }
        }
        private string _guestSurname;
        public string GuestSurname
        {
            get => _guestSurname;
            set
            {
                _guestSurname = value;
                OnPropertyChanged();
            }
        }
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

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string properyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(properyName));
        }

        private void Rate(object sender, RoutedEventArgs e)
        {
            AccommodationRatings rating = new AccommodationRatings();
            rating.Show();
        }
    }
}
