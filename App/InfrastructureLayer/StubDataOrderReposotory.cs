using App.ApplicationLayer.ModelsDto;
using App.DomainModelLayer.DbContexts;
using App.DomainModelLayer.Models;
using App.DomainModelLayer.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.InfrastructureLayer
{
    public class StubDataOrderReposotory : MemoryRepository<Order>, IOrderRepository
    {
        private readonly SampleprojectContext _context;
        public StubDataOrderReposotory(SampleprojectContext context) : base(context)
        {
            _context = context;
        }

    

        public IEnumerable<Order> getAllSpe()
        {            
            return  _context.Order.Include(c => c.OrderItem);            
        }

        //public Order AddOrder(Order order)
        //{
        //    throw new NotImplementedException();
        //}

        //public Order AddOrder(Order order)
        //{
        //    try
        //    {
        //        _context.Order.Add(order);
        //        _context.SaveChanges();
        //        return order;
        //    }
        //    catch (Exception)
        //    {
        //        throw;                 
        //    }

        //}

        public Order getByid(Guid id)
        {
            Order order = new Order();
            order = _context.Order.Where(x => x.Id == id).Include(c => c.OrderItem).FirstOrDefault();
            return order;
        }
    }
}
