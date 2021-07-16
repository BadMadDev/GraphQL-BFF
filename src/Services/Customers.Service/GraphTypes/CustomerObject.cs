using Customers.Data.Models;
using GraphQL.Types;

namespace Customers.Service.GraphTypes
{
	public sealed class CustomerObject : ObjectGraphType<Customer>
	{
		public CustomerObject()
		{
			Name = nameof(Customer);
			Description = "A customer";

			Field(m => m.Id).Description("Identifier of the customer");
			Field(m => m.Firstname).Description("Firstname of the customer");
			Field(m => m.Lastname).Description("Lastname of the customer");
			Field(m => m.DayOfBirth).Description("DayOfBirth of the customer");
		}
	}
}
