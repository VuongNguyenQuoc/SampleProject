using App.DomainModelLayer.DbContexts;
using App.DomainModelLayer.Models;
using App.Helpers.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.DomainModelLayer.OrderItems
{
    public class OrderItemAlreadySpec : SpecificationBase<OrderItem>
    {
        private Guid _id;
        private decimal _price;
        private int _qty;
        private readonly SampleprojectContext _context;
        public OrderItemAlreadySpec(SampleprojectContext context, Guid id, int qty, decimal price)
        {
            _id = id;
            _price = price;
            _qty = qty;
            _context = context;
        }

        public bool CheckQty()
        {
            if (_qty < 1)
            {
                return true;
            }
            return false;
        }
        public bool CheckPrice()
        {
            var orderItem= _context.OrderItem.Where(x => x.Id == _id).FirstOrDefault();
            if(orderItem!=null)
            {
                if(orderItem.ProductPrice!=_price)
                {
                    return true;
                }
            }

            return false;
        }


        public override Expression<Func<OrderItem, bool>> SpecExpression
        {
            get
            {
                return orderItem => orderItem.Id == _id;
            }
        }
    }
}
