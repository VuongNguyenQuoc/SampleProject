
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace App.ApplicationLayer.ModelsDto
{
    public partial class ProductDto
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "The Code is Required")]
        public string Code { get; set; }
        [Required(ErrorMessage = "The Tilte is Required")]
        public string Tilte { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "The Price is Required")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "The TenantId is Required")]
        public Guid TenantId { get; set; }

        //public virtual TenantDto Tenant { get; set; }
    }
}