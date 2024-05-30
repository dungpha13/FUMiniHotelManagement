using BusinessObjects;
using DataAccessObjects.DTO;
using DataAccessObjects.DTO.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class BookingHistoryDAO
    {
        public static async Task<BookingReservation?> GetBookingById(int id)
        {
            using var db = new FuminiHotelManagementContext();
            return await db.BookingReservations.FirstOrDefaultAsync(b => b.Equals(id));
        }

        public static async Task<List<BookingHistoryDTO>> GetBookingByCusId(int id)
        {
            using var db = new FuminiHotelManagementContext();
            return await db.BookingDetails
                .Include(bd => bd.BookingReservation)
                    .ThenInclude(br => br.Customer)
                .Include(bd => bd.Room)
                .Where(bd => bd.BookingReservation.CustomerId == id)
                .Select(bd => new BookingHistoryDTO
                {
                    BookingReservationId = bd.BookingReservationId,
                    RoomId = bd.RoomId,
                    RoomNumber = bd.Room.RoomNumber,
                    StartDate = bd.StartDate,
                    EndDate = bd.EndDate,
                    ActualPrice = bd.ActualPrice,
                    BookingDate = bd.BookingReservation.BookingDate,
                    TotalPrice = bd.BookingReservation.TotalPrice,
                    CustomerId = bd.BookingReservation.CustomerId,
                    BookingStatus = bd.BookingReservation.BookingStatus
                })
                .ToListAsync();
        }

        public BookingReservation CreateBooking(BookingDTO bookingDto)
        {
            using var db = new FuminiHotelManagementContext();

            var bookingReservation = new BookingReservation
            {
                BookingReservationId = bookingDto.BookingReservationId,
                BookingDate = DateOnly.FromDateTime((DateTime)bookingDto.BookingDate),
                CustomerId = bookingDto.CustomerId,
                BookingStatus = bookingDto.BookingStatus,
                BookingDetails = new List<BookingDetail>()
            };

            foreach (var detailDto in bookingDto.BookingDetails)
            {
                var detail = new BookingDetail
                {
                    BookingReservationId = bookingDto.BookingReservationId,
                    RoomId = detailDto.Room.RoomId,
                    StartDate = DateOnly.FromDateTime(detailDto.StartDate),
                    EndDate = DateOnly.FromDateTime(detailDto.EndDate),
                    ActualPrice = detailDto.ActualPrice,
                    Room = db.RoomInformations.Find(detailDto.Room.RoomId),
                };

                db.BookingDetails.Add(detail);
                bookingReservation.BookingDetails.Add(detail);
            }

            db.BookingReservations.Add(bookingReservation);

            return bookingReservation;
        }
    }
}
