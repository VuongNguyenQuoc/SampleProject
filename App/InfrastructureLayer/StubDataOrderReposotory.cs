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



        public async Task<IEnumerable<Order>> getAllBySum(int SumMin, int SumMax)
        {
            return await _context.Order.Where(x => x.Sum >= SumMin & x.Sum <= SumMax).Include(c => c.OrderItem).ToArrayAsync();
        }

        public async Task<IEnumerable<Order>> getAllSpe()
        {
            return await _context.Order.Include(c => c.OrderItem).ToArrayAsync();
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

        public async Task<Order> getByid(Guid id)
        {
            Order order = new Order();
            order = await _context.Order.Where(x => x.Id == id).Include(c => c.OrderItem).FirstOrDefaultAsync();
            return order;
        }
    }
}
