using FiveStarTours.Model;
using FiveStarTours.Repository;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace FiveStarTours.View.Owner
{
    /// <summary>
    /// Interaction logic for OwnerRatingGuests.xaml
    /// </summary>
    public partial class GuestRatingView : Window
    {
        public AccommodationReservation _selectedReservation { get; set; }

        private readonly AccommodationReservationsRepository _repository;
        public AccommodationReservation accommodationReservation { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string properyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(properyName));
        }


        /*public ObservableCollection<int> _tidinessRate { get; set; }
        public int tidinessRate { get; set; }
        public ObservableCollection<int> _rulesFollowedRate { get; set; }
        public int rulesFollowedRate { get; set; }
        public ObservableCollection<int> _quietnessRate { get; set; }
        public int quietnessRate { get; set; }
        public ObservableCollection<int> _friendlinessRate { get; set; }
        public int friendlinessRate { get; set; }
        public ObservableCollection<int> _communicationRate { get; set; }
        public int communicationRate { get; set; }
        public ObservableCollection<int> _respectTimeRate { get; set; }
        public int respectTimeRate { get; set; }*/

        public GuestRatingView(AccommodationReservation selectedReservation)
        {
            InitializeComponent();
            DataContext = this;

            //accommodationReservation = new AccommodationReservation();
            //accommodationReservation = _repository.GetById(selectedReservation.Id);

            _repository = new AccommodationReservationsRepository();



            accommodationReservation = new AccommodationReservation();
            accommodationReservation = _repository.GetById(selectedReservation.Id);

            /*_tidinessRate = new ObservableCollection<int>();

            for (int i = 1; i < 6; i++)
            {
                _tidinessRate.Add(i);
            }

            _tidinessRate = new ObservableCollection<int>();

            for (int i = 1; i < 6; i++)
            {
                _tidinessRate.Add(i);
            }*/

        }



        private string tidiness;
        public string Tidiness
        {
            get => tidiness;
            set
            {
                tidiness = value;
                OnPropertyChanged();
            }
        }

        private string rulesFollowed;
        public string RulesFollowed
        {
            get
            {
                return rulesFollowed;
            }
            set
            {
                rulesFollowed = value;
                OnPropertyChanged();
            }
        }

        private string quietness;
        public string Quietness
        {
            get
            {
                return rulesFollowed;
            }
            set
            {
                rulesFollowed = value;
                OnPropertyChanged();
            }
        }

        private string friendliness;
        public string Friendliness
        {
            get
            {
                return rulesFollowed;
            }
            set
            {
                rulesFollowed = value;
                OnPropertyChanged();
            }
        }

        private string communication;
        public string Communication
        {
            get
            {
                return communication;
            }
            set
            {
                rulesFollowed = value;
                OnPropertyChanged();
            }
        }

        private string respectTime;
        public string RespectTime
        {
            get
            {
                return rulesFollowed;
            }
            set
            {
                rulesFollowed = value;
                OnPropertyChanged();
            }
        }

        private string comment;
        public string Comment
        {
            get
            {
                return rulesFollowed;
            }
            set
            {
                rulesFollowed = value;
                OnPropertyChanged();
            }
        }

        private void SubmitRateButton_Click(object sender, RoutedEventArgs e)
        {

            int tidiness = int.Parse(Tidiness);
            int rulesFollowed = int.Parse(RulesFollowed);
            int quietness = int.Parse(Quietness);
            int friendliness = int.Parse(Friendliness);
            int communication = int.Parse(Communication);
            int respectTime = int.Parse(RespectTime);

            AccommodationReservation reservation = _selectedReservation;



            GuestRating newGuestRate = new GuestRating(
                    reservation,
                    tidiness,
                    rulesFollowed,
                    quietness,
                    friendliness,
                    communication,
                    respectTime,
                    Comment
                );

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


    }
}
