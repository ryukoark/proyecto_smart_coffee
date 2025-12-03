using MediatR;

namespace smartcoffe.Application.Features.modulo_productos_inventarios.Inventory.Commands.CheckStock;

public record CheckStockCommand(int ProductId, int Quantity) : IRequest<bool>;