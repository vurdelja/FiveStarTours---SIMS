using FiveStarTours.Model;
using FiveStarTours.Repository;
using FiveStarTours.View.Traveler;
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

namespace FiveStarTours.View.Owner
{
    /// <summary>
    /// Interaction logic for SuperOwnerView.xaml
    /// </summary>
    public partial class SuperOwnerView : Window
    {

        private readonly AccommodationRatingRepository _rateRepository;
        private readonly UserRepository _userRepository;
        public AccommodationRating accommodationRating { get; set; }

        public User LoggedInUser { get; set; }

        public int NumberOfReviews { get; set; }

        public double AverageRate { get; set; }

        

        public SuperOwnerView(User user)
        {
            InitializeComponent();
            DataContext = this;

            _userRepository = new UserRepository();

            _rateRepository = new AccommodationRatingRepository();

            accommodationRating = new AccommodationRating();

            LoggedInUser = user;

            NumberOfReviews = _rateRepository.CountRatings();
            AverageRate = _rateRepository.AverageOwnerRating();

            if (_rateRepository.CountRatings() > 50 && _rateRepository.AverageOwnerRating() > 4.5)
            {
                LoggedInUser.Super = true;
                _userRepository.Update(LoggedInUser);
                
            }
            else
            {
                LoggedInUser.Super = false;
                _userRepository.Update(LoggedInUser);
            }

            return;


        }


    }
}
