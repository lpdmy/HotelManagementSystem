using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IBookingReservationRepository
    {
        List<BookingReservation> GetAllReservations();
        BookingReservation AddReservation(BookingReservation reservation);
        void UpdateReservation(BookingReservation updatedReservation);
        void DeleteReservation(int reservationId);
        BookingReservation GetBookingReservation(int reservationId);

    }
}
