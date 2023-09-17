namespace BTUProject.DataAccess
{
    public class ProductCategories
    {

        public ProductCategories()
        {
            Product = new HashSet<Product>();
        }

        public ProductCategories(int id, string code, string name) : this()
        {
            Id = id;
            Code = code;
            Name = name;
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
