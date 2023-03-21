using FiveStarTours.Model;
using FiveStarTours.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveStarTours.Repository
{
    public class GuestRatingsRepository
    {
        private const string FilePath = "../../../Resources/Data/ratings.csv";

        private readonly Serializer<GuestRating> _serializerRating;

        private List<GuestRating> _ratings;

        public GuestRatingsRepository()
        {
            _serializerRating = new Serializer<GuestRating>();
            _ratings = _serializerRating.FromCSV(FilePath);
        }

        public List<GuestRating> GetAll()
        {
            return _serializerRating.FromCSV(FilePath);
        }

        public GuestRating Save(GuestRating rating)
        {
            rating.Id = NextId();
            _ratings = _serializerRating.FromCSV(FilePath);
            _ratings.Add(rating);
            _serializerRating.ToCSV(FilePath, _ratings);
            return rating;
        }

        public int NextId()
        {
            _ratings = _serializerRating.FromCSV(FilePath);
            if (_ratings.Count < 1)
            {
                return 1;
            }
            return _ratings.Max(t => t.Id) + 1;
        }

        public GuestRating GetById(int id)
        {
            _ratings = GetAll();
            foreach (GuestRating rating in _ratings)
            {
                if (rating.Id == id)
                {
                    return rating;
                }
            }
            return null;
        }
    }
}
