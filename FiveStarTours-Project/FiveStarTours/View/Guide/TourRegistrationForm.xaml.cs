// Modeled on CommentForm from InitialProject

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using FiveStarTours.Model;
using FiveStarTours.Repository;

namespace FiveStarTours.View
{
    /// <summary>
    /// Interaction logic for TourRegistrationForm.xaml
    /// </summary>
    public partial class TourRegistrationForm : Window, INotifyPropertyChanged
    {
        public User LoggedInUser { get; set; }

        private readonly ToursRepository _toursRepository;
        private readonly LanguagesRepository _languagesRepository;
        private readonly LocationsRepository _locationsRepository;
        private readonly KeyPointsRepository _keyPointsRepository;

        private string _tourName;
        public string TourName
        {
            get => _tourName;
            set
            {
                if (value != _tourName)
                {
                    _tourName = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _description;
        public string Description
        {
            get => _description;
            set
            {
                if (value != _description)
                {
                    _description = value;
                    OnPropertyChanged();
                }
            }
        }

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

        private string _maxGuests;
        public string MaxGuests
        {

            get => _maxGuests;
            set
            {
                if (value != _maxGuests)
                {
                    _maxGuests = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _keyPoints;
        public string KeyPoints
        {

            get => _keyPoints;
            set
            {
                if (value != _keyPoints)
                {
                    _keyPoints = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _duration;
        public string Duration
        {

            get => _duration;
            set
            {
                if (value != _duration)
                {
                    _duration = value;
                    OnPropertyChanged();
                }
            }
        }


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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public TourRegistrationForm(User user)
        {
            InitializeComponent();
            DataContext = this;

            _toursRepository = new ToursRepository();
            _languagesRepository = new LanguagesRepository();
            _locationsRepository = new LocationsRepository();
            _keyPointsRepository = new KeyPointsRepository();

            LoggedInUser = user;

            // Adding state and city trough combobox:

            List<string> States = _locationsRepository.GetAllStates();
            stateComboBox.ItemsSource = States;
            stateComboBox.SelectedValuePath = ".";
            stateComboBox.DisplayMemberPath = ".";

        }

        // Adding state and city trough combobox:

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

        public bool CheckLocation()
        {
            if(selectedCity == null)
            {
                MessageBox.Show("You must select state and city.");
                return false;
            }

            return true;
        }


        // Adding dates and times into list

        List<DateTime> DateTimes = new List<DateTime>();
        private DateTime lastSelectedDate;

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            lastSelectedDate = (DateTime)datePicker.SelectedDate;

        }

        private void AddDateTime_Click(object sender, RoutedEventArgs e)
        {
            datesTextBox.Clear();
            if (datePicker.SelectedDate == null)
            {
                MessageBox.Show("Please select date first!");
                return;
            }
            DateTime date = (DateTime)datePicker.SelectedDate;
            TimeSpan time = TimeSpan.Parse(textBoxTime.Text);
            DateTime newDate = new DateTime(date.Year, date.Month, date.Day, time.Hours, time.Minutes, time.Seconds);
            DateTimes.Add(newDate);
            foreach (DateTime dateTime in DateTimes)
            {
                datesTextBox.AppendText(dateTime.ToString() + "\n");
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (TourName == null)
            {
                MessageBox.Show("You must enter name of tour.");
                return;
            }

            Location location = new Location();
            if (CheckLocation())
            {
                location = GetSelectedLocation();
            }
            else return;

            if (Description == null)
            {
                MessageBox.Show("You must enter description of tour.");
                return;
            }

            List<Language> LanguageList = new List<Language>();
            if (CheckLanguages(Languages))
            {
                LanguageList = MakeLanguagesList(Languages);
            }
            else return;

            List<int> LanguageIds = GetLanguagesIds(LanguageList);

            int MaximumGuests;
            if (MaxGuests == null)
            {
                MessageBox.Show("You must enter maximum guests number.");
                return;
            } else
            {
                MaximumGuests = int.Parse(MaxGuests);
                if(MaximumGuests < 1)
                {
                    MessageBox.Show("Maximum number of guests must be greater then 0.");
                    return;
                }
            }

            List<KeyPoints> KeyPointsList = new List<KeyPoints>();
           
            if (KeyPointsCheck(KeyPoints))
            {
                KeyPointsList = MakeKeyPointsList(KeyPoints);
            }
            else return;
            List<int> KeyPointsIds = GetKeyPointsIds(KeyPointsList);

            if(DateTimes.Count < 1)
            {
                MessageBox.Show("At least 1 date and time is required.");
            }

            int DurationTime;
            if (Duration == null)
            {
                MessageBox.Show("You must enter duration time.");
                return;
            }
            else
            {
                DurationTime = int.Parse(Duration);
                if (DurationTime < 1)
                {
                    MessageBox.Show("Duration time must be greater then 0.");
                    return;
                }
            }

            List<string> ImageUrlsList = new List<string>();
            if (CheckUrls(ImageUrls))
            {
                ImageUrlsList = MakeUrlsList(ImageUrls);
            }
            else return;

            Tour newTour = new Tour(TourName, LoggedInUser, location.Id, location, Description, LanguageIds, LanguageList, MaximumGuests, KeyPointsIds, KeyPointsList, DateTimes, DurationTime, ImageUrlsList);
            _toursRepository.Save(newTour);

            Close();
        }

        // Convert from string to list of Language objects
        public List<Language> MakeLanguagesList(string language)
        {
            List<Language> result = new List<Language>();

            Array _languages = language.Split(", ");

            foreach (string l in _languages)
            {
                Language lang = new Language(l);
                _languagesRepository.Save(lang);
                result.Add(lang);
            }

            return result;
        }

        public List<int> GetLanguagesIds(List<Language> languages)
        {
            List<int> result = new List<int>();

            foreach (Language lang in languages)
            {
                result.Add(lang.Id);
            }

            return result;
        }

        public bool CheckLanguages(string languages)
        {
            if(languages == null)
            {
                MessageBox.Show("At least 1 language is required.");
                return false;
            }

            return true;
        }

        // Convert from string to list of KeyPoints objects
        public List<KeyPoints> MakeKeyPointsList(string keyPoints)
        {
            List<KeyPoints> result = new List<KeyPoints>();

            Array _keyPoints = keyPoints.Split(", ");

            foreach (string keyPoint in _keyPoints)
            {

                KeyPoints kp = new KeyPoints(keyPoint);
                _keyPointsRepository.Save(kp);
                result.Add(kp);

            }

            return result;
        }

        public bool KeyPointsCheck(string keyPoints)
        {

            Array _keyPoints = keyPoints.Split(", ");
            if(_keyPoints.Length < 2)
            {
                MessageBox.Show("At least 2 key points are required.");
                return false;
            }

            return true;
        }

        public List<int> GetKeyPointsIds(List<KeyPoints> keyPoints)
        {
            List<int> result = new List<int>();

            foreach (KeyPoints keyPoint in keyPoints)
            {
                result.Add(keyPoint.Id);
            }

            return result;
        }

        // Convert from string to list of strings

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

        public bool CheckUrls(string urls)
        {
            if (urls == null)
            {
                MessageBox.Show("At least 1 URL is required.");
                return false;
            }

            return true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


    }
}
