using Microsoft.EntityFrameworkCore;
using Orders.Data.Context;
using Orders.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orders.Data.Repositories
{
	public class OrdersRepository : IOrdersRepository
	{
		private readonly OrderContext _orderContext;

		public OrdersRepository(OrderContext orderContext)
		{
			_orderContext = orderContext ?? throw new ArgumentNullException(nameof(orderContext));

			_orderContext.Database.EnsureCreated();
		}

		public Task<List<Order>> GetOrdersAsync()
		{
			return _orderContext.Orders.AsNoTracking().ToListAsync();
		}

		public Task<Order> GetByIdAsync(Guid customerId)
		{
			return Task.FromResult(new Order());
		}
	}
}
