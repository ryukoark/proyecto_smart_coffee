using MediatR;
using smartcoffe.Application.Features.Category.DTOs;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.Category.Queries.GetAllCategoriesQuery
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCategoriesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CategoryDto>> Handle(Queries.GetAllCategoriesQuery.GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _unitOfWork.Categories.GetAllAsync();

            // Mapeo manual de Entidad a DTO
            var categoriesDto = categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                Status = c.Status
            });

            return categoriesDto;
        }
    }
}