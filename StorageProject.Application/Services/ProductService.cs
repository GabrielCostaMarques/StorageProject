using StorageProject.Application.Contracts;
using StorageProject.Application.DTOs.Requests;
using StorageProject.Application.DTOs.Response;
using StorageProject.Application.Mappers;
using StorageProject.Domain.Contracts;

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
            var dto = products.Select(product => ProductMapper.ToResponseDTO(product));

            return dto;
        }

        public async Task<ProductResponseDTO> CreateAsync(ProductDTO productDTO)
        {
            var entity = ProductMapper.ToEntity(productDTO);

            await _unitOfWork.ProductRepository.Create(entity);
            await _unitOfWork.CommitAsync();

            return ProductMapper.ToResponseDTO(entity);
        }

        public async Task<ProductResponseDTO> GetByIdAsync(Guid id)
        {
            var entity = await _unitOfWork.ProductRepository.GetByIdWithIncludesAsync(id);
            return ProductMapper.ToResponseDTO(entity);
        }

        public Task<ProductResponseDTO> UpdateAsync(ProductDTO productDTO)
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
