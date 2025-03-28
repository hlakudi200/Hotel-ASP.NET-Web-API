namespace Application.DTOs
{
    public class ClientResponseDto
    {
        public string ClientNo { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string IdNumber { get; set; } = string.Empty;
        public string ContactNo { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; } = string.Empty;
    }
}
