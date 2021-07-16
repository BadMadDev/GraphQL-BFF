using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Orders.Service.Services;
using System;
using System.Threading.Tasks;

namespace Orders.Service.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class OrdersController : ControllerBase
	{
		private readonly IOrdersService _ordersService;
		private readonly ILogger<OrdersController> _logger;

		public OrdersController(IOrdersService ordersService, ILogger<OrdersController> logger)
		{
			_ordersService = ordersService ?? throw new ArgumentNullException(nameof(ordersService));
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var orders = await _ordersService.GetOrders();

			return Ok(orders);
		}
	}
}
