
using App.DomainModelLayer.OrderItems;
using App.Helpers.Domain;
using System;
using System.Collections.Generic;

#nullable disable

namespace App.DomainModelLayer.Models
{
    public partial class OrderItem : IAggregateRoot
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal Cost { get; set; }

        public virtual Order Order { get; set; }

        public static OrderItem Create(Guid orderid, Guid product, int qty, decimal proPrice)
        {
            return Create(Guid.NewGuid(), orderid, product, qty, proPrice);
        }

        public static OrderItem Create(Guid id, Guid orderid, Guid product, int qty, decimal proPrice)
        {
            OrderItem orderItem = new OrderItem()
            {
                Id = id,
                OrderId = orderid,
                ProductId = product,
                Quantity = qty,
                ProductPrice = proPrice,
                Cost = qty * proPrice,
            };
            DomainEvents.Raise<OrderItemCreated>(new OrderItemCreated() { orderItem = orderItem });

            return orderItem;
        }
    }
}