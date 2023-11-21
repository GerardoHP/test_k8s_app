using testK8sApp.Domain.Interfaces;

namespace testK8sApp.Domain;

public class Book : IAuditable
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public DateTime PublishedDate { get; set; }
    public decimal BasePrice { get; set; }
    public int AuthorId { get; set; }
    
    public DateTime UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public bool IsDeleted { get; set; }
    public string UpdatedBy { get; set; }

    public virtual Author Author { get; set; }
}