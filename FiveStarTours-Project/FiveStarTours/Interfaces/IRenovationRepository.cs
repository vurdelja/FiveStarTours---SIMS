using FiveStarTours.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveStarTours.Interfaces
{
    public interface IRenovationRepository
    {
        List<Renovations> GetAll();
        Renovations Save(Renovations renovation);

        int NextId();
        Renovations GetById(int id);
        void Delete(Renovations renovation);
        Renovations Update(Renovations renovation);
        bool DatesIntertwine(DateTime startAcc, DateTime endAcc, DateTime start, DateTime end);
        List<Renovations> GetAllReservationsForAccommodationDateInterval(string accomodationName, DateTime start, DateTime end);
        bool DoesInterwalIntertwineWithReservations(List<Renovations> reservations, DateTime start, DateTime end);
        List<DateInterval> GetFreeDateIntervals(string accommodationName, DateTime start, DateTime end, int numberOfDays);
        bool IsAbleToCancel(int renovationId);
        void CancelRenovation(Renovations renovation);
        public void SetToFalse(Renovations renovation);


    }
}
