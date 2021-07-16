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

			var customerId = Guid.Parse("00BCD523-DC9B-4D23-95ED-0CF10DAACE5F");

			modelBuilder.Entity<Customer>().HasData(
				new Customer { Id = customerId, Firstname = "Hans", Lastname = "Werner", DayOfBirth = new DateTime(1970, 11, 4) },
				new Customer { Id = Guid.NewGuid(), Firstname = "Ben", Lastname = "Schuster", DayOfBirth = new DateTime(1973, 5, 6) },
				new Customer { Id = Guid.NewGuid(), Firstname = "Alfred", Lastname = "Müller", DayOfBirth = new DateTime(1982, 7, 12) },
				new Customer { Id = Guid.NewGuid(), Firstname = "Wolfgang", Lastname = "Fleischer", DayOfBirth = new DateTime(1967, 7, 21) },
				new Customer { Id = Guid.NewGuid(), Firstname = "Max", Lastname = "Mustermann", DayOfBirth = new DateTime(1949, 12, 2) }
			);
		}
	}
}
