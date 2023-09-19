namespace BTUProject.Dto.Products
{
    public class ProductDetailsDto
    {
        //(კოდი, დასახელება, ერთეულის ფასი, საზომი ერთეული, რაოდენობა);
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int UnitId { get; set; }
        public int Quantity { get; set; }
    }
}
