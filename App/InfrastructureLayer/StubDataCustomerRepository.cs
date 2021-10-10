using App.DomainModelLayer.Customers;
using App.DomainModelLayer.DbContexts;
using App.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.InfrastructureLayer
{
    public class StubDataCustomerRepository: MemoryRepository<Customer>, ICustomerRepository
    {
        public StubDataCustomerRepository(SampleprojectContext context) : base(context)
        {

        }
    }
}
