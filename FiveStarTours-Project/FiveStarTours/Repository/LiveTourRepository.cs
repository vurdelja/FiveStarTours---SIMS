using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiveStarTours.Model;
using FiveStarTours.Serializer;

namespace FiveStarTours.Repository
{
    public class LiveTourRepository
    {
        private const string FilePath = "../../../Resources/Data/livetours.csv";

        private readonly Serializer<LiveTour> _serializer;

        private List<LiveTour> _liveTours;

        public LiveTourRepository()
        {
            _serializer = new Serializer<LiveTour>();
            _liveTours = _serializer.FromCSV(FilePath);
        }

        public List<LiveTour> GetAll()
        {
            return _serializer.FromCSV(FilePath);
        }

        public LiveTour Save(LiveTour liveTour)
        {
            liveTour.Id = NextId();
            _liveTours = _serializer.FromCSV(FilePath);
            _liveTours.Add(liveTour);
            _serializer.ToCSV(FilePath, _liveTours);
            return liveTour;
        }

        public int NextId()
        {
            _liveTours = _serializer.FromCSV(FilePath);
            if (_liveTours.Count < 1)
            {
                return 1;
            }
            return _liveTours.Max(lt => lt.Id) + 1;
        }

        public void FindIdAndSave(LiveTour liveTour, int idLiveTour)
        {
            List<LiveTour> liveToursList = new List<LiveTour>();
            liveToursList = GetAll();
            var livetour = liveToursList.ElementAt(idLiveTour-1);
            if(livetour != null)
            {
                livetour = liveTour;
            }

            _serializer.ToCSV(FilePath, _liveTours);
        }
    }
}
