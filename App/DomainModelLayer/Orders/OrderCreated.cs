using App.DomainModelLayer.Models;
using App.Helpers.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DomainModelLayer.Orders
{
    public class OrderCreated : DomainEvent
    {
        public Order order { get; set; }

        public override void Flatten()
        {
            this.Args.Add("Id", this.order.Id);
            this.Args.Add("CustomerId", this.order.CustomerId);
            this.Args.Add("Title", this.order.Number);
            this.Args.Add("Sum", this.order.Sum);
            this.Args.Add("TenantId", this.order.TenantId);
        }
    }
}
