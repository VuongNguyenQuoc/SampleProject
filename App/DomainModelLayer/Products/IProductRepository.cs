using App.DomainModelLayer.Models;
using App.Helpers.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DomainModelLayer.Products
{
    public interface IProductRepository : IRepository<Product>
    {
        Product Update(Guid id, string tilte);
    }
}
