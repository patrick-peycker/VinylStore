using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VinylStore.Web.Models
{
	public class CartItem
	{
		public Guid CartItemId { get; set; }
		public Album Album { get; set; }
		public decimal Amount { get; set; }
		public string CartId { get; set; }
	}
}
