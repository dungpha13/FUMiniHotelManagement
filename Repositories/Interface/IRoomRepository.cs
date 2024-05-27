using BusinessObjects;
using DataAccessObjects.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IRoomRepository
    {
        List<RoomDTO> GetRooms(Func<RoomInformation, bool> predicate);
        Task AddRoom(RoomDTO room);
        Task UpdateRoom(RoomDTO room);
        Task DeleteRoom(int roomId);
    }
}
