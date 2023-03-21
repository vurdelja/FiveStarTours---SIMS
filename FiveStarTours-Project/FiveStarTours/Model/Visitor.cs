using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiveStarTours.Serializer;
using FiveStarTours.Repository;
using System.Windows;
using System.Xml.Linq;

namespace FiveStarTours.Model
{
    public class Visitor : ISerializable
    {
        public int Id { get; set; }
        public string VisitorName { get; set; }
        public string PhoneNumber { get; set; }
        public string StartingKeyPoint { get; set; }
        public int MembersNumber { get; set; }
        public string Email { get; set; }
        public Visitor() { }
        public Visitor(string visitorName, string phoneNumber, string startingKeyPoint, int membersNumber, string email)
        {
            VisitorName = visitorName;
            PhoneNumber = phoneNumber;
            StartingKeyPoint = startingKeyPoint;
            MembersNumber = membersNumber;
            Email = email;
        }
        public string[] ToCSV()
        {
            string[] csvValues =
           {
              Id.ToString(),
              VisitorName,
              PhoneNumber,
              StartingKeyPoint,              
              MembersNumber.ToString(),
              Email
            };
            return csvValues;
        }
        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            VisitorName = values[1];
            PhoneNumber = values[2];
            StartingKeyPoint = values[3];
            MembersNumber = Convert.ToInt32(values[4]);
            Email = values[5];           
        }
    }
}
