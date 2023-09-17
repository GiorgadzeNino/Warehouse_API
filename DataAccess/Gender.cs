namespace BTUProject.DataAccess
{
    public class Gender
    {
        public Gender()
        {
            Customer = new HashSet<Customer>();
        }
        public Gender(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }

    }
}
