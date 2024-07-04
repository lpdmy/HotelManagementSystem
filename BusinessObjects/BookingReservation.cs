using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class BookingReservation
    {
        public int BookingReservationID {  get; set; }
        public DateTime BookingDate { get; set; }
        public decimal TotalPrice { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        public BookingStatus BookingStatus { get; set; }

    }
}
