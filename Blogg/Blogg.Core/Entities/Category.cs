namespace Blogg.Core.Entities;

public class Category : AuditableEntity
{
    public string Name { get; set; } = null!;
    public string Icon { get; set; } = null!;

}
