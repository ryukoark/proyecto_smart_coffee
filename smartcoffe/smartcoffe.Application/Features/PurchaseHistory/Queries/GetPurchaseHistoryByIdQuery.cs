using MediatR;
using smartcoffe.Application.Features.PurchaseHistory.DTOs;
using smartcoffe.Domain.Interfaces;


namespace smartcoffe.Application.PurchaseHistory.Queries;

public class GetPurchaseHistoryByIdQuery : IRequest<PurchaseHistoryGetDto?>
{
	public int Id { get; set; }
}

internal sealed class GetPurchaseHistoryByIdQueryHandler : IRequestHandler<GetPurchaseHistoryByIdQuery, PurchaseHistoryGetDto?>
{
	private readonly IUnitOfWork _unitOfWork;

	public GetPurchaseHistoryByIdQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

	public async Task<PurchaseHistoryGetDto?> Handle(GetPurchaseHistoryByIdQuery request, CancellationToken cancellationToken)
	{
		var e = await _unitOfWork.PurchaseHistories.GetByIdAsync(request.Id);
		if (e is null) return null;

		return new PurchaseHistoryGetDto
		{
			Id = e.Id,
			IdUser = e.Iduser,
			IdShopping = e.Idshopping,
			IdPayment = e.IdPayment,
			Status = e.Status
		};
	}
}