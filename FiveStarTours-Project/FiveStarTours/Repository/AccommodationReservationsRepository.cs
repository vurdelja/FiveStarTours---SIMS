using FiveStarTours.Model;
using FiveStarTours.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveStarTours.Repository
{
    public class AccommodationReservationsRepository
    {
        private const string FilePath = "../../../Resources/Data/accommondationReservations.csv";

        private readonly Serializer<AccommodationReservation> _serializer;

        private List<AccommodationReservation> _reservations;

        public AccommodationReservationsRepository()
        {
            _serializer = new Serializer<AccommodationReservation>();
            _reservations = _serializer.FromCSV(FilePath);
        }

        public List<AccommodationReservation> GetAll()
        {
            return _serializer.FromCSV(FilePath);
        }

        public AccommodationReservation Save(AccommodationReservation reservation)
        {
            reservation.Id = NextId();
            _reservations = _serializer.FromCSV(FilePath);
            _reservations.Add(reservation);
            _serializer.ToCSV(FilePath, _reservations);
            return reservation;
        }

        public List<AccommodationReservation> Load()
        {
            return _serializer.FromCSV(FilePath);
        }

        public int NextId()
        {
            _reservations = _serializer.FromCSV(FilePath);
            if (_reservations.Count < 1)
            {
                return 1;
            }
            return _reservations.Max(t => t.Id) + 1;
        }

        public AccommodationReservation GetById(int id)
        {
            _reservations = GetAll();
            foreach (AccommodationReservation accommodationReservation in _reservations)
            {
                if (accommodationReservation.Id == id)
                {
                    return accommodationReservation;
                }
            }
            return null;
        }

        public AccommodationReservation Update(AccommodationReservation reservation)
        {
            _reservations = _serializer.FromCSV(FilePath);
            AccommodationReservation current = _reservations.Find(c => c.Id == reservation.Id);
            int index = _reservations.IndexOf(current);
            _reservations.Remove(current);
            _reservations.Insert(index, reservation);
            _serializer.ToCSV(FilePath, _reservations);
            return reservation;
        }

        public List<AccommodationReservation> GetUnratedAndLessThanFiveDaysAgo()
        {
            List<AccommodationReservation> reservations = new List<AccommodationReservation>();
            DateTime now = DateTime.Now;
            foreach (AccommodationReservation accommodationReservation in _reservations)
            {
                DateTime end = accommodationReservation.EndDate;
                if(end<now)
                {
                    if (accommodationReservation.Rated == false && now.AddDays(-5) < end)
                    {
                        reservations.Add(accommodationReservation);

                    }
                }
            }
            return reservations;
 
        }

        

    }
}
