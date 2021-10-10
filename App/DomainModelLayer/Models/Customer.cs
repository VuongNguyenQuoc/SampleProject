﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using App.DomainModelLayer.Customers;
using App.Helpers.Domain;
using System;
using System.Collections.Generic;

#nullable disable

namespace App.DomainModelLayer.Models
{
    public class Customer : IAggregateRoot
    {
        
        public virtual Guid Id { get;  set; }
        public virtual string Title { get;  set; }
        public virtual Guid TenantId { get;  set; }
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