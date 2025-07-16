using Ardalis.Result;
using StorageProject.Application.Contracts;
using StorageProject.Application.DTOs.Requests;
using StorageProject.Application.Mappers;
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

        public async Task<Result<Brand>> CreateAsync(BrandDTO brandDTO)
        {
            var entity = brandDTO.ToEntity();

            if (entity.Name.Any())
            {
                
            }

            var brand = await _unitOfWork.BrandRepository.Create(entity);
            await _unitOfWork.CommitAsync();

            return brand;
        }

        public async Task<Result<Brand>> UpdateAsync(ChangeBrandDTO changeBrandDTO)
        {

            //todo: to return Result<BrandDTO> instead of Brand
            var entity = await _unitOfWork.BrandRepository.GetById(changeBrandDTO.Id);

            changeBrandDTO.ToEntity(entity);

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
