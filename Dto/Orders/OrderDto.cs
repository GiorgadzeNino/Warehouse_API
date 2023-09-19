using System;

namespace BTUProject.Dto.Orders
{
    public class OrderDto
    {
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
