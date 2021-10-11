
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace App.ApplicationLayer.ModelsDto
{
    public partial class TenantDto
    {
        //public TenantDto()
        //{
        //    Customer = new HashSet<CustomerDto>();
        //    Product = new HashSet<ProductDto>();
        //}

        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Title is Required")]
        public string Title { get; set; }

        //public virtual ICollection<CustomerDto> Customer { get; set; }
        //public virtual ICollection<ProductDto> Product { get; set; }
    }
}