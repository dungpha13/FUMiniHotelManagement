﻿using BusinessObjects;
using DataAccessObjects;
using DataAccessObjects.DTO;
using DataAccessObjects.DTO.Request;
using Repositories.Interface;

namespace Repositories
{
    public class BookingHistoryRepository : IBookingHistoryRepository
    {
        public async Task<BookingReservation?> GetBookingById(int id) => await BookingHistoryDAO.GetBookingById(id);

        public async Task<List<BookingHistoryDTO>> GetBookingByCusId(int id) => await BookingHistoryDAO.GetBookingByCusId(id);

        public BookingReservation CreateBooking(BookingDTO booking) => BookingHistoryDAO.CreateBooking(booking);
    }
}
