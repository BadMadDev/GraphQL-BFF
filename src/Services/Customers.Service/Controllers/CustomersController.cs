using Customers.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Customers.Service.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CustomersController : ControllerBase
	{
		private readonly ICustomersService _customersService;
		private readonly ILogger<CustomersController> _logger;

		public CustomersController(ICustomersService customersService, ILogger<CustomersController> logger)
		{
			_customersService = customersService ?? throw new ArgumentNullException(nameof(customersService));
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var customers = await _customersService.GetCustomers();

			return Ok(customers);
		}
	}
}
