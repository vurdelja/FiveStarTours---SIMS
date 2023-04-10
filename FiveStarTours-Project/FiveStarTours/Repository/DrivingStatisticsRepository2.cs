using FiveStarTours.Model;
using FiveStarTours.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveStarTours.Repository
{
    public class DrivingStatisticsRepository2
    {
        private const string FilePath = "../../../Resources/Data/drivingstatistics2.csv";

        private readonly Serializer<DrivingStatisticsData2> _serializer;

        private List<DrivingStatisticsData2> _drivingStatisticsData2;

        public DrivingStatisticsRepository2()
        {
            _serializer = new Serializer<DrivingStatisticsData2>();
            _drivingStatisticsData2 = _serializer.FromCSV(FilePath);

        }

        public List<DrivingStatisticsData2> GetAll()
        {
            return _serializer.FromCSV(FilePath);
        }

        
        public int NextId()
        {
            _drivingStatisticsData2 = _serializer.FromCSV(FilePath);
            if (_drivingStatisticsData2.Count < 1)
            {
                return 1;
            }
            return _drivingStatisticsData2.Max(l => l.Id) + 1;
        }
    }

}
