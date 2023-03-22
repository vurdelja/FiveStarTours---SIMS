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
        //public List<Drivings> DrivingsList;
        public Drivings Drivings { get; set; }
        public int Delays { get; set; }
        public string? SelectedFinishedComboBox { get; set; }



        public OnAdress() { }

        public OnAdress( Drivings drivings, int delays, string? selectedFinishedComboBox)
        {

            //this.DrivingsList = drivingsList;
            Drivings = drivings;
            Delays = delays;
            SelectedFinishedComboBox = selectedFinishedComboBox;
            
        }

        public string[] ToCSV()
        {

            string[] csvValues =
            {
                Id.ToString(),

                Delays.ToString(),

                Drivings.ToString(),

                SelectedFinishedComboBox.ToString()
            };

            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);

            Delays = Convert.ToInt32(values[1]);

            SelectedFinishedComboBox = values[3];

            
            

            
        }
    }
}
