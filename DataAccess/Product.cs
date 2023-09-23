namespace BTUProject.DataAccess
{
    public class Product : Base
    {
        public Product()
        {
            WareHouse = new HashSet<WareHouse>();
        }

        public Product(int id, string code, string name, int categoryId)
        {
            Id = id;
            Code = code;
            Name = name;
            CategoryId = categoryId;
        }


        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public virtual ProductCategories ProductCategories { get; set; }
        public ICollection<WareHouse> WareHouse { get; set; }


        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Product other = (Product)obj;
            return Id == other.Id;
        }
    }

}


