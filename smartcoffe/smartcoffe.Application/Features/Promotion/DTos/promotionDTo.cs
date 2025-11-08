namespace smartcoffe.Application.Promotion.DTos;

public class promotionDTo
{
    public string name { get; set; }
    public decimal amount { get; set; }
    public string type { get; set; }
    public DateOnly startDate { get; set; }
    public DateOnly endDate { get; set; }
}