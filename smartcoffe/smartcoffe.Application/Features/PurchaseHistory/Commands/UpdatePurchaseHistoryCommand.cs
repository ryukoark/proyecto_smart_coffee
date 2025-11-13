using MediatR;
using smartcoffe.Application.Features.PurchaseHistory.DTOs;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.PurchaseHistory.Commands;

public record UpdatePurchaseHistoryCommand(int Id, PurchaseHistoryUpdateDto Dto) : IRequest<Unit>;

internal sealed class UpdatePurchaseHistoryCommandHandler : IRequestHandler<UpdatePurchaseHistoryCommand, Unit>
{
	private readonly IUnitOfWork _unitOfWork;

	public UpdatePurchaseHistoryCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

	public async Task<Unit> Handle(UpdatePurchaseHistoryCommand request, CancellationToken cancellationToken)
	{
		var dto = request.Dto;

		var entity = await _unitOfWork.PurchaseHistories.GetByIdAsync(request.Id);
		if (entity == null) throw new KeyNotFoundException($"PurchaseHistory with id {request.Id} not found.");

		if (dto.IdUser.HasValue)
		{
			if (dto.IdUser.Value <= 0) throw new ArgumentException("IdUser must be a positive integer.");
			var user = await _unitOfWork.Users.GetByIdAsync(dto.IdUser.Value);
			if (user is null) throw new KeyNotFoundException($"User with id {dto.IdUser} was not found.");
		}

		if (dto.IdShopping.HasValue)
		{
			if (dto.IdShopping.Value <= 0) throw new ArgumentException("IdShopping must be a positive integer.");
			var shopping = await _unitOfWork.Shoppings.GetByIdAsync(dto.IdShopping.Value);
			if (shopping is null) throw new KeyNotFoundException($"Shopping with id {dto.IdShopping} was not found.");
		}

		// Apply updates
		if (dto.IdUser.HasValue) entity.Iduser = dto.IdUser.Value;
		if (dto.IdShopping.HasValue) entity.Idshopping = dto.IdShopping.Value;
		if (dto.IdPayment is not null) entity.IdPayment = dto.IdPayment;

		_unitOfWork.PurchaseHistories.Update(entity);
		try
		{
			await _unitOfWork.CompleteAsync();
		}
		catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
		{
			if (ex.InnerException is Npgsql.PostgresException p && p.SqlState == "23503")
			{
				throw new KeyNotFoundException("Referenced User or Shopping not found (FK violation).");
			}
			throw; 
		}

		return Unit.Value;
	}
}