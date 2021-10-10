using App.ApplicationLayer.ModelsDto;
using App.DomainModelLayer.Models;
using App.Helpers.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DomainModelLayer.Orders
{
    public interface IOrderRepository : IRepository<Order>
    {
        public Order getByid(Guid id);
        //public Order AddOrder(Order order);
        public IEnumerable<Order> getAllSpe();
    }
}
