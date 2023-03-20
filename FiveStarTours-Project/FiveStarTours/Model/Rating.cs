using FiveStarTours.Repository;
using FiveStarTours.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveStarTours.Model
{
    public class Rating : ISerializable
    {
        public int Id { get; set; }
        public int IdGuest { get; set; }
        public Guest Guest { get; set; }
        public int CleanRate { get; set; }
        public int RulesFollowed { get; set; }
        public string Comment { get; set; }


        public Rating() { }

        public Rating(int id, int idGuest, Guest guest, int cleanRate, int rulesFollowed, string comment)
        {
            Id = id;
            IdGuest = idGuest;
            Guest = guest;
            CleanRate = cleanRate;
            RulesFollowed = rulesFollowed;
            Comment = comment;
        }

        public string[] ToCSV()
        {

            string[] csvValues = {
                Id.ToString(),
                IdGuest.ToString(),
                CleanRate.ToString(),
                RulesFollowed.ToString(),
                Comment
        };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            IdGuest = Convert.ToInt32(values[1]);
            CleanRate = int.Parse(values[2]);
            RulesFollowed = int.Parse(values[3]);
            Comment = values[4];
        }

        public Guest getGuestById(int guestId)
        {
            GuestsRepository guestsRepository = new GuestsRepository();
            foreach (Guest guest in guestsRepository.GetAll())
            {
                if (guestId == guest.Id)
                {
                    Guest = guest;
                    return guest;
                }
            }

            return null;

        }
    }
}
