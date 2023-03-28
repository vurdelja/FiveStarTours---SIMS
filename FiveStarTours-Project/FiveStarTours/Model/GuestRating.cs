using FiveStarTours.Repository;
using FiveStarTours.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FiveStarTours.Model
{
    public class GuestRating : ISerializable
    {
        public int Id { get; set; }
        public AccommodationReservation AccommodationReservation { get; set; }
        public int Tidiness { get; set; } 
        public int RulesFollowed { get; set; } 
        public int Quietness { get; set; }
        public int Friendliness { get; set; }
        public int Communication { get; set; }
        public int RespectTime { get; set; }
        public string Comment { get; set; }


        public GuestRating() 
        {
            AccommodationReservation= new AccommodationReservation();
        }

        public GuestRating(AccommodationReservation a, int tidiness, int rulesFollowed, int quietness, int friendliness, int communication, int respectTime , string comment)
        {
            AccommodationReservation= a;
            Tidiness = tidiness;
            RulesFollowed = rulesFollowed;
            Quietness = quietness;
            Friendliness= friendliness;
            Communication = communication;
            RespectTime = respectTime;
            Comment = comment;
        }

        public string[] ToCSV()
        {

            string[] csvValues = {
                Id.ToString(),
                AccommodationReservation.GuestName,
                AccommodationReservation.GuestSurname,
                Tidiness.ToString(),
                RulesFollowed.ToString(),
                Quietness.ToString(),
                Friendliness.ToString(),
                Communication.ToString(),
                RespectTime.ToString(),
                Comment
        };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            AccommodationReservation = new AccommodationReservation() { GuestName = values[1] };
            AccommodationReservation = new AccommodationReservation() { GuestSurname = values[2] };
            Tidiness = int.Parse(values[3]);
            RulesFollowed= int.Parse(values[4]);
            Quietness= int.Parse(values[5]);
            Friendliness= int.Parse(values[6]);
            Communication= int.Parse(values[7]);
            RespectTime= int.Parse(values[8]);
            Comment = values[9];
        }

    }
}
