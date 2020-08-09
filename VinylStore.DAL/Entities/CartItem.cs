using System;

namespace VinylStore.DAL.Entities
{
	public class CartItem
	{
		public Guid CartItemId { get; set; }
		public Guid AlbumId { get; set; }
		public Album Album { get; set; }
		public decimal Amount { get; set; }
		public string CartId { get; set; }
	}
}
