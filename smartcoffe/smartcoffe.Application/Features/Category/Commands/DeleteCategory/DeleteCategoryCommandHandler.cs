using MediatR;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.Category.Commands.DeleteCategory
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
            var categoryToDelete = await _unitOfWork.Categories.GetByIdAsync(request.Id);

            // 2. Validar si existe
            if (categoryToDelete == null)
            {
                return false;
            }

            // 3. Eliminar del repositorio
            _unitOfWork.Categories.Remove(categoryToDelete);

            // 4. Guardar cambios
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}