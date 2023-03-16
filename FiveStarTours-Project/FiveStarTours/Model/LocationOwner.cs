using FiveStarTours.ViewModel;
using System;
using System.Collections.Generic;

namespace FiveStarTours.Model
{
    public class LocationOwner
    {
    }


    public class Country
    {
        public string CountryName { get; set; }
        public string CountryThreeLetterCode { get; set; }

        public List<Country> getCountries()
        {
            List<Country> returnCountries = new List<Country>();
            returnCountries.Add(new Country() { CountryName = "Serbia", CountryThreeLetterCode = "SRB" });
            returnCountries.Add(new Country() { CountryName = "Bulgaria", CountryThreeLetterCode = "BLG" });
            returnCountries.Add(new Country() { CountryName = "Hungary", CountryThreeLetterCode = "HUN" });
            return returnCountries;
        }
    }



    public class City
    {
        public string CountryThreeLetterCode { get; set; }
        public string CityName { get; set; }

        public List<City> getCitiesCollection()
        {
            List<City> returnCities = new List<City>();
            returnCities.Add(new City() { CountryThreeLetterCode = "SRB", CityName = "Beograd" });
            returnCities.Add(new City() { CountryThreeLetterCode = "SRB", CityName = "Novi Sad" });
            returnCities.Add(new City() { CountryThreeLetterCode = "SRB", CityName = "Krusevac" });
            returnCities.Add(new City() { CountryThreeLetterCode = "BLG", CityName = "Sofia" });
            returnCities.Add(new City() { CountryThreeLetterCode = "BLG", CityName = "Plovdiv" });
            returnCities.Add(new City() { CountryThreeLetterCode = "HUN", CityName = "Szeged" });
            returnCities.Add(new City() { CountryThreeLetterCode = "HUN", CityName = "Budapest" });
            return returnCities;
        }


        public List<City> getCityByCountryCode(string countryCode)
        {
            List<City> cityList = new List<City>();
            foreach (City currentCity in getCitiesCollection())
            {
                if (currentCity.CountryThreeLetterCode == countryCode)
                {
                    cityList.Add(new City() { CountryThreeLetterCode = currentCity.CountryThreeLetterCode, CityName = currentCity.CityName });
                }
            }
            return cityList;
        }
    }
}