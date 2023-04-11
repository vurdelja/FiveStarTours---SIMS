using FiveStarTours.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveStarTours.Model
{
    public class Taximeter : ISerializable
    {
        public int Id { get; set; }
        public string ShowTimer { get; set; }
        public string ShowPrice { get; set; }
        public Taximeter()
        {
        }

        public Taximeter(int id, string showTimer, string showPrice)
        {
            Id = id;
            ShowTimer = showTimer;
            ShowPrice = showPrice;
        }   

        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);    
            ShowTimer = Convert.ToString(values[1]);    
            ShowPrice = Convert.ToString(values[2]);
        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                ShowTimer.ToString(),
                ShowPrice.ToString()

            };
            return csvValues;

        }
    }
}
