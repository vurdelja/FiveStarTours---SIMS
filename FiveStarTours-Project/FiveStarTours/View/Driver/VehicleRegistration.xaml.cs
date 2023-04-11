using FiveStarTours.Model;
using FiveStarTours.Repository;
using FiveStarTours.View;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;


namespace FiveStarTours.View.VehicleRegistration
{
    /// <summary>
    /// Interaction logic for VehicleRegistration.xaml
    /// </summary>
    public partial class VehicleRegistration : Window, INotifyPropertyChanged
    {

        private readonly VehicleRepository _vehicleRegistrationRepository;
        private readonly LanguagesRepository _languagesRepository;
        private readonly LocationsRepository _locationsRepository;

        private string _languages;
        public string Languages
        {
            get => _languages;
            set
            {
                if (value != _languages)
                {
                    _languages = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _maxPersonNum;
        public string MaxPersonNum
        {

            get => _maxPersonNum;
            set
            {
                if (value != _maxPersonNum)
                {
                    _maxPersonNum = value;
                    OnPropertyChanged();
                }
            }
        }

        
        private string selectedState;
        private string selectedCity;

        private string _imageUrls;
        public string ImageUrls
        {
            get => _imageUrls;
            set
            {
                if (value != _imageUrls)
                {
                    _imageUrls = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _selectedImagePath;

        public string SelectedImagePath
        {
            get { return _selectedImagePath; }
            set
            {
                _selectedImagePath = value;
                OnPropertyChanged("SelectedImagePath");
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public VehicleRegistration()
        {
            InitializeComponent();
            DataContext = this;

            _vehicleRegistrationRepository = new VehicleRepository();
            _languagesRepository = new LanguagesRepository();
            _locationsRepository = new LocationsRepository();

            // Adding state and city trough combobox:

            List<string> States = _locationsRepository.GetAllStates();
            stateComboBox.ItemsSource = States;
            stateComboBox.SelectedValuePath = ".";
            stateComboBox.DisplayMemberPath = ".";
        }

        // Adding state and city trough combobox:

        private void StateCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (stateComboBox.SelectedItem != null)
            {

                string selectedStateComboBox = stateComboBox.SelectedItem.ToString();
                List<string> citiesInState = _locationsRepository.GetCitiesInState(selectedStateComboBox);
                cityComboBox.ItemsSource = citiesInState;
                selectedState = stateComboBox.SelectedItem as string;
            }
        }

        private void CityCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cityComboBox.SelectedItem != null)
            {
                selectedCity = cityComboBox.SelectedItem as string;
            }
        }
        
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Location location = GetSelectedLocation();
            List<Language> LanguageList = MakeLanguagesList(Languages);
            List<int> LanguageIds = GetLanguagesIds(LanguageList);
            int MaximumPersonNumber = int.Parse(MaxPersonNum);
            List<string> ImageUrlsList = MakeUrlsList(ImageUrls);

            
            Vehicle newVehicle = new Vehicle( location, LanguageList, LanguageIds, MaximumPersonNumber, ImageUrlsList );
            _vehicleRegistrationRepository.Save(newVehicle);
            MessageBox.Show("Data saved successfully.");
            Close();
        }
        
        

        private List<string> MakeUrlsList(string urls)
        {
            List<string> result = new List<string>();

            Array _urls = urls.Split(",");

            foreach (string url in _urls)
            {
                result.Add(url);
            }

            return result;
        }
        

        private List<int> GetLanguagesIds(List<Language> languages)
        {
            List<int> result = new List<int>();

            foreach (Language lang in languages)
            {
                result.Add(lang.Id);
            }

            return result;
        }

        private List<Language> MakeLanguagesList(string languages)
        {
            List<Language> result = new List<Language>();

            Array _languages = languages.Split(", ");

            foreach (string l in _languages)
            {
                Language lang = new Language();
                _languagesRepository.Save(lang);
                result.Add(lang);
            }

            return result;
        }

        private Location GetSelectedLocation()
        {
            return new Location();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }

}
