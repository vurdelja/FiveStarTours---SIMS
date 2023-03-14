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
        public int Id { get; set; }
        public Driver() { }

        public Driver(int id)
        {
            Id = id;
        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                
            };
            return csvValues;
        }
        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
        }

        
    }
}
