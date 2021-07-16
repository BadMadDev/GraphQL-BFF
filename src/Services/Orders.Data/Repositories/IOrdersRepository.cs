using Orders.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orders.Data.Repositories
{
	public interface IOrdersRepository
	{
		Task<List<Order>> GetOrdersAsync();

		Task<Order> GetByIdAsync(Guid customerId);
	}
}