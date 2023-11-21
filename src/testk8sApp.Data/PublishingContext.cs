using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using testK8sApp.Data.Interceptors;
using testK8sApp.Data.Mappings;
using testK8sApp.Domain;

namespace testK8sApp.Data;

public class PublishingContext : DbContext
{
    private readonly string _user;
    private readonly ILoggerFactory _loggerFactory;

    public PublishingContext(DbContextOptions<PublishingContext> options, ILoggerFactory loggerFactory)
        : base(options)
    {
        _loggerFactory = loggerFactory;
        // todo: get from session the user name
        _user = "context user";
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .AddInterceptors(new AuditableInterceptor(_user))
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            .UseLoggerFactory(_loggerFactory);
#if DEBUG
        optionsBuilder
            // replaced in order to use the logger factory in appsettings.Development.json
            // .LogTo(
            //     Console.WriteLine,
            //     new[]
            //     {
            //         DbLoggerCategory.Database.Command.Name,
            //         DbLoggerCategory.Update.Name,
            //     }, 
            //     LogLevel.Information)
            .EnableSensitiveDataLogging();
#endif
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
