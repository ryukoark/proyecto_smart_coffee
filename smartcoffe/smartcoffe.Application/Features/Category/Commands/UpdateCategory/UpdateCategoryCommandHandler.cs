using MediatR;
using smartcoffe.Application.Features.Category.Commands.UpdateCategory;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.Category.Commands
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            // 1. Obtener la categoría existente
            var categoryToUpdate = await _unitOfWork.Categories.GetByIdAsync(request.Id);

            // 2. Validar si existe
            if (categoryToUpdate == null)
            {
                return false; // O podrías lanzar una excepción NotFoundException
            }

            // 3. Actualizar las propiedades
            categoryToUpdate.Name = request.Name;
            categoryToUpdate.Description = request.Description;
            categoryToUpdate.Status = request.Status;

            // 4. Marcar como modificado en el repositorio
            _unitOfWork.Categories.Update(categoryToUpdate);

            // 5. Guardar cambios
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}