namespace Blogg.Core.Entities.Common;

public class AuditableEntity : BaseEntity
{
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}
