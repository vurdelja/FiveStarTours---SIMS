using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Xml.Linq;
using FiveStarTours.Repository;
using FiveStarTours.Serializer;


namespace FiveStarTours.Model
{
    public class Renovations : ISerializable
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int IdAccommodation { get; set; }
        public Accommodation Accommodation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ExpectedDuration { get; set; }
        public string Description { get; set; }


        public Renovations() { }

        public Renovations(User user, Accommodation accommodation, DateTime start, DateTime end, int expected, string description)
        {
            User = user;
            Accommodation = accommodation;
            StartDate= start;
            EndDate= end;
            ExpectedDuration = expected;
            Description = description;
        }

        public string[] ToCSV()
        {
            string[] csvValues = {
              Id.ToString(),
              User.Id.ToString(),
              Accommodation.Id.ToString(),
              Accommodation.AccommodationName,
              string.Join(';', StartDate),
              string.Join(';', EndDate),
              ExpectedDuration.ToString(),
              Description

        };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            User = new User() { Id = Convert.ToInt32(values[1]) };
            Accommodation = new Accommodation() { Id = Convert.ToInt32(values[2]) };
            Accommodation = new Accommodation() { AccommodationName = values[3] };
            StartDate = Convert.ToDateTime(values[4]);
            EndDate = Convert.ToDateTime(values[5]);
            ExpectedDuration = Convert.ToInt32(values[6]);
            Description = values[7];
        }






    }
}
