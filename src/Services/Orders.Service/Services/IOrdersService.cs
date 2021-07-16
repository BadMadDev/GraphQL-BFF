using System.Collections.Generic;
using System.Threading.Tasks;
using Orders.Service.Models;

namespace Orders.Service.Services
{
	public interface IOrdersService
	{
		Task<IEnumerable<Order>> GetOrders();
	}
}