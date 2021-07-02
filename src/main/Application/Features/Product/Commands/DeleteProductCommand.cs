using Application.Common.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Contracts.Repositories;

namespace Application.Features.Product.Commands
{
    public class DeleteProductCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        
        public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, IResult>
        {
            private readonly IProductRepository _productRepository;

            public DeleteProductCommandHandler(IProductRepository productRepository)
            {
                _productRepository = productRepository;
            }

            public async Task<IResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
            {
                var product = await _productRepository.GetAsync(x => x.Id == request.Id);
                if (product==null)
                    return new ErrorResult("Product not found.", StatusCodes.Status403Forbidden);

                await _productRepository.RemoveAsync(product);

                return new SuccessResult("Product deleted.");
            }
        }
    }
}
