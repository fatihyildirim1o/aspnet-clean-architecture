using Application.Features.Product.Models;
using AutoMapper;

namespace Application.Features.Product.Mapping
{
    public class ProductMapper:Profile
    {
        public ProductMapper()
        {
            CreateMap<Domain.Entities.Product, ProductDetailViewModel>();
        }
    }
}
