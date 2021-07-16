using System;

namespace Customers.Data.Models
{
	public class Customer
	{
		public Guid Id { get; set; }

		public string Firstname { get; set; }
		public string Lastname { get; set; }

		public DateTime DayOfBirth { get; set; }
	}
}
