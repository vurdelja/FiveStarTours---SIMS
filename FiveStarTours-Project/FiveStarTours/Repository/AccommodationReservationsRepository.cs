using FiveStarTours.Model;
using FiveStarTours.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

        public int CountUnrated()
        {
            int unrated = 0;
            _reservations = GetUnratedAndLessThanFiveDaysAgo();

            foreach (AccommodationReservation accommodationReservation in _reservations)
            {
                if (accommodationReservation.Rated == false)
                {
                    unrated++;
                }
            }
            return unrated;

        }

        public void NotifyAboutUnratedGuests()
        {
            _reservations = GetAll();
            int unrated = CountUnrated();
            if(unrated > 0)
            {
                MessageBox.Show("You have " + unrated + " forms that are waiting to be filled. Please fill them before they become unavailable!");
            }
            else
            {
                return;
            }
            
        }

        public bool DatesIntertwine(DateTime startAcc, DateTime endAcc, DateTime start, DateTime end)
        {
            bool isInInterval = false;
            if (start.Date <= endAcc.Date && end.Date >= startAcc.Date)
            {
                return true;
            }

            return isInInterval;
        }
     

        public List<AccommodationReservation> GetAllReservationsForAccommodationDateInterval(string accomodationName, DateTime start, DateTime end)
        {
             List<AccommodationReservation> accommodationReservations = new List<AccommodationReservation>();
            foreach (AccommodationReservation accommodationReservation in _reservations)
            {
                if (accomodationName == accommodationReservation.AccommodationName && DatesIntertwine(accommodationReservation.StartDate, accommodationReservation.EndDate, start, end) )
                {
                    accommodationReservations.Add(accommodationReservation);
                  
                }
                
            }
             return accommodationReservations;
        }

        public List<DateInterval> GetFreeDateIntervals(string accommodationName, DateTime start, DateTime end, int numberOfDays)
        {



            return null;
        }



    }
}
