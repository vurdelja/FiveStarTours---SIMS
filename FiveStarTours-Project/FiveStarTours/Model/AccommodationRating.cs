using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiveStarTours.Serializer;

namespace FiveStarTours.Model
{
    public class AccommodationRating : ISerializable
    {
        public int Id { get; set; }
        public AccommodationReservation AccommodationReservation { get; set; }
        public int Tidiness { get; set; }
        public int RulesFollowed { get; set; }
        public string Comment { get; set; }
        public string Recommodation { get; set; }
        public List<string> ImageUrls { get; set; }


        public AccommodationRating()
        {
            AccommodationReservation = new AccommodationReservation();
        }

        public AccommodationRating(AccommodationReservation a, int tidiness, int rulesFollowed, string comment)
        {
            AccommodationReservation = a;
            Tidiness = tidiness;
            RulesFollowed = rulesFollowed;
            Comment = comment;
        }

        public string[] ToCSV()
        {

            string[] csvValues = {
                Id.ToString(),
                Tidiness.ToString(),
                RulesFollowed.ToString(),
                Comment
        };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            Tidiness = int.Parse(values[1]);
            RulesFollowed = int.Parse(values[2]);
            Comment = values[3];
        }
    }
}
