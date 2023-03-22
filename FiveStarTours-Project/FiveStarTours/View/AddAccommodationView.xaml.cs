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

namespace FiveStarTours.View
{
    public partial class AddAccommodationView : Window
    {
        
        private readonly LocationsRepository _locationsRepository;
        private readonly AccommodationsRepository _accommodationsRepository;

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string properyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(properyName));
        }

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
                _accommodationName = value;
                OnPropertyChanged();
            }
        }

    
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
        private AccommodationType accommodationType;

        /*private IEnumerable<AccommodationType> _AccommodationTypes;
        private string _SelectedAccommodationType;

        public IEnumerable<AccommodationType> AccommodationTypes
        {
            get
            {
                return (AccommodationType[])Enum.GetValues(typeof(AccommodationType));
            }
            set
            {
                if (value != _AccommodationTypes)
                {
                    _AccommodationTypes = value;
                    OnPropertyChanged();
                }
            }
        }
        public string SelectedAccommodationType
        {
            get { return _SelectedAccommodationType; }
            set
            {
                _SelectedAccommodationType = value;
                OnPropertyChanged();
            }
        }*/



        //Accommodation max guest number
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


        //Min days to make reservation
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

        //Min days to make reservation
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


        // Upload image button
        private void UploadImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog= new OpenFileDialog();
            openFileDialog.Filter = "Image files|*.bmp;*.jpg;*.png";
            openFileDialog.FilterIndex = 1;


            if (openFileDialog.ShowDialog() == true)
            {
                string[] selectedFiles = openFileDialog.FileNames;

                foreach (string file in selectedFiles)
                {
                    ImageURLs += file;
                    ImageURLs += "|";
                }

                ImageURLs = ImageURLs.Substring(0, ImageURLs.Length - 1);

                imagePicture.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }

        }

        //Submit button
        private void SubmitRegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            Location location = GetSelectedLocation();

            List<string> formattedImages = new List<string>();

            string[] delimitedImages = ImageURLs.Split(",");

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

            foreach (string imageURL in delimitedImages)
            {
                formattedImages.Add(imageURL);
            }

            int MaximumGuests = int.Parse(MaxGuestNum);
            int MinDays = int.Parse(MinReservationDays);
            int PossibleToCancel = int.Parse(DaysPossibleToCancel);


            Accommodation newAccommodation = new Accommodation(
                    AccommodationName,
                    location.Id,
                    location,
                    accommodationType,
                    MaximumGuests,
                    MinDays,
                    PossibleToCancel,
                    formattedImages
                );

            _accommodationsRepository.Save(newAccommodation);

            Close();
        }


        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
    
}

