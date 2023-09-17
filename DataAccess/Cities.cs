namespace BTUProject.DataAccess
{
    public class Cities
    {
        public Cities()
        {

        }

        public Cities(int id, string name) : this()
        {
            Id = id;
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
