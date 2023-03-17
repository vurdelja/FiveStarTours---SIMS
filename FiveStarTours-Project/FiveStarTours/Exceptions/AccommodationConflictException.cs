using FiveStarTours.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FiveStarTours.Exceptions
{
    public class AccommodationConflictException : Exception
    {
        public Accommodation ExistingAccommodation { get; set; }
        public Accommodation NewAccommodation { get; set; }
        public AccommodationConflictException(Accommodation existingAccommodation, Accommodation newAccommodation)
        {
            ExistingAccommodation = existingAccommodation;
            NewAccommodation = newAccommodation;
        }

        public AccommodationConflictException(string? message, Accommodation existingAccommodation, Accommodation newAccommodation) : base(message)
        {
            ExistingAccommodation = existingAccommodation;
            NewAccommodation = newAccommodation;
        }

        public AccommodationConflictException(string? message, Exception? innerException, Accommodation existingAccommodation, Accommodation newAccommodation) : base(message, innerException)
        { 
            ExistingAccommodation = existingAccommodation;
            NewAccommodation = newAccommodation;
        }

        protected AccommodationConflictException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }


    }
}
