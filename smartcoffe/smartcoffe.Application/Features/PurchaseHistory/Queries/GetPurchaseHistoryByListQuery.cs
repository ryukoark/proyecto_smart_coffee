using MediatR;
using smartcoffe.Application.Features.PurchaseHistory.DTOs;
using smartcoffe.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace smartcoffe.Application.PurchaseHistory.Queries;

// Simple query that returns all PurchaseHistory records (mapped to DTOs)
public class GetPurchaseHistoryByListQuery : IRequest<IEnumerable<PurchaseHistoryListDto>>
{
}

internal sealed class GetPurchaseHistoryByListQueryHandler : IRequestHandler<GetPurchaseHistoryByListQuery, IEnumerable<PurchaseHistoryListDto>>
{
	private readonly IUnitOfWork _unitOfWork;

	public GetPurchaseHistoryByListQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

	public async Task<IEnumerable<PurchaseHistoryListDto>> Handle(GetPurchaseHistoryByListQuery request, CancellationToken cancellationToken)
	{
		var all = await _unitOfWork.PurchaseHistories.GetAllAsync();

		// Map domain entities to DTOs in memory. This returns every purchase history (no filters).
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