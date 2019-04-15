using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share;
using GWebsite.AbpZeroTemplate.Application.Share.Purchases;
using GWebsite.AbpZeroTemplate.Application.Share.Purchases.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
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

        
        public async Task<PagedResultDto<PurchaseDto>> GetPurchasesAsync(Pagination pagination)
        {
            var query = _purchaseRepository.GetAllIncluding(p => p.PurchaseProducts, p => p.Department);
            var totalCount = await query.CountAsync();
            var items = await query.Skip(pagination.Start * pagination.NumberItem).Take(pagination.NumberItem).ToListAsync();
            return new PagedResultDto<PurchaseDto>(
             totalCount,
             items.Select(item => ObjectMapper.Map<PurchaseDto>(item)).ToList());
        }

        public async Task<PagedResultDto<PurchaseDto>> GetPurchasesAsync(GetPurchaseInput input)
        {
            var query = _purchaseRepository.GetAll()
                .WhereIf(!input.Name.IsNullOrWhiteSpace(), m => m.User.Name.Contains(input.Name));

            var totalCount = await query.CountAsync();
            var items = await query.OrderBy(x => x.User.Name).Skip(input.Start * input.NumberItem).Take(input.NumberItem).ToListAsync();

            return new PagedResultDto<PurchaseDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<PurchaseDto>(item)).ToList());
        }

        public async Task<PurchaseDto> GetPurchaseForEditAsync(NullableIdDto input)
        {
            var item = await _purchaseRepository.GetAllIncluding(p => p.PurchaseProducts, p => p.Department).FirstOrDefaultAsync(x => x.Id == input.Id);
            return ObjectMapper.Map<PurchaseDto>(item);
        }

        public async Task<int> CreatePurchaseAsync(PurchaseSave input)
        {
            var entity = ObjectMapper.Map<Purchase>(input);
            var a= await _purchaseRepository.InsertAndGetIdAsync(entity);
            return a;
        }

        public async Task<PurchaseDto> UpdatePurchaseAsync(PurchaseSave input)
        {
            var entity = await _purchaseRepository.GetAllIncluding(p=>p.PurchaseProducts,p1=>p1.User,p2=>p2.Department).FirstOrDefaultAsync(x=>x.Id== input.Id);
            ObjectMapper.Map(input, entity);
            entity = await _purchaseRepository.UpdateAsync(entity);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<PurchaseDto>(entity);
        }
    }
}
