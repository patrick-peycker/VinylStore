using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using VinylStore.CrossCutting.Interfaces;
using VinylStore.CrossCutting.TransferObjects;
using VinylStore.DAL.Context;
using VinylStore.DAL.Extensions;

namespace VinylStore.DAL.Repositories
{
	public class CartItemRepository : ICartItemRepository
	{
		private readonly VinylStoreDbContext context;

		public CartItemRepository(VinylStoreDbContext context)
		{
			this.context = context ?? throw new ArgumentNullException($"CartItemRepository : {nameof(context)} is empty");
		}

		public CrossCutting.TransferObjects.CartItem Create(CrossCutting.TransferObjects.CartItem TransferObject)
		{
			if (TransferObject is null)
				throw new ArgumentNullException($"CartItemRepository : {nameof(context)} is empty");

			var entityCreated = context.CartItems.Add(TransferObject.ToEntity());

			return entityCreated.Entity.ToTransferObject();
		}

		public CrossCutting.TransferObjects.CartItem Delete(CrossCutting.TransferObjects.CartItem TransferObject)
		{
			if (TransferObject is null)
				throw new ArgumentNullException($"CartItemRepository : {nameof(TransferObject)} is empty");

			var entityDeleted = context.CartItems.Remove(TransferObject.ToEntity());

			return entityDeleted.Entity.ToTransferObject();
		}

		public void DeleteAllByCartId(string CartId)
		{
			var itemsToDelete = RetrieveByCartId(CartId);
			context.RemoveRange(itemsToDelete);
		}

		public ICollection<CartItem> GetAll()
		{
			throw new NotImplementedException();
		}

		public CartItem GetById(Guid id)
		{
			throw new NotImplementedException();
		}

		public CartItem Insert(CartItem entity)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<CrossCutting.TransferObjects.CartItem> Retrieve()
		{
			throw new NotImplementedException();
		}

		public CrossCutting.TransferObjects.CartItem Retrieve(Guid Id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<CrossCutting.TransferObjects.CartItem> RetrieveByCartId(string CartId)
		{
			return context.CartItems
				.Where(c => c.CartId == CartId)
				.Include(c => c.Album)
				.Select(c=>c.ToTransferObject());
		}

		public CrossCutting.TransferObjects.CartItem Update(CrossCutting.TransferObjects.CartItem TransferObject)
		{
			throw new NotImplementedException();
		}

	}
}
