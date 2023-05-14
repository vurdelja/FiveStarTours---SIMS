
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiveStarTours.Serializer;
using FiveStarTours.Model;
using FiveStarTours.View;
using FiveStarTours.Interfaces;

namespace FiveStarTours.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        private const string FilePath = "../../../Resources/Data/vehicles.csv";

        private readonly Serializer<Vehicle> _serializer;

        private List<Vehicle> _vehicles;
       

        private List<Vehicle> _countfastdrive;

        public VehicleRepository()
        {
            _serializer = new Serializer<Vehicle>();
            _vehicles = _serializer.FromCSV(FilePath);
        }

        public List<Vehicle> GetAll()
        {
            return _serializer.FromCSV(FilePath);
        }

        public Vehicle Save(Vehicle vehicle)
        {
            vehicle.Id = NextId();
            _vehicles = _serializer.FromCSV(FilePath);
            _vehicles.Add(vehicle);
            _serializer.ToCSV(FilePath, _vehicles);
            return vehicle;
        }

        public int NextId()
        {
            _vehicles = _serializer.FromCSV(FilePath);
            if (_vehicles.Count < 1)
            {
                return 1;
            }
            return _vehicles.Max(t => t.Id) + 1;
        }

        public Vehicle GetByFastDrive(string fastdrivenum)
        {
            _vehicles = GetAll();
            foreach (Vehicle vehicle in _vehicles)
            {
                if (vehicle.FastDriveNum == fastdrivenum)
                {
                    return vehicle;
                }
            }
            return null;
        }

        
        /*
public string CountFastDrive()
{
   int number = 0;
   _countfastdrive = GetbyFastDrive();

   foreach (Vehicle vehiclefastdrive in _countfastdrive)
   {
       number++;
   }

   return number;

}
*/
    }
}
