﻿using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public partial class Purchase : Entity<int>
    {
        public int Owner { get; set; }
        public double Price { get; set; }
        public string Summary { get; set; }
        public string AvailableAddress { get; set; }
        public DateTime AddedDate { get; set; }
        public Image Image { get; set; }
        public DateTime RaisedDate { get; set; }
        public DateTime AuthorizedDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ReceivedDate { get; set; }
    }
}
