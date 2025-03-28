using Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class BookingResponseDto
    {
        public ClientResponseDto ClientDto { get; set; }
        public int RoomId { get; set; }
        public int persons { get; set; }
        public DateTime BookingDate { get; private set; } = DateTime.Now;
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
    }
}
