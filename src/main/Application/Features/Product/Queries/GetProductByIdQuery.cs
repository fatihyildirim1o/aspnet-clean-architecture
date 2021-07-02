using Application.Common.Contracts;
using Application.Common.Contracts.Repositories;
using Application.Common.Enums;
using Application.Common.Results;
using Application.Features.Product.Models;
using MediatR;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;

namespace Application.Features.Product.Queries
{
    public class GetProductByIdQuery : IRequest<IDataResult<ProductDetailViewModel>>
    {
        public int Id { get; set; }
        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, IDataResult<ProductDetailViewModel>>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;

            public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }

            public async Task<IDataResult<ProductDetailViewModel>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            {
                await _productRepository.GetListAsync(null, null, null, new Tuple<Expression<Func<Domain.Entities.Product, object>>, OrderBy>(x => x.Id, OrderBy.Asc));
                var product = await _productRepository.GetAsync(x => x.Id == request.Id);
                var result = _mapper.Map<ProductDetailViewModel>(product);
                return new SuccessDataResult<ProductDetailViewModel>(result);
            }
        }
    }
}
