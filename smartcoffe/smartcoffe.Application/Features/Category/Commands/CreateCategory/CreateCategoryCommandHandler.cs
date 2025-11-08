using MediatR;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.Category.Commands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            // Mapeo directo de Command a Entidad de Dominio
            var categoryEntity = new smartcoffe.Domain.Entities.Category
            {
                Name = request.Name,
                Description = request.Description,
                Status = request.Status
            };

            // Agregar la entidad al repositorio
            await _unitOfWork.Categories.AddAsync(categoryEntity);
            
            // Guardar los cambios en la base de datos a través del Unit of Work
            await _unitOfWork.CompleteAsync();

            // Retornar el ID generado de la nueva categoría
            return categoryEntity.Id;
        }
    }
}