using App.ApplicationLayer.ModelsDto;
using App.DomainModelLayer.Customers;
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

namespace App.ApplicationLayer.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper,IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _customerRepository = customerRepository;
        }
        public CustomerDto Add(CustomerDto customerDto)
        {
            ISpecification<Customer> alreadyCus = new CustomerAlreadySpec(customerDto.Title,customerDto.TenantId);

            Customer existingTenant = _customerRepository.FindOne(alreadyCus);
            if (existingTenant != null)
                throw new Exception("Customer with this tile already exists");
            Customer cus = Customer.Create(Guid.NewGuid(), customerDto.Title,customerDto.TenantId);
            var result = _customerRepository.Add(cus);
            _unitOfWork.Commit();
            return _mapper.Map<Customer, CustomerDto>(result);
        }
    }
}
