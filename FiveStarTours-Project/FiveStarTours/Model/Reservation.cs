using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiveStarTours.Serializer;


namespace FiveStarTours.Model
{
    internal class Reservation : ISerializable
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DaysForVisit { get; set; }

        public Reservation(DateTime startDate, DateTime endDate, int daysForVisit)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.DaysForVisit = daysForVisit;
        }
        public Reservation()
        { }
        public string[] ToCSV()
        {
            string[] csvValues =
           {
                string.Join(';', StartDate),
                string.Join(';', EndDate),
                DaysForVisit.ToString()
            };

            return csvValues;
        }


        public void FromCSV(string[] values)
        {
            StartDate = Convert.ToDateTime(values[0]);
            EndDate = Convert.ToDateTime(values[1]);
            DaysForVisit = Convert.ToInt32(values[2]);

        }

    }
    
}

