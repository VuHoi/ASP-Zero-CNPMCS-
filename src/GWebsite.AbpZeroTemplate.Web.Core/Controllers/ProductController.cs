﻿using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Product;
using GWebsite.AbpZeroTemplate.Application.Share.Product.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ProductsController : GWebsiteControllerBase
    {
        private readonly IProductAppService _ProductAppService;

        public ProductsController(IProductAppService ProductAppService)
        {
            _ProductAppService = ProductAppService;
        }

        [HttpGet]
        public async Task<ListResultDto<ProductDto>> GetProducts()
        {
            return await _ProductAppService.GetProductsAsync();
        }

        [HttpGet]
        public async Task<ProductDto> GetProduct(int Id)
        {
            return await _ProductAppService.GetProductAsync(Id);
        }
    }
}