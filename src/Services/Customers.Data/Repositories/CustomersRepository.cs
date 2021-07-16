using Customers.Data.Context;
using Customers.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Customers.Data.Repositories
{
	public class CustomersRepository : ICustomersRepository
	{
		private readonly CustomerContext _customerContext;

		public CustomersRepository(CustomerContext customerContext)
		{
			_customerContext = customerContext ?? throw new ArgumentNullException(nameof(customerContext));

			_customerContext.Database.EnsureCreated();
		}

		public Task<List<Customer>> GetCustomersAsync()
		{
			return _customerContext.Customers.AsNoTracking().ToListAsync();
		}

		public Task<Customer> GetByIdAsync(Guid customerId)
		{
			return Task.FromResult(new Customer());
		}
	}
}
