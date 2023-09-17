namespace BTUProject.DataAccess
{
    public class Countries
    {

        public Countries()
        {
            Customer = new HashSet<Customer>();
        }
        public Countries(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }

    }
}
