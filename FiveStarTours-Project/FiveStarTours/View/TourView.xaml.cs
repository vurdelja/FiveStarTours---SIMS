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

namespace FiveStarTours.View
{
    /// <summary>
    /// Interaction logic for TourView.xaml
    /// </summary>
    /// 
    public partial class TourView : Window
    {
        //public static ObservableCollection<Tour> Tours { get; set; }
        public Tour SelectedTour { get; set; }
        private readonly ToursRepository _repository;
        public Tour tour { get; set; }

        public TourView(Tour selectedTour)
        {
            InitializeComponent();
            DataContext = this;
            _repository = new ToursRepository();
            tour = new Tour();
            tour = _repository.GetById(selectedTour.Id);
            //Tours = new ObservableCollection<Tour>(_repository.GetById(selectedTour.Id));
        }

        private void ReservationButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
