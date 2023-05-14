﻿using FiveStarTours.Model;
using FiveStarTours.View.Owner;
using System.Windows;


namespace FiveStarTours.View
{
    /// <summary>
    /// Interaction logic for ActionBarView.xaml
    /// </summary>
    public partial class ActionBarView : Window
    {
        
        public User LoggedInUser { get; set; }

        public ActionBarView(User user)
        {
            InitializeComponent();
            DataContext = this;

            LoggedInUser= user;

        }

        private void AddAccommodationButton_Click(object sender, RoutedEventArgs e)
        {
            AddAccommodationView addAccommodation = new AddAccommodationView(LoggedInUser);
            addAccommodation.Show();
            Close();
        }

        private void GuestReviewsButton_Click(object sender, RoutedEventArgs e)
        {
            GuestReviewsView guestReviews = new GuestReviewsView(LoggedInUser);
            guestReviews.Show();
            Close();
        }

        private void GuestRatingButton_Click(object sender, RoutedEventArgs e)
        {
            GuestsWithoutRateView guestRating = new GuestsWithoutRateView(LoggedInUser);
            guestRating.Show();
            Close();
        }

        private void SuperOwnerButton_Click(object sender, RoutedEventArgs e)
        {
            SuperOwnerView superOwner = new SuperOwnerView(LoggedInUser);
            superOwner.Show();
            Close();
        }

        private void RequestsButton_Click(object sender, RoutedEventArgs e)
        {
            ManageRequestsView manageRequestsView = new ManageRequestsView(LoggedInUser);
            manageRequestsView.Show();
            Close();
        }

        

        private void StatisticsButton_Click(object sender, RoutedEventArgs e)
        {
            StatisticsView statisticsView = new StatisticsView(LoggedInUser);
            statisticsView.Show();
            Close();
        }

        private void RenovationsButton_Click(object sender, RoutedEventArgs e)
        {
            RenovationAccommodationsView accommodations = new RenovationAccommodationsView(LoggedInUser);
            accommodations.Show();
            Close();
        }

        private void ForumButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SuggestionsButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            OwnerMainPageView main = new OwnerMainPageView(LoggedInUser);
            main.Show();
            Close();
        }


    }
}
