using FiveStarTours.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FiveStarTours.Model;

namespace FiveStarTours.View
{
    /// <summary>
    /// Interaction logic for ReservationView.xaml
    /// </summary>
    public partial class ReservationView : Window//, INotifyPropertyChanged
    {
        private readonly VisitorRepository _visitorRepository;
        private readonly KeyPointsRepository _keyPointsRepository;


        private string _visitorName;
        public string VisitorName
        {
            get => _visitorName;
            set
            {
                if(value != _visitorName)
                {
                    _visitorName = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                if(value != _phoneNumber)
                {
                    _phoneNumber = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _membersNumber;
        public string MembersNumber
        {
            get => _membersNumber;
            set
            {
                if( value != _membersNumber)
                {
                    _membersNumber = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                if(_email != value)
                {
                    _email = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ReservationView(Tour selectedTour)
        {
            InitializeComponent();
            DataContext = this;

            _visitorRepository = new VisitorRepository();
            _keyPointsRepository = new KeyPointsRepository();

            List<string> KeyPoints = _keyPointsRepository.GetAllNames();
            StartingKeyPoint.ItemsSource = KeyPoints;
            StartingKeyPoint.SelectedValuePath = ".";
            StartingKeyPoint.DisplayMemberPath = ".";

        }

        private void ReservationButton_Click(object sender, RoutedEventArgs e)
        {
            KeyPoints startingKeyPoint = new KeyPoints();
            startingKeyPoint.Name = selectedKeyPoint;
            foreach(var keyPoint in _keyPointsRepository.GetAll())
            {
                if(startingKeyPoint.Name == keyPoint.Name)
                {
                    startingKeyPoint.Id = keyPoint.Id;
                }
            }
            Visitor visitor = new Visitor(VisitorName, PhoneNumber, startingKeyPoint.Id, startingKeyPoint, Convert.ToInt32(MembersNumber), Email);
            _visitorRepository.Save(visitor);
            Close();

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private string selectedKeyPoint;
        private void StartingKeyPoint_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(StartingKeyPoint.SelectedItem != null)
            {
                selectedKeyPoint = StartingKeyPoint.SelectedItem as string;

            }
        }
    }
}
