using MediatR;

namespace smartcoffe.Application.Features.Cafes.Commands.DeleteCafe
{
    public class DeleteCafeHandler : IRequestHandler<DeleteCafeCommand, bool>
    {
        public async Task<bool> Handle(DeleteCafeCommand request, CancellationToken cancellationToken)
        {
            // Simulamos eliminación exitosa
            return await Task.FromResult(true);
        }
    }
}