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


namespace FiveStarTours.View.VehicleOnAdress
{
    /// <summary>
    /// Interaction logic for VehicleOnAdress.xaml
    /// </summary>
    public partial class VehicleOnAdress : Window, INotifyPropertyChanged
    {

        private readonly VehicleOnAdressRepository _vehicleOnAddressRepository;
        private readonly DrivingsRepository _drivingsRepository;
        public Drivings SelectedDrivings { get; set; }
        public static List<Drivings> Drivings { get; set; }



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


            Drivings = new List<Drivings>(_drivingsRepository.GetAll());

        }

        

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
           
        }


        /*

        public void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            // List<Drivings> DrivingsList = MakeDrivingsList(Drivings);
            Drivings drivings= GetSelectedDriving();
            int Delays = int.Parse(Delay);
            string selectedFinishedComboBox = FinishedComboBox.SelectedItem.ToString();

            OnAdress newVehicleOnAdress = new OnAdress( drivings , Delays, selectedFinishedComboBox);
            _vehicleOnAddressRepository.Save(newVehicleOnAdress);
            MessageBox.Show("Data saved successfully.");

            Close();
        }
        */

    }
}
