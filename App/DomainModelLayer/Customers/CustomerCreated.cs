using App.DomainModelLayer.Models;
using App.Helpers.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DomainModelLayer.Customers
{
    public class CustomerCreated : DomainEvent
    {
        public Customer Customer { get; set; }

        public override void Flatten()
        {
            this.Args.Add("Id", this.Customer.Id);
            this.Args.Add("TenantId", this.Customer.TenantId);
            this.Args.Add("Title", this.Customer.Title);            
        }
    }
}
