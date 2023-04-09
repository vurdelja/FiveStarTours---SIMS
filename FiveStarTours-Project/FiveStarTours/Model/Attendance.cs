using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiveStarTours.Serializer;

namespace FiveStarTours.Model
{
    public class Attendance : ISerializable
    {
        public int Id { get; set; }
        public int IdTour { get; set; }
        public int IdVisitor { get; set; }
        public int IdKeyPoint { get; set; }

        public Attendance() { }
        public Attendance(int idTour, int idVisitor, int isKeyPoint)
        {
            IdTour = idTour;
            IdVisitor = idVisitor;
            IdKeyPoint = isKeyPoint;
        }

        public string[] ToCSV()
        {
            string[] csvValues =
          {
              Id.ToString(),
              IdTour.ToString(),
              IdVisitor.ToString(),
              IdKeyPoint.ToString(),
            };
            return csvValues;
        }
        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            IdTour = Convert.ToInt32(values[1]);
            IdVisitor = Convert.ToInt32(values[2]);
            IdKeyPoint = Convert.ToInt32(values[3]);
            
        }
    }
}
