namespace BTUProject.DataAccess
{
    public class Orders : Base
    {
        public Orders()
        {
            OrderItems = new HashSet<OrderItems>();
        }
        public Orders(int id, DateTime orderDate, string orderNumber, int customerId, decimal totalAmount, ICollection<OrderItems> orderItems)
        {
            Id = id;
            OrderDate = orderDate;
            OrderNumber = orderNumber;
            CustomerId = customerId;
            TotalAmount = totalAmount;
            OrderItems = orderItems;
        }

        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public virtual ICollection<OrderItems> OrderItems { get; private set; }
        public virtual Customer Customer { get; set; }

        public Orders AddOrderItem(params OrderItems[] orderItems)
        {

            foreach (var oi in orderItems)
            {
                OrderItems.Add(oi);
            }
            return this;
        }
    }
}
