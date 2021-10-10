using API.Models;
using App.ApplicationLayer.Customers;
using App.ApplicationLayer.ModelsDto;
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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _cusService;

        public CustomerController(ICustomerService cusService)
        {
            _cusService = cusService;
        }

        // POST api/<CustomerController>
        [HttpPost]
        public Response<CustomerDto> Post([FromBody] CustomerDto value)
        {            
            Response<CustomerDto> response = new Response<CustomerDto>();
            try
            {
                response.Object = _cusService.Add(value);
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
