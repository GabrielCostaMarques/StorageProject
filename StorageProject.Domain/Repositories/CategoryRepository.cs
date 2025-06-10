using Microsoft.EntityFrameworkCore;
using StorageProject.Domain.Entity;
using StorageProject.Domain.Repositories.Contracts;

namespace StorageProject.Domain.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext context) : base(context)
        {
        }
    }
}
