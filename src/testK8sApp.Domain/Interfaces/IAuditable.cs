namespace testK8sApp.Domain.Interfaces;

public interface IAuditable
{
    public DateTime UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public bool IsDeleted { get; set; }
    public string UpdatedBy { get; set; }
}