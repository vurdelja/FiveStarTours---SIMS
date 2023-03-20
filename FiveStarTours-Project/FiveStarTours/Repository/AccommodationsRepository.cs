using FiveStarTours.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using FiveStarTours.Serializer;

namespace FiveStarTours.Repository
{
    public class AccommodationsRepository
    {
        private const string FilePath = "../../../Resources/Data/accommodations.csv";

        private readonly Serializer<Accommodation> _serializer;

        private List<Accommodation> _accommodations;

        public AccommodationsRepository()
        {
            _serializer = new Serializer<Accommodation>();
            _accommodations = _serializer.FromCSV(FilePath);
        }

        public List<Accommodation> GetAll()
        {
            return _serializer.FromCSV(FilePath);
        }

        public Accommodation Save(Accommodation accommodation)
        {
            accommodation.Id = NextId();
            _accommodations = _serializer.FromCSV(FilePath);
            _accommodations.Add(accommodation);
            _serializer.ToCSV(FilePath, _accommodations);
            return accommodation;
        }

        public List<Accommodation> Load()
        {
            return _serializer.FromCSV(FilePath);
        }

        public int NextId()
        {
            _accommodations = _serializer.FromCSV(FilePath);
            if (_accommodations.Count < 1)
            {
                return 1;
            }
            return _accommodations.Max(t => t.Id) + 1;
        }
    }

}
