using App.ApplicationLayer.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationLayer.Tenants
{
    public interface ITenantService
    {
        Task< TenantDto> Add(TenantDto tenant);
        Task< IEnumerable<TenantDto>> GetAll();
    }
}
