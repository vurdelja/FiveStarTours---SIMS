using FiveStarTours.Model;
using FiveStarTours.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveStarTours.Repository
{
    public class TourRatingRepository
    { 
        private const string FilePath = "../../../Resources/Data/tourRating.csv";

        private readonly Serializer<TourRating> _serializer;

        private List<TourRating> _tourRatingRepository;

        public TourRatingRepository()
        {
            _serializer = new Serializer<TourRating>();
            _tourRatingRepository = _serializer.FromCSV(FilePath);

        }
        public List<TourRating> GetAll()
        {
            return _serializer.FromCSV(FilePath);
        }

        public TourRating Save(TourRating rating)
        {
            rating.Id = NextId();
            _tourRatingRepository = _serializer.FromCSV(FilePath);
            _tourRatingRepository.Add(rating);
            _serializer.ToCSV(FilePath, _tourRatingRepository);
            return rating;
        }

        public int NextId()
        {
            _tourRatingRepository = _serializer.FromCSV(FilePath);
            if (_tourRatingRepository.Count < 1)
            {
                return 1;
            }
            return _tourRatingRepository.Max(t => t.Id) + 1;
        }

        public TourRating GetById(int id)
        {
            _tourRatingRepository = GetAll();
            foreach (TourRating rating in _tourRatingRepository)
            {
                if (rating.Id == id)
                {
                    return rating;
                }
            }
            return null;
        }

        public TourRating Update(TourRating rating)
        {
            _tourRatingRepository = _serializer.FromCSV(FilePath);
            TourRating current = _tourRatingRepository.Find(c => c.Id == rating.Id);
            int index = _tourRatingRepository.IndexOf(current);
            _tourRatingRepository.Remove(current);
            _tourRatingRepository.Insert(index, rating);
            _serializer.ToCSV(FilePath, _tourRatingRepository);
            return rating;
        }
    }
}
