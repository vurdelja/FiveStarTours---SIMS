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
        List<Renovation> GetAll();
        Renovation Save(Renovation renovation);

        int NextId();
        Renovation GetById(int id);
        void Delete(Renovation renovation);
        Renovation Update(Renovation renovation);
        bool DatesIntertwine(DateTime startAcc, DateTime endAcc, DateTime start, DateTime end);
        List<Renovation> GetAllReservationsForAccommodationDateInterval(string accomodationName, DateTime start, DateTime end);
        bool DoesInterwalIntertwineWithReservations(List<Renovation> reservations, DateTime start, DateTime end);
        List<DateInterval> GetFreeDateIntervals(string accommodationName, DateTime start, DateTime end, int numberOfDays);
        bool IsAbleToCancel(int renovationId);
        void CancelRenovation(Renovation renovation);


    }
}
