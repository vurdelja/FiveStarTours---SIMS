using FiveStarTours.Exceptions;
using FiveStarTours.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FiveStarTours
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //testiranje da li registracija smestaja radi -Nina

        /*protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                Owner owner = new Owner(7);

                owner.RegistrateAccommodation(new Accommodation(
                    3, 7, "Kucica", 8, AccommodationType.cottage
                    , 9, 3, 2));

                owner.RegistrateAccommodation(new Accommodation(
                    3, 7, "Kucica", 8, AccommodationType.cottage
                    , 9, 3, 2));

                IEnumerable<Accommodation> accommondations = owner.GetAccommodationsForOwner(7);


                base.OnStartup(e);
            }
            catch(AccommodationConflictException ex)
            {

            }
        } */




    }
}
