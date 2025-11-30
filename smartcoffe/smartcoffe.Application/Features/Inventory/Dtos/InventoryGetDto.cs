namespace smartcoffe.Application.Features.Inventory.DTOs
{
    public class InventoryGetDto
    {
        public int Id { get; set; }                 
        public int Quantity { get; set; }            
        public int IdCafe { get; set; }              
        public int IdProduct { get; set; }           
        public int IdSupplier { get; set; }          
        public string Status { get; set; }           
    }
}