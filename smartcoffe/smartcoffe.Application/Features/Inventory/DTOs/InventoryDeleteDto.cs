namespace smartcoffe.Application.Features.Inventory.DTOs
{
    public class InventoryDeleteDto
    {
        public int Id { get; set; }                  
        public string? Reason { get; set; }          
        public string? DeletedBy { get; set; }       
        public string Status { get; set; } = "Inactive"; 
    }
}