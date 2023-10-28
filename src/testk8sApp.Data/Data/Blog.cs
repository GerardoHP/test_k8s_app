using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testk8sApp.Data.Data;

[Table("blog")]
public class Blog
{
    [Key, Required]
    public int BlogId { get; set; }
    
    [Required]
    public string Url { get; set; } = string.Empty;
    public int Rating { get; set; }
    public virtual List<Post> Posts { get; set; } = new();
}
