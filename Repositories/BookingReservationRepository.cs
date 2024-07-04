using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BookingReservationRepository : IBookingReservationRepository
    {
        public BookingReservation AddReservation(BookingReservation reservation)
        {
            return BookingReservationDAO.Instance.AddReservation(reservation);
        }

        public void DeleteReservation(int reservationId)
        {
            BookingReservationDAO.Instance.DeleteReservation(reservationId);
        }

        public List<BookingReservation> GetAllReservations()
        {
            return BookingReservationDAO.Instance.GetAllReservations();
        }

        public BookingReservation GetBookingReservation(int reservationId)
        {
           return BookingReservationDAO.Instance.GetBookingReservation(reservationId);
        }

        public void UpdateReservation(BookingReservation updatedReservation)
        {
           BookingReservationDAO.Instance.UpdateReservation(updatedReservation);
        }
    }
}
