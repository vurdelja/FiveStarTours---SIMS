using System.Collections.Generic;
using System.Linq;
using FiveStarTours.Model;
using FiveStarTours.Serializer;

namespace FiveStarTours.Repository
{
    public class AttendanceRepository
    {
        private const string FilePath = "../../../Resources/Data/attendance.csv";

        private readonly Serializer<Attendance> _serializer;

        private List<Attendance> _attendances;

        public AttendanceRepository()
        {
            _serializer = new Serializer<Attendance>();
            _attendances = _serializer.FromCSV(FilePath);
        }

        public List<Attendance> GetAll()
        {
            return _serializer.FromCSV(FilePath);
        }

        public Attendance Save(Attendance attendance)
        {
            attendance.Id = NextId();
            _attendances = _serializer.FromCSV(FilePath);
            _attendances.Add(attendance);
            _serializer.ToCSV(FilePath, _attendances);
            return attendance;
        }

        public int NextId()
        {
            _attendances = _serializer.FromCSV(FilePath);
            if (_attendances.Count < 1)
            {
                return 1;
            }
            return _attendances.Max(a => a.Id) + 1;
        }

        public int GetAllLower(int id, UserRepository userRepository)
        {
            int result = 0;
            List<Attendance> Attendances = new List<Attendance>();
            foreach (var attendance in GetAll())
            {
                if (attendance.IdTour == id)
                {
                    Attendances.Add(attendance);
                }
            }
            List<User> visitors = new List<User>();
            foreach (var attendance in Attendances)
            {
                visitors.Add(userRepository.GetById(attendance.IdVisitor));
            }

            foreach (var visitor in visitors)
            {
                if (visitor.Age < 18)
                {
                    result = result + 1;
                }
            }

            return result;
        }

        public int GetAllBetween(int id, UserRepository userRepository)
        {
            int result = 0;
            List<Attendance> Attendances = new List<Attendance>();
            foreach (var attendance in GetAll())
            {
                if (attendance.IdTour == id)
                {
                    Attendances.Add(attendance);
                }
            }
            List<User> visitors = new List<User>();
            foreach (var attendance in Attendances)
            {
                visitors.Add(userRepository.GetById(attendance.IdVisitor));
            }

            foreach (var visitor in visitors)
            {
                if (visitor.Age >= 18 && visitor.Age < 50)
                {
                    result = result + 1;
                }
            }

            return result;
        }

        public int GetAllAbove(int id, UserRepository userRepository)
        {
            int result = 0;
            List<Attendance> Attendances = new List<Attendance>();
            foreach (var attendance in GetAll())
            {
                if (attendance.IdTour == id)
                {
                    Attendances.Add(attendance);
                }
            }
            List<User> visitors = new List<User>();
            foreach (var attendance in Attendances)
            {
                visitors.Add(userRepository.GetById(attendance.IdVisitor));
            }

            foreach (var visitor in visitors)
            {
                if (visitor.Age >= 50)
                {
                    result = result + 1;
                }
            }

            return result;
        }

        public int GetAllById(int id, UserRepository userRepository)
        {
            int result = 0;
            List<Attendance> Attendances = new List<Attendance>();
            foreach (var attendance in GetAll())
            {
                if (attendance.IdTour == id)
                {
                    Attendances.Add(attendance);
                }
            }
            List<User> visitors = new List<User>();
            foreach (var attendance in Attendances)
            {
                visitors.Add(userRepository.GetById(attendance.IdVisitor));
            }

            foreach (var visitor in visitors)
            {

                result = result + 1;

            }

            return result;
        }
    }
}
