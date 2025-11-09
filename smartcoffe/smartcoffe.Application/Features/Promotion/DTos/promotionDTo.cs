namespace smartcoffe.Application.Features.Promotion.DTos;

public class PromotionDTo
{
    public string name { get; set; }
    public decimal amount { get; set; }
    public string type { get; set; }
    public DateOnly startDate { get; set; }
    public DateOnly endDate { get; set; }
}