using Application.Common.Contracts.Repositories;
using Application.Common.Enums;
using Application.Common.Results;
using Application.Features.Product.Models;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Product.Queries
{
    public class GetProductListQuery : IRequest<IDataResult<ListDetailModel<ProductDetailViewModel>>>
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, IDataResult<ListDetailModel<ProductDetailViewModel>>>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;

            public GetProductListQueryHandler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }
            public async Task<IDataResult<ListDetailModel<ProductDetailViewModel>>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
            {
                var categories = await _productRepository.GetListAsync(null,request.Page, request.PageSize,new Tuple<Expression<Func<Domain.Entities.Product, object>>, OrderBy>(x=>x.Name,OrderBy.Asc));
                var count = await _productRepository.CountAsync();

                return new SuccessDataResult<ListDetailModel<ProductDetailViewModel>>(
                    new ListDetailModel<ProductDetailViewModel>
                    {
                        Items = _mapper.Map<List<ProductDetailViewModel>>(categories),
                        Total = count
                    });
            }
        }
    }
}
