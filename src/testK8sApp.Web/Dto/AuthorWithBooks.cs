namespace testK8sApp.Web.Dto;

public class AuthorWithBooks
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<Book>? Books { get; set; }
}