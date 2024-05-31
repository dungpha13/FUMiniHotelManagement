using BusinessObjects;
using DataAccessObjects.DTO;
using DataAccessObjects.DTO.Request;

namespace Repositories.Interface
{
    public interface IBookingHistoryRepository
    {
        Task<BookingReservation?> GetBookingById(int id);
        Task<List<BookingHistoryDTO>> GetBookingByCusId(int id);
        BookingReservation CreateBooking(BookingDTO booking);
    }
}
