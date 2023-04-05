using FiveStarTours.Model;
using FiveStarTours.Repository;
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

namespace FiveStarTours.View.Visitor
{
    /// <summary>
    /// Interaction logic for GiftCardsListingView.xaml
    /// </summary>
    public partial class GiftCardsListingView : Window
    {
        public static ObservableCollection<GiftCard> GiftCards { get; set; }
        public GiftCard SelectedGiftCard { get; set; }
        private readonly GiftCardRepository _repository;

        public GiftCardsListingView()
        {
            InitializeComponent();
            DataContext = this;
            _repository = new GiftCardRepository();
            //GiftCards = new ObservableCollection<GiftCard>(_repository.GetAllById(UserId));
        }

        private void ChoseGiftCard(object sender, RoutedEventArgs e)
        {
            /*if (SelectedGiftCard != null)
            {
                ReservationView reservationView = new ReservationView(SelectedGiftCard);
                reservationView.Show();

            }*/
        }
    }
}
