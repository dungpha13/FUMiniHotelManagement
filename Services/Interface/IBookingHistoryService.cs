using BusinessObjects;
using DataAccessObjects.DTO;

namespace Services.Interface
{
    public interface IBookingHistoryService
    {
        Task<BookingReservation?> GetBookingById(int id);
        Task<List<BookingHistoryDTO>> GetBookingByCusId(int id);
    }
}
