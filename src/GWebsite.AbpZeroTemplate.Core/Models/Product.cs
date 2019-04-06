using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public partial class Product : Entity<int>
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Summary { get; set; }
        public string AvailableAddress { get; set; }
        public DateTime AddedDate { get; set; }
    
    }
}
