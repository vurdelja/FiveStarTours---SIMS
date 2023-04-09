using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using FiveStarTours.Serializer;
public enum StatusType
{
    approved,
    rejected,
    processing
}
namespace FiveStarTours.Model
{
    public class ReservationChange : ISerializable
    {
        public int Id { get; set; } 
        public AccommodationReservation AccommodationReservation { get; set; }  
        public DateTime NewStartDate { get; set; }
        public DateTime NewEndDate { get; set; }

        public StatusType Status { get; set; }
        public string Comment { get; set; }


        public ReservationChange( AccommodationReservation accommodationReservation, DateTime newStartDate, DateTime newEndDate, StatusType status, string comment)
        {
           
            AccommodationReservation = accommodationReservation;
            NewStartDate = newStartDate;
            NewEndDate = newEndDate;
            Status = status;
            Comment = comment;
        }
        public ReservationChange()
        { }
        public string[] ToCSV()
        {

            string[] csvValues = {
                Id.ToString(),
                AccommodationReservation.Id.ToString(),
                string.Join(';', NewStartDate),
                string.Join(';', NewEndDate),
                Status.ToString(),
                Comment

        };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            AccommodationReservation=new AccommodationReservation() { Id = Convert.ToInt32(values[1]) };
            NewStartDate = Convert.ToDateTime(values[2]);
            NewEndDate = Convert.ToDateTime(values[3]);
            Status = Enum.Parse<StatusType>(values[4]);
            Comment = values[5];

           
        }
    }
}
