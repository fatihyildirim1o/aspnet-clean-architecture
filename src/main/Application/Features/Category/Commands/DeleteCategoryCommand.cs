using Application.Common.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Contracts.Repositories;

namespace Application.Features.Category.Commands
{
    public class DeleteCategoryCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        
        public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, IResult>
        {
            private readonly ICategoryRepository _categoryRepository;

            public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
            {
                _categoryRepository = categoryRepository;
            }

            public async Task<IResult> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
            {
                var category = await _categoryRepository.GetAsync(x => x.Id == request.Id);
                if (category==null)
                    return new ErrorResult("Category not found.", StatusCodes.Status403Forbidden);

                await _categoryRepository.RemoveAsync(category);

                return new SuccessResult("Category deleted.");
            }
        }
    }
}
