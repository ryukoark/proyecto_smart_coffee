using MediatR;
using smartcoffe.Application.Features.modulo_compras.PurchaseHistory.DTOs;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.modulo_compras.PurchaseHistory.Commands;

public record CreatePurchaseHistoryCommand(PurchaseHistoryCreateDto Dto) : IRequest<int>;

internal sealed class CreatePurchaseHistoryCommandHandler : IRequestHandler<CreatePurchaseHistoryCommand, int>
{
	private readonly IUnitOfWork _unitOfWork;

	public CreatePurchaseHistoryCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

	public async Task<int> Handle(CreatePurchaseHistoryCommand request, CancellationToken cancellationToken)
	{
		var dto = request.Dto;

		var entity = new Domain.Entities.PurchaseHistory
		{
			Iduser = dto.IdUser,
			Idshopping = dto.IdShopping,
			IdPayment = dto.IdPayment,
			Status = dto.Status ?? true
		};

		await _unitOfWork.Repository<Domain.Entities.PurchaseHistory>().AddAsync(entity);
		await _unitOfWork.CompleteAsync();

		return entity.Id;
	}
}