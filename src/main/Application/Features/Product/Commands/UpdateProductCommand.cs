using Application.Common.Contracts.Repositories;
using Application.Common.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Product.Commands
{
    public class UpdateProductCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, IResult>
        {
            private readonly IProductRepository _productRepository;

            public UpdateProductCommandHandler(IProductRepository productRepository)
            {
                _productRepository = productRepository;
            }

            public async Task<IResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                var product = await _productRepository.GetAsync(x => x.Id == request.Id);
                if (product == null)
                    return new ErrorResult("Product not found.", StatusCodes.Status403Forbidden);

                product.Name = request.Name;

                await _productRepository.UpdateAsync(product);

                return new SuccessResult("Product updated.");
            }
        }
    }
}
