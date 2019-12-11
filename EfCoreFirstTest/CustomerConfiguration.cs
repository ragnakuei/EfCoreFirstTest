using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreFirstTest
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable(nameof(Customer), "dbo");

            builder.HasKey(x => new
                                {
                                    x.Id,
                                })
                   .IsClustered();

            builder.Property(x => x.Id)
                   .HasColumnType(SqlDbTypes.Int)
                   .IsRequired();
        }
    }
}