using StorageProject.Application.Contracts;
using StorageProject.Application.DTOs;
using StorageProject.Domain.Contracts;
using StorageProject.Domain.Entity;

namespace StorageProject.Application.Services
{
    public class ProductService : IProductService
    {
        private IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<ICollection<Product>> GetAllAsync()
        {
           var products= await _unitOfWork.ProductRepository.GetAll();
           return products;
        }

        public async Task<Product> CreateAsync(ProductDTO productDTO)
        {
            var entity = new Product
            {
                Name = productDTO.Name,
                Description = productDTO.Description,
                Quantity = productDTO.Quantity,
                BrandId = productDTO.BrandId,
                CategoryId = productDTO.CategoryId,

            };

            await _unitOfWork.ProductRepository.Create(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public Task<Product> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateAsync(ProductDTO productDTO)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        
    }
}
