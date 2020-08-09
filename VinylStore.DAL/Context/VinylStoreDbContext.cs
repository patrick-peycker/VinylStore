using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VinylStore.DAL.Entities;

namespace VinylStore.DAL.Context
{
	public class VinylStoreDbContext : IdentityDbContext<User>
	{
		public VinylStoreDbContext(DbContextOptions<VinylStoreDbContext> options) : base(options)
		{
		}

		public DbSet<Artist> Artists { get; set; }
		public DbSet<Album> Albums { get; set; }
		public DbSet<Track> Tracks { get; set; }
		public DbSet<CartItem> CartItems { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderDetail> OrderDetails { get; set; }
	}
}
