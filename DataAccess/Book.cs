namespace BTUProject.DataAccess
{
    public class Book : Product
    {
        public Book() { }
        public Book(string description, string author, decimal price, string publishingHouse, int publishingYear, int recommendedAge)
        {
            Description = description;
            Author = author;
            Price = price;
            PublishingHouse = publishingHouse;
            PublishingYear = publishingYear;
            RecommendedAge = recommendedAge;
        }

        public int ProductId { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public string PublishingHouse { get; set; }
        public int PublishingYear { get; set; }
        public int RecommendedAge { get; set; }
    }
}
