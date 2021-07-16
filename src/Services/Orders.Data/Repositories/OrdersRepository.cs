using Microsoft.EntityFrameworkCore;
using Orders.Data.Context;
using Orders.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
			return _orderContext.Orders.Include("OrderEntries").AsNoTracking().ToListAsync();
		}

		public Task<List<Order>> GetOrdersByCustomerIdAsync(Guid customerId)
		{
			return _orderContext.Orders.Include("OrderEntries").Where(o => o.CustomerId == customerId).AsNoTracking().ToListAsync();
		}

		public Task<Order> GetByIdAsync(Guid orderId)
		{
			return _orderContext.Orders.Include("OrderEntries").FirstOrDefaultAsync(o => o.Id == orderId);
		}

		public async Task<Order> AddEntryToOrderAsync(Guid id, OrderEntry entry)
		{
			var movie = await _orderContext.Orders.Where(m => m.Id == id).FirstOrDefaultAsync();
			movie.AddEntry(entry);
			await _orderContext.SaveChangesAsync();
			return movie;
		}
	}
}
