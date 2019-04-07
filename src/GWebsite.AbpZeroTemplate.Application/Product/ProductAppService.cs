using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Product;
using GWebsite.AbpZeroTemplate.Application.Share.Product.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Web.Core
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
  public  class ProductAppService : GWebsiteAppServiceBase, IProductAppService
    {
        private readonly IRepository<Product, int> _productRepository;

        public ProductAppService(IRepository<Product, int> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ListResultDto<ProductDto>> GetProductsAsync()
        {
            var items = await _productRepository.GetAllListAsync();
            return new ListResultDto<ProductDto>(
             items.Select(item => ObjectMapper.Map<ProductDto>(item)).ToList());
        }

        public async Task<ProductDto> GetProductAsync(int id)
        {
            var item = await _productRepository.FirstOrDefaultAsync(i => i.Id == id);
            return ObjectMapper.Map<ProductDto>(item);
        }
    }
}
