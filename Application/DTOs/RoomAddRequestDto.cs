using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class RoomAddRequestDto
    {
        public int RoomNo { get; set; }
        public string RoomType { get; set; } = string.Empty;
        public bool Booked { get; set; }
        public bool Locked { get; set; }
    }
}
