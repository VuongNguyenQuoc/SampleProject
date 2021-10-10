using App.DomainModelLayer.Models;
using App.Helpers.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DomainModelLayer.Tenants
{
    public class TenantCreated: DomainEvent
    {
        public Tenant Tenant { get; set; }

        public override void Flatten()
        {
            this.Args.Add("Id", this.Tenant.Id);            
            this.Args.Add("Title", this.Tenant.Title);
        }
    }
}
