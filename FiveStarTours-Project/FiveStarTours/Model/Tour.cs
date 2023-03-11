using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiveStarTours.Serializer;

namespace FiveStarTours.Model
{
    public class Tour : ISerializable
    {
        public int Id { get; set; }
        public string Name { get; set; }  
        public int IdLocation { get; set; }
        public Location Location { get; set; }
        public string Description { get; set; } 
        public List<int> IdLanguage { get; set; }
        public List<Language> Language { get; set; }
        public int MaxGuests { get; set; }
        public List<int> IdKeyPoints { get; set; }
        public List<KeyPoints> KeyPoints { get; set; }
        public List<DateTime> Beginning { get; set; }
        public int Duration { get; set; }
        public List<string> ImageUrls { get; set; }

        public Tour() { }

        public Tour(int id, string name, int idLocation, Location location, string description, List<int> idLanguage, List<Language> language, int maxGuests, List<int> idKeyPoints, List<KeyPoints> keyPoints, List<DateTime> beginning, int duration, List<string> imageUrls)
        {
            Id = id;
            Name = name;
            IdLocation = idLocation;
            Location = location;
            Description = description;
            IdLanguage = idLanguage;
            Language = language;
            MaxGuests = maxGuests;
            IdKeyPoints = idKeyPoints;
            KeyPoints = keyPoints;
            Beginning = beginning;
            Duration = duration;
            ImageUrls = imageUrls;
        }

        public string[] ToCSV()
        {
            string[] csvValues =
            { Id.ToString(),
              Name,
              IdLocation.ToString(),
              Description,
              string.Join(';', IdLanguage),
              MaxGuests.ToString(), 
              string.Join(';', IdKeyPoints),
              string.Join(';', Beginning), 
              Duration.ToString(), 
              string.Join(';', ImageUrls) };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            Name = values[1];
            IdLocation = Convert.ToInt32(values[2]);
            Description = values[3];
            IdLanguage = ConvertToInt(values[4]);
            MaxGuests = Convert.ToInt32(values[5]);
            IdKeyPoints = ConvertToInt(values[6]);
            Beginning = ConvertToDateTime(values[7]);
            Duration = Convert.ToInt32(values[8]);
            ImageUrls = values[9].Split(';').ToList();

        }

        // Conversion from string to DateTime - for list
        public List<DateTime> ConvertToDateTime(string values)
        {
            List <string> dates = values.Split(';').ToList();
            List <DateTime> result = new List<DateTime>();

            foreach(string date in dates)
            {
                DateTime beginning = Convert.ToDateTime(date);
                result.Add(beginning);
            }

            return result;
        }

        // Conversion from string to int - for list
        public List<int> ConvertToInt(string values)
        {
            List <string> numbers = values.Split(';').ToList();
            List <int> result = new List<int>();

            foreach(string num in numbers)
            {
                int number = Convert.ToInt32(num);
                result.Add(number);
            }

            return result;

        }

    }
}
