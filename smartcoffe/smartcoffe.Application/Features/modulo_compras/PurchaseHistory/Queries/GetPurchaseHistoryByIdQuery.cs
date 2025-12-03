using MediatR;
using smartcoffe.Application.Features.modulo_compras.PurchaseHistory.DTOs;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.modulo_compras.PurchaseHistory.Queries;

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
		var e = await _unitOfWork.Repository<Domain.Entities.PurchaseHistory>().GetByIdAsync(request.Id);
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