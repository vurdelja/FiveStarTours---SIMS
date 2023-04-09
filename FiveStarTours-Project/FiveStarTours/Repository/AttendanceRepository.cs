using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
