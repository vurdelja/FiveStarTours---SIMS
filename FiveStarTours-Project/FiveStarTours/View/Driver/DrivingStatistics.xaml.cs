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


using FiveStarTours.Model;
using FiveStarTours.Repository;

namespace FiveStarTours.View.Driver
{
    /// <summary>
    /// Interaction logic for DrivingStatistics.xaml
    /// </summary>
    public partial class DrivingStatistics : Window
    {
        private readonly DrivingStatisticsRepository _drivingStatisticsRepository;
        public static List<DrivingStatisticsData> DrivingYearData { get; set; }
        public DrivingStatistics()
        {
            InitializeComponent();
            DataContext = this;

            _drivingStatisticsRepository = new DrivingStatisticsRepository();

            DrivingYearData = _drivingStatisticsRepository.GetAll();

        }

    }
}
