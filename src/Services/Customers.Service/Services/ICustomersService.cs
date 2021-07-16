using Customers.Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Customers.Service.Services
{
	public interface ICustomersService
	{
		Task<IEnumerable<Customer>> GetCustomers();
	}
}