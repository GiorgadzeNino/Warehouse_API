namespace BTUProject.DataAccess
{
    public class OrderItems : Base
    {

        public OrderItems() { }

        public OrderItems(int id, int orderId, int productId, decimal unitPrice, int quantity, bool isDiscounted, decimal discountPrice)
        {
            Id = id;
            OrderId = orderId;
            ProductId = productId;
            UnitPrice = unitPrice;
            Quantity = quantity;
            IsDiscounted = isDiscounted;
            DiscountPrice = discountPrice;
        }

        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public bool IsDiscounted { get; set; }
        public decimal DiscountPrice { get; set; }

        public virtual Orders Orders { get; set; }
        public virtual Product Product { get; set; }

    }
}
