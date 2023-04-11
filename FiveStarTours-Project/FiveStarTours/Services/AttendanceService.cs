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
    public class AttendanceService
    {
        private IAttendanceRepository _attendanceRepository;

        public AttendanceService()
        {
            _attendanceRepository = Injector.Injector.CreateInstance<IAttendanceRepository>();
        }
        public List<Attendance> GetAll()
        {
            return _attendanceRepository.GetAll();
        }

        public Attendance Save(Attendance attendance)
        {
            return _attendanceRepository.Save(attendance);
        }

        public int NextId()
        {
            return _attendanceRepository.NextId();
        }

        public int GetAllLower(int id, UserRepository userRepository)
        {
            return _attendanceRepository.GetAllLower(id, userRepository);
        }

        public int GetAllBetween(int id, UserRepository userRepository)
        {
            return _attendanceRepository.GetAllBetween(id, userRepository);
        }

        public int GetAllAbove(int id, UserRepository userRepository)
        {
            return _attendanceRepository.GetAllAbove(id, userRepository);
        }

        public int GetAllById(int id, UserRepository userRepository)
        {
            return _attendanceRepository.GetAllById(id, userRepository);
        }

        public int GetMostVisitedTour(List<Tour> tours)
        {
            return _attendanceRepository.GetMostVisitedTour(tours);
        }

        public List<Attendance> GetAllByTours(List<Tour> tours)
        {
            return _attendanceRepository.GetAllByTours(tours);
        }

        public string GetMostVisitedByYear(DateTime date, ToursRepository toursRepository)
        {
            return _attendanceRepository.GetMostVisitedByYear(date, toursRepository);
        }
        public List<int> GetVisitedTours(int id)
        {
            return _attendanceRepository.GetVisitedTours(id);
        }
    }
}
