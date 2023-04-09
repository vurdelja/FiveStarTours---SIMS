using FiveStarTours.Model;
using FiveStarTours.Repository;
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

namespace FiveStarTours.View.Traveler
{
    /// <summary>
    /// Interaction logic for ChangeReservation.xaml
    /// </summary>
    public partial class ChangeReservation : Window, INotifyPropertyChanges
    {
        public Accommodation SelectedAccommodation { get; set; }
        public event PropertyChangedEventHandler? PropertyChanged;
        private readonly AccommodationReservationsRepository accommodationReservationsRepository;
        private readonly AccommodationsRepository accommodationsRepository;
        public string AccommodationName { get; set; }
        public static ObservableCollection<AccommodationReservation> AccommodationReservations { get; set; }
        public ChangeReservation()
        {
            InitializeComponent();
            this.DataContext = this;
            accommodationReservationsRepository = AccommodationReservationsRepository.GetInstace();
            accommodationsRepository = new AccommodationsRepository();
           
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string properyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(properyName));
        }

    }
}

