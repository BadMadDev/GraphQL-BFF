using Customers.Data.Repositories;
using Customers.Service.Mappings;
using Customers.Service.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers.Service.Services
{
	public class CustomersService : ICustomersService
	{
		private readonly ICustomersRepository _customersRepository;

		public CustomersService(ICustomersRepository customersRepository)
		{
			_customersRepository = customersRepository;
		}

		public async Task<IEnumerable<Customer>> GetCustomers()
		{
			var customers = await _customersRepository.GetCustomersAsync();

			return customers.Select(c => c.ToModel());
		}
	}
}
