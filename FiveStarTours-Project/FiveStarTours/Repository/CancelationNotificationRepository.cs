using FiveStarTours.Model;
using FiveStarTours.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FiveStarTours.Repository
{
    public class CancelationNotificationRepository
    {
        private const string FilePath = "../../../Resources/Data/cancelationNotification.csv";

        private readonly Serializer<CancelationNotification> _serializer;
        private List<CancelationNotification> _cancelations;
        private List<AccommodationReservation> _reservations;



        public CancelationNotificationRepository()
        {
            _serializer = new Serializer<CancelationNotification>();
            _cancelations = _serializer.FromCSV(FilePath);
        }

        public List<CancelationNotification> GetAll()
        {
            return _serializer.FromCSV(FilePath);
        }
        public CancelationNotification Update(CancelationNotification cancelation)
        {
            _cancelations = _serializer.FromCSV(FilePath);
            CancelationNotification current = _cancelations.Find(c => c.Id == cancelation.Id);
            int index = _cancelations.IndexOf(current);
            _cancelations.Remove(current);
            _cancelations.Insert(index, cancelation);
            _serializer.ToCSV(FilePath, _cancelations);
            return cancelation;
        }
        public int CountChanges()
        {
            int canceled = 0;
            // _cancelations =  GetCancellationLessThan24HoursAndOtherRestriction()

            foreach (CancelationNotification cancelation in _cancelations)
            {
                if (cancelation.Delivered== false)
                {
                    canceled++;
                }
            }
            return canceled;

        }
      
        public void NotifyAboutChanges()
        {
            _cancelations = GetAll();
            int canceled = CountChanges();
            if (canceled > 0)
            {
                MessageBox.Show("You have " + canceled + "reservation that are changed. Please look them up and set their status!");
            }
            else
            {
                return;
            }

        }


    }
}
