using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Purchases;
using GWebsite.AbpZeroTemplate.Application.Share.Purchases.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Web.Core.Purchases
{
    public class PurchaseAppService : GWebsiteAppServiceBase, IPurchaseAppService
    {

        private readonly IRepository<Purchase, int> _purchaseRepository;
        public PurchaseAppService(IRepository<Purchase, int> purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        public async Task<ListResultDto<PurchaseDto>> GetPurchasesAsync()
        {
            var items = await _purchaseRepository.GetAllListAsync();
            return new ListResultDto<PurchaseDto>(
             items.Select(item => ObjectMapper.Map<PurchaseDto>(item)).ToList());
        }
    }
}
