namespace testK8sApp.Domain;

public class Book
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public DateTime PublishedDate { get; set; }
    public decimal BasePrice { get; set; }
    public Author Author { get; set; }
    public int AuthorId { get; set; }
}