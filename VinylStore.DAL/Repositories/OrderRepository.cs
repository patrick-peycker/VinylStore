using System;
using System.Collections.Generic;
using VinylStore.CrossCutting.Interfaces;
using VinylStore.CrossCutting.TransferObjects;
using VinylStore.DAL.Context;


namespace VinylStore.DAL.Repositories
{
	public class OrderRepository : IOrderRepository
	{
		private readonly VinylStoreDbContext context;

		public OrderRepository(VinylStoreDbContext context)
		{
			this.context = context;

			if (this.context is null)
			{
				throw new ArgumentNullException($"OrderRepository : {nameof(context)} is empty");
			}
		}

		public CrossCutting.TransferObjects.Order Create(CrossCutting.TransferObjects.Order TransferObject)
		{
			//if (TransferObject is null)
			//{
			//	throw new ArgumentNullException($"OrderRepository : {nameof(TransferObject)} is empty");
			//}
			//var entry = context.Orders.Add(TransferObject.ToEntity());

			//return entry.Entity.ToTransfertObject();

			throw new NotImplementedException();
		}

		public CrossCutting.TransferObjects.Order Delete(CrossCutting.TransferObjects.Order TransferObject)
		{
			throw new NotImplementedException();
		}

		public ICollection<Order> GetAll()
		{
			throw new NotImplementedException();
		}

		public Order GetById(Guid id)
		{
			throw new NotImplementedException();
		}

		public Order Insert(Order entity)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<CrossCutting.TransferObjects.Order> Retrieve()
		{
			throw new NotImplementedException();
		}

		public CrossCutting.TransferObjects.Order Retrieve(Guid Id)
		{
			throw new NotImplementedException();
		}

		public CrossCutting.TransferObjects.Order Update(CrossCutting.TransferObjects.Order TransferObject)
		{
			throw new NotImplementedException();
		}
	}
}
