using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using testK8sApp.Domain;

namespace testK8sApp.Data.Mappings;

public class AuthorMapping : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder
            .Property(a => a.UpdatedAt)
            .HasColumnName("UPDATED_AT")
            .HasDefaultValue(new DateTime(2023, 1, 1))
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
            .HasQueryFilter(a => !a.IsDeleted);
    }
}