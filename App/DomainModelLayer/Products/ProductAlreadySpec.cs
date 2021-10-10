using App.DomainModelLayer.Models;
using App.Helpers.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.DomainModelLayer.Products
{
    public class ProductAlreadySpec : SpecificationBase<Product>
    {
        private string _code;
        private Guid _tenantId;
       
        public ProductAlreadySpec(string code, Guid tenantId)
        {
            _code = code;
            _tenantId = tenantId;
        
        }
        public override Expression<Func<Product, bool>> SpecExpression
        {
            get
            {
                return product => product.Code == _code & product.TenantId == _tenantId ;
            }
        }
    }
}
