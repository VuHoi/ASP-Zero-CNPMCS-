using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Bidding.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Bidding
{
  public interface ISupplierAppService
    {

        Task<PagedResultDto<SupplierDto>> GetSupplierByProductAsync(Pagination pagination,int productId);

        Task<PagedResultDto<SupplierDto>> GetAllBiddingPassAsync(Pagination pagination);
        Task<BiddingProduct> BiddingProductAsync(BiddingSaved biddingSaved);
        //Task<SupplierDto> ChangeOwnerBiddingProductAsync();

        //Task<string> ApprovePurchaseAsync(EntityDto<int> input);
        //Task DeletePurchaseAsync(EntityDto<int> input);
    }
}
