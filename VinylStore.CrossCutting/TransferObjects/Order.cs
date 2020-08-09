using System;
using System.Collections.Generic;

namespace VinylStore.CrossCutting.TransferObjects
{
	public class Order
	{
		public Guid Id { get; set; }
		public decimal Total { get; set; }
		public DateTime Date { get; set; }
		public List<OrderDetail> OrderItems { get; set; }
	}
}
