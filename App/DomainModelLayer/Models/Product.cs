
using App.DomainModelLayer.Products;
using App.Helpers.Domain;
using System;
using System.Collections.Generic;

#nullable disable

namespace App.DomainModelLayer.Models
{
    public partial class Product: IAggregateRoot
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Tilte { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Guid TenantId { get; set; }

        //public virtual Tenant Tenant { get; set; }
        public static Product Create(string code, string tilte, string description, decimal price, Guid tenantId)
        {
            return Create(Guid.NewGuid(), code, tilte, description, price, tenantId);
        }

        public static Product Create(Guid id, string code, string tilte, string description, decimal price, Guid tenanId)
        {
            Product product = new Product()
            {
                Id = id,
                Code = code,
                Tilte = tilte,
                Description = description,
                Price = price,
                TenantId = tenanId,
            };

            DomainEvents.Raise<ProductCreated>(new ProductCreated() { product = product });

            return product;
        }
    }
}