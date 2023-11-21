using testK8sApp.Domain.Interfaces;

namespace testK8sApp.Domain;

public class Author : IAuditable
{
    public int AuthorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public bool IsDeleted { get; set; }
    public string UpdatedBy { get; set; }

    public virtual List<Book> Books { get; set; } = new();
}