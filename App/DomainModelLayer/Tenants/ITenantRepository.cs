using App.ApplicationLayer.ModelsDto;
using App.DomainModelLayer.Models;
using App.Helpers.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DomainModelLayer.Tenants
{
    public interface ITenantRepository : IRepository<Tenant>
    {
        Task<IEnumerable<Tenant>> GetAllAsyn();
    }
}
