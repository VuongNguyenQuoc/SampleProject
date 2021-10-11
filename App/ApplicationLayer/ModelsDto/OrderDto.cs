
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace App.ApplicationLayer.ModelsDto
{
    public partial class OrderDto
    {
        public OrderDto()
        {
            OrderItem = new HashSet<OrderItemDto>();
        }

        public Guid Id { get; set; }
        [Required(ErrorMessage = "The Customer is Required")]
        public Guid CustomerId { get; set; }

        public long Number { get; set; }
        [Required(ErrorMessage = "The Tenant is Required")]
        public Guid TenantId { get; set; }
        public decimal Sum { get; set; }

        //public virtual CustomerDto Customer { get; set; }
        public virtual ICollection<OrderItemDto> OrderItem { get; set; }
    }
}