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
    /// Interaction logic for TravelerViewandSearch.xaml
    /// </summary>
    /// 

    public partial class TravelerViewandSearch : Window
    {

        public static ObservableCollection<Accommodation> Accommodations { get; set; }
        public Accommodation SelectAccommodation { get; set; }
        private readonly AccommodationsRepository accommodationsRepository;
        private readonly LocationsRepository locationsRepository;
        public TravelerViewandSearch()
        {
            InitializeComponent();
            DataContext = this;
            accommodationsRepository = new AccommodationsRepository();
            locationsRepository = new LocationsRepository();
            Accommodations = new ObservableCollection<Accommodation>(accommodationsRepository.GetAll());
        }
        private string _accomodationName;
        public string AccomodationName
        {
            get => _accomodationName;
            set
            {
                _accomodationName = value;
                OnPropertyChanged();
            }
        }
        private string _accomodationLocation;
        public string AccomodationLocation
        {
            get => _accomodationLocation;
            set
            {
                _accomodationLocation = value;
                OnPropertyChanged();
            }
        }
        private string _accomodationType;
        public string AccomodationType
        {
            get => _accomodationType;
            set
            {
                _accomodationType=value;
                OnPropertyChanged();
            }
        }

        private string _maxGuestNum;
        public string MaxGuestNum
        {
            get
            {
                return _maxGuestNum;
            }
            set
            {
                _maxGuestNum = value;
                OnPropertyChanged();
            }
        }


        private string _minReservationDays;
        public string MinReservationDays
        {
            get
            {
                return _minReservationDays;
            }
            set
            {
                _minReservationDays = value;
                OnPropertyChanged();
            }
        }

        
        private string _daysPossibleToCancel;
        public string DaysPossibleToCancel
        {
            get
            {
                return _daysPossibleToCancel;
            }
            set
            {
                _daysPossibleToCancel = value;
                OnPropertyChanged();
            }
        }

       
        private string _imageURLs;

        public string ImageURLs
        {
            get => _imageURLs;
            set
            {
                if (value != _imageURLs)
                {
                    _imageURLs = value;
                    OnPropertyChanged();
                }
            }
        }
        public string selectedCity;
        public string selectedState;
        private Location GetSelectedLocation()
        {
            foreach (var location in locationsRepository.GetAll())
            {
                if (location.City == selectedCity)
                {
                    return location;
                }
            }
            return null;
        }


        private void Search_enter(object sender, RoutedEventArgs e)
        {
            string searchterm = SearchNtb.Text;
            string searchterm1 = SearchLtb.Text;
            string searchterm2 = SearchGtb.Text;
            string searchterm3 = SearchLentb.Text;
           

           


        }

        private string _selectedImage;
        public string SelectedImage
        {
            get { return _selectedImage; }
            set
            {
                _selectedImage = value;
                OnPropertyChanged("SelectedImage");
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string properyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(properyName));
        }

        private void Reserve(object sender, RoutedEventArgs e)
        {
            Reservation rs = new Reservation();
            rs.Show();
        }
    }


}
