using Microsoft.EntityFrameworkCore;
using StorageProject.Domain.Entity;
using StorageProject.Domain.Repositories.Contracts;

namespace StorageProject.Domain.Repositories
{
    public class ProductRepository : Repository<Product>,IProductRepository
    {
        public ProductRepository(DbContext context) : base(context)
        {
        }
    }
}
