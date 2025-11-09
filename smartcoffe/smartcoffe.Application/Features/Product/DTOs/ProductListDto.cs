namespace smartcoffe.Application.Features.Product.DTOs
{
    // Este DTO es más ligero, para listas (ej. GetAll)
    public class ProductListDto
    {
        public int Id { get; set; }
        public string Productname { get; set; } = null!;
        public decimal Price { get; set; }
        public bool Status { get; set; }
    }
}