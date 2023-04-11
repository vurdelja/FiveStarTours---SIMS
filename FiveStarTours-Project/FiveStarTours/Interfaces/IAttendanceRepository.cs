using FiveStarTours.Model;
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
    }
}
