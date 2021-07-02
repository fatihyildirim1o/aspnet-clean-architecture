using Application.Common.Contracts.Repositories;
using Domain.Entities;
using Infrastructure.ObjectRelationMapping.EntityFramework.Config;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.ObjectRelationMapping.EntityFramework.Repositories
{
    public class EfProductRepository:EfEntityRepositoryBase<Product>,IProductRepository
    {
        public EfProductRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
