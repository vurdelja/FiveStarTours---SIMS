﻿using FiveStarTours.Model;
using FiveStarTours.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace FiveStarTours.View.Owner
{
    /// <summary>
    /// Interaction logic for FullGuestReviewView.xaml
    /// </summary>
    public partial class FullGuestReviewView : Window
    {
        public AccommodationReservation _selectedReservation { get; set; }


        private readonly AccommodationRatingRepository _rateRepository;

        public AccommodationRating accommodationRating { get; set; }


        public FullGuestReviewView(AccommodationReservation selectedReservation)
        {
            InitializeComponent();
            DataContext = this;

            _selectedReservation = selectedReservation;

            _rateRepository = AccommodationRatingRepository.GetInstace();

            accommodationRating = new AccommodationRating();
            accommodationRating = _rateRepository.GetById(selectedReservation.Id);

        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
