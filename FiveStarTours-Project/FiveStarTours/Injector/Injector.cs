﻿using FiveStarTours.Interfaces;
using FiveStarTours.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveStarTours.Injector
{
    public class Injector
    {
        private static Dictionary<Type, object> _implementations = new Dictionary<Type, object>
        {
        { typeof(IAccommodationReservationRepository), new AccommodationReservationsRepository() },
        { typeof(IAccommodationRatingRepository), new AccommodationRatingRepository() },
        { typeof(IAccommodationsRepository), new AccommodationsRepository() },
        
        // Add more implementations here
    };

        public static T CreateInstance<T>()
        {
            Type type = typeof(T);

            if (_implementations.ContainsKey(type))
            {
                return (T)_implementations[type];
            }

            throw new ArgumentException($"No implementation found for type {type}");
        }
    }
}
