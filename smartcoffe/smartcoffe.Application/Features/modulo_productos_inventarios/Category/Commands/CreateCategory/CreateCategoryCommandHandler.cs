using MediatR;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.modulo_productos_inventarios.Category.Commands.CreateCategory
{
    // El Handler debe devolver un int (el Id de la nueva categoría)
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            // 1. Mapeo de Command a Entidad de Dominio
            var category = new Domain.Entities.Category
            {
                Name = request.Name,
                Description = request.Description,
                Status = request.Status,
                // Agrega cualquier otra propiedad necesaria (ej: CreatedAt, UpdatedAt)
            };

            // 2. Agregar la entidad al repositorio
            // El repositorio Categories debe haber sido definido en IUnitOfWork y UnitOfWork.
            await _unitOfWork.Repository<Domain.Entities.Category>().AddAsync(category);

            // 3. Guardar cambios en la base de datos (Ejecutar transacción)
            await _unitOfWork.CompleteAsync();

            // 4. Retornar el ID generado por la base de datos (PostgreSQL/EF Core)
            return category.Id;
        }
    }
}