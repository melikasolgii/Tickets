using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tickets.Domains;
namespace Data.EntityConfig;
public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        if (builder == null)
        {
            throw new ArgumentNullException(nameof(builder));
        }        
        builder.Property(e => e.Name).HasColumnType("nvarchar(50)").IsRequired();
        builder.HasIndex(e => e.Username).IsUnique();
        builder.Property(e => e.Password).HasColumnType("varchar(50)").IsRequired();        
        builder.Property(e => e.NationalCode).HasColumnType("varchar(11)");

        builder.HasMany(x => x.Customers).WithOne(x => x.User).HasForeignKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(x => x.Employees).WithOne(x => x.User).HasForeignKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
