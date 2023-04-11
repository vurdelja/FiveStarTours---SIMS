using FiveStarTours.Model;
using FiveStarTours.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveStarTours.Interfaces
{
    public interface IAttendanceRepository
    {
        public List<Attendance> GetAll();
        public Attendance Save(Attendance attendance);
        public int NextId();
        public int GetAllLower(int id, UserRepository userRepository);
        public int GetAllBetween(int id, UserRepository userRepository);
        public int GetAllAbove(int id, UserRepository userRepository);
        public int GetAllById(int id, UserRepository userRepository);
        public int GetMostVisitedTour(List<Tour> tours);
        public List<Attendance> GetAllByTours(List<Tour> tours);
        public string GetMostVisitedByYear(DateTime date, ToursRepository toursRepository);
        public List<int> GetVisitedTours(int id);
    }
}
