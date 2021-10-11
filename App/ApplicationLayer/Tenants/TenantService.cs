using App.ApplicationLayer.ModelsDto;
using App.DomainModelLayer.Models;
using App.DomainModelLayer.Tenants;
using App.Helpers.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using App.Helpers.Repository;
using App.DomainModelLayer.DbContexts;
using App.InfrastructureLayer;

namespace App.ApplicationLayer.Tenants
{
    public class TenantService :  ITenantService
    {
        private readonly ITenantRepository _tenantRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        //private readonly SampleprojectContext _context;
        public TenantService ( ITenantRepository tenantRepository,IUnitOfWork unitOfWork, IMapper mapper)
        {
          
            _tenantRepository = tenantRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<TenantDto> Add(TenantDto tenant)
        {
            ISpecification<Tenant> alreadyTenant = new TenantAlreadySpec(tenant.Title);

            Tenant existingTenant = _tenantRepository.FindOne(alreadyTenant);
            if (existingTenant != null)
                throw new Exception("Tenant with this title already exists");
            Tenant tenant1 = Tenant.Create(Guid.NewGuid(), tenant.Title);
            var result= _tenantRepository.Add(tenant1);
            await _unitOfWork.Commit();
            return  _mapper.Map<Tenant, TenantDto>(result.Result);            
        }     

        public async Task<IEnumerable<TenantDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<TenantDto>> (await _tenantRepository.GetAllAsyn());
        }
    }
}
