using MediatR;
using smartcoffe.Application.Features.modulo_compras.PurchaseHistory.DTOs;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.modulo_compras.PurchaseHistory.Queries;

public class GetPurchaseHistoryByListQuery : IRequest<IEnumerable<PurchaseHistoryListDto>>
{
}

internal sealed class GetPurchaseHistoryByListQueryHandler : IRequestHandler<GetPurchaseHistoryByListQuery, IEnumerable<PurchaseHistoryListDto>>
{
	private readonly IUnitOfWork _unitOfWork;

	public GetPurchaseHistoryByListQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

	public async Task<IEnumerable<PurchaseHistoryListDto>> Handle(GetPurchaseHistoryByListQuery request, CancellationToken cancellationToken)
	{
		var all = await _unitOfWork.Repository<Domain.Entities.PurchaseHistory>().GetAllAsync();

		var list = all.Select(e => new PurchaseHistoryListDto
		{
			Id = e.Id,
			IdUser = e.Iduser,
			IdShopping = e.Idshopping,
			IdPayment = e.IdPayment,
			Status = e.Status
		}).ToList();

		return list;
	}
}