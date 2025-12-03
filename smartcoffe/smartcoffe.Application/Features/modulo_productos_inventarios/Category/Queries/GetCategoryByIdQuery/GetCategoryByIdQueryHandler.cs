using MediatR;
using smartcoffe.Application.Features.modulo_productos_inventarios.Category.DTOs;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.modulo_productos_inventarios.Category.Queries.GetCategoryByIdQuery
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<modulo_productos_inventarios.Category.Queries.GetCategoryByIdQuery.GetCategoryByIdQuery, CategoryDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCategoryByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CategoryDto> Handle(modulo_productos_inventarios.Category.Queries.GetCategoryByIdQuery.GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.Repository<Domain.Entities.Category>().GetByIdAsync(request.Id);

            if (category == null)
            {
                return null!; // O manejar con una excepción personalizada de NotFound
            }

            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                Status = category.Status
            };
        }
    }
}