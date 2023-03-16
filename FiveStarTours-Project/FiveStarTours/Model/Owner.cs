using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveStarTours.Model
{
    public class Owner
    {
        private readonly AccommodationBook accommodationBook;

        public int Id { get; set; }

        public Owner(int id)
        {
            Id = id;
            accommodationBook = new AccommodationBook();
        }

        public IEnumerable<Accommodation> GetAccommodationsForOwner(int id)
        {
            return accommodationBook.GetAccommodationsForOwner(id);
        }

        public void RegistrateAccommodation(Accommodation accommodation)
        {
            accommodationBook.AddAccomodation(accommodation);
        }
    }
}
