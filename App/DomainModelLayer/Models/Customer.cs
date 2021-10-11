
using App.DomainModelLayer.Customers;
using App.Helpers.Domain;
using System;
using System.Collections.Generic;

#nullable disable

namespace App.DomainModelLayer.Models
{
    public class Customer : IAggregateRoot
    {

        public Customer()
        {
            Order = new HashSet<Order>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid TenantId { get; set; }

        public virtual Tenant Tenant { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        public static Customer Create(Guid id, string title, Guid tenantId)
        {
            Customer customer = new Customer()
            {
                Id = id,
                Title = title,
                TenantId = tenantId
            };

            DomainEvents.Raise<CustomerCreated>(new CustomerCreated() { Customer = customer });

            return customer;
        }
    }
}