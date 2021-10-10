using App.DomainModelLayer.DbContexts;
using App.DomainModelLayer.Models;
using App.DomainModelLayer.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.InfrastructureLayer
{
    public class StubDataProductRepository : MemoryRepository<Product>, IProductRepository
    {
        private readonly SampleprojectContext _context;
        public StubDataProductRepository(SampleprojectContext context) : base(context)
        {
            _context = context;

        }

        public Product Update(Guid id, string tilte)
        {
            Product product = _context.Product.Find(id);
            product.Tilte = tilte;
           _context.Product.Update(product);
            _context.SaveChanges();
            return product;
        }
    }
}
