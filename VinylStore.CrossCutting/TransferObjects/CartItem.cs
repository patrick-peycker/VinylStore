using System;
using System.Collections.Generic;
using System.Text;

namespace VinylStore.CrossCutting.TransferObjects
{
	public class CartItem
	{
		public Guid Id { get; set; }
		public Album Album { get; set; }
		public decimal Amount { get; set; }
		public string CartId { get; set; }
	}
}
