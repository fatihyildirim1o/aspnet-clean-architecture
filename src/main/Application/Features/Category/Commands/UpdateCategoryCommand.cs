using Application.Common.Contracts.Repositories;
using Application.Common.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Category.Commands
{
    public class UpdateCategoryCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, IResult>
        {
            private readonly ICategoryRepository _categoryRepository;

            public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
            {
                _categoryRepository = categoryRepository;
            }

            public async Task<IResult> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
            {
                var category = await _categoryRepository.GetAsync(x => x.Id == request.Id);
                if (category == null)
                    return new ErrorResult("Category not found.", StatusCodes.Status403Forbidden);

                category.Name = request.Name;

                await _categoryRepository.UpdateAsync(category);

                return new SuccessResult("Category updated.");
            }
        }
    }
}
