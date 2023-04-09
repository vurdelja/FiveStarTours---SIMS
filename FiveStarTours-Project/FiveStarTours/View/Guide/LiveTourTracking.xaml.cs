using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;
using FiveStarTours.Model;
using FiveStarTours.Repository;
using FiveStarTours.View.Visitor;

namespace FiveStarTours.View.Guide
{
    /// <summary>
    /// Interaction logic for LiveTourTracking.xaml
    /// </summary>
    public partial class LiveTourTracking : Window, INotifyPropertyChanged
    {
        private readonly LiveTourRepository _liveTourRepository;
        private readonly AttendanceRepository _attendanceRepository;
        private readonly TourReservationRepository _tourReservationRepository;
        private readonly UserRepository _userRepository;

        public event PropertyChangedEventHandler? PropertyChanged;
        public ObservableCollection<string> Checkpoints { get; set; }
        public ObservableCollection<bool> IsChecked { get; set; }

        public List<string> Visitor { get ; set; } 
        LiveTour liveTour { get; set; }
        public LiveTourTracking(Tour selectedTour)
        {
            _liveTourRepository = new LiveTourRepository();
            _attendanceRepository = new AttendanceRepository();
            _tourReservationRepository = new TourReservationRepository();
            _userRepository = new UserRepository();
            if (StartLiveTour(selectedTour))
            {
                InitializeComponent();
                DataContext = liveTour;
                Show();
            } 
        }
        public bool CheckVisitors(TourReservationRepository visitorRepository, Tour tour)
        {
            List<TourReservation> visitors = new List<TourReservation>();
            foreach (var v in _tourReservationRepository.GetAll())
            {
                if (tour.Id == v.Id && tour.OneBeginningTime == v.DateTime)
                {
                    visitors.Add(v);
                }
            }
            if( visitors.Count < 1)
            {
                return false;
            }

            return true;
        }

        public bool StartLiveTour(Tour tour)
        {
            tour.KeyPoints = tour.getKeyPointsById(tour.IdKeyPoints);
            tour.KeyPoints.ElementAt(0).Visited = true;
            if(CheckVisitors(_tourReservationRepository, tour))
            {
                Visitor = _tourReservationRepository.GetAllVisitors(tour);
            }
            else
            {
                MessageBox.Show("No visitors on this tour!");
                return false;
            }
            liveTour = new LiveTour(tour.Id, tour.Name, tour.OneBeginningTime, tour.IdKeyPoints, tour.KeyPoints, true, false);
            foreach (var livetour in _liveTourRepository.GetAll())
            {
                if (livetour.Ended && livetour.Date == tour.OneBeginningTime && string.Equals(tour.Name, livetour.Name, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("This tour is already over");
                    return false;
                }
                else if (livetour.Started == true && livetour.Ended == false)
                {
                    MessageBox.Show("One tour is already started.");
                    return false;
                }
            }

            tour.KeyPoints = tour.getKeyPointsById(tour.IdKeyPoints);
            tour.KeyPoints.ElementAt(0).Visited = true;
            liveTour = new LiveTour(tour.Id, tour.Name, tour.OneBeginningTime, tour.IdKeyPoints, tour.KeyPoints, true, false);
            liveTour.Visitors = Visitor;
            _liveTourRepository.Save(liveTour);
            
            return true;
        }

        public void EndTour_Click(object sender, RoutedEventArgs e)
        {
            liveTour.Ended = true;
            _liveTourRepository.FindIdAndSave(liveTour, liveTour.Id);
            Close();
        }
        private void CheckPoint_Checked(object sender, RoutedEventArgs e)
        {
            bool allChecked = true;
            foreach (KeyPoints item in liveTour.KeyPoints)
            {
                if (!item.Visited)
                {
                    allChecked = false;
                    break;
                }
            }

            if (allChecked)
            {
                EndTour_Click(sender, e);
                this.Close();
            }
        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            ((CheckBox)sender).SetBinding(ToggleButton.IsCheckedProperty, new Binding("IsCheckedProperty"));
        }

        // Generated with ChatGPT
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T t)
                    {
                        yield return t;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        public void Visitor_Checked(object sender, RoutedEventArgs e)
        {
            string item = (string)((CheckBox)sender).Content;

            // Poslati notifikaciju i cekati odgovor
            //MessageBoxResult result = MessageBox.Show($"Do you want to send request for attendance for {item}?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            User User = new User();
            foreach(User user in _userRepository.GetAll())
            {
                if(user.Name == item)
                {
                    User = user;
                }
            }
            Notification.User = User;
            Notification.SentNotification = true;
            if (Notification.Answer)
            {
                MessageBox.Show($"The visitor {item} has confirmed his/hers presence.");
                int idVisitor = _userRepository.FindIdByName(item);
                int idKeyPoint = FindLastVisited(liveTour);
                Attendance attendance = new Attendance(liveTour.IdTour, idVisitor, idKeyPoint);
                _attendanceRepository.Save(attendance);
                Notification.Answer = false;
            }
            else
            {
                MessageBox.Show($"The visitor {item} has not confirmed his/hers presence.");
                ((CheckBox)sender).IsChecked = false;
            }
        }
        public int FindLastVisited(LiveTour liveTour)
        {
            var keyPoints = liveTour.KeyPoints;
            foreach (var keyPoint in keyPoints)
            {
                if (keyPoint.Visited == false)
                {
                    return keyPoint.Id - 1;
                }
            }

            return 0;
        }

    }
}
