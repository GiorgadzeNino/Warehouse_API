namespace BTUProject.DataAccess
{
    public class Toy : Product
    {

        public Toy() { }

        public Toy(int productId, string description, decimal price, string manufacturer, string material, int recommendedAge)
        {
            ProductId = productId;
            Description = description;
            Price = price;
            Manufacturer = manufacturer;
            Material = material;
            RecommendedAge = recommendedAge;
        }

        public void getName()
        {
            Console.WriteLine("Toy is " + Name);
        }

        public int ProductId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Manufacturer { get; set; }
        public string Material { get; set; }
        public int RecommendedAge { get; set; }
    }
}
