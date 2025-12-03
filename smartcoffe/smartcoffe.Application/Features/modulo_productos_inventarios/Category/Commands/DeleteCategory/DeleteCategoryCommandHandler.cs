using MediatR;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.modulo_productos_inventarios.Category.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            // 1. Obtener la entidad a eliminar
            var categoryToDelete = await _unitOfWork.Repository<Domain.Entities.Category>().GetByIdAsync(request.Id);

            // 2. Validar si existe
            if (categoryToDelete == null)
            {
                return false;
            }

            // 3. Eliminar del repositorio
            _unitOfWork.Repository<Domain.Entities.Category>().Remove(categoryToDelete);

            // 4. Guardar cambios
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}