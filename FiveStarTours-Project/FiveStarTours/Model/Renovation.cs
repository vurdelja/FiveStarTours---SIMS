using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Xml.Linq;
using FiveStarTours.Repository;
using FiveStarTours.Serializer;


namespace FiveStarTours.Model
{
    public class Renovation : ISerializable
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int IdAccommodation { get; set; }
        public Accommodation Accommodation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ExpectedDuration { get; set; }
        public string Description { get; set; }
        public bool RecentlyRenovated { get; set; }  //godinu dana nakon renoviranja


        public Renovation() { }

        public Renovation(User user, Accommodation accommodation, int idAccommodation, DateTime start, DateTime end, int expected, string description)
        {
            User = user;
            Accommodation = accommodation;
            IdAccommodation = idAccommodation;
            StartDate= start;
            EndDate= end;
            ExpectedDuration = expected;
            Description = description;
            RecentlyRenovated = false;
        }

        public string[] ToCSV()
        {
            string[] csvValues = {
              Id.ToString(),
              User.Id.ToString(),
              IdAccommodation.ToString(),
              string.Join(';', StartDate),
              string.Join(';', EndDate),
              ExpectedDuration.ToString(),
              Description,
              RecentlyRenovated.ToString()

        };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            User = new User() { Id = Convert.ToInt32(values[1]) };
            IdAccommodation = Convert.ToInt32(values[2]);
            StartDate = Convert.ToDateTime(values[3]);
            EndDate = Convert.ToDateTime(values[4]);
            ExpectedDuration = Convert.ToInt32(values[5]);
            Description = values[6];
            RecentlyRenovated = Convert.ToBoolean(values[7]);
        }






    }
}
