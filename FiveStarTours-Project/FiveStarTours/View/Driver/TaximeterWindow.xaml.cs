using FiveStarTours.Model;
using FiveStarTours.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
using System.Windows.Threading;
using System.Xml.Linq;


namespace FiveStarTours.View.Driver
{
    /// <summary>
    /// Interaction logic for TaximeterWindow.xaml
    /// </summary>
    public partial class TaximeterWindow : Window, INotifyPropertyChanged
    {
        private readonly TaximeterRepository _taximeterRepository;
        private readonly VehicleOnAdressRepository _vehicleOnAddressRepository;
        public static List<Taximeter> Taximeters { get; set; }

        private string currentTime = "00:00:00";

        public string CurrentTime
        {
            get { return currentTime; }
            set { currentTime = value; OnPropertyChanged("CurrentTime"); }
        }

        private string _time;
        public string Time
        {

            get => _time;
            set
            {
                if (value != _time)
                {
                    _time = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _price;
        public string Price
        {

            get => _price;
            set
            {
                if (value != _price)
                {
                    _price = value;
                    OnPropertyChanged();
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
        
        private void Timer_Tick(object sender, EventArgs e)
        {
            Time = currentTime;
            currentTime = ToString();
            //currentTime = DateTime.Now.ToString("HH:mm:ss"); // update CurrentTime with current time
        }

        public TaximeterWindow()
        {
            InitializeComponent();
            DataContext = this; // set DataContext to the code-behind file

            _vehicleOnAddressRepository = new VehicleOnAdressRepository();
            _taximeterRepository = new TaximeterRepository();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start(); // start the timer
            
            
            
        }

        
        private void FinishButton_Click(object sender, RoutedEventArgs e)
        {
            string time = Convert.ToString(Time);
            string price = Convert.ToString(Price);


           Taximeter newTaximeter = new Taximeter(time, price);
            _taximeterRepository.Save(newTaximeter);


            MessageBox.Show("TIME: " + TimeTextBox + "PRICE: " + PriceTextBox);
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        
    }
}
