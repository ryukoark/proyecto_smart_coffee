using MediatR;

namespace smartcoffe.Application.Features.Reports.ProductsExpiring
{
    public class ProductsExpiringQuery : IRequest<byte[]>
    {
        public int Days { get; set; }
        public ProductsExpiringQuery(int days) => Days = days;
    }
}