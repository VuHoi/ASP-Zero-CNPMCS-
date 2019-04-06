using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public partial class Purchase : Entity<int>
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public ICollection<PurchaseProduct> PurchaseProducts { get; set; }
        public int Status { get; set; }
        public string Comment { get; set; }
        public DateTime RaisedDate { get; set; }
        public DateTime AuthorizedDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ReceivedDate { get; set; }

        public Purchase()
        {
            Status = 0;
            RaisedDate = DateTime.Now;
            PurchaseProducts = new Collection<PurchaseProduct>();
        }
    }
}
