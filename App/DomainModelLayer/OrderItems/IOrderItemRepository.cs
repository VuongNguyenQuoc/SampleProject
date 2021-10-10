using App.DomainModelLayer.Models;
using App.Helpers.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DomainModelLayer.OrderItems
{
    public interface IOrderItemRepository : IRepository<OrderItem>
    {
        public OrderItem UpdateQty(Guid id, int qty);



    }
}
