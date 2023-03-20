using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Documents;
using FiveStarTours.Serializer;

namespace FiveStarTours.Model
{
    public class Guest : ISerializable
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public DateTime VisitStartDate { get; set; }
        public DateTime VisitEndDate { get; set; }


        public Guest() { }

        public Guest(int id, string name, string surname, DateTime visitStart, DateTime visitEnd)
        {
            Id = Id;
            Name = name;
            Surname = surname;
            VisitStartDate = visitStart;
            VisitEndDate= visitEnd;
        }

        public string[] ToCSV()
        {
           
            string[] csvValues = {
                Id.ToString(),
                Name,
                Surname
        };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            Name = values[1];
            Surname= values[2];
            
        }

    }
}
