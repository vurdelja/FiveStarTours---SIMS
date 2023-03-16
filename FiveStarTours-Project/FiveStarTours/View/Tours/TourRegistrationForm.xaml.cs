using System;
using System.Collections.Generic;
using System.Linq;
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

namespace FiveStarTours.View
{
    /// <summary>
    /// Interaction logic for TourRegistrationForm.xaml
    /// </summary>
    public partial class TourRegistrationForm : Window, INotifyPropertyChanged
    {
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

        private string _city;

        public string City
        {
            get => _city;
            set
            {
                if (value != _city)
                {
                    _city = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _state;

        public string State
        {
            get => _state;
            set
            {
                if (value != _state)
                {
                    _state = value;
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

        public TourRegistrationForm()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
