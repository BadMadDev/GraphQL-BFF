using Microsoft.EntityFrameworkCore;
using Orders.Data.Models;
using System;

namespace Orders.Data.Context
{
	public class OrderContext : DbContext
	{
		public OrderContext(DbContextOptions<OrderContext> options) : base(options)
		{

		}

		public DbSet<Order> Orders { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderContext).Assembly);

			var orderId = Guid.Parse("72d95bfd-1dac-4bc2-adc1-f28fd43777fd");

			modelBuilder.Entity<OrderEntry>().HasData(
				new OrderEntry {Id = Guid.NewGuid(), OrderId = orderId, Description = "Bechreibung 1"},
				new OrderEntry {Id = Guid.NewGuid(), OrderId = orderId, Description = "Bechreibung 2" }
			);

			modelBuilder.Entity<Order>().HasData(
				new Order {Id = orderId}
			);
		}
	}
}
