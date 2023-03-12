using FiveStarTours.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FiveStarTours.Model
{
    public class Driver : ISerializable
    {

        public Location Location { get; set; }
        public int ID { get; set; }
        public int MaxPersonNum { get; set; }
        public string Language { get; set; }

        public List<string> ImageURLs = new List<string>();  


        Driver() { }

        public Driver(Location location, int iD, int maxPersonNum, string language, List<string> imageURLs)
        {
            Location = location;
            ID = iD;
            MaxPersonNum = maxPersonNum;
            Language = language;
            ImageURLs = imageURLs;
        }


        public string[] ToCSV()
        {
            string[] csvValues = 
            {
                Location.City.ToString(),
                Location.State.ToString(),
                ID.ToString(), 
                MaxPersonNum.ToString(), 
                Language,
                
            };
            return csvValues;
        }


        public void FromCSV(string[] values)
        {
            Location = new Location(values[0], values[1]);
            ID = Convert.ToInt32(values[2]);
            MaxPersonNum = int.Parse(values[3]);
            Language = values[4];
            ImageURLs = values[5].Split(',').ToList();

        }

        
    }
    }