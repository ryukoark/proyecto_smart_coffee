using MediatR;

namespace smartcoffe.Application.Features.modulo_productos_inventarios.Inventory.Commands.ReduceStock;

public record ReduceStockCommand(int ProductId, int Quantity) : IRequest<bool>;
