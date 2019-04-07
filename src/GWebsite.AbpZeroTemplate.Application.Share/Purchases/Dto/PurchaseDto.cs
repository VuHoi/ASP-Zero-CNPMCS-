using GWebsite.AbpZeroTemplate.Application.Share.Product.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Purchases.Dto
{
    public partial class PurchaseDto
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        //public ICollection<ProductDto> PurchaseProducts { get; set; }
        public int Status { get; set; }
        public string Comment { get; set; }
        public DepartmentDto Department { get; set; }
        public DateTime RaisedDate { get; set; }
        public DateTime AuthorizedDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ReceivedDate { get; set; }

    }
}
