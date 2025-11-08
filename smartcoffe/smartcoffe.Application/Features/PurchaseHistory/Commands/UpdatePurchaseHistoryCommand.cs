using MediatR;
using smartcoffe.Application.Features.PurchaseHistory.DTOs;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.PurchaseHistory.Commands;

public record UpdatePurchaseHistoryCommand(PurchaseHistoryUpdateDto Dto) : IRequest<Unit>;

internal sealed class UpdatePurchaseHistoryCommandHandler : IRequestHandler<UpdatePurchaseHistoryCommand, Unit>
{
	private readonly IUnitOfWork _unitOfWork;

	public UpdatePurchaseHistoryCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

	public async Task<Unit> Handle(UpdatePurchaseHistoryCommand request, CancellationToken cancellationToken)
	{
		var dto = request.Dto;

		var entity = await _unitOfWork.PurchaseHistories.GetByIdAsync(dto.Id);
		if (entity == null) throw new KeyNotFoundException($"PurchaseHistory with id {dto.Id} not found.");

		if (dto.IdUser.HasValue) entity.Iduser = dto.IdUser.Value;
		if (dto.IdShopping.HasValue) entity.Idshopping = dto.IdShopping.Value;
		if (dto.IdPayment is not null) entity.IdPayment = dto.IdPayment;
		if (dto.Status.HasValue) entity.Status = dto.Status.Value;

		_unitOfWork.PurchaseHistories.Update(entity);
		await _unitOfWork.CompleteAsync();

		return Unit.Value;
	}
}