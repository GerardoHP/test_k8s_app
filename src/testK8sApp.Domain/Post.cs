using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testK8sApp.Domain;

[Table("post")]
public class Post
{
    [Key, Required]
    public int PostId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;

    public int BlogId { get; set; }
    public virtual Blog Blog { get; set; } = new();
}