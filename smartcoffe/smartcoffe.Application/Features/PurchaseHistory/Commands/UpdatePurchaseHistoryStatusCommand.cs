using MediatR;
using smartcoffe.Application.Features.PurchaseHistory.DTOs;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.PurchaseHistory.Commands;

public record UpdatePurchaseHistoryStatusCommand(PurchaseHistoryStatusUpdateDto Dto) : IRequest<Unit>;

internal sealed class UpdatePurchaseHistoryStatusCommandHandler : IRequestHandler<UpdatePurchaseHistoryStatusCommand, Unit>
{
	private readonly IUnitOfWork _unitOfWork;

	public UpdatePurchaseHistoryStatusCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

	public async Task<Unit> Handle(UpdatePurchaseHistoryStatusCommand request, CancellationToken cancellationToken)
	{
		var dto = request.Dto;
		var entity = await _unitOfWork.PurchaseHistories.GetByIdAsync(dto.Id);
		if (entity == null) throw new KeyNotFoundException($"PurchaseHistory with id {dto.Id} not found.");

		entity.Status = dto.Status;
		_unitOfWork.PurchaseHistories.Update(entity);
		await _unitOfWork.CompleteAsync();

		return Unit.Value;
	}
}