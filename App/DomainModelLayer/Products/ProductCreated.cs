using App.DomainModelLayer.Models;
using App.Helpers.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DomainModelLayer.Products
{
    public class ProductCreated : DomainEvent
    {
        public Product product { get; set; }

        public override void Flatten()
        {
            this.Args.Add("Id", this.product.Id);
            this.Args.Add("TenantId", this.product.TenantId);
            this.Args.Add("Title", this.product.Tilte);
            this.Args.Add("Price", this.product.Price);
            this.Args.Add("TenantId", this.product.TenantId);
            

        }
    }
}
