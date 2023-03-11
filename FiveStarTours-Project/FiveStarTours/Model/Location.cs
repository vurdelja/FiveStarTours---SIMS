using FiveStarTours.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveStarTours.Model
{
    public class Location : ISerializable
    {
        public string State { get; set; }
        public string City { get; set; }

        public Location() { }

        public Location(string state, string city)
        {
            this.State = state;
            this.City = city;
        }

        public string[] ToCSV()
        {
            string[] csvValues = 
            { 
                State, 
                City 
            };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            State = values[0];
            City = values[1];
        }
    }
}
