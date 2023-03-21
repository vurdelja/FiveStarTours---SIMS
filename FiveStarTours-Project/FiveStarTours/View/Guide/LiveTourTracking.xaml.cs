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

        public event PropertyChangedEventHandler? PropertyChanged;
        public ObservableCollection<string> Checkpoints { get; set; }
        public ObservableCollection<bool> IsChecked { get; set; }

        Tour tour { get; set; }
        LiveTour liveTour { get; set; }
        public LiveTourTracking(Tour selectedTour)
        {
            _liveTourRepository = new LiveTourRepository();
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

        public bool StartLiveTour(Tour tour)
        {
            tour.KeyPoints = tour.getKeyPointsById(tour.IdKeyPoints);
            tour.KeyPoints.ElementAt(0).Visited = true;
            liveTour = new LiveTour(tour.Id, tour.Name, tour.OneBeginningTime, tour.IdKeyPoints, tour.KeyPoints, true, false);
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
