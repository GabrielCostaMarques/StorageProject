﻿using Ardalis.Result;
using StorageProject.Application.DTOs.Requests.Product;
using StorageProject.Application.DTOs.Response;


namespace StorageProject.Application.Contracts
{
    public interface IProductService : IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        Task<Result<IEnumerable<ProductResponseDTO>>> GetAllAsync();
        Task<Result<ProductResponseDTO>> GetByIdAsync(Guid id);
        Task<Result<ProductResponseDTO>> CreateAsync(CreateProductDTO createProductDTO)
        Task<Result<ProductResponseDTO>> UpdateAsync(ChangeProductDTO changeProductDTO);
        Task<Result> RemoveAsync(Guid id);
    }
}
