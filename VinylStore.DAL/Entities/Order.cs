using System;
using System.Collections.Generic;

namespace VinylStore.DAL.Entities
{
	public class Order
	{
		public Guid OrderId { get; set; }
		public decimal Total { get; set; }
		public DateTime Date { get; set; }
		public ICollection<OrderDetail> OrderItems { get; set; }
	}
}
