namespace BTUProject.Dto.Products
{
    public class AddProductToWarehouseDto
    {
        public string DocNumber { get; set; }
        public DateTime OperationDate { get; set ; } = DateTime.Now;
        public int ProductId { get; set; }
        public int SupplierId { get; set; }
        public int UnitId { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal RealizationPrice { get; set; }

    }
}
