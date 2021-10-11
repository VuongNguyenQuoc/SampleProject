using App.ApplicationLayer.ModelsDto;
using App.DomainModelLayer.DbContexts;
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
        private OrderDto _order;
        private readonly SampleprojectContext _context;
        public OrderAlreadySpec(SampleprojectContext context, OrderDto order )
        {
            _order = order;
            _context = context;
        }
        
        public bool CheckMaxOrderItem()
        {
            if(_order.OrderItem.Count()>5 && _order.OrderItem!=null)
            {
                return true;
            }
                
            return false;
        }
        public bool CheckUniqueItem()
        {         
            if (_order.OrderItem.GroupBy(x => x.ProductId).Any(g => g.Count() > 1))                
            {
                return true;
            }

            return false;
        }
        public long GetRowNumber()
        {
            long RowIndex =1;
            var result = _context.Order.Where(x => x.TenantId == _order.TenantId).FirstOrDefault();
            if(result!=null)
            {
                RowIndex = result.Number + 1;
            }
            return RowIndex;
        }



        public override Expression<Func<Order, bool>> SpecExpression => throw new NotImplementedException();
    }
}
