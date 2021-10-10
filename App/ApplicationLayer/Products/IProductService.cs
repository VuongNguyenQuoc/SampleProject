using App.ApplicationLayer.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationLayer.Products
{
    public interface IProductService
    {
        ProductDto Add(ProductDto tenant);
        ProductDto Update(Guid id, string tilte);
    }
}
