using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Product
{
    public interface IProductAppService
    {
        Task<ListResultDto<Product>> GetMenuClientsAsync();



        Task<MenuClientDto> CreateMenuClientAsync(CreateMenuClientInput input);

        Task<MenuClientDto> UpdateMenuClientAsync(UpdateMenuClientInput input);

        Task DeleteMenuClientAsync(EntityDto<int> input);
    }
}
