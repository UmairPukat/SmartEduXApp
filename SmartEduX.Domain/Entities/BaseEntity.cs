namespace SmartEduX.Domain.Entities;

public abstract class BaseEntity
{
    public long CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public long? DeletedBy { get; set; }
    public DateTime? DeletedDate { get; set; }
    public long? UpdatedBy { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsDeleted { get; set; }
    public string LanguageCode { get; set; } = string.Empty;
}
