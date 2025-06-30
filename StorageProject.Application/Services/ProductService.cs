using Microsoft.EntityFrameworkCore;
using StorageProject.Application.Contracts;
using StorageProject.Application.DTOs.Requests;
using StorageProject.Application.DTOs.Response;
using StorageProject.Application.Mappers;
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


        public async Task<IEnumerable<ProductResponseDTO>> GetAllAsync()
        {
            var products = await _unitOfWork.ProductRepository.GetAllWithIncludesAsync();
            var dto = products.Select(product => ProductMapper.ToResponseDTO(
                 product,
                 product.Brand?.Name ?? string.Empty,
                 product.Category?.Name ?? string.Empty
             ));

            return dto;
        }

        public async Task<ProductResponseDTO> CreateAsync(ProductDTO productDTO)
        {
            var entity = ProductMapper.ToEntity(productDTO);

            await _unitOfWork.ProductRepository.Create(entity);
            await _unitOfWork.CommitAsync();

            var brand = await _unitOfWork.BrandRepository.GetById(productDTO.BrandId);
            var category = await _unitOfWork.CategoryRepository.GetById(productDTO.BrandId);
            return ProductMapper.ToResponseDTO(
                
                entity,
                brand?.Name ?? string.Empty,
                category?.Name ?? string.Empty);
        }

        public Task<Product> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateAsync(ProductDTO productDTO)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(Guid id)
        {
            var product = await _unitOfWork.ProductRepository.GetById(id);

            if (product is null)
                throw new Exception("Produto não encontrado");

            _unitOfWork.ProductRepository.Delete(product);

            await _unitOfWork.CommitAsync();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }


    }
}
