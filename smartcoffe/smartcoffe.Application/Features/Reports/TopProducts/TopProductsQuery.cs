using MediatR;

namespace smartcoffe.Application.Features.Reports.TopProducts
{
    public class TopProductsQuery : IRequest<byte[]>
    {
        public int Limit { get; set; }
        public TopProductsQuery(int limit) => Limit = limit;
    }
}