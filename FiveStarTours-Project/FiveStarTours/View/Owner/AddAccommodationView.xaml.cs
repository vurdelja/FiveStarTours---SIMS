using FiveStarTours.Model;
using FiveStarTours.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using System.Linq;
using System.Text.RegularExpressions;
using System.Security.AccessControl;
using System.Xml.Linq;

namespace FiveStarTours.View
{
    public partial class AddAccommodationView : Window
    {
        
        private readonly LocationsRepository _locationsRepository;
        private readonly AccommodationsRepository _accommodationsRepository;


        public AddAccommodationView()
        {
            InitializeComponent();
            DataContext = this;

            _locationsRepository = new LocationsRepository();
            _accommodationsRepository = new AccommodationsRepository();


            // Adding state and city trough combobox:

            List<string> States = _locationsRepository.GetAllStates();
            stateComboBox.ItemsSource = States;
            stateComboBox.SelectedValuePath = ".";
            stateComboBox.DisplayMemberPath = ".";
        }

        //Name
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


        //Location - state and city
        private string selectedState;
        private string selectedCity;

        private void stateComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (stateComboBox.SelectedItem != null)
            {

                string selectedStateComboBox = stateComboBox.SelectedItem.ToString();
                List<string> citiesInState = _locationsRepository.GetCitiesInState(selectedStateComboBox);
                cityComboBox.ItemsSource = citiesInState;
                selectedState = stateComboBox.SelectedItem as string;
            }
        }

        private void cityComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cityComboBox.SelectedItem != null)
            {
                selectedCity = cityComboBox.SelectedItem as string;
            }
        }

        private Location GetSelectedLocation()
        {
            foreach (var location in _locationsRepository.GetAll())
            {
                if (location.City == selectedCity)
                {
                    return location;
                }
            }
            return null;
        }

        //Accommodation type
        public AccommodationType accommodationType;

        //Accommodation max guest number
        public int _maxGuestNum;
        public int MaxGuestNum
        {
            get => _maxGuestNum;
            set
            {
                if (value != _maxGuestNum)
                {
                    _maxGuestNum = value;
                    OnPropertyChanged();
                }
            }
        }


        //Min days to make reservation
        private int _minReservationDays;
        public int MinReservationDays
        {
            get => _minReservationDays;
            set
            {
                if (value != _minReservationDays)
                {
                    _minReservationDays = value;
                    OnPropertyChanged();
                }
            }
        }



        //Days possible to cancel
        private int _daysPossibleToCancel = 1;
        public int DaysPossibleToCancel
        {
            get => _daysPossibleToCancel;
            set
            {
                if (value != _daysPossibleToCancel)
                {
                    _daysPossibleToCancel = value;
                    OnPropertyChanged();
                }
            }
        }

        //Images
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private void SubmitRegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            Location location = GetSelectedLocation();

            List<string> ImageURLsList = new List<string>();
            if (ImageURLs != null)
            {
                ImageURLsList = MakeUrlsList(ImageURLs);
            }
            else return;

            string AccType = AccommodationTypeComboBox.Text;

            if (AccType.Equals("apartment"))
            {
                accommodationType = AccommodationType.apartment;
            }
            else if (AccType.Equals("house"))
            {
                accommodationType = AccommodationType.house;
            }
            else if (AccType.Equals("cottage"))
            {
                accommodationType = AccommodationType.cottage;
            }


            Accommodation newAccommodation = new Accommodation(
                    AccommodationName,
                    location,
                    accommodationType,
                    MaxGuestNum,
                    MinReservationDays,
                    DaysPossibleToCancel,
                    ImageURLsList
                );


            if(IsValid(newAccommodation))
            {
                _accommodationsRepository.Save(newAccommodation);
                Close();
            }
            else
            {
                MessageBox.Show("You must provide all info on your accommodation.");
            }
            

        }

        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                if (columnName == "AccommodationName")
                {
                    if (string.IsNullOrEmpty(AccommodationName))
                        return "AccommodationName is required";
                }
                else if (columnName == "MaxGuestNum")
                {
                    if (MaxGuestNum <1)
                        return "Type is required";
                }

                else if (columnName == "MinReservationDays")
                {
                    if (MinReservationDays<1)
                        return "Type is required";
                }
                else if (columnName == "DaysPossibleToCancel")
                {
                    if (DaysPossibleToCancel < 1)
                        return "Type is required";
                }
               

                return null;
            }
        }



        private readonly string[] _validatedProperties = { "AccommodationName", "MaxGuestNum", "MinReservationDays", "DaysPossibleToCancel"};



        public bool IsValid(Accommodation accommodation)
        {
            foreach (var property in _validatedProperties)
            {
                if (this[property] != null)
                    return false;
            }

            return true;
        }

        public static bool IsValidUrl(string url)
        {
            return Uri.IsWellFormedUriString(url, UriKind.Absolute);
        }



        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public List<string> MakeUrlsList(string urls)
        {
            List<string> result = new List<string>();

            Array _urls = urls.Split(", ");

            foreach (string url in _urls)
            {
                result.Add(url);
            }

            return result;
        }


    }
    
}

