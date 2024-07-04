using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class BookingReservationDAO : SingletonBase<BookingReservationDAO>
    {
        private List<BookingReservation> reservations; 

        public BookingReservationDAO()
        {
            reservations = new List<BookingReservation>() { };
        }

        public List<BookingReservation> GetAllReservations()
        {
            return reservations;
        }

        public BookingReservation AddReservation(BookingReservation reservation)
        {
            int newId = reservations.Count > 0 ? reservations.ToList().Max(r => r.BookingReservationID) + 1 : 1;
            reservation.BookingReservationID = newId;
            reservations.Add(reservation);
            return reservation;
        }

        public void UpdateReservation(BookingReservation updatedReservation)
        {
            BookingReservation existingReservation = reservations.ToList().FirstOrDefault(r => r.BookingReservationID == updatedReservation.BookingReservationID);
            if (existingReservation != null)
            {
                existingReservation.BookingDate = updatedReservation.BookingDate;
                existingReservation.TotalPrice = updatedReservation.TotalPrice;
                existingReservation.CustomerID = updatedReservation.CustomerID;
                existingReservation.Customer = updatedReservation.Customer;
                existingReservation.BookingStatus = updatedReservation.BookingStatus;
            }
        }

        public void DeleteReservation(int reservationId)
        {
            BookingReservation reservationToRemove = reservations.ToList().FirstOrDefault(r => r.BookingReservationID == reservationId);
            if (reservationToRemove != null)
            {
                reservations.Remove(reservationToRemove);
            }
        }

        public BookingReservation GetBookingReservation (int id)
        {
            return reservations.FirstOrDefault(x => x.BookingReservationID == id) ?? null;
        }
    }
}
