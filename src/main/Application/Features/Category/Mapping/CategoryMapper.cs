using Application.Features.Category.Models;
using AutoMapper;

namespace Application.Features.Category.Mapping
{
    public class CategoryMapper:Profile
    {
        public CategoryMapper()
        {
            CreateMap<Domain.Entities.Category, CategoryDetailViewModel>();
        }
    }
}
