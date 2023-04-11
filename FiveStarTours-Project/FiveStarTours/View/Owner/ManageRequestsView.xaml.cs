using FiveStarTours.Model;
using FiveStarTours.Repository;
using FiveStarTours.View.Traveler;
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

namespace FiveStarTours.View.Owner
{
    /// <summary>
    /// Interaction logic for ManageRequestsView.xaml
    /// </summary>
    public partial class ManageRequestsView : Window
    {
        public static ObservableCollection<ReservationChange> Requests { get; set; }

        public ReservationChange SelectedRequest { get; set; }   //SELEKTOVANA
        private readonly ReservationChangeRepository _repository;

        
        public ManageRequestsView()
        {
            InitializeComponent();
            DataContext = this;

            _repository = new ReservationChangeRepository();
            Requests = new ObservableCollection<ReservationChange>(_repository.GetAll());
        }

        private void ViewReviewButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedRequest != null)
            {
                RejectedRequestView rejected = new RejectedRequestView(SelectedRequest);
                rejected.Show();
                Close();
            }
            else
            {
                MessageBox.Show("You must select the request.");
            }


        }

        private void MaybeLaterButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        
    }
}
