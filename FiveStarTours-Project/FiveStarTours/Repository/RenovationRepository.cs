using FiveStarTours.Interfaces;
using FiveStarTours.Model;
using FiveStarTours.Serializer;
using FiveStarTours.View.Traveler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FiveStarTours.Repository
{
    public class RenovationRepository : IRenovationRepository
    {
        private const string FilePath = "../../../Resources/Data/renovations.csv";

        private readonly Serializer<Renovation> _serializer;

        private List<Renovation> renovations;

        private AccommodationReservationsRepository _reservationsRepository;

        private AccommodationsRepository _accommodationsRepository;

        private CancelationNotificationRepository _cancelationNotificationRepository;

        private UserRepository _userRepository;

        public RenovationRepository()
        {
            _serializer = new Serializer<Renovation>();

            renovations = _serializer.FromCSV(FilePath);

            _reservationsRepository = new AccommodationReservationsRepository();

            _accommodationsRepository = new AccommodationsRepository();

            _cancelationNotificationRepository = new CancelationNotificationRepository();

            _userRepository = new UserRepository();
        }

        public List<Renovation> GetAll()
        {
            return _serializer.FromCSV(FilePath);
        }

        public Renovation Save(Renovation renovation)
        {
            renovation.Id = NextId();
            renovations = _serializer.FromCSV(FilePath);
            renovations.Add(renovation);
            _serializer.ToCSV(FilePath, renovations);
            return renovation;
        }

        public int NextId()
        {
            renovations = _serializer.FromCSV(FilePath);
            if (renovations.Count < 1)
            {
                return 1;
            }
            return renovations.Max(t => t.Id) + 1;
        }


        public Renovation GetById(int id)
        {
            renovations = GetAll();
            foreach (Renovation renovation in renovations)
            {
                if (renovation.Id == id)
                {
                    return renovation;
                }
            }
            return null;
        }
        public void Delete(Renovation renovation)
        {
            renovations = _serializer.FromCSV(FilePath);
            Renovation found = renovations.Find(c => c.Id == renovation.Id);
            renovations.Remove(found);
            _serializer.ToCSV(FilePath, renovations);
        }

        public Renovation Update(Renovation renovation)
        {
            renovations = _serializer.FromCSV(FilePath);
            Renovation current = renovations.Find(c => c.Id == renovation.Id);
            int index = renovations.IndexOf(current);
            renovations.Remove(current);
            renovations.Insert(index, renovation);
            _serializer.ToCSV(FilePath, renovations);
            return renovation;
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


        public List<Renovation> GetAllReservationsForAccommodationDateInterval(string accomodationName, DateTime start, DateTime end)
        {
            List<Renovation> renovations = new List<Renovation>();
            foreach (Renovation renovation in renovations)
            {
                if (accomodationName == renovation.Accommodation.AccommodationName && DatesIntertwine(renovation.StartDate, renovation.EndDate, start, end))
                {
                    renovations.Add(renovation);

                }

            }
            return renovations;
        }

        public bool DoesInterwalIntertwineWithReservations(List<Renovation> renovations, DateTime start, DateTime end)
        {
            foreach (Renovation renovation in renovations)
            {
                if (DatesIntertwine(renovation.StartDate, renovation.EndDate, start, end))
                {
                    return true;
                }
            }

            return false;
        }



        public List<DateInterval> GetFreeDateIntervals(string accommodationName, DateTime start, DateTime end, int numberOfDays)
        {
            DateTime iterDate = start;
            List<Renovation> reservations = GetAllReservationsForAccommodationDateInterval(accommodationName, start, end);
            List<DateInterval> freeIntervals = new List<DateInterval>();

            while (iterDate.AddDays(numberOfDays).Date <= end.Date)
            {
                if (!DoesInterwalIntertwineWithReservations(reservations, iterDate, iterDate.AddDays(numberOfDays)))
                {
                    freeIntervals.Add(new DateInterval(iterDate, iterDate.AddDays(numberOfDays)));
                }

                iterDate = iterDate.AddDays(1);
            }


            return freeIntervals;
        }


        public bool IsAbleToCancel(int renovationId)
        {
            Renovation renovation = GetById(renovationId);
            DateTime now = DateTime.Now;
            Accommodation accommodation = _accommodationsRepository.GetAccommodationForAccommodationName(renovation.Accommodation.AccommodationName);
            if (renovation.StartDate > now.AddDays(5))
            {
                return true;
            }

            return false;
        }

        public void CancelRenovation(Renovation renovation)
        {
            int ownerId = 2;
            User guest = _userRepository.GetByNameSurname(renovation.User.Name);
            User owner = _userRepository.GetById(ownerId);
            CancelationNotification cancelationNotification = new CancelationNotification(-1, owner, guest, false);
            _cancelationNotificationRepository.Save(cancelationNotification);
        }


    }
}