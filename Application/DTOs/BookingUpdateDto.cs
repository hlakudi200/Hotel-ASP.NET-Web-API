namespace Application.DTOs
{
    public class BookingUpdateDto
    {
        public int? RoomId { get; set; }
        public int? Persons { get; set; }
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public string? Status { get; set; } = string.Empty;
        public string? Notes { get; set; } = string.Empty;
    }
}
