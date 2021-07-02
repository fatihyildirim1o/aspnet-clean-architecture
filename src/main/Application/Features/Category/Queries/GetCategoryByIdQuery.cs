using Application.Common.Contracts.Repositories;
using Application.Common.Enums;
using Application.Common.Results;
using Application.Features.Category.Models;
using MediatR;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;

namespace Application.Features.Category.Queries
{
    public class GetCategoryByIdQuery : IRequest<IDataResult<CategoryDetailViewModel>>
    {
        public int Id { get; set; }
        public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, IDataResult<CategoryDetailViewModel>>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;

            public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
            }

            public async Task<IDataResult<CategoryDetailViewModel>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
            {
                await _categoryRepository.GetListAsync(null, null, null, new Tuple<Expression<Func<Domain.Entities.Category, object>>, OrderBy>(x => x.Id, OrderBy.Asc));
                var category = await _categoryRepository.GetAsync(x => x.Id == request.Id);
                var result = _mapper.Map<CategoryDetailViewModel>(category);
                return new SuccessDataResult<CategoryDetailViewModel>(result);
            }
        }
    }
}
