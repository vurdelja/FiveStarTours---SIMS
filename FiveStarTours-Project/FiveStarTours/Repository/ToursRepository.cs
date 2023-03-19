// Modeled on CommentRepository from InitialProject

using System;
using System.Collections.Generic;
using System.Linq;
using FiveStarTours.Model;
using FiveStarTours.Serializer;

namespace FiveStarTours.Repository
{
    public class ToursRepository
    {
        private const string FilePath = "../../../Resources/Data/tours.csv";

        private readonly Serializer<Tour> _serializerTour;

        private List<Tour> _tours;

        public ToursRepository()
        {
            _serializerTour = new Serializer<Tour>();
            _tours = _serializerTour.FromCSV(FilePath);
        }

        public List<Tour> GetAll()
        {
            return _serializerTour.FromCSV(FilePath);
        }

        public Tour Save(Tour tour)
        {
            tour.Id = NextId();
            _tours = _serializerTour.FromCSV(FilePath);
            _tours.Add(tour);
            _serializerTour.ToCSV(FilePath, _tours);
            return tour;
        }

        public int NextId()
        {
            _tours = _serializerTour.FromCSV(FilePath);
            if (_tours.Count < 1)
            {
                return 1;
            }
            return _tours.Max(t => t.Id) + 1;
        }

        public Tour GetById(int id)
        {
            _tours = GetAll();
            foreach (Tour tour in _tours)
            {
                if(tour.Id == id)
                {
                    return tour;
                }
            }
            return null;
        }

        public List<Tour> GetAllByDate(DateTime date)
        {
            List<Tour> toursByDate = new List<Tour>();
            var tours = GetAll();
            foreach (var tour in tours)
            {
                foreach (DateTime dateTime in tour.Beginning)
                {
                    if (dateTime.Date == date.Date)
                    {
                        DateTime tourDate = dateTime.Date;
                        TimeSpan tourTime = dateTime.TimeOfDay;

                        DateTime newDate = new DateTime(tourDate.Year, tourDate.Month, tourDate.Day, tourTime.Hours, tourTime.Minutes, tourTime.Seconds);
                        Location location = tour.getLocationById(tour.IdLocation);
                        Tour newTour = new Tour(tour.Name, tour.IdLocation, location, tour.Description, tour.IdLanguages, tour.Languages, tour.MaxGuests, tour.IdKeyPoints, tour.KeyPoints, newDate, tour.Duration, tour.ImageUrls);
                        toursByDate.Add(newTour);

                    }
                }
            }

            return toursByDate;
        }  
    }
}
