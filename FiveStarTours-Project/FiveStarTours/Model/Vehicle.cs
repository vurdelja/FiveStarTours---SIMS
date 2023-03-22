using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiveStarTours.Serializer;


namespace FiveStarTours.Model
{
    public class Vehicle : ISerializable
    {
        public int Id { get; set; }
        public int IdLocation { get; set; }
        public Location Location { get; set; }
        public int MaxPersonNum { get; set; }
        public List<int> IdLanguages { get; set; }
        public List<Language> Languages { get; set; }
        public List<string> ImageUrls { get; set; }


        public Vehicle() { }

        

        public Vehicle(Location location, List<Language> languageList, List<int>idLanguages, int maximumPersonNumber, List<string> imageUrlsList)
        {
            Location = location;
            MaxPersonNum = maximumPersonNumber;
            Languages = languageList;
            IdLanguages = idLanguages;
            ImageUrls = imageUrlsList;
        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                IdLocation.ToString(),
                MaxPersonNum.ToString(),
                
                string.Join(';', IdLanguages),
                string.Join(';', ImageUrls) };
             return csvValues;
        }
            
        

        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            IdLocation = Convert.ToInt32(values[1]);
            MaxPersonNum = Convert.ToInt32(values[2]);
            
            
            if (IdLanguages == null)
            {
                IdLanguages = new List<int>();
                
            }

            
            ImageUrls = values[4].Split(';').ToList();
        }

        
    }
}
