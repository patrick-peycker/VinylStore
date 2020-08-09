using System;

namespace VinylStore.CrossCutting.TransferObjects
{
	public class OrderDetail
	{
		public Guid Id { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }
		public Album Album { get; set; }
		public Order Order { get; set; }
	}
}
