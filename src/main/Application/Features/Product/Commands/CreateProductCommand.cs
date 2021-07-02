using Application.Common.Results;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Contracts.Repositories;
using Microsoft.AspNetCore.Http;
using MediatR;

namespace Application.Features.Product.Commands
{
    public class CreateProductCommand : IRequest<IDataResult<int>>
    {
        public int CategoryId { get; set; } 
        public string Name { get; set; }

        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, IDataResult<int>>
        {
            private readonly IProductRepository _productRepository;
            public CreateProductCommandHandler(IProductRepository productRepository)
            {
                _productRepository = productRepository;
            }

            public async Task<IDataResult<int>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var addedProduct = await _productRepository.AddAsync(new Domain.Entities.Product
                {
                    Name = request.Name
                });
                return new SuccessDataResult<int>(addedProduct.Id, "Product added.", StatusCodes.Status201Created);
            }
        }
    }
}
