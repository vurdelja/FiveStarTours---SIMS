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

       
        private const string FilePath = "../../../Resources/Data/drivingstatistics2.csv";



        public DrivingStatistics()
        {
            InitializeComponent();
            DataContext = this;

            _drivingStatisticsRepository = new DrivingStatisticsRepository();
            _drivingStatisticsRepository2 = new DrivingStatisticsRepository2();

            DrivingStatisticsData = _drivingStatisticsRepository.GetAll();

            DrivingStatisticsData dataItem = new DrivingStatisticsData();
            DrivingStatisticsData2 dataItem2 = new DrivingStatisticsData2();
            /*
            if (dataItem.DrivingYear.Equals(dataItem2.DrivingYear2) )
            {
                
                  
                    DrivingStatisticsData2.Add(dataItem2);
               
                
            }*/
            
                /*
                dataItem2.DrivingNDP = "Driving Number, Driving Duration, Driving Price";
                dataItem2.January = "1000, 2000, 3000";
                dataItem2.February = "4000, 5000, 6000";
                dataItem2.March = "7000, 8000, 9000";
                dataItem2.April = "1000, 2000, 3000";
                dataItem2.May = "4000, 5000, 6000";
                dataItem2.June = "7000, 8000, 9000";
                dataItem2.July = "1000, 2000, 3000";
                dataItem2.August = "7000, 8000, 9000";
                dataItem2.September = "1000, 2000, 3000";
                dataItem2.October = "1000, 2000, 3000";
                dataItem2.November = "7000, 8000, 9000";
                dataItem2.December = "4000, 5000, 6000";*/

        }


    }
}
    

