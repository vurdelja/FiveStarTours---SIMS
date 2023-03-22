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

    public partial class TravelerViewandSearch : Window,INotifyPropertyChanged
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


        private string _accomodationMaxGuest;
        public string AccomodationMaxGuest
        {
            get
            {
                return _accomodationMaxGuest;
            }
            set
            {
                _accomodationMaxGuest = value;
                OnPropertyChanged();
            }
        }


        private string _accomodationMinReservationDays;
        public string AccomodationMinReservationDays
        {
            get
            {
                return _accomodationMinReservationDays;
            }
            set
            {
                _accomodationMinReservationDays = value;
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
            Accommodations.Clear();
            foreach (Accommodation accommodation in Accommodations)
            {
                Accommodations.Add(accommodation);
            }
            /*String Name = NameSearch.Text;
            String State = StateSearch.Text;
            String City = CitySearch.Text;
            String GuestNum = NumberSearch.Text;
            String LengtH=LengthSearch.Text;
            List<Accommodation>ac=new List<Accommodation>();
            */
            String Name = NameSearch.Text;
            String[] splitLocation = StateSearch.Text.Split(",");
            String[] splitLocation1 = CitySearch.Text.Split(",");
            String[] splitNumber = NumberSearch.Text.Split(",");
            String[] splitType = TypeBox.Text.Split(",");
            String[] splitLeng = LengthSearch.Text.Split(",");



            int max = 0;
            int min = 0;
            if (!(int.TryParse(NumberSearch.Text, out max) || (NumberSearch.Text.Equals(""))) || !(int.TryParse(LengthSearch.Text, out min) || (LengthSearch.Text.Equals(""))))
            {
                return;
            }
            foreach (Accommodation accommodation in Accommodations)
            {
                if (accommodation.Name.ToLower().Contains(NameSearch.Text.ToLower()) && accommodation.Location.State.ToLower().Contains(StateSearch.Text.ToLower()) && accommodation.Location.City.ToLower().Contains(CitySearch.Text.ToLower()) && (accommodation.MaxGuestNum - max >= 0 || NumberSearch.Text.Equals("")) && (accommodation.MinReservationDays - min <= 0 || LengthSearch.Text.Equals("")) && accommodation.Type.Equals(TypeBox))
                {
                    Accommodations.Add(accommodation);

                }


            }
        }
        /* foreach(Accommodation accommodation in Accommodations)
         {
             if(AllMatchesGood(accommodation, _accomodationName, _accomodationLocation, _accomodationMaxGuest, _accomodationType, _accomodationMinReservationDays))
             {
                 if(!Accommodations.Contains(accommodation))
                     Accommodations.Add(accommodation);
                 MyDisplay.ItemsSource = Accommodations;
             }

         }
         MyDisplay.ItemsSource = Accommodations;
     }

     private bool AllMatchesGood(Accommodation accommodation, string _accomodationName, string _accomodationLocation, string _accomodationMaxGuest, _accomodationType, _accomodationMinReservationDays)
     {
         bool same = false;
         if ((_accomodationName.ToLower().Trim().Contains(Name) || string.IsNullOrEmpty(Name)) &&
             (GuestNumGoodMatch(_accomodationMaxGuest,AccomodationMaxGuest) || string.IsNullOrEmpty(MaxGues)) &&
             (MinReservationGoodMatch(_accommodationMinResevationDays, MinReservationDays) || string.IsNullOrEmpty(MinReservationDays)))
         {
             same = true;
         }
         return same;
     }

     public bool  GuestNumGoodMatch(Accommodation accommodation,string MaxGuestNum)
     {
         bool good = false;
         if(int.Parse(MaxGuestNum, out int parsedGuestNum)&& parsedGuestNum<=accommodation.MaxGuestNum)
         {
             good = true;
         }
         return good;
     }
     public bool MinReservationGoodMatch(Accommodation accommodation, string MinReservationDays)
     {
         bool good = false;
         if (int.Parse(MaxGuestNum, out int parsedReservation) && parsedReservation <= accommodation.MaxGuestNum)
         {
             good = true;
         }
         return good;
     }
        */


        private string _selectedReservation;
        public string SelectedReservation
        {
            get { return _selectedReservation; }
            set
            {
                _selectedReservation = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string properyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(properyName));
        }

        private void Reserve(object sender, RoutedEventArgs e)
        {
            if (SelectAccommodation != null)
            {
                string messageBoxText = "Are you sure you want to reserve this?";    
                string caption = "Reservation";
                MessageBoxButton button = MessageBoxButton.YesNo;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;

                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                if (result == MessageBoxResult.Yes)
                {
                   
                    Reservation rs = new Reservation();
                    rs.Show();

                }
                else
                {
                    return;
                }
            }
            Close();

        }


    }
}
