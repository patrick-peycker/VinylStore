using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VinylStore.Web.Models
{
	public class Album
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string Date { get; set; }
		public string Country { get; set; }
		public string Barcode { get; set; }
		public decimal Price { get; set; }
		public int Quantity { get; set; }
	}
}
