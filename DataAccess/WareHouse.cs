namespace BTUProject.DataAccess
{
    public class WareHouse : Base
    {
        public WareHouse()
        { }

        public WareHouse(int id, string docNumber, DateTime operationDate, int productId, int supplierId, int unitId, int quantity, DateTime expiryDate, decimal unitPrice, decimal realizationPrice)
        {
            Id = id;
            DocNumber = docNumber;
            OperationDate = operationDate;
            ProductId = productId;
            SupplierId = supplierId;
            UnitId = unitId;
            Quantity = quantity;
            ExpiryDate = expiryDate;
            UnitPrice = unitPrice;
            RealizationPrice = realizationPrice;
        }

        public int Id { get; set; }
        public string DocNumber { get; set; }
        public DateTime OperationDate { get; set; }
        public int ProductId { get; set; }
        public int SupplierId { get; set; }
        public int UnitId { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal RealizationPrice { get; set; }
        public virtual Suppliers Suppliers { get; private set; }
        public virtual Units Units { get; private set; }
        public virtual Product Product { get; set; }
    }
}
