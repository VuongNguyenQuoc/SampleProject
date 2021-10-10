using App.DomainModelLayer.Models;
using App.Helpers.Domain;
using App.Helpers.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.DomainModelLayer.Customers
{
    public class CustomerAlreadySpec : SpecificationBase<Customer>
    {
        
        string _tilte;
        Guid _tenantId;

        public CustomerAlreadySpec(string tilte, Guid tenantId)
        {
            _tilte = tilte;
            _tenantId = tenantId;
        }

        //public override Expression<Func<Tenant, bool>> SpecExpression
        //{
        //    get
        //    {
        //        return tenant => tenant.Title == _tilte;
        //    }
        //}

        public override Expression<Func<Customer, bool>> SpecExpression
        {
            get { return Cus => Cus.Title == _tilte & Cus.TenantId == _tenantId; }
        }
    }
}
