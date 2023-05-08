using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using FiveStarTours.Interfaces;
using FiveStarTours.Model;
using FiveStarTours.Repository;
using FiveStarTours.Services;
using FiveStarTours.View;
using FiveStarTours.ViewModel;
using static System.Net.Mime.MediaTypeNames;
using Application = System.Windows.Application;

namespace FiveStarTours.View.Visitor
{
    /// <summary>
    /// Interaction logic for ToursListingView.xaml
    /// </summary>
    /// 

    public partial class ToursListingView : Window
    {
        TourListingViewModel viewModel;
        public ToursListingView(User user)
        {
            
            InitializeComponent();
            viewModel = new TourListingViewModel(user);
            DataContext = viewModel;
           

        }

    }
}
