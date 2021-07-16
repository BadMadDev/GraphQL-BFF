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
			var customerId = Guid.Parse("00BCD523-DC9B-4D23-95ED-0CF10DAACE5F");

			modelBuilder.Entity<OrderEntry>().HasData(
				new OrderEntry {Id = Guid.NewGuid(), OrderId = orderId, Description = "Product Description 1", Name = "Product 1", Price = 120 },
				new OrderEntry {Id = Guid.NewGuid(), OrderId = orderId, Description = "Product Description 2", Name = "Product 2", Price = 150 },
				new OrderEntry {Id = Guid.NewGuid(), OrderId = orderId, Description = "Product Description 3", Name = "Product 3", Price = 165 }
			);

			modelBuilder.Entity<Order>().HasData(
				new Order { Id = orderId, Date = DateTime.Now, Tax = 16, Total = 420, CustomerId = customerId }
			);
		}
	}
}
