﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VinylStore.Web.Models
{
	public class Artist
	{
		public Guid Id { get; set; }
		public string Type { get; set; }
		public int Score { get; set; }
		public string Name { get; set; }
		public string Country { get; set; }
		public string Description { get; set; }
		public List<Album> Albums { get; set; }
	}
}
