using MediatR;
using smartcoffe.Application.Features.PurchaseHistory.DTOs;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.PurchaseHistory.Commands;

public record DeletePurchaseHistoryCommand(PurchaseHistoryDeleteDto Dto) : IRequest<Unit>;

internal sealed class DeletePurchaseHistoryCommandHandler : IRequestHandler<DeletePurchaseHistoryCommand, Unit>
{
	private readonly IUnitOfWork _unitOfWork;

	public DeletePurchaseHistoryCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

	public async Task<Unit> Handle(DeletePurchaseHistoryCommand request, CancellationToken cancellationToken)
	{
		var id = request.Dto.Id;
		var entity = await _unitOfWork.PurchaseHistories.GetByIdAsync(id);
		if (entity == null) throw new KeyNotFoundException($"PurchaseHistory with id {id} not found.");

		entity.Status = false;
		_unitOfWork.PurchaseHistories.Update(entity);
		await _unitOfWork.CompleteAsync();

		return Unit.Value;
	}
}