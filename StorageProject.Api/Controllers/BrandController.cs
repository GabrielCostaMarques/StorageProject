﻿using Microsoft.AspNetCore.Mvc;
using StorageProject.Application.Contracts;
using StorageProject.Application.DTOs.Requests;
using StorageProject.Application.Services;

namespace StorageProject.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var brand = await _brandService.GetAllAsync();

            if (!brand.Any())
            {
                return NotFound();
            }

            return Ok(brand);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BrandDTO brandDTO)
        {
            var brand = await _brandService.CreateAsync(brandDTO);
            return Ok(brand);
        }
    }
}
