using Application.Common.Contracts.Repositories;
using Application.Common.Enums;
using Application.Common.Results;
using Application.Features.Category.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Contracts;
using AutoMapper;

namespace Application.Features.Category.Queries
{
    public class GetCategoryListQuery : IRequest<IDataResult<ListDetailModel<CategoryDetailViewModel>>>
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public class GetCategoryListQueryHandler : IRequestHandler<GetCategoryListQuery, IDataResult<ListDetailModel<CategoryDetailViewModel>>>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;

            public GetCategoryListQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
            }
            public async Task<IDataResult<ListDetailModel<CategoryDetailViewModel>>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
            {
                var categories = await _categoryRepository.GetListAsync(
                    null,
                    request.Page,
                    request.PageSize,
                    new Tuple<Expression<Func<Domain.Entities.Category, object>>, OrderBy>(x=>x.Name,OrderBy.Asc),
                    x=>x.Products);

                var count = await _categoryRepository.CountAsync();

                return new SuccessDataResult<ListDetailModel<CategoryDetailViewModel>>(
                    new ListDetailModel<CategoryDetailViewModel>
                    {
                        Items = _mapper.Map<List<CategoryDetailViewModel>>(categories),
                        Total = count
                    });
            }
        }
    }
}
