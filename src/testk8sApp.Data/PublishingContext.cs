using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using testK8sApp.Data.Interceptors;
using testK8sApp.Data.Mappings;
using testK8sApp.Domain;

namespace testK8sApp.Data;

public class PublishingContext : DbContext
{
    public PublishingContext(DbContextOptions<PublishingContext> options)
        : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .AddInterceptors(new AuditableInterceptor())
            .LogTo(Console.WriteLine);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseSerialColumns();
        // new AuthorMapping().Configure(modelBuilder.Entity<Author>());
        // modelBuilder.ApplyConfiguration(new AuthorMapping());
        modelBuilder.ApplyConfiguration(new AuthorMapping());
        modelBuilder.ApplyConfiguration(new BookMapping());
    }
     

    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
}
