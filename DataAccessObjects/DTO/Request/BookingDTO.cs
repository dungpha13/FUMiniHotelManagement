using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.DTO.Request
{
    public class BookingDTO
    {
        public int BookingReservationId { get; set; }

        public DateTime? BookingDate { get; set; }

        public decimal TotalPrice => CalculateTotalPrice();

        public int CustomerId { get; set; }

        public byte? BookingStatus { get; set; }

        public List<int> BookingDetails { get; set; }

        private decimal CalculateTotalPrice()
        {
            if (BookingDetails == null || BookingDetails.Count == 0)
            {
                return 0;
            }

            decimal totalPrice = 0;

            foreach (var item in BookingDetails)
            {

            }

            return totalPrice;
        }
    }
}
