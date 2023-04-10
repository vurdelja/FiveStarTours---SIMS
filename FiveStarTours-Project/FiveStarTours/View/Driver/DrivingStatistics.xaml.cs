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
using System.Windows.Forms.DataVisualization;
using System.Collections.ObjectModel;
using System.IO;


using FiveStarTours.Model;
using FiveStarTours.Repository;
using FiveStarTours.Serializer;
using System.ComponentModel;
using System.Data;
using System.Collections;

namespace FiveStarTours.View.Driver
{
    /// <summary>
    /// Interaction logic for DrivingStatistics.xaml
    /// </summary>
    public partial class DrivingStatistics : Window
    {
        private readonly DrivingStatisticsRepository _drivingStatisticsRepository;
        private readonly DrivingStatisticsRepository2 _drivingStatisticsRepository2;


        public static List<DrivingStatisticsData> DrivingStatisticsData { get; set; }
        public static List<DrivingStatisticsData2> DrivingStatisticsData2 { get; set; }


       
        public DrivingStatistics()
        {
            InitializeComponent();
            DataContext = this;

            _drivingStatisticsRepository = new DrivingStatisticsRepository();
            _drivingStatisticsRepository2 = new DrivingStatisticsRepository2();

            DrivingStatisticsData = _drivingStatisticsRepository.GetAll();
            DrivingStatisticsData2 = _drivingStatisticsRepository2.GetAll();

            /*
            if (DataGridStatistics.SelectedItem == "2019") 
            {
                drivingStatisticsData2.Add(new DrivingStatisticsData2() { DrivingNDP = "Driving Number", January = "100" });
                drivingStatisticsData2.Add(new DrivingStatisticsData2() { DrivingNDP = "Driving Duration", January = "100" });
                drivingStatisticsData2.Add(new DrivingStatisticsData2() { DrivingNDP = "Driving Price", January = "100" });
            }*/
            
        }

        
    }
}
    

