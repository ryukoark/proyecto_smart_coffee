namespace smartcoffe.Application.Features.Promotion.DTos;

public class PromotionCreateDTo
{
    public string Name { get; set; }
    public decimal Amount { get; set; }
    public string type { get; set; }
    public DateOnly startDate { get; set; }
    public DateOnly endDate { get; set; }
    public bool Status { get; set; } = true;
}