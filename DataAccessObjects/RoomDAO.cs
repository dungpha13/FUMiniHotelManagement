using BusinessObjects;
using DataAccessObjects.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class RoomDAO
    {
        public static List<RoomDTO> GetRooms(Func<RoomInformation, bool> predicate)
        {
            using var db = new FuminiHotelManagementContext();
            return db.RoomInformations
                            .Include(r => r.RoomType)
                            .Where(predicate)
                            .Select(r => new RoomDTO
                            {
                                RoomId = r.RoomId,
                                RoomNumber = r.RoomNumber,
                                RoomDetailDescription = r.RoomDetailDescription,
                                RoomMaxCapacity = r.RoomMaxCapacity,
                                RoomStatus = r.RoomStatus == 1 ? "Active" : "Deleted",
                                RoomPricePerDay = r.RoomPricePerDay,
                                RoomType = r.RoomType.RoomTypeName,
                            })
                            .ToList();
        }

        public static async Task AddRoom(RoomDTO room)
        {
            using var db = new FuminiHotelManagementContext();
            var newRoom = new RoomInformation
            {
                RoomNumber = room.RoomNumber,
                RoomDetailDescription = room.RoomDetailDescription,
                RoomMaxCapacity = room.RoomMaxCapacity,
                RoomStatus = room.RoomStatus.Equals("Active") ? (byte)1 : (byte)0,
                RoomPricePerDay = room.RoomPricePerDay,
                RoomType = await db.RoomTypes.FirstOrDefaultAsync(rt => rt.RoomTypeName == room.RoomType)
            };

            db.RoomInformations.Add(newRoom);
            await db.SaveChangesAsync();
        }

        public static async Task UpdateRoom(RoomDTO room)
        {
            using var db = new FuminiHotelManagementContext();
            var existingRoom = await db.RoomInformations.FindAsync(room.RoomId);
            if (existingRoom != null)
            {
                existingRoom.RoomNumber = room.RoomNumber;
                existingRoom.RoomDetailDescription = room.RoomDetailDescription;
                existingRoom.RoomMaxCapacity = room.RoomMaxCapacity;
                existingRoom.RoomStatus = room.RoomStatus.Equals("Active") ? (byte)1 : (byte)0;
                existingRoom.RoomPricePerDay = room.RoomPricePerDay;
                existingRoom.RoomType = await db.RoomTypes.FirstOrDefaultAsync(rt => rt.RoomTypeName == room.RoomType);

                db.RoomInformations.Update(existingRoom);
                await db.SaveChangesAsync();
            }
        }

        public static async Task DeleteRoom(int roomId)
        {
            using var db = new FuminiHotelManagementContext();
            var room = await db.RoomInformations.FindAsync(roomId);
            if (room != null)
            {
                db.RoomInformations.Remove(room);
                await db.SaveChangesAsync();
            }
        }
    }
}
