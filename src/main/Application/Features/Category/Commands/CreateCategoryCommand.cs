using Application.Common.Results;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Contracts.Repositories;
using Microsoft.AspNetCore.Http;
using MediatR;

namespace Application.Features.Category.Commands
{
    public class CreateCategoryCommand : IRequest<IDataResult<int>>
    {
        public string Name { get; set; }

        public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, IDataResult<int>>
        {
            private readonly ICategoryRepository _categoryRepository;
            public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
            {
                _categoryRepository = categoryRepository;
            }

            public async Task<IDataResult<int>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {
                var addedCategory = await _categoryRepository.AddAsync(new Domain.Entities.Category
                {
                    Name = request.Name
                });
                return new SuccessDataResult<int>(addedCategory.Id, "Category added.", StatusCodes.Status201Created);
            }
        }
    }
}
