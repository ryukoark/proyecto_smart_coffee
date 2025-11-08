namespace smartcoffe.Application.Promotion.DTos;

public class promotionUpdateDTo
{
    public int id { get; set; }
    public string name { get; set; }
    public decimal amount { get; set; }
    public string type { get; set; }
    public DateOnly startDate { get; set; }
    public DateOnly endDate { get; set; }
    public bool Status { get; set; }
}