using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VinylStore.Web.Models
{
	public class Track
	{
		public Guid Id { get; set; }
		public string Number { get; set; }
		public int Position { get; set; }
		//public int Length { get; set; }
		public string Title { get; set; }
	}
}
