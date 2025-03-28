namespace Application.DTOs
{
    public class UserDTO
    {
        public string Email { get; set; } = string.Empty;
        public string? Role { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
