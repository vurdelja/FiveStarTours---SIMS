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
        
        public string Finished { get; set; }



        public OnAdress() { }

        public OnAdress( Drivings drivings, bool isOnAdress, bool isDelay, int delays, string finished)
        {

            Drivings = drivings;
            IsOnAdress = isOnAdress;
            IsDelay = isDelay;
            Delays = delays;
            Finished = finished;
        }

        public string[] ToCSV()
        {

            string[] csvValues =
            {
                Id.ToString(),

                IsOnAdress.ToString(),
                IsDelay.ToString(),
                Delays.ToString(),
                Finished.ToString()

                
            };

            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            /*
            IsOnAdress = Convert.ToBoolean(values[1]);
            IsDelay = Convert.ToBoolean(values[2]);
            Delays = Convert.ToInt32(values[3]);
            Finished = Convert.ToString(values[4]);
            */
            
            IsOnAdress.GetType().ToString();
            IsDelay.GetType().ToString();
            Delays.GetType().ToString();
            //Finished.GetType().ToString();

            if (Finished == null)
            {
                GetFinished();

            }

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

        public string GetFinished()
        {
            return Finished;
        }

        
    }
}
