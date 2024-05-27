using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.DTO
{
    public class RoomDTO
    {
        public int RoomId { get; set; }

        public string? RoomNumber { get; set; }

        public string? RoomDetailDescription { get; set; }

        public int? RoomMaxCapacity { get; set; }

        public string? RoomStatus { get; set; }

        public decimal? RoomPricePerDay { get; set; }

        public string? RoomType { get; set; }
    }
}
