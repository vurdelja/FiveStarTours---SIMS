using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using FiveStarTours.Serializer;

public enum AccommodationType
{
    apartment,
    house,
    cottage
}

namespace FiveStarTours.Model
{
    public class Accommodation : ISerializable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
        public AccommodationType Type { get; set; }
        public int MaxGuestNum { get; set; }
        public int MinReservationDays { get; set; }
        public int DaysPossibleToCancel { get; set; } = 1;  //podrazumevana vrednost je jedan dan, a vlasnik može zadati neki drugi broj

        public List<string> ImageURLs = new List<string>();   //Jedna ili više slika (za svaku sliku navesti URL)
        public User Owner { get; set; }

        public Accommodation() { }

        public Accommodation(int Id, string Name, Location location, AccommodationType type, int maxGuestNum, int minReservationDays, int daysPossibleToCancel, List<Accommodation> photos, User owner)
        {
            this.Id = Id;
            this.Name = Name;
            this.Location = location;
            this.Type = type;
            this.MaxGuestNum = maxGuestNum;
            this.MinReservationDays = minReservationDays;
            this.DaysPossibleToCancel = daysPossibleToCancel;
            this.Owner = owner;
      
        }

        public string[] ToCSV()
        {
            
            string[] csvValues = {
                Id.ToString(),
                Name,
                Location.State.ToString(),
                Location.City.ToString(),
                Type.ToString(),
                MaxGuestNum.ToString(),
                MinReservationDays.ToString(),
                DaysPossibleToCancel.ToString()
                
        };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            Name = values[1];
            Location = new Location(values[2], values[3]);
            Type = Enum.Parse<AccommodationType>(values[4]);
            MaxGuestNum = int.Parse(values[5]);
            MinReservationDays = int.Parse(values[6]);
            DaysPossibleToCancel = int.Parse(values[7]);
            ImageURLs = values[8].Split(',').ToList();
            Owner = new User(values[9], values[10]);

        }
    }
}
