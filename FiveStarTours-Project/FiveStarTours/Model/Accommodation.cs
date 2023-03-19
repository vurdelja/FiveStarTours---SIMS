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
        public int IdLocation { get; set; }
        public Location Location { get; set; }
        public AccommodationType Type { get; set; }
        public int MaxGuestNum { get; set; }
        public int MinReservationDays { get; set; }
        public int DaysPossibleToCancel { get; set; } = 1;  //podrazumevana vrednost je jedan dan, a vlasnik može zadati neki drugi broj

        public List<Uri> ImageURLs { get; set; }   //Jedna ili više slika (za svaku sliku navesti URL)

        public Accommodation() { }

        public Accommodation(string Name, int idLocation, Location location, AccommodationType type, int maxGuestNum, int minReservationDays, int daysPossibleToCancel, List<string> imageURLs)
        {
            {
                ImageURLs = new List<Uri>();
            }

            this.Name = Name;
            this.IdLocation = idLocation;
            this.Location = location;
            this.Type = type;
            this.MaxGuestNum = maxGuestNum;
            this.MinReservationDays = minReservationDays;
            this.DaysPossibleToCancel = daysPossibleToCancel;

            
            this.ImageURLs = new List<Uri>();

            foreach(string imageURL in imageURLs)
            {
                Uri file = new Uri(imageURL);
                ImageURLs.Add(file);
            }
        }

        public string[] ToCSV()
        {
            StringBuilder imageURLsList = new StringBuilder();

            foreach (Uri imageURL in ImageURLs)
            {
                string imageURLString = imageURL.ToString();
                imageURLsList.Append(imageURL);
                imageURLsList.Append(" ,");
            }

            imageURLsList.Remove(imageURLsList.Length - 1, 1);

            string[] csvValues = {
                Id.ToString(),
                Name,
                IdLocation.ToString(),
                Type.ToString(),
                MaxGuestNum.ToString(),
                MinReservationDays.ToString(),
                DaysPossibleToCancel.ToString(),
                imageURLsList.ToString()
                
        };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            Name = values[1];
            IdLocation = Convert.ToInt32(values[2]);
            Type = Enum.Parse<AccommodationType>(values[3]);
            MaxGuestNum = int.Parse(values[4]);
            MinReservationDays = int.Parse(values[5]);
            DaysPossibleToCancel = int.Parse(values[6]);

            string imageURLs = values[7];
            string[] delimitedImageURLs = imageURLs.Split(",");
            if (ImageURLs == null)
            {
                ImageURLs = new List<Uri>();
            }

            foreach (string imageURL in delimitedImageURLs)
            {
                Uri file = new Uri(imageURL);
                ImageURLs.Add(file);
            }
        }

    }
}
