using FiveStarTours.Services;
using System;
using FiveStarTours.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using FiveStarTours.View.Traveler;
using FiveStarTours.View.Owner.Renovation;

namespace FiveStarTours.View.Owner
{
    /// <summary>
    /// Interaction logic for SchedulingRenovationsView.xaml
    /// </summary>
    public partial class SchedulingView : Window
    {
        public User LoggedInUser { get; set; }

        private readonly RenovationService renovationService;
        private readonly AccommodationsService accommodationService;
        private readonly AccommodationReservationService accommodationReservationService;
        public static ObservableCollection<Renovations> Renovations { get; set; }
        public event PropertyChangedEventHandler? PropertyChanged;

        public Accommodation SelectedAccommodation { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int ExpectedDuration { get; set; }
        public string Description { get; set; }

        public SchedulingView(User user, Accommodation selected)
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
            FreeDatesView freeDates = new FreeDatesView(LoggedInUser, accommodationReservationService.GetFreeDateIntervals(SelectedAccommodation.AccommodationName, StartDate, EndDate, ExpectedDuration), SelectedAccommodation.AccommodationName, Description, ExpectedDuration);
            freeDates.Show();
            Close();

        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            AccommodationsView accommodations = new AccommodationsView(LoggedInUser);
            accommodations.Show();
            Close();
        }
    }
}
