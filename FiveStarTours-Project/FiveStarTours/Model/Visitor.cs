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
        public int TourId { get; set; }
        public int IdKeyPoint { get; set; }
        public KeyPoints StartingKeyPoint { get; set; }
        public DateTime DateTime { get; set; }
        public int MembersNumber { get; set; }
        public string Email { get; set; }
        public Visitor() { }
        public Visitor(string visitorName, string phoneNumber, int tourId, int idKeyPoint, KeyPoints startingKeyPoint, DateTime dateTime, int membersNumber, string email)
        {
            VisitorName = visitorName;
            PhoneNumber = phoneNumber;
            TourId = tourId;
            IdKeyPoint = idKeyPoint;
            StartingKeyPoint = startingKeyPoint;
            DateTime = dateTime;
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
              TourId.ToString(),
              IdKeyPoint.ToString(),
              DateTime.ToString(),
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
            TourId = Convert.ToInt32(values[3]);
            IdKeyPoint = Convert.ToInt32(values[4]);
            DateTime = Convert.ToDateTime(values[5]);
            MembersNumber = Convert.ToInt32(values[6]);
            Email = values[7];           
        }
    }
}
