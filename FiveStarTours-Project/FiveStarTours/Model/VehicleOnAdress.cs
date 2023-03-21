using FiveStarTours.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveStarTours.Model
{
    public class VehicleOnAdress 
    {

        public int Id;
        public List<Drivings> drivingsList;
        public object delays;
       

        VehicleOnAdress() { }

        public VehicleOnAdress(List<Drivings> drivingsList, int delays)
        {

            
            this.drivingsList = drivingsList;
            this.delays = delays;
            
        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),

                delays.ToString(),

                string.Join(';', drivingsList) };
                
            return csvValues;
        }



        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            
            delays = Convert.ToInt32(values[1]);


            
        }
    }
}
