using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orders.Data.Models;

namespace Orders.Data.EntityConfiguration
{
	public class OrderEntryConfiguration : IEntityTypeConfiguration<OrderEntry>
	{
		public void Configure(EntityTypeBuilder<OrderEntry> builder)
		{
			builder.ToTable("OrderEntry", "Orders");

			builder.HasKey(e => e.Id);

			builder.Property(e => e.Id)
				.IsRequired();

			builder.Property(e => e.Name)
				.IsRequired()
				.HasMaxLength(32);

			builder.Property(e => e.Description)
				.IsRequired()
				.HasMaxLength(64);

			builder.Property(e => e.Price)
				.IsRequired();
		}
	}
}