namespace BTUProject.Dto.Customer
{
    public class MakeRelationshipWithIdDto
    {
        public int Id { get; set; }
        public int StartCustomerId { get; set; }
        public int EndCustomerId { get; set; }
        public int RelationShipTypeId { get; set; }
        public string Comment { get; set; }
    }
}
