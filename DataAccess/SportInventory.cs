namespace BTUProject.DataAccess
{
    public class SportInventory : Product
    {
        public SportInventory() { }
        public SportInventory(int productId, string description, decimal price, int recommentddedAge)
        {
            ProductId = productId;
            Description = description;
            Price = price;
            RecommentddedAge = recommentddedAge;
        }

        public int ProductId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int RecommentddedAge { get; set; }
    }
}
