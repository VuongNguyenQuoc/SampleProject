using App.ApplicationLayer.ModelsDto;
using App.DomainModelLayer.DbContexts;
using App.DomainModelLayer.Models;
using App.DomainModelLayer.OrderItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.InfrastructureLayer
{
    public class StubDataOrderItemReposotory : MemoryRepository<OrderItem>, IOrderItemRepository
    {
        private readonly SampleprojectContext _context;
        public StubDataOrderItemReposotory(SampleprojectContext context) : base(context)
        {
            _context = context;

        }
        public OrderItem UpdateQty(Guid id,int qty)
        {
            OrderItem orderItem = _context.OrderItem.Where(x => x.Id == id).FirstOrDefault();
            if(orderItem!=null)
            {
                orderItem.Quantity = qty;
                orderItem.Cost = qty * orderItem.ProductPrice;
                _context.OrderItem.Update(orderItem);

                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Order item not exist");
            }
            return orderItem;
        }

    }
}
