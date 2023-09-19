using System;

namespace BTUProject.Dto.Orders
{
    public class OrderItemDto
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public bool IsDiscounted { get; set; } = false;
        public decimal DiscountPrice { get; set; }


    }
}
