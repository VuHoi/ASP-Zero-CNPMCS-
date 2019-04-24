using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using GSoft.AbpZeroTemplate.EntityFrameworkCore;
using GSoft.AbpZeroTemplate.Migrations.Seed.Gwebsite;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share;
using GWebsite.AbpZeroTemplate.Application.Share.Bidding;
using GWebsite.AbpZeroTemplate.Application.Share.Bidding.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Web.Core.Suppliers
{
   public  class SupplierAppService : GWebsiteAppServiceBase, ISupplierAppService
    {
        private readonly IRepository<Supplier, int> _supplierRepository;
        //private readonly AbpZeroTemplateDbContext _context;
        private readonly GwebsiteDbBuilder context;
        public SupplierAppService(IRepository<Supplier, int> supplierRepository)
        {
            _supplierRepository = supplierRepository;
            //_context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="biddingProduct"></param>
        /// <returns>SupplierDto</returns>
        public async  Task<BiddingProduct> BiddingProductAsync(BiddingSaved biddingSaved)
        {
            var bidding = ObjectMapper.Map<Bidding>(biddingSaved);
            //context.Create().Biddings.Add(bidding);
            //await _context.SaveChangesAsync();
            return ObjectMapper.Map<BiddingProduct>(bidding);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<SupplierDto>> GetAllBiddingPassAsync(Pagination pagination)
        {
            var query = _supplierRepository.GetAllIncluding().Include(p=>p.Biddings).ThenInclude(p=>p.Product);
            var select = query.Where(p => p.Biddings.All(b =>  b.Status == 1));
            var totalCount = await select.CountAsync();
            var items = await select.Skip(pagination.Start * pagination.NumberItem).Take(pagination.NumberItem).ToListAsync();
            return new PagedResultDto<SupplierDto>(
             totalCount,
             items.Select(item => ObjectMapper.Map<SupplierDto>(item)).ToList());
        }


        /// <summary>
        ///  status = 0 tham gia dau thau
        ///  status =1 trung thau
        ///  status =2 huy thau
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        public  async Task<PagedResultDto<SupplierDto>> GetSupplierByProductAsync(Pagination pagination,int productId)
        {
            var query = _supplierRepository.GetAllIncluding().Include(p => p.Biddings).ThenInclude(p => p.Product).ThenInclude(p=>p.Image);
            var select = query.Where(p => p.Biddings.All(b => b.ProductId == productId && b.Status!=0));
            var totalCount = await select.CountAsync();
            var items = await select.Skip(pagination.Start * pagination.NumberItem).Take(pagination.NumberItem).ToListAsync();
            return new PagedResultDto<SupplierDto>(
             totalCount,
             items.Select(item => ObjectMapper.Map<SupplierDto>(item)).ToList());
        }
      
    }
}
