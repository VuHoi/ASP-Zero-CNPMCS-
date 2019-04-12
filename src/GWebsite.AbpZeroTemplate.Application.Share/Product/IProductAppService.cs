using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Products.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Products
{
    public interface IProductAppService
    {
        Task<ListResultDto<ProductDto>> GetProductsAsync();

        Task<ProductDto> GetProductAsync(int id);




    }
}
