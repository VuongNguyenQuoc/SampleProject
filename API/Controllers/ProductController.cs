using API.Models;
using App.ApplicationLayer.ModelsDto;
using App.ApplicationLayer.Products;
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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<Response<ProductDto>> Post([FromBody] ProductDto value)
        {
            Response<ProductDto> response = new Response<ProductDto>();
            try
            {
                response.Object = await _productService.Add(value);
            }
            catch (Exception ex)
            {
                //log error
                response.Errored = true;
                response.ErrorMessage = ex.Message;
            }
            return response;

        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<Response<ProductDto>> Put(Guid id, [FromBody] string title)
        {
            Response<ProductDto> response = new Response<ProductDto>();
            try
            {
                response.Object = await _productService.Update(id, title);
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
