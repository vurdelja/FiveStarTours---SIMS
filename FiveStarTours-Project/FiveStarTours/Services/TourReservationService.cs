using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiveStarTours.Interfaces;
using FiveStarTours.Model;
using FiveStarTours.Repository;

namespace FiveStarTours.Services
{
    public class TourReservationService
    {
        private IAccomodationRatingRepository _tourReservationRepository;
        public TourReservationService()
        {
            _tourReservationRepository = Injector.Injector.CreateInstance<IAccomodationRatingRepository>();
        }

        public List<TourReservation> GetAll()
        {
            return _tourReservationRepository.GetAll();
        }

        public TourReservation Save(TourReservation tourReservation)
        {
            return _tourReservationRepository.Save(tourReservation);
        }

        public int NextId()
        {
            return _tourReservationRepository.NextId();
        }

        public int ReservedSeats(Tour tour)
        {
            return _tourReservationRepository.ReservedSeats(tour);
        }

        public List<string> GetAllVisitors(Tour tour)
        {
            return _tourReservationRepository.GetAllVisitors(tour);
        }

        public void DeleteById(Tour tour)
        {
            _tourReservationRepository.DeleteById(tour);
        }

        public void Delete(TourReservation tourReservation)
        {
            _tourReservationRepository.Delete(tourReservation);
        }

        public int GetWithGiftCard(int id, AttendanceRepository attendanceRepository, UserRepository userRepository)
        {
            return _tourReservationRepository.GetWithGiftCard(id, attendanceRepository, userRepository);
        }
    }
}
