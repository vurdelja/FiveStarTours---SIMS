using FiveStarTours.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FiveStarTours.Model;
using FiveStarTours.Repository;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FiveStarTours.View.Owner
{
    /// <summary>
    /// Interaction logic for Statistics.xaml
    /// </summary>
    public partial class StatisticsView : Window
    {
        public User LoggedInUser { get; set; }

        public StatisticsView(User user)
        {
            InitializeComponent();
            DataContext = this;

            LoggedInUser = user;
        }

        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {
            
            StatisticsYearView yearView = new StatisticsYearView(LoggedInUser);
            yearView.Show();
            Close();
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            ActionBarView action = new ActionBarView(LoggedInUser);
            action.Show();
            Close();
        }
    }
}
