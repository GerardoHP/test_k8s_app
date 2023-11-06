using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testK8sApp.Domain;

[Table("proof")]
public class ProofOfLife
{
    [Key, Required]
    public Guid Id { get; set; }
}