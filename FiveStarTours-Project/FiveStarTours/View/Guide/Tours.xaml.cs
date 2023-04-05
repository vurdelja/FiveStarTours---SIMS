using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using FiveStarTours.Model;
using FiveStarTours.Repository;
using FiveStarTours.View.Guide;

namespace FiveStarTours.View
{
    /// <summary>
    /// Interaction logic for Tours.xaml
    /// </summary>
    public partial class Tours : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private readonly ToursRepository _toursRepository;
        public Tour SelectedTour { get; set; }
        public User LoggedInUser { get; set; }
        public ObservableCollection<Tour> ToursCollection { get; set; }
        public Tours(User user)
        {
            InitializeComponent();
            _toursRepository = new ToursRepository();
            DataContext = this;
            LoggedInUser = user;
            ToursCollection = new ObservableCollection<Tour>(_toursRepository.GetByUser(user));
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            TourRegistrationForm tourRegistration = new TourRegistrationForm(LoggedInUser);
            tourRegistration.Show();
        }

        private void ToursDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            ToursCollection = new ObservableCollection<Tour>(_toursRepository.GetAllByDate((DateTime)ToursDate.SelectedDate, LoggedInUser));
            DataGridTours.ItemsSource = ToursCollection;
        }

        private void StartTourButton_CLick(object sender, RoutedEventArgs e)
        {
            if (SelectedTour == null)
            {
                MessageBox.Show("Choose tour first!");
            }
            else if (SelectedTour.OneBeginningTime.Date != DateTime.Now.Date)
            {
                MessageBox.Show("This tour can not be started because it is not today.");
            }
            else
            {
                foreach(Tour t in _toursRepository.GetAll())
                {
                    if(SelectedTour.Name == t.Name)
                    {
                        SelectedTour.Id = t.Id;
                    }
                }

                LiveTourTracking liveTourTracking = new LiveTourTracking(SelectedTour);
            }
        }

        private void CancelTour_Click(object sender, RoutedEventArgs e)
        {
            DateTime fixedDateTime = SelectedTour.OneBeginningTime;
            TimeSpan timeDifference = fixedDateTime - DateTime.Now;
            if (SelectedTour == null)
            {
                MessageBox.Show("Choose tour first!");
            }
            else if (timeDifference.TotalHours < 48)
            {
                MessageBox.Show("It is less than 48 hours from this tour.");
            }
            else
            {
                _toursRepository.Delete(SelectedTour);
            }
        }
    }
}
