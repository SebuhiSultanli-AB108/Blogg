namespace Blogg.BL.DTOs.UserDTOs;

public class RegisterDTO
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string? ImageUrl { get; set; }
    public bool IsMale { get; set; }
}
