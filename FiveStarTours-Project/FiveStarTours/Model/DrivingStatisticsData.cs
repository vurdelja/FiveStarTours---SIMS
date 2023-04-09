using FiveStarTours.Repository;
using FiveStarTours.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace FiveStarTours.Model
{
    public class DrivingStatisticsData : ISerializable
    {
        public string DrivingYear { get; set; }
        public int DrivingNumber { get; set; }
        public string DrivingDuration { get; set; }
        public double DrivingPrice { get; set; }

        public DrivingStatisticsData() { }

        public DrivingStatisticsData(string drivingYear, int drivingNumber, string drivingDuration, double drivingPrice)
        {
            DrivingYear = drivingYear;  
            DrivingNumber = drivingNumber;
            DrivingDuration = drivingDuration;
            DrivingPrice = drivingPrice;
        }

        public void FromCSV(string[] values)
        {
            DrivingYear = Convert.ToString(values[0]);  
            DrivingNumber = Convert.ToInt32(values[1]); 
            DrivingDuration = Convert.ToString(values[2]);
            DrivingPrice = Convert.ToDouble(values[3]);     
        }

        public string[] ToCSV()
        {
            string[] csvValues =
            { 
              DrivingYear,
              DrivingNumber.ToString(),
              DrivingDuration,
              DrivingPrice.ToString() 
            };
        
            return csvValues;
        }
    }
}
