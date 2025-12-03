namespace smartcoffe.Application.Features.modulo_productos_inventarios.Inventory.Dtos
{
    public class InventoryDeleteDto
    {
        public int Id { get; set; }                  
        public string? Reason { get; set; }          
        public string? DeletedBy { get; set; }       
        public string Status { get; set; } = "Inactive"; 
    }
}