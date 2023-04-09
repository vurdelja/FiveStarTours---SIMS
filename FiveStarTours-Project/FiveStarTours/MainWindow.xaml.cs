using FiveStarTours.Model;
using FiveStarTours.Repository;
using FiveStarTours.View;
using FiveStarTours.View.Traveler;
using FiveStarTours.View.Visitor;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace FiveStarTours
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly UserRepository _repository;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            _repository = new UserRepository();
        }

        private void Signin(object sender, RoutedEventArgs e)
        {
            User user = _repository.GetByUsername(Username);
            if (user != null)
            {
                if (user.Password == txtPassword.Password)
                {
                   
                    FindbyRole(user);
                   
                }
                else
                {
                    MessageBox.Show("Wrong password!");
                }
            }
            else
            {
                MessageBox.Show("Wrong username!");
            }
        }


        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                if (value != _username)
                {
                    _username = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void FindbyRole(User user)
        {
            if (String.Equals(user.Role.ToLower(), "owner"))
            {
                OwnerMainWindow ownerMainWindow = new OwnerMainWindow();
                ownerMainWindow.Show();
            }
            else if (String.Equals(user.Role.ToLower(), "traveler"))
            {
                TravelerViewandSearch travelerViewandSearch = new TravelerViewandSearch();
                travelerViewandSearch.Show();
            }
            else if (String.Equals(user.Role.ToLower(), "guide"))
            {
                Tours tours = new Tours(user);
                tours.Show();
            }
            else if (String.Equals(user.Role.ToLower(), "visitor"))
            {
                VisitorMainWindow visitorMainWindow = new VisitorMainWindow(user);
                visitorMainWindow.Show();
            }
            else 
            {
                DriverMainWindow driverMainWindow = new DriverMainWindow();
                driverMainWindow.Show();
            }



        }
    }
}

