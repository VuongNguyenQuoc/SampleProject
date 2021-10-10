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
        TenantDto Add(TenantDto tenant);
        IEnumerable<TenantDto> GetAll();
    }
}
