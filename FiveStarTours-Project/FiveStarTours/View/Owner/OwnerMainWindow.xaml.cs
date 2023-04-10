﻿using FiveStarTours.Model;
using FiveStarTours.Repository;
using FiveStarTours.View.Owner;
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
    /// Interaction logic for OwnerMainWindow.xaml
    /// </summary>
    public partial class OwnerMainWindow : Window
    {
        private readonly AccommodationReservationsRepository _repository;
        public User LoggedInUser { get; set; }

        public OwnerMainWindow(User user)
        {
            InitializeComponent();
            DataContext = this;

            _repository = AccommodationReservationsRepository.GetInstace();

            LoggedInUser= user;

            _repository.NotifyAboutUnratedGuests();

        }

        private void AddAccommodationButton_Click(object sender, RoutedEventArgs e)
        {
            AddAccommodationView addAccommodation = new AddAccommodationView();
            addAccommodation.Show();
        }

        private void GuestReviewsButton_Click(object sender, RoutedEventArgs e)
        {
            GuestReviewsView guestReviews = new GuestReviewsView();
            guestReviews.Show();
        }

        private void GuestRatingButton_Click(object sender, RoutedEventArgs e)
        {
            GuestsWithoutRateView guestRating = new GuestsWithoutRateView();
            guestRating.Show();
        }

        private void SuperOwnerButton_Click(object sender, RoutedEventArgs e)
        {
            SuperOwnerView superOwner = new SuperOwnerView(LoggedInUser);
            superOwner.Show();
        }







    }
}
