using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickyTicky.Models
{
    public class ShopModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public long OwnerId { get; set; }
        public double Latitude { get; set; }
        public double Longtitude { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string LogoUrl { get; set; }
    }
}
