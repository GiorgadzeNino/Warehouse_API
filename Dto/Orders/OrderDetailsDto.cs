using System;

namespace BTUProject.Dto.Orders
{
    public class OrderDetailsDto
    {
        public int OrderId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public int CategoryId { get; set; }

    }
}
