using Customers.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Customers.Data.Repositories
{
	public interface ICustomersRepository
	{
		Task<List<Customer>> GetCustomersAsync();

		Task<Customer> GetByIdAsync(Guid customerId);
	}
}