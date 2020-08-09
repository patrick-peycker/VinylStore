using System;

namespace VinylStore.DAL.Entities
{
	public class OrderDetail
	{
		public Guid OrderDetailId { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }
		public Guid AlbumId { get; set; }
		public Album Album { get; set; }
		public Guid OrderId { get; set; }
		public Order Order { get; set; }
	}
}