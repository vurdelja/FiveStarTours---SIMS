﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiveStarTours.Serializer;
using FiveStarTours.Model;
using FiveStarTours.View;


namespace FiveStarTours.Repository
{
    public class VehicleOnAdressRepository
    {
        private const string FilePath = "../../../Resources/Data/vehicleOnAdress.csv";

        private readonly Serializer<VehicleOnAdress> _serializer;

        private List<VehicleOnAdress> _vehicleOnAdress;

        public VehicleOnAdressRepository()
        {
            _serializer = new Serializer<VehicleOnAdress>();
            _vehicleOnAdress = _serializer.FromCSV(FilePath);
        }

        public List<VehicleOnAdress> GetAll()
        {
            return _serializer.FromCSV(FilePath);
        }

        public VehicleOnAdress Save(VehicleOnAdress newVehicleOnAdress)
        {
            newVehicleOnAdress.Id = NextId();
            _vehicleOnAdress = _serializer.FromCSV(FilePath);
            _vehicleOnAdress.Add(newVehicleOnAdress);
            _serializer.ToCSV(FilePath, _vehicleOnAdress);
            return newVehicleOnAdress;
        }

        public int NextId()
        {
            _vehicleOnAdress = _serializer.FromCSV(FilePath);
            if (_vehicleOnAdress.Count < 1)
            {
                return 1;
            }
            return _vehicleOnAdress.Max(t => t.Id) + 1;
        }
    }
}
