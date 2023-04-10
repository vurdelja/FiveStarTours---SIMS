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
using FiveStarTours.Model;
using FiveStarTours.Repository;

namespace FiveStarTours.View.Guide
{
    /// <summary>
    /// Interaction logic for Statistics.xaml
    /// </summary>
    public partial class Statistics : Window, INotifyPropertyChanged
    {
        private readonly LiveTourRepository _liveTourRepository;
        private readonly AttendanceRepository _attendanceRepository;
        private readonly UserRepository _userRepository;
        private readonly TourReservationRepository _tourReservationRepository;
        private readonly ToursRepository _toursRepository;

        public event PropertyChangedEventHandler? PropertyChanged;
        public List<int> Years { get; } = Enumerable.Range(2000, DateTime.Now.Year - 2000 + 1).ToList();
        public Statistics()
        {
            InitializeComponent();
            _liveTourRepository = new LiveTourRepository();
            _attendanceRepository = new AttendanceRepository();
            _userRepository = new UserRepository();
            _tourReservationRepository = new TourReservationRepository();
            _toursRepository = new ToursRepository();
            DataContext = this;

            MostVisited.Text = GetMostVisitedAllTime();

            List<string> endedTours = _liveTourRepository.GetEndedTours();
            EndedTours.ItemsSource = endedTours;
            EndedTours.SelectedValuePath = ".";
            EndedTours.DisplayMemberPath = ".";
        }

        private string selectedTour;
        public string selectedDate;

        private void EndedToursComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EndedTours.SelectedItem != null)
            {

                string selectedTourComboBox = EndedTours.SelectedItem.ToString();
                List<string> dates = _liveTourRepository.GetDates(selectedTourComboBox);
                DateOfTour.ItemsSource = dates;
                selectedTour = EndedTours.SelectedItem as string;
            }
        }

        private void DateOfTour_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DateOfTour.SelectedItem != null)
            {
                selectedDate = Convert.ToString(DateOfTour.SelectedItem);
            }
        }
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            LowerThan18.Text = GetLower();
            Between18and50.Text = GetBetween();
            GreaterThan50.Text = GetAbove();
            WithGitfCards.Text = GetWithGiftCard() + "%";
            WithoutGitfCards.Text = GetWithoutGiftCard() + "%";
        }
        public string GetLower()
        {
            LiveTour tour = _liveTourRepository.GetByNameAndDate(selectedTour, Convert.ToDateTime(selectedDate));
            int numberLower = _attendanceRepository.GetAllLower(tour.Id, _userRepository);
            string Lower = Convert.ToString(numberLower / _attendanceRepository.GetAllById(tour.Id, _userRepository) * 100) + "%";
            return Lower;
        }

        public string GetBetween()
        {
            LiveTour tour = _liveTourRepository.GetByNameAndDate(selectedTour, Convert.ToDateTime(selectedDate));
            int numberLower = _attendanceRepository.GetAllBetween(tour.Id, _userRepository);
            string Between = Convert.ToString(numberLower / _attendanceRepository.GetAllById(tour.Id, _userRepository) * 100) + "%";
            return Between;
        }
        public string GetAbove()
        {
            LiveTour tour = _liveTourRepository.GetByNameAndDate(selectedTour, Convert.ToDateTime(selectedDate));
            int numberLower = _attendanceRepository.GetAllAbove(tour.Id, _userRepository);
            string Above = Convert.ToString(numberLower / _attendanceRepository.GetAllById(tour.Id, _userRepository) * 100) + "%";
            return Above;
        }

        public string GetWithGiftCard()
        {
            LiveTour tour = _liveTourRepository.GetByNameAndDate(selectedTour, Convert.ToDateTime(selectedDate));
            int number = _tourReservationRepository.GetWithGiftCard(tour.Id, _attendanceRepository, _userRepository);
            string WithGiftCard = Convert.ToString(number / _attendanceRepository.GetAllById(tour.Id, _userRepository) * 100) ;
            return WithGiftCard;
        }

        public string GetWithoutGiftCard()
        {
            int number = 100 - Convert.ToInt32(GetWithGiftCard());
            return Convert.ToString(number);
        }

        public string GetMostVisitedAllTime()
        {
            int id;
            string result;
            id = _attendanceRepository.GetMostVisitedTour();
            if(id == 0)
            {
                return "There's no visited tours.";
            }
            else
            {
                result = _toursRepository.GetById(id).Name;
                return result;
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
