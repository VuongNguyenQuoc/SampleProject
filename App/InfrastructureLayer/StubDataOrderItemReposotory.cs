using App.ApplicationLayer.ModelsDto;
using App.DomainModelLayer.DbContexts;
using App.DomainModelLayer.Models;
using App.DomainModelLayer.OrderItems;
using Microsoft.EntityFrameworkCore;
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
        public async Task< OrderItem> UpdateQty(Guid id,int qty)
        {
            OrderItem orderItem =await _context.OrderItem.Where(x => x.Id == id).FirstOrDefaultAsync();
            if(orderItem!=null)
            {
                orderItem.Quantity = qty;
                orderItem.Cost = qty * orderItem.ProductPrice;
                _context.OrderItem.Update(orderItem);                
            }
            else
            {
                throw new Exception("Order item not exist");
            }
            return orderItem;
        }        
    }
}
