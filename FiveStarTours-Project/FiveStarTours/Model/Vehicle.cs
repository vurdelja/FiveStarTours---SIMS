using FiveStarTours.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;



namespace FiveStarTours.Model
{
    public class Vehicle : FiveStarTours.Serializer.ISerializable
    {
        public int Id { get; set; }
        public int IdLocation { get; set; }
        public Location Location { get; set; } //lokacija
        public int MaxPersonNum { get; set; } // maksimalni broj osoba
        public int IdLanguage { get; set; }
        public Language Language { get; set; } //jezik
        public List<string> ImageUrls { get; set; } // slike


        public Vehicle() { }

        public Vehicle(int id, int idLocation, Location location, int maxPersonNum, int idLanguage, Language language, List<string> imageUrls)
        {
            Id = id;
            IdLocation = idLocation;
            Location = location;
            MaxPersonNum = maxPersonNum;
            IdLanguage = idLanguage;
            Language = language;
            ImageUrls = imageUrls;
        }


        public string[] ToCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                IdLocation.ToString(),
                MaxPersonNum.ToString(),
                string.Join(';', IdLanguage),
                string.Join(';', ImageUrls)
            };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            IdLocation = Convert.ToInt32(values[1]);
            MaxPersonNum = Convert.ToInt32(values[2]);
            IdLanguage = Convert.ToInt32(values[3]);
            ImageUrls = values[4].Split(';').ToList();
        }


    }
}
