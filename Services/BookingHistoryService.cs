using BusinessObjects;
using DataAccessObjects.DTO;
using Repositories;
using Repositories.Interface;
using Services.Interface;

namespace Services
{
    public class BookingHistoryService : IBookingHistoryService
    {
        private readonly IBookingHistoryRepository _repo;

        public BookingHistoryService()
        {
            _repo = new BookingHistoryRepository();
        }

        public async Task<BookingReservation?> GetBookingById(int id) => await _repo.GetBookingById(id);

        public async Task<List<BookingHistoryDTO>> GetBookingByCusId(int id) => await _repo.GetBookingByCusId(id);
    }
}
