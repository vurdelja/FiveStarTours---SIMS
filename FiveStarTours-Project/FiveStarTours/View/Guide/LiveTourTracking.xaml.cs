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

namespace FiveStarTours.View.Guide
{
    /// <summary>
    /// Interaction logic for LiveTourTracking.xaml
    /// </summary>
    public partial class LiveTourTracking : Window, INotifyPropertyChanged
    {
        private readonly LiveTourRepository _liveTourRepository;
        private readonly TourReservationRepository _visitorRepository;

        public event PropertyChangedEventHandler? PropertyChanged;
        public ObservableCollection<string> Checkpoints { get; set; }
        public ObservableCollection<bool> IsChecked { get; set; }

        Tour tour { get; set; }
        LiveTour liveTour { get; set; }
        public LiveTourTracking(Tour selectedTour)
        {
            selectedTour.Id += 1;
            _liveTourRepository = new LiveTourRepository();
            _visitorRepository = new TourReservationRepository();
            if (StartLiveTour(selectedTour))
            {
                InitializeComponent();
                _liveTourRepository.Save(liveTour);
                DataContext = liveTour;
                Checkpoints = new ObservableCollection<string>();
                IsChecked = new ObservableCollection<bool>();
                Show();
            }
        }

        // Dictionary of visitors for tracking 

        Dictionary<string, bool> Visitor;

        public Dictionary<string, bool> GetAllVisitors(TourReservationRepository visitorRepository, Tour tour)
        {
            Dictionary<string, bool> Visitors = new Dictionary<string, bool>();
            List<TourReservation> visitors = new List<TourReservation>();
            foreach(var v in _visitorRepository.GetAll())
            {
                if(tour.Id == v.TourId && tour.OneBeginningTime == v.DateTime)
                {
                    visitors.Add(v);
                }
            }

            List<string> Names = new List<string>();

            foreach(var visitor in visitors)
            {
               // Names.Add(visitor.VisitorName);
            }

            foreach(var name in Names)
            {
                Visitors.Add(name, false);
            }

            if (Visitors.Count < 1)
            {
                Close();
            }
            return Visitors;
        }

        public bool CheckVisitors(TourReservationRepository visitorRepository, Tour tour)
        {
            List<TourReservation> visitors = new List<TourReservation>();
            foreach (var v in _visitorRepository.GetAll())
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
            if(CheckVisitors(_visitorRepository, tour))
            {
                Visitor = GetAllVisitors(_visitorRepository, tour);
            }
            else
            {
                MessageBox.Show("No visitors on this tour!");
                return false;
            }
            liveTour = new LiveTour(tour.Id, tour.Name, tour.OneBeginningTime, tour.IdKeyPoints, tour.KeyPoints, Visitor, true, false);
            foreach (var livetour in _liveTourRepository.GetAll())
            {
                if (livetour.Ended && livetour.Date.Date == liveTour.Date.Date && string.Equals(livetour.Name, liveTour.Name, StringComparison.OrdinalIgnoreCase))
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

            MessageBoxResult result = MessageBox.Show($"Do you want to check {item}?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                liveTour.Visitors[item] = true;
            }
            else
            {
                ((CheckBox)sender).IsChecked = false;
            }
        }

    }
}
