using System;
using System.Collections.Generic;

namespace Orders.Data.Models
{
	public class Order
	{
		public Guid Id { get; set; }

		public IList<OrderEntry> OrderEntries { get; set; } = new List<OrderEntry>();

		public void AddEntry(OrderEntry entry)
		{
			OrderEntries.Add(entry);
		}
	}
}
