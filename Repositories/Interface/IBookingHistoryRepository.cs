using BusinessObjects;
using DataAccessObjects.DTO;

namespace Repositories.Interface
{
    public interface IBookingHistoryRepository
    {
        Task<BookingReservation?> GetBookingById(int id);
        Task<List<BookingHistoryDTO>> GetBookingByCusId(int id);
    }
}
