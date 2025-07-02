using StorageProject.Application.Contracts;
using StorageProject.Application.DTOs.Requests;
using StorageProject.Application.DTOs.Response;
using StorageProject.Application.Mappers;
using StorageProject.Application.ModelResult;
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


        public async Task<Result<IEnumerable<ProductResponseDTO>>> GetAllAsync()
        {
            
            var products = await _unitOfWork.ProductRepository.GetAllWithIncludesAsync();

            if (!products.Any())
            {
                return Result<IEnumerable<ProductResponseDTO>>.Failure("Empty List");
            }

            var dto = products.Select(product => ProductMapper.ToResponseDTO(product)).ToList();

            return Result<IEnumerable<ProductResponseDTO>>.Success(dto);
        }

        public async Task CreateAsync(ProductDTO productDTO)
        {
            var entity = ProductMapper.ToEntity(productDTO);

            await _unitOfWork.ProductRepository.Create(entity);



            await _unitOfWork.CommitAsync();

            var created = await _unitOfWork.ProductRepository.GetByIdWithIncludesAsync(entity.Id);

        }

        public async Task<Result<ProductResponseDTO>> GetByIdAsync(Guid id)
        {
            var entity = await _unitOfWork.ProductRepository.GetByIdWithIncludesAsync(id);

            if (entity == null) return Result<ProductResponseDTO>.Failure("Not Found Product");

            return Result<ProductResponseDTO>.Success(entity.ToResponseDTO());
        }

        public async Task<ProductResponseDTO> UpdateAsync(ChangeProductDTO changeProductDTO)
        {

            var entity = await _unitOfWork.ProductRepository.GetByIdWithIncludesAsync(changeProductDTO.Id);
            changeProductDTO.ToEntity(entity);

            await _unitOfWork.CommitAsync();//The EF detect the tracking, don't need .Update() function

            return entity.ToResponseDTO();
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
