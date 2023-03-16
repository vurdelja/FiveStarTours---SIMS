using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using FiveStarTours.Exceptions;
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
        public int IdOwner { get; set; } 
        public string Name { get; set; }
        public int IdLocation { get; set; }
        public AccommodationType Type { get; set; }
        public int MaxGuestNum { get; set; }
        public int MinReservationDays { get; set; }
        public int DaysPossibleToCancel { get; set; } = 1;  //podrazumevana vrednost je jedan dan, a vlasnik može zadati neki drugi broj

        public List<string> ImageURLs = new List<string>();   //Jedna ili više slika (za svaku sliku navesti URL)

        public Accommodation() { }

        public Accommodation(int Id, int idOwner, string Name, int idLocation, AccommodationType type, int maxGuestNum, int minReservationDays, int daysPossibleToCancel)
        {
            this.Id = Id;
            this.IdOwner = idOwner;
            this.Name = Name;
            this.IdLocation = idLocation;
            this.Type = type;
            this.MaxGuestNum = maxGuestNum;
            this.MinReservationDays = minReservationDays;
            this.DaysPossibleToCancel = daysPossibleToCancel;
          
        }

        public string[] ToCSV()
        {
            StringBuilder imageList = new StringBuilder();

            foreach(string image in ImageURLs)
            {
                imageList.Append(image);
                imageList.Append(',');
            }

            imageList.Remove(imageList.Length - 1, 1);
            
            string[] csvValues = {
                Id.ToString(),
                IdOwner.ToString(),
                Name,
                IdLocation.ToString(),
                Type.ToString(),
                MaxGuestNum.ToString(),
                MinReservationDays.ToString(),
                DaysPossibleToCancel.ToString(),
                imageList.ToString(),
                
        };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            IdOwner = Convert.ToInt32(values[1]);
            Name = values[2];
            IdLocation = Convert.ToInt32(values[3]);
            Type = Enum.Parse<AccommodationType>(values[4]);
            MaxGuestNum = int.Parse(values[5]);
            MinReservationDays = int.Parse(values[6]);
            DaysPossibleToCancel = int.Parse(values[7]);

            string images = values[8];
            string[] delimitedImages = images.Split(";");

            if(ImageURLs == null)
            {
                ImageURLs = new List<string>();
            }

            foreach(string image in delimitedImages)
            {
                ImageURLs.Add(image);
            }

        }


        public bool Conflicts(Accommodation accommodation)
        {
            if (accommodation.Id != Id)
            {
                return false;
            }

            else
            {
                return true;
            }
        }

        


    }
}
