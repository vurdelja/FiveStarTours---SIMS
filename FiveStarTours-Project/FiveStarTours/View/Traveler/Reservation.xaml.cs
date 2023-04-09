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
using FiveStarTours.Model;
using FiveStarTours.Repository;

namespace FiveStarTours.View.Traveler
{
    /// <summary>
    /// Interaction logic for Reservation.xaml
    /// </summary>
    public partial class Reservation : Window, INotifyPropertyChanged
    {
        private readonly AccommodationReservationsRepository accommodationReservationsRepository;
        private readonly AccommodationsRepository accommodationsRepository;
        public static ObservableCollection<AccommodationReservation> AccommodationReservations { get; set; }
        public event PropertyChangedEventHandler? PropertyChanged;
        public Accommodation SelectedAccommodation;


        protected virtual void OnPropertyChanged([CallerMemberName] string properyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(properyName));
        }

        public Reservation()
        {
            InitializeComponent();
            DataContext = this;
            accommodationReservationsRepository = new AccommodationReservationsRepository();
        }
        private string _guestName;
        public string GuestName
        {
            get => _guestName;
            set
            {
                if (value != _guestName)
                {
                    _guestName = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _guestSurname;
        public string GuestSurname
        {
            get => _guestSurname;
            set
            {
                if (value != _guestSurname)
                {
                    _guestSurname = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _visitationDays;
        public string VisitationDays
        {
            get => _visitationDays;
            set
            {
                if (value != _visitationDays)
                {
                    _visitationDays = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _guestNumber;
        public string GuestNumber
        {
            get => _guestNumber;
            set
            {
                if (value != _guestNumber)
                {
                    _guestNumber = value;
                    OnPropertyChanged();
                }
            }
        }
 
        private string _rated;
        public string Rated
        {
            get => _rated;
            set
            {
                if (value != _rated)
                {
                    _rated = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _accommodationName;
        public string AccommodationName
        {
            get => _accommodationName;
            set
            {
                if (value != _accommodationName)
                {
                    _accommodationName = value;
                    OnPropertyChanged();
                }
            }
        }
       

        private void goback(object sender, RoutedEventArgs e)
        {
            TravelerViewandSearch tvs = new TravelerViewandSearch();
            tvs.Show();
        }

        int availableDates
        {
            get; set;
        }

        List<DateTime> Start = new List<DateTime>();
        private DateTime firstSelectedDate;

        List<DateTime> End = new List<DateTime>();
        private DateTime lastSelectedDate;

        public void SelestedDate(DateTime dateTime)
        {
            firstSelectedDate = (DateTime)first.SelectedDate;
            

        }
        private void SelectedDate(DateTime dateTime)
        {
            lastSelectedDate = (DateTime)last.SelectedDate;
        }
        
        
        private void Submit(object sender, RoutedEventArgs e)
        {
            int visitationDays = int.Parse(VisitationDays);
            int guestNumber = int.Parse(GuestNumber);
           

            int min = 0;
            if (!(int.TryParse(Lengthtxt.Text, out min)) || (Lengthtxt.Text.Equals("")))
            {
                return;
            }
            AccommodationReservation newRes = new AccommodationReservation(GuestName, GuestSurname, firstSelectedDate, lastSelectedDate, visitationDays, AccommodationName, guestNumber);
            accommodationReservationsRepository.Save(newRes);
            if(availableDates>Convert.ToInt32(VisitationDays))
            {
                MessageBox.Show($"There's no available dates for this reservation. Left seats : {availableDates}");
                
            }
            else
            {
                ComplitedReservationxaml cr = new ComplitedReservationxaml();
                cr.Show();
            }
            
            Close();

        }
    

    }
    }

