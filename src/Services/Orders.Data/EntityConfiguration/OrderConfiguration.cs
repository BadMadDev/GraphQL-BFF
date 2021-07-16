using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orders.Data.Models;

namespace Orders.Data.EntityConfiguration
{
	public class OrderConfiguration : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
		{
			builder.ToTable("Orders", "Orders");

			builder.HasKey(b => b.Id);

			builder.Property(b => b.Id)
				.IsRequired();

			builder.Property(b => b.CustomerId)
				.IsRequired();

			builder.Property(b => b.Date)
				.IsRequired();

			builder.Property(b => b.Tax)
				.IsRequired();

			builder.Property(b => b.Total)
				.IsRequired();

			builder.HasMany(b => b.OrderEntries)
				.WithOne(a => a.Order)
				.HasForeignKey(a => a.OrderId);
		}
	}
}
