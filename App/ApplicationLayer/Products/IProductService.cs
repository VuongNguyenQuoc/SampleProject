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
        Task< ProductDto> Add(ProductDto tenant);
       Task< ProductDto> Update(Guid id, string tilte);
    }
}
