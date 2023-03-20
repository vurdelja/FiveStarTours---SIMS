﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Text.RegularExpressions;
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
        public Owner Owner { get; set; }
        public Guest Guest { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdLocation { get; set; }
        public Location Location { get; set; }
        public AccommodationType Type { get; set; }
        public int MaxGuestNum { get; set; }
        public int MinReservationDays { get; set; }
        public int DaysPossibleToCancel { get; set; } = 1;  //podrazumevana vrednost je jedan dan, a vlasnik može zadati neki drugi broj

        public List<string> ImageURLs { get; set; }   //Jedna ili više slika (za svaku sliku navesti URL)

        public Accommodation() { }

        public Accommodation(string Name, int idLocation, Location location, AccommodationType type, int maxGuestNum, int minReservationDays, int daysPossibleToCancel, List<string> imageURLs)
        {
            this.Name = Name;
            this.IdLocation = idLocation;
            this.Location = location;
            this.Type = type;
            this.MaxGuestNum = maxGuestNum;
            this.MinReservationDays = minReservationDays;
            this.DaysPossibleToCancel = daysPossibleToCancel;
            this.ImageURLs = imageURLs;
        }

        public string[] ToCSV()
        {
            StringBuilder imageURLsList = new StringBuilder();

            foreach (string imageURL in ImageURLs)
            {
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
                ImageURLs = new List<string>();
            }

            foreach (string imageURL in delimitedImageURLs)
            {
                string file = new string(imageURL);
                ImageURLs.Add(file);
            }
        }

        //validacija
        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                if (columnName == "textName")
                {
                    if (string.IsNullOrEmpty(Name))
                        return "Name is necessary!";
                }
                else if (columnName == "MaxGuestNum")
                {
                    if (string.IsNullOrEmpty(MaxGuestNum.ToString()))
                        return "Maximum number of guests is necessary!";
                }
                else if (columnName == "MinReservationDays")
                {
                    if (string.IsNullOrEmpty(MinReservationDays.ToString()))
                        return "Minimum reservation days is necessary!";
                }

                return null;
            }
        }

        private readonly string[] _validatedProperties = { "Name", "MaxGuestNum", "MinReservationDays" };

        public bool IsValid
        {
            get
            {
                foreach (var property in _validatedProperties)
                {
                    if (this[property] != null)
                        return false;
                }

                return true;
            }
        }

    }
}
