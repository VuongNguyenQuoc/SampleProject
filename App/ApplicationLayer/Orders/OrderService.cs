using App.ApplicationLayer.ModelsDto;
using App.ApplicationLayer.OrderItems;
using App.DomainModelLayer.Models;
using App.DomainModelLayer.OrderItems;
using App.DomainModelLayer.Orders;
using App.Helpers.Repository;
using App.Helpers.Specification;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationLayer.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderItemService _orderItemService;
        public OrderService(IOrderRepository orderRepository, IOrderItemService orderItemService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _orderRepository = orderRepository;
            _orderItemService = orderItemService;
        }

        public OrderDto Add(OrderDto order)
        {
            Order order1 = Order.Create(order.CustomerId, order.Number, order.TenantId, order.Sum);
            var result = _orderRepository.Add(order1);
            foreach (var item in order.OrderItem)
            {
                OrderItem orderItem = OrderItem.Create(result.Id, item.ProductId, item.Quantity, item.ProductPrice);                
                _orderItemService.Add(_mapper.Map<OrderItem, OrderItemDto>(orderItem));               
            }
            _unitOfWork.Commit();
            return getById(result.Id);
        }

        public IEnumerable<OrderDto> GetAll()
        {
            var result = _orderRepository.getAllSpe();
            return _mapper.Map<IEnumerable<Order>, IEnumerable<OrderDto>>(result);
        }

        public OrderDto getById(Guid id)
        {
            var result = _orderRepository.getByid(id);
            return _mapper.Map<Order, OrderDto>(result);
            // return result;
        }
    }
}
