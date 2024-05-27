using BusinessObjects;
using DataAccessObjects.DTO;
using Repositories;
using Repositories.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _repo;

        public RoomService()
        {
            _repo = new RoomRepository();
        }

        public async Task AddRoom(RoomDTO room) => await _repo.AddRoom(room);

        public async Task DeleteRoom(int roomId) => await _repo.DeleteRoom(roomId);

        public List<RoomDTO> GetRooms(Func<RoomInformation, bool> predicate) => _repo.GetRooms(predicate);

        public async Task UpdateRoom(RoomDTO room) => await _repo.UpdateRoom(room);
    }
}
