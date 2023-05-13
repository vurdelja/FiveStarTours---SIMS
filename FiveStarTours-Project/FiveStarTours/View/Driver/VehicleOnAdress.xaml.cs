﻿using FiveStarTours.Model;
using System;
using System.Collections.Generic;
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
using FiveStarTours.Repository;
using FiveStarTours.View;
using Microsoft.Win32;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using FiveStarTours.View.VehicleOnAdress;
using System.IO;
using System.Windows.Threading;
using FiveStarTours.Serializer;
using FiveStarTours.View.Driver;
using Microsoft.VisualBasic.FileIO;
using FiveStarTours.View.Visitor;


namespace FiveStarTours.View.VehicleOnAdress
{
    /// <summary>
    /// Interaction logic for VehicleOnAdress.xaml
    /// </summary>
    public partial class VehicleOnAdress : Window, INotifyPropertyChanged
    {

        private readonly VehicleOnAdressRepository _vehicleOnAddressRepository;
        private readonly DrivingsRepository _drivingsRepository;
        

        public static List<Drivings> Drivings { get; set; }
        public User LoggedInUser { get; set; }
        public bool notificationReceived = false;

       

        private string _name;
        public string Name
        {

            get => _name;
            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _acceptingDrive;
        public bool AcceptingDrive
        {

            get => _acceptingDrive;
            set
            {
                if (value != _acceptingDrive)
                {
                    _acceptingDrive = value;
                    OnPropertyChanged();
                }
            }
        }


        private bool _onAdress;
        public bool OnAdress
        {

            get => _onAdress;
            set
            {
                if (value != _onAdress)
                {
                    _onAdress = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _isDelay;
        public bool IsDelay
        {

            get => _isDelay;
            set
            {
                if (_onAdress == value) 
                { 
                    OnPropertyChanged();
                }
                if (value != _isDelay)
                {
                    _isDelay = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _enterDelay;
        public int EnterDelay
        {

            get => _enterDelay;
            set
            {
                if (value != _enterDelay)
                {
                    _enterDelay = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _drivingStarts;
        public bool DrivingStarts
        {

            get => _drivingStarts;
            set
            {
                if (value != _drivingStarts)
                {
                    _drivingStarts = value;
                    OnPropertyChanged();
                    
                }
            }
        }
        private int _enterStartPrice;
        public int EnterStartPrice
        {

            get => _enterStartPrice;
            set
            {
                if (value != _enterStartPrice)
                {
                    _enterStartPrice = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

        public VehicleOnAdress(User user)
        {

            InitializeComponent();
            LoggedInUser = user;
            DataContext = this;

            _vehicleOnAddressRepository = new VehicleOnAdressRepository();
            _drivingsRepository = new DrivingsRepository();

            //from CSV file to SelectDriverComboBox
            string csvFilePath = "../../../Resources/Data/vehicles.csv";

            try
            {
                using (TextFieldParser parser = new TextFieldParser(csvFilePath))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");

                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();

                        // Assuming the values are in the first column of each line
                        if (fields.Length > 0)
                        {
                            string value = fields[0];
                            SelectDriverComboBox.Items.Add(value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the process
                MessageBox.Show("Error: " + ex.Message);
            }
            //Reserved driving in Grid (Name)
            Drivings = _drivingsRepository.GetAll();

            if (OnAdressCheckBox != null)
            {
                IsDelayCheckBox.IsReadOnly = true;
                EnterDelayTextBox.IsReadOnly = true;
            }
            else
            {
                IsDelayCheckBox.IsReadOnly = false;   
                EnterDelayTextBox.IsReadOnly = false;
            }

            

        }

        private Drivings GetSelectedDriving()
        {
            return new Drivings();
        }

        

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            
            Close();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        { 
            //Name
            Drivings name = GetSelectedDriving();
            //Accept drive and send notification
            if (AcceptDrive != null)
            {
                
                /*
                //Send notification
                notificationReceived = Notification.SentNotification;

                 Check if there are any notifications
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
                }*/
            }
            bool acceptingDrive = Convert.ToBoolean(AcceptingDrive);
            
            
            
            //On Adress
            bool isOnAdress = Convert.ToBoolean(OnAdress);
            //Delay
            bool isDelay = Convert.ToBoolean(IsDelay);
            int delay = Convert.ToInt32(EnterDelay);
            //Drivig Starts
            bool drivingStarts = Convert.ToBoolean(DrivingStarts);
            //Enter Start Price
            int enterStartPrice = Convert.ToInt32(EnterStartPrice);
            

            OnAdress newVehicleOnAdress = new OnAdress( name, LoggedInUser, acceptingDrive, isOnAdress, isDelay, delay , drivingStarts, enterStartPrice);
            _vehicleOnAddressRepository.Save(newVehicleOnAdress);
            
            
            MessageBox.Show("Data Saved");
            TaximeterWindow taximeterWindow = new TaximeterWindow();
            taximeterWindow.Show();
            

            Close();
        }

        private void SelectDriverComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
