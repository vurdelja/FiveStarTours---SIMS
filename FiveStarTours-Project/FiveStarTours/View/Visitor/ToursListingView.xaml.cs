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
using System.Xml.Linq;
using FiveStarTours.Model;
using FiveStarTours.Repository;
using FiveStarTours.Services;
using FiveStarTours.View;
using static System.Net.Mime.MediaTypeNames;
using Application = System.Windows.Application;

namespace FiveStarTours.View.Visitor
{
    /// <summary>
    /// Interaction logic for ToursListingView.xaml
    /// </summary>
    /// 

    public partial class ToursListingView : Window
    {
        public User LoggedInUser { get; set; }
        public static ObservableCollection<Tour> Tours { get; set; }
        public Tour SelectedTour{ get; set; }
        private readonly ToursService _repository;



        public ToursListingView(User user)
        {
            LoggedInUser = user;
            InitializeComponent();
            DataContext = this;
            _repository = new ToursService();
            Tours = new ObservableCollection<Tour>(_repository.GetAll());

        }

        private void TourSearchClick(object sender, RoutedEventArgs e)
        {

        }

        private void ShowTourView(object sender, RoutedEventArgs e)
        {
            
            if(SelectedTour != null)
            {
                TourView tourView = new TourView(SelectedTour, LoggedInUser);
                tourView.Show();
                
            }
        }

        private void RateClick(object sender, RoutedEventArgs e)
        {
            TourRatingView rate = new TourRatingView(LoggedInUser);
            rate.Show();
        }

        private void VehicleClick(object sender, RoutedEventArgs e)
        {
            VehicleSearchView vehicle = new VehicleSearchView(LoggedInUser);
            vehicle.Show();
        }

        private void LogOutClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            foreach(Window window in Application.Current.Windows)
            {
                if(window != mainWindow)
                {
                    window.Close();
                }
            }
            mainWindow.Show();
        }
    }
}
