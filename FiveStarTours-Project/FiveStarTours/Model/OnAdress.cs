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

        public int Id;
        public List<Drivings> DrivingsList;
        public int Delays;
       

        public OnAdress() { }

        public OnAdress(List<Drivings> drivingsList, int delays)
        {
            
            this.DrivingsList = drivingsList;
            this.Delays = delays;
            
        }

        public string[] ToCSV()
        {

            string[] csvValues =
            {
                Id.ToString(),

                Delays.ToString(),

                string.Join(';', DrivingsList) };

            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);

            Delays = Convert.ToInt32(values[1]);

            if (DrivingsList == null)
            {
                DrivingsList = new List<Drivings>();

            }
        }
    }
}
