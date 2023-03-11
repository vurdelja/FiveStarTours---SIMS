﻿using FiveStarTours.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveStarTours.Model
{
    public class Location : ISerializable
    {
        public int Id { get; set; }
        public string State { get; set; }
        public string City { get; set; }

        public Location() { }

        public Location(int id, string state, string city)
        {
            Id = id;
            State = state;
            City = city;
        }

        public string[] ToCSV()
        {
            string[] csvValues = { State, City };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            State = values[1];
            City = values[2];
        }
    }
}
