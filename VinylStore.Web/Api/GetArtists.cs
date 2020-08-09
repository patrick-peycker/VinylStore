using System;

namespace VinylStore.Web.Api
{
	public class GetArtists
	{
		public Guid Id { get; set; }
		public string Type { get; set; }
		public int Score { get; set; }
		public string Name { get; set; }
		public Area Area { get; set; }
		public string Disambiguation { get; set; }
	}
}
