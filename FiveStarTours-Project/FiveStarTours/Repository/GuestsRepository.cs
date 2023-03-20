using FiveStarTours.Model;
using FiveStarTours.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveStarTours.Repository
{
    public class GuestsRepository
    {
        private const string FilePath = "../../../Resources/Data/guest.csv";

        private readonly Serializer<Guest> _serializerGuest;

        private List<Guest> _guests;

        public GuestsRepository()
        {
            _serializerGuest = new Serializer<Guest>();
            _guests = _serializerGuest.FromCSV(FilePath);
        }

        public List<Guest> GetAll()
        {
            return _serializerGuest.FromCSV(FilePath);
        }

        public Guest Save(Guest guest)
        {
            guest.Id = NextId();
            _guests = _serializerGuest.FromCSV(FilePath);
            _guests.Add(guest);
            _serializerGuest.ToCSV(FilePath, _guests);
            return guest;
        }

        public int NextId()
        {
            _guests = _serializerGuest.FromCSV(FilePath);
            if (_guests.Count < 1)
            {
                return 1;
            }
            return _guests.Max(t => t.Id) + 1;
        }

        public Guest GetById(int id)
        {
            _guests = GetAll();
            foreach (Guest guest in _guests)
            {
                if (guest.Id == id)
                {
                    return guest;
                }
            }
            return null;
        }
    }
}

