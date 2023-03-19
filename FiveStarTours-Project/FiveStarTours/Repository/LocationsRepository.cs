// Modeled on CommentRepository from InitialProject

using System.Collections.Generic;
using System.Linq;
using FiveStarTours.Model;
using FiveStarTours.Serializer;

namespace FiveStarTours.Repository
{
    public class LocationsRepository
    {
        private const string FilePath = "../../../Resources/Data/locations.csv";

        private readonly Serializer<Location> _serializer;

        private List<Location> _locations;

        public LocationsRepository()
        {
            _serializer = new Serializer<Location>();
            _locations = _serializer.FromCSV(FilePath);
        }

        public List<Location> GetAll()
        {
            return _serializer.FromCSV(FilePath);
        }

        public List<string> GetAllStates()
        {
            List<Location> locations = GetAll();
            List<string> states = locations.Select(l => l.State).Distinct().ToList();
            return states;
        }
        public List<string> GetCitiesInState(string state)
        {
            var locations = GetAll();
            return locations
                .Where(l => l.State == state)
                .Select(l => l.City)
                .Distinct()
                .ToList();
        }
    }
}