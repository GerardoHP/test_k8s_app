using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using testK8sApp.Domain;

namespace testK8sApp.Data.Mappings;

public class BookMapping : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder
            .Property(a => a.UpdatedAt)
            .HasColumnName("UPDATED_AT")
            .HasDefaultValue(new DateTime(2023, 1, 1).ToUniversalTime())
            .IsRequired();
        builder
            .Property(a => a.DeletedAt)
            .HasColumnName("DELETED_AT")
            .IsRequired(false);
        builder
            .Property(a => a.IsDeleted)
            .HasColumnName("IS_DELETED")
            .HasDefaultValue(false)
            .IsRequired();
        builder
            .Property(b => b.UpdatedBy)
            .HasColumnName("UPDATED_BY")
            .HasDefaultValue("system")
            .IsRequired();
        builder
            .HasQueryFilter(b => !b.IsDeleted && !b.Author.IsDeleted);
    }
}