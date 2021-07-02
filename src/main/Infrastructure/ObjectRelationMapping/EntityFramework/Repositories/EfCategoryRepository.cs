using Application.Common.Contracts.Repositories;
using Domain.Entities;
using Infrastructure.ObjectRelationMapping.EntityFramework.Config;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.ObjectRelationMapping.EntityFramework.Repositories
{
    public class EfCategoryRepository:EfEntityRepositoryBase<Category>,ICategoryRepository
    {
        public EfCategoryRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
