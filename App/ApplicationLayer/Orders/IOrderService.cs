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
        Task<OrderDto> Add(OrderDto order);
        Task<OrderDto> getById(Guid id);
        Task<IEnumerable< OrderDto>> GetAllBySum(int min, int max);
        Task<IEnumerable<OrderDto>> GetAll();
    }
}
