namespace Blogg.Core.Entities;

public class User : AuditableEntity
{
    public string Username { get; set; }
    public string ImageUrl { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
    public bool IsMale { get; set; }
    public int Role { get; set; } = 1;
}
