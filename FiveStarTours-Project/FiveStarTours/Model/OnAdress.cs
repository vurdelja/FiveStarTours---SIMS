using FiveStarTours.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveStarTours.Model
{
    public class OnAdress : ISerializable
    {

        public int Id { get; set; }
        public Drivings Drivings { get; set; }
        public bool IsOnAdress { get; set; }
        public bool IsDelay { get; set; }
        public int Delays { get; set; }
        



        public OnAdress() { }

        public OnAdress( Drivings drivings, bool isOnAdress, bool isDelay, int delays)
        {

            Drivings = drivings;
            IsOnAdress = isOnAdress;
            IsDelay = isDelay;
            Delays = delays;
            
        }

        public string[] ToCSV()
        {

            string[] csvValues =
            {
                Id.ToString(),
                
                IsOnAdress.ToString(),
                IsDelay.ToString(),
                Delays.ToString(),

                
            };

            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            IsOnAdress.GetType().ToString();
            IsDelay.GetType().ToString();
            Delays.GetType().ToString();
           
        }

        public bool GetIsOnAdress()
        {
            return IsOnAdress;
        }

        public bool GetIsDelay()
        {
            return IsDelay;
        }
        public int GetDelays() 
        {
            return Delays;
        }

        
    }
}
