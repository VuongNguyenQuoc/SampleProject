
using App.DomainModelLayer.Orders;
using App.Helpers.Domain;
using System;
using System.Collections.Generic;

#nullable disable

namespace App.DomainModelLayer.Models
{
    public partial class Order : IAggregateRoot
    {
        public Order()
        {
            OrderItem = new HashSet<OrderItem>();
        }

        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public long Number { get; set; }
        public Guid TenantId { get; set; }
        public decimal Sum { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderItem> OrderItem { get; set; }
        public static Order Create(Guid custormerID, long number, Guid tenantId, decimal sum)
        {
            return Create(Guid.NewGuid(), custormerID, number, tenantId, sum);
        }

        public static Order Create(Guid id, Guid custormerID, long number, Guid tenantId, decimal sum)
        {
            Order order = new Order()
            {
                Id = id,
                CustomerId = custormerID,
                Number = number,
                TenantId = tenantId,
                Sum = sum,
            };
            DomainEvents.Raise<OrderCreated>(new OrderCreated() { order = order });

            return order;
        }


    }
}