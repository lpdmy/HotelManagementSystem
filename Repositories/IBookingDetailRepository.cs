using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IBookingDetailRepository
    {
        List<BookingDetail> GetAllBookingDetails();
        BookingDetail GetBookingDetail(int BookingReservationId);
        void AddBookingDetail(BookingDetail bookingDetail);
        void UpdateBookingDetail(BookingDetail updatedBookingDetail);
        void DeleteBookingDetail(int bookingReservationId, int roomId);
        List<RoomInformation> GetAvailableRooms();
        List<BookingDetail> GetBookingDetails(int userId);
    }
}
