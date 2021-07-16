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

			builder.HasKey(b => b.Id);

			builder.Property(b => b.Id)
				.IsRequired();
		}
	}
}