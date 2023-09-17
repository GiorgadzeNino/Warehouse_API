namespace BTUProject.DataAccess
{
    public class Cities
    {
        public Cities()
        {
            Customer = new HashSet<Customer>();
        }

        public Cities(int id, string name) : this()
        {
            Id = id;
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }

    }
}
