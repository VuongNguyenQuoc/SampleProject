
using System;
using System.Collections.Generic;

#nullable disable

namespace App.ApplicationLayer.ModelsDto
{
    public partial class OrderItemDto
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal Cost { get; set; }

        //public virtual OrderDto Order { get; set; }
    }
}