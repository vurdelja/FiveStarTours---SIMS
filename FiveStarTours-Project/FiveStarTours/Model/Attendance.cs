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
        public int IdVisitor { get; set; }
        public int IdKeyPoint { get; set; }

        public Attendance() { }
        public Attendance(int idVisitor, int isKeyPoint)
        {
            IdVisitor = idVisitor;
            IdKeyPoint = isKeyPoint;
        }

        public string[] ToCSV()
        {
            string[] csvValues =
          {
              Id.ToString(),
              IdVisitor.ToString(),
              IdKeyPoint.ToString(),
            };
            return csvValues;
        }
        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            IdVisitor = Convert.ToInt32(values[1]);
            IdKeyPoint = Convert.ToInt32(values[2]);
            
        }
    }
}
