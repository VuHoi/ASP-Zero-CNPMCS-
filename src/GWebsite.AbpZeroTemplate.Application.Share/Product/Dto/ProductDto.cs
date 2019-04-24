using GWebsite.AbpZeroTemplate.Application.Share.Bidding.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Products.Dto
{
    public partial class ProductDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public string Summary { get; set; }
        public string AvailableAddress { get; set; }
        public DateTime AddedDate { get; set; }
        public ImageDto Image { get; set; }
        public SupplierDto Supplier { get; set; }
    }
}
