using FiveStarTours.Model;
using FiveStarTours.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveStarTours.Repository
{
    public class RatingsRepository
    {
        private const string FilePath = "../../../Resources/Data/ratings.csv";

        private readonly Serializer<Rating> _serializerRating;

        private List<Rating> _ratings;

        public RatingsRepository()
        {
            _serializerRating = new Serializer<Rating>();
            _ratings = _serializerRating.FromCSV(FilePath);
        }

        public List<Rating> GetAll()
        {
            return _serializerRating.FromCSV(FilePath);
        }

        public Rating Save(Rating rating)
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

        public Rating GetById(int id)
        {
            _ratings = GetAll();
            foreach (Rating rating in _ratings)
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
