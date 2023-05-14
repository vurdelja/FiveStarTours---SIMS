using FiveStarTours.Repository;
using FiveStarTours.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FiveStarTours.View.Driver
{
    /// <summary>
    /// Interaction logic for SuperDriver.xaml
    /// </summary>
    public partial class SuperDriver : Window
    {
        private readonly VehicleRepository _vehicleRepository;
        private readonly UserService _userService;
        public int NumberOfFastDrives { get; set; }
        public Model.User LoggedInUser { get; set; }
        public bool IsSuperOwner { get; set; }

        public SuperDriver(Model.User user)
        {
            InitializeComponent();
            DataContext = this;

            _userService = new UserService();
            _vehicleRepository = new VehicleRepository();

            LoggedInUser = user;

            NumberOfFastDrives = _vehicleRepository.CountFastDrive();


            if (_vehicleRepository.CountFastDrive() > 15)
            {
                LoggedInUser.Super = true;
                _userService.Update(LoggedInUser);

            }
            else
            {
                LoggedInUser.Super = false;
                _userService.Update(LoggedInUser);
            }

            if (LoggedInUser.Super == true)
            {
                IsSuperOwner = true;
            }
            else
            {
                IsSuperOwner = false;
            }

            return;
            
        }
    }
}
