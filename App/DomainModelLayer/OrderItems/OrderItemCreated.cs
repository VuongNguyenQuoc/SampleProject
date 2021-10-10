using App.DomainModelLayer.Models;
using App.Helpers.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DomainModelLayer.OrderItems
{
    public class OrderItemCreated: DomainEvent
    {
        public Models.OrderItem orderItem { get; set; }

        public override void Flatten()
        {
            this.Args.Add("Id", this.orderItem.Id);
            this.Args.Add("OrderId", this.orderItem.OrderId);
            this.Args.Add("ProductId", this.orderItem.ProductId);
            this.Args.Add("Quantity", this.orderItem.Quantity);
            this.Args.Add("ProductPrice", this.orderItem.ProductPrice);
            this.Args.Add("Cost", this.orderItem.Cost);
        }
    }
}
