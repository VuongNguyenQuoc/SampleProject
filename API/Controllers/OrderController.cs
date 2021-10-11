using API.Models;
using App.ApplicationLayer.ModelsDto;
using App.ApplicationLayer.OrderItems;
using App.ApplicationLayer.Orders;
using App.DomainModelLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IOrderItemService _orderItemService;

        public OrderController(IOrderService orderService, IOrderItemService orderItemService)
        {
            _orderService = orderService;
            _orderItemService = orderItemService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task< OrderDto> GetById(Guid id)
        {
            return await _orderService.getById(id);
        }
        [HttpGet("GetOrderBySum")]
        public async Task<IEnumerable< OrderDto>> GetBySum(int SumMin , int SumMax)
        {
            return await _orderService.GetAllBySum(SumMin,SumMax);
        }
        [HttpGet]
        public async Task<IEnumerable<OrderDto>> GetAll()
        {
            return await _orderService.GetAll();
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task< Response<OrderDto>> Post([FromBody] OrderDto value)
        {
            Response<OrderDto> response = new Response<OrderDto>();
            try
            {
                response.Object = await _orderService.Add(value);
            }
            catch (Exception ex)
            {
                //log error
                response.Errored = true;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        // Order Item
        [HttpPut("UpdateOrderItem/{id}")]
        public async Task< Response<OrderItemDto>> UpdateOrderItem(Guid id ,[FromBody] OrderItemDto value)
        {
            Response<OrderItemDto> response = new Response<OrderItemDto>();
            try
            {
                response.Object = await _orderItemService.UpdateQty(id,value.Quantity);
            }
            catch (Exception ex)
            {
                //log error
                response.Errored = true;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        // Order Item
        [HttpDelete("RemoveOrderItem")]
        public Response<bool> RemoveOrderItem([FromBody] OrderItemDto value)
        {
            Response<bool> response = new Response<bool>();
            try
            {
                response.Object = _orderItemService.Remove(value);
            }
            catch (Exception ex)
            {
                //log error
                response.Errored = true;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }
    }
}
