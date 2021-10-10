using App.ApplicationLayer.ModelsDto;
using App.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationLayer.Orders
{
    public interface IOrderService
    {
        OrderDto Add(OrderDto order);
        OrderDto getById(Guid id);
        IEnumerable< OrderDto> GetAll();
    }
}
