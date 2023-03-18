using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Xml.Linq;
using FiveStarTours.Model;
using FiveStarTours.Repository;

namespace FiveStarTours.View
{
    /// <summary>
    /// Interaction logic for ToursListingView.xaml
    /// </summary>
    /// 

    public partial class ToursListingView : Window
    { 
        public static ObservableCollection<Tour> Tours { get; set; }
        public Tour SelectedTour{ get; set; }
        //private readonly TourRepository _repository;



        public ToursListingView()
        {
            InitializeComponent();
            DataContext = this;

            //_repository = new TourRepository();


        }

        private void TourSearchClick_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
