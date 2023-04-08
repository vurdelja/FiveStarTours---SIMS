using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiveStarTours.Serializer;


namespace FiveStarTours.Model
{
    public class AccommodationReservation : ISerializable
    {
        public int Id { get; set; }
        public string GuestName { get; set; }
        public string GuestSurname { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
       
        public int VisitationDays { get; set; }
        public string AccommodationName { get; set; }
        public int GuestNumber { get; set; }

        public bool RatedByOwner { get; set; }
        public bool RatedByGuest { get; set; }

        public AccommodationReservation(string name, string surname, DateTime startDate, DateTime endDate, int visitationDays, string accommodationName, int guestNum)
        {
            this.GuestName = name;
            this.GuestSurname = surname;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.VisitationDays = visitationDays;
            this.AccommodationName = accommodationName;
            this.GuestNumber = guestNum;
            RatedByOwner = false;
            RatedByGuest = false;
        }
        public AccommodationReservation()
        { }
        public string[] ToCSV()
        {
            string[] csvValues =
           {
                Id.ToString(),
                GuestName,
                GuestSurname,

                string.Join(';', StartDate),
                string.Join(';', EndDate),
                VisitationDays.ToString(),
                AccommodationName,
                GuestNumber.ToString(),
                RatedByOwner.ToString(),
                RatedByGuest.ToString()

            };

            return csvValues;
        }


        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            GuestName = values[1];
            GuestSurname = values[2];
            StartDate = Convert.ToDateTime(values[3]);
            EndDate = Convert.ToDateTime(values[4]);
            VisitationDays = Convert.ToInt32(values[5]);
            AccommodationName = values[6];
            GuestNumber = Convert.ToInt32(values[7]);
            RatedByOwner = Convert.ToBoolean(values[8]);
            RatedByGuest = Convert.ToBoolean(values[9]);
        }

    }

}

