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
    public class GroupRide : ISerializable
    {
        public int Id { get; set; }
        public int PassengerNumber { get; set; }
        public Location StartingLocation { get; set; }
        public string StartingStreet { get; set; }
        public Location DestinationLocation { get; set; }
        public string DestinationStreet { get; set; }
        public Language Language { get; set; }

        public GroupRide() { }

        public GroupRide(int id, int passengerNumber, Location startingLocation, string startingStreet, Location destinationLocation, string destinationStreet, Language language)
        {
            Id = id;
            PassengerNumber = passengerNumber;
            StartingLocation = startingLocation;
            StartingStreet = startingStreet;
            DestinationLocation = destinationLocation;
            DestinationStreet = destinationStreet;
            Language = language;
        }
        public string[] ToCSV()
        {
            string[] csvValues =
            {
              Id.ToString(),
              PassengerNumber.ToString(),
              StartingStreet,
              DestinationStreet,
              
             };
            return csvValues;
        }
        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            PassengerNumber = Convert.ToInt32(values[1]);
            StartingStreet = values[2];
            DestinationStreet = values[3];
            
        }
        
    }
}
