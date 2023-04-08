﻿using FiveStarTours.Model;
using FiveStarTours.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveStarTours.Repository
{
    public class AccommodationRatingRepository
    {
        private const string FilePath = "../../../Resources/Data/accommodationRatings.csv";

        private readonly Serializer<AccommodationRating> _serializer;

        private static AccommodationRatingRepository instance = null;

        private List<AccommodationRating> _accratings;
        public static AccommodationRatingRepository GetInstace()
        {
            if (instance == null)
            {
                instance = new AccommodationRatingRepository();
            }
            return instance;
        }
        public AccommodationRatingRepository()
        {
            _serializer = new Serializer<AccommodationRating>();
            _accratings = _serializer.FromCSV(FilePath);
        }

        public List<AccommodationRating> GetAll()
        {
            return _serializer.FromCSV(FilePath);
        }

        public AccommodationRating Save(AccommodationRating rating)
        {
            rating.Id = NextId();
            _accratings = _serializer.FromCSV(FilePath);
            _accratings.Add(rating);
            _serializer.ToCSV(FilePath, _accratings);
            return rating;
        }

        public int NextId()
        {
            _accratings = _serializer.FromCSV(FilePath);
            if (_accratings.Count < 1)
            {
                return 1;
            }
            return _accratings.Max(t => t.Id) + 1;
        }

        public AccommodationRating GetById(int id)
        {
            _accratings = GetAll();
            foreach (AccommodationRating rating in _accratings)
            {
                if (rating.Id == id)
                {
                    return rating;
                }
            }
            return null;
        }

        public AccommodationRating Update(AccommodationRating rating)
        {
            _accratings = _serializer.FromCSV(FilePath);
            AccommodationRating current = _accratings.Find(c => c.Id == rating.Id);
            int index = _accratings.IndexOf(current);
            _accratings.Remove(current);
            _accratings.Insert(index, rating);
            _serializer.ToCSV(FilePath, _accratings);
            return rating;
        }

        public bool ExistsRateForReservation(int reservationId)
        {
            foreach(AccommodationRating rating in _accratings)
            {
                if(rating.AccommodationReservation.Id == reservationId)
                {
                    return true;
                }
            }
            return false;
        }

    }
}

