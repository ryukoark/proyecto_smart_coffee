using MediatR;

namespace smartcoffe.Application.Features.Cafes.Commands
{
    public class DeleteCafe : IRequest<bool>
    {
        public int Id { get; }

        public DeleteCafe(int id)
        {
            Id = id;
        }
    }

    public class DeleteCafeHandler : IRequestHandler<DeleteCafe, bool>
    {
        public async Task<bool> Handle(DeleteCafe request, CancellationToken cancellationToken)
        {
            // Simulamos eliminación exitosa
            return await Task.FromResult(true);
        }
    }
}