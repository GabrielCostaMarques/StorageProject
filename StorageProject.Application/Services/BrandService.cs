using Ardalis.Result;
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
            return await _unitOfWork.BrandRepository.GetAll();
        }

        public async Task<Brand> GetByIdAsync(Guid id)
        {
            return await _unitOfWork.BrandRepository.GetById(id);
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

        public async Task<Brand> UpdateAsync(Brand brand)
        {
            var entity = await _unitOfWork.BrandRepository.GetById(brand.Id);

            entity = new Brand()
            {
                Name = brand.Name,
            };

            await _unitOfWork.CommitAsync();

            return entity;
        }

        public async Task<Result> DeleteById(Guid id)
        {
            var entity = await _unitOfWork.BrandRepository.GetById(id);
            _unitOfWork.BrandRepository.Delete(entity);
            await _unitOfWork.CommitAsync();
            return Result.SuccessWithMessage("Brand deleted successfully.");
        }

         
    }
}
