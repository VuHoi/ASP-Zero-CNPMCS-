using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using GWebsite.AbpZeroTemplate.Application.Share;
using GWebsite.AbpZeroTemplate.Application.Share.Bidding;
using GWebsite.AbpZeroTemplate.Application.Share.Bidding.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public  class SupplierController : GWebsiteControllerBase
    {

        private readonly ISupplierAppService _SupplierAppService;

        public SupplierController(ISupplierAppService SuppllierService)
        {
            _SupplierAppService = SuppllierService;
        }

        [HttpGet]
        public async Task<ListResultDto<SupplierDto>> GetSupplierByProduct(int start = 0, int numberItem = 10, int productId=0)
        {
            return await _SupplierAppService.GetSupplierByProductAsync(new Pagination() { Start = start, NumberItem = numberItem }, productId);
        }

        [HttpGet]
        public async Task<ListResultDto<SupplierDto>> GetAllBiddingPass(int start = 0, int numberItem = 10)
        {
            return await _SupplierAppService.GetAllBiddingPassAsync(new Pagination() { Start = start, NumberItem = numberItem });
        }

        [HttpPost]
        public async Task<BiddingProduct> CreatePurchase([FromBody]  BiddingSaved BiddingSaved)
        {
            return await _SupplierAppService.BiddingProductAsync(BiddingSaved);
        }
    }
}
