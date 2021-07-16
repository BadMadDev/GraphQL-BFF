using System;
using Customers.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Customers.Data.Context
{
	public class CustomerContext : DbContext
	{
		public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
		{
		}

		public DbSet<Customer> Customers{ get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerContext).Assembly);

			var customerId = "{44C2D406-5BEB-43EF-A16E-4469FD369036}";

			modelBuilder.Entity<Customer>().HasData(
				new Customer {  Id = Guid.Parse(customerId), Firstname = "Hans", Lastname = "Werner"},
				new Customer {  Id = Guid.NewGuid(), Firstname = "Max", Lastname = "Mustermann"}
			);
		}
	}
}
