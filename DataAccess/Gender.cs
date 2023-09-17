namespace BTUProject.DataAccess
{
    public class Gender
    {
        public Gender()
        {
        }
        public Gender(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
