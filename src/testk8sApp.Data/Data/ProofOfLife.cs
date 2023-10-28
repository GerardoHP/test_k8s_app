using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testk8sApp.Data.Data;

[Table("proof")]
public class ProofOfLife
{
    [Key, Required]
    public Guid Id { get; set; }
}