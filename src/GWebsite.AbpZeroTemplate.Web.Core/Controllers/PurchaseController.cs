using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Purchases;
using GWebsite.AbpZeroTemplate.Application.Share.Purchases.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class PurchaseController : GWebsiteControllerBase
    {
        private readonly IPurchaseAppService _PurchaseAppService;

        public PurchaseController(IPurchaseAppService PurchaseAppService)
        {
            _PurchaseAppService = PurchaseAppService;
        }

        [HttpGet]
        public async Task<ListResultDto<PurchaseDto>> GePurchases()
        {
            return await _PurchaseAppService.GetPurchasesAsync();
        }
    }
}
