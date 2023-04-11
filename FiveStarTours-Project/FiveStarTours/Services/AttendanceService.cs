using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiveStarTours.Interfaces;
using FiveStarTours.Model;

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
    }
}
