using FiveStarTours.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FiveStarTours.Model
{
    public class Vehicle : ISerializable
    {
        public int Id { get; set; }
        public int IdLocation { get; set; }
        public Location Location { get; set; }
        
        public int MaxPersonNum { get; set; }
        public string Language { get; set; }

        public List<string> ImageURLs = new List<string>();  


       Vehicle () { }

        public Vehicle(int id, int idLocation, Location location, int maxPersonNum, string language, List<string> imageURLs)
        {
            Id = id;
            IdLocation = idLocation;
            Location = location;
            
            MaxPersonNum = maxPersonNum;
            Language = language;
            ImageURLs = imageURLs;
        }


        public string[] ToCSV()
        {
            string[] csvValues = 
            {
                Id.ToString(),
                IdLocation.ToString(),
                MaxPersonNum.ToString(), 
                Language,
                
            };
            return csvValues;
        }


        public void FromCSV(string[] values)
        {
            Id = int.Parse(values[0]);
            IdLocation = int.Parse(values[1]);
            
            MaxPersonNum = int.Parse(values[2]);
            Language = values[3];
            ImageURLs = values[4].Split(',').ToList();

        }

        
    }
    }
