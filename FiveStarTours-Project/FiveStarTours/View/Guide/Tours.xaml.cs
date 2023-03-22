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
        private readonly ToursRepository _repository;
        public Tour SelectedTour { get; set; }
        public ObservableCollection<Tour> ToursCollection { get; set; }
        public Tours()
        {
            InitializeComponent();
            _repository = new ToursRepository();
            DataContext = this;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            TourRegistrationForm tourRegistration = new TourRegistrationForm();
            tourRegistration.Show();
        }

        private void ToursDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            ToursCollection = new ObservableCollection<Tour>(_repository.GetAllByDate((DateTime)ToursDate.SelectedDate));
            DataGridTours.ItemsSource = ToursCollection;
        }

        private void StartTourButton_CLick(object sender, RoutedEventArgs e)
        {
            if (SelectedTour == null)
            {
                MessageBox.Show("Choose tour first!");
            }
            else
            {
                LiveTourTracking liveTourTracking = new LiveTourTracking(SelectedTour);
            }
        }
    }
}
