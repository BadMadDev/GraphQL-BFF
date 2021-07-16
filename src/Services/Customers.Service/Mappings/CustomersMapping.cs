using Customers.Service.Models;

namespace Customers.Service.Mappings
{
	public static class CustomersMapping
	{
		public static Customer ToModel(this Data.Models.Customer customer)
		{
			return new()
			{
				Id = customer.Id,
				Firstname = customer.Firstname,
				Lastname = customer.Lastname,
				DayOfBirth = customer.DayOfBirth
			};
		}
	}
}