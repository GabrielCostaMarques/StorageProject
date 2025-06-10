using Microsoft.EntityFrameworkCore;
using StorageProject.Domain.Entity;
using StorageProject.Domain.Repositories.Contracts;

namespace StorageProject.Domain.Repositories
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        public BrandRepository(DbContext context) : base(context)
        {
        }
    }
}
