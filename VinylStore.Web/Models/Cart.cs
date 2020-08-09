using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinylStore.DAL.Context;

namespace VinylStore.Web.Models
{
	public class Cart
	{
		public string CartId { get; set; }
		public List<CartItem> CartItems { get; set; }

		private readonly VinylStoreDbContext context;
		public Cart(VinylStoreDbContext context)
		{
			this.context = context;
		}

		public static Cart GetCart(IServiceProvider services)
		{
			ISession session = services.GetRequiredService<IHttpContextAccessor>()?
				.HttpContext
				.Session;

			var context = services.GetService<VinylStoreDbContext>();

			string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

			session.SetString("CartId", cartId);

			return new Cart(context) { CartId = cartId };
		}

		//public void AddToCart(Album album, int amount)
		//{
		//	var CartItem =
		//			context.CartItems.SingleOrDefault(
		//				s => s.AlbumId == album.Id && s.CartId == CartId);

		//	if (CartItem == null)
		//	{
		//		CartItem = new CartItem
		//		{
		//			CartId = CartId,
		//			Album = album,
		//			Amount = 1
		//		};

		//		context.CartItems.Add(CartItem);
		//	}
		//	else
		//	{
		//		shoppingCartItem.Amount++;
		//	}
		//	_appDbContext.SaveChanges();
		//}

		//public int RemoveFromCart(Pie pie)
		//{
		//	var shoppingCartItem =
		//			_appDbContext.ShoppingCartItems.SingleOrDefault(
		//				s => s.Pie.PieId == pie.PieId && s.ShoppingCartId == ShoppingCartId);

		//	var localAmount = 0;

		//	if (shoppingCartItem != null)
		//	{
		//		if (shoppingCartItem.Amount > 1)
		//		{
		//			shoppingCartItem.Amount--;
		//			localAmount = shoppingCartItem.Amount;
		//		}
		//		else
		//		{
		//			_appDbContext.ShoppingCartItems.Remove(shoppingCartItem);
		//		}
		//	}

		//	_appDbContext.SaveChanges();

		//	return localAmount;
		//}

		//public List<CartItem> GetShoppingCartItems()
		//{
		//	return CartItems ??
		//		   (CartItems =
		//			   context.CartItems.Where(c => c.CartId == CartId)
		//				   .Include(s => s.Album)
		//				   .ToList());
		//}

		//public void ClearCart()
		//{
		//	var cartItems = context
		//		.ShoppingCartItems
		//		.Where(cart => cart.ShoppingCartId == ShoppingCartId);

		//	_appDbContext.ShoppingCartItems.RemoveRange(cartItems);

		//	_appDbContext.SaveChanges();
		//}

		//public decimal GetShoppingCartTotal()
		//{
		//	var total = _appDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
		//		.Select(c => c.Pie.Price * c.Amount).Sum();
		//	return total;
		//}

	}
}
