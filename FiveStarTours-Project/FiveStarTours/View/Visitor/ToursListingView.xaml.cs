using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Xml.Linq;
using FiveStarTours.Interfaces;
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

    public partial class ToursListingView : Window, INotifyPropertyChanged
    {
        public User LoggedInUser { get; set; }
        public static ObservableCollection<Tour> Tours { get; set; }
        public Tour SelectedTour{ get; set; }
        private readonly ToursService _repository;
        private readonly LanguagesService _languagesService;
        public bool notificationReceived = false;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        List<Language> Languages = new List<Language>();
       

        public ToursListingView(User user)
        {
            LoggedInUser = user;
            InitializeComponent();
            DataContext = this;
            _repository = new ToursService();
            Tours = new ObservableCollection<Tour>(_repository.GetAll());

            /*Languages = _languagesService.GetAll();
            LanguageComboBox.ItemsSource = Languages;
            LanguageComboBox.SelectedValuePath = ".";
            LanguageComboBox.DisplayMemberPath = "."; */

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

        private string selectedLanguage;
        private void LanguageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LanguageComboBox.SelectedItem != null)
            {
                selectedLanguage = LanguageComboBox.SelectedItem as string;
            }
        }

        private void BackgroundComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void NotificationsButtonClick(object sender, RoutedEventArgs e)
        {
            notificationReceived = Notification.SentNotification;

            // Check if there are any notifications
            if (!notificationReceived || Notification.User.Id != LoggedInUser.Id)
            {
                MessageBox.Show("There are no notifications.", "No Notifications", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                NotificationsView notificationWindow = new NotificationsView(LoggedInUser);
                notificationWindow.ShowDialog();

                if (notificationWindow.UserResponse == "yes")
                {
                    Notification.Answer = true;

                }
                else if (notificationWindow.UserResponse == "no")
                {
                    Notification.Answer = false;
                }

                Notification.SentNotification = false;
            }
        }
    }
}
