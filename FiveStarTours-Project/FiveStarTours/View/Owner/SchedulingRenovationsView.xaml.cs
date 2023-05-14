using FiveStarTours.Services;
using System;
using FiveStarTours.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using FiveStarTours.View.Traveler;

namespace FiveStarTours.View.Owner
{
    /// <summary>
    /// Interaction logic for SchedulingRenovationsView.xaml
    /// </summary>
    public partial class SchedulingRenovationsView : Window
    {
        public User LoggedInUser { get; set; }

        private readonly RenovationService renovationService;
        private readonly AccommodationsService accommodationService;
        private readonly AccommodationReservationService accommodationReservationService;
        public static ObservableCollection<Renovation> Renovations { get; set; }
        public event PropertyChangedEventHandler? PropertyChanged;

        public Accommodation SelectedAccommodation { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int ExpectedDuration { get; set; }
        public string Description { get; set; }
        public SchedulingRenovationsView(User user, Accommodation selected)
        {
            InitializeComponent();
            DataContext = this;

            accommodationService = new AccommodationsService();
            accommodationReservationService = new AccommodationReservationService();
            SelectedAccommodation = selected;

            StartDate = DateTime.Now;
            EndDate = DateTime.Now;

            LoggedInUser = user;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string properyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(properyName));
        }

    
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            AvailableDates availableDates = new AvailableDates(renovationService.GetFreeDateIntervals(SelectedAccommodation.AccommodationName, StartDate, EndDate, ExpectedDuration), SelectedAccommodation.AccommodationName);
            availableDates.Show();
            Close();
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            RenovationAccommodationsView accommodations = new RenovationAccommodationsView(LoggedInUser);
            accommodations.Show();
            Close();
        }
    }
}
