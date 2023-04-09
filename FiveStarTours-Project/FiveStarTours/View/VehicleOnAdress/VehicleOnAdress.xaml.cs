using FiveStarTours.Model;
using FiveStarTours.Repository;
using FiveStarTours.View;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using FiveStarTours.View.VehicleOnAdress;
using System.IO;
using System.Windows.Threading;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using System.Reflection.PortableExecutable;
using FiveStarTours.Serializer;
using ControlzEx.Standard;
using System.Security.Policy;



namespace FiveStarTours.View.VehicleOnAdress
{
    /// <summary>
    /// Interaction logic for VehicleOnAdress.xaml
    /// </summary>
    public partial class VehicleOnAdress : Window, INotifyPropertyChanged
    {

        private readonly VehicleOnAdressRepository _vehicleOnAddressRepository;
        private readonly DrivingsRepository _drivingsRepository;
        //public Drivings SelectedDrivings { get; set; }
        public static List<Drivings> Drivings { get; set; }

        private DispatcherTimer _timer;
        private DateTime _currentTime;

        public DateTime CurrentTime
        {
            get { return _currentTime; }
            set { _currentTime = value; OnPropertyChanged(nameof(CurrentTime)); }
        }

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

        

        private string _finished;
        public string Finished
        {

            get => _finished;
            set
            {
                if (value != _finished)
                {
                    _finished = value;
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

        public VehicleOnAdress()
        {
            InitializeComponent();
            DataContext = this;

            _vehicleOnAddressRepository = new VehicleOnAdressRepository();
            _drivingsRepository = new DrivingsRepository();

            
            Drivings = _drivingsRepository.GetAll();

            if (DrivingStartsCheckBox.IsThreeState) 
            {
                _timer = new DispatcherTimer();
                _timer.Interval = TimeSpan.FromSeconds(1);
                _timer.Tick += Timer_Tick;
                _timer.Start();
            }



            if (OnAdressCheckBox.IsThreeState == true)

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

        private void Timer_Tick(object sender, EventArgs e)
        {
            CurrentTime = DateTime.Now;
        }

        private void FinishedComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FinishedComboBox.SelectedItem != null)
            {

                string selectedFinishedComboBox = FinishedComboBox.SelectedItem.ToString();
                selectedFinishedComboBox = FinishedComboBox.SelectedItem as string;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            
            Drivings name = GetSelectedDriving();
            bool isOnAdress = Convert.ToBoolean(OnAdress);
            bool isDelay = Convert.ToBoolean(IsDelay);
            int delay = Convert.ToInt32(EnterDelay);
            string finished = FinishedComboBox.SelectedItem.ToString();
            bool drivingStarts = Convert.ToBoolean(DrivingStarts);
            int enterStartPrice = Convert.ToInt32(EnterStartPrice);
            string taximeter = GetTaximeter();


            OnAdress newVehicleOnAdress = new OnAdress( name, isOnAdress, isDelay, delay, finished, drivingStarts, enterStartPrice, taximeter);
            _vehicleOnAddressRepository.Save(newVehicleOnAdress);
            _drivingsRepository.Delete(name);
            MessageBox.Show("Driving Duration:");
            
            Close();
        }

        private string GetTaximeter()
        {
            throw new NotImplementedException();
        }

        private Drivings GetSelectedDriving()
        {
            return new Drivings();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
