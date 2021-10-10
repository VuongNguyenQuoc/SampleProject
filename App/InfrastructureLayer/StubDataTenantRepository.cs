using App.ApplicationLayer.ModelsDto;
using App.DomainModelLayer.DbContexts;
using App.DomainModelLayer.Models;
using App.DomainModelLayer.Tenants;
using App.Helpers.Repository;
using App.Helpers.Specification;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.InfrastructureLayer
{
    public class StubDataTenantRepository : MemoryRepository<Tenant> , ITenantRepository
    {    
       
        public StubDataTenantRepository(SampleprojectContext context):base (context)
        {     

        }       
    }
}
