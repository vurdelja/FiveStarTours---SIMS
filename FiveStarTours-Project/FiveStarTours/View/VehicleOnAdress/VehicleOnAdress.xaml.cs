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


namespace FiveStarTours.View.VehicleOnAdress
{
    /// <summary>
    /// Interaction logic for VehicleOnAdress.xaml
    /// </summary>
    public partial class VehicleOnAdress : Window, INotifyPropertyChanged
    {

        private readonly VehicleOnAdressRepository _vehicleOnAddressRepository;
        private readonly DrivingsRepository _drivingsRepository;

        private string _drivings;
        public string Drivings
        {
            get => _drivings;
            set
            {
                if (value != _drivings)
                {
                    _drivings = value;
                    OnPropertyChanged();
                }
            }
        }


        private string _delay;
        public string Delay
        {

            get => _delay;
            set
            {
                if (value != _delay)
                {
                    _delay = value;
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
            

            // Adding state and city trough combobox:

            List<string> States = _drivingsRepository.GetAllNames();
            DrivingsComboBox.ItemsSource = States;
            DrivingsComboBox.SelectedValuePath = ".";
            DrivingsComboBox.DisplayMemberPath = ".";
        }

        
        private string selectedDriving;
        private void DrivingsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DrivingsComboBox.SelectedItem != null)
            {


                selectedDriving = DrivingsComboBox.SelectedItem as string;
            }
        }

        public void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            
            List<Drivings> DrivingsList = MakeDrivingsList(Drivings);
            int Delays = int.Parse(Delay);

            OnAdress newVehicleOnAdress = new OnAdress( DrivingsList, Delays);
            _vehicleOnAddressRepository.Save(newVehicleOnAdress);
            MessageBox.Show("Data saved successfully.");

            Close();
        }

        private List<Drivings> MakeDrivingsList(string drivings)
        {
            List<Drivings> result = new List<Drivings>();

            Array _drivings = drivings.Split(", ");

            foreach (string d in _drivings)
            {
                Drivings driv = new Drivings();
                _drivingsRepository.Save(driv);
                result.Add(driv);
            }

            return result;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void FinishedComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
