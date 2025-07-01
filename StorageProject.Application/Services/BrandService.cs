using StorageProject.Application.Contracts;
using StorageProject.Application.DTOs.Requests;
using StorageProject.Domain.Contracts;
using StorageProject.Domain.Entity;

namespace StorageProject.Application.Services
{
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BrandService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Brand>> GetAllAsync()
        {
            return await _unitOfWork.BrandRepository.GetAllWithIncludesAsync();
        }

        public Task<Guid> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Brand> CreateAsync(BrandDTO brandDTO)
        {
            var entity = new Brand()
            {
                Name = brandDTO.Name,
            };

            var brand = await _unitOfWork.BrandRepository.Create(entity);
            await _unitOfWork.CommitAsync();

            return brand;
        }

        public Task<Brand> UpdateAsync(BrandDTO brandDTO)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }

         
    }
}
