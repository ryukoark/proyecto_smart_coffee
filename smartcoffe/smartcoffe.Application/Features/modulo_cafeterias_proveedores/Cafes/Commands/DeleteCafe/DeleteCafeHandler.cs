using MediatR;
using smartcoffe.Domain.Entities;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.modulo_cafeterias_proveedores.Cafes.Commands.DeleteCafe
{
    public class DeleteCafeHandler : IRequestHandler<DeleteCafeCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCafeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteCafeCommand request, CancellationToken cancellationToken)
        {
            var cafe = await _unitOfWork.Repository<Cafe>().GetByIdAsync(request.Id);
            if (cafe == null)
                return false;

            _unitOfWork.Repository<Cafe>().Remove(cafe);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}