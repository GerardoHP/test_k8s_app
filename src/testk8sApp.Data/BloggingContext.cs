using Microsoft.EntityFrameworkCore;
using testK8sApp.Domain;

namespace testk8sApp.Data;

public class BloggingContext : DbContext
{
    public BloggingContext(DbContextOptions<BloggingContext> options) :base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseSerialColumns();
        modelBuilder.Entity<ProofOfLife>()
            .HasData(new List<ProofOfLife>()
            {
                new()
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000001")
                }
            });
    }
    
    public DbSet<ProofOfLife> ProofOfLives { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
}
