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
        Task<PagedResultDto<PurchaseDto>> GetPurchasesAsync(Pagination pagination);
        Task<PagedResultDto<PurchaseDto>> GetPurchasesAsync(GetPurchaseInput input);
        Task<PurchaseDto> GetPurchaseForEditAsync(NullableIdDto input);

        Task<int> CreatePurchaseAsync(PurchaseSave input);
        Task<PurchaseDto> UpdatePurchaseAsync(PurchaseSave input);

        //Task DeleteMenuClientAsync(EntityDto<int> input);
    }
}
