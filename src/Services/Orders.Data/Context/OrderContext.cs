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

			var orderId = Guid.NewGuid();

			modelBuilder.Entity<OrderEntry>().HasData(
				new OrderEntry {Id = Guid.NewGuid(), OrderId = orderId },
				new OrderEntry {Id = Guid.NewGuid(), OrderId = orderId }
			);

			modelBuilder.Entity<Order>().HasData(
				new Order {Id = orderId}
			);
		}
	}
}
