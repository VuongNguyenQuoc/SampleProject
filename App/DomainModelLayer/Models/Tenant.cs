
using App.DomainModelLayer.Tenants;
using App.Helpers.Domain;
using System;
using System.Collections.Generic;

#nullable disable

namespace App.DomainModelLayer.Models
{
    public partial class Tenant : IAggregateRoot
    {
        public Tenant()
        {
            Customer = new HashSet<Customer>();
            Product = new HashSet<Product>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<Product> Product { get; set; }
        public static Tenant Create(Guid id, string title)
        {
            Tenant tenant = new Tenant()
            {
                Id = id,
                Title = title,
            };

            DomainEvents.Raise<TenantCreated>(new TenantCreated() { Tenant = tenant });
            return tenant;
        }
    }
}