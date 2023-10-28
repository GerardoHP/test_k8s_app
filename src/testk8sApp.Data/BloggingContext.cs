using Microsoft.EntityFrameworkCore;

namespace testk8sApp.Data;

public class BloggingContext : DbContext
{
    public BloggingContext(DbContextOptions<BloggingContext> options) :base(options){}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseSerialColumns();
        modelBuilder.Entity<ProofOfLife>().HasData(new List<ProofOfLife>() { new() { Id = Guid.Parse("00000000-0000-0000-0000-000000000001") } });
    }
    
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<ProofOfLife> ProofOfLives { get; set; }
}
