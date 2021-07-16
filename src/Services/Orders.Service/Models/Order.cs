using System;
using System.Collections.Generic;

namespace Orders.Service.Models
{
	public class Order
	{
		public Guid Id { get; set; }

		public IList<OrderEntry> OrderEntries { get; set; }
	}
}
