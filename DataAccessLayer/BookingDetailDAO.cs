using BusinessObjects;

namespace DataAccessLayer
{
    public class BookingDetailDAO : SingletonBase<BookingDetailDAO>
    {
        private List<BookingDetail> bookingDetails; // In-memory collection to store booking details

        public BookingDetailDAO()
        {
            bookingDetails = new List<BookingDetail>();

        }


        public List<BookingDetail> GetAllBookingDetails()
        {
            return bookingDetails;
        }

        public BookingDetail GetBookingDetail(int BookingReservationId)
        {
            return bookingDetails.FirstOrDefault(x => x.BookingReservationID == BookingReservationId);
        }

        public void AddBookingDetail(BookingDetail bookingDetail)
        {
            bookingDetails.Add(bookingDetail);
        }


        public void UpdateBookingDetail(BookingDetail updatedBookingDetail)
        {
            BookingDetail existingBookingDetail = bookingDetails.FirstOrDefault(b => b.BookingReservationID == updatedBookingDetail.BookingReservationID && b.RoomID == updatedBookingDetail.RoomID);
            if (existingBookingDetail != null)
            {
                existingBookingDetail.StartDate = updatedBookingDetail.StartDate;
                existingBookingDetail.EndDate = updatedBookingDetail.EndDate;
                existingBookingDetail.ActualPrice = updatedBookingDetail.ActualPrice;
            }

        }


        public void DeleteBookingDetail(int bookingReservationId, int roomId)
        {

            BookingDetail bookingDetailToRemove = bookingDetails.FirstOrDefault(b => b.BookingReservationID == bookingReservationId && b.RoomID == roomId);
            if (bookingDetailToRemove != null)
            {
                bookingDetails.Remove(bookingDetailToRemove);
            }
        }

       
        public List<RoomInformation> GetAvailableRooms()
        {
            var listIds = bookingDetails.Where(x => x.BookingReservation.BookingStatus != BookingStatus.Pending).Select(x => x.RoomID).ToList();
            var listAllRoom = RoomInformationDAO.Instance.GetRoomInformations();
            var listNotConfirmedRooms = listAllRoom
                .Where(room => listIds.Contains(room.RoomID))
                .ToList();
            return listNotConfirmedRooms;
        }

        public List<BookingDetail> GetBookingDetails(int userId)
        {
            var listBookingDetail = bookingDetails.Where(x => x.BookingReservation.CustomerID == userId).ToList();
            return listBookingDetail;
        }
    }
}

