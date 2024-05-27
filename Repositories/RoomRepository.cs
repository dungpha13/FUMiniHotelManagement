using BusinessObjects;
using DataAccessObjects;
using DataAccessObjects.DTO;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RoomRepository : IRoomRepository
    {
        public async Task AddRoom(RoomDTO room) => await RoomDAO.AddRoom(room);

        public async Task DeleteRoom(int roomId) => await RoomDAO.DeleteRoom(roomId);

        public List<RoomDTO> GetRooms(Func<RoomInformation, bool> predicate) => RoomDAO.GetRooms(predicate);

        public async Task UpdateRoom(RoomDTO room) => await RoomDAO.UpdateRoom(room);
    }
}
