using Ardalis.Result;
using FluentValidation.Validators;
using StorageProject.Application.Contracts;
using StorageProject.Application.DTOs.Requests.Brand;
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

        public async Task<IEnumerable<BrandDTO>> GetAllAsync()
        {
            var entity = await _unitOfWork.BrandRepository.GetAll();
            return entity.Select(b => b.ToDTO());
        }

        public async Task<Result<BrandDTO>> GetByIdAsync(Guid id)
        {
            var entity = await _unitOfWork.BrandRepository.GetById(id);
            return entity.ToDTO();
        }

        public async Task<Result<BrandDTO>> CreateAsync(BrandDTO brandDTO)
        {
            var entity = brandDTO.ToEntity();

            if (!entity.Name.Any())
            {
                Result.Conflict("There's a brand with same name");
            }

            var brand = await _unitOfWork.BrandRepository.Create(entity);

            await _unitOfWork.CommitAsync();

            return brand.ToDTO();
        }

        public async Task<Result> UpdateAsync(ChangeBrandDTO changeBrandDTO)
        {

            var entity = await _unitOfWork.BrandRepository.GetById(changeBrandDTO.Id);

            changeBrandDTO.ToEntity(entity);

            await _unitOfWork.CommitAsync();

            return Result.SuccessWithMessage("Brand updated successfully.");
        }

        public async Task<Result> DeleteAsync(Guid id)
        {
            var entity = await _unitOfWork.BrandRepository.GetById(id);
            _unitOfWork.BrandRepository.Delete(entity);
            await _unitOfWork.CommitAsync();
            return Result.SuccessWithMessage("Brand deleted successfully.");
        }


    }
}
