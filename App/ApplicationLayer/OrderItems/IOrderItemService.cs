using App.ApplicationLayer.ModelsDto;
using App.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationLayer.OrderItems
{
    public interface IOrderItemService
    {
        public OrderItemDto Add(OrderItemDto orderItems);
        public OrderItemDto UpdateQty(Guid id, int qty);

        public bool Remove(OrderItemDto id);
    }
}
