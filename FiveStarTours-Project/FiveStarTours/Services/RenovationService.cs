using FiveStarTours.Interfaces;
using FiveStarTours.Model;
using FiveStarTours.Repository;
using FiveStarTours.Serializer;
using FiveStarTours.View.Traveler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveStarTours.Services
{
    public class RenovationService
    {
        private IRenovationRepository _renovationRepository;

        public RenovationService()
        {
            _renovationRepository = Injector.Injector.CreateInstance<IRenovationRepository>();
        }

        public List<Renovations> GetAll()
        {
            return _renovationRepository.GetAll();
        }

        public Renovations Save(Renovations renovation)
        {
            return _renovationRepository.Save(renovation);
        }


        public int NextId()
        {
            return NextId();
        }

        public Renovations GetById(int id)
        {
            return _renovationRepository.GetById(id);
        }
        public void Delete(Renovations renovation)
        {
            _renovationRepository.Delete(renovation);
        }

        public Renovations Update(Renovations renovations)
        {
            return _renovationRepository.Update(renovations);
        }

        public bool DatesIntertwine(DateTime startAcc, DateTime endAcc, DateTime start, DateTime end)
        {
            return _renovationRepository.DatesIntertwine(startAcc, endAcc, start, end);
        }

        public void SetToFalse(Renovations renovation)
        {
            _renovationRepository.SetToFalse(renovation);
        }


        public List<Renovations> GetAllReservationsForAccommodationDateInterval(string accomodationName, DateTime start, DateTime end)
        {
            return _renovationRepository.GetAllReservationsForAccommodationDateInterval(accomodationName, start, end);
        }

        public bool DoesInterwalIntertwineWithReservations(List<Renovations> renovations, DateTime start, DateTime end)
        {
            return _renovationRepository.DoesInterwalIntertwineWithReservations(renovations, start, end);
        }



        public List<DateInterval> GetFreeDateIntervals(string accommodationName, DateTime start, DateTime end, int numberOfDays)
        {
            return _renovationRepository.GetFreeDateIntervals(accommodationName, start, end, numberOfDays);
        }

        public bool IsAbleToCancel(int renovationId)
        {
            return _renovationRepository.IsAbleToCancel(renovationId);
        }

        public void CancelRenovation(Renovations renovation)
        {
            _renovationRepository.CancelRenovation(renovation);
        }



    }

}
