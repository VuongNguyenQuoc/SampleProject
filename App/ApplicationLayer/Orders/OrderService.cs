using App.ApplicationLayer.ModelsDto;
using App.ApplicationLayer.OrderItems;
using App.DomainModelLayer.DbContexts;
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
        private readonly SampleprojectContext _context;
        public OrderService(SampleprojectContext context , IOrderRepository orderRepository, IOrderItemService orderItemService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _orderRepository = orderRepository;
            _orderItemService = orderItemService;
            _context = context;
        }

        public async Task<OrderDto> Add(OrderDto order)
        {
            try
            {
                var orderCheck = new OrderAlreadySpec(_context,order);
                if (orderCheck.CheckMaxOrderItem())
                {
                    throw new Exception("One Order can not contain more than 5 Items");
                }
                else if (orderCheck.CheckUniqueItem())
                {
                    throw new Exception("Duplicate product in order");
                }               
                
                Order order1 = Order.Create(order.CustomerId, orderCheck.GetRowNumber(), order.TenantId, order.Sum);

                var result = _orderRepository.Add(order1);
                foreach (var item in order.OrderItem)
                {
                    OrderItem orderItem = OrderItem.Create(result.Result.Id, item.ProductId, item.Quantity, item.ProductPrice);
                    await _orderItemService.Add(_mapper.Map<OrderItem, OrderItemDto>(orderItem));
                }
                order1.Sum = order.OrderItem.Sum(x => x.Quantity * x.Cost);
                await _unitOfWork.Commit();
                return getById(result.Result.Id).Result;
            }
            catch (Exception )
            {
                throw new Exception("Duplicate product in order");
            }         
        }

        public async Task<IEnumerable<OrderDto>> GetAll()
        {
            var result = await _orderRepository.getAllSpe();
            return _mapper.Map<IEnumerable<Order>, IEnumerable<OrderDto>>(result);
        }

        public async Task< IEnumerable<OrderDto>> GetAllBySum(int SumMin, int SumMax)
        {
            var result = await _orderRepository.getAllBySum(SumMin, SumMax);
            return _mapper.Map<IEnumerable<Order>, IEnumerable<OrderDto>>(result);
        }

        public async Task< OrderDto> getById(Guid id)
        {
            var result = await _orderRepository.getByid(id);
            return _mapper.Map<Order, OrderDto>(result);
            // return result;
        }
    }
}
