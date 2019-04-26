using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share;
using GWebsite.AbpZeroTemplate.Application.Share.Bidding;
using GWebsite.AbpZeroTemplate.Application.Share.Bidding.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Web.Core.Suppliers
{
    public class SupplierAppService : GWebsiteAppServiceBase, ISupplierAppService
    {
        private readonly IRepository<Supplier, int> _supplierRepository;
        private readonly IRepository<Bidding, int> _biddingRepository;
        //private readonly AbpZeroTemplateDbContext _context;
        public SupplierAppService(IRepository<Supplier, int> supplierRepository, IRepository<Bidding, int> biddingRepository)
        {
            _supplierRepository = supplierRepository;
            _biddingRepository = biddingRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="biddingProduct"></param>
        /// <returns>SupplierDto</returns>
        public async Task<BiddingProduct> BiddingProductAsync(BiddingSaved biddingSaved)
        {
            var bidding = ObjectMapper.Map<Bidding>(biddingSaved);
            await _biddingRepository.InsertAndGetIdAsync(bidding);
            //_context.Biddings.Add(bidding);
            //await _context.SaveChangesAsync();
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<BiddingProduct>(bidding);
        }

        /// <summary>
        /// when  change owner of  product 
        /// 1, change status of current product of supplier
        /// 2, change status new supplier of product and update  start date and end date of bidding
        /// </summary>
        /// <param name="biddingSaved"></param>
        /// <returns></returns>
        public async Task<BiddingProduct> ChangeOwnerBiddingProductAsync(BiddingSaved biddingSaved)
        {
            var current = await _biddingRepository.GetAllIncluding(p => p.Supplier, p1 => p1.Product).FirstOrDefaultAsync(x => x.ProductId == biddingSaved.ProductId && x.Status == 1);
            current.Status = 0;
            await _biddingRepository.UpdateAsync(current);
            var entity = await _biddingRepository.GetAllIncluding(p => p.Supplier, p1 => p1.Product).FirstOrDefaultAsync(x => x.ProductId == biddingSaved.ProductId && x.SupplierId == biddingSaved.SupplierId);
            ObjectMapper.Map(biddingSaved, entity);
            entity = await _biddingRepository.UpdateAsync(entity);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<BiddingProduct>(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<SupplierDto>> GetAllBiddingPassAsync(Pagination pagination)
        {
            var query = _supplierRepository.GetAllIncluding().Include(p => p.Biddings).ThenInclude(p => p.Product);
            var select = query.Where(p => p.Biddings.All(b => b.Status == 1));
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
        public async Task<PagedResultDto<SupplierDto>> GetSupplierByProductAsync(Pagination pagination, int productId)
        {
            var query = _supplierRepository.GetAllIncluding().Include(p => p.Biddings).ThenInclude(p => p.Product).ThenInclude(p => p.Image);
            var select = query.Where(p => p.Biddings.All(b => b.ProductId == productId && b.Status != 0));
            var totalCount = await select.CountAsync();
            var items = await select.Skip(pagination.Start * pagination.NumberItem).Take(pagination.NumberItem).ToListAsync();
            return new PagedResultDto<SupplierDto>(
             totalCount,
             items.Select(item => ObjectMapper.Map<SupplierDto>(item)).ToList());
        }

    }
}
