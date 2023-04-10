using FiveStarTours.Model;
using FiveStarTours.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace FiveStarTours.View.Visitor
{
    /// <summary>
    /// Interaction logic for ReservedToursView.xaml
    /// </summary>
    public partial class ReservedToursView : Window
    {
        public User LoggedInUser { get; set; }
        public static ObservableCollection<Tour> Tours { get; set; }
        public Tour SelectedTour { get; set; }

        private readonly ToursRepository _repository;
        public Tour tour { get; set; }
        public ReservedToursView(Tour selectedTour, User user)
        {
            LoggedInUser = user;
            InitializeComponent();
            DataContext = this;
            _repository = new ToursRepository();
            tour = new Tour();
            tour = _repository.GetById(selectedTour.Id);
            SelectedTour = selectedTour;
            //Tours = new ObservableCollection<Tour>(_repository.GetById(selectedTour.Id));
        }

        private void RateButton_Click(object sender, RoutedEventArgs e)
        {
            
                TourRatingView tourRatingView = new TourRatingView(LoggedInUser);
                tourRatingView.Show();

            
        }
    }
}
