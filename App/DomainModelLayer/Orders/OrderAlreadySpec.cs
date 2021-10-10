using App.DomainModelLayer.Models;
using App.Helpers.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.DomainModelLayer.Orders
{
    public class OrderAlreadySpec : SpecificationBase<Order>
    {
       
        public OrderAlreadySpec()
        {
         
        }
       
        public override Expression<Func<Order, bool>> SpecExpression => throw new NotImplementedException();
    }
}
