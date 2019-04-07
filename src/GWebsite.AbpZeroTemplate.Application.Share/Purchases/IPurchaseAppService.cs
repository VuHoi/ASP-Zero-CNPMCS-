using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Purchases.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Purchases
{
  public interface IPurchaseAppService
    {
        Task<ListResultDto<PurchaseDto>> GetPurchasesAsync();


        //Task<GetMenuClientOutput> GetMenuClientForEditAsync(NullableIdDto input);

        //Task<MenuClientDto> CreateMenuClientAsync(CreateMenuClientInput input);

        //Task<MenuClientDto> UpdateMenuClientAsync(UpdateMenuClientInput input);

        //Task DeleteMenuClientAsync(EntityDto<int> input);
    }
}
