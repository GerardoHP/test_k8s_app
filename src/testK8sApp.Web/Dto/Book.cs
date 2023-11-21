namespace testK8sApp.Web.Dto;

public class Book
{
      public int Id { get; set; }
      public string Title { get; set; }
      public DateTime PublishedDate { get; set; }
      public decimal BasePrice { get; set; }
      public Author? Author { get; set; } 
      public int? AuthorId { get; set; }
}