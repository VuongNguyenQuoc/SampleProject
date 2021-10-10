using API.Models;
using App.ApplicationLayer.ModelsDto;
using App.ApplicationLayer.Tenants;
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

    public class TenantController : ControllerBase
    {
        private readonly ITenantService _tenantService;

        public TenantController(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }
        // GET: api/<TenantController>
        [HttpGet]
        public IEnumerable<TenantDto> GetAll()
        {
            return _tenantService.GetAll();
        }
       
        // POST api/<TenantController>
        [HttpPost]
        public Response<TenantDto> Post([FromBody] TenantDto value)
        {
            Response<TenantDto> response = new Response<TenantDto>();
            try
            {
                response.Object = _tenantService.Add(value);
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
