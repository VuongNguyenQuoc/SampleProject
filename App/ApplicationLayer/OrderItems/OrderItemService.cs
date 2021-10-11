using App.ApplicationLayer.ModelsDto;
using App.DomainModelLayer.DbContexts;
using App.DomainModelLayer.Models;
using App.DomainModelLayer.OrderItems;
using App.DomainModelLayer.Orders;
using App.DomainModelLayer.Tenants;
using App.Helpers.Repository;
using App.Helpers.Specification;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationLayer.OrderItems
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly SampleprojectContext _context;
        public OrderItemService(SampleprojectContext context, IOrderItemRepository orderService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _orderItemService = orderService;
            _context = context;
        }
        public async Task< OrderItemDto> Add(OrderItemDto orderItems)
        {
            var checkOrderItem = new OrderItemAlreadySpec(_context, orderItems.Id, orderItems.Quantity, orderItems.ProductPrice);

            if (checkOrderItem.CheckPrice())
            {
                throw new Exception("Price of Product in Item can not be changed");
            }
            if (checkOrderItem.CheckQty())
            {
                throw new Exception("Quantity can not be less than 1");
            }

            OrderItem orderItems1 = OrderItem.Create(orderItems.OrderId, orderItems.ProductId, orderItems.Quantity, orderItems.ProductPrice);
            var result = _orderItemService.Add(orderItems1);
            await _unitOfWork.Commit();
            return _mapper.Map<OrderItem, OrderItemDto>(result.Result);
        }
        public bool Remove(OrderItemDto orderItem)
        {
            return _orderItemService.Remove(_mapper.Map<OrderItemDto, OrderItem>(orderItem));
        }

        public async Task< OrderItemDto> UpdateQty(Guid id, int qty)
        {
            var result = await _orderItemService.UpdateQty(id, qty);
            await _unitOfWork.Commit();
            return _mapper.Map<OrderItem, OrderItemDto>(result);
        }
    }
}
