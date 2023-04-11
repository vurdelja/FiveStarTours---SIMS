using FiveStarTours.Model;
using FiveStarTours.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveStarTours.Interfaces
{
    public interface IAccomodationRatingRepository
    {
        List<TourReservation> GetAll();
        TourReservation Save(TourReservation tourReservation);
        int NextId();
        int ReservedSeats(Tour tour);
        List<string> GetAllVisitors(Tour tour);
        void DeleteById(Tour tour);
        void Delete(TourReservation tourReservation);
        public int GetWithGiftCard(int id, AttendanceRepository attendanceRepository, UserRepository userRepository);
    }
}
