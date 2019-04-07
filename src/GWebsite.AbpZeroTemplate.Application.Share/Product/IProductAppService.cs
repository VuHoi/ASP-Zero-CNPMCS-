using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Product.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Product
{
    public interface IProductAppService
    {
        Task<ListResultDto<ProductDto>> GetProductsAsync();

        Task<ProductDto> GetProductAsync(int id);




    }
}
