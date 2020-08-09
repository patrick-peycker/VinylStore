using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VinylStore.Web.Models
{
	public class Album
	{
		public Guid Id { get; set; }
		public string Title { get; set; }

		[DisplayFormat(DataFormatString ="{0:yyy}")]
		public DateTime Date { get; set; }
		public string Country { get; set; }
		public string Barcode { get; set; }
		public decimal Price { get; set; }
		public int Quantity { get; set; }
		public int Track { get; set; }

		public List<Track> Tracks { get; set; }
	}
}
