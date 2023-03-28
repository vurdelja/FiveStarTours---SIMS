﻿using FiveStarTours.Model;
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
        public Drivings SelectedDrivings { get; set; }
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
        public bool IsOnAdress
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

        private int _delay;

        public int Delay
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
            
        }
        private string selectFinished;
        private void FinishedComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FinishedComboBox.SelectedItem != null)
            {

                selectFinished = FinishedComboBox.SelectedItem as string;
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            
            Drivings name = GetSelectedDriving();
            bool isOnAdress = Convert.ToBoolean(IsOnAdress);
            bool isDelay = Convert.ToBoolean(IsDelay);
            int delay = Convert.ToInt32(Delay);
            string finished = GetFinished();


            OnAdress newVehicleOnAdress = new OnAdress( name, isOnAdress, isDelay, delay, finished);
            _vehicleOnAddressRepository.Save(newVehicleOnAdress);
            MessageBox.Show("Data saved successfully.");
            
            Close();
        }

        private string GetFinished()
        {
            return FinishedComboBox.ToString();
        }

        private Drivings GetSelectedDriving()
        {
            return new Drivings();
        }
        
    }
}
