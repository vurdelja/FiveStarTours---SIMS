using FiveStarTours.Exceptions;
using FiveStarTours.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveStarTours.Model
{
    public class AccommodationBook
    {

        private readonly List<Accommodation> accommodations;

        public AccommodationBook()
        {
            accommodations = new List<Accommodation>();
        }

        public IEnumerable<Accommodation> GetAccommodationsForOwner(int id)
        {
            return accommodations.Where(a => a.IdOwner == id);
        }

        public void AddAccomodation(Accommodation accommodation)
        {
            foreach(Accommodation existingAccommodation in accommodations)
            {
                if (existingAccommodation.Conflicts(accommodation)){
                    throw new AccommodationConflictException(existingAccommodation, accommodation);
                }
            }

            accommodations.Add(accommodation);
        }

    }
}
