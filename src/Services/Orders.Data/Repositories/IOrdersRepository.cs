using Orders.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orders.Data.Repositories
{
	public interface IOrdersRepository
	{
		Task<List<Order>> GetOrdersAsync();
		Task<List<Order>> GetOrdersByCustomerIdAsync(Guid customerId);

		Task<Order> GetByIdAsync(Guid orderId);

		Task<Order> AddEntryToOrderAsync(Guid id, OrderEntry entry);
	}
}