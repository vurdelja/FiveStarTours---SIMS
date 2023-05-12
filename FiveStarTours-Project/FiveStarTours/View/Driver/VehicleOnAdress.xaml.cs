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
using FiveStarTours.View.Driver;

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

        public VehicleOnAdress()
        {

            InitializeComponent();
            DataContext = this;

            _vehicleOnAddressRepository = new VehicleOnAdressRepository();
            _drivingsRepository = new DrivingsRepository();
            


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
            Drivings name = GetSelectedDriving();
            
            bool isOnAdress = Convert.ToBoolean(OnAdress);
            bool isDelay = Convert.ToBoolean(IsDelay);
            int delay = Convert.ToInt32(EnterDelay);
            
            bool drivingStarts = Convert.ToBoolean(DrivingStarts);
            int enterStartPrice = Convert.ToInt32(EnterStartPrice);
            

            OnAdress newVehicleOnAdress = new OnAdress( name, isOnAdress, isDelay, delay , drivingStarts, enterStartPrice);
            _vehicleOnAddressRepository.Save(newVehicleOnAdress);
            
            
            MessageBox.Show("Data Saved");
            TaximeterWindow taximeterWindow = new TaximeterWindow();
            taximeterWindow.Show();
            

            Close();
        }

        
    }
}
