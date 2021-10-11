
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace App.ApplicationLayer.ModelsDto
{
    public partial class CustomerDto
    {
        //public CustomerDto()
        //{
        //    Order = new HashSet<OrderDto>();
        //}

        public Guid Id { get; set; }
        [Required(ErrorMessage = "The Title is Required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "The Tenant is Required")]
        public Guid TenantId { get; set; }

        //public virtual TenantDto Tenant { get; set; }
        //public virtual ICollection<OrderDto> Order { get; set; }
    }
}