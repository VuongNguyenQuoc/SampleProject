using App.ApplicationLayer.ModelsDto;
using App.DomainModelLayer.DbContexts;
using App.DomainModelLayer.Models;
using App.DomainModelLayer.Tenants;
using App.Helpers.Repository;
using App.Helpers.Specification;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.InfrastructureLayer
{
    public class StubDataTenantRepository : MemoryRepository<Tenant> , ITenantRepository
    {

        private readonly SampleprojectContext _context;
        public StubDataTenantRepository(SampleprojectContext context):base (context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tenant>> GetAllAsyn()
        {
            return await _context.Tenant.ToListAsync();
        }
    }
}
