using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BookingDetailRepository : IBookingDetailRepository
    {
        public void AddBookingDetail(BookingDetail bookingDetail)
        {
            BookingDetailDAO.Instance.AddBookingDetail(bookingDetail);
        }

        public void DeleteBookingDetail(int bookingReservationId, int roomId)
        {
            BookingDetailDAO.Instance.DeleteBookingDetail(bookingReservationId, roomId);
        }

        public List<BookingDetail> GetAllBookingDetails()
        {
            return BookingDetailDAO.Instance.GetAllBookingDetails();
        }

        public List<RoomInformation> GetAvailableRooms()
        {
            return BookingDetailDAO.Instance.GetAvailableRooms();
        }

        public BookingDetail GetBookingDetail(int BookingReservationId)
        {
            return BookingDetailDAO.Instance.GetBookingDetail(BookingReservationId);
        }

        public List<BookingDetail> GetBookingDetails(int userId)
        {
            return BookingDetailDAO.Instance.GetBookingDetails(userId);
        }

        public void UpdateBookingDetail(BookingDetail updatedBookingDetail)
        {
            BookingDetailDAO.Instance.UpdateBookingDetail(updatedBookingDetail);
        }
    }
}
