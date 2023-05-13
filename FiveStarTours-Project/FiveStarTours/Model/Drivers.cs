using FiveStarTours.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveStarTours.Model
{
    public class Drivers : ISerializable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
        public DateTime StartWork { get; set; }
        public DateTime FinishWork { get; set; }

        public Vehicle Vehicle { get; set; }    
        public Drivers() { }

        public Drivers(int id, string name, Location location, DateTime startWork, DateTime finishWork, Vehicle vehicle)
        {
            Id = id;
            Name = name;
            Location = location;
            StartWork = startWork;
            FinishWork = finishWork;
            Vehicle = vehicle;
        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                Name.ToString(),
                StartWork.ToString(),
                FinishWork.ToString(),
                

            };
            return csvValues;
        }
        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            Name = Convert.ToString(values[1]);
            StartWork = Convert.ToDateTime(values[2]);
            FinishWork = Convert.ToDateTime(values[3]);
        }

    }
}
