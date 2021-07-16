using Orders.Data.Repositories;
using Orders.Service.Mappings;
using Orders.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Service.Services
{
	public class OrdersService : IOrdersService
	{
		private readonly IOrdersRepository _ordersRepository;

		public OrdersService(IOrdersRepository ordersRepository)
		{
			_ordersRepository = ordersRepository ?? throw new ArgumentNullException(nameof(ordersRepository));
		}
		public async Task<IEnumerable<Order>> GetOrders()
		{
			var orders = await _ordersRepository.GetOrdersAsync();

			return orders.Select(o => o.ToModel());
		}
	}
}
