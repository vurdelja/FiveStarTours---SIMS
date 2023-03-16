using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using FiveStarTours.Model;

namespace FiveStarTours.ViewModel
{
    public class AddAccommodationViewModel : ViewModelBase
    {
        //Accommodation name
        private string _accommodationName;
        public string AccommodationName
        {
            get
            {
                return _accommodationName;
            }
            set
            {
                _accommodationName = value;
                OnPropertyChanged(nameof(Accommodation.Name));
            }
        }

        //Accommodation type
        private IEnumerable<AccommodationType> _AccommodationTypes;
        private string _SelectedAccommodationType;
        private ICommand _ShowAccommodationTypeCommand;

        public IEnumerable<AccommodationType> AccommodationTypes
        {
            get
            {
                return (AccommodationType[])Enum.GetValues(typeof(AccommodationType));
            }
            set
            {
                if (value != _AccommodationTypes)
                {
                    _AccommodationTypes = value;
                    OnPropertyChanged("_AccommodationTypes");
                }
            }
        }
        public string SelectedAccommodationType
        {
            get { return _SelectedAccommodationType; }
            set
            {
                _SelectedAccommodationType = value;
                OnPropertyChanged("SelectedAccommodationType");
            }
        }
        public ICommand ShowAccommodationTypeCommand
        {
            get
            {
                _ShowAccommodationTypeCommand = new RelayCommand(
                    param => ShowAccommodationTypeMethod()
                );
                return _ShowAccommodationTypeCommand;
            }
        }

        private void ShowAccommodationTypeMethod()
        {
            MessageBox.Show(SelectedAccommodationType);
        }


        //Accommodation Location
        private List<Country> _CountryList;
        private string _SelectedCountryCode;
        private List<City> _CityList;
        private string _SelectedCity;

        public List<Country> CountryList
        {
            get { return _CountryList; }
            set
            {
                _CountryList = value;
                OnPropertyChanged("CountryList");
            }
        }
        public string SelectedCountryCode
        {
            get { return _SelectedCountryCode; }
            set
            {
                _SelectedCountryCode = value;
                OnPropertyChanged("SelectedCountryCode");
                OnPropertyChanged("AllowCitySelection");
                getCityList();
            }
        }
        public List<City> CityList
        {
            get { return _CityList; }
            set
            {
                _CityList = value;
                OnPropertyChanged("CityList");
            }
        }
        public string SelectedCity
        {
            get { return _SelectedCity; }
            set
            {
                _SelectedCity = value;
                OnPropertyChanged("SelectedCity");
            }
        }
        public bool AllowCitySelection
        {
            get { return (SelectedCountryCode != null); }
        }

        public AddAccommodationViewModel()
        {
            Country _Country = new Country();
            CountryList = _Country.getCountries();
        }

        private void getCityList()
        {
            City _City = new City();
            CityList = _City.getCityByCountryCode(SelectedCountryCode);
        }

        //Accommodation max guest number
        private int _maxGuestNum;
        public int MaxGuestNum
        {
            get
            {
                return _maxGuestNum; 
            }
            set
            {
                _maxGuestNum = value;
                OnPropertyChanged(nameof(Accommodation.MaxGuestNum));
            }
        }

        //Submit and Cancel
        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

    }
}
