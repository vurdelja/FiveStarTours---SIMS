using FiveStarTours.Model;
using FiveStarTours.Services;
using FiveStarTours.Services;
using FiveStarTours.View.Owner;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FiveStarTours.View.Owner.Renovation
{
    /// <summary>
    /// Interaction logic for RenovationAccommodations.xaml
    /// </summary>
    public partial class AccommodationsView : Window
    {
        public User LoggedInUser;
        public ObservableCollection<Accommodation> Accommodations { get; set; }
        public Accommodation SelectedAccommodation { get; set; }

        private readonly AccommodationsService accommodationService;
        public AccommodationsView(User user)
        {
            InitializeComponent();
            DataContext = this;

            accommodationService = new AccommodationsService();
            Accommodations = new ObservableCollection<Accommodation>(accommodationService.GetAll());

            LoggedInUser = user;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            SchedulingView scheduling = new SchedulingView(LoggedInUser, SelectedAccommodation);
            scheduling.Show();
            Close();
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            ActionBarView action = new ActionBarView(LoggedInUser);
            action.Show();
            Close();
        }
    }
}
