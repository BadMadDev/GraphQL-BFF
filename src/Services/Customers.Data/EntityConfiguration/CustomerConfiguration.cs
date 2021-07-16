using Customers.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Customers.Data.EntityConfiguration
{
	public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
	{
		public void Configure(EntityTypeBuilder<Customer> builder)
		{
			builder.ToTable("Customers", "Customers");

			builder.HasKey(b => b.Id);

			builder.Property(b => b.Id)
				.IsRequired();

			builder.Property(t => t.Firstname)
				.IsRequired()
				.HasMaxLength(64);

			builder.Property(t => t.Lastname)
				.IsRequired()
				.HasMaxLength(64);

			builder.Property(t => t.DayOfBirth)
				.IsRequired();
		}
	}
}
