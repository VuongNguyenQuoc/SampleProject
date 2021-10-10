using App.DomainModelLayer.Models;
using App.Helpers.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.DomainModelLayer.Tenants
{
    public class TenantAlreadySpec : SpecificationBase<Tenant>
    {
        string _tilte;
    
        public TenantAlreadySpec(string tilte)
        {
             _tilte= tilte;
        }

        public override Expression<Func<Tenant, bool>> SpecExpression
        {
            get
            {
                return tenant => tenant.Title == _tilte;
            }
        }
    }
}
